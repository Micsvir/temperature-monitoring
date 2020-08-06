namespace TWClient
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lServerIP = new System.Windows.Forms.Label();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.lServerPort = new System.Windows.Forms.Label();
            this.tbMinTempValue = new System.Windows.Forms.TextBox();
            this.lMinTemp = new System.Windows.Forms.Label();
            this.tbMaxTempValue = new System.Windows.Forms.TextBox();
            this.lMaxTemp = new System.Windows.Forms.Label();
            this.chbLogToFile = new System.Windows.Forms.CheckBox();
            this.chbUseTempLimits = new System.Windows.Forms.CheckBox();
            this.chbUseSound = new System.Windows.Forms.CheckBox();
            this.tbSoundFilePath = new System.Windows.Forms.TextBox();
            this.ofdNotificationSound = new System.Windows.Forms.OpenFileDialog();
            this.tbLogStringsLimit = new System.Windows.Forms.TextBox();
            this.chbLimitLogStrings = new System.Windows.Forms.CheckBox();
            this.chbTemperatureInLog = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bOK
            // 
            this.bOK.Location = new System.Drawing.Point(12, 408);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(100, 35);
            this.bOK.TabIndex = 0;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(336, 408);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(100, 35);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lServerIP
            // 
            this.lServerIP.AutoSize = true;
            this.lServerIP.Location = new System.Drawing.Point(12, 18);
            this.lServerIP.Name = "lServerIP";
            this.lServerIP.Size = new System.Drawing.Size(72, 18);
            this.lServerIP.TabIndex = 2;
            this.lServerIP.Text = "Server IP";
            // 
            // tbServerIP
            // 
            this.tbServerIP.Location = new System.Drawing.Point(15, 39);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(175, 26);
            this.tbServerIP.TabIndex = 3;
            // 
            // tbServerPort
            // 
            this.tbServerPort.Location = new System.Drawing.Point(248, 39);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(188, 26);
            this.tbServerPort.TabIndex = 5;
            // 
            // lServerPort
            // 
            this.lServerPort.AutoSize = true;
            this.lServerPort.Location = new System.Drawing.Point(245, 18);
            this.lServerPort.Name = "lServerPort";
            this.lServerPort.Size = new System.Drawing.Size(85, 18);
            this.lServerPort.TabIndex = 4;
            this.lServerPort.Text = "Server port";
            // 
            // tbMinTempValue
            // 
            this.tbMinTempValue.Enabled = false;
            this.tbMinTempValue.Location = new System.Drawing.Point(15, 146);
            this.tbMinTempValue.Name = "tbMinTempValue";
            this.tbMinTempValue.Size = new System.Drawing.Size(175, 26);
            this.tbMinTempValue.TabIndex = 7;
            // 
            // lMinTemp
            // 
            this.lMinTemp.AutoSize = true;
            this.lMinTemp.Location = new System.Drawing.Point(12, 125);
            this.lMinTemp.Name = "lMinTemp";
            this.lMinTemp.Size = new System.Drawing.Size(161, 18);
            this.lMinTemp.TabIndex = 6;
            this.lMinTemp.Text = "Min temperature value";
            // 
            // tbMaxTempValue
            // 
            this.tbMaxTempValue.Enabled = false;
            this.tbMaxTempValue.Location = new System.Drawing.Point(248, 146);
            this.tbMaxTempValue.Name = "tbMaxTempValue";
            this.tbMaxTempValue.Size = new System.Drawing.Size(188, 26);
            this.tbMaxTempValue.TabIndex = 9;
            // 
            // lMaxTemp
            // 
            this.lMaxTemp.AutoSize = true;
            this.lMaxTemp.Location = new System.Drawing.Point(245, 125);
            this.lMaxTemp.Name = "lMaxTemp";
            this.lMaxTemp.Size = new System.Drawing.Size(165, 18);
            this.lMaxTemp.TabIndex = 8;
            this.lMaxTemp.Text = "Max temperature value";
            // 
            // chbLogToFile
            // 
            this.chbLogToFile.AutoSize = true;
            this.chbLogToFile.Location = new System.Drawing.Point(248, 335);
            this.chbLogToFile.Name = "chbLogToFile";
            this.chbLogToFile.Size = new System.Drawing.Size(129, 22);
            this.chbLogToFile.TabIndex = 10;
            this.chbLogToFile.Text = "Save log to file";
            this.chbLogToFile.UseVisualStyleBackColor = true;
            // 
            // chbUseTempLimits
            // 
            this.chbUseTempLimits.AutoSize = true;
            this.chbUseTempLimits.Location = new System.Drawing.Point(15, 100);
            this.chbUseTempLimits.Name = "chbUseTempLimits";
            this.chbUseTempLimits.Size = new System.Drawing.Size(183, 22);
            this.chbUseTempLimits.TabIndex = 11;
            this.chbUseTempLimits.Text = "Use temperature limits";
            this.chbUseTempLimits.UseVisualStyleBackColor = true;
            this.chbUseTempLimits.CheckedChanged += new System.EventHandler(this.chbUseTempLimits_CheckedChanged);
            // 
            // chbUseSound
            // 
            this.chbUseSound.AutoSize = true;
            this.chbUseSound.Location = new System.Drawing.Point(248, 226);
            this.chbUseSound.Name = "chbUseSound";
            this.chbUseSound.Size = new System.Drawing.Size(180, 22);
            this.chbUseSound.TabIndex = 12;
            this.chbUseSound.Text = "Use sound notification";
            this.chbUseSound.UseVisualStyleBackColor = true;
            this.chbUseSound.CheckedChanged += new System.EventHandler(this.chbUseSound_CheckedChanged);
            // 
            // tbSoundFilePath
            // 
            this.tbSoundFilePath.Enabled = false;
            this.tbSoundFilePath.Location = new System.Drawing.Point(248, 253);
            this.tbSoundFilePath.Name = "tbSoundFilePath";
            this.tbSoundFilePath.Size = new System.Drawing.Size(188, 26);
            this.tbSoundFilePath.TabIndex = 13;
            this.tbSoundFilePath.DoubleClick += new System.EventHandler(this.tbSoundFilePath_DoubleClick);
            // 
            // ofdNotificationSound
            // 
            this.ofdNotificationSound.DefaultExt = "wav";
            // 
            // tbLogStringsLimit
            // 
            this.tbLogStringsLimit.Enabled = false;
            this.tbLogStringsLimit.Location = new System.Drawing.Point(15, 253);
            this.tbLogStringsLimit.Name = "tbLogStringsLimit";
            this.tbLogStringsLimit.Size = new System.Drawing.Size(175, 26);
            this.tbLogStringsLimit.TabIndex = 15;
            // 
            // chbLimitLogStrings
            // 
            this.chbLimitLogStrings.AutoSize = true;
            this.chbLimitLogStrings.Location = new System.Drawing.Point(15, 226);
            this.chbLimitLogStrings.Name = "chbLimitLogStrings";
            this.chbLimitLogStrings.Size = new System.Drawing.Size(136, 22);
            this.chbLimitLogStrings.TabIndex = 14;
            this.chbLimitLogStrings.Text = "Limit log strings";
            this.chbLimitLogStrings.UseVisualStyleBackColor = true;
            this.chbLimitLogStrings.CheckedChanged += new System.EventHandler(this.chbLimitLogStrings_CheckedChanged);
            // 
            // chbTemperatureInLog
            // 
            this.chbTemperatureInLog.AutoSize = true;
            this.chbTemperatureInLog.Location = new System.Drawing.Point(15, 335);
            this.chbTemperatureInLog.Name = "chbTemperatureInLog";
            this.chbTemperatureInLog.Size = new System.Drawing.Size(155, 22);
            this.chbTemperatureInLog.TabIndex = 16;
            this.chbTemperatureInLog.Text = "Temperature in log";
            this.chbTemperatureInLog.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 455);
            this.Controls.Add(this.chbTemperatureInLog);
            this.Controls.Add(this.tbLogStringsLimit);
            this.Controls.Add(this.chbLimitLogStrings);
            this.Controls.Add(this.tbSoundFilePath);
            this.Controls.Add(this.chbUseSound);
            this.Controls.Add(this.chbUseTempLimits);
            this.Controls.Add(this.chbLogToFile);
            this.Controls.Add(this.tbMaxTempValue);
            this.Controls.Add(this.lMaxTemp);
            this.Controls.Add(this.tbMinTempValue);
            this.Controls.Add(this.lMinTemp);
            this.Controls.Add(this.tbServerPort);
            this.Controls.Add(this.lServerPort);
            this.Controls.Add(this.tbServerIP);
            this.Controls.Add(this.lServerIP);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lServerIP;
        private System.Windows.Forms.TextBox tbServerIP;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.Label lServerPort;
        private System.Windows.Forms.TextBox tbMinTempValue;
        private System.Windows.Forms.Label lMinTemp;
        private System.Windows.Forms.TextBox tbMaxTempValue;
        private System.Windows.Forms.Label lMaxTemp;
        private System.Windows.Forms.CheckBox chbLogToFile;
        private System.Windows.Forms.CheckBox chbUseTempLimits;
        private System.Windows.Forms.CheckBox chbUseSound;
        private System.Windows.Forms.TextBox tbSoundFilePath;
        private System.Windows.Forms.OpenFileDialog ofdNotificationSound;
        private System.Windows.Forms.TextBox tbLogStringsLimit;
        private System.Windows.Forms.CheckBox chbLimitLogStrings;
        private System.Windows.Forms.CheckBox chbTemperatureInLog;
    }
}