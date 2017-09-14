namespace Vixen_Messaging
{
	partial class Messages
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Messages));
			this.ok = new System.Windows.Forms.PictureBox();
			this.Cancel = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxMessages = new System.Windows.Forms.TextBox();
			this.textBoxCountDownMSG = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBoxAdvertisingMSG = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.trackBarRandomAdvetisingSensitivity = new System.Windows.Forms.TrackBar();
			this.label44 = new System.Windows.Forms.Label();
			this.trackBarRandomCountDownSensitivity = new System.Windows.Forms.TrackBar();
			this.label8 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.trackBarRandomMessagesSensitivity = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomAdvetisingSensitivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomCountDownSensitivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomMessagesSensitivity)).BeginInit();
			this.SuspendLayout();
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(466, 591);
			this.ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(61, 61);
			this.ok.TabIndex = 3;
			this.ok.TabStop = false;
			this.ok.Tag = "7";
			this.ok.Click += new System.EventHandler(this.Ok_Click);
			// 
			// Cancel
			// 
			this.Cancel.Location = new System.Drawing.Point(542, 591);
			this.Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(61, 61);
			this.Cancel.TabIndex = 4;
			this.Cancel.TabStop = false;
			this.Cancel.Tag = "8";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(14, 288);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(182, 34);
			this.label9.TabIndex = 7;
			this.label9.Text = "Extra Messages:";
			this.toolTip1.SetToolTip(this.label9, "Enter a message that will be sent to the audiance member that sent the inappropia" +
        "te words that they have been banned.");
			// 
			// textBoxMessages
			// 
			this.textBoxMessages.Location = new System.Drawing.Point(210, 280);
			this.textBoxMessages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxMessages.Multiline = true;
			this.textBoxMessages.Name = "textBoxMessages";
			this.textBoxMessages.Size = new System.Drawing.Size(407, 244);
			this.textBoxMessages.TabIndex = 4;
			this.toolTip1.SetToolTip(this.textBoxMessages, "Enter a message that will be sent to the audiance member that sent the inappropia" +
        "te words that they have been banned.");
			this.textBoxMessages.TextChanged += new System.EventHandler(this.textBoxMessages_TextChanged);
			// 
			// textBoxCountDownMSG
			// 
			this.textBoxCountDownMSG.Location = new System.Drawing.Point(209, 26);
			this.textBoxCountDownMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxCountDownMSG.Multiline = true;
			this.textBoxCountDownMSG.Name = "textBoxCountDownMSG";
			this.textBoxCountDownMSG.Size = new System.Drawing.Size(405, 62);
			this.textBoxCountDownMSG.TabIndex = 95;
			this.toolTip1.SetToolTip(this.textBoxCountDownMSG, "Enter a message that will be displayed when Countdown is enabled. Add the word CO" +
        "UNTDOWN anywhere in the message which will be replaced by number of days to the " +
        "countdown date.");
			this.textBoxCountDownMSG.TextChanged += new System.EventHandler(this.textBoxMessages_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(15, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(186, 33);
			this.label3.TabIndex = 96;
			this.label3.Text = "Count down message";
			this.toolTip1.SetToolTip(this.label3, "Enter a message that will be displayed when Countdown is enabled. Add the word CO" +
        "UNTDOWN which will be replaced by number of days.");
			// 
			// textBoxAdvertisingMSG
			// 
			this.textBoxAdvertisingMSG.Location = new System.Drawing.Point(209, 146);
			this.textBoxAdvertisingMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxAdvertisingMSG.Multiline = true;
			this.textBoxAdvertisingMSG.Name = "textBoxAdvertisingMSG";
			this.textBoxAdvertisingMSG.Size = new System.Drawing.Size(406, 66);
			this.textBoxAdvertisingMSG.TabIndex = 97;
			this.toolTip1.SetToolTip(this.textBoxAdvertisingMSG, "Enter a advertising message that will be randomly displayed when enabled.");
			this.textBoxAdvertisingMSG.TextChanged += new System.EventHandler(this.textBoxMessages_TextChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(13, 154);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(186, 33);
			this.label10.TabIndex = 98;
			this.label10.Text = "Advertising message";
			this.toolTip1.SetToolTip(this.label10, "Enter a message that will be displayed when Advertising is enabled.");
			// 
			// trackBarRandomAdvetisingSensitivity
			// 
			this.trackBarRandomAdvetisingSensitivity.AutoSize = false;
			this.trackBarRandomAdvetisingSensitivity.LargeChange = 1;
			this.trackBarRandomAdvetisingSensitivity.Location = new System.Drawing.Point(238, 229);
			this.trackBarRandomAdvetisingSensitivity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarRandomAdvetisingSensitivity.Maximum = 50;
			this.trackBarRandomAdvetisingSensitivity.Minimum = 1;
			this.trackBarRandomAdvetisingSensitivity.Name = "trackBarRandomAdvetisingSensitivity";
			this.trackBarRandomAdvetisingSensitivity.Size = new System.Drawing.Size(376, 32);
			this.trackBarRandomAdvetisingSensitivity.TabIndex = 99;
			this.toolTip1.SetToolTip(this.trackBarRandomAdvetisingSensitivity, "This will adjust the sensitivity of how often the Advertising messages is display" +
        "ed.");
			this.trackBarRandomAdvetisingSensitivity.Value = 1;
			this.trackBarRandomAdvetisingSensitivity.Scroll += new System.EventHandler(this.trackBarTextPosition_MouseDown);
			this.trackBarRandomAdvetisingSensitivity.ValueChanged += new System.EventHandler(this.trackBarTextPosition_VisibleChanged);
			this.trackBarRandomAdvetisingSensitivity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextPosition_MouseDown);
			this.trackBarRandomAdvetisingSensitivity.MouseHover += new System.EventHandler(this.trackBarTextPosition_MouseDown);
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(15, 234);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(206, 17);
			this.label44.TabIndex = 100;
			this.label44.Text = "Random Advertising Sensitivity:";
			this.toolTip1.SetToolTip(this.label44, "This will adjust the sensitivity of how often the Advertising messages is display" +
        "ed.");
			// 
			// trackBarRandomCountDownSensitivity
			// 
			this.trackBarRandomCountDownSensitivity.AutoSize = false;
			this.trackBarRandomCountDownSensitivity.LargeChange = 1;
			this.trackBarRandomCountDownSensitivity.Location = new System.Drawing.Point(238, 102);
			this.trackBarRandomCountDownSensitivity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarRandomCountDownSensitivity.Maximum = 50;
			this.trackBarRandomCountDownSensitivity.Minimum = 1;
			this.trackBarRandomCountDownSensitivity.Name = "trackBarRandomCountDownSensitivity";
			this.trackBarRandomCountDownSensitivity.Size = new System.Drawing.Size(376, 32);
			this.trackBarRandomCountDownSensitivity.TabIndex = 101;
			this.toolTip1.SetToolTip(this.trackBarRandomCountDownSensitivity, "This will adjust the sensitivity of how often the Countdown message is displayed." +
        "");
			this.trackBarRandomCountDownSensitivity.Value = 1;
			this.trackBarRandomCountDownSensitivity.Scroll += new System.EventHandler(this.trackBarTextPosition_MouseDown);
			this.trackBarRandomCountDownSensitivity.ValueChanged += new System.EventHandler(this.trackBarTextPosition_VisibleChanged);
			this.trackBarRandomCountDownSensitivity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextPosition_MouseDown);
			this.trackBarRandomCountDownSensitivity.MouseHover += new System.EventHandler(this.trackBarTextPosition_MouseDown);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(15, 107);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(208, 17);
			this.label8.TabIndex = 102;
			this.label8.Text = "Random CountDown Sensitivity:";
			this.toolTip1.SetToolTip(this.label8, "This will adjust the sensitivity of how often the Countdown message is displayed." +
        "");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 322);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(150, 202);
			this.label1.TabIndex = 103;
			this.label1.Text = "Note: Add COUNTDOWN anywhere in the messages and it will be replace with the numb" +
    "er of days to the countdown date.";
			this.toolTip1.SetToolTip(this.label1, "Enter a message that will be sent to the audiance member that sent the inappropia" +
        "te words that they have been banned.");
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.AddExtension = false;
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// trackBarRandomMessagesSensitivity
			// 
			this.trackBarRandomMessagesSensitivity.AutoSize = false;
			this.trackBarRandomMessagesSensitivity.LargeChange = 1;
			this.trackBarRandomMessagesSensitivity.Location = new System.Drawing.Point(241, 542);
			this.trackBarRandomMessagesSensitivity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarRandomMessagesSensitivity.Maximum = 50;
			this.trackBarRandomMessagesSensitivity.Minimum = 1;
			this.trackBarRandomMessagesSensitivity.Name = "trackBarRandomMessagesSensitivity";
			this.trackBarRandomMessagesSensitivity.Size = new System.Drawing.Size(376, 32);
			this.trackBarRandomMessagesSensitivity.TabIndex = 104;
			this.toolTip1.SetToolTip(this.trackBarRandomMessagesSensitivity, "This will adjust the sensitivity of how often the Advertising messages is display" +
        "ed.");
			this.trackBarRandomMessagesSensitivity.Value = 1;
			this.trackBarRandomMessagesSensitivity.Scroll += new System.EventHandler(this.trackBarTextPosition_MouseDown);
			this.trackBarRandomMessagesSensitivity.ValueChanged += new System.EventHandler(this.trackBarTextPosition_VisibleChanged);
			this.trackBarRandomMessagesSensitivity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextPosition_MouseDown);
			this.trackBarRandomMessagesSensitivity.MouseHover += new System.EventHandler(this.trackBarTextPosition_MouseDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 547);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(200, 17);
			this.label2.TabIndex = 105;
			this.label2.Text = "Random Messages Sensitivity:";
			this.toolTip1.SetToolTip(this.label2, "This will adjust the sensitivity of how often the messages are displayed.");
			// 
			// Messages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(642, 633);
			this.Controls.Add(this.trackBarRandomMessagesSensitivity);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.trackBarRandomCountDownSensitivity);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.textBoxMessages);
			this.Controls.Add(this.trackBarRandomAdvetisingSensitivity);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.textBoxCountDownMSG);
			this.Controls.Add(this.label44);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.textBoxAdvertisingMSG);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(660, 680);
			this.MinimumSize = new System.Drawing.Size(660, 680);
			this.Name = "Messages";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Displayed Messages";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessagingSettings_FormClosing);
			this.Load += new System.EventHandler(this.Messages_Load);
			((System.ComponentModel.ISupportInitialize)(this.ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomAdvetisingSensitivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomCountDownSensitivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomMessagesSensitivity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.PictureBox ok;
		private System.Windows.Forms.ToolTip toolTip1;
		public System.Windows.Forms.PictureBox Cancel;
		private System.Windows.Forms.TextBox textBoxMessages;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.TextBox textBoxCountDownMSG;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxAdvertisingMSG;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TrackBar trackBarRandomAdvetisingSensitivity;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TrackBar trackBarRandomCountDownSensitivity;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TrackBar trackBarRandomMessagesSensitivity;
		private System.Windows.Forms.Label label2;
    }
}