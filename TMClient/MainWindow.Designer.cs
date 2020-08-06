namespace TWClient
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbConnect = new System.Windows.Forms.ToolStripButton();
            this.tsbAddSensor = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveSensor = new System.Windows.Forms.ToolStripButton();
            this.tsbEditSensor = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveSensors = new System.Windows.Forms.ToolStripButton();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.gbConnectionInfo = new System.Windows.Forms.GroupBox();
            this.lConnectionStatus = new System.Windows.Forms.Label();
            this.lConnectionStatusCaption = new System.Windows.Forms.Label();
            this.lServerPort = new System.Windows.Forms.Label();
            this.lServerPortCaption = new System.Windows.Forms.Label();
            this.lServerIP = new System.Windows.Forms.Label();
            this.lServerIPCaption = new System.Windows.Forms.Label();
            this.lClientIP = new System.Windows.Forms.Label();
            this.lClientIPCaption = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbSensors = new System.Windows.Forms.GroupBox();
            this.dgvSensors = new System.Windows.Forms.DataGridView();
            this.sensorSystemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorLastTemp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.eventDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.gbConnectionInfo.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbSensors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensors)).BeginInit();
            this.gbLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbConnect,
            this.tsbAddSensor,
            this.tsbRemoveSensor,
            this.tsbEditSensor,
            this.tsbSaveSensors,
            this.tsbSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(877, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbConnect
            // 
            this.tsbConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbConnect.Image = ((System.Drawing.Image)(resources.GetObject("tsbConnect.Image")));
            this.tsbConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConnect.Name = "tsbConnect";
            this.tsbConnect.Size = new System.Drawing.Size(70, 22);
            this.tsbConnect.Text = "Connect";
            this.tsbConnect.Click += new System.EventHandler(this.tsbConnect_Click);
            // 
            // tsbAddSensor
            // 
            this.tsbAddSensor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddSensor.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddSensor.Image")));
            this.tsbAddSensor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddSensor.Name = "tsbAddSensor";
            this.tsbAddSensor.Size = new System.Drawing.Size(92, 22);
            this.tsbAddSensor.Text = "Add sensor";
            this.tsbAddSensor.Click += new System.EventHandler(this.tsbAddSensor_Click);
            // 
            // tsbRemoveSensor
            // 
            this.tsbRemoveSensor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRemoveSensor.Image = ((System.Drawing.Image)(resources.GetObject("tsbRemoveSensor.Image")));
            this.tsbRemoveSensor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveSensor.Name = "tsbRemoveSensor";
            this.tsbRemoveSensor.Size = new System.Drawing.Size(121, 22);
            this.tsbRemoveSensor.Text = "Remove sensor";
            this.tsbRemoveSensor.Click += new System.EventHandler(this.tsbRemoveSensor_Click);
            // 
            // tsbEditSensor
            // 
            this.tsbEditSensor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEditSensor.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditSensor.Image")));
            this.tsbEditSensor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditSensor.Name = "tsbEditSensor";
            this.tsbEditSensor.Size = new System.Drawing.Size(91, 22);
            this.tsbEditSensor.Text = "Edit sensor";
            this.tsbEditSensor.Click += new System.EventHandler(this.tsbEditSensor_Click);
            // 
            // tsbSaveSensors
            // 
            this.tsbSaveSensors.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSaveSensors.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveSensors.Image")));
            this.tsbSaveSensors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveSensors.Name = "tsbSaveSensors";
            this.tsbSaveSensors.Size = new System.Drawing.Size(107, 22);
            this.tsbSaveSensors.Text = "Save sensors";
            this.tsbSaveSensors.Click += new System.EventHandler(this.tsbSaveSensors_Click);
            // 
            // tsbSettings
            // 
            this.tsbSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbSettings.Image")));
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(69, 22);
            this.tsbSettings.Text = "Settings";
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // gbConnectionInfo
            // 
            this.gbConnectionInfo.Controls.Add(this.lConnectionStatus);
            this.gbConnectionInfo.Controls.Add(this.lConnectionStatusCaption);
            this.gbConnectionInfo.Controls.Add(this.lServerPort);
            this.gbConnectionInfo.Controls.Add(this.lServerPortCaption);
            this.gbConnectionInfo.Controls.Add(this.lServerIP);
            this.gbConnectionInfo.Controls.Add(this.lServerIPCaption);
            this.gbConnectionInfo.Controls.Add(this.lClientIP);
            this.gbConnectionInfo.Controls.Add(this.lClientIPCaption);
            this.gbConnectionInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConnectionInfo.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbConnectionInfo.Location = new System.Drawing.Point(0, 25);
            this.gbConnectionInfo.Name = "gbConnectionInfo";
            this.gbConnectionInfo.Size = new System.Drawing.Size(877, 122);
            this.gbConnectionInfo.TabIndex = 3;
            this.gbConnectionInfo.TabStop = false;
            this.gbConnectionInfo.Text = "Connection Info";
            // 
            // lConnectionStatus
            // 
            this.lConnectionStatus.AutoSize = true;
            this.lConnectionStatus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lConnectionStatus.ForeColor = System.Drawing.Color.Red;
            this.lConnectionStatus.Location = new System.Drawing.Point(154, 82);
            this.lConnectionStatus.Name = "lConnectionStatus";
            this.lConnectionStatus.Size = new System.Drawing.Size(101, 18);
            this.lConnectionStatus.TabIndex = 7;
            this.lConnectionStatus.Text = "disconnected";
            // 
            // lConnectionStatusCaption
            // 
            this.lConnectionStatusCaption.AutoSize = true;
            this.lConnectionStatusCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lConnectionStatusCaption.Location = new System.Drawing.Point(12, 82);
            this.lConnectionStatusCaption.Name = "lConnectionStatusCaption";
            this.lConnectionStatusCaption.Size = new System.Drawing.Size(136, 18);
            this.lConnectionStatusCaption.TabIndex = 6;
            this.lConnectionStatusCaption.Text = "Connection status:";
            // 
            // lServerPort
            // 
            this.lServerPort.AutoSize = true;
            this.lServerPort.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lServerPort.ForeColor = System.Drawing.Color.Red;
            this.lServerPort.Location = new System.Drawing.Point(154, 64);
            this.lServerPort.Name = "lServerPort";
            this.lServerPort.Size = new System.Drawing.Size(34, 18);
            this.lServerPort.TabIndex = 5;
            this.lServerPort.Text = "N/A";
            // 
            // lServerPortCaption
            // 
            this.lServerPortCaption.AutoSize = true;
            this.lServerPortCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lServerPortCaption.Location = new System.Drawing.Point(12, 64);
            this.lServerPortCaption.Name = "lServerPortCaption";
            this.lServerPortCaption.Size = new System.Drawing.Size(89, 18);
            this.lServerPortCaption.TabIndex = 4;
            this.lServerPortCaption.Text = "Server port:";
            // 
            // lServerIP
            // 
            this.lServerIP.AutoSize = true;
            this.lServerIP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lServerIP.ForeColor = System.Drawing.Color.Red;
            this.lServerIP.Location = new System.Drawing.Point(154, 46);
            this.lServerIP.Name = "lServerIP";
            this.lServerIP.Size = new System.Drawing.Size(34, 18);
            this.lServerIP.TabIndex = 3;
            this.lServerIP.Text = "N/A";
            // 
            // lServerIPCaption
            // 
            this.lServerIPCaption.AutoSize = true;
            this.lServerIPCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lServerIPCaption.Location = new System.Drawing.Point(12, 46);
            this.lServerIPCaption.Name = "lServerIPCaption";
            this.lServerIPCaption.Size = new System.Drawing.Size(76, 18);
            this.lServerIPCaption.TabIndex = 2;
            this.lServerIPCaption.Text = "Server IP:";
            // 
            // lClientIP
            // 
            this.lClientIP.AutoSize = true;
            this.lClientIP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lClientIP.ForeColor = System.Drawing.Color.Red;
            this.lClientIP.Location = new System.Drawing.Point(154, 28);
            this.lClientIP.Name = "lClientIP";
            this.lClientIP.Size = new System.Drawing.Size(34, 18);
            this.lClientIP.TabIndex = 1;
            this.lClientIP.Text = "N/A";
            // 
            // lClientIPCaption
            // 
            this.lClientIPCaption.AutoSize = true;
            this.lClientIPCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lClientIPCaption.Location = new System.Drawing.Point(12, 28);
            this.lClientIPCaption.Name = "lClientIPCaption";
            this.lClientIPCaption.Size = new System.Drawing.Size(70, 18);
            this.lClientIPCaption.TabIndex = 0;
            this.lClientIPCaption.Text = "Client IP:";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 147);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbSensors);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbLog);
            this.splitContainer1.Size = new System.Drawing.Size(877, 401);
            this.splitContainer1.SplitterDistance = 167;
            this.splitContainer1.TabIndex = 4;
            // 
            // gbSensors
            // 
            this.gbSensors.Controls.Add(this.dgvSensors);
            this.gbSensors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSensors.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbSensors.Location = new System.Drawing.Point(0, 0);
            this.gbSensors.Name = "gbSensors";
            this.gbSensors.Size = new System.Drawing.Size(877, 167);
            this.gbSensors.TabIndex = 4;
            this.gbSensors.TabStop = false;
            this.gbSensors.Text = "Sensors";
            // 
            // dgvSensors
            // 
            this.dgvSensors.AllowUserToAddRows = false;
            this.dgvSensors.AllowUserToDeleteRows = false;
            this.dgvSensors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSensors.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvSensors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSensors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sensorSystemName,
            this.sensorUserName,
            this.sensorStatus,
            this.sensorLastTemp,
            this.sensorDescription});
            this.dgvSensors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSensors.Location = new System.Drawing.Point(3, 28);
            this.dgvSensors.MultiSelect = false;
            this.dgvSensors.Name = "dgvSensors";
            this.dgvSensors.ReadOnly = true;
            this.dgvSensors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSensors.Size = new System.Drawing.Size(871, 136);
            this.dgvSensors.TabIndex = 0;
            // 
            // sensorSystemName
            // 
            this.sensorSystemName.FillWeight = 60.9137F;
            this.sensorSystemName.HeaderText = "Sensor";
            this.sensorSystemName.Name = "sensorSystemName";
            this.sensorSystemName.ReadOnly = true;
            this.sensorSystemName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // sensorUserName
            // 
            this.sensorUserName.FillWeight = 110.058F;
            this.sensorUserName.HeaderText = "Sensor name";
            this.sensorUserName.Name = "sensorUserName";
            this.sensorUserName.ReadOnly = true;
            // 
            // sensorStatus
            // 
            this.sensorStatus.FillWeight = 98.85445F;
            this.sensorStatus.HeaderText = "Sensor status";
            this.sensorStatus.Name = "sensorStatus";
            this.sensorStatus.ReadOnly = true;
            // 
            // sensorLastTemp
            // 
            this.sensorLastTemp.FillWeight = 110.058F;
            this.sensorLastTemp.HeaderText = "Sensor last temp";
            this.sensorLastTemp.Name = "sensorLastTemp";
            this.sensorLastTemp.ReadOnly = true;
            // 
            // sensorDescription
            // 
            this.sensorDescription.FillWeight = 220.1159F;
            this.sensorDescription.HeaderText = "Sensor description";
            this.sensorDescription.Name = "sensorDescription";
            this.sensorDescription.ReadOnly = true;
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.dgvLog);
            this.gbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLog.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbLog.Location = new System.Drawing.Point(0, 0);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(877, 230);
            this.gbLog.TabIndex = 1;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Log";
            // 
            // dgvLog
            // 
            this.dgvLog.AllowUserToAddRows = false;
            this.dgvLog.AllowUserToDeleteRows = false;
            this.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLog.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventDate,
            this.eventDescription});
            this.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLog.Location = new System.Drawing.Point(3, 28);
            this.dgvLog.MultiSelect = false;
            this.dgvLog.Name = "dgvLog";
            this.dgvLog.ReadOnly = true;
            this.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLog.Size = new System.Drawing.Size(871, 199);
            this.dgvLog.TabIndex = 0;
            // 
            // eventDate
            // 
            this.eventDate.HeaderText = "Event Date";
            this.eventDate.Name = "eventDate";
            this.eventDate.ReadOnly = true;
            // 
            // eventDescription
            // 
            this.eventDescription.FillWeight = 253.6912F;
            this.eventDescription.HeaderText = "Event description";
            this.eventDescription.Name = "eventDescription";
            this.eventDescription.ReadOnly = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 548);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.gbConnectionInfo);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TMClient";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Shown += new System.EventHandler(this.MainWindow_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbConnectionInfo.ResumeLayout(false);
            this.gbConnectionInfo.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gbSensors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensors)).EndInit();
            this.gbLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox gbConnectionInfo;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbSensors;
        public System.Windows.Forms.DataGridView dgvSensors;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.DataGridView dgvLog;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDescription;
        private System.Windows.Forms.ToolStripButton tsbAddSensor;
        private System.Windows.Forms.ToolStripButton tsbRemoveSensor;
        private System.Windows.Forms.ToolStripButton tsbEditSensor;
        private System.Windows.Forms.ToolStripButton tsbSaveSensors;
        private System.Windows.Forms.ToolStripButton tsbConnect;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.Label lServerPortCaption;
        private System.Windows.Forms.Label lServerIPCaption;
        private System.Windows.Forms.Label lClientIPCaption;
        private System.Windows.Forms.Label lConnectionStatus;
        private System.Windows.Forms.Label lConnectionStatusCaption;
        public System.Windows.Forms.Label lServerPort;
        public System.Windows.Forms.Label lServerIP;
        public System.Windows.Forms.Label lClientIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorSystemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorLastTemp;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorDescription;
    }
}

