using System;
using System.Drawing;

namespace Vixen_Messaging
{
    partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.timerCheckTwilio = new System.Windows.Forms.Timer(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.checkBoxVixenControl = new System.Windows.Forms.CheckBox();
			this.buttonStart = new System.Windows.Forms.PictureBox();
			this.buttonStop = new System.Windows.Forms.PictureBox();
			this.buttonStopSequence = new System.Windows.Forms.Button();
			this.buttonInstantMSG = new System.Windows.Forms.Button();
			this.checkBoxCountDown = new System.Windows.Forms.CheckBox();
			this.WebServerStatus = new System.Windows.Forms.Button();
			this.timerCheckVixenEnabled = new System.Windows.Forms.Timer(this.components);
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exportLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.twilioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.messagingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.whiteBlackListsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkBoxAdvertising = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.buttonStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStop)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// timerCheckTwilio
			// 
			this.timerCheckTwilio.Interval = 1000;
			this.timerCheckTwilio.Tick += new System.EventHandler(this.timerCheckTwilio_Tick);
			// 
			// toolTip1
			// 
			this.toolTip1.AutomaticDelay = 300;
			this.toolTip1.AutoPopDelay = 10000;
			this.toolTip1.InitialDelay = 300;
			this.toolTip1.ReshowDelay = 60;
			// 
			// checkBoxVixenControl
			// 
			this.checkBoxVixenControl.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxVixenControl.Location = new System.Drawing.Point(241, 30);
			this.checkBoxVixenControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxVixenControl.Name = "checkBoxVixenControl";
			this.checkBoxVixenControl.Size = new System.Drawing.Size(174, 42);
			this.checkBoxVixenControl.TabIndex = 68;
			this.checkBoxVixenControl.Text = "Enable Vixen 3 Control";
			this.checkBoxVixenControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.checkBoxVixenControl, resources.GetString("checkBoxVixenControl.ToolTip"));
			this.checkBoxVixenControl.UseVisualStyleBackColor = true;
			this.checkBoxVixenControl.CheckedChanged += new System.EventHandler(this.checkBoxVixenControl_CheckedChanged);
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(54, 48);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(61, 61);
			this.buttonStart.TabIndex = 13;
			this.buttonStart.TabStop = false;
			this.buttonStart.Tag = "20";
			this.toolTip1.SetToolTip(this.buttonStart, "Starts checking Twilio for messages.");
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(120, 48);
			this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(61, 61);
			this.buttonStop.TabIndex = 14;
			this.buttonStop.TabStop = false;
			this.buttonStop.Tag = "21";
			this.toolTip1.SetToolTip(this.buttonStop, "Stops checking Twilio for messages.");
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// buttonStopSequence
			// 
			this.buttonStopSequence.BackColor = System.Drawing.Color.Honeydew;
			this.buttonStopSequence.Location = new System.Drawing.Point(235, 157);
			this.buttonStopSequence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonStopSequence.Name = "buttonStopSequence";
			this.buttonStopSequence.Size = new System.Drawing.Size(175, 39);
			this.buttonStopSequence.TabIndex = 61;
			this.buttonStopSequence.Text = "Stop current message";
			this.toolTip1.SetToolTip(this.buttonStopSequence, "Stops current displayed message.");
			this.buttonStopSequence.UseVisualStyleBackColor = false;
			this.buttonStopSequence.Click += new System.EventHandler(this.buttonStopSequence_Click);
			this.buttonStopSequence.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonStopSequence.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// buttonInstantMSG
			// 
			this.buttonInstantMSG.BackColor = System.Drawing.Color.Honeydew;
			this.buttonInstantMSG.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonInstantMSG.Location = new System.Drawing.Point(25, 157);
			this.buttonInstantMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonInstantMSG.Name = "buttonInstantMSG";
			this.buttonInstantMSG.Size = new System.Drawing.Size(173, 39);
			this.buttonInstantMSG.TabIndex = 107;
			this.buttonInstantMSG.Text = "Send Instant Message";
			this.toolTip1.SetToolTip(this.buttonInstantMSG, "Sends an instant message to your lights.");
			this.buttonInstantMSG.UseVisualStyleBackColor = false;
			this.buttonInstantMSG.Click += new System.EventHandler(this.buttonInstantMSG_Click);
			this.buttonInstantMSG.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonInstantMSG.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// checkBoxCountDown
			// 
			this.checkBoxCountDown.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxCountDown.Location = new System.Drawing.Point(221, 74);
			this.checkBoxCountDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxCountDown.Name = "checkBoxCountDown";
			this.checkBoxCountDown.Size = new System.Drawing.Size(194, 34);
			this.checkBoxCountDown.TabIndex = 118;
			this.checkBoxCountDown.Text = "Enable Countdown Msg";
			this.checkBoxCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.checkBoxCountDown, "When enabled, Messaging will send a count down message to be displayed on a Rando" +
        "m bases.");
			this.checkBoxCountDown.UseVisualStyleBackColor = true;
			this.checkBoxCountDown.CheckedChanged += new System.EventHandler(this.checkBoxCountDown_CheckedChanged);
			// 
			// WebServerStatus
			// 
			this.WebServerStatus.BackColor = System.Drawing.Color.OrangeRed;
			this.WebServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WebServerStatus.Location = new System.Drawing.Point(92, 410);
			this.WebServerStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.WebServerStatus.Name = "WebServerStatus";
			this.WebServerStatus.Size = new System.Drawing.Size(255, 34);
			this.WebServerStatus.TabIndex = 31;
			this.WebServerStatus.Text = "Vixen 3 Web Server is ENABLED";
			this.WebServerStatus.UseVisualStyleBackColor = false;
			// 
			// timerCheckVixenEnabled
			// 
			this.timerCheckVixenEnabled.Interval = 300;
			this.timerCheckVixenEnabled.Tick += new System.EventHandler(this.timerCheckVixenEnabled_Tick);
			// 
			// richTextBoxLog
			// 
			this.richTextBoxLog.Location = new System.Drawing.Point(12, 236);
			this.richTextBoxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxLog.Name = "richTextBoxLog";
			this.richTextBoxLog.Size = new System.Drawing.Size(418, 163);
			this.richTextBoxLog.TabIndex = 1;
			this.richTextBoxLog.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 208);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 17);
			this.label6.TabIndex = 115;
			this.label6.Text = "Log";
			// 
			// menuStrip1
			// 
			this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItemFile,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(442, 28);
			this.menuStrip1.TabIndex = 117;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItemFile
			// 
			this.fileToolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.exportLogToolStripMenuItem,
            this.closeToolStripMenuItem});
			this.fileToolStripMenuItemFile.Name = "fileToolStripMenuItemFile";
			this.fileToolStripMenuItemFile.Size = new System.Drawing.Size(44, 24);
			this.fileToolStripMenuItemFile.Text = "File";
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// exportLogToolStripMenuItem
			// 
			this.exportLogToolStripMenuItem.Name = "exportLogToolStripMenuItem";
			this.exportLogToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
			this.exportLogToolStripMenuItem.Text = "Export Log";
			this.exportLogToolStripMenuItem.Click += new System.EventHandler(this.exportLogToolStripMenuItem_Click);
			// 
			// closeToolStripMenuItem
			// 
			this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			this.closeToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
			this.closeToolStripMenuItem.Text = "Close";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.twilioToolStripMenuItem,
            this.messagingToolStripMenuItem,
            this.textToolStripMenuItem,
            this.whiteBlackListsToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// twilioToolStripMenuItem
			// 
			this.twilioToolStripMenuItem.Name = "twilioToolStripMenuItem";
			this.twilioToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
			this.twilioToolStripMenuItem.Text = "Twilio";
			this.twilioToolStripMenuItem.Click += new System.EventHandler(this.twilioToolStripMenuItem_Click);
			// 
			// messagingToolStripMenuItem
			// 
			this.messagingToolStripMenuItem.Name = "messagingToolStripMenuItem";
			this.messagingToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
			this.messagingToolStripMenuItem.Text = "Messaging";
			this.messagingToolStripMenuItem.Click += new System.EventHandler(this.messagingToolStripMenuItem_Click);
			// 
			// textToolStripMenuItem
			// 
			this.textToolStripMenuItem.Name = "textToolStripMenuItem";
			this.textToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
			this.textToolStripMenuItem.Text = "Text";
			this.textToolStripMenuItem.Click += new System.EventHandler(this.textToolStripMenuItem_Click);
			// 
			// whiteBlackListsToolStripMenuItem
			// 
			this.whiteBlackListsToolStripMenuItem.Name = "whiteBlackListsToolStripMenuItem";
			this.whiteBlackListsToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
			this.whiteBlackListsToolStripMenuItem.Text = "White/Black Lists";
			this.whiteBlackListsToolStripMenuItem.Click += new System.EventHandler(this.whiteBlackListsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
			this.helpToolStripMenuItem.Text = "Help";
			this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
			// 
			// checkBoxAdvertising
			// 
			this.checkBoxAdvertising.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxAdvertising.Location = new System.Drawing.Point(221, 113);
			this.checkBoxAdvertising.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxAdvertising.Name = "checkBoxAdvertising";
			this.checkBoxAdvertising.Size = new System.Drawing.Size(194, 34);
			this.checkBoxAdvertising.TabIndex = 119;
			this.checkBoxAdvertising.Text = "Enable Advertising Msg";
			this.checkBoxAdvertising.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.checkBoxAdvertising, "When enabled, Messaging will send a advertising message to be displayed on a Rand" +
        "om bases.");
			this.checkBoxAdvertising.UseVisualStyleBackColor = true;
			this.checkBoxAdvertising.CheckedChanged += new System.EventHandler(this.checkBoxAdvertising_CheckedChanged);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(442, 453);
			this.Controls.Add(this.checkBoxAdvertising);
			this.Controls.Add(this.checkBoxCountDown);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.richTextBoxLog);
			this.Controls.Add(this.buttonInstantMSG);
			this.Controls.Add(this.checkBoxVixenControl);
			this.Controls.Add(this.buttonStopSequence);
			this.Controls.Add(this.WebServerStatus);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonStart);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(100, 100);
			this.MainMenuStrip = this.menuStrip1;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(460, 500);
			this.MinimumSize = new System.Drawing.Size(460, 500);
			this.Name = "FormMain";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Vixen Messaging";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.buttonStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStop)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Timer timerCheckTwilio;
		private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox buttonStart;
		private System.Windows.Forms.PictureBox buttonStop;
		private System.Windows.Forms.Button WebServerStatus;
		private System.Windows.Forms.Button buttonStopSequence;
        private System.Windows.Forms.Timer timerCheckVixenEnabled;
		private System.Windows.Forms.CheckBox checkBoxVixenControl;
		private System.Windows.Forms.RichTextBox richTextBoxLog;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItemFile;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportLogToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem twilioToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem messagingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem whiteBlackListsToolStripMenuItem;
		private System.Windows.Forms.Button buttonInstantMSG;
		private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
		private System.Windows.Forms.CheckBox checkBoxCountDown;
		private System.Windows.Forms.CheckBox checkBoxAdvertising;
    }
}

