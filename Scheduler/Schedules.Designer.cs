namespace Vixen_Messaging
{
	partial class Schedules
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedules));
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxSchedulerDay = new System.Windows.Forms.ComboBox();
			this.dateTimePickerOn = new System.Windows.Forms.DateTimePicker();
			this.Cancel = new System.Windows.Forms.PictureBox();
			this.ok = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePickerOff = new System.Windows.Forms.DateTimePicker();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ok)).BeginInit();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.AddExtension = false;
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// toolTip2
			// 
			this.toolTip2.AutoPopDelay = 10000;
			this.toolTip2.InitialDelay = 500;
			this.toolTip2.ReshowDelay = 100;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.Transparent;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label4.Location = new System.Drawing.Point(34, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(78, 20);
			this.label4.TabIndex = 106;
			this.label4.Text = "Time On:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label3.Location = new System.Drawing.Point(34, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(44, 20);
			this.label3.TabIndex = 102;
			this.label3.Text = "Day:";
			// 
			// comboBoxSchedulerDay
			// 
			this.comboBoxSchedulerDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSchedulerDay.FormattingEnabled = true;
			this.comboBoxSchedulerDay.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
			this.comboBoxSchedulerDay.Location = new System.Drawing.Point(122, 22);
			this.comboBoxSchedulerDay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxSchedulerDay.Name = "comboBoxSchedulerDay";
			this.comboBoxSchedulerDay.Size = new System.Drawing.Size(127, 24);
			this.comboBoxSchedulerDay.TabIndex = 2;
			this.comboBoxSchedulerDay.SelectedIndexChanged += new System.EventHandler(this.comboBoxSchedulerDay_SelectedIndexChanged);
			// 
			// dateTimePickerOn
			// 
			this.dateTimePickerOn.CustomFormat = "HH:mm:ss";
			this.dateTimePickerOn.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerOn.Location = new System.Drawing.Point(122, 71);
			this.dateTimePickerOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dateTimePickerOn.Name = "dateTimePickerOn";
			this.dateTimePickerOn.Size = new System.Drawing.Size(127, 22);
			this.dateTimePickerOn.TabIndex = 3;
			this.dateTimePickerOn.Value = new System.DateTime(2015, 6, 16, 21, 32, 0, 0);
			this.dateTimePickerOn.ValueChanged += new System.EventHandler(this.Time_Change);
			// 
			// Cancel
			// 
			this.Cancel.Location = new System.Drawing.Point(148, 199);
			this.Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(61, 61);
			this.Cancel.TabIndex = 93;
			this.Cancel.TabStop = false;
			this.Cancel.Tag = "8";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(72, 199);
			this.ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(61, 61);
			this.ok.TabIndex = 92;
			this.ok.TabStop = false;
			this.ok.Tag = "7";
			this.ok.Click += new System.EventHandler(this.Ok_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label1.Location = new System.Drawing.Point(34, 132);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 20);
			this.label1.TabIndex = 108;
			this.label1.Text = "Time Off:";
			// 
			// dateTimePickerOff
			// 
			this.dateTimePickerOff.CustomFormat = "HH:mm:ss";
			this.dateTimePickerOff.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePickerOff.Location = new System.Drawing.Point(122, 130);
			this.dateTimePickerOff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dateTimePickerOff.Name = "dateTimePickerOff";
			this.dateTimePickerOff.Size = new System.Drawing.Size(127, 22);
			this.dateTimePickerOff.TabIndex = 107;
			this.dateTimePickerOff.Value = new System.DateTime(2015, 6, 16, 21, 32, 0, 0);
			this.dateTimePickerOff.ValueChanged += new System.EventHandler(this.Time_Change);
			// 
			// Schedules
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(282, 253);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.dateTimePickerOff);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBoxSchedulerDay);
			this.Controls.Add(this.dateTimePickerOn);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(300, 300);
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "Schedules";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Scheduler";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Scheduler_FormClosing);
			this.Load += new System.EventHandler(this.Schedules_Load);
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ok)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolTip toolTip2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxSchedulerDay;
		private System.Windows.Forms.DateTimePicker dateTimePickerOn;
		public System.Windows.Forms.PictureBox Cancel;
		private System.Windows.Forms.PictureBox ok;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DateTimePicker dateTimePickerOff;
    }
}