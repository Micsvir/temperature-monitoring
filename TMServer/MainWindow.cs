using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Threading;
using System.IO;
using System.IO.Ports;
using NetSubSys;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace TWServer
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            
            ClientHasBeenConnected += new ReceivingDataDelegate(receivedata);

            LoadSettings();
        }

        //Сервер для передачи данных о температуре
        public static TcpListener server;
        
        //переменная для отправки и получения данных с помощью NetworkStream
        BinaryFormatter bf = new BinaryFormatter();

        //переменная-индикатор состояния сервера
        public static bool started = false;

        //переменная отдельного потока прослушивания порта на входящие tcp-соединения
        public static Thread listeningThread;

        //переменная-счетчик кол-ва подключенных клиентов
        public static int connectedClientsCount = 0;

        //структура для хранения переменных настроек
        [Serializable]
        public struct Settings
        {
            public int serverPort;
            public string comPortName;
            public int comPortSpeed;
            public int dataBits;
            public int logStringsLimit;
            public bool logToFile;
            public bool limitLogStrings;
        }

        //сами настройки
        public static Settings settings = new Settings();

        //индикатор успешной загрузки настроек
        public static bool settingsHaveBeenLoaded = false;

        //структура для хранения информации о клиенте
        public struct ConnectedClient
        {
            public string IP;
            public string hostName;
            public string connectionDate;
            public NetworkStream networkStream;
            public TcpClient tcpClientClassObject;
        }

        //список подключенных клиентов
        public static List<ConnectedClient> connectedClients = new List<ConnectedClient>();

        //описание возможных состояний (статусов) сенсора
        public enum SensStatus
        {
            online,
            offline
        }

        //описание структуры для хранения информации о сенсоре
        [Serializable]
        public struct Sensor
        {
            public string sensSysName;
            public string sensName;
            public string sensDescription;
            public SensStatus sensStatus;
        }

        //список всех добавленных сенсоров
        public static List<Sensor> sensorsList = new List<Sensor>();

        //Т.к. каждый раз при изменении индекса элемента AddEditSensorForm.cbSensors осуществляется
        //проверка на наличие выбираемого сенсора в списке сенсоров, понадобилось ввести дополнительную переменную,
        //которая отключает данную проверку, если ее значение true
        public static bool sensorIsEditing = false;

        //вспомогательная пременная типа Sensor для хранения исходных данных выбранного для редактирования сенсора.
        //Она понадобится для сопоставления исходных данных, которые были на момент открытия формы редактирования и конечных данных,
        //которые появились на момент нажатия кнопки bOk. Если между исходными и конечными данными ничего не поменялось, тогда 
        //форма будет просто закрыта, и никаких дополнительных действий предпринято не будет
        public static Sensor editingSensor = new MainWindow.Sensor();

        public SerialPort sp;
        
        //вспомогательные переменные
        public static bool serverStarted = false;
        public static bool portHasBeenOpened = false;
        public static bool portHasBeenClosed = false;

        //Загрузка настроек из файла
        public void LoadSettings()
        {
            try
            {
                FileStream fs = new FileStream("settings", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                settings = (Settings)bf.Deserialize(fs);
                fs.Close();
                settingsHaveBeenLoaded = true;
            }
            catch (Exception ex)
            {
                settingsHaveBeenLoaded = false;
                MessageBox.Show("Unable to load settings\n\n" + ex.Message);
            }
        }

        //Делегат для вызова метода BeginInvoke в методе SerialPortDataReceived
        public delegate void SetTextDelegate(string text);
        //Делегат для вызова метода BeginInvoke в методе SerialPortDataReceived
        public delegate void SendDataDelegate(NetworkStream clientNS, string dataToSend);

        //Метод позволяет заполнять строки dgvLog полученными по COM-порту данными
        void addDataToLog(string data)
        {
            try
            {
                if (!settings.limitLogStrings)
                {
                    dgvLog.Rows.Add();
                    dgvLog.Rows[dgvLog.Rows.Count - 1].Cells["eventDate"].Value = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                    dgvLog.Rows[dgvLog.Rows.Count - 1].Cells["eventDescription"].Value = data;
                }
                else
                {
                    if (dgvLog.Rows.Count == settings.logStringsLimit)
                    {
                        dgvLog.Rows.RemoveAt(0);
                        dgvLog.Rows.Add();
                        dgvLog.Rows[dgvLog.Rows.Count - 1].Cells["eventDate"].Value = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                        dgvLog.Rows[dgvLog.Rows.Count - 1].Cells["eventDescription"].Value = data;
                    }
                    else
                    {
                        dgvLog.Rows.Add();
                        dgvLog.Rows[dgvLog.Rows.Count - 1].Cells["eventDate"].Value = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                        dgvLog.Rows[dgvLog.Rows.Count - 1].Cells["eventDescription"].Value = data;
                    }
                }
                
                if (settings.logToFile)
                {
                    try
                    {
                        SaveLogToFile(data);
                    }
                    catch (Exception logToFileException)
                    {
                        addEventToLog(logToFileException.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void addEventToLog(string eventString)
        {
            //добавление информации в лог
            try
            {
                this.BeginInvoke(new SetTextDelegate(addDataToLog), new object[] { eventString });
            }
            catch (Exception addingToLogEx)
            {
                MessageBox.Show("Unable to add event to log\n\n" + addingToLogEx.Message);
            }
        }

        //обработчик события получения данных по COM-порту.
        //Создается для события DataReceived класса SerialPort.
        void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            /*
            try
            {
                string dataString = sp.ReadLine();
                this.BeginInvoke(new SetTextDelegate(addDataToLog), new object[] { dataString });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to read data from serial port. " + ex.Message);
            }
            */

            for (int i = 0; i < connectedClients.Count; i++)
            {
                try
                {
                    string dataString = sp.ReadLine();
                    this.BeginInvoke(new SendDataDelegate(sendData), new object[] { connectedClients[i].networkStream, dataString });
                    //sendData(connectedClients[i].networkStream, sp.ReadLine());
                }
                catch (Exception sendDataException)
                {
                    addEventToLog(sendDataException.Message);
                }
            }
        }

        //прослушивание запросов на подключение
        public void listen()
        {
            TcpClient connectedClient = server.AcceptTcpClient();
            NetworkStream ns = connectedClient.GetStream();

            //попытка получить от клиента сообщение с именем хоста (это сообщение клиент отправляет сразу после подключения)
            string hostName = "";
            try
            {
                string firstMsg = (string)bf.Deserialize(ns);
                if (firstMsg.IndexOf("hostname") != -1)
                {
                    hostName = firstMsg.Split('=')[1];
                }
            }
            catch (Exception firstMsgException)
            {
                addEventToLog(firstMsgException.Message);
            }

            //добавление подключенного клиента в список connectedClients
            ConnectedClient newConnectedClient = new ConnectedClient();
            newConnectedClient.connectionDate = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
            newConnectedClient.IP = connectedClient.Client.RemoteEndPoint.ToString().Split(':')[0];
            newConnectedClient.hostName = hostName;
            newConnectedClient.networkStream = ns;
            newConnectedClient.tcpClientClassObject = connectedClient;
            connectedClients.Add(newConnectedClient);

            //добавление подключенного клиента в dgvConnectedClients
            this.BeginInvoke(new ReceivingDataDelegate(addConnectedClientToDGV), new object[] { newConnectedClient });

            //увеличение счетчика подключенных клиентов на единицу
            connectedClientsCount++;
            ConnectedClientsCount.Text = "Connected clients count: " + connectedClientsCount;

            //добавление информации в лог
            addEventToLog("New client on " + newConnectedClient.hostName + " with ip " + newConnectedClient.IP + " connected");

            //вызов соответствующего события
            if (ClientHasBeenConnected != null)
            {
                ClientHasBeenConnected(newConnectedClient);
            }
        }

        //делегат, события и методы получения сообщений от клиентов, добавления и удаления клиентов из списков
        public delegate void ReceivingDataDelegate(ConnectedClient connectedClient);
        public event ReceivingDataDelegate ClientHasBeenConnected;
        public void receivedata(ConnectedClient curConnectedClient)
        {
            bool stop = false;

            listeningThread = new Thread(new ThreadStart(listen));
            listeningThread.IsBackground = true;
            listeningThread.Start();

            while (!stop)
            {
                if (curConnectedClient.networkStream != null)
                {
                    try
                    {
                        //получение сообщения от клиента
                        string message = (string)bf.Deserialize(curConnectedClient.networkStream);

                        //если сообщение = "disconnect", значит, клиент хочет разорвать соединение
                        if (message == "disconnect")
                        {
                            //Удаление клиента из списка подключенных клиентов
                            int index = -1;
                            for (int i = 0; i < connectedClients.Count; i++)
                            {
                                if (connectedClients[i].networkStream == curConnectedClient.networkStream)
                                {
                                    index = i;
                                }
                            }

                            if (index != -1)
                            {
                                try
                                {
                                    connectedClients.RemoveAt(index);
                                    this.BeginInvoke(new RemoveClientDelegate(RemoveConnectedClientFromDGV), new object[] { index });
                                }
                                catch (Exception ex)
                                {
                                    //добавление информации в лог
                                    addEventToLog("Не удалось удалить клиента. " + ex.Message);
                                }
                            }
                            else
                            {
                                //добавление информации в лог
                                addEventToLog("Не удалось найти клиента для удаления");
                            }

                            //отправка ответного сообщения о закрытии соединения
                            bf.Serialize(curConnectedClient.networkStream, "disconnect");

                            //Закрытие подключений
                            curConnectedClient.tcpClientClassObject.Close();
                            curConnectedClient.networkStream.Close();

                            //уменьшение счетчика подключенных клиентов на единицу
                            connectedClientsCount--;
                            ConnectedClientsCount.Text = "Connected clients count: " + connectedClientsCount;

                            stop = true;

                            //добавление информации в лог
                            addEventToLog("Client on " + curConnectedClient.hostName + "with ip " + curConnectedClient.IP + " disconnected");
                        }
                        else
                        {
                            //MessageBox.Show(message);
                            for (int i = 0; i < 5; i++)
                            {
                                sendData(curConnectedClient.networkStream, "message from the server " + i.ToString());
                                Thread.Sleep(2000);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //удаление клиента ото всюду, откуда только возможно
                        int indexToDelete = -1;
                        for (int i = 0; i < connectedClients.Count; i++)
                        {
                            if (connectedClients[i].networkStream == curConnectedClient.networkStream)
                            {
                                indexToDelete = i;
                            }
                        }

                        if (indexToDelete != -1)
                        {
                            try
                            {
                                connectedClients.RemoveAt(indexToDelete);
                                this.BeginInvoke(new RemoveClientDelegate(RemoveConnectedClientFromDGV), new object[] { indexToDelete });
                            }
                            catch (Exception ex1)
                            {
                                addEventToLog("Не удалось удалить клиента. " + ex1.Message);
                            }
                        }
                        else
                        {
                            addEventToLog("Отключенный клиент не удален. Не удалось найти элемент для удаления");
                        }

                        //закрытие всего, чего только можно
                        curConnectedClient.networkStream.Close();
                        curConnectedClient.tcpClientClassObject.Close();
                        //добавление информации в лог
                        addEventToLog(ex.Message);
                        stop = true;

                        //уменьшение счетчика подключенных клиентов на единицу
                        connectedClientsCount--;
                        ConnectedClientsCount.Text = "Connected clients count: " + connectedClientsCount;

                        //добавление информации в лог
                        addEventToLog("Client (" + curConnectedClient.IP + ", " + curConnectedClient.hostName + ") disconnected");
                    }
                }
            }
        }

        public void addConnectedClientToDGV(ConnectedClient connectedClient)
        {
            dgvConnectedClients.Rows.Add();
            int lastRow = dgvConnectedClients.Rows.Count - 1;
            dgvConnectedClients.Rows[lastRow].Cells["connectionDate"].Value = connectedClient.connectionDate;
            dgvConnectedClients.Rows[lastRow].Cells["hostIP"].Value = connectedClient.IP;
            dgvConnectedClients.Rows[lastRow].Cells["hostName"].Value = connectedClient.hostName;
        }

        //Делегат и метод удаления клиента из dgvConnectedClients при разрыве соединения
        public delegate void RemoveClientDelegate(int dgvIndex);
        public void RemoveConnectedClientFromDGV(int index)
        {
            dgvConnectedClients.Rows.RemoveAt(index);
        }

        //отправка сообщения клиенту
        public void sendData(NetworkStream clientNS, string data)
        {
            bf.Serialize(clientNS, data);
        }

        //Сохранение очередного события в лог-файле
        public void SaveLogToFile(string eventString)
        {
            try
            {
                StreamWriter LogWriter = new StreamWriter(DateTime.Now.ToShortDateString() + ".log", true, Encoding.Default);
                lock (LogWriter)
                {
                    LogWriter.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " " + eventString);
                    LogWriter.Close();
                }
            }
            catch (Exception logToFileException)
            {
                addEventToLog("Unable to write event to log file. " + logToFileException.Message);
            }
        }

        private void tsbAddSensor_Click(object sender, EventArgs e)
        {
            /*
            AddEditSensorForm addSensorForm = new AddEditSensorForm();
            addSensorForm.Show();
            */
        }

        private void tsbRemoveSensor_Click(object sender, EventArgs e)
        {
            /*
            //если выбран какой-либо элемент списка dgvSensors
            if (dgvSensors.SelectedRows.Count > 0)
            {
                //Если пользователь подтвердил свое намерение удалить сенсор
                if (MessageBox.Show("Are you sure you want to delete sensor " + dgvSensors.SelectedRows[0].Cells["sensorSystemName"].Value + "?", "You are about to delete an item from sensors list", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    //подготавливается переменная для передачи в обработчик события удаления сенсора
                    Sensor sensorToDelete = new Sensor();

                    //удалить сенсор из списка sensorsList можно зная только sensSysName, т.к. оно гарантировано не повторяется (это условие проверяется при
                    //добавлении нового сенсора), поэтому нет нужды помещать в переменную sensorToDelete всю известную информацию из dgvSensors
                    sensorToDelete.sensSysName = dgvSensors.SelectedRows[0].Cells["sensorSystemName"].Value.ToString();

                    //определяется индекс удаляемого элемента в списке dgvSensors
                    int sensorIndex = -1;
                    for (int i = 0; i < dgvSensors.Rows.Count; i++)
                    {
                        if (dgvSensors.Rows[i].Cells["sensorSystemName"].Value == dgvSensors.SelectedRows[0].Cells["sensorSystemName"].Value)
                        {
                            sensorIndex = i;
                        }
                    }

                    //если индекс равен -1, значит, что-то пошло не так, и удаляемый элемент найден не был
                    if (sensorIndex == -1)
                    {
                        MessageBox.Show("Error occured. Unable to delete selected item. Item hasnt been found in sensors' list");
                    }
                    //елемент удаляется
                    else
                    {
                        dgvSensors.Rows.RemoveAt(sensorIndex);
                    }

                    //вызывается соответствующее событие.
                    //Оно нужно для удаления этого элемента из списка sensorsList
                    if (sensorHasBeenDeleted != null)
                    {
                        sensorHasBeenDeleted(sensorToDelete);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item you want to delete");
            }
            */
        }

        private void tsbEditSensor_Click(object sender, EventArgs e)
        {
            /*
            if (dgvSensors.SelectedRows.Count > 0)
            {
                AddEditSensorForm editSensorForm = new AddEditSensorForm();
                editSensorForm.Text = "Edit sensor";
                sensorIsEditing = true;

                //данные выбранного в dgvSensor сенсора помещаются во вспомогательную переменную
                editingSensor.sensSysName = dgvSensors.SelectedRows[0].Cells["sensorSystemName"].Value.ToString();
                editingSensor.sensName = dgvSensors.SelectedRows[0].Cells["sensorUserName"].Value.ToString();
                editingSensor.sensDescription = dgvSensors.SelectedRows[0].Cells["sensorDescription"].Value.ToString();
                
                //поиск индекса элемента cbSensors, совпадающего с выбранным элементом из dgvSensors
                int sensorIndex = -1;
                for (int i = 0; i < editSensorForm.cbSensors.Items.Count; i++)
                {
                    if (editSensorForm.cbSensors.Items[i].ToString() == editingSensor.sensSysName)
                    {
                        sensorIndex = i;
                    }
                }

                //если значение переменной sensorIndex не равно -1, значит, в процессе поиска был
                //найден индекс элемента, значение которого совпадает со значением переменной selectedSensor
                if (sensorIndex != -1)
                {
                    //индекс выбранного элемента устанавливается в соответствующее значение
                    editSensorForm.cbSensors.SelectedIndex = sensorIndex;
                    
                    //а контрол editSensorForm.cbSensor становится недоступным для использования
                    editSensorForm.cbSensors.Enabled = false;

                    //оставшиеся поля заполняются соответствующими значениями
                    editSensorForm.tbSensorName.Text = editingSensor.sensName;
                    editSensorForm.tbSensorDescription.Text = editingSensor.sensDescription;

                    //после всех этих подготовительных действий отображается и сама форма редактирования
                    editSensorForm.Show();
                }
                else
                {
                    MessageBox.Show("Error occured. Unable to find selected item in ComboBox");
                    editSensorForm.Close();
                }
            }
            else
            {
                MessageBox.Show("Please select an item you want to edit");
            }
            */
        }

        //запуск и остановка сервера
        private void tsbStartStop_Click(object sender, EventArgs e)
        {
            if (!started)
            {
                try
                {
                    sp = new SerialPort(settings.comPortName, settings.comPortSpeed, Parity.None, settings.dataBits, StopBits.One);
                    sp.Open();
                    sp.DataReceived += new SerialDataReceivedEventHandler(SerialPortDataReceived);
                    server = new TcpListener(settings.serverPort);
                    server.Start();
                    listeningThread = new Thread(new ThreadStart(listen));
                    listeningThread.IsBackground = true;
                    listeningThread.Start();
                    started = true;
                    tsbStartStop.Text = "Stop";
                    serverStatus.Text = "Server status: online";

                    //добавление информации в лог
                    addEventToLog("Server has been started");
                }
                catch (Exception ex)
                {
                    //добавление информации в лог
                    addEventToLog("Unable to start server. " + ex.Message);
                }
            }
            else
            {
                try
                {
                    sp.Close();
                    listeningThread.Abort();
                    server.Stop();
                    started = false;
                    connectedClients.Clear();
                    dgvConnectedClients.Rows.Clear();
                    connectedClientsCount = 0;
                    ConnectedClientsCount.Text = "Connected clients count: " + connectedClientsCount;
                    tsbStartStop.Text = "Start";
                    serverStatus.Text = "Server status: offline";

                    //добавление информации в лог
                    addEventToLog("Server has been stoped");
                }
                catch (Exception ex)
                {
                    //добавление информации в лог
                    addEventToLog("Unable to stop server\n\n" + ex.Message);
                }
            }
        }

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

    }
}
