namespace TWServer
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
            this.tsbStartStop = new System.Windows.Forms.ToolStripButton();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbConnectedClients = new System.Windows.Forms.GroupBox();
            this.dgvConnectedClients = new System.Windows.Forms.DataGridView();
            this.connectionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.dgvLog = new System.Windows.Forms.DataGridView();
            this.eventDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.serverStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConnectedClientsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbConnectedClients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConnectedClients)).BeginInit();
            this.gbLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStartStop,
            this.tsbSettings});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(751, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbStartStop
            // 
            this.tsbStartStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbStartStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStartStop.Image")));
            this.tsbStartStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStartStop.Name = "tsbStartStop";
            this.tsbStartStop.Size = new System.Drawing.Size(45, 22);
            this.tsbStartStop.Text = "Start";
            this.tsbStartStop.Click += new System.EventHandler(this.tsbStartStop_Click);
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
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 28);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbConnectedClients);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbLog);
            this.splitContainer1.Size = new System.Drawing.Size(751, 532);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.TabIndex = 1;
            // 
            // gbConnectedClients
            // 
            this.gbConnectedClients.Controls.Add(this.dgvConnectedClients);
            this.gbConnectedClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbConnectedClients.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbConnectedClients.Location = new System.Drawing.Point(0, 0);
            this.gbConnectedClients.Name = "gbConnectedClients";
            this.gbConnectedClients.Size = new System.Drawing.Size(751, 161);
            this.gbConnectedClients.TabIndex = 0;
            this.gbConnectedClients.TabStop = false;
            this.gbConnectedClients.Text = "Connected clients";
            // 
            // dgvConnectedClients
            // 
            this.dgvConnectedClients.AllowUserToAddRows = false;
            this.dgvConnectedClients.AllowUserToDeleteRows = false;
            this.dgvConnectedClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConnectedClients.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvConnectedClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvConnectedClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConnectedClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.connectionDate,
            this.hostName,
            this.hostIP});
            this.dgvConnectedClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConnectedClients.Location = new System.Drawing.Point(3, 28);
            this.dgvConnectedClients.MultiSelect = false;
            this.dgvConnectedClients.Name = "dgvConnectedClients";
            this.dgvConnectedClients.ReadOnly = true;
            this.dgvConnectedClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConnectedClients.Size = new System.Drawing.Size(745, 130);
            this.dgvConnectedClients.TabIndex = 0;
            // 
            // connectionDate
            // 
            this.connectionDate.HeaderText = "Connection date";
            this.connectionDate.Name = "connectionDate";
            this.connectionDate.ReadOnly = true;
            // 
            // hostName
            // 
            this.hostName.HeaderText = "Host name";
            this.hostName.Name = "hostName";
            this.hostName.ReadOnly = true;
            // 
            // hostIP
            // 
            this.hostIP.HeaderText = "Host IP";
            this.hostIP.Name = "hostIP";
            this.hostIP.ReadOnly = true;
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.dgvLog);
            this.gbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLog.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbLog.Location = new System.Drawing.Point(0, 0);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(751, 367);
            this.gbLog.TabIndex = 0;
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
            this.dgvLog.Size = new System.Drawing.Size(745, 336);
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverStatus,
            this.ConnectedClientsCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 561);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(751, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // serverStatus
            // 
            this.serverStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.serverStatus.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.serverStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.serverStatus.Name = "serverStatus";
            this.serverStatus.Size = new System.Drawing.Size(368, 19);
            this.serverStatus.Spring = true;
            this.serverStatus.Text = "Server status: offline";
            // 
            // ConnectedClientsCount
            // 
            this.ConnectedClientsCount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ConnectedClientsCount.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.ConnectedClientsCount.Name = "ConnectedClientsCount";
            this.ConnectedClientsCount.Size = new System.Drawing.Size(368, 19);
            this.ConnectedClientsCount.Spring = true;
            this.ConnectedClientsCount.Text = "Connected clients count: 0";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 585);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TMServer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gbConnectedClients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConnectedClients)).EndInit();
            this.gbLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLog)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbConnectedClients;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.ToolStripButton tsbStartStop;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel serverStatus;
        private System.Windows.Forms.ToolStripStatusLabel ConnectedClientsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn connectionDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDescription;
        public System.Windows.Forms.DataGridView dgvConnectedClients;
        public System.Windows.Forms.DataGridView dgvLog;

    }
}

