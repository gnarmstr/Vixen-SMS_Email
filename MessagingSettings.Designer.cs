namespace Vixen_Messaging
{
	partial class MessagingSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessagingSettings));
			this.ok = new System.Windows.Forms.PictureBox();
			this.Cancel = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label9 = new System.Windows.Forms.Label();
			this.label100 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label87 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxReturnBannedMSG = new System.Windows.Forms.TextBox();
			this.textBoxGroupName = new System.Windows.Forms.TextBox();
			this.buttonGetVixenData = new System.Windows.Forms.Button();
			this.textBoxReturnWarningMSG = new System.Windows.Forms.TextBox();
			this.textBoxReturnSuccessMSG = new System.Windows.Forms.TextBox();
			this.dateCountDown = new System.Windows.Forms.DateTimePicker();
			this.label14 = new System.Windows.Forms.Label();
			this.comboBoxBlack_Whitelist = new System.Windows.Forms.ComboBox();
			this.numericUpDownIntervalMsgs = new System.Windows.Forms.NumericUpDown();
			this.label71 = new System.Windows.Forms.Label();
			this.textBoxCountDownMSG = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBoxVixenFolder = new System.Windows.Forms.TextBox();
			this.textBoxNodeId = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxOutputSequence = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxSequenceTemplate = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxVixenServer = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label74 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBoxAdvertisingMSG = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.trackBarRandomAdvetisingSensitivity = new System.Windows.Forms.TrackBar();
			this.label44 = new System.Windows.Forms.Label();
			this.trackBarRandomCountDownSensitivity = new System.Windows.Forms.TrackBar();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMsgs)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomAdvetisingSensitivity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomCountDownSensitivity)).BeginInit();
			this.SuspendLayout();
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(552, 754);
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
			this.Cancel.Location = new System.Drawing.Point(628, 754);
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
			this.label9.Location = new System.Drawing.Point(10, 35);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(182, 34);
			this.label9.TabIndex = 7;
			this.label9.Text = "Banned:";
			this.toolTip1.SetToolTip(this.label9, "Enter a message that will be sent to the audiance member that sent the inappropia" +
        "te words that they have been banned.");
			// 
			// label100
			// 
			this.label100.AutoSize = true;
			this.label100.Location = new System.Drawing.Point(10, 30);
			this.label100.Name = "label100";
			this.label100.Size = new System.Drawing.Size(93, 17);
			this.label100.TabIndex = 89;
			this.label100.Text = "Group Name:";
			this.toolTip1.SetToolTip(this.label100, "Enter your Matrix/Megatree group name that you will be sending messages to.");
			// 
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(10, 64);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(101, 17);
			this.label32.TabIndex = 10;
			this.label32.Text = "Group NodeId:";
			this.toolTip1.SetToolTip(this.label32, "The Node ID of the Group used to Display the Text. This must be set for the softw" +
        "are to work.");
			// 
			// label87
			// 
			this.label87.Location = new System.Drawing.Point(5, 66);
			this.label87.Name = "label87";
			this.label87.Size = new System.Drawing.Size(132, 23);
			this.label87.TabIndex = 67;
			this.label87.Text = "CountDown Date:";
			this.label87.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.toolTip1.SetToolTip(this.label87, "Add the word COUNTDOWN to your message to display the number fo days to the selec" +
        "ted date.");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 83);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(185, 42);
			this.label1.TabIndex = 92;
			this.label1.Text = "When Message Displayed:";
			this.toolTip1.SetToolTip(this.label1, "Enter a message that will be sent back to the audiance member after their message" +
        " is displayed..");
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 130);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(186, 42);
			this.label2.TabIndex = 94;
			this.label2.Text = "Warning when inappropriate word received";
			this.toolTip1.SetToolTip(this.label2, "Enter a message that will be sent to the audiance member an inappropiate word has" +
        " been recieved, first and only warning.");
			// 
			// textBoxReturnBannedMSG
			// 
			this.textBoxReturnBannedMSG.Location = new System.Drawing.Point(206, 27);
			this.textBoxReturnBannedMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxReturnBannedMSG.Multiline = true;
			this.textBoxReturnBannedMSG.Name = "textBoxReturnBannedMSG";
			this.textBoxReturnBannedMSG.Size = new System.Drawing.Size(486, 42);
			this.textBoxReturnBannedMSG.TabIndex = 4;
			this.toolTip1.SetToolTip(this.textBoxReturnBannedMSG, "Enter a message that will be sent to the audiance member that sent the inappropia" +
        "te words that they have been banned.");
			this.textBoxReturnBannedMSG.TextChanged += new System.EventHandler(this.textBoxReturnBannedMSG_TextChanged);
			// 
			// textBoxGroupName
			// 
			this.textBoxGroupName.Location = new System.Drawing.Point(143, 27);
			this.textBoxGroupName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxGroupName.Name = "textBoxGroupName";
			this.textBoxGroupName.Size = new System.Drawing.Size(273, 22);
			this.textBoxGroupName.TabIndex = 90;
			this.toolTip1.SetToolTip(this.textBoxGroupName, "Enter your Matrix/Megatree group name that you will be sending messages to.");
			this.textBoxGroupName.TextChanged += new System.EventHandler(this.textBoxReturnBannedMSG_TextChanged);
			// 
			// buttonGetVixenData
			// 
			this.buttonGetVixenData.BackColor = System.Drawing.Color.Honeydew;
			this.buttonGetVixenData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.buttonGetVixenData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonGetVixenData.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.buttonGetVixenData.Location = new System.Drawing.Point(470, 21);
			this.buttonGetVixenData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonGetVixenData.Name = "buttonGetVixenData";
			this.buttonGetVixenData.Size = new System.Drawing.Size(200, 32);
			this.buttonGetVixenData.TabIndex = 11;
			this.buttonGetVixenData.Text = "Get Vixen Data Settings";
			this.toolTip1.SetToolTip(this.buttonGetVixenData, "ENter the Group Name and select Get Vixen data to retrieve all Vixen settings.");
			this.buttonGetVixenData.UseVisualStyleBackColor = false;
			this.buttonGetVixenData.Click += new System.EventHandler(this.buttonGetVixenData_Click);
			this.buttonGetVixenData.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonGetVixenData.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// textBoxReturnWarningMSG
			// 
			this.textBoxReturnWarningMSG.Location = new System.Drawing.Point(206, 127);
			this.textBoxReturnWarningMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxReturnWarningMSG.Multiline = true;
			this.textBoxReturnWarningMSG.Name = "textBoxReturnWarningMSG";
			this.textBoxReturnWarningMSG.Size = new System.Drawing.Size(485, 42);
			this.textBoxReturnWarningMSG.TabIndex = 93;
			this.toolTip1.SetToolTip(this.textBoxReturnWarningMSG, "Enter a message that will be sent to the audiance member when an inappropiate wor" +
        "d has been recieved, first and only warning.");
			this.textBoxReturnWarningMSG.TextChanged += new System.EventHandler(this.textBoxReturnBannedMSG_TextChanged);
			// 
			// textBoxReturnSuccessMSG
			// 
			this.textBoxReturnSuccessMSG.Location = new System.Drawing.Point(206, 77);
			this.textBoxReturnSuccessMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxReturnSuccessMSG.Multiline = true;
			this.textBoxReturnSuccessMSG.Name = "textBoxReturnSuccessMSG";
			this.textBoxReturnSuccessMSG.Size = new System.Drawing.Size(485, 42);
			this.textBoxReturnSuccessMSG.TabIndex = 91;
			this.toolTip1.SetToolTip(this.textBoxReturnSuccessMSG, "Enter a message that will be sent to the audiance member that thier message will " +
        "be displayed soon. Leave blank for no reply.");
			this.textBoxReturnSuccessMSG.TextChanged += new System.EventHandler(this.textBoxReturnBannedMSG_TextChanged);
			// 
			// dateCountDown
			// 
			this.dateCountDown.CustomFormat = "";
			this.dateCountDown.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateCountDown.Location = new System.Drawing.Point(162, 66);
			this.dateCountDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dateCountDown.Name = "dateCountDown";
			this.dateCountDown.Size = new System.Drawing.Size(145, 22);
			this.dateCountDown.TabIndex = 66;
			this.toolTip1.SetToolTip(this.dateCountDown, "Enter the date to count down to, for example 25/12/17, christmas day.");
			this.dateCountDown.Value = new System.DateTime(2015, 12, 25, 0, 0, 0, 0);
			this.dateCountDown.ValueChanged += new System.EventHandler(this.numericUpDownIntervalMsgs_ValueChanged);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(17, 103);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(238, 17);
			this.label14.TabIndex = 104;
			this.label14.Text = "Select required Word list to be used:";
			this.toolTip1.SetToolTip(this.label14, "To add words to the lists please select the Word Lists tab above.");
			// 
			// comboBoxBlack_Whitelist
			// 
			this.comboBoxBlack_Whitelist.FormattingEnabled = true;
			this.comboBoxBlack_Whitelist.Items.AddRange(new object[] {
            "Blacklist",
            "Whitelist"});
			this.comboBoxBlack_Whitelist.Location = new System.Drawing.Point(278, 103);
			this.comboBoxBlack_Whitelist.Name = "comboBoxBlack_Whitelist";
			this.comboBoxBlack_Whitelist.Size = new System.Drawing.Size(127, 24);
			this.comboBoxBlack_Whitelist.TabIndex = 105;
			this.toolTip1.SetToolTip(this.comboBoxBlack_Whitelist, "Select to use either the White list or Black list.");
			this.comboBoxBlack_Whitelist.SelectedIndexChanged += new System.EventHandler(this.comboBoxBlack_Whitelist_SelectedIndexChanged);
			// 
			// numericUpDownIntervalMsgs
			// 
			this.numericUpDownIntervalMsgs.Location = new System.Drawing.Point(470, 54);
			this.numericUpDownIntervalMsgs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.numericUpDownIntervalMsgs.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
			this.numericUpDownIntervalMsgs.Name = "numericUpDownIntervalMsgs";
			this.numericUpDownIntervalMsgs.Size = new System.Drawing.Size(64, 22);
			this.numericUpDownIntervalMsgs.TabIndex = 106;
			this.toolTip1.SetToolTip(this.numericUpDownIntervalMsgs, "Sets the time interval between message retrieval.");
			this.numericUpDownIntervalMsgs.ValueChanged += new System.EventHandler(this.numericUpDownIntervalMsgs_ValueChanged);
			// 
			// label71
			// 
			this.label71.AutoSize = true;
			this.label71.Location = new System.Drawing.Point(420, 35);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(183, 17);
			this.label71.TabIndex = 107;
			this.label71.Text = "Interval between Messages:";
			this.toolTip1.SetToolTip(this.label71, "Time between messages, may need to increase to 1 or 2 secs as a minimum.");
			// 
			// textBoxCountDownMSG
			// 
			this.textBoxCountDownMSG.Location = new System.Drawing.Point(205, 178);
			this.textBoxCountDownMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxCountDownMSG.Multiline = true;
			this.textBoxCountDownMSG.Name = "textBoxCountDownMSG";
			this.textBoxCountDownMSG.Size = new System.Drawing.Size(484, 42);
			this.textBoxCountDownMSG.TabIndex = 95;
			this.toolTip1.SetToolTip(this.textBoxCountDownMSG, "Enter a message that will be displayed when Countdown is enabled. Add the word CO" +
        "UNTDOWN anywhere in the message which will be replaced by number of days to the " +
        "countdown date.");
			this.textBoxCountDownMSG.TextChanged += new System.EventHandler(this.textBoxReturnBannedMSG_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(11, 187);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(186, 33);
			this.label3.TabIndex = 96;
			this.label3.Text = "Count down message";
			this.toolTip1.SetToolTip(this.label3, "Enter a message that will be displayed when Countdown is enabled. Add the word CO" +
        "UNTDOWN which will be replaced by number of days.");
			// 
			// checkBoxAutoStart
			// 
			this.checkBoxAutoStart.AutoSize = true;
			this.checkBoxAutoStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxAutoStart.Location = new System.Drawing.Point(20, 29);
			this.checkBoxAutoStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxAutoStart.Name = "checkBoxAutoStart";
			this.checkBoxAutoStart.Size = new System.Drawing.Size(281, 21);
			this.checkBoxAutoStart.TabIndex = 0;
			this.checkBoxAutoStart.Text = "Auto Start Message retrieval on startup:";
			this.checkBoxAutoStart.UseVisualStyleBackColor = true;
			this.checkBoxAutoStart.CheckedChanged += new System.EventHandler(this.checkBoxAutoStart_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.textBoxVixenFolder);
			this.groupBox3.Controls.Add(this.label32);
			this.groupBox3.Controls.Add(this.textBoxNodeId);
			this.groupBox3.Controls.Add(this.textBoxGroupName);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.textBoxOutputSequence);
			this.groupBox3.Controls.Add(this.label100);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.textBoxSequenceTemplate);
			this.groupBox3.Controls.Add(this.buttonGetVixenData);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.textBoxVixenServer);
			this.groupBox3.Location = new System.Drawing.Point(12, 526);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Size = new System.Drawing.Size(708, 215);
			this.groupBox3.TabIndex = 6;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Vixen Settings";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(12, 94);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(102, 17);
			this.label7.TabIndex = 7;
			this.label7.Text = "Vixen 3 Folder:";
			// 
			// textBoxVixenFolder
			// 
			this.textBoxVixenFolder.Enabled = false;
			this.textBoxVixenFolder.Location = new System.Drawing.Point(143, 93);
			this.textBoxVixenFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxVixenFolder.Name = "textBoxVixenFolder";
			this.textBoxVixenFolder.Size = new System.Drawing.Size(559, 22);
			this.textBoxVixenFolder.TabIndex = 6;
			this.textBoxVixenFolder.TextChanged += new System.EventHandler(this.textBoxReturnBannedMSG_TextChanged);
			// 
			// textBoxNodeId
			// 
			this.textBoxNodeId.Enabled = false;
			this.textBoxNodeId.Location = new System.Drawing.Point(143, 64);
			this.textBoxNodeId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxNodeId.Name = "textBoxNodeId";
			this.textBoxNodeId.Size = new System.Drawing.Size(559, 22);
			this.textBoxNodeId.TabIndex = 10;
			this.textBoxNodeId.TextChanged += new System.EventHandler(this.textBoxReturnBannedMSG_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(10, 188);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(123, 17);
			this.label6.TabIndex = 6;
			this.label6.Text = "Output Sequence:";
			// 
			// textBoxOutputSequence
			// 
			this.textBoxOutputSequence.Enabled = false;
			this.textBoxOutputSequence.Location = new System.Drawing.Point(143, 185);
			this.textBoxOutputSequence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxOutputSequence.Name = "textBoxOutputSequence";
			this.textBoxOutputSequence.Size = new System.Drawing.Size(559, 22);
			this.textBoxOutputSequence.TabIndex = 9;
			this.textBoxOutputSequence.TextChanged += new System.EventHandler(this.textBoxReturnBannedMSG_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 158);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(124, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "Messaging Folder:";
			// 
			// textBoxSequenceTemplate
			// 
			this.textBoxSequenceTemplate.Enabled = false;
			this.textBoxSequenceTemplate.Location = new System.Drawing.Point(143, 155);
			this.textBoxSequenceTemplate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxSequenceTemplate.Name = "textBoxSequenceTemplate";
			this.textBoxSequenceTemplate.Size = new System.Drawing.Size(559, 22);
			this.textBoxSequenceTemplate.TabIndex = 8;
			this.textBoxSequenceTemplate.TextChanged += new System.EventHandler(this.textBoxReturnBannedMSG_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 124);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 17);
			this.label4.TabIndex = 2;
			this.label4.Text = "Vixen Server:";
			// 
			// textBoxVixenServer
			// 
			this.textBoxVixenServer.Enabled = false;
			this.textBoxVixenServer.Location = new System.Drawing.Point(143, 124);
			this.textBoxVixenServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxVixenServer.Name = "textBoxVixenServer";
			this.textBoxVixenServer.Size = new System.Drawing.Size(559, 22);
			this.textBoxVixenServer.TabIndex = 7;
			this.textBoxVixenServer.TextChanged += new System.EventHandler(this.textBoxReturnBannedMSG_TextChanged);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.AddExtension = false;
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label74);
			this.groupBox5.Controls.Add(this.numericUpDownIntervalMsgs);
			this.groupBox5.Controls.Add(this.label71);
			this.groupBox5.Controls.Add(this.comboBoxBlack_Whitelist);
			this.groupBox5.Controls.Add(this.label14);
			this.groupBox5.Controls.Add(this.groupBox1);
			this.groupBox5.Controls.Add(this.dateCountDown);
			this.groupBox5.Controls.Add(this.label87);
			this.groupBox5.Controls.Add(this.checkBoxAutoStart);
			this.groupBox5.Location = new System.Drawing.Point(12, 11);
			this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox5.Size = new System.Drawing.Size(708, 511);
			this.groupBox5.TabIndex = 5;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Messaging Settings";
			// 
			// label74
			// 
			this.label74.AutoSize = true;
			this.label74.Location = new System.Drawing.Point(544, 57);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(32, 17);
			this.label74.TabIndex = 108;
			this.label74.Text = "Sec";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.trackBarRandomCountDownSensitivity);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.trackBarRandomAdvetisingSensitivity);
			this.groupBox1.Controls.Add(this.label44);
			this.groupBox1.Controls.Add(this.textBoxAdvertisingMSG);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.textBoxCountDownMSG);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBoxReturnWarningMSG);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBoxReturnSuccessMSG);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBoxReturnBannedMSG);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Location = new System.Drawing.Point(6, 131);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(696, 375);
			this.groupBox1.TabIndex = 93;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Auto Reply to Audiance";
			// 
			// textBoxAdvertisingMSG
			// 
			this.textBoxAdvertisingMSG.Location = new System.Drawing.Point(205, 274);
			this.textBoxAdvertisingMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxAdvertisingMSG.Multiline = true;
			this.textBoxAdvertisingMSG.Name = "textBoxAdvertisingMSG";
			this.textBoxAdvertisingMSG.Size = new System.Drawing.Size(485, 42);
			this.textBoxAdvertisingMSG.TabIndex = 97;
			this.toolTip1.SetToolTip(this.textBoxAdvertisingMSG, "Enter a advertising message that will be randomly displayed when enabled.");
			this.textBoxAdvertisingMSG.TextChanged += new System.EventHandler(this.textBoxReturnBannedMSG_TextChanged);
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(9, 282);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(186, 33);
			this.label10.TabIndex = 98;
			this.label10.Text = "Advertising message";
			this.toolTip1.SetToolTip(this.label10, "Enter a message that will be displayed when Countdown is enabled. Add the word CO" +
        "UNTDOWN which will be replaced by number of days.");
			// 
			// trackBarRandomAdvetisingSensitivity
			// 
			this.trackBarRandomAdvetisingSensitivity.AutoSize = false;
			this.trackBarRandomAdvetisingSensitivity.LargeChange = 1;
			this.trackBarRandomAdvetisingSensitivity.Location = new System.Drawing.Point(234, 329);
			this.trackBarRandomAdvetisingSensitivity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarRandomAdvetisingSensitivity.Maximum = 7;
			this.trackBarRandomAdvetisingSensitivity.Minimum = 1;
			this.trackBarRandomAdvetisingSensitivity.Name = "trackBarRandomAdvetisingSensitivity";
			this.trackBarRandomAdvetisingSensitivity.Size = new System.Drawing.Size(455, 32);
			this.trackBarRandomAdvetisingSensitivity.TabIndex = 99;
			this.toolTip1.SetToolTip(this.trackBarRandomAdvetisingSensitivity, "This will adjust the sensitivity of how often the Countdown and Advertising messa" +
        "ges are displayed.");
			this.trackBarRandomAdvetisingSensitivity.Value = 1;
			this.trackBarRandomAdvetisingSensitivity.Scroll += new System.EventHandler(this.trackBarTextPosition_MouseDown);
			this.trackBarRandomAdvetisingSensitivity.ValueChanged += new System.EventHandler(this.trackBarTextPosition_VisibleChanged);
			this.trackBarRandomAdvetisingSensitivity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextPosition_MouseDown);
			this.trackBarRandomAdvetisingSensitivity.MouseHover += new System.EventHandler(this.trackBarTextPosition_MouseDown);
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(11, 334);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(206, 17);
			this.label44.TabIndex = 100;
			this.label44.Text = "Random Advertising Sensitivity:";
			this.toolTip1.SetToolTip(this.label44, "This will adjust the sensitivity of how often the Countdown and Advertising messa" +
        "ges are displayed.");
			// 
			// trackBarRandomCountDownSensitivity
			// 
			this.trackBarRandomCountDownSensitivity.AutoSize = false;
			this.trackBarRandomCountDownSensitivity.LargeChange = 1;
			this.trackBarRandomCountDownSensitivity.Location = new System.Drawing.Point(234, 234);
			this.trackBarRandomCountDownSensitivity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarRandomCountDownSensitivity.Maximum = 7;
			this.trackBarRandomCountDownSensitivity.Minimum = 1;
			this.trackBarRandomCountDownSensitivity.Name = "trackBarRandomCountDownSensitivity";
			this.trackBarRandomCountDownSensitivity.Size = new System.Drawing.Size(455, 32);
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
			this.label8.Location = new System.Drawing.Point(11, 239);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(208, 17);
			this.label8.TabIndex = 102;
			this.label8.Text = "Random CountDown Sensitivity:";
			this.toolTip1.SetToolTip(this.label8, "This will adjust the sensitivity of how often the Countdown message is displayed." +
        "");
			// 
			// MessagingSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(732, 803);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.ok);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(750, 850);
			this.MinimumSize = new System.Drawing.Size(750, 850);
			this.Name = "MessagingSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Messaging Settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessagingSettings_FormClosing);
			this.Load += new System.EventHandler(this.MessagingSettings_Load);
			((System.ComponentModel.ISupportInitialize)(this.ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMsgs)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomAdvetisingSensitivity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomCountDownSensitivity)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.PictureBox ok;
		private System.Windows.Forms.ToolTip toolTip1;
		public System.Windows.Forms.PictureBox Cancel;
		private System.Windows.Forms.TextBox textBoxReturnBannedMSG;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.CheckBox checkBoxAutoStart;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label100;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button buttonGetVixenData;
		private System.Windows.Forms.TextBox textBoxVixenFolder;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.TextBox textBoxNodeId;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBoxOutputSequence;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBoxSequenceTemplate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBoxVixenServer;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.TextBox textBoxGroupName;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.DateTimePicker dateCountDown;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBoxReturnSuccessMSG;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxReturnWarningMSG;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.ComboBox comboBoxBlack_Whitelist;
		private System.Windows.Forms.Label label74;
		private System.Windows.Forms.NumericUpDown numericUpDownIntervalMsgs;
		private System.Windows.Forms.Label label71;
		private System.Windows.Forms.TextBox textBoxCountDownMSG;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBoxAdvertisingMSG;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TrackBar trackBarRandomAdvetisingSensitivity;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TrackBar trackBarRandomCountDownSensitivity;
		private System.Windows.Forms.Label label8;
    }
}