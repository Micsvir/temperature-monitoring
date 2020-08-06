using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace TWServer
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            FillFields();
        }

        //Счетчик полей настроек, заполненных с ошибками
        public int settingsErrorsCount = 0;

        //сохранение настроек в файл
        public void saveSettings()
        {
            try
            {
                FileStream fs = new FileStream("settings", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, MainWindow.settings);
                fs.Close();
                MessageBox.Show("Settings have been successfuly saved");
            }
            catch (Exception fileCreationException)
            {
                MessageBox.Show("Unable to save settings.\n\n" + fileCreationException.Message);
            }
        }

        //заполнение полей настроек значениями из переменной MainWindow.settings
        public void FillFields()
        {
            if (MainWindow.settingsHaveBeenLoaded)
            {
                try
                {
                    tbComPortDataBits.Text = MainWindow.settings.dataBits.ToString();
                    tbComPortName.Text = MainWindow.settings.comPortName;
                    tbComPortSpeed.Text = MainWindow.settings.comPortSpeed.ToString();
                    tbServerPort.Text = MainWindow.settings.serverPort.ToString();
                    chbLimitLogStrings.Checked = MainWindow.settings.limitLogStrings;
                    if (MainWindow.settings.limitLogStrings)
                    {
                        tbLogMaxStrings.Text = MainWindow.settings.logStringsLimit.ToString();
                    }
                    chbLogToFile.Checked = MainWindow.settings.logToFile;
                }
                catch { }
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            bool success = false;
            try
            {
                MainWindow.settings.comPortName = tbComPortName.Text;
                MainWindow.settings.comPortSpeed = Convert.ToInt32(tbComPortSpeed.Text);
                MainWindow.settings.dataBits = Convert.ToInt32(tbComPortDataBits.Text);
                MainWindow.settings.logToFile = chbLogToFile.Checked;
                MainWindow.settings.limitLogStrings = chbLimitLogStrings.Checked;
                if (MainWindow.settings.limitLogStrings)
                {
                    MainWindow.settings.logStringsLimit = Convert.ToInt32(tbLogMaxStrings.Text);
                }
                MainWindow.settings.logToFile = chbLogToFile.Checked;
                MainWindow.settings.serverPort = Convert.ToInt32(tbServerPort.Text);

                success = true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
                success = false;
            }

            if (success)
            {
                saveSettings();
                this.Close();
            }
        }

        private void chbLimitLogStrings_CheckedChanged(object sender, EventArgs e)
        {
            tbLogMaxStrings.Enabled = chbLimitLogStrings.Checked;
        }
    }
}
