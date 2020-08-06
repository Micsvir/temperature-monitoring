namespace TWServer
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
            this.chbLogToFile = new System.Windows.Forms.CheckBox();
            this.tbComPortName = new System.Windows.Forms.TextBox();
            this.lComPortName = new System.Windows.Forms.Label();
            this.lComPortSpeed = new System.Windows.Forms.Label();
            this.tbComPortSpeed = new System.Windows.Forms.TextBox();
            this.lComPortDataBits = new System.Windows.Forms.Label();
            this.tbComPortDataBits = new System.Windows.Forms.TextBox();
            this.lServerPort = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.tbLogMaxStrings = new System.Windows.Forms.TextBox();
            this.chbLimitLogStrings = new System.Windows.Forms.CheckBox();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chbLogToFile
            // 
            this.chbLogToFile.AutoSize = true;
            this.chbLogToFile.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbLogToFile.Location = new System.Drawing.Point(215, 229);
            this.chbLogToFile.Name = "chbLogToFile";
            this.chbLogToFile.Size = new System.Drawing.Size(129, 22);
            this.chbLogToFile.TabIndex = 0;
            this.chbLogToFile.Text = "Save log to file";
            this.chbLogToFile.UseVisualStyleBackColor = true;
            // 
            // tbComPortName
            // 
            this.tbComPortName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbComPortName.Location = new System.Drawing.Point(29, 45);
            this.tbComPortName.Name = "tbComPortName";
            this.tbComPortName.Size = new System.Drawing.Size(129, 26);
            this.tbComPortName.TabIndex = 1;
            // 
            // lComPortName
            // 
            this.lComPortName.AutoSize = true;
            this.lComPortName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lComPortName.Location = new System.Drawing.Point(26, 24);
            this.lComPortName.Name = "lComPortName";
            this.lComPortName.Size = new System.Drawing.Size(119, 18);
            this.lComPortName.TabIndex = 2;
            this.lComPortName.Text = "COM port name";
            // 
            // lComPortSpeed
            // 
            this.lComPortSpeed.AutoSize = true;
            this.lComPortSpeed.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lComPortSpeed.Location = new System.Drawing.Point(26, 114);
            this.lComPortSpeed.Name = "lComPortSpeed";
            this.lComPortSpeed.Size = new System.Drawing.Size(124, 18);
            this.lComPortSpeed.TabIndex = 4;
            this.lComPortSpeed.Text = "COM port speed";
            // 
            // tbComPortSpeed
            // 
            this.tbComPortSpeed.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbComPortSpeed.Location = new System.Drawing.Point(29, 135);
            this.tbComPortSpeed.Name = "tbComPortSpeed";
            this.tbComPortSpeed.Size = new System.Drawing.Size(129, 26);
            this.tbComPortSpeed.TabIndex = 3;
            // 
            // lComPortDataBits
            // 
            this.lComPortDataBits.AutoSize = true;
            this.lComPortDataBits.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lComPortDataBits.Location = new System.Drawing.Point(26, 204);
            this.lComPortDataBits.Name = "lComPortDataBits";
            this.lComPortDataBits.Size = new System.Drawing.Size(140, 18);
            this.lComPortDataBits.TabIndex = 6;
            this.lComPortDataBits.Text = "COM port data bits";
            // 
            // tbComPortDataBits
            // 
            this.tbComPortDataBits.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbComPortDataBits.Location = new System.Drawing.Point(29, 225);
            this.tbComPortDataBits.Name = "tbComPortDataBits";
            this.tbComPortDataBits.Size = new System.Drawing.Size(129, 26);
            this.tbComPortDataBits.TabIndex = 5;
            // 
            // lServerPort
            // 
            this.lServerPort.AutoSize = true;
            this.lServerPort.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lServerPort.Location = new System.Drawing.Point(212, 27);
            this.lServerPort.Name = "lServerPort";
            this.lServerPort.Size = new System.Drawing.Size(85, 18);
            this.lServerPort.TabIndex = 8;
            this.lServerPort.Text = "Server port";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbServerPort.Location = new System.Drawing.Point(215, 45);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(129, 26);
            this.tbServerPort.TabIndex = 7;
            // 
            // tbLogMaxStrings
            // 
            this.tbLogMaxStrings.Enabled = false;
            this.tbLogMaxStrings.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbLogMaxStrings.Location = new System.Drawing.Point(215, 135);
            this.tbLogMaxStrings.Name = "tbLogMaxStrings";
            this.tbLogMaxStrings.Size = new System.Drawing.Size(129, 26);
            this.tbLogMaxStrings.TabIndex = 9;
            // 
            // chbLimitLogStrings
            // 
            this.chbLimitLogStrings.AutoSize = true;
            this.chbLimitLogStrings.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbLimitLogStrings.Location = new System.Drawing.Point(215, 107);
            this.chbLimitLogStrings.Name = "chbLimitLogStrings";
            this.chbLimitLogStrings.Size = new System.Drawing.Size(136, 22);
            this.chbLimitLogStrings.TabIndex = 11;
            this.chbLimitLogStrings.Text = "Limit log strings";
            this.chbLimitLogStrings.UseVisualStyleBackColor = true;
            this.chbLimitLogStrings.CheckedChanged += new System.EventHandler(this.chbLimitLogStrings_CheckedChanged);
            // 
            // bOK
            // 
            this.bOK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOK.Location = new System.Drawing.Point(29, 290);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(129, 34);
            this.bOK.TabIndex = 12;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.Location = new System.Drawing.Point(215, 290);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(129, 34);
            this.bCancel.TabIndex = 13;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 345);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.chbLimitLogStrings);
            this.Controls.Add(this.tbLogMaxStrings);
            this.Controls.Add(this.lServerPort);
            this.Controls.Add(this.tbServerPort);
            this.Controls.Add(this.lComPortDataBits);
            this.Controls.Add(this.tbComPortDataBits);
            this.Controls.Add(this.lComPortSpeed);
            this.Controls.Add(this.tbComPortSpeed);
            this.Controls.Add(this.lComPortName);
            this.Controls.Add(this.tbComPortName);
            this.Controls.Add(this.chbLogToFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbLogToFile;
        private System.Windows.Forms.TextBox tbComPortName;
        private System.Windows.Forms.Label lComPortName;
        private System.Windows.Forms.Label lComPortSpeed;
        private System.Windows.Forms.TextBox tbComPortSpeed;
        private System.Windows.Forms.Label lComPortDataBits;
        private System.Windows.Forms.TextBox tbComPortDataBits;
        private System.Windows.Forms.Label lServerPort;
        private System.Windows.Forms.TextBox tbServerPort;
        private System.Windows.Forms.TextBox tbLogMaxStrings;
        private System.Windows.Forms.CheckBox chbLimitLogStrings;
        private System.Windows.Forms.Button bOK;
        private System.Windows.Forms.Button bCancel;
    }
}