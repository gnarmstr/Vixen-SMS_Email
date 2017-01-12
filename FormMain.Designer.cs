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
			this.buttonSettings = new System.Windows.Forms.Button();
			this.buttonTwilio = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.timerCheckMail = new System.Windows.Forms.Timer(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label14 = new System.Windows.Forms.Label();
			this.richTextBoxWhitelist = new System.Windows.Forms.RichTextBox();
			this.richTextBoxBlacklist = new System.Windows.Forms.RichTextBox();
			this.WebServerStatus = new System.Windows.Forms.Button();
			this.checkBoxLocal = new System.Windows.Forms.CheckBox();
			this.checkBoxTwilio = new System.Windows.Forms.CheckBox();
			this.label66 = new System.Windows.Forms.Label();
			this.checkBoxVixenControl = new System.Windows.Forms.CheckBox();
			this.SaveAll = new System.Windows.Forms.PictureBox();
			this.checkBoxLocalRandom = new System.Windows.Forms.CheckBox();
			this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
			this.label71 = new System.Windows.Forms.Label();
			this.checkBoxBlacklist = new System.Windows.Forms.CheckBox();
			this.checkBoxWhitelist = new System.Windows.Forms.CheckBox();
			this.comboBoxPlayMode = new System.Windows.Forms.ComboBox();
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageMain = new System.Windows.Forms.TabPage();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonTextSettings = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonInstantMSG = new System.Windows.Forms.Button();
			this.textBoxInstantMSG = new System.Windows.Forms.TextBox();
			this.groupBoxPlayOptions = new System.Windows.Forms.GroupBox();
			this.label74 = new System.Windows.Forms.Label();
			this.numericUpDownIntervalMsgs = new System.Windows.Forms.NumericUpDown();
			this.localMsgs = new System.Windows.Forms.TabPage();
			this.groupBoxMessages = new System.Windows.Forms.GroupBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.label96 = new System.Windows.Forms.Label();
			this.tabPageWordLists = new System.Windows.Forms.TabPage();
			this.pictureBoxSaveBlacklist = new System.Windows.Forms.PictureBox();
			this.pictureBoxSaveWhitelist = new System.Windows.Forms.PictureBox();
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
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).BeginInit();
			this.tabControlMain.SuspendLayout();
			this.tabPageMain.SuspendLayout();
			this.groupBoxPlayOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMsgs)).BeginInit();
			this.localMsgs.SuspendLayout();
			this.groupBoxMessages.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.tabPageWordLists.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveBlacklist)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveWhitelist)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonHelp)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonSettings
			// 
			this.buttonSettings.BackColor = System.Drawing.Color.Honeydew;
			this.buttonSettings.Location = new System.Drawing.Point(243, 84);
			this.buttonSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonSettings.Name = "buttonSettings";
			this.buttonSettings.Size = new System.Drawing.Size(294, 39);
			this.buttonSettings.TabIndex = 9;
			this.buttonSettings.Text = "Messaging Settings";
			this.buttonSettings.UseVisualStyleBackColor = false;
			this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
			this.buttonSettings.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonSettings.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// buttonTwilio
			// 
			this.buttonTwilio.BackColor = System.Drawing.Color.Honeydew;
			this.buttonTwilio.Location = new System.Drawing.Point(243, 27);
			this.buttonTwilio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonTwilio.Name = "buttonTwilio";
			this.buttonTwilio.Size = new System.Drawing.Size(294, 39);
			this.buttonTwilio.TabIndex = 8;
			this.buttonTwilio.Text = "Twilio Settings";
			this.toolTip1.SetToolTip(this.buttonTwilio, "Only need to select this if you have a Twilio account that would be used to accep" +
        "t SMS\'s.");
			this.buttonTwilio.UseVisualStyleBackColor = false;
			this.buttonTwilio.Click += new System.EventHandler(this.buttonTwilio_Click);
			this.buttonTwilio.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonTwilio.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.richTextBoxLog);
			this.groupBox2.Location = new System.Drawing.Point(11, 466);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox2.Size = new System.Drawing.Size(772, 236);
			this.groupBox2.TabIndex = 30;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Log";
			// 
			// richTextBoxLog
			// 
			this.richTextBoxLog.Location = new System.Drawing.Point(5, 20);
			this.richTextBoxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxLog.Name = "richTextBoxLog";
			this.richTextBoxLog.Size = new System.Drawing.Size(762, 212);
			this.richTextBoxLog.TabIndex = 1;
			this.richTextBoxLog.Text = "";
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
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(20, 440);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(238, 17);
			this.label14.TabIndex = 20;
			this.label14.Text = "Select required Word list to be used:";
			this.toolTip1.SetToolTip(this.label14, "To add words to the lists please select the Word Lists tab above.");
			// 
			// richTextBoxWhitelist
			// 
			this.richTextBoxWhitelist.Location = new System.Drawing.Point(390, 5);
			this.richTextBoxWhitelist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxWhitelist.Name = "richTextBoxWhitelist";
			this.richTextBoxWhitelist.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.richTextBoxWhitelist.Size = new System.Drawing.Size(191, 690);
			this.richTextBoxWhitelist.TabIndex = 15;
			this.richTextBoxWhitelist.Text = "";
			this.toolTip1.SetToolTip(this.richTextBoxWhitelist, "Can edit directly in the text box and then save. Not required to use non Alphanum" +
        "eric characters.");
			// 
			// richTextBoxBlacklist
			// 
			this.richTextBoxBlacklist.Location = new System.Drawing.Point(9, 5);
			this.richTextBoxBlacklist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxBlacklist.Name = "richTextBoxBlacklist";
			this.richTextBoxBlacklist.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.richTextBoxBlacklist.Size = new System.Drawing.Size(191, 690);
			this.richTextBoxBlacklist.TabIndex = 5;
			this.richTextBoxBlacklist.Text = "";
			this.toolTip1.SetToolTip(this.richTextBoxBlacklist, "Can edit directly in the text box and then save. Not required to use non Alphanum" +
        "eric characters.");
			// 
			// WebServerStatus
			// 
			this.WebServerStatus.BackColor = System.Drawing.Color.OrangeRed;
			this.WebServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.WebServerStatus.Location = new System.Drawing.Point(190, 752);
			this.WebServerStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.WebServerStatus.Name = "WebServerStatus";
			this.WebServerStatus.Size = new System.Drawing.Size(255, 34);
			this.WebServerStatus.TabIndex = 31;
			this.WebServerStatus.Text = "Vixen 3 Web Server is ENABLED";
			this.toolTip1.SetToolTip(this.WebServerStatus, "Click to Enable Vixen Web Server");
			this.WebServerStatus.UseVisualStyleBackColor = false;
			// 
			// checkBoxLocal
			// 
			this.checkBoxLocal.AutoSize = true;
			this.checkBoxLocal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxLocal.Location = new System.Drawing.Point(207, 29);
			this.checkBoxLocal.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxLocal.Name = "checkBoxLocal";
			this.checkBoxLocal.Size = new System.Drawing.Size(64, 21);
			this.checkBoxLocal.TabIndex = 10;
			this.checkBoxLocal.Tag = "4";
			this.checkBoxLocal.Text = "Local";
			this.toolTip1.SetToolTip(this.checkBoxLocal, "Select to display Locally created messages.");
			this.checkBoxLocal.UseVisualStyleBackColor = true;
			// 
			// checkBoxTwilio
			// 
			this.checkBoxTwilio.AutoSize = true;
			this.checkBoxTwilio.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxTwilio.Location = new System.Drawing.Point(287, 29);
			this.checkBoxTwilio.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxTwilio.Name = "checkBoxTwilio";
			this.checkBoxTwilio.Size = new System.Drawing.Size(108, 21);
			this.checkBoxTwilio.TabIndex = 11;
			this.checkBoxTwilio.Tag = "4";
			this.checkBoxTwilio.Text = "Twilio (SMS)";
			this.toolTip1.SetToolTip(this.checkBoxTwilio, "Select to retrieve messages from Twilio (SMS account).");
			this.checkBoxTwilio.UseVisualStyleBackColor = true;
			// 
			// label66
			// 
			this.label66.AutoSize = true;
			this.label66.Location = new System.Drawing.Point(533, 29);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(78, 17);
			this.label66.TabIndex = 59;
			this.label66.Text = "Play Mode:";
			this.toolTip1.SetToolTip(this.label66, "Changes between Selected Play options either Randomly or in a Sequential order.");
			// 
			// checkBoxVixenControl
			// 
			this.checkBoxVixenControl.AutoSize = true;
			this.checkBoxVixenControl.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxVixenControl.Location = new System.Drawing.Point(498, 817);
			this.checkBoxVixenControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxVixenControl.Name = "checkBoxVixenControl";
			this.checkBoxVixenControl.Size = new System.Drawing.Size(173, 21);
			this.checkBoxVixenControl.TabIndex = 68;
			this.checkBoxVixenControl.Text = "Enable Vixen 3 Control";
			this.toolTip1.SetToolTip(this.checkBoxVixenControl, resources.GetString("checkBoxVixenControl.ToolTip"));
			this.checkBoxVixenControl.UseVisualStyleBackColor = true;
			this.checkBoxVixenControl.CheckedChanged += new System.EventHandler(this.checkBoxVixenControl_CheckedChanged);
			// 
			// SaveAll
			// 
			this.SaveAll.Location = new System.Drawing.Point(300, 800);
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
			// checkBoxLocalRandom
			// 
			this.checkBoxLocalRandom.AutoSize = true;
			this.checkBoxLocalRandom.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxLocalRandom.Location = new System.Drawing.Point(330, 34);
			this.checkBoxLocalRandom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxLocalRandom.Name = "checkBoxLocalRandom";
			this.checkBoxLocalRandom.Size = new System.Drawing.Size(203, 21);
			this.checkBoxLocalRandom.TabIndex = 1;
			this.checkBoxLocalRandom.Text = "Play Local Msgs Randomly:";
			this.checkBoxLocalRandom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.checkBoxLocalRandom, "Select this to display random Local messages. Ensure messages that you want displ" +
        "ayed have been enabled.");
			this.checkBoxLocalRandom.UseVisualStyleBackColor = true;
			// 
			// richTextBoxMessage
			// 
			this.richTextBoxMessage.Location = new System.Drawing.Point(5, 20);
			this.richTextBoxMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxMessage.Name = "richTextBoxMessage";
			this.richTextBoxMessage.Size = new System.Drawing.Size(768, 242);
			this.richTextBoxMessage.TabIndex = 60;
			this.richTextBoxMessage.Text = "";
			this.toolTip1.SetToolTip(this.richTextBoxMessage, resources.GetString("richTextBoxMessage.ToolTip"));
			// 
			// label71
			// 
			this.label71.AutoSize = true;
			this.label71.Location = new System.Drawing.Point(530, 420);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(183, 17);
			this.label71.TabIndex = 62;
			this.label71.Text = "Interval between Messages:";
			this.toolTip1.SetToolTip(this.label71, "Time between messages, may need to increase to 1 or 2 secs as a minimum.");
			// 
			// checkBoxBlacklist
			// 
			this.checkBoxBlacklist.AutoSize = true;
			this.checkBoxBlacklist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxBlacklist.Checked = true;
			this.checkBoxBlacklist.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxBlacklist.Location = new System.Drawing.Point(261, 440);
			this.checkBoxBlacklist.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxBlacklist.Name = "checkBoxBlacklist";
			this.checkBoxBlacklist.Size = new System.Drawing.Size(81, 21);
			this.checkBoxBlacklist.TabIndex = 13;
			this.checkBoxBlacklist.Tag = "3";
			this.checkBoxBlacklist.Text = "Blacklist";
			this.toolTip1.SetToolTip(this.checkBoxBlacklist, "Checks for dirty words against a Blacklist and rejects any that match.");
			this.checkBoxBlacklist.UseVisualStyleBackColor = true;
			this.checkBoxBlacklist.CheckedChanged += new System.EventHandler(this.checkBoxBlacklist_CheckedChanged);
			// 
			// checkBoxWhitelist
			// 
			this.checkBoxWhitelist.AutoSize = true;
			this.checkBoxWhitelist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxWhitelist.Location = new System.Drawing.Point(365, 440);
			this.checkBoxWhitelist.Margin = new System.Windows.Forms.Padding(4);
			this.checkBoxWhitelist.Name = "checkBoxWhitelist";
			this.checkBoxWhitelist.Size = new System.Drawing.Size(83, 21);
			this.checkBoxWhitelist.TabIndex = 14;
			this.checkBoxWhitelist.Tag = "4";
			this.checkBoxWhitelist.Text = "Whitelist";
			this.toolTip1.SetToolTip(this.checkBoxWhitelist, "Will only display incoming messages if all words are in the whitelist.");
			this.checkBoxWhitelist.UseVisualStyleBackColor = true;
			this.checkBoxWhitelist.CheckedChanged += new System.EventHandler(this.checkBoxWhitelist_CheckedChanged);
			// 
			// comboBoxPlayMode
			// 
			this.comboBoxPlayMode.BackColor = System.Drawing.SystemColors.Window;
			this.comboBoxPlayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxPlayMode.FormattingEnabled = true;
			this.comboBoxPlayMode.Items.AddRange(new object[] {
            "Random",
            "Sequential"});
			this.comboBoxPlayMode.Location = new System.Drawing.Point(615, 26);
			this.comboBoxPlayMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxPlayMode.Name = "comboBoxPlayMode";
			this.comboBoxPlayMode.Size = new System.Drawing.Size(155, 24);
			this.comboBoxPlayMode.TabIndex = 12;
			this.comboBoxPlayMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlayMode_SelectedIndexChanged);
			// 
			// tabControlMain
			// 
			this.tabControlMain.Controls.Add(this.tabPageMain);
			this.tabControlMain.Controls.Add(this.localMsgs);
			this.tabControlMain.Controls.Add(this.tabPageWordLists);
			this.tabControlMain.Location = new System.Drawing.Point(-2, 10);
			this.tabControlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.Size = new System.Drawing.Size(801, 736);
			this.tabControlMain.TabIndex = 5;
			// 
			// tabPageMain
			// 
			this.tabPageMain.BackColor = System.Drawing.Color.Azure;
			this.tabPageMain.Controls.Add(this.label4);
			this.tabPageMain.Controls.Add(this.buttonTextSettings);
			this.tabPageMain.Controls.Add(this.label2);
			this.tabPageMain.Controls.Add(this.label1);
			this.tabPageMain.Controls.Add(this.buttonInstantMSG);
			this.tabPageMain.Controls.Add(this.textBoxInstantMSG);
			this.tabPageMain.Controls.Add(this.buttonSettings);
			this.tabPageMain.Controls.Add(this.groupBoxPlayOptions);
			this.tabPageMain.Controls.Add(this.buttonTwilio);
			this.tabPageMain.Controls.Add(this.label74);
			this.tabPageMain.Controls.Add(this.numericUpDownIntervalMsgs);
			this.tabPageMain.Controls.Add(this.label71);
			this.tabPageMain.Controls.Add(this.label14);
			this.tabPageMain.Controls.Add(this.checkBoxBlacklist);
			this.tabPageMain.Controls.Add(this.checkBoxWhitelist);
			this.tabPageMain.Controls.Add(this.groupBox2);
			this.tabPageMain.Location = new System.Drawing.Point(4, 25);
			this.tabPageMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageMain.Name = "tabPageMain";
			this.tabPageMain.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageMain.Size = new System.Drawing.Size(793, 707);
			this.tabPageMain.TabIndex = 0;
			this.tabPageMain.Tag = "2";
			this.tabPageMain.Text = "Main";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(205, 151);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(20, 17);
			this.label4.TabIndex = 73;
			this.label4.Text = "2.";
			// 
			// buttonTextSettings
			// 
			this.buttonTextSettings.BackColor = System.Drawing.Color.Honeydew;
			this.buttonTextSettings.Location = new System.Drawing.Point(243, 140);
			this.buttonTextSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonTextSettings.Name = "buttonTextSettings";
			this.buttonTextSettings.Size = new System.Drawing.Size(294, 39);
			this.buttonTextSettings.TabIndex = 72;
			this.buttonTextSettings.Text = "Text Settings";
			this.buttonTextSettings.UseVisualStyleBackColor = false;
			this.buttonTextSettings.Click += new System.EventHandler(this.buttonTextSettings_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(205, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 17);
			this.label2.TabIndex = 71;
			this.label2.Text = "2.";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(205, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 17);
			this.label1.TabIndex = 70;
			this.label1.Text = "1.";
			// 
			// buttonInstantMSG
			// 
			this.buttonInstantMSG.BackColor = System.Drawing.Color.Honeydew;
			this.buttonInstantMSG.Location = new System.Drawing.Point(484, 285);
			this.buttonInstantMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonInstantMSG.Name = "buttonInstantMSG";
			this.buttonInstantMSG.Size = new System.Drawing.Size(294, 39);
			this.buttonInstantMSG.TabIndex = 69;
			this.buttonInstantMSG.Text = "Send Instant Message";
			this.buttonInstantMSG.UseVisualStyleBackColor = false;
			this.buttonInstantMSG.Click += new System.EventHandler(this.buttonInstantMSG_Click);
			this.buttonInstantMSG.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonInstantMSG.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// textBoxInstantMSG
			// 
			this.textBoxInstantMSG.Location = new System.Drawing.Point(23, 293);
			this.textBoxInstantMSG.Name = "textBoxInstantMSG";
			this.textBoxInstantMSG.Size = new System.Drawing.Size(442, 22);
			this.textBoxInstantMSG.TabIndex = 68;
			// 
			// groupBoxPlayOptions
			// 
			this.groupBoxPlayOptions.Controls.Add(this.comboBoxPlayMode);
			this.groupBoxPlayOptions.Controls.Add(this.checkBoxTwilio);
			this.groupBoxPlayOptions.Controls.Add(this.checkBoxLocal);
			this.groupBoxPlayOptions.Controls.Add(this.label66);
			this.groupBoxPlayOptions.Location = new System.Drawing.Point(11, 350);
			this.groupBoxPlayOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxPlayOptions.Name = "groupBoxPlayOptions";
			this.groupBoxPlayOptions.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxPlayOptions.Size = new System.Drawing.Size(775, 59);
			this.groupBoxPlayOptions.TabIndex = 67;
			this.groupBoxPlayOptions.TabStop = false;
			this.groupBoxPlayOptions.Text = "Play Options";
			// 
			// label74
			// 
			this.label74.AutoSize = true;
			this.label74.Location = new System.Drawing.Point(654, 442);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(32, 17);
			this.label74.TabIndex = 63;
			this.label74.Text = "Sec";
			// 
			// numericUpDownIntervalMsgs
			// 
			this.numericUpDownIntervalMsgs.Location = new System.Drawing.Point(580, 439);
			this.numericUpDownIntervalMsgs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.numericUpDownIntervalMsgs.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.numericUpDownIntervalMsgs.Name = "numericUpDownIntervalMsgs";
			this.numericUpDownIntervalMsgs.Size = new System.Drawing.Size(64, 22);
			this.numericUpDownIntervalMsgs.TabIndex = 15;
			// 
			// localMsgs
			// 
			this.localMsgs.BackColor = System.Drawing.Color.Azure;
			this.localMsgs.Controls.Add(this.groupBoxMessages);
			this.localMsgs.Location = new System.Drawing.Point(4, 25);
			this.localMsgs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.localMsgs.Name = "localMsgs";
			this.localMsgs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.localMsgs.Size = new System.Drawing.Size(793, 707);
			this.localMsgs.TabIndex = 7;
			this.localMsgs.Text = "Local Messages";
			// 
			// groupBoxMessages
			// 
			this.groupBoxMessages.Controls.Add(this.groupBox8);
			this.groupBoxMessages.Controls.Add(this.label96);
			this.groupBoxMessages.Controls.Add(this.checkBoxLocalRandom);
			this.groupBoxMessages.Location = new System.Drawing.Point(3, 5);
			this.groupBoxMessages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxMessages.Name = "groupBoxMessages";
			this.groupBoxMessages.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxMessages.Size = new System.Drawing.Size(788, 700);
			this.groupBoxMessages.TabIndex = 0;
			this.groupBoxMessages.TabStop = false;
			this.groupBoxMessages.Text = "Local Messages";
			// 
			// groupBox8
			// 
			this.groupBox8.Controls.Add(this.richTextBoxMessage);
			this.groupBox8.Location = new System.Drawing.Point(3, 434);
			this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox8.Name = "groupBox8";
			this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox8.Size = new System.Drawing.Size(778, 265);
			this.groupBox8.TabIndex = 93;
			this.groupBox8.TabStop = false;
			this.groupBox8.Text = "Standard Messages";
			// 
			// label96
			// 
			this.label96.Location = new System.Drawing.Point(12, 387);
			this.label96.Name = "label96";
			this.label96.Size = new System.Drawing.Size(758, 37);
			this.label96.TabIndex = 92;
			this.label96.Text = "Enter a list of messages in the list box below and/or enter custom messages above" +
    ".\r\nEnter the word COUNTDOWN anywhere to display the number of days to the select" +
    "ed Countdown date above.";
			// 
			// tabPageWordLists
			// 
			this.tabPageWordLists.BackColor = System.Drawing.Color.Azure;
			this.tabPageWordLists.Controls.Add(this.pictureBoxSaveBlacklist);
			this.tabPageWordLists.Controls.Add(this.pictureBoxSaveWhitelist);
			this.tabPageWordLists.Controls.Add(this.richTextBoxWhitelist);
			this.tabPageWordLists.Controls.Add(this.richTextBoxBlacklist);
			this.tabPageWordLists.Location = new System.Drawing.Point(4, 25);
			this.tabPageWordLists.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageWordLists.Name = "tabPageWordLists";
			this.tabPageWordLists.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageWordLists.Size = new System.Drawing.Size(793, 707);
			this.tabPageWordLists.TabIndex = 4;
			this.tabPageWordLists.Text = "Word Lists";
			// 
			// pictureBoxSaveBlacklist
			// 
			this.pictureBoxSaveBlacklist.Location = new System.Drawing.Point(211, 327);
			this.pictureBoxSaveBlacklist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBoxSaveBlacklist.Name = "pictureBoxSaveBlacklist";
			this.pictureBoxSaveBlacklist.Size = new System.Drawing.Size(133, 80);
			this.pictureBoxSaveBlacklist.TabIndex = 18;
			this.pictureBoxSaveBlacklist.TabStop = false;
			this.pictureBoxSaveBlacklist.Tag = "0";
			this.pictureBoxSaveBlacklist.Click += new System.EventHandler(this.pictureBoxSaveBlacklist_Click);
			// 
			// pictureBoxSaveWhitelist
			// 
			this.pictureBoxSaveWhitelist.Location = new System.Drawing.Point(597, 327);
			this.pictureBoxSaveWhitelist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBoxSaveWhitelist.Name = "pictureBoxSaveWhitelist";
			this.pictureBoxSaveWhitelist.Size = new System.Drawing.Size(133, 80);
			this.pictureBoxSaveWhitelist.TabIndex = 17;
			this.pictureBoxSaveWhitelist.TabStop = false;
			this.pictureBoxSaveWhitelist.Tag = "1";
			this.pictureBoxSaveWhitelist.Click += new System.EventHandler(this.pictureBoxSaveWhitelist_Click);
			// 
			// buttonSaveLog
			// 
			this.buttonSaveLog.BackColor = System.Drawing.Color.Honeydew;
			this.buttonSaveLog.Location = new System.Drawing.Point(11, 754);
			this.buttonSaveLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonSaveLog.Name = "buttonSaveLog";
			this.buttonSaveLog.Size = new System.Drawing.Size(108, 34);
			this.buttonSaveLog.TabIndex = 60;
			this.buttonSaveLog.Text = "Export Log";
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
			this.buttonStart.Location = new System.Drawing.Point(509, 754);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(68, 60);
			this.buttonStart.TabIndex = 13;
			this.buttonStart.TabStop = false;
			this.buttonStart.Tag = "20";
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(611, 754);
			this.buttonStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(67, 60);
			this.buttonStop.TabIndex = 14;
			this.buttonStop.TabStop = false;
			this.buttonStop.Tag = "21";
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			// 
			// buttonHelp
			// 
			this.buttonHelp.Location = new System.Drawing.Point(722, 779);
			this.buttonHelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonHelp.Name = "buttonHelp";
			this.buttonHelp.Size = new System.Drawing.Size(44, 39);
			this.buttonHelp.TabIndex = 15;
			this.buttonHelp.TabStop = false;
			this.buttonHelp.Tag = "22";
			this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
			// 
			// buttonStopSequence
			// 
			this.buttonStopSequence.BackColor = System.Drawing.Color.Honeydew;
			this.buttonStopSequence.Location = new System.Drawing.Point(11, 802);
			this.buttonStopSequence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonStopSequence.Name = "buttonStopSequence";
			this.buttonStopSequence.Size = new System.Drawing.Size(260, 32);
			this.buttonStopSequence.TabIndex = 61;
			this.buttonStopSequence.Text = "Stop Currently Running Sequence";
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
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(802, 835);
			this.Controls.Add(this.SaveAll);
			this.Controls.Add(this.checkBoxVixenControl);
			this.Controls.Add(this.buttonStopSequence);
			this.Controls.Add(this.WebServerStatus);
			this.Controls.Add(this.buttonSaveLog);
			this.Controls.Add(this.buttonHelp);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.tabControlMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Location = new System.Drawing.Point(100, 100);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(820, 882);
			this.MinimumSize = new System.Drawing.Size(820, 882);
			this.Name = "FormMain";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Vixen Messaging - v3.3u2";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).EndInit();
			this.tabControlMain.ResumeLayout(false);
			this.tabPageMain.ResumeLayout(false);
			this.tabPageMain.PerformLayout();
			this.groupBoxPlayOptions.ResumeLayout(false);
			this.groupBoxPlayOptions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMsgs)).EndInit();
			this.localMsgs.ResumeLayout(false);
			this.groupBoxMessages.ResumeLayout(false);
			this.groupBoxMessages.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.tabPageWordLists.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveBlacklist)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveWhitelist)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonHelp)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timerCheckMail;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControlMain;
		private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBoxBlacklist;
		private System.Windows.Forms.CheckBox checkBoxWhitelist;
        private System.Windows.Forms.TabPage tabPageWordLists;
        private System.Windows.Forms.RichTextBox richTextBoxWhitelist;
		private System.Windows.Forms.RichTextBox richTextBoxBlacklist;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox buttonStart;
        private System.Windows.Forms.PictureBox buttonStop;
		private System.Windows.Forms.PictureBox buttonHelp;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button WebServerStatus;
        private System.Windows.Forms.PictureBox pictureBoxSaveBlacklist;
		private System.Windows.Forms.PictureBox pictureBoxSaveWhitelist;
        private System.Windows.Forms.Label label66;
		private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button buttonStopSequence;
		private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.NumericUpDown numericUpDownIntervalMsgs;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Button buttonTwilio;
        private System.Windows.Forms.GroupBox groupBoxPlayOptions;
		private System.Windows.Forms.ComboBox comboBoxPlayMode;
        private System.Windows.Forms.CheckBox checkBoxTwilio;
		private System.Windows.Forms.CheckBox checkBoxLocal;
        private System.Windows.Forms.Timer timerCheckVixenEnabled;
		private System.Windows.Forms.CheckBox checkBoxVixenControl;
		private System.Windows.Forms.PictureBox SaveAll;
		private System.Windows.Forms.TabPage localMsgs;
		private System.Windows.Forms.GroupBox groupBoxMessages;
		private System.Windows.Forms.CheckBox checkBoxLocalRandom;
		private System.Windows.Forms.RichTextBox richTextBoxMessage;
		private System.Windows.Forms.Label label96;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.Button buttonSettings;
		private System.Windows.Forms.Button buttonInstantMSG;
		private System.Windows.Forms.TextBox textBoxInstantMSG;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonTextSettings;
    }
}

