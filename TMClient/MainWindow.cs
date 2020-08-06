using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NetSubSys;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.IO;
using System.Media;

namespace TWClient
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            //подписки на события осуществляются в методе MainWindow_Shown
        }

        //структура для хранения переменных настроек
        [Serializable]
        public struct Settings
        {
            public string serverIP;
            public int serverPort;
            public bool useTempLimits;
            public int minTemperature;
            public int maxTemperature;
            public bool limitLogStrings;
            public int logStringsLimit;
            public bool logToFile;
            public bool useSound;
            public string soundFilePath;
            public bool temperatureInLog;
        }

        //сами настройки
        public static Settings settings = new Settings();

        //описание возможных состояний (статусов) сенсора
        public enum SensStatus
        {
            offline,
            online
        }

        //описание структуры для хранения информации о сенсоре
        [Serializable]
        public struct Sensor
        {
            public string sensSysName;
            public string sensName;
            public float sensLastTemp;
            public string sensDescription;
            public SensStatus sensStatus;
        }

        //список всех добавленных сенсоров
        public static List<Sensor> sensorsList = new List<Sensor>();

        //описание параметра, содержащегося в строке, значения которого необходимо отслеживать.
        //Класс взят из проекта KSLA, где на его основе из лог файла формировалась таблица значений указанных параметров.
        //Некоторые функции класса в условиях этого проекта не нужны.
        public class WatchedParameter
        {
            public string sourceString;
            private string _stringSeparator;
            private string _paramName;
            public string paramName
            {
                get
                {
                    return _paramName;
                }
            }
            public string ColumnName;
            private bool _fixedName;
            private bool _fixedLengthAndPosition;
            private bool _valueExists;
            private string _paramSeparator;
            private int _paramPositionInSymbols;
            private int _paramPositionInWords;
            private List<string> _paramValues = new List<string>();
            private string _settingsDescription;
            public string settingsDescription
            {
                get
                {
                    return _settingsDescription;
                }
            }
            public string foundValueOrParameter;

            //поиск в строке параметра или его значения
            public void FindParameterValue()
            {
                foundValueOrParameter = "";

                if (_fixedName)
                {
                    if (_valueExists)
                    {
                        //позиция искомого параметра
                        //несмотря на то, что значение этой переменной задается в конструкторе класса
                        //на этапе создания объекта класса, это значение повторно вычисляется здесь для того,
                        //чтобы алгоритм правильно отрабатывал случаи, когда параметр ищется в строках разной длинны
                        _paramPositionInSymbols = sourceString.IndexOf(_paramName);

                        //позиция разделителя параметра и значения
                        int separatorPosition = _paramPositionInSymbols + _paramName.Length;

                        //позиция значения
                        int valuePosition = separatorPosition + _paramSeparator.Length;

                        //если, начиная с позиции значения для указанного параметра, до конца строки не встречаются
                        //разделители строки, значит, эти параметр и его значение являются последним словом в строке.
                        //Если это действительно так, нет смысла в цикле, который формирует значение для указанного параметра
                        //в цикле while до тех пор, пока не будет встречен символ разделителя строки (т.к. он не будет встречен)
                        int StrSepCount = 0;
                        for (int i = valuePosition; i < sourceString.Length - _stringSeparator.Length; i++)
                        {
                            if (sourceString.Substring(i, _stringSeparator.Length) == _stringSeparator)
                            {
                                StrSepCount++;
                            }
                        }

                        //Если после значения параметра обнаружились разделители строки, тогда используется цикл
                        //с условием нахождения следующего разделителя строки
                        if (StrSepCount > 0)
                        {
                            while (sourceString.Substring(valuePosition, _stringSeparator.Length) != _stringSeparator)
                            {
                                foundValueOrParameter += sourceString[valuePosition];
                                valuePosition++;
                            }
                        }
                        //иначе используется цикл до конца строки
                        else
                        {
                            while (valuePosition < sourceString.Length)
                            {
                                foundValueOrParameter += sourceString[valuePosition];
                                valuePosition++;
                            }
                        }
                    }

                    //Бредовый else, если задуматься.
                    //Если имя параметра не изменяется и при этом в строке не содержится его значения, значит, это
                    //просто какое-то слово или какая-то фраза, которая есть в строке и всегда одинаковая.
                    //Но в этом случае создавать столбец для того, чтобы хранить в нем эту фразу или это слово бессмысленно,
                    //т.к. весь столбец будет заполнен одинаковыми значениями
                    else
                    {
                        _paramPositionInSymbols = sourceString.IndexOf(_paramName);
                        int curPosition = _paramPositionInSymbols;
                        while (sourceString.Substring(curPosition, _stringSeparator.Length) != _stringSeparator)
                        {
                            foundValueOrParameter += sourceString[curPosition];
                            curPosition++;
                        }
                    }
                }

                if (!_fixedName)
                {
                    //в случае, если имя параметра изменяется, но длинна параметра при этом неизменна,
                    //под позицией параметра в строке понимается не количество символов от начала строки до
                    //интересующего параметра, а количество слов от начала строки до него. Или, что практически
                    //одно и то же, кол-во разделителей строки (т.е., например, пробелов)
                    if (_fixedLengthAndPosition)
                    {
                        int curSepCount = 0;
                        int curPosition = 0;
                        while (curSepCount < _paramPositionInWords)
                        {
                            if (sourceString.Substring(curPosition, _stringSeparator.Length) == _stringSeparator)
                            {
                                curSepCount++;
                            }
                            curPosition++;
                        }
                        foundValueOrParameter = sourceString.Substring(curPosition, _paramName.Length);
                    }

                    //в случае, если имя параметра не фиксировано, длинна параметра и позиция параметра в строке, не являются постоянными,
                    //ничего не остается, кроме как перечислить все возможные значения, которые может принять данный параметр, причем
                    //внезависимости от того, присутствует ли значения для этого параметра в строке или нет
                    else
                    {
                        if (_paramValues != null)
                        {
                            if (!_valueExists)
                            {
                                foreach (string curParamValue in _paramValues)
                                {
                                    if (sourceString.IndexOf(curParamValue) != -1)
                                    {
                                        foundValueOrParameter = curParamValue;
                                    }
                                }
                            }
                            else
                            {
                                foreach (string curParam in _paramValues)
                                {
                                    if (sourceString.IndexOf(curParam) != -1)
                                    {
                                        _paramPositionInSymbols = sourceString.IndexOf(curParam);

                                        //позиция разделителя параметра и значения
                                        int separatorPosition = _paramPositionInSymbols + _paramName.Length;

                                        //позиция значения
                                        int valuePosition = separatorPosition + _paramSeparator.Length;

                                        int StrSepCount = 0;
                                        for (int i = valuePosition; i < sourceString.Length - _stringSeparator.Length; i++)
                                        {
                                            if (sourceString.Substring(i, _stringSeparator.Length) == _stringSeparator)
                                            {
                                                StrSepCount++;
                                            }
                                        }

                                        if (StrSepCount > 0)
                                        {
                                            while (sourceString.Substring(valuePosition, _stringSeparator.Length) != _stringSeparator)
                                            {
                                                foundValueOrParameter += sourceString[valuePosition];
                                                valuePosition++;
                                            }
                                        }
                                        //иначе используется цикл до конца строки
                                        else
                                        {
                                            while (valuePosition < sourceString.Length)
                                            {
                                                foundValueOrParameter += sourceString[valuePosition];
                                                valuePosition++;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            public WatchedParameter(string stringSample, string stringSeparator, string parameterName, int paramPosition, string parameterSeparator, bool fixedName, bool fixedLengthAndPosition, bool valueExists, List<string> paramValues)
            {
                sourceString = stringSample;
                _stringSeparator = stringSeparator;
                _paramName = parameterName;
                _paramSeparator = parameterSeparator;
                _fixedName = fixedName;
                _fixedLengthAndPosition = fixedLengthAndPosition;
                _valueExists = valueExists;
                _paramValues = paramValues;

                _paramPositionInSymbols = paramPosition;

                int curPosition = 0;
                while (curPosition < _paramPositionInSymbols)
                {
                    if (stringSample.Substring(curPosition, _stringSeparator.Length) == _stringSeparator)
                    {
                        _paramPositionInWords++;
                    }
                    curPosition++;
                }

                if (_fixedName)
                {
                    _settingsDescription += "имя параметра фиксированно; ";
                }
                else
                {
                    _settingsDescription += "имя параметра не фиксированно; ";
                }
                if (_fixedLengthAndPosition)
                {
                    _settingsDescription += "длинна имени параметра и его позиция в строке фиксированны; ";
                }
                else
                {
                    _settingsDescription += "длинна имени параметра и его позиция в строке не фиксированны; ";
                }
                if (_valueExists)
                {
                    _settingsDescription += "в строке содержится значение для указанного параметра; ";
                }
                else
                {
                    _settingsDescription += "в строке не содержится значения для указанного параметра; ";
                }
                if (paramValues != null)
                {
                    if (paramValues.Count > 0)
                    {
                        _settingsDescription += "\nвозможные варианты параметра: ";
                        for (int i = 0; i < paramValues.Count; i++)
                        {
                            _settingsDescription += (i + 1).ToString() + ". " + paramValues[i] + "; ";
                        }
                    }
                }
            }
        }
        public static WatchedParameter temp = new WatchedParameter(null, " ", "temp", 0, "=", true, false, true, null);

        //событие удаления сенсора из списка dgvSensors
        public static event AddEditSensorForm.changingSensorsListHandler sensorHasBeenDeleted;

        //Т.к. каждый раз при изменении индекса элемента AddEditSensorForm.cbSensors осуществляется
        //проверка на наличие выбираемого сенсора в списке сенсоров, понадобилось ввести дополнительную переменную,
        //которая отключает данную проверку, если ее значение true
        public static bool sensorIsEditing = false;

        //вспомогательная пременная типа Sensor для хранения исходных данных выбранного для редактирования сенсора.
        //Она понадобится для сопоставления исходных данных, которые были на момент открытия формы редактирования и конечных данных,
        //которые появились на момент нажатия кнопки bOk. Если между исходными и конечными данными ничего не поменялось, тогда 
        //форма будет просто закрыта, и никаких дополнительных действий предпринято не будет
        public static Sensor editingSensor = new MainWindow.Sensor();

        //клиент для реализации клиент-серверной архитектуры
        //public static NetSubSys.Client client;
        public static TcpClient client;
        NetworkStream ns;
        BinaryFormatter bf = new BinaryFormatter();
        public static bool connected = false;
        public static bool settingsHaveBeenLoaded = false;
        Thread connectionThread;
        //вспомогательный массив из сообщений, полученных от сервера. Kол-во сообщений в этом массиве
        //не превышает кол-ва сенсоров в sensorsList. Всякий раз, когда в массиве набирается максимальное кол-во сообщений, происходит сравнение сенсоров
        //в массиве с сенсорами из sensorsList для определения сенсоров, которые перестали отсылать данные на сервер
        public static List<string> temperatureMessages = new List<string>();

        //при наступлении события AddEditSensorFrom.sensorHasBeenAdded
        //добавленный к списку sensorsList сенсор добавляется еще и к dgvSensors
        public void addSensorToDGV(Sensor sensor)
        {
            if (this.InvokeRequired)
            {
                AddEditSensorForm.changingSensorsListHandler eventHandler = new AddEditSensorForm.changingSensorsListHandler(addSensorToDGV);
                this.Invoke(eventHandler, new object[] { sensor });
            }
            else
            {
                dgvSensors.Rows.Add();
                int lastRowIndex = dgvSensors.Rows.Count - 1;
                dgvSensors.Rows[lastRowIndex].Cells["sensorSystemName"].Value = sensor.sensSysName;
                dgvSensors.Rows[lastRowIndex].Cells["sensorUserName"].Value = sensor.sensName;
                dgvSensors.Rows[lastRowIndex].Cells["sensorDescription"].Value = sensor.sensDescription;

                addEventToLog("Sensor " + sensor.sensSysName + " with user name \"" + sensor.sensName + "\" has been added", Color.Black);
            }
        }

        //обработчик события sensorHasBeenDeleted
        public void deleteSensorFromSensorsList(Sensor sensor)
        {
            if (this.InvokeRequired)
            {
                AddEditSensorForm.changingSensorsListHandler eventHandler = new AddEditSensorForm.changingSensorsListHandler(deleteSensorFromSensorsList);
                this.Invoke(eventHandler, new object[] { sensor });
            }
            else
            {
                int sensorIndex = -1;
                for (int i = 0; i < sensorsList.Count; i++)
                {
                    if (sensorsList[i].sensSysName == sensor.sensSysName)
                    {
                        sensorIndex = i;
                    }
                }

                if (sensorIndex != -1)
                {
                    sensorsList.RemoveAt(sensorIndex);
                    addEventToLog("Sensor " + sensor.sensSysName + " with user name \"" + sensor.sensName + "\" has been removed", Color.Black);
                }
                else
                {
                    addEventToLog("Error occured. Unable to remove selected item. Item hasnt been found in sensors' list", Color.Black);
                }
            }
        }

        //обработчик события AddEditSensorForm.sensorHasBeenChanged
        public void UpdateSensorsData(Sensor sensor)
        {
            //вспомогательная переменная, принимающая значение true, если обновление элемента списка sensorsList
            //прошло успешно
            bool sensorsListHasBeenUpdated = false;

            //поиск в MainWindow.sensorsList соответствующего сенсора (по полю sensSysName) и обновление его свойств
            int targetIndex = -1;
            for (int i = 0; i < sensorsList.Count; i++)
            {
                if (editingSensor.sensSysName == sensorsList[i].sensSysName)
                {
                    targetIndex = i;
                }
            }

            if (targetIndex != -1)
            {
                sensorsList[targetIndex] = editingSensor;
                sensorsListHasBeenUpdated = true;

                addEventToLog("Sensor " + editingSensor.sensSysName + " info has been successfuly changed", Color.Black);
            }
            else
            {
                addEventToLog("Error occured. Unable to find editing sensor in sensorsList", Color.Black);
            }

            //если обновление элемента списка sensorsList было успешным
            //осуществляется процедура обновления dgvSensors
            if (sensorsListHasBeenUpdated)
            {
                targetIndex = -1;
                for (int i = 0; i < dgvSensors.Rows.Count; i++)
                {
                    if (dgvSensors.Rows[i].Cells["sensorSystemName"].Value.ToString() == editingSensor.sensSysName)
                    {
                        targetIndex = i;
                    }
                }
            }

            if (targetIndex != -1)
            {
                dgvSensors.Rows[targetIndex].Cells["sensorUserName"].Value = editingSensor.sensName;
                dgvSensors.Rows[targetIndex].Cells["sensorDescription"].Value = editingSensor.sensDescription;
            }
            else
            {
                addEventToLog("Error occured. Unable to find editing sensor in DataGridView", Color.Black);
            }
        }

        //подключение к серверу и прослушивание входящих сообщений от сервера
        public void connect()
        {
            //вспомогательная переменная
            bool connectionWasSuccessful = false;

            //попытка подключения к серверу
            try
            {
                client = new TcpClient();
                client.Connect(settings.serverIP, settings.serverPort);
                ns = client.GetStream();
                connectionWasSuccessful = true;

                //попытка отправить сообщение на сервер с информацией об имени хоста
                try
                {
                    string hostName = System.Net.Dns.GetHostName();
                    hostName = "hostname=" + hostName;
                    bf.Serialize(ns, hostName);
                }
                catch
                { }

                connected = true;

                //событие
                if (Connected != null)
                {
                    Connected("connected", Color.Green);
                }

                tsbConnect.Text = "Disconnect";

                addEventToLog("Connected to the server", Color.Black);
            }
            catch (Exception ex)
            {
                addEventToLog(ex.Message, Color.Black);
            }

            //если соединение прошло успешно, вызывается метод получения сообщений от сервера в отдельном потоке
            if (connectionWasSuccessful)
            {
                Thread dataReceivingThread = new Thread(new ThreadStart(receiveData));
                dataReceivingThread.IsBackground = true;
                dataReceivingThread.Start();
            }
        }

        //делегат для события получения сообщения от сервера
        public delegate void ReceiveDataDelegate(string data);
        //событие получения сообщения от сервера
        public event ReceiveDataDelegate MessageHasBeenReceived;
        //получение входящих сообщений от сервера
        public void receiveData()
        {
            //вспомогательная переменная, необходимая для выхода из цикла while
            bool stop = false;

            while (!stop)
            {
                //на всякий случай выполняется проверка инициализации экземпляра класса NetworkStream
                if (ns != null)
                {
                    //получение сообщений от сервера выполняется в блоке try
                    try
                    {
                        string message = (string)bf.Deserialize(ns);

                        //если было получено сообщение с тектом "disconnect", значит сервер отключил этого клиента
                        //или завершил свою работу. Поэтому необходимо завершить цикл получения сообщений от сервера
                        //закрыть поток и экземпляр класса TcpClient.
                        if (message == "disconnect")
                        {
                            stop = true;
                            ns.Close();
                            client.Close();

                            connected = false;

                            //событие
                            if (Disconnected != null)
                            {
                                Disconnected("disconnected", Color.Red);
                            }

                            tsbConnect.Text = "Connect";

                            addEventToLog("Disconnected from the server", Color.Black);
                        }
                        else
                        {
                            //отслеживание сенсоров.
                            //информация о сенсорах, не указанных в списке отслеживаемых сенсоров, не будет отображаться.
                            //в результате отслеживания у сенсоров из списка ослеживаемых сенсоров появятся статусы online и offline.

                            //Если количество сообщений, добавленных во вспомогательный лист temperatureMessages, стало равным количеству сенсоров
                            //в sensorsList
                            if (temperatureMessages.Count == sensorsList.Count)
                            {
                                //каждый сенсор из sensorList
                                for (int i = 0; i < sensorsList.Count; i++)
                                {
                                    bool thereIsASensor = false;

                                    //сравнивается с каждым сенсором, взятым из сообщений temperatureMessages
                                    for (int j = 0; j < temperatureMessages.Count; j++)
                                    {
                                        string sensorFromTempMsg = "";
                                        WatchedParameter sensor = new WatchedParameter(temperatureMessages[j], " ", "s01", 0, "=", false, true, false, null);
                                        sensor.FindParameterValue();
                                        sensorFromTempMsg = sensor.foundValueOrParameter;

                                        //если в результате сравнения сенсора из sensorsList с сенсором из temperatureMessages
                                        if (sensorsList[i].sensSysName == sensorFromTempMsg)
                                        {
                                            //переменная thereIsASensor принимает значение true, что свидетельствует о том, что среди полученных сообщений
                                            //было сообщение от сенсора sensorsList[i], а следовательно, он исправен и ему следует присвоить статус "online".
                                            thereIsASensor = true;
                                        }
                                    }

                                    //присвоение статуса сенсору
                                    if (thereIsASensor)
                                    {
                                        Sensor updatedSensor = new Sensor();
                                        updatedSensor.sensName = sensorsList[i].sensName;
                                        updatedSensor.sensSysName = sensorsList[i].sensSysName;
                                        updatedSensor.sensDescription = sensorsList[i].sensDescription;
                                        updatedSensor.sensStatus = SensStatus.online;
                                        sensorsList[i] = updatedSensor;
                                    }
                                    else
                                    {
                                        Sensor updatedSensor = new Sensor();
                                        updatedSensor.sensName = sensorsList[i].sensName;
                                        updatedSensor.sensSysName = sensorsList[i].sensSysName;
                                        updatedSensor.sensDescription = sensorsList[i].sensDescription;
                                        updatedSensor.sensStatus = SensStatus.offline;
                                        sensorsList[i] = updatedSensor;
                                        
                                        if (settings.useSound)
                                        {
                                            PlayTheSound();
                                        }
                                    }

                                    //обновление инфы в dgvSensors
                                    UpdateSensorStatus(sensorsList[i]);
                                }
                                temperatureMessages.Clear();
                            }
                            else
                            {
                                temperatureMessages.Add(message);
                            }

                            //обновление sensorsList[i].sensLastTemp и соответствующего столбца dgvSensors
                            string sensorFromMessage = "";
                            WatchedParameter sens = new WatchedParameter(message, " ", "s01", 0, "=", false, true, false, null);
                            sens.FindParameterValue();
                            sensorFromMessage = sens.foundValueOrParameter;
                            //если в результате предыдущих манипуляций переменная sensorFromMessage оказалась не пустой,
                            //есть все основания полагать, что в ней находится имя сенсора
                            if (sensorFromMessage != "")
                            {
                                //далее по имени сенсора из сообщения осуществляется поиск сенсора из списка сенсоров
                                for (int i = 0; i < sensorsList.Count; i++)
                                {
                                    if (sensorsList[i].sensSysName == sensorFromMessage)
                                    {
                                        //и для него формируется значение температуры в переменную tempResult
                                        WatchedParameter sensorTemp = new WatchedParameter(message, " ", "temp", 0, "=", true, false, true, null);
                                        sensorTemp.FindParameterValue();
                                        try
                                        {
                                            int firstPartOfNumber = Convert.ToInt32(sensorTemp.foundValueOrParameter.Split('.')[0]);
                                            int secondPartOfNumber = Convert.ToInt32(sensorTemp.foundValueOrParameter.Split('.')[1]);
                                            float tempResult = -555;
                                            tempResult = firstPartOfNumber + (float)secondPartOfNumber / 100;
                                            //после чего создается вспомогательная пременная updateSensor
                                            //с помощью которой обновленная информация помещается в sensorsList[i]
                                            Sensor updatedSensor = new Sensor();
                                            updatedSensor.sensName = sensorsList[i].sensName;
                                            updatedSensor.sensSysName = sensorsList[i].sensSysName;
                                            updatedSensor.sensDescription = sensorsList[i].sensDescription;
                                            updatedSensor.sensLastTemp = tempResult;
                                            sensorsList[i] = updatedSensor;

                                            UpdateSensorLastTemperature(sensorsList[i]);
                                        }
                                        catch (Exception updateTempInfoException)
                                        {
                                            addEventToLog("Unable to update temperature last value for " + sensorsList[i].sensSysName + " sensor. " + updateTempInfoException.Message, Color.Black);
                                        }
                                    }
                                }
                            }

                            //если отслеживаются показания температуры (т.е. стоит галочка "Use temperature limits")
                            if (settings.useTempLimits)
                            {
                                temp.sourceString = message;
                                temp.FindParameterValue();

                                //преобразование в float
                                float tempResult = -273;
                                if (temp.foundValueOrParameter != "")
                                {
                                    int firstPartOfNumber = Convert.ToInt32(temp.foundValueOrParameter.Split('.')[0]);
                                    int secondPartOfNumber = Convert.ToInt32(temp.foundValueOrParameter.Split('.')[1]);
                                    tempResult = firstPartOfNumber + secondPartOfNumber / 100;

                                    //сравнение
                                    if (tempResult > settings.maxTemperature || tempResult < settings.minTemperature)
                                    {
                                        //покрасить строчку в красный цвет
                                        if (settings.temperatureInLog)
                                        {
                                            addEventToLog(message, Color.Red);
                                        }
                                        else
                                        {
                                            WatchedParameter sensorName = new WatchedParameter(message, " ", "s01", 0, "=", false, true, false, null);
                                            sensorName.FindParameterValue();
                                            addEventToLog("Sensor " + sensorName.foundValueOrParameter + " temperature value is out of limits!", Color.Red);
                                        }

                                        //если включено звуковое оповещение, воспроизвести звук
                                        if (settings.useSound)
                                        {
                                            PlayTheSound();
                                        }
                                    }
                                    else
                                    {
                                        if (settings.temperatureInLog)
                                        {
                                            addEventToLog(message, Color.Black);
                                        }
                                    }
                                }
                                else
                                {
                                    addEventToLog("Unable to get temperature value from received string", Color.Black);
                                }
                            }
                            else
                            {
                                if (settings.temperatureInLog)
                                {
                                    addEventToLog(message, Color.Black);
                                }
                            }
                        }

                        //вызов соответствующего события (25.02.2019: на данный момент у события нет ни одного обработчика)
                        if (MessageHasBeenReceived != null)
                        {
                            MessageHasBeenReceived(message);
                        }
                    }
                    catch (Exception ex)
                    {
                        addEventToLog(ex.Message, Color.Black);
                        addEventToLog("Соединение будет разорвано. Выполните повторное подключение к серверу", Color.Black);
                        ns.Close();
                        client.Close();
                        stop = true;

                        connected = false;

                        tsbConnect.Text = "Connect";

                        //событие
                        if (Disconnected != null)
                        {
                            Disconnected("disconnected", Color.Red);
                        }
                    }
                }
            }
        }

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

                if (settings.serverIP != null || settings.serverIP != "")
                {
                    lServerIP.Text = settings.serverIP;
                    lServerIP.ForeColor = Color.Green;
                }
                lServerPort.Text = settings.serverPort.ToString();
                lServerPort.ForeColor = Color.Green;

                addEventToLog("Settings have been successfuly loaded", Color.Black);
            }
            catch (Exception ex)
            {
                settingsHaveBeenLoaded = false;
                addEventToLog("Unable to load settings" + ex.Message, Color.Black);
            }
        }

        //метод для события SettingsForm.SettingsUpdated;
        public void UpdateCaptionsAndColors()
        {
            if (this.InvokeRequired)
            {
                SettingsForm.SettingsUpdatedDelegate sud = new SettingsForm.SettingsUpdatedDelegate(UpdateCaptionsAndColors);
                this.BeginInvoke(sud, new object[] { });
            }
            else
            {
                if (settings.serverIP != null || settings.serverIP != "")
                {
                    lServerIP.Text = settings.serverIP;
                    lServerIP.ForeColor = Color.Green;
                }
                lServerPort.Text = settings.serverPort.ToString();
                lServerPort.ForeColor = Color.Green;
            }
        }

        //сохранение списка датчиков
        public void SaveSensorsList()
        {
            try
            {
                FileStream fs = new FileStream("sensors", FileMode.Create);
                BinaryFormatter biform = new BinaryFormatter();
                biform.Serialize(fs, sensorsList);
                fs.Close();
                addEventToLog("Sensors list has been successfuly saved", Color.Black);
            }
            catch(Exception saveSensorsException)
            {
                addEventToLog("Unable to save sensors list. " + saveSensorsException.Message, Color.Black);
            }
        }

        //загрузка списка датчиков
        public void LoadSensorsList()
        {
            try
            {
                FileStream fs = new FileStream("sensors", FileMode.Open);
                BinaryFormatter biform = new BinaryFormatter();
                sensorsList = (List<Sensor>)biform.Deserialize(fs);
                fs.Close();

                for (int i = 0; i < sensorsList.Count; i++)
                {
                    addSensorToDGV(sensorsList[i]);
                }
                addEventToLog("Sensors list has been successfuly loaded", Color.Black);
            }
            catch(Exception loadSensorsException)
            {
                addEventToLog("Unable to load sensors list. " + loadSensorsException.Message, Color.Black);
            }
        }

        //Воспроизведение звука при обнаружении превышения температурных лимитов
        public void PlayTheSound()
        {
            try
            {
                SoundPlayer sp = new SoundPlayer(settings.soundFilePath);
                sp.Play();
            }
            catch(Exception playTheSoundException)
            {
                addEventToLog(playTheSoundException.Message, Color.Black);
            }
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
                addEventToLog("Unable to write event to log file. " + logToFileException.Message, Color.Black);
            }
        }

        //Обновление статусов сенсоров в dgvSensors (offlne, online)
        public void UpdateSensorStatus(Sensor sensor)
        {
            if (this.InvokeRequired)
            {
                AddEditSensorForm.changingSensorsListHandler chslh = new AddEditSensorForm.changingSensorsListHandler(UpdateSensorStatus);
                this.BeginInvoke(chslh, new object[] { sensor });
            }
            else
            {
                for (int i = 0; i < dgvSensors.Rows.Count; i++)
                {
                    if (dgvSensors.Rows[i].Cells["sensorSystemName"].Value.ToString() == sensor.sensSysName)
                    {
                        dgvSensors.Rows[i].Cells["sensorStatus"].Value = sensor.sensStatus.ToString();
                        if (sensor.sensStatus == SensStatus.offline)
                        {
                            dgvSensors.Rows[i].Cells["sensorStatus"].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            dgvSensors.Rows[i].Cells["sensorStatus"].Style.ForeColor = Color.Green;
                        }
                    }
                }
            }
        }

        //Обновление последней температуры сенсоров 
        public void UpdateSensorLastTemperature(Sensor sensor)
        {
            if (this.InvokeRequired)
            {
                AddEditSensorForm.changingSensorsListHandler chslh = new AddEditSensorForm.changingSensorsListHandler(UpdateSensorLastTemperature);
                this.BeginInvoke(chslh, new object[] { sensor });
            }
            else
            {
                for (int i = 0; i < dgvSensors.Rows.Count; i++)
                {
                    if (dgvSensors.Rows[i].Cells["sensorSystemName"].Value.ToString() == sensor.sensSysName)
                    {
                        dgvSensors.Rows[i].Cells["sensorLastTemp"].Value = sensor.sensLastTemp.ToString();
                        if (settings.useTempLimits)
                        {
                            if (sensor.sensLastTemp > settings.maxTemperature || sensor.sensLastTemp < settings.minTemperature)
                            {
                                dgvSensors.Rows[i].Cells["sensorLastTemp"].Style.ForeColor = Color.Red;
                            }
                            else
                            {
                                dgvSensors.Rows[i].Cells["sensorLastTemp"].Style.ForeColor = Color.Black;
                            }
                        }
                        else
                        {
                            dgvSensors.Rows[i].Cells["sensorLastTemp"].Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        public delegate void UpdateConnectionStatusDelegate(string text, Color color);
        public static event UpdateConnectionStatusDelegate Connected;
        public static event UpdateConnectionStatusDelegate Disconnected;
        public void UpdateConnectionStatusCaption(string text, Color color)
        {
            if (this.InvokeRequired)
            {
                UpdateConnectionStatusDelegate ucsd = new UpdateConnectionStatusDelegate(UpdateConnectionStatusCaption);
                this.BeginInvoke(ucsd, new object[] { text, color });
            }
            else
            {
                lConnectionStatus.Text = text;
                lConnectionStatus.ForeColor = color;
            }
        }

        public delegate void addDataToLogDelegate(string text, Color color);
        public void addDataToLog(string text, Color color)
        {
            if (settings.limitLogStrings)
            {
                if (settings.logStringsLimit > 0)
                {
                    if (dgvLog.Rows.Count == settings.logStringsLimit)
                    {
                        dgvLog.Rows.RemoveAt(0);
                        dgvLog.Rows.Add();
                        dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                        dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[1].Value = text;
                        dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[1].Style.ForeColor = color;
                    }
                    else
                    {
                        dgvLog.Rows.Add();
                        dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                        dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[1].Value = text;
                        dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[1].Style.ForeColor = color;
                    }
                }
            }
            else
            {
                dgvLog.Rows.Add();
                dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[0].Value = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString();
                dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[1].Value = text;
                dgvLog.Rows[dgvLog.Rows.Count - 1].Cells[1].Style.ForeColor = color;
            }

            if (settings.logToFile)
            {
                SaveLogToFile(text);
            }
            dgvLog.Rows[dgvLog.Rows.Count - 1].Selected = true;
            dgvLog.FirstDisplayedScrollingRowIndex = dgvLog.Rows.Count - 1;
        }
        public void addEventToLog(string text, Color color)
        {
            try
            {
                this.BeginInvoke(new addDataToLogDelegate(addDataToLog), new object[] { text, color });
            }
            catch (Exception addEventToLogException)
            {
                MessageBox.Show(addEventToLogException.Message);
            }

        }

        private void tsbAddSensor_Click(object sender, EventArgs e)
        {
            AddEditSensorForm addSensorForm = new AddEditSensorForm();
            addSensorForm.Show();
        }

        private void tsbRemoveSensor_Click(object sender, EventArgs e)
        {
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

                    //но я ее туда все же помещу, потому что в обработчике события вызывается метод addEventToLog, который сообщает, какой сенсор был удален,
                    //и для него эта информация нужна
                    sensorToDelete.sensName = dgvSensors.SelectedRows[0].Cells["sensorUserName"].Value.ToString();

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
                        addEventToLog("Error occured. Unable to delete selected item. Item hasnt been found in sensors' list", Color.Black);
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
        }

        private void tsbEditSensor_Click(object sender, EventArgs e)
        {
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
        }

        private void tsbConnect_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                connectionThread = new Thread(new ThreadStart(connect));
                connectionThread.IsBackground = true;
                connectionThread.Start();
            }
            else
            {
                bf.Serialize(ns, "disconnect");
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            string str = "disconnect";
            try
            {
                bf.Serialize(ns, str);
                ns.Close();
                client.Close();
            }
            catch { }
        }

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        private void tsbSaveSensors_Click(object sender, EventArgs e)
        {
            SaveSensorsList();
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            AddEditSensorForm.sensorHasBeenAdded += new AddEditSensorForm.changingSensorsListHandler(addSensorToDGV);
            sensorHasBeenDeleted += new AddEditSensorForm.changingSensorsListHandler(deleteSensorFromSensorsList);
            AddEditSensorForm.sensorHasBeenChanged += new AddEditSensorForm.changingSensorsListHandler(UpdateSensorsData);
            Connected += new UpdateConnectionStatusDelegate(UpdateConnectionStatusCaption);
            Disconnected += new UpdateConnectionStatusDelegate(UpdateConnectionStatusCaption);
            SettingsForm.SettingsUpdated += new SettingsForm.SettingsUpdatedDelegate(UpdateCaptionsAndColors);

            LoadSensorsList();

            LoadSettings();

            try
            {
                string ipList = "";
                for (int i = 0; i < System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.Length; i++)
                {
                    ipList += System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList[i].ToString() + ";  ";
                }
                lClientIP.Text = ipList;
                lClientIP.ForeColor = Color.Green;
            }
            catch
            {
                addEventToLog("Unable to get host ip list", Color.Black);
            }
        }

    }
}
