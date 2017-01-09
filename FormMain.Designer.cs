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
			this.RandomColourSelection = new System.Windows.Forms.GroupBox();
			this.labelColour10 = new System.Windows.Forms.Label();
			this.labelColour9 = new System.Windows.Forms.Label();
			this.labelColour8 = new System.Windows.Forms.Label();
			this.labelColour7 = new System.Windows.Forms.Label();
			this.labelColour6 = new System.Windows.Forms.Label();
			this.labelColour5 = new System.Windows.Forms.Label();
			this.labelColour4 = new System.Windows.Forms.Label();
			this.labelColour3 = new System.Windows.Forms.Label();
			this.labelColour2 = new System.Windows.Forms.Label();
			this.labelColour1 = new System.Windows.Forms.Label();
			this.TextColor1 = new System.Windows.Forms.Button();
			this.TextColor10 = new System.Windows.Forms.Button();
			this.TextColor8 = new System.Windows.Forms.Button();
			this.TextColor9 = new System.Windows.Forms.Button();
			this.TextColor2 = new System.Windows.Forms.Button();
			this.TextColor3 = new System.Windows.Forms.Button();
			this.TextColor7 = new System.Windows.Forms.Button();
			this.TextColor4 = new System.Windows.Forms.Button();
			this.TextColor6 = new System.Windows.Forms.Button();
			this.TextColor5 = new System.Windows.Forms.Button();
			this.WebServerStatus = new System.Windows.Forms.Button();
			this.checkBoxLocal = new System.Windows.Forms.CheckBox();
			this.checkBoxTwilio = new System.Windows.Forms.CheckBox();
			this.label66 = new System.Windows.Forms.Label();
			this.label88 = new System.Windows.Forms.Label();
			this.numericUpDownMaxWords = new System.Windows.Forms.NumericUpDown();
			this.checkBoxVixenControl = new System.Windows.Forms.CheckBox();
			this.SaveAll = new System.Windows.Forms.PictureBox();
			this.checkBoxLocalRandom = new System.Windows.Forms.CheckBox();
			this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
			this.label87 = new System.Windows.Forms.Label();
			this.label71 = new System.Windows.Forms.Label();
			this.checkBoxBlacklist = new System.Windows.Forms.CheckBox();
			this.checkBoxWhitelist = new System.Windows.Forms.CheckBox();
			this.label36 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.comboBoxPlayMode = new System.Windows.Forms.ComboBox();
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageMain = new System.Windows.Forms.TabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonInstantMSG = new System.Windows.Forms.Button();
			this.textBoxInstantMSG = new System.Windows.Forms.TextBox();
			this.groupBoxPlayOptions = new System.Windows.Forms.GroupBox();
			this.label74 = new System.Windows.Forms.Label();
			this.numericUpDownIntervalMsgs = new System.Windows.Forms.NumericUpDown();
			this.tabPageTextSetting = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.richTextBoxLog1 = new System.Windows.Forms.RichTextBox();
			this.groupBoxSeqSettings = new System.Windows.Forms.GroupBox();
			this.checkBoxCenterText = new System.Windows.Forms.CheckBox();
			this.checkBoxCenterStop = new System.Windows.Forms.CheckBox();
			this.label98 = new System.Windows.Forms.Label();
			this.incomingMessageColourOption = new System.Windows.Forms.ComboBox();
			this.textBoxFontSize = new System.Windows.Forms.TextBox();
			this.buttonFont = new System.Windows.Forms.Button();
			this.textBoxFont = new System.Windows.Forms.TextBox();
			this.comboBoxString = new System.Windows.Forms.ComboBox();
			this.comboBoxTextDirection = new System.Windows.Forms.ComboBox();
			this.trackBarTextPosition = new System.Windows.Forms.TrackBar();
			this.label44 = new System.Windows.Forms.Label();
			this.trackBarTextSpeed = new System.Windows.Forms.TrackBar();
			this.label21 = new System.Windows.Forms.Label();
			this.localMsgs = new System.Windows.Forms.TabPage();
			this.groupBoxMessages = new System.Windows.Forms.GroupBox();
			this.groupBox8 = new System.Windows.Forms.GroupBox();
			this.label96 = new System.Windows.Forms.Label();
			this.dateCountDown = new System.Windows.Forms.DateTimePicker();
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
			this.trackBarIntensity = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.RandomColourSelection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWords)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).BeginInit();
			this.tabControlMain.SuspendLayout();
			this.tabPageMain.SuspendLayout();
			this.groupBoxPlayOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMsgs)).BeginInit();
			this.tabPageTextSetting.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBoxSeqSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextPosition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextSpeed)).BeginInit();
			this.localMsgs.SuspendLayout();
			this.groupBoxMessages.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.tabPageWordLists.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveBlacklist)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveWhitelist)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonHelp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarIntensity)).BeginInit();
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
			// RandomColourSelection
			// 
			this.RandomColourSelection.Controls.Add(this.labelColour10);
			this.RandomColourSelection.Controls.Add(this.labelColour9);
			this.RandomColourSelection.Controls.Add(this.labelColour8);
			this.RandomColourSelection.Controls.Add(this.labelColour7);
			this.RandomColourSelection.Controls.Add(this.labelColour6);
			this.RandomColourSelection.Controls.Add(this.labelColour5);
			this.RandomColourSelection.Controls.Add(this.labelColour4);
			this.RandomColourSelection.Controls.Add(this.labelColour3);
			this.RandomColourSelection.Controls.Add(this.labelColour2);
			this.RandomColourSelection.Controls.Add(this.labelColour1);
			this.RandomColourSelection.Controls.Add(this.TextColor1);
			this.RandomColourSelection.Controls.Add(this.TextColor10);
			this.RandomColourSelection.Controls.Add(this.TextColor8);
			this.RandomColourSelection.Controls.Add(this.TextColor9);
			this.RandomColourSelection.Controls.Add(this.TextColor2);
			this.RandomColourSelection.Controls.Add(this.TextColor3);
			this.RandomColourSelection.Controls.Add(this.TextColor7);
			this.RandomColourSelection.Controls.Add(this.TextColor4);
			this.RandomColourSelection.Controls.Add(this.TextColor6);
			this.RandomColourSelection.Controls.Add(this.TextColor5);
			this.RandomColourSelection.Location = new System.Drawing.Point(13, 248);
			this.RandomColourSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RandomColourSelection.Name = "RandomColourSelection";
			this.RandomColourSelection.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RandomColourSelection.Size = new System.Drawing.Size(598, 74);
			this.RandomColourSelection.TabIndex = 9;
			this.RandomColourSelection.TabStop = false;
			this.RandomColourSelection.Text = "Colors";
			this.toolTip1.SetToolTip(this.RandomColourSelection, "Select a color to edit. Number idicates colours that are enabled and will change " +
        "depending on selected Colour Option..");
			// 
			// labelColour10
			// 
			this.labelColour10.AutoSize = true;
			this.labelColour10.Location = new System.Drawing.Point(544, 18);
			this.labelColour10.Name = "labelColour10";
			this.labelColour10.Size = new System.Drawing.Size(24, 17);
			this.labelColour10.TabIndex = 76;
			this.labelColour10.Text = "10";
			this.labelColour10.Visible = false;
			// 
			// labelColour9
			// 
			this.labelColour9.AutoSize = true;
			this.labelColour9.Location = new System.Drawing.Point(486, 18);
			this.labelColour9.Name = "labelColour9";
			this.labelColour9.Size = new System.Drawing.Size(16, 17);
			this.labelColour9.TabIndex = 75;
			this.labelColour9.Text = "9";
			this.labelColour9.Visible = false;
			// 
			// labelColour8
			// 
			this.labelColour8.AutoSize = true;
			this.labelColour8.Location = new System.Drawing.Point(428, 18);
			this.labelColour8.Name = "labelColour8";
			this.labelColour8.Size = new System.Drawing.Size(16, 17);
			this.labelColour8.TabIndex = 74;
			this.labelColour8.Text = "8";
			this.labelColour8.Visible = false;
			// 
			// labelColour7
			// 
			this.labelColour7.AutoSize = true;
			this.labelColour7.Location = new System.Drawing.Point(372, 18);
			this.labelColour7.Name = "labelColour7";
			this.labelColour7.Size = new System.Drawing.Size(16, 17);
			this.labelColour7.TabIndex = 73;
			this.labelColour7.Text = "7";
			this.labelColour7.Visible = false;
			// 
			// labelColour6
			// 
			this.labelColour6.AutoSize = true;
			this.labelColour6.Location = new System.Drawing.Point(313, 18);
			this.labelColour6.Name = "labelColour6";
			this.labelColour6.Size = new System.Drawing.Size(16, 17);
			this.labelColour6.TabIndex = 72;
			this.labelColour6.Text = "6";
			this.labelColour6.Visible = false;
			// 
			// labelColour5
			// 
			this.labelColour5.AutoSize = true;
			this.labelColour5.Location = new System.Drawing.Point(256, 18);
			this.labelColour5.Name = "labelColour5";
			this.labelColour5.Size = new System.Drawing.Size(16, 17);
			this.labelColour5.TabIndex = 71;
			this.labelColour5.Text = "5";
			this.labelColour5.Visible = false;
			// 
			// labelColour4
			// 
			this.labelColour4.AutoSize = true;
			this.labelColour4.Location = new System.Drawing.Point(199, 18);
			this.labelColour4.Name = "labelColour4";
			this.labelColour4.Size = new System.Drawing.Size(16, 17);
			this.labelColour4.TabIndex = 70;
			this.labelColour4.Text = "4";
			this.labelColour4.Visible = false;
			// 
			// labelColour3
			// 
			this.labelColour3.AutoSize = true;
			this.labelColour3.Location = new System.Drawing.Point(143, 18);
			this.labelColour3.Name = "labelColour3";
			this.labelColour3.Size = new System.Drawing.Size(16, 17);
			this.labelColour3.TabIndex = 69;
			this.labelColour3.Text = "3";
			this.labelColour3.Visible = false;
			// 
			// labelColour2
			// 
			this.labelColour2.AutoSize = true;
			this.labelColour2.Location = new System.Drawing.Point(90, 18);
			this.labelColour2.Name = "labelColour2";
			this.labelColour2.Size = new System.Drawing.Size(16, 17);
			this.labelColour2.TabIndex = 68;
			this.labelColour2.Text = "2";
			this.labelColour2.Visible = false;
			// 
			// labelColour1
			// 
			this.labelColour1.AutoSize = true;
			this.labelColour1.Location = new System.Drawing.Point(35, 18);
			this.labelColour1.Name = "labelColour1";
			this.labelColour1.Size = new System.Drawing.Size(16, 17);
			this.labelColour1.TabIndex = 67;
			this.labelColour1.Text = "1";
			this.labelColour1.Visible = false;
			// 
			// TextColor1
			// 
			this.TextColor1.BackColor = System.Drawing.Color.Red;
			this.TextColor1.Location = new System.Drawing.Point(24, 38);
			this.TextColor1.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor1.Name = "TextColor1";
			this.TextColor1.Size = new System.Drawing.Size(36, 32);
			this.TextColor1.TabIndex = 10;
			this.toolTip1.SetToolTip(this.TextColor1, "Select a colour to edit.");
			this.TextColor1.UseVisualStyleBackColor = false;
			this.TextColor1.Click += new System.EventHandler(this.TextColor1_Click);
			// 
			// TextColor10
			// 
			this.TextColor10.BackColor = System.Drawing.Color.DodgerBlue;
			this.TextColor10.Location = new System.Drawing.Point(534, 38);
			this.TextColor10.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor10.Name = "TextColor10";
			this.TextColor10.Size = new System.Drawing.Size(36, 32);
			this.TextColor10.TabIndex = 19;
			this.toolTip1.SetToolTip(this.TextColor10, "Select a colour to edit.");
			this.TextColor10.UseVisualStyleBackColor = false;
			this.TextColor10.Click += new System.EventHandler(this.TextColor10_Click);
			// 
			// TextColor8
			// 
			this.TextColor8.BackColor = System.Drawing.Color.Maroon;
			this.TextColor8.Location = new System.Drawing.Point(419, 38);
			this.TextColor8.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor8.Name = "TextColor8";
			this.TextColor8.Size = new System.Drawing.Size(36, 32);
			this.TextColor8.TabIndex = 17;
			this.toolTip1.SetToolTip(this.TextColor8, "Select a colour to edit.");
			this.TextColor8.UseVisualStyleBackColor = false;
			this.TextColor8.Click += new System.EventHandler(this.TextColor8_Click);
			// 
			// TextColor9
			// 
			this.TextColor9.BackColor = System.Drawing.Color.Brown;
			this.TextColor9.Location = new System.Drawing.Point(476, 38);
			this.TextColor9.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor9.Name = "TextColor9";
			this.TextColor9.Size = new System.Drawing.Size(36, 32);
			this.TextColor9.TabIndex = 18;
			this.toolTip1.SetToolTip(this.TextColor9, "Select a colour to edit.");
			this.TextColor9.UseVisualStyleBackColor = false;
			this.TextColor9.Click += new System.EventHandler(this.TextColor9_Click);
			// 
			// TextColor2
			// 
			this.TextColor2.BackColor = System.Drawing.Color.Lime;
			this.TextColor2.Location = new System.Drawing.Point(79, 38);
			this.TextColor2.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor2.Name = "TextColor2";
			this.TextColor2.Size = new System.Drawing.Size(36, 32);
			this.TextColor2.TabIndex = 11;
			this.toolTip1.SetToolTip(this.TextColor2, "Select a colour to edit.");
			this.TextColor2.UseVisualStyleBackColor = false;
			this.TextColor2.Click += new System.EventHandler(this.TextColor2_Click);
			// 
			// TextColor3
			// 
			this.TextColor3.BackColor = System.Drawing.Color.Blue;
			this.TextColor3.Location = new System.Drawing.Point(132, 38);
			this.TextColor3.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor3.Name = "TextColor3";
			this.TextColor3.Size = new System.Drawing.Size(36, 32);
			this.TextColor3.TabIndex = 12;
			this.toolTip1.SetToolTip(this.TextColor3, "Select a colour to edit.");
			this.TextColor3.UseVisualStyleBackColor = false;
			this.TextColor3.Click += new System.EventHandler(this.TextColor3_Click);
			// 
			// TextColor7
			// 
			this.TextColor7.BackColor = System.Drawing.Color.LightBlue;
			this.TextColor7.Location = new System.Drawing.Point(362, 38);
			this.TextColor7.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor7.Name = "TextColor7";
			this.TextColor7.Size = new System.Drawing.Size(36, 32);
			this.TextColor7.TabIndex = 16;
			this.toolTip1.SetToolTip(this.TextColor7, "Select a colour to edit.");
			this.TextColor7.UseVisualStyleBackColor = false;
			this.TextColor7.Click += new System.EventHandler(this.TextColor7_Click);
			// 
			// TextColor4
			// 
			this.TextColor4.BackColor = System.Drawing.Color.Yellow;
			this.TextColor4.Location = new System.Drawing.Point(188, 38);
			this.TextColor4.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor4.Name = "TextColor4";
			this.TextColor4.Size = new System.Drawing.Size(36, 32);
			this.TextColor4.TabIndex = 13;
			this.toolTip1.SetToolTip(this.TextColor4, "Select a colour to edit.");
			this.TextColor4.UseVisualStyleBackColor = false;
			this.TextColor4.Click += new System.EventHandler(this.TextColor4_Click);
			// 
			// TextColor6
			// 
			this.TextColor6.BackColor = System.Drawing.Color.Pink;
			this.TextColor6.Location = new System.Drawing.Point(304, 38);
			this.TextColor6.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor6.Name = "TextColor6";
			this.TextColor6.Size = new System.Drawing.Size(36, 32);
			this.TextColor6.TabIndex = 15;
			this.toolTip1.SetToolTip(this.TextColor6, "Select a colour to edit.");
			this.TextColor6.UseVisualStyleBackColor = false;
			this.TextColor6.Click += new System.EventHandler(this.TextColor6_Click);
			// 
			// TextColor5
			// 
			this.TextColor5.BackColor = System.Drawing.Color.Orange;
			this.TextColor5.Location = new System.Drawing.Point(246, 38);
			this.TextColor5.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor5.Name = "TextColor5";
			this.TextColor5.Size = new System.Drawing.Size(36, 32);
			this.TextColor5.TabIndex = 14;
			this.toolTip1.SetToolTip(this.TextColor5, "Select a colour to edit.");
			this.TextColor5.UseVisualStyleBackColor = false;
			this.TextColor5.Click += new System.EventHandler(this.TextColor5_Click);
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
			// label88
			// 
			this.label88.AutoSize = true;
			this.label88.Location = new System.Drawing.Point(397, 71);
			this.label88.Name = "label88";
			this.label88.Size = new System.Drawing.Size(82, 17);
			this.label88.TabIndex = 66;
			this.label88.Text = "Max Words:";
			this.toolTip1.SetToolTip(this.label88, "Enter the Maximum number of words in a message or 0 for unlimited.\r\nWill send rep" +
        "ly message to sender informing them that their message was too long.");
			// 
			// numericUpDownMaxWords
			// 
			this.numericUpDownMaxWords.Location = new System.Drawing.Point(483, 70);
			this.numericUpDownMaxWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.numericUpDownMaxWords.Name = "numericUpDownMaxWords";
			this.numericUpDownMaxWords.Size = new System.Drawing.Size(64, 22);
			this.numericUpDownMaxWords.TabIndex = 5;
			this.toolTip1.SetToolTip(this.numericUpDownMaxWords, "Enter 0 for unlimited words.");
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
			// label87
			// 
			this.label87.Location = new System.Drawing.Point(20, 34);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(132, 23);
			this.label87.TabIndex = 65;
			this.label87.Text = "CountDown Date:";
			this.label87.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.toolTip1.SetToolTip(this.label87, "Add the word COUNTDOWN to your message to display the number fo days to the selec" +
        "ted date.");
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
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Location = new System.Drawing.Point(296, 31);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(119, 17);
			this.label36.TabIndex = 55;
			this.label36.Text = "String Orienation:";
			this.toolTip1.SetToolTip(this.label36, "Set this as per the requirement in Vixen");
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Location = new System.Drawing.Point(219, 71);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(68, 17);
			this.label45.TabIndex = 51;
			this.label45.Text = "Direction:";
			this.toolTip1.SetToolTip(this.label45, "Text direction");
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
			this.tabControlMain.Controls.Add(this.tabPageTextSetting);
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
			// tabPageTextSetting
			// 
			this.tabPageTextSetting.BackColor = System.Drawing.Color.Azure;
			this.tabPageTextSetting.Controls.Add(this.groupBox4);
			this.tabPageTextSetting.Controls.Add(this.groupBoxSeqSettings);
			this.tabPageTextSetting.Location = new System.Drawing.Point(4, 25);
			this.tabPageTextSetting.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageTextSetting.Name = "tabPageTextSetting";
			this.tabPageTextSetting.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageTextSetting.Size = new System.Drawing.Size(793, 707);
			this.tabPageTextSetting.TabIndex = 5;
			this.tabPageTextSetting.Tag = "30";
			this.tabPageTextSetting.Text = "Text Settings";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.richTextBoxLog1);
			this.groupBox4.Location = new System.Drawing.Point(3, 368);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox4.Size = new System.Drawing.Size(783, 337);
			this.groupBox4.TabIndex = 58;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Log";
			// 
			// richTextBoxLog1
			// 
			this.richTextBoxLog1.Location = new System.Drawing.Point(2, 49);
			this.richTextBoxLog1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxLog1.Name = "richTextBoxLog1";
			this.richTextBoxLog1.Size = new System.Drawing.Size(773, 258);
			this.richTextBoxLog1.TabIndex = 2;
			this.richTextBoxLog1.Text = "";
			// 
			// groupBoxSeqSettings
			// 
			this.groupBoxSeqSettings.Controls.Add(this.trackBarIntensity);
			this.groupBoxSeqSettings.Controls.Add(this.label3);
			this.groupBoxSeqSettings.Controls.Add(this.checkBoxCenterText);
			this.groupBoxSeqSettings.Controls.Add(this.checkBoxCenterStop);
			this.groupBoxSeqSettings.Controls.Add(this.label98);
			this.groupBoxSeqSettings.Controls.Add(this.incomingMessageColourOption);
			this.groupBoxSeqSettings.Controls.Add(this.label88);
			this.groupBoxSeqSettings.Controls.Add(this.numericUpDownMaxWords);
			this.groupBoxSeqSettings.Controls.Add(this.textBoxFontSize);
			this.groupBoxSeqSettings.Controls.Add(this.buttonFont);
			this.groupBoxSeqSettings.Controls.Add(this.textBoxFont);
			this.groupBoxSeqSettings.Controls.Add(this.comboBoxString);
			this.groupBoxSeqSettings.Controls.Add(this.label36);
			this.groupBoxSeqSettings.Controls.Add(this.comboBoxTextDirection);
			this.groupBoxSeqSettings.Controls.Add(this.label45);
			this.groupBoxSeqSettings.Controls.Add(this.trackBarTextPosition);
			this.groupBoxSeqSettings.Controls.Add(this.label44);
			this.groupBoxSeqSettings.Controls.Add(this.trackBarTextSpeed);
			this.groupBoxSeqSettings.Controls.Add(this.label21);
			this.groupBoxSeqSettings.Controls.Add(this.RandomColourSelection);
			this.groupBoxSeqSettings.Location = new System.Drawing.Point(5, 12);
			this.groupBoxSeqSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxSeqSettings.Name = "groupBoxSeqSettings";
			this.groupBoxSeqSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxSeqSettings.Size = new System.Drawing.Size(780, 337);
			this.groupBoxSeqSettings.TabIndex = 1;
			this.groupBoxSeqSettings.TabStop = false;
			this.groupBoxSeqSettings.Text = "Incoming Message / Text Settings";
			// 
			// checkBoxCenterText
			// 
			this.checkBoxCenterText.AutoSize = true;
			this.checkBoxCenterText.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxCenterText.Location = new System.Drawing.Point(19, 120);
			this.checkBoxCenterText.Name = "checkBoxCenterText";
			this.checkBoxCenterText.Size = new System.Drawing.Size(103, 21);
			this.checkBoxCenterText.TabIndex = 101;
			this.checkBoxCenterText.Text = "Center Text";
			this.checkBoxCenterText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxCenterText.UseVisualStyleBackColor = true;
			// 
			// checkBoxCenterStop
			// 
			this.checkBoxCenterStop.AutoSize = true;
			this.checkBoxCenterStop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxCenterStop.Location = new System.Drawing.Point(17, 83);
			this.checkBoxCenterStop.Name = "checkBoxCenterStop";
			this.checkBoxCenterStop.Size = new System.Drawing.Size(105, 21);
			this.checkBoxCenterStop.TabIndex = 100;
			this.checkBoxCenterStop.Text = "Center Stop";
			this.checkBoxCenterStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxCenterStop.UseVisualStyleBackColor = true;
			// 
			// label98
			// 
			this.label98.AutoSize = true;
			this.label98.Location = new System.Drawing.Point(6, 31);
			this.label98.Name = "label98";
			this.label98.Size = new System.Drawing.Size(99, 17);
			this.label98.TabIndex = 99;
			this.label98.Text = "Colour Option:";
			// 
			// incomingMessageColourOption
			// 
			this.incomingMessageColourOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.incomingMessageColourOption.FormattingEnabled = true;
			this.incomingMessageColourOption.Items.AddRange(new object[] {
            "Single",
            "Multi",
            "Random"});
			this.incomingMessageColourOption.Location = new System.Drawing.Point(111, 29);
			this.incomingMessageColourOption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.incomingMessageColourOption.Name = "incomingMessageColourOption";
			this.incomingMessageColourOption.Size = new System.Drawing.Size(159, 24);
			this.incomingMessageColourOption.TabIndex = 0;
			this.incomingMessageColourOption.SelectedIndexChanged += new System.EventHandler(this.incomingMessageColourOption_SelectedIndexChanged);
			// 
			// textBoxFontSize
			// 
			this.textBoxFontSize.BackColor = System.Drawing.Color.White;
			this.textBoxFontSize.Enabled = false;
			this.textBoxFontSize.Location = new System.Drawing.Point(644, 98);
			this.textBoxFontSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxFontSize.Name = "textBoxFontSize";
			this.textBoxFontSize.Size = new System.Drawing.Size(77, 22);
			this.textBoxFontSize.TabIndex = 59;
			this.textBoxFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// buttonFont
			// 
			this.buttonFont.Location = new System.Drawing.Point(612, 27);
			this.buttonFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonFont.Name = "buttonFont";
			this.buttonFont.Size = new System.Drawing.Size(132, 26);
			this.buttonFont.TabIndex = 2;
			this.buttonFont.Text = "Font Selection";
			this.buttonFont.UseVisualStyleBackColor = true;
			this.buttonFont.Click += new System.EventHandler(this.buttonFont_Click);
			// 
			// textBoxFont
			// 
			this.textBoxFont.BackColor = System.Drawing.Color.White;
			this.textBoxFont.Enabled = false;
			this.textBoxFont.ForeColor = System.Drawing.SystemColors.InfoText;
			this.textBoxFont.Location = new System.Drawing.Point(596, 69);
			this.textBoxFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxFont.Name = "textBoxFont";
			this.textBoxFont.Size = new System.Drawing.Size(167, 22);
			this.textBoxFont.TabIndex = 57;
			this.textBoxFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// comboBoxString
			// 
			this.comboBoxString.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxString.FormattingEnabled = true;
			this.comboBoxString.Items.AddRange(new object[] {
            "Horizontal",
            "Vertical"});
			this.comboBoxString.Location = new System.Drawing.Point(433, 29);
			this.comboBoxString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxString.Name = "comboBoxString";
			this.comboBoxString.Size = new System.Drawing.Size(114, 24);
			this.comboBoxString.TabIndex = 1;
			// 
			// comboBoxTextDirection
			// 
			this.comboBoxTextDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTextDirection.FormattingEnabled = true;
			this.comboBoxTextDirection.Items.AddRange(new object[] {
            "Left",
            "Right",
            "Up",
            "Down",
            "None",
            "Random"});
			this.comboBoxTextDirection.Location = new System.Drawing.Point(291, 69);
			this.comboBoxTextDirection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxTextDirection.Name = "comboBoxTextDirection";
			this.comboBoxTextDirection.Size = new System.Drawing.Size(82, 24);
			this.comboBoxTextDirection.TabIndex = 4;
			// 
			// trackBarTextPosition
			// 
			this.trackBarTextPosition.AutoSize = false;
			this.trackBarTextPosition.Location = new System.Drawing.Point(100, 159);
			this.trackBarTextPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarTextPosition.Maximum = 100;
			this.trackBarTextPosition.Minimum = -100;
			this.trackBarTextPosition.Name = "trackBarTextPosition";
			this.trackBarTextPosition.Size = new System.Drawing.Size(300, 32);
			this.trackBarTextPosition.TabIndex = 8;
			this.trackBarTextPosition.Scroll += new System.EventHandler(this.trackBarTextPosition_Scroll);
			this.trackBarTextPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextPosition_MouseDown);
			this.trackBarTextPosition.MouseHover += new System.EventHandler(this.trackBarTextPosition_MouseHover);
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(10, 166);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(62, 17);
			this.label44.TabIndex = 50;
			this.label44.Text = "Position:";
			// 
			// trackBarTextSpeed
			// 
			this.trackBarTextSpeed.AutoSize = false;
			this.trackBarTextSpeed.Location = new System.Drawing.Point(499, 159);
			this.trackBarTextSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarTextSpeed.Maximum = 20;
			this.trackBarTextSpeed.Minimum = 1;
			this.trackBarTextSpeed.Name = "trackBarTextSpeed";
			this.trackBarTextSpeed.Size = new System.Drawing.Size(276, 32);
			this.trackBarTextSpeed.TabIndex = 9;
			this.trackBarTextSpeed.Value = 1;
			this.trackBarTextSpeed.Scroll += new System.EventHandler(this.trackBarTextSpeed_Scroll);
			this.trackBarTextSpeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextSpeed_MouseDown);
			this.trackBarTextSpeed.MouseHover += new System.EventHandler(this.trackBarTextSpeed_MouseHover);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(413, 166);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(70, 17);
			this.label21.TabIndex = 48;
			this.label21.Text = "Iterations:";
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
			this.groupBoxMessages.Controls.Add(this.dateCountDown);
			this.groupBoxMessages.Controls.Add(this.label87);
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
			// dateCountDown
			// 
			this.dateCountDown.CalendarForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.dateCountDown.CalendarMonthBackground = System.Drawing.SystemColors.InactiveCaption;
			this.dateCountDown.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.dateCountDown.CustomFormat = "";
			this.dateCountDown.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateCountDown.Location = new System.Drawing.Point(168, 31);
			this.dateCountDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dateCountDown.Name = "dateCountDown";
			this.dateCountDown.Size = new System.Drawing.Size(123, 22);
			this.dateCountDown.TabIndex = 0;
			this.dateCountDown.Value = new System.DateTime(2017, 12, 25, 0, 0, 0, 0);
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
			// trackBarIntensity
			// 
			this.trackBarIntensity.AutoSize = false;
			this.trackBarIntensity.Location = new System.Drawing.Point(100, 212);
			this.trackBarIntensity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarIntensity.Maximum = 100;
			this.trackBarIntensity.Minimum = 1;
			this.trackBarIntensity.Name = "trackBarIntensity";
			this.trackBarIntensity.Size = new System.Drawing.Size(300, 32);
			this.trackBarIntensity.TabIndex = 102;
			this.trackBarIntensity.Value = 1;
			this.trackBarIntensity.Scroll += new System.EventHandler(this.trackBarIntensity_Scroll);
			this.trackBarIntensity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextIntensity_MouseDown);
			this.trackBarIntensity.MouseHover += new System.EventHandler(this.trackBarTextIntensity_MouseHover);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 219);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 17);
			this.label3.TabIndex = 103;
			this.label3.Text = "Intensity:";
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
			this.RandomColourSelection.ResumeLayout(false);
			this.RandomColourSelection.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWords)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).EndInit();
			this.tabControlMain.ResumeLayout(false);
			this.tabPageMain.ResumeLayout(false);
			this.tabPageMain.PerformLayout();
			this.groupBoxPlayOptions.ResumeLayout(false);
			this.groupBoxPlayOptions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMsgs)).EndInit();
			this.tabPageTextSetting.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBoxSeqSettings.ResumeLayout(false);
			this.groupBoxSeqSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextPosition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextSpeed)).EndInit();
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
			((System.ComponentModel.ISupportInitialize)(this.trackBarIntensity)).EndInit();
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
        private System.Windows.Forms.TabPage tabPageTextSetting;
		private System.Windows.Forms.GroupBox groupBoxSeqSettings;
        private System.Windows.Forms.ComboBox comboBoxTextDirection;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TrackBar trackBarTextPosition;
        private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TrackBar trackBarTextSpeed;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox RandomColourSelection;
        private System.Windows.Forms.Button TextColor1;
        private System.Windows.Forms.Button TextColor10;
        private System.Windows.Forms.Button TextColor8;
        private System.Windows.Forms.Button TextColor9;
        private System.Windows.Forms.Button TextColor2;
        private System.Windows.Forms.Button TextColor3;
        private System.Windows.Forms.Button TextColor7;
        private System.Windows.Forms.Button TextColor4;
        private System.Windows.Forms.Button TextColor6;
		private System.Windows.Forms.Button TextColor5;
        private System.Windows.Forms.ComboBox comboBoxString;
		private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button WebServerStatus;
		private System.Windows.Forms.TextBox textBoxFont;
        private System.Windows.Forms.Button buttonFont;
        private System.Windows.Forms.TextBox textBoxFontSize;
        private System.Windows.Forms.PictureBox pictureBoxSaveBlacklist;
		private System.Windows.Forms.PictureBox pictureBoxSaveWhitelist;
		private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
		private System.Windows.Forms.RichTextBox richTextBoxLog1;
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
        private System.Windows.Forms.Label label88;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxWords;
        private System.Windows.Forms.Timer timerCheckVixenEnabled;
		private System.Windows.Forms.CheckBox checkBoxVixenControl;
		private System.Windows.Forms.PictureBox SaveAll;
		private System.Windows.Forms.TabPage localMsgs;
		private System.Windows.Forms.GroupBox groupBoxMessages;
		private System.Windows.Forms.CheckBox checkBoxLocalRandom;
		private System.Windows.Forms.RichTextBox richTextBoxMessage;
		private System.Windows.Forms.DateTimePicker dateCountDown;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label96;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label labelColour4;
		private System.Windows.Forms.Label labelColour3;
		private System.Windows.Forms.Label labelColour2;
		private System.Windows.Forms.Label labelColour1;
		private System.Windows.Forms.Label label98;
		private System.Windows.Forms.ComboBox incomingMessageColourOption;
		private System.Windows.Forms.Label labelColour10;
		private System.Windows.Forms.Label labelColour9;
		private System.Windows.Forms.Label labelColour8;
		private System.Windows.Forms.Label labelColour7;
		private System.Windows.Forms.Label labelColour6;
		private System.Windows.Forms.Label labelColour5;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.Button buttonSettings;
		private System.Windows.Forms.Button buttonInstantMSG;
		private System.Windows.Forms.TextBox textBoxInstantMSG;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxCenterText;
		private System.Windows.Forms.CheckBox checkBoxCenterStop;
		private System.Windows.Forms.TrackBar trackBarIntensity;
		private System.Windows.Forms.Label label3;
    }
}

