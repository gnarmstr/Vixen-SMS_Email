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
			this.timerCheckMail = new System.Windows.Forms.Timer(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.WebServerStatus = new System.Windows.Forms.Button();
			this.checkBoxVixenControl = new System.Windows.Forms.CheckBox();
			this.SaveAll = new System.Windows.Forms.PictureBox();
			this.buttonTwilio = new System.Windows.Forms.Button();
			this.buttonSaveLog = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.buttonStart = new System.Windows.Forms.PictureBox();
			this.buttonStop = new System.Windows.Forms.PictureBox();
			this.buttonHelp = new System.Windows.Forms.PictureBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.buttonStopSequence = new System.Windows.Forms.Button();
			this.fileDialog = new System.Windows.Forms.OpenFileDialog();
			this.timerCheckVixenEnabled = new System.Windows.Forms.Timer(this.components);
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonWhite_BlackLists = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonTextSettings = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonInstantMSG = new System.Windows.Forms.Button();
			this.textBoxInstantMSG = new System.Windows.Forms.TextBox();
			this.buttonSettings = new System.Windows.Forms.Button();
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.label6 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonHelp)).BeginInit();
			this.SuspendLayout();
			// 
			// timerCheckMail
			// 
			this.timerCheckMail.Interval = 1000;
			this.timerCheckMail.Tick += new System.EventHandler(this.timerCheckMail_Tick);
			// 
			// toolTip1
			// 
			this.toolTip1.AutomaticDelay = 300;
			this.toolTip1.AutoPopDelay = 10000;
			this.toolTip1.InitialDelay = 300;
			this.toolTip1.ReshowDelay = 60;
			// 
			// WebServerStatus
			// 
			this.WebServerStatus.BackColor = System.Drawing.Color.OrangeRed;
			this.WebServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WebServerStatus.Location = new System.Drawing.Point(169, 548);
			this.WebServerStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.WebServerStatus.Name = "WebServerStatus";
			this.WebServerStatus.Size = new System.Drawing.Size(255, 34);
			this.WebServerStatus.TabIndex = 31;
			this.WebServerStatus.Text = "Vixen 3 Web Server is ENABLED";
			this.WebServerStatus.UseVisualStyleBackColor = false;
			// 
			// checkBoxVixenControl
			// 
			this.checkBoxVixenControl.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.checkBoxVixenControl.Location = new System.Drawing.Point(354, 120);
			this.checkBoxVixenControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxVixenControl.Name = "checkBoxVixenControl";
			this.checkBoxVixenControl.Size = new System.Drawing.Size(95, 77);
			this.checkBoxVixenControl.TabIndex = 68;
			this.checkBoxVixenControl.Text = "Enable Vixen 3 Control";
			this.checkBoxVixenControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.checkBoxVixenControl, resources.GetString("checkBoxVixenControl.ToolTip"));
			this.checkBoxVixenControl.UseVisualStyleBackColor = true;
			this.checkBoxVixenControl.CheckedChanged += new System.EventHandler(this.checkBoxVixenControl_CheckedChanged);
			// 
			// SaveAll
			// 
			this.SaveAll.Location = new System.Drawing.Point(210, 595);
			this.SaveAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.SaveAll.Name = "SaveAll";
			this.SaveAll.Size = new System.Drawing.Size(200, 40);
			this.SaveAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.SaveAll.TabIndex = 69;
			this.SaveAll.TabStop = false;
			this.SaveAll.Tag = "20";
			this.toolTip1.SetToolTip(this.SaveAll, "This will Save all settings and lists. ");
			this.SaveAll.Click += new System.EventHandler(this.SaveAll_Click);
			// 
			// buttonTwilio
			// 
			this.buttonTwilio.BackColor = System.Drawing.Color.Honeydew;
			this.buttonTwilio.Location = new System.Drawing.Point(49, 14);
			this.buttonTwilio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonTwilio.Name = "buttonTwilio";
			this.buttonTwilio.Size = new System.Drawing.Size(294, 39);
			this.buttonTwilio.TabIndex = 96;
			this.buttonTwilio.Text = "Twilio Settings";
			this.toolTip1.SetToolTip(this.buttonTwilio, "Enter Twilio settings.");
			this.buttonTwilio.UseVisualStyleBackColor = false;
			this.buttonTwilio.Click += new System.EventHandler(this.buttonTwilio_Click);
			this.buttonTwilio.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonTwilio.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// buttonSaveLog
			// 
			this.buttonSaveLog.BackColor = System.Drawing.Color.Honeydew;
			this.buttonSaveLog.Location = new System.Drawing.Point(10, 548);
			this.buttonSaveLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonSaveLog.Name = "buttonSaveLog";
			this.buttonSaveLog.Size = new System.Drawing.Size(108, 34);
			this.buttonSaveLog.TabIndex = 60;
			this.buttonSaveLog.Text = "Export Log";
			this.toolTip1.SetToolTip(this.buttonSaveLog, "Export the Log to a text file.");
			this.buttonSaveLog.UseVisualStyleBackColor = false;
			this.buttonSaveLog.Click += new System.EventHandler(this.buttonSaveLog_Click);
			this.buttonSaveLog.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonSaveLog.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// colorDialog1
			// 
			this.colorDialog1.AnyColor = true;
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.AddExtension = false;
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(374, 14);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(68, 60);
			this.buttonStart.TabIndex = 13;
			this.buttonStart.TabStop = false;
			this.buttonStart.Tag = "20";
			this.toolTip1.SetToolTip(this.buttonStart, "Starts checking Twilio for messages.");
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(374, 70);
			this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(68, 60);
			this.buttonStop.TabIndex = 14;
			this.buttonStop.TabStop = false;
			this.buttonStop.Tag = "21";
			this.toolTip1.SetToolTip(this.buttonStop, "Stops checking Twilio for messages.");
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// buttonHelp
			// 
			this.buttonHelp.Location = new System.Drawing.Point(397, 595);
			this.buttonHelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonHelp.Name = "buttonHelp";
			this.buttonHelp.Size = new System.Drawing.Size(44, 39);
			this.buttonHelp.TabIndex = 15;
			this.buttonHelp.TabStop = false;
			this.buttonHelp.Tag = "22";
			this.toolTip1.SetToolTip(this.buttonHelp, "Display help.");
			this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
			// 
			// buttonStopSequence
			// 
			this.buttonStopSequence.BackColor = System.Drawing.Color.Honeydew;
			this.buttonStopSequence.Location = new System.Drawing.Point(10, 595);
			this.buttonStopSequence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonStopSequence.Name = "buttonStopSequence";
			this.buttonStopSequence.Size = new System.Drawing.Size(175, 32);
			this.buttonStopSequence.TabIndex = 61;
			this.buttonStopSequence.Text = "Stop current message";
			this.toolTip1.SetToolTip(this.buttonStopSequence, "Stops current displayed message.");
			this.buttonStopSequence.UseVisualStyleBackColor = false;
			this.buttonStopSequence.Click += new System.EventHandler(this.buttonStopSequence_Click);
			this.buttonStopSequence.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonStopSequence.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// fileDialog
			// 
			this.fileDialog.FileName = "Select a File";
			this.fileDialog.Title = "Select a File";
			// 
			// timerCheckVixenEnabled
			// 
			this.timerCheckVixenEnabled.Interval = 500;
			this.timerCheckVixenEnabled.Tick += new System.EventHandler(this.timerCheckVixenEnabled_Tick);
			// 
			// fontDialog1
			// 
			this.fontDialog1.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(120, 187);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(151, 17);
			this.label5.TabIndex = 114;
			this.label5.Text = "OPTIONAL SETTINGS";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(22, 224);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 17);
			this.label3.TabIndex = 113;
			this.label3.Text = "4.";
			// 
			// buttonWhite_BlackLists
			// 
			this.buttonWhite_BlackLists.BackColor = System.Drawing.Color.Honeydew;
			this.buttonWhite_BlackLists.Location = new System.Drawing.Point(49, 213);
			this.buttonWhite_BlackLists.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonWhite_BlackLists.Name = "buttonWhite_BlackLists";
			this.buttonWhite_BlackLists.Size = new System.Drawing.Size(294, 39);
			this.buttonWhite_BlackLists.TabIndex = 112;
			this.buttonWhite_BlackLists.Text = "White/Black lists";
			this.toolTip1.SetToolTip(this.buttonWhite_BlackLists, "Update White list or Black list for words to be checked.");
			this.buttonWhite_BlackLists.UseVisualStyleBackColor = false;
			this.buttonWhite_BlackLists.Click += new System.EventHandler(this.buttonWhite_BlackLists_Click);
			this.buttonWhite_BlackLists.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonWhite_BlackLists.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(22, 125);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(20, 17);
			this.label4.TabIndex = 111;
			this.label4.Text = "3.";
			// 
			// buttonTextSettings
			// 
			this.buttonTextSettings.BackColor = System.Drawing.Color.Honeydew;
			this.buttonTextSettings.Location = new System.Drawing.Point(49, 114);
			this.buttonTextSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonTextSettings.Name = "buttonTextSettings";
			this.buttonTextSettings.Size = new System.Drawing.Size(294, 39);
			this.buttonTextSettings.TabIndex = 110;
			this.buttonTextSettings.Text = "Text Settings";
			this.toolTip1.SetToolTip(this.buttonTextSettings, "Enter Text settings.");
			this.buttonTextSettings.UseVisualStyleBackColor = false;
			this.buttonTextSettings.Click += new System.EventHandler(this.buttonTextSettings_Click);
			this.buttonTextSettings.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonTextSettings.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 74);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 17);
			this.label2.TabIndex = 109;
			this.label2.Text = "2.";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 17);
			this.label1.TabIndex = 108;
			this.label1.Text = "1.";
			// 
			// buttonInstantMSG
			// 
			this.buttonInstantMSG.BackColor = System.Drawing.Color.Honeydew;
			this.buttonInstantMSG.Location = new System.Drawing.Point(49, 271);
			this.buttonInstantMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonInstantMSG.Name = "buttonInstantMSG";
			this.buttonInstantMSG.Size = new System.Drawing.Size(294, 39);
			this.buttonInstantMSG.TabIndex = 107;
			this.buttonInstantMSG.Text = "Send Instant Message";
			this.toolTip1.SetToolTip(this.buttonInstantMSG, "Sends an instant message to your lights.");
			this.buttonInstantMSG.UseVisualStyleBackColor = false;
			this.buttonInstantMSG.Click += new System.EventHandler(this.buttonInstantMSG_Click);
			this.buttonInstantMSG.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonInstantMSG.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// textBoxInstantMSG
			// 
			this.textBoxInstantMSG.Location = new System.Drawing.Point(49, 313);
			this.textBoxInstantMSG.Name = "textBoxInstantMSG";
			this.textBoxInstantMSG.Size = new System.Drawing.Size(294, 22);
			this.textBoxInstantMSG.TabIndex = 106;
			this.toolTip1.SetToolTip(this.textBoxInstantMSG, "Enter message here when selecting Instant message.");
			// 
			// buttonSettings
			// 
			this.buttonSettings.BackColor = System.Drawing.Color.Honeydew;
			this.buttonSettings.Location = new System.Drawing.Point(49, 63);
			this.buttonSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Size = new System.Drawing.Size(294, 39);
			this.buttonSettings.TabIndex = 97;
			this.buttonSettings.Text = "Messaging Settings";
			this.toolTip1.SetToolTip(this.buttonSettings, "Enter messaging settings.");
			this.buttonSettings.UseVisualStyleBackColor = false;
			this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
			this.buttonSettings.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonSettings.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// richTextBoxLog
			// 
			this.richTextBoxLog.Location = new System.Drawing.Point(24, 375);
			this.richTextBoxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxLog.Name = "richTextBoxLog";
			this.richTextBoxLog.Size = new System.Drawing.Size(418, 163);
			this.richTextBoxLog.TabIndex = 1;
			this.richTextBoxLog.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(22, 347);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(32, 17);
			this.label6.TabIndex = 115;
			this.label6.Text = "Log";
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(452, 633);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.richTextBoxLog);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.buttonWhite_BlackLists);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.buttonTextSettings);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonInstantMSG);
			this.Controls.Add(this.textBoxInstantMSG);
			this.Controls.Add(this.buttonSettings);
			this.Controls.Add(this.buttonTwilio);
			this.Controls.Add(this.SaveAll);
			this.Controls.Add(this.checkBoxVixenControl);
			this.Controls.Add(this.buttonStopSequence);
			this.Controls.Add(this.WebServerStatus);
			this.Controls.Add(this.buttonSaveLog);
			this.Controls.Add(this.buttonHelp);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonStart);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(100, 100);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(470, 680);
			this.MinimumSize = new System.Drawing.Size(470, 680);
			this.Name = "FormMain";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Vixen Messaging - v3.3u2";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonHelp)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Timer timerCheckMail;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox buttonStart;
        private System.Windows.Forms.PictureBox buttonStop;
		private System.Windows.Forms.PictureBox buttonHelp;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button WebServerStatus;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button buttonStopSequence;
		private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Timer timerCheckVixenEnabled;
		private System.Windows.Forms.CheckBox checkBoxVixenControl;
		private System.Windows.Forms.PictureBox SaveAll;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button buttonWhite_BlackLists;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonTextSettings;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonInstantMSG;
		private System.Windows.Forms.TextBox textBoxInstantMSG;
		private System.Windows.Forms.Button buttonSettings;
		private System.Windows.Forms.Button buttonTwilio;
		private System.Windows.Forms.RichTextBox richTextBoxLog;
		private System.Windows.Forms.Label label6;
    }
}

