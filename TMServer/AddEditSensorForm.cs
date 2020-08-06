using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TWServer
{
    public partial class AddEditSensorForm : Form
    {
        public AddEditSensorForm()
        {
            InitializeComponent();
        }

        //делегат и событие, возникающее при добавлении нового элемента в список MainWindow.sensorsList.
        //Оно понадобится для того, чтобы при его наступлении выполнялась процедура добавления соответствующего сенсора
        //в dgvSensors
        public delegate void changingSensorsListHandler(MainWindow.Sensor sensor);
        public static event changingSensorsListHandler sensorHasBeenAdded;
        public static event changingSensorsListHandler sensorHasBeenChanged;

        //Процедура возвращает true, если указанный в качестве параметра сенсор отсутствует в 
        //списке активных сенсоров (dgvSensors)
        public bool isSensorFree(string sensorSysName)
        {
            //флаг примет значение true, если в списке сенсоров обнаружится сенсор, системное имя которого совпадает
            //с указанным в качестве параметра именем
            bool flag = false;
            foreach (MainWindow.Sensor curSensor in MainWindow.sensorsList)
            {
                if (curSensor.sensSysName == sensorSysName)
                {
                    flag = true;
                }
            }
            if (flag)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void cbSensors_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Проверка условия, что выбираемый сенсор не был выбран ранее (свободен)
            if (!MainWindow.sensorIsEditing)
            {
                if (cbSensors.SelectedIndex != -1)
                {
                    if (!isSensorFree(cbSensors.SelectedItem.ToString()))
                    {
                        MessageBox.Show("This sensor has already been added to sensors list");
                        cbSensors.SelectedIndex = -1;
                    }
                }
            }
        }

        //добавление нового сенсора или изменение существующего
        private void bOK_Click(object sender, EventArgs e)
        {
            //Если выбран доступный для добавления сенсор и указано его имя, 
            //информация о сенсоре добавляется в список сенсоров MainWindow.sensorsList
            if (cbSensors.SelectedIndex != -1 && tbSensorName.Text.Length > 0)
            {
                //если это не редактирование сенсора, а создание нового,
                //выполняется следующая последовательность действий
                if (!MainWindow.sensorIsEditing)
                {
                    MainWindow.Sensor newSensor = new MainWindow.Sensor();
                    newSensor.sensSysName = cbSensors.SelectedItem.ToString();
                    newSensor.sensName = tbSensorName.Text;
                    newSensor.sensDescription = tbSensorDescription.Text;

                    MainWindow.sensorsList.Add(newSensor);

                    if (sensorHasBeenAdded != null)
                    {
                        sensorHasBeenAdded(newSensor);
                    }

                    this.Close();
                }
                else
                {
                    //осуществляется сравнение значений переменных tbSensorName.Text, tbSensorDescription.Text со
                    //значениями MainWindow.editingSensor.sensName, MainWindow.editingSensor.sensDescription соответственно.
                    //Если между ними никакой разницы не обнаруживается, форма просто закрывается, и ничего более не происходит
                    if (tbSensorName.Text != MainWindow.editingSensor.sensName || tbSensorDescription.Text != MainWindow.editingSensor.sensDescription)
                    {
                        MainWindow.editingSensor.sensName = tbSensorName.Text;
                        MainWindow.editingSensor.sensDescription = tbSensorDescription.Text;

                        //Далее просто вызывается событие, что данные выбранного сенсора были изменены,
                        //а вся необходимая обработка выполняется в коде MainWindow
                        if (sensorHasBeenChanged != null)
                        {
                            sensorHasBeenChanged(MainWindow.editingSensor);
                        }

                        //После чего форма закрывается
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }
                    MainWindow.sensorIsEditing = false;
                }
            }
            else
            {
                MessageBox.Show("Choose sensor and enter sensor's name");
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            MainWindow.sensorIsEditing = false;
            this.Close();
        }
    }
}
