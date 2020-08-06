namespace TWServer
{
    partial class AddEditSensorForm
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
            this.lSensorCaption = new System.Windows.Forms.Label();
            this.cbSensors = new System.Windows.Forms.ComboBox();
            this.lSensorName = new System.Windows.Forms.Label();
            this.tbSensorName = new System.Windows.Forms.TextBox();
            this.tbSensorDescription = new System.Windows.Forms.TextBox();
            this.lSensorDescriptionCaption = new System.Windows.Forms.Label();
            this.bOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lSensorCaption
            // 
            this.lSensorCaption.AutoSize = true;
            this.lSensorCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSensorCaption.Location = new System.Drawing.Point(28, 35);
            this.lSensorCaption.Name = "lSensorCaption";
            this.lSensorCaption.Size = new System.Drawing.Size(114, 18);
            this.lSensorCaption.TabIndex = 0;
            this.lSensorCaption.Text = "Choose sensor";
            // 
            // cbSensors
            // 
            this.cbSensors.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbSensors.FormattingEnabled = true;
            this.cbSensors.Items.AddRange(new object[] {
            "t0",
            "t1",
            "t2",
            "t3",
            "t4",
            "t5",
            "t6",
            "t7",
            "t8",
            "t9"});
            this.cbSensors.Location = new System.Drawing.Point(31, 56);
            this.cbSensors.Name = "cbSensors";
            this.cbSensors.Size = new System.Drawing.Size(322, 26);
            this.cbSensors.TabIndex = 1;
            this.cbSensors.SelectedIndexChanged += new System.EventHandler(this.cbSensors_SelectedIndexChanged);
            // 
            // lSensorName
            // 
            this.lSensorName.AutoSize = true;
            this.lSensorName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSensorName.Location = new System.Drawing.Point(28, 119);
            this.lSensorName.Name = "lSensorName";
            this.lSensorName.Size = new System.Drawing.Size(135, 18);
            this.lSensorName.TabIndex = 2;
            this.lSensorName.Text = "Type sensor name";
            // 
            // tbSensorName
            // 
            this.tbSensorName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSensorName.Location = new System.Drawing.Point(31, 140);
            this.tbSensorName.Name = "tbSensorName";
            this.tbSensorName.Size = new System.Drawing.Size(322, 26);
            this.tbSensorName.TabIndex = 3;
            // 
            // tbSensorDescription
            // 
            this.tbSensorDescription.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbSensorDescription.Location = new System.Drawing.Point(31, 222);
            this.tbSensorDescription.Multiline = true;
            this.tbSensorDescription.Name = "tbSensorDescription";
            this.tbSensorDescription.Size = new System.Drawing.Size(322, 102);
            this.tbSensorDescription.TabIndex = 5;
            // 
            // lSensorDescriptionCaption
            // 
            this.lSensorDescriptionCaption.AutoSize = true;
            this.lSensorDescriptionCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lSensorDescriptionCaption.Location = new System.Drawing.Point(28, 201);
            this.lSensorDescriptionCaption.Name = "lSensorDescriptionCaption";
            this.lSensorDescriptionCaption.Size = new System.Drawing.Size(173, 18);
            this.lSensorDescriptionCaption.TabIndex = 4;
            this.lSensorDescriptionCaption.Text = "Type sensor description";
            // 
            // bOK
            // 
            this.bOK.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bOK.Location = new System.Drawing.Point(31, 375);
            this.bOK.Name = "bOK";
            this.bOK.Size = new System.Drawing.Size(110, 39);
            this.bOK.TabIndex = 6;
            this.bOK.Text = "OK";
            this.bOK.UseVisualStyleBackColor = true;
            this.bOK.Click += new System.EventHandler(this.bOK_Click);
            // 
            // bCancel
            // 
            this.bCancel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bCancel.Location = new System.Drawing.Point(243, 375);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(110, 39);
            this.bCancel.TabIndex = 7;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // AddEditSensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 426);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOK);
            this.Controls.Add(this.tbSensorDescription);
            this.Controls.Add(this.lSensorDescriptionCaption);
            this.Controls.Add(this.tbSensorName);
            this.Controls.Add(this.lSensorName);
            this.Controls.Add(this.cbSensors);
            this.Controls.Add(this.lSensorCaption);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditSensorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add sensor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lSensorCaption;
        private System.Windows.Forms.Label lSensorName;
        private System.Windows.Forms.Label lSensorDescriptionCaption;
        public System.Windows.Forms.ComboBox cbSensors;
        public System.Windows.Forms.TextBox tbSensorName;
        public System.Windows.Forms.TextBox tbSensorDescription;
        public System.Windows.Forms.Button bOK;
        public System.Windows.Forms.Button bCancel;
    }
}