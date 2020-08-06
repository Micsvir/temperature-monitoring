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

namespace TWClient
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            FillFields();
        }
        
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
                    tbServerIP.Text = MainWindow.settings.serverIP;
                    tbServerPort.Text = MainWindow.settings.serverPort.ToString();
                    chbUseTempLimits.Checked = MainWindow.settings.useTempLimits;
                    if (MainWindow.settings.useTempLimits)
                    {
                        tbMinTempValue.Text = MainWindow.settings.minTemperature.ToString();
                        tbMaxTempValue.Text = MainWindow.settings.maxTemperature.ToString();
                    }
                    chbLogToFile.Checked = MainWindow.settings.logToFile;
                    chbUseSound.Checked = MainWindow.settings.useSound;
                    if (MainWindow.settings.useSound)
                    {
                        tbSoundFilePath.Text = MainWindow.settings.soundFilePath;
                    }
                    chbLimitLogStrings.Checked = MainWindow.settings.limitLogStrings;
                    if (MainWindow.settings.limitLogStrings)
                    {
                        tbLogStringsLimit.Text = MainWindow.settings.logStringsLimit.ToString();
                    }
                    chbTemperatureInLog.Checked = MainWindow.settings.temperatureInLog;
                }
                catch { }
            }
        }

        public delegate void SettingsUpdatedDelegate();
        public static event SettingsUpdatedDelegate SettingsUpdated;

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            bool success = false;
            try
            {
                MainWindow.settings.serverIP = tbServerIP.Text;
                MainWindow.settings.serverPort = Convert.ToInt32(tbServerPort.Text);
                MainWindow.settings.useTempLimits = chbUseTempLimits.Checked;
                if (MainWindow.settings.useTempLimits)
                {
                    MainWindow.settings.minTemperature = Convert.ToInt32(tbMinTempValue.Text);
                    MainWindow.settings.maxTemperature = Convert.ToInt32(tbMaxTempValue.Text);
                }
                MainWindow.settings.logToFile = chbLogToFile.Checked;
                MainWindow.settings.useSound = chbUseSound.Checked;
                if (MainWindow.settings.useSound)
                {
                    MainWindow.settings.soundFilePath = tbSoundFilePath.Text;
                }
                MainWindow.settings.limitLogStrings = chbLimitLogStrings.Checked;
                if (MainWindow.settings.limitLogStrings)
                {
                    MainWindow.settings.logStringsLimit = Convert.ToInt32(tbLogStringsLimit.Text);
                }
                MainWindow.settings.temperatureInLog = chbTemperatureInLog.Checked;

                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                MessageBox.Show(ex.Message);
            }

            if (success)
            {
                if (SettingsUpdated != null)
                {
                    SettingsUpdated();
                }
                saveSettings();
                this.Close();
            }

        }

        private void chbUseTempLimits_CheckedChanged(object sender, EventArgs e)
        {
            tbMaxTempValue.Enabled = chbUseTempLimits.Checked;
            tbMinTempValue.Enabled = chbUseTempLimits.Checked;
        }

        private void chbUseSound_CheckedChanged(object sender, EventArgs e)
        {
            tbSoundFilePath.Enabled = chbUseSound.Checked;
        }

        private void tbSoundFilePath_DoubleClick(object sender, EventArgs e)
        {
            if (ofdNotificationSound.ShowDialog() == DialogResult.OK)
            {
                tbSoundFilePath.Text = ofdNotificationSound.FileName;
            }
        }

        private void chbLimitLogStrings_CheckedChanged(object sender, EventArgs e)
        {
            tbLogStringsLimit.Enabled = chbLimitLogStrings.Checked;
        }
    }
}
