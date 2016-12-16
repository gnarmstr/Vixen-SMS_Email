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
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxServer = new System.Windows.Forms.TextBox();
			this.textBoxUID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxPWD = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttonTwilio = new System.Windows.Forms.Button();
			this.label65 = new System.Windows.Forms.Label();
			this.label68 = new System.Windows.Forms.Label();
			this.textBoxComments = new System.Windows.Forms.TextBox();
			this.comboBoxEmailSettings = new System.Windows.Forms.ComboBox();
			this.label67 = new System.Windows.Forms.Label();
			this.label64 = new System.Windows.Forms.Label();
			this.textBoxSMTP = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.textBoxReturnSubjectHeading = new System.Windows.Forms.TextBox();
			this.textBoxFromEmailAddress = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.timerCheckMail = new System.Windows.Forms.Timer(this.components);
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label12 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.richTextBoxWhitelist = new System.Windows.Forms.RichTextBox();
			this.richTextBoxBlacklist = new System.Windows.Forms.RichTextBox();
			this.label32 = new System.Windows.Forms.Label();
			this.groupBoxEffects = new System.Windows.Forms.GroupBox();
			this.label70 = new System.Windows.Forms.Label();
			this.label69 = new System.Windows.Forms.Label();
			this.extraTime = new System.Windows.Forms.NumericUpDown();
			this.checkBoxVariableLength = new System.Windows.Forms.CheckBox();
			this.tabControlEffects = new System.Windows.Forms.TabControl();
			this.tabPageSnowFlake = new System.Windows.Forms.TabPage();
			this.buttonPlaySnowFlake = new System.Windows.Forms.Button();
			this.label101 = new System.Windows.Forms.Label();
			this.comboBoxSnowFlakeName = new System.Windows.Forms.ComboBox();
			this.buttonRemoveSnowFlake = new System.Windows.Forms.Button();
			this.buttonAddSnowFlake = new System.Windows.Forms.Button();
			this.checkBoxRandom1 = new System.Windows.Forms.CheckBox();
			this.label56 = new System.Windows.Forms.Label();
			this.checkBoxSnowFlakeColour6 = new System.Windows.Forms.CheckBox();
			this.checkBoxSnowFlakeColour5 = new System.Windows.Forms.CheckBox();
			this.checkBoxSnowFlakeColour4 = new System.Windows.Forms.CheckBox();
			this.SnowFlakeColour5 = new System.Windows.Forms.Button();
			this.checkBoxSnowFlakeColour3 = new System.Windows.Forms.CheckBox();
			this.SnowFlakeColour6 = new System.Windows.Forms.Button();
			this.checkBoxSnowFlakeColour2 = new System.Windows.Forms.CheckBox();
			this.SnowFlakeColour4 = new System.Windows.Forms.Button();
			this.checkBoxSnowFlakeColour1 = new System.Windows.Forms.CheckBox();
			this.SnowFlakeColour3 = new System.Windows.Forms.Button();
			this.SnowFlakeColour1 = new System.Windows.Forms.Button();
			this.SnowFlakeColour2 = new System.Windows.Forms.Button();
			this.label17 = new System.Windows.Forms.Label();
			this.label29 = new System.Windows.Forms.Label();
			this.trackBarSpeedSnowFlakes = new System.Windows.Forms.TrackBar();
			this.EffectType = new System.Windows.Forms.NumericUpDown();
			this.MaxSnowFlake = new System.Windows.Forms.NumericUpDown();
			this.label30 = new System.Windows.Forms.Label();
			this.tabPageFire = new System.Windows.Forms.TabPage();
			this.label104 = new System.Windows.Forms.Label();
			this.comboBoxFireName = new System.Windows.Forms.ComboBox();
			this.buttonRemoveFire = new System.Windows.Forms.Button();
			this.buttonAddFire = new System.Windows.Forms.Button();
			this.buttonPlayFire = new System.Windows.Forms.Button();
			this.checkBoxRandom2 = new System.Windows.Forms.CheckBox();
			this.FireHeight = new System.Windows.Forms.NumericUpDown();
			this.label31 = new System.Windows.Forms.Label();
			this.tabPageMeteors = new System.Windows.Forms.TabPage();
			this.buttonPlayMeteor = new System.Windows.Forms.Button();
			this.label102 = new System.Windows.Forms.Label();
			this.comboBoxMeteorName = new System.Windows.Forms.ComboBox();
			this.buttonRemoveMeteor = new System.Windows.Forms.Button();
			this.buttonAddMeteor = new System.Windows.Forms.Button();
			this.checkBoxRandom3 = new System.Windows.Forms.CheckBox();
			this.label55 = new System.Windows.Forms.Label();
			this.checkBoxMeteorColour6 = new System.Windows.Forms.CheckBox();
			this.checkBoxMeteorColour5 = new System.Windows.Forms.CheckBox();
			this.checkBoxMeteorColour4 = new System.Windows.Forms.CheckBox();
			this.MeteorColour5 = new System.Windows.Forms.Button();
			this.checkBoxMeteorColour3 = new System.Windows.Forms.CheckBox();
			this.MeteorColour6 = new System.Windows.Forms.Button();
			this.checkBoxMeteorColour2 = new System.Windows.Forms.CheckBox();
			this.MeteorColour4 = new System.Windows.Forms.Button();
			this.checkBoxMeteorColour1 = new System.Windows.Forms.CheckBox();
			this.MeteorColour3 = new System.Windows.Forms.Button();
			this.MeteorColour1 = new System.Windows.Forms.Button();
			this.MeteorColour2 = new System.Windows.Forms.Button();
			this.label18 = new System.Windows.Forms.Label();
			this.trackBarSpeedMeteors = new System.Windows.Forms.TrackBar();
			this.MeteorColour = new System.Windows.Forms.ComboBox();
			this.label35 = new System.Windows.Forms.Label();
			this.MeteorTrailLength = new System.Windows.Forms.NumericUpDown();
			this.label34 = new System.Windows.Forms.Label();
			this.MeteorCount = new System.Windows.Forms.NumericUpDown();
			this.label33 = new System.Windows.Forms.Label();
			this.tabPageTwinkles = new System.Windows.Forms.TabPage();
			this.buttonPlayTwinkle = new System.Windows.Forms.Button();
			this.label103 = new System.Windows.Forms.Label();
			this.comboBoxTwinkleName = new System.Windows.Forms.ComboBox();
			this.buttonRemoveTwinkle = new System.Windows.Forms.Button();
			this.buttonAddTwinkle = new System.Windows.Forms.Button();
			this.checkBoxRandom4 = new System.Windows.Forms.CheckBox();
			this.label54 = new System.Windows.Forms.Label();
			this.checkBoxTwinkleColour6 = new System.Windows.Forms.CheckBox();
			this.checkBoxTwinkleColour5 = new System.Windows.Forms.CheckBox();
			this.checkBoxTwinkleColour4 = new System.Windows.Forms.CheckBox();
			this.TwinkleColour5 = new System.Windows.Forms.Button();
			this.checkBoxTwinkleColour3 = new System.Windows.Forms.CheckBox();
			this.TwinkleColour6 = new System.Windows.Forms.Button();
			this.checkBoxTwinkleColour2 = new System.Windows.Forms.CheckBox();
			this.TwinkleColour4 = new System.Windows.Forms.Button();
			this.checkBoxTwinkleColour1 = new System.Windows.Forms.CheckBox();
			this.TwinkleColour3 = new System.Windows.Forms.Button();
			this.TwinkleColour1 = new System.Windows.Forms.Button();
			this.TwinkleColour2 = new System.Windows.Forms.Button();
			this.label53 = new System.Windows.Forms.Label();
			this.trackBarSpeedTwinkles = new System.Windows.Forms.TrackBar();
			this.label52 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.trackBarTwinkleSteps = new System.Windows.Forms.TrackBar();
			this.trackBarTwinkleLights = new System.Windows.Forms.TrackBar();
			this.tabPageMovie = new System.Windows.Forms.TabPage();
			this.buttonPlayMovie = new System.Windows.Forms.Button();
			this.label77 = new System.Windows.Forms.Label();
			this.label76 = new System.Windows.Forms.Label();
			this.label75 = new System.Windows.Forms.Label();
			this.numericUpDownMatrixH = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMatrixW = new System.Windows.Forms.NumericUpDown();
			this.checkBoxRandom5 = new System.Windows.Forms.CheckBox();
			this.buttonMovieDelete = new System.Windows.Forms.Button();
			this.label72 = new System.Windows.Forms.Label();
			this.label73 = new System.Windows.Forms.Label();
			this.trackBarMovieSpeed = new System.Windows.Forms.TrackBar();
			this.trackBarThumbnail = new System.Windows.Forms.TrackBar();
			this.pictureBoxMovie = new System.Windows.Forms.PictureBox();
			this.tabPageGlediator = new System.Windows.Forms.TabPage();
			this.buttonPlayGled = new System.Windows.Forms.Button();
			this.label80 = new System.Windows.Forms.Label();
			this.label79 = new System.Windows.Forms.Label();
			this.trackBarGlediator = new System.Windows.Forms.TrackBar();
			this.checkBoxRandom6 = new System.Windows.Forms.CheckBox();
			this.textBoxGlediator = new System.Windows.Forms.TextBox();
			this.buttonGlediator = new System.Windows.Forms.Button();
			this.label28 = new System.Windows.Forms.Label();
			this.EffectTime = new System.Windows.Forms.NumericUpDown();
			this.TabSeq1 = new System.Windows.Forms.TabPage();
			this.label48 = new System.Windows.Forms.Label();
			this.textBoxSequenceLength1 = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.buttonRemoveSeq1 = new System.Windows.Forms.Button();
			this.label40 = new System.Windows.Forms.Label();
			this.textBoxVixenSeq1 = new System.Windows.Forms.TextBox();
			this.buttonVixenSeq1 = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.TabSeq2 = new System.Windows.Forms.TabPage();
			this.label49 = new System.Windows.Forms.Label();
			this.textBoxSequenceLength2 = new System.Windows.Forms.TextBox();
			this.label24 = new System.Windows.Forms.Label();
			this.buttonRemoveSeq2 = new System.Windows.Forms.Button();
			this.label39 = new System.Windows.Forms.Label();
			this.textBoxVixenSeq2 = new System.Windows.Forms.TextBox();
			this.buttonVixenSeq2 = new System.Windows.Forms.Button();
			this.label20 = new System.Windows.Forms.Label();
			this.buttonRemoveSeq3 = new System.Windows.Forms.Button();
			this.checkBoxManEnterSettings = new System.Windows.Forms.CheckBox();
			this.buttonRemoveSeq4 = new System.Windows.Forms.Button();
			this.checkBoxEnableSqnctrl = new System.Windows.Forms.CheckBox();
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
			this.checkBoxRandomSeqSelection = new System.Windows.Forms.CheckBox();
			this.WebServerStatus = new System.Windows.Forms.Button();
			this.buttonRemoveSeq5 = new System.Windows.Forms.Button();
			this.buttonRemoveSeq6 = new System.Windows.Forms.Button();
			this.checkBoxDisableSeq = new System.Windows.Forms.CheckBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label78 = new System.Windows.Forms.Label();
			this.textBoxAccessPWD = new System.Windows.Forms.TextBox();
			this.checkBoxEmail = new System.Windows.Forms.CheckBox();
			this.checkBoxLocal = new System.Windows.Forms.CheckBox();
			this.checkBoxTwilio = new System.Windows.Forms.CheckBox();
			this.label66 = new System.Windows.Forms.Label();
			this.numericUpDownMultiLine = new System.Windows.Forms.NumericUpDown();
			this.label85 = new System.Windows.Forms.Label();
			this.checkBoxMultiLine = new System.Windows.Forms.CheckBox();
			this.label88 = new System.Windows.Forms.Label();
			this.numericUpDownMaxWords = new System.Windows.Forms.NumericUpDown();
			this.checkBoxVixenControl = new System.Windows.Forms.CheckBox();
			this.groupBox7 = new System.Windows.Forms.GroupBox();
			this.SaveAll = new System.Windows.Forms.PictureBox();
			this.checkBoxLocalRandom = new System.Windows.Forms.CheckBox();
			this.groupBoxCountDown = new System.Windows.Forms.GroupBox();
			this.label106 = new System.Windows.Forms.Label();
			this.label37 = new System.Windows.Forms.Label();
			this.customMessageNodeSel = new System.Windows.Forms.ComboBox();
			this.label99 = new System.Windows.Forms.Label();
			this.customMessageSeqSel = new System.Windows.Forms.ComboBox();
			this.checkBoxCentreStop = new System.Windows.Forms.CheckBox();
			this.label97 = new System.Windows.Forms.Label();
			this.messageColourOption = new System.Windows.Forms.ComboBox();
			this.line1Colour = new System.Windows.Forms.Button();
			this.line2Colour = new System.Windows.Forms.Button();
			this.line3Colour = new System.Windows.Forms.Button();
			this.line4Colour = new System.Windows.Forms.Button();
			this.label95 = new System.Windows.Forms.Label();
			this.trackBarCustomSpeed = new System.Windows.Forms.TrackBar();
			this.buttonPlay = new System.Windows.Forms.Button();
			this.CustomMsgLength = new System.Windows.Forms.NumericUpDown();
			this.label94 = new System.Windows.Forms.Label();
			this.textBoxCustomFontSize = new System.Windows.Forms.TextBox();
			this.textBoxCustomFont = new System.Windows.Forms.TextBox();
			this.buttonCustomFont = new System.Windows.Forms.Button();
			this.label93 = new System.Windows.Forms.Label();
			this.comboBoxName = new System.Windows.Forms.ComboBox();
			this.checkBoxMessageEnabled = new System.Windows.Forms.CheckBox();
			this.buttonRemoveMessage = new System.Windows.Forms.Button();
			this.buttonAddMessage = new System.Windows.Forms.Button();
			this.comboBoxCountDownDirection = new System.Windows.Forms.ComboBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label92 = new System.Windows.Forms.Label();
			this.label91 = new System.Windows.Forms.Label();
			this.label90 = new System.Windows.Forms.Label();
			this.label89 = new System.Windows.Forms.Label();
			this.textBoxLine1 = new System.Windows.Forms.TextBox();
			this.textBoxLine2 = new System.Windows.Forms.TextBox();
			this.label86 = new System.Windows.Forms.Label();
			this.textBoxLine3 = new System.Windows.Forms.TextBox();
			this.trackBarCountDownPosition = new System.Windows.Forms.TrackBar();
			this.textBoxLine4 = new System.Windows.Forms.TextBox();
			this.richTextBoxMessage = new System.Windows.Forms.RichTextBox();
			this.checkBoxCountDownEnable = new System.Windows.Forms.CheckBox();
			this.label87 = new System.Windows.Forms.Label();
			this.label71 = new System.Windows.Forms.Label();
			this.checkBoxBlacklist = new System.Windows.Forms.CheckBox();
			this.checkBoxWhitelist = new System.Windows.Forms.CheckBox();
			this.label36 = new System.Windows.Forms.Label();
			this.label46 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
			this.comboBoxNodeID = new System.Windows.Forms.ComboBox();
			this.buttonRemoveNodeID = new System.Windows.Forms.Button();
			this.buttonAddNodeID = new System.Windows.Forms.Button();
			this.label100 = new System.Windows.Forms.Label();
			this.checkBoxTextFile = new System.Windows.Forms.CheckBox();
			this.checkBoxdeleteTextFile = new System.Windows.Forms.CheckBox();
			this.comboBoxPlayMode = new System.Windows.Forms.ComboBox();
			this.tabControlMain = new System.Windows.Forms.TabControl();
			this.tabPageMain = new System.Windows.Forms.TabPage();
			this.groupBoxPlayOptions = new System.Windows.Forms.GroupBox();
			this.label74 = new System.Windows.Forms.Label();
			this.numericUpDownIntervalMsgs = new System.Windows.Forms.NumericUpDown();
			this.tabPageMessagingSettings = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label7 = new System.Windows.Forms.Label();
			this.buttonGetVixenData = new System.Windows.Forms.Button();
			this.textBoxVixenFolder = new System.Windows.Forms.TextBox();
			this.textBoxNodeId = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBoxOutputSequence = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBoxSequenceTemplate = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBoxVixenServer = new System.Windows.Forms.TextBox();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.textBoxBlacklistEmailLog = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBoxLogFileName = new System.Windows.Forms.TextBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.label105 = new System.Windows.Forms.Label();
			this.textBoxTextFileFolder = new System.Windows.Forms.TextBox();
			this.textBoxReturnBannedMSG = new System.Windows.Forms.TextBox();
			this.checkBoxAutoStart = new System.Windows.Forms.CheckBox();
			this.textBoxSubjectHeader = new System.Windows.Forms.TextBox();
			this.buttonResetToDefault = new System.Windows.Forms.Button();
			this.tabPageTextSetting = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.richTextBoxLog1 = new System.Windows.Forms.RichTextBox();
			this.groupBoxSeqSettings = new System.Windows.Forms.GroupBox();
			this.label98 = new System.Windows.Forms.Label();
			this.incomingMessageColourOption = new System.Windows.Forms.ComboBox();
			this.textBoxFontSize = new System.Windows.Forms.TextBox();
			this.buttonFont = new System.Windows.Forms.Button();
			this.textBoxFont = new System.Windows.Forms.TextBox();
			this.comboBoxString = new System.Windows.Forms.ComboBox();
			this.TextLineNumber = new System.Windows.Forms.NumericUpDown();
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
			this.tabPageSeqSettings = new System.Windows.Forms.TabPage();
			this.groupBoxLog = new System.Windows.Forms.GroupBox();
			this.richTextBoxLog2 = new System.Windows.Forms.RichTextBox();
			this.groupBoxSeqControl = new System.Windows.Forms.GroupBox();
			this.tabControlSequence = new System.Windows.Forms.TabControl();
			this.TabSeq3 = new System.Windows.Forms.TabPage();
			this.label47 = new System.Windows.Forms.Label();
			this.textBoxSequenceLength3 = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.textBoxVixenSeq3 = new System.Windows.Forms.TextBox();
			this.buttonVixenSeq3 = new System.Windows.Forms.Button();
			this.label23 = new System.Windows.Forms.Label();
			this.TabSeq4 = new System.Windows.Forms.TabPage();
			this.label50 = new System.Windows.Forms.Label();
			this.textBoxSequenceLength4 = new System.Windows.Forms.TextBox();
			this.label41 = new System.Windows.Forms.Label();
			this.label42 = new System.Windows.Forms.Label();
			this.textBoxVixenSeq4 = new System.Windows.Forms.TextBox();
			this.buttonVixenSeq4 = new System.Windows.Forms.Button();
			this.label43 = new System.Windows.Forms.Label();
			this.TabSeq5 = new System.Windows.Forms.TabPage();
			this.label27 = new System.Windows.Forms.Label();
			this.textBoxSequenceLength5 = new System.Windows.Forms.TextBox();
			this.label57 = new System.Windows.Forms.Label();
			this.label58 = new System.Windows.Forms.Label();
			this.textBoxVixenSeq5 = new System.Windows.Forms.TextBox();
			this.buttonVixenSeq5 = new System.Windows.Forms.Button();
			this.label59 = new System.Windows.Forms.Label();
			this.TabSeq6 = new System.Windows.Forms.TabPage();
			this.label60 = new System.Windows.Forms.Label();
			this.textBoxSequenceLength6 = new System.Windows.Forms.TextBox();
			this.label61 = new System.Windows.Forms.Label();
			this.label62 = new System.Windows.Forms.Label();
			this.textBoxVixenSeq6 = new System.Windows.Forms.TextBox();
			this.buttonVixenSeq6 = new System.Windows.Forms.Button();
			this.label63 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.tabPageWordLists = new System.Windows.Forms.TabPage();
			this.pictureBoxSaveBlacklist = new System.Windows.Forms.PictureBox();
			this.pictureBoxSaveWhitelist = new System.Windows.Forms.PictureBox();
			this.remoteCmds = new System.Windows.Forms.TabPage();
			this.label84 = new System.Windows.Forms.Label();
			this.label83 = new System.Windows.Forms.Label();
			this.label82 = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.label81 = new System.Windows.Forms.Label();
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
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBoxEffects.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.extraTime)).BeginInit();
			this.tabControlEffects.SuspendLayout();
			this.tabPageSnowFlake.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSpeedSnowFlakes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EffectType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxSnowFlake)).BeginInit();
			this.tabPageFire.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.FireHeight)).BeginInit();
			this.tabPageMeteors.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSpeedMeteors)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MeteorTrailLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MeteorCount)).BeginInit();
			this.tabPageTwinkles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSpeedTwinkles)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTwinkleSteps)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTwinkleLights)).BeginInit();
			this.tabPageMovie.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatrixH)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatrixW)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarMovieSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarThumbnail)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxMovie)).BeginInit();
			this.tabPageGlediator.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarGlediator)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.EffectTime)).BeginInit();
			this.TabSeq1.SuspendLayout();
			this.TabSeq2.SuspendLayout();
			this.RandomColourSelection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMultiLine)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWords)).BeginInit();
			this.groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).BeginInit();
			this.groupBoxCountDown.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarCustomSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.CustomMsgLength)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarCountDownPosition)).BeginInit();
			this.tabControlMain.SuspendLayout();
			this.tabPageMain.SuspendLayout();
			this.groupBoxPlayOptions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMsgs)).BeginInit();
			this.tabPageMessagingSettings.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox6.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPageTextSetting.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBoxSeqSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.TextLineNumber)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextPosition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextSpeed)).BeginInit();
			this.localMsgs.SuspendLayout();
			this.groupBoxMessages.SuspendLayout();
			this.groupBox8.SuspendLayout();
			this.tabPageSeqSettings.SuspendLayout();
			this.groupBoxLog.SuspendLayout();
			this.groupBoxSeqControl.SuspendLayout();
			this.tabControlSequence.SuspendLayout();
			this.TabSeq3.SuspendLayout();
			this.TabSeq4.SuspendLayout();
			this.TabSeq5.SuspendLayout();
			this.TabSeq6.SuspendLayout();
			this.tabPageWordLists.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveBlacklist)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveWhitelist)).BeginInit();
			this.remoteCmds.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.buttonStart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStop)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonHelp)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 182);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(95, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "POP3 Server:";
			// 
			// textBoxServer
			// 
			this.textBoxServer.Location = new System.Drawing.Point(194, 178);
			this.textBoxServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxServer.Name = "textBoxServer";
			this.textBoxServer.Size = new System.Drawing.Size(579, 22);
			this.textBoxServer.TabIndex = 5;
			// 
			// textBoxUID
			// 
			this.textBoxUID.Location = new System.Drawing.Point(194, 74);
			this.textBoxUID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxUID.Name = "textBoxUID";
			this.textBoxUID.Size = new System.Drawing.Size(578, 22);
			this.textBoxUID.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 75);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "User Name:";
			this.toolTip1.SetToolTip(this.label2, "Username may include the full email address");
			// 
			// textBoxPWD
			// 
			this.textBoxPWD.Location = new System.Drawing.Point(194, 103);
			this.textBoxPWD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxPWD.Name = "textBoxPWD";
			this.textBoxPWD.PasswordChar = '*';
			this.textBoxPWD.Size = new System.Drawing.Size(578, 22);
			this.textBoxPWD.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(9, 106);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Password:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.buttonTwilio);
			this.groupBox1.Controls.Add(this.label65);
			this.groupBox1.Controls.Add(this.label68);
			this.groupBox1.Controls.Add(this.textBoxComments);
			this.groupBox1.Controls.Add(this.comboBoxEmailSettings);
			this.groupBox1.Controls.Add(this.label67);
			this.groupBox1.Controls.Add(this.label64);
			this.groupBox1.Controls.Add(this.textBoxSMTP);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.textBoxReturnSubjectHeading);
			this.groupBox1.Controls.Add(this.textBoxFromEmailAddress);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBoxPWD);
			this.groupBox1.Controls.Add(this.textBoxServer);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBoxUID);
			this.groupBox1.Location = new System.Drawing.Point(11, 5);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Size = new System.Drawing.Size(775, 340);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mail Server";
			// 
			// buttonTwilio
			// 
			this.buttonTwilio.BackColor = System.Drawing.Color.Honeydew;
			this.buttonTwilio.Location = new System.Drawing.Point(15, 288);
			this.buttonTwilio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonTwilio.Name = "buttonTwilio";
			this.buttonTwilio.Size = new System.Drawing.Size(125, 39);
			this.buttonTwilio.TabIndex = 8;
			this.buttonTwilio.Text = "Twilio Settings";
			this.toolTip1.SetToolTip(this.buttonTwilio, "Only need to select this if you have a Twilio account that would be used to accep" +
        "t SMS\'s.");
			this.buttonTwilio.UseVisualStyleBackColor = false;
			this.buttonTwilio.Click += new System.EventHandler(this.buttonTwilio_Click);
			// 
			// label65
			// 
			this.label65.Location = new System.Drawing.Point(350, 142);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(404, 26);
			this.label65.TabIndex = 34;
			this.label65.Text = "Listed Email Clients have been tested and are supported.";
			// 
			// label68
			// 
			this.label68.Location = new System.Drawing.Point(9, 244);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(152, 44);
			this.label68.TabIndex = 33;
			this.label68.Text = "Important Information for your email client:";
			this.toolTip1.SetToolTip(this.label68, "example for gmail is 587");
			// 
			// textBoxComments
			// 
			this.textBoxComments.Enabled = false;
			this.textBoxComments.Location = new System.Drawing.Point(192, 242);
			this.textBoxComments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxComments.Multiline = true;
			this.textBoxComments.Name = "textBoxComments";
			this.textBoxComments.Size = new System.Drawing.Size(578, 89);
			this.textBoxComments.TabIndex = 7;
			// 
			// comboBoxEmailSettings
			// 
			this.comboBoxEmailSettings.FormattingEnabled = true;
			this.comboBoxEmailSettings.Items.AddRange(new object[] {
            "Manual",
            "GMail",
            "Yahoo.com",
            "Yahoo.com.au",
            "Zoho",
            "Yandex"});
			this.comboBoxEmailSettings.Location = new System.Drawing.Point(194, 139);
			this.comboBoxEmailSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxEmailSettings.Name = "comboBoxEmailSettings";
			this.comboBoxEmailSettings.Size = new System.Drawing.Size(134, 24);
			this.comboBoxEmailSettings.TabIndex = 4;
			this.comboBoxEmailSettings.SelectedIndexChanged += new System.EventHandler(this.comboBoxEmailSettings_SelectedIndexChanged);
			// 
			// label67
			// 
			this.label67.AutoSize = true;
			this.label67.Location = new System.Drawing.Point(9, 142);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(128, 17);
			this.label67.TabIndex = 17;
			this.label67.Text = "Select Email Client:";
			this.toolTip1.SetToolTip(this.label67, "This will automatically populate your email settings for your email client.");
			// 
			// label64
			// 
			this.label64.AutoSize = true;
			this.label64.Location = new System.Drawing.Point(9, 212);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(90, 17);
			this.label64.TabIndex = 10;
			this.label64.Text = "SMTP (TLS):";
			this.toolTip1.SetToolTip(this.label64, "Enter the SMTP of your email address");
			// 
			// textBoxSMTP
			// 
			this.textBoxSMTP.Location = new System.Drawing.Point(194, 209);
			this.textBoxSMTP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxSMTP.Name = "textBoxSMTP";
			this.textBoxSMTP.Size = new System.Drawing.Size(578, 22);
			this.textBoxSMTP.TabIndex = 6;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(9, 18);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(163, 17);
			this.label13.TabIndex = 8;
			this.label13.Text = "Return Subject Heading:";
			this.toolTip1.SetToolTip(this.label13, "Enter a return subject heading. For example  Northridge Xmas Lights");
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(9, 46);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(137, 17);
			this.label11.TabIndex = 7;
			this.label11.Text = "From Email address:";
			this.toolTip1.SetToolTip(this.label11, "Enter the email address for your lights");
			// 
			// textBoxReturnSubjectHeading
			// 
			this.textBoxReturnSubjectHeading.Location = new System.Drawing.Point(194, 14);
			this.textBoxReturnSubjectHeading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxReturnSubjectHeading.Name = "textBoxReturnSubjectHeading";
			this.textBoxReturnSubjectHeading.Size = new System.Drawing.Size(576, 22);
			this.textBoxReturnSubjectHeading.TabIndex = 0;
			// 
			// textBoxFromEmailAddress
			// 
			this.textBoxFromEmailAddress.Location = new System.Drawing.Point(194, 44);
			this.textBoxFromEmailAddress.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxFromEmailAddress.Name = "textBoxFromEmailAddress";
			this.textBoxFromEmailAddress.Size = new System.Drawing.Size(576, 22);
			this.textBoxFromEmailAddress.TabIndex = 1;
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
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(13, 62);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(91, 17);
			this.label12.TabIndex = 17;
			this.label12.Text = "Blacklist Log:";
			this.toolTip1.SetToolTip(this.label12, "Email address and phone numbers are stored in this file when a member has sent a " +
        "Blacklist word. This will be cleared each time Vixen Messaging is re-started.");
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
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(403, 30);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(143, 17);
			this.label15.TabIndex = 5;
			this.label15.Text = "SMS Subject Header:";
			this.toolTip1.SetToolTip(this.label15, "This is used to check for against in the incoming SMS messages from you SMS provi" +
        "der. Not applicable for Twilio accounts.");
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(377, 67);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(388, 70);
			this.label16.TabIndex = 6;
			this.label16.Text = resources.GetString("label16.Text");
			this.toolTip1.SetToolTip(this.label16, "This is used to check for agaist in th eincoming SMS messages from you SMS provid" +
        "er");
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
			// label32
			// 
			this.label32.AutoSize = true;
			this.label32.Location = new System.Drawing.Point(12, 73);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(101, 17);
			this.label32.TabIndex = 10;
			this.label32.Text = "Group NodeId:";
			this.toolTip1.SetToolTip(this.label32, "The Node ID of the Group used to Display the Text. This must be set for the softw" +
        "are to work.");
			// 
			// groupBoxEffects
			// 
			this.groupBoxEffects.Controls.Add(this.label70);
			this.groupBoxEffects.Controls.Add(this.label69);
			this.groupBoxEffects.Controls.Add(this.extraTime);
			this.groupBoxEffects.Controls.Add(this.checkBoxVariableLength);
			this.groupBoxEffects.Controls.Add(this.tabControlEffects);
			this.groupBoxEffects.Controls.Add(this.label28);
			this.groupBoxEffects.Controls.Add(this.EffectTime);
			this.groupBoxEffects.Location = new System.Drawing.Point(5, 42);
			this.groupBoxEffects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxEffects.Name = "groupBoxEffects";
			this.groupBoxEffects.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxEffects.Size = new System.Drawing.Size(780, 262);
			this.groupBoxEffects.TabIndex = 1;
			this.groupBoxEffects.TabStop = false;
			this.groupBoxEffects.Text = "Messaging Effects";
			this.toolTip1.SetToolTip(this.groupBoxEffects, "These effects correspond to the Nutcracker effects in Vixen 3");
			// 
			// label70
			// 
			this.label70.AutoSize = true;
			this.label70.Location = new System.Drawing.Point(259, 23);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(117, 17);
			this.label70.TabIndex = 41;
			this.label70.Text = "Extend length by:";
			this.toolTip1.SetToolTip(this.label70, "Extends the Sequence length by adding this to the Auto adjusted length.");
			// 
			// label69
			// 
			this.label69.AutoSize = true;
			this.label69.Location = new System.Drawing.Point(445, 25);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(32, 17);
			this.label69.TabIndex = 40;
			this.label69.Text = "Sec";
			this.toolTip1.SetToolTip(this.label69, "Set length. Message will repeat until seq length time has reached.");
			// 
			// extraTime
			// 
			this.extraTime.Enabled = false;
			this.extraTime.Location = new System.Drawing.Point(381, 22);
			this.extraTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.extraTime.Name = "extraTime";
			this.extraTime.Size = new System.Drawing.Size(60, 22);
			this.extraTime.TabIndex = 1;
			// 
			// checkBoxVariableLength
			// 
			this.checkBoxVariableLength.AutoSize = true;
			this.checkBoxVariableLength.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxVariableLength.Location = new System.Drawing.Point(11, 23);
			this.checkBoxVariableLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxVariableLength.Name = "checkBoxVariableLength";
			this.checkBoxVariableLength.Size = new System.Drawing.Size(178, 21);
			this.checkBoxVariableLength.TabIndex = 0;
			this.checkBoxVariableLength.Text = "Auto Adjust Seq length:";
			this.toolTip1.SetToolTip(this.checkBoxVariableLength, "Sequence length is determained by the number of characters in the message and spe" +
        "ed of the Text selected. This ensures maximum usage of time.");
			this.checkBoxVariableLength.UseVisualStyleBackColor = true;
			this.checkBoxVariableLength.CheckedChanged += new System.EventHandler(this.checkBoxVariableLength_CheckedChanged);
			// 
			// tabControlEffects
			// 
			this.tabControlEffects.Controls.Add(this.tabPageSnowFlake);
			this.tabControlEffects.Controls.Add(this.tabPageFire);
			this.tabControlEffects.Controls.Add(this.tabPageMeteors);
			this.tabControlEffects.Controls.Add(this.tabPageTwinkles);
			this.tabControlEffects.Controls.Add(this.tabPageMovie);
			this.tabControlEffects.Controls.Add(this.tabPageGlediator);
			this.tabControlEffects.Location = new System.Drawing.Point(5, 52);
			this.tabControlEffects.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabControlEffects.Name = "tabControlEffects";
			this.tabControlEffects.SelectedIndex = 0;
			this.tabControlEffects.Size = new System.Drawing.Size(770, 206);
			this.tabControlEffects.TabIndex = 2;
			// 
			// tabPageSnowFlake
			// 
			this.tabPageSnowFlake.BackColor = System.Drawing.Color.Azure;
			this.tabPageSnowFlake.Controls.Add(this.buttonPlaySnowFlake);
			this.tabPageSnowFlake.Controls.Add(this.label101);
			this.tabPageSnowFlake.Controls.Add(this.comboBoxSnowFlakeName);
			this.tabPageSnowFlake.Controls.Add(this.buttonRemoveSnowFlake);
			this.tabPageSnowFlake.Controls.Add(this.buttonAddSnowFlake);
			this.tabPageSnowFlake.Controls.Add(this.checkBoxRandom1);
			this.tabPageSnowFlake.Controls.Add(this.label56);
			this.tabPageSnowFlake.Controls.Add(this.checkBoxSnowFlakeColour6);
			this.tabPageSnowFlake.Controls.Add(this.checkBoxSnowFlakeColour5);
			this.tabPageSnowFlake.Controls.Add(this.checkBoxSnowFlakeColour4);
			this.tabPageSnowFlake.Controls.Add(this.SnowFlakeColour5);
			this.tabPageSnowFlake.Controls.Add(this.checkBoxSnowFlakeColour3);
			this.tabPageSnowFlake.Controls.Add(this.SnowFlakeColour6);
			this.tabPageSnowFlake.Controls.Add(this.checkBoxSnowFlakeColour2);
			this.tabPageSnowFlake.Controls.Add(this.SnowFlakeColour4);
			this.tabPageSnowFlake.Controls.Add(this.checkBoxSnowFlakeColour1);
			this.tabPageSnowFlake.Controls.Add(this.SnowFlakeColour3);
			this.tabPageSnowFlake.Controls.Add(this.SnowFlakeColour1);
			this.tabPageSnowFlake.Controls.Add(this.SnowFlakeColour2);
			this.tabPageSnowFlake.Controls.Add(this.label17);
			this.tabPageSnowFlake.Controls.Add(this.label29);
			this.tabPageSnowFlake.Controls.Add(this.trackBarSpeedSnowFlakes);
			this.tabPageSnowFlake.Controls.Add(this.EffectType);
			this.tabPageSnowFlake.Controls.Add(this.MaxSnowFlake);
			this.tabPageSnowFlake.Controls.Add(this.label30);
			this.tabPageSnowFlake.Location = new System.Drawing.Point(4, 25);
			this.tabPageSnowFlake.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageSnowFlake.Name = "tabPageSnowFlake";
			this.tabPageSnowFlake.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageSnowFlake.Size = new System.Drawing.Size(762, 177);
			this.tabPageSnowFlake.TabIndex = 0;
			this.tabPageSnowFlake.Tag = "1";
			this.tabPageSnowFlake.Text = "SnowFlakes";
			// 
			// buttonPlaySnowFlake
			// 
			this.buttonPlaySnowFlake.BackColor = System.Drawing.Color.Azure;
			this.buttonPlaySnowFlake.FlatAppearance.BorderSize = 0;
			this.buttonPlaySnowFlake.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonPlaySnowFlake.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonPlaySnowFlake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPlaySnowFlake.Location = new System.Drawing.Point(369, 27);
			this.buttonPlaySnowFlake.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPlaySnowFlake.Name = "buttonPlaySnowFlake";
			this.buttonPlaySnowFlake.Size = new System.Drawing.Size(34, 30);
			this.buttonPlaySnowFlake.TabIndex = 88;
			this.buttonPlaySnowFlake.Text = "P";
			this.toolTip1.SetToolTip(this.buttonPlaySnowFlake, "Play selected Effect. Useful for testing current Effect with no text.");
			this.buttonPlaySnowFlake.UseVisualStyleBackColor = false;
			this.buttonPlaySnowFlake.Click += new System.EventHandler(this.buttonPlaySnowFlake_Click);
			// 
			// label101
			// 
			this.label101.AutoSize = true;
			this.label101.Location = new System.Drawing.Point(9, 8);
			this.label101.Name = "label101";
			this.label101.Size = new System.Drawing.Size(121, 17);
			this.label101.TabIndex = 89;
			this.label101.Text = "SnowFlake Name:";
			// 
			// comboBoxSnowFlakeName
			// 
			this.comboBoxSnowFlakeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxSnowFlakeName.FormattingEnabled = true;
			this.comboBoxSnowFlakeName.Location = new System.Drawing.Point(12, 32);
			this.comboBoxSnowFlakeName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxSnowFlakeName.Name = "comboBoxSnowFlakeName";
			this.comboBoxSnowFlakeName.Size = new System.Drawing.Size(254, 24);
			this.comboBoxSnowFlakeName.TabIndex = 85;
			this.toolTip1.SetToolTip(this.comboBoxSnowFlakeName, "List of all SnowFlake effects that have been created.");
			this.comboBoxSnowFlakeName.SelectedIndexChanged += new System.EventHandler(this.comboBoxSnowFlakeName_SelectedIndexChanged);
			// 
			// buttonRemoveSnowFlake
			// 
			this.buttonRemoveSnowFlake.BackColor = System.Drawing.Color.Azure;
			this.buttonRemoveSnowFlake.FlatAppearance.BorderSize = 0;
			this.buttonRemoveSnowFlake.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveSnowFlake.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveSnowFlake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveSnowFlake.Location = new System.Drawing.Point(324, 27);
			this.buttonRemoveSnowFlake.Margin = new System.Windows.Forms.Padding(0);
			this.buttonRemoveSnowFlake.Name = "buttonRemoveSnowFlake";
			this.buttonRemoveSnowFlake.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveSnowFlake.TabIndex = 87;
			this.buttonRemoveSnowFlake.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveSnowFlake, "Delete selected effect.");
			this.buttonRemoveSnowFlake.UseVisualStyleBackColor = false;
			this.buttonRemoveSnowFlake.Click += new System.EventHandler(this.buttonRemoveSnowFlake_Click);
			// 
			// buttonAddSnowFlake
			// 
			this.buttonAddSnowFlake.BackColor = System.Drawing.Color.Azure;
			this.buttonAddSnowFlake.FlatAppearance.BorderSize = 0;
			this.buttonAddSnowFlake.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonAddSnowFlake.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonAddSnowFlake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAddSnowFlake.Location = new System.Drawing.Point(278, 27);
			this.buttonAddSnowFlake.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAddSnowFlake.Name = "buttonAddSnowFlake";
			this.buttonAddSnowFlake.Size = new System.Drawing.Size(34, 30);
			this.buttonAddSnowFlake.TabIndex = 86;
			this.buttonAddSnowFlake.Text = "+";
			this.toolTip1.SetToolTip(this.buttonAddSnowFlake, "Create new SnowFlake effect.");
			this.buttonAddSnowFlake.UseVisualStyleBackColor = false;
			this.buttonAddSnowFlake.Click += new System.EventHandler(this.buttonAddSnowFlake_Click);
			// 
			// checkBoxRandom1
			// 
			this.checkBoxRandom1.AutoSize = true;
			this.checkBoxRandom1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRandom1.Location = new System.Drawing.Point(505, 5);
			this.checkBoxRandom1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxRandom1.Name = "checkBoxRandom1";
			this.checkBoxRandom1.Size = new System.Drawing.Size(213, 21);
			this.checkBoxRandom1.TabIndex = 4;
			this.checkBoxRandom1.Text = "Include in Random Selection:";
			this.checkBoxRandom1.UseVisualStyleBackColor = true;
			this.checkBoxRandom1.Leave += new System.EventHandler(this.checkBoxRandom1_Leave);
			// 
			// label56
			// 
			this.label56.AutoSize = true;
			this.label56.Location = new System.Drawing.Point(581, 90);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(93, 17);
			this.label56.TabIndex = 81;
			this.label56.Text = "Effect Colour:";
			// 
			// checkBoxSnowFlakeColour6
			// 
			this.checkBoxSnowFlakeColour6.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxSnowFlakeColour6.Location = new System.Drawing.Point(722, 118);
			this.checkBoxSnowFlakeColour6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxSnowFlakeColour6.Name = "checkBoxSnowFlakeColour6";
			this.checkBoxSnowFlakeColour6.Size = new System.Drawing.Size(20, 18);
			this.checkBoxSnowFlakeColour6.TabIndex = 10;
			this.checkBoxSnowFlakeColour6.UseVisualStyleBackColor = true;
			this.checkBoxSnowFlakeColour6.Leave += new System.EventHandler(this.checkBoxSnowFlakeColour6_Leave);
			// 
			// checkBoxSnowFlakeColour5
			// 
			this.checkBoxSnowFlakeColour5.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxSnowFlakeColour5.Location = new System.Drawing.Point(674, 118);
			this.checkBoxSnowFlakeColour5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxSnowFlakeColour5.Name = "checkBoxSnowFlakeColour5";
			this.checkBoxSnowFlakeColour5.Size = new System.Drawing.Size(20, 18);
			this.checkBoxSnowFlakeColour5.TabIndex = 9;
			this.checkBoxSnowFlakeColour5.UseVisualStyleBackColor = true;
			this.checkBoxSnowFlakeColour5.Leave += new System.EventHandler(this.checkBoxSnowFlakeColour5_Leave);
			// 
			// checkBoxSnowFlakeColour4
			// 
			this.checkBoxSnowFlakeColour4.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxSnowFlakeColour4.Location = new System.Drawing.Point(629, 118);
			this.checkBoxSnowFlakeColour4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxSnowFlakeColour4.Name = "checkBoxSnowFlakeColour4";
			this.checkBoxSnowFlakeColour4.Size = new System.Drawing.Size(20, 18);
			this.checkBoxSnowFlakeColour4.TabIndex = 8;
			this.checkBoxSnowFlakeColour4.UseVisualStyleBackColor = true;
			this.checkBoxSnowFlakeColour4.Leave += new System.EventHandler(this.checkBoxSnowFlakeColour4_Leave);
			// 
			// SnowFlakeColour5
			// 
			this.SnowFlakeColour5.BackColor = System.Drawing.Color.Orange;
			this.SnowFlakeColour5.Location = new System.Drawing.Point(667, 139);
			this.SnowFlakeColour5.Margin = new System.Windows.Forms.Padding(0);
			this.SnowFlakeColour5.Name = "SnowFlakeColour5";
			this.SnowFlakeColour5.Size = new System.Drawing.Size(36, 32);
			this.SnowFlakeColour5.TabIndex = 15;
			this.toolTip1.SetToolTip(this.SnowFlakeColour5, "Select a colour to edit.");
			this.SnowFlakeColour5.UseVisualStyleBackColor = false;
			this.SnowFlakeColour5.Click += new System.EventHandler(this.SnowFlakeColour5_Click);
			// 
			// checkBoxSnowFlakeColour3
			// 
			this.checkBoxSnowFlakeColour3.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxSnowFlakeColour3.Location = new System.Drawing.Point(586, 118);
			this.checkBoxSnowFlakeColour3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxSnowFlakeColour3.Name = "checkBoxSnowFlakeColour3";
			this.checkBoxSnowFlakeColour3.Size = new System.Drawing.Size(20, 18);
			this.checkBoxSnowFlakeColour3.TabIndex = 7;
			this.checkBoxSnowFlakeColour3.UseVisualStyleBackColor = true;
			this.checkBoxSnowFlakeColour3.Leave += new System.EventHandler(this.checkBoxSnowFlakeColour3_Leave);
			// 
			// SnowFlakeColour6
			// 
			this.SnowFlakeColour6.BackColor = System.Drawing.Color.Pink;
			this.SnowFlakeColour6.Location = new System.Drawing.Point(715, 139);
			this.SnowFlakeColour6.Margin = new System.Windows.Forms.Padding(0);
			this.SnowFlakeColour6.Name = "SnowFlakeColour6";
			this.SnowFlakeColour6.Size = new System.Drawing.Size(36, 32);
			this.SnowFlakeColour6.TabIndex = 16;
			this.toolTip1.SetToolTip(this.SnowFlakeColour6, "Select a colour to edit.");
			this.SnowFlakeColour6.UseVisualStyleBackColor = false;
			this.SnowFlakeColour6.Click += new System.EventHandler(this.SnowFlakeColour6_Click);
			// 
			// checkBoxSnowFlakeColour2
			// 
			this.checkBoxSnowFlakeColour2.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxSnowFlakeColour2.Location = new System.Drawing.Point(544, 118);
			this.checkBoxSnowFlakeColour2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxSnowFlakeColour2.Name = "checkBoxSnowFlakeColour2";
			this.checkBoxSnowFlakeColour2.Size = new System.Drawing.Size(20, 18);
			this.checkBoxSnowFlakeColour2.TabIndex = 6;
			this.checkBoxSnowFlakeColour2.UseVisualStyleBackColor = true;
			this.checkBoxSnowFlakeColour2.Leave += new System.EventHandler(this.checkBoxSnowFlakeColour2_Leave);
			// 
			// SnowFlakeColour4
			// 
			this.SnowFlakeColour4.BackColor = System.Drawing.Color.Yellow;
			this.SnowFlakeColour4.Location = new System.Drawing.Point(622, 139);
			this.SnowFlakeColour4.Margin = new System.Windows.Forms.Padding(0);
			this.SnowFlakeColour4.Name = "SnowFlakeColour4";
			this.SnowFlakeColour4.Size = new System.Drawing.Size(36, 32);
			this.SnowFlakeColour4.TabIndex = 14;
			this.toolTip1.SetToolTip(this.SnowFlakeColour4, "Select a colour to edit.");
			this.SnowFlakeColour4.UseVisualStyleBackColor = false;
			this.SnowFlakeColour4.Click += new System.EventHandler(this.SnowFlakeColour4_Click);
			// 
			// checkBoxSnowFlakeColour1
			// 
			this.checkBoxSnowFlakeColour1.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxSnowFlakeColour1.Location = new System.Drawing.Point(505, 118);
			this.checkBoxSnowFlakeColour1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxSnowFlakeColour1.Name = "checkBoxSnowFlakeColour1";
			this.checkBoxSnowFlakeColour1.Size = new System.Drawing.Size(20, 18);
			this.checkBoxSnowFlakeColour1.TabIndex = 5;
			this.checkBoxSnowFlakeColour1.UseVisualStyleBackColor = true;
			this.checkBoxSnowFlakeColour1.Leave += new System.EventHandler(this.checkBoxSnowFlakeColour1_Leave);
			// 
			// SnowFlakeColour3
			// 
			this.SnowFlakeColour3.BackColor = System.Drawing.Color.Blue;
			this.SnowFlakeColour3.Location = new System.Drawing.Point(580, 139);
			this.SnowFlakeColour3.Margin = new System.Windows.Forms.Padding(0);
			this.SnowFlakeColour3.Name = "SnowFlakeColour3";
			this.SnowFlakeColour3.Size = new System.Drawing.Size(36, 32);
			this.SnowFlakeColour3.TabIndex = 13;
			this.toolTip1.SetToolTip(this.SnowFlakeColour3, "Select a colour to edit.");
			this.SnowFlakeColour3.UseVisualStyleBackColor = false;
			this.SnowFlakeColour3.Click += new System.EventHandler(this.SnowFlakeColour3_Click);
			// 
			// SnowFlakeColour1
			// 
			this.SnowFlakeColour1.BackColor = System.Drawing.Color.Red;
			this.SnowFlakeColour1.Location = new System.Drawing.Point(496, 139);
			this.SnowFlakeColour1.Margin = new System.Windows.Forms.Padding(0);
			this.SnowFlakeColour1.Name = "SnowFlakeColour1";
			this.SnowFlakeColour1.Size = new System.Drawing.Size(36, 32);
			this.SnowFlakeColour1.TabIndex = 11;
			this.toolTip1.SetToolTip(this.SnowFlakeColour1, "Select a colour to edit.");
			this.SnowFlakeColour1.UseVisualStyleBackColor = false;
			this.SnowFlakeColour1.Click += new System.EventHandler(this.SnowFlakeColour1_Click);
			// 
			// SnowFlakeColour2
			// 
			this.SnowFlakeColour2.BackColor = System.Drawing.Color.Lime;
			this.SnowFlakeColour2.Location = new System.Drawing.Point(537, 139);
			this.SnowFlakeColour2.Margin = new System.Windows.Forms.Padding(0);
			this.SnowFlakeColour2.Name = "SnowFlakeColour2";
			this.SnowFlakeColour2.Size = new System.Drawing.Size(36, 32);
			this.SnowFlakeColour2.TabIndex = 12;
			this.toolTip1.SetToolTip(this.SnowFlakeColour2, "Select a colour to edit.");
			this.SnowFlakeColour2.UseVisualStyleBackColor = false;
			this.SnowFlakeColour2.Click += new System.EventHandler(this.SnowFlakeColour2_Click);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(375, 130);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(53, 17);
			this.label17.TabIndex = 46;
			this.label17.Text = "Speed:";
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(9, 83);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(84, 17);
			this.label29.TabIndex = 39;
			this.label29.Text = "Effect Type:";
			// 
			// trackBarSpeedSnowFlakes
			// 
			this.trackBarSpeedSnowFlakes.AutoSize = false;
			this.trackBarSpeedSnowFlakes.Location = new System.Drawing.Point(435, 5);
			this.trackBarSpeedSnowFlakes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarSpeedSnowFlakes.Maximum = 20;
			this.trackBarSpeedSnowFlakes.Minimum = 1;
			this.trackBarSpeedSnowFlakes.Name = "trackBarSpeedSnowFlakes";
			this.trackBarSpeedSnowFlakes.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBarSpeedSnowFlakes.Size = new System.Drawing.Size(36, 169);
			this.trackBarSpeedSnowFlakes.TabIndex = 3;
			this.trackBarSpeedSnowFlakes.Value = 5;
			this.trackBarSpeedSnowFlakes.Scroll += new System.EventHandler(this.trackBarSpeedSnowFlakes_Scroll);
			this.trackBarSpeedSnowFlakes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarSpeedSnowFlakes_MouseDown);
			this.trackBarSpeedSnowFlakes.MouseLeave += new System.EventHandler(this.trackBarSpeedSnowFlakes_MouseLeave);
			this.trackBarSpeedSnowFlakes.MouseHover += new System.EventHandler(this.trackBarSpeedSnowFlakes_MouseHover);
			// 
			// EffectType
			// 
			this.EffectType.Location = new System.Drawing.Point(144, 82);
			this.EffectType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.EffectType.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.EffectType.Name = "EffectType";
			this.EffectType.Size = new System.Drawing.Size(64, 22);
			this.EffectType.TabIndex = 0;
			this.EffectType.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.EffectType.Leave += new System.EventHandler(this.EffectType_Leave);
			// 
			// MaxSnowFlake
			// 
			this.MaxSnowFlake.Location = new System.Drawing.Point(144, 117);
			this.MaxSnowFlake.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaxSnowFlake.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
			this.MaxSnowFlake.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MaxSnowFlake.Name = "MaxSnowFlake";
			this.MaxSnowFlake.Size = new System.Drawing.Size(64, 22);
			this.MaxSnowFlake.TabIndex = 1;
			this.MaxSnowFlake.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
			this.MaxSnowFlake.Leave += new System.EventHandler(this.MaxSnowFlake_Leave);
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(9, 118);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(105, 17);
			this.label30.TabIndex = 41;
			this.label30.Text = "Max Snowflake:";
			// 
			// tabPageFire
			// 
			this.tabPageFire.BackColor = System.Drawing.Color.Azure;
			this.tabPageFire.Controls.Add(this.label104);
			this.tabPageFire.Controls.Add(this.comboBoxFireName);
			this.tabPageFire.Controls.Add(this.buttonRemoveFire);
			this.tabPageFire.Controls.Add(this.buttonAddFire);
			this.tabPageFire.Controls.Add(this.buttonPlayFire);
			this.tabPageFire.Controls.Add(this.checkBoxRandom2);
			this.tabPageFire.Controls.Add(this.FireHeight);
			this.tabPageFire.Controls.Add(this.label31);
			this.tabPageFire.Location = new System.Drawing.Point(4, 25);
			this.tabPageFire.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageFire.Name = "tabPageFire";
			this.tabPageFire.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageFire.Size = new System.Drawing.Size(762, 177);
			this.tabPageFire.TabIndex = 1;
			this.tabPageFire.Text = "Fire";
			// 
			// label104
			// 
			this.label104.AutoSize = true;
			this.label104.Location = new System.Drawing.Point(9, 8);
			this.label104.Name = "label104";
			this.label104.Size = new System.Drawing.Size(77, 17);
			this.label104.TabIndex = 93;
			this.label104.Text = "Fire Name:";
			// 
			// comboBoxFireName
			// 
			this.comboBoxFireName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFireName.FormattingEnabled = true;
			this.comboBoxFireName.Location = new System.Drawing.Point(12, 32);
			this.comboBoxFireName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxFireName.Name = "comboBoxFireName";
			this.comboBoxFireName.Size = new System.Drawing.Size(254, 24);
			this.comboBoxFireName.TabIndex = 90;
			this.toolTip1.SetToolTip(this.comboBoxFireName, "List of all Fire effects that have been created.");
			this.comboBoxFireName.SelectedIndexChanged += new System.EventHandler(this.comboBoxFireName_SelectedIndexChanged);
			// 
			// buttonRemoveFire
			// 
			this.buttonRemoveFire.BackColor = System.Drawing.Color.Azure;
			this.buttonRemoveFire.FlatAppearance.BorderSize = 0;
			this.buttonRemoveFire.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveFire.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveFire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveFire.Location = new System.Drawing.Point(324, 27);
			this.buttonRemoveFire.Margin = new System.Windows.Forms.Padding(0);
			this.buttonRemoveFire.Name = "buttonRemoveFire";
			this.buttonRemoveFire.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveFire.TabIndex = 92;
			this.buttonRemoveFire.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveFire, "Delete selected effect.");
			this.buttonRemoveFire.UseVisualStyleBackColor = false;
			this.buttonRemoveFire.Click += new System.EventHandler(this.buttonRemoveFire_Click);
			// 
			// buttonAddFire
			// 
			this.buttonAddFire.BackColor = System.Drawing.Color.Azure;
			this.buttonAddFire.FlatAppearance.BorderSize = 0;
			this.buttonAddFire.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonAddFire.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonAddFire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAddFire.Location = new System.Drawing.Point(278, 27);
			this.buttonAddFire.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAddFire.Name = "buttonAddFire";
			this.buttonAddFire.Size = new System.Drawing.Size(34, 30);
			this.buttonAddFire.TabIndex = 91;
			this.buttonAddFire.Text = "+";
			this.toolTip1.SetToolTip(this.buttonAddFire, "Create new Fire effect.");
			this.buttonAddFire.UseVisualStyleBackColor = false;
			this.buttonAddFire.Click += new System.EventHandler(this.buttonAddFire_Click);
			// 
			// buttonPlayFire
			// 
			this.buttonPlayFire.BackColor = System.Drawing.Color.Azure;
			this.buttonPlayFire.FlatAppearance.BorderSize = 0;
			this.buttonPlayFire.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonPlayFire.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonPlayFire.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPlayFire.Location = new System.Drawing.Point(369, 27);
			this.buttonPlayFire.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPlayFire.Name = "buttonPlayFire";
			this.buttonPlayFire.Size = new System.Drawing.Size(34, 30);
			this.buttonPlayFire.TabIndex = 89;
			this.buttonPlayFire.Text = "P";
			this.toolTip1.SetToolTip(this.buttonPlayFire, "Play selected Effect. Useful for testing current Effect with no text.");
			this.buttonPlayFire.UseVisualStyleBackColor = false;
			this.buttonPlayFire.Click += new System.EventHandler(this.buttonPlayFire_Click);
			// 
			// checkBoxRandom2
			// 
			this.checkBoxRandom2.AutoSize = true;
			this.checkBoxRandom2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRandom2.Location = new System.Drawing.Point(505, 5);
			this.checkBoxRandom2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxRandom2.Name = "checkBoxRandom2";
			this.checkBoxRandom2.Size = new System.Drawing.Size(213, 21);
			this.checkBoxRandom2.TabIndex = 51;
			this.checkBoxRandom2.Text = "Include in Random Selection:";
			this.checkBoxRandom2.UseVisualStyleBackColor = true;
			// 
			// FireHeight
			// 
			this.FireHeight.Location = new System.Drawing.Point(144, 76);
			this.FireHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.FireHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.FireHeight.Name = "FireHeight";
			this.FireHeight.Size = new System.Drawing.Size(64, 22);
			this.FireHeight.TabIndex = 1;
			this.FireHeight.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.FireHeight.Leave += new System.EventHandler(this.FireHeight_Leave);
			// 
			// label31
			// 
			this.label31.AutoSize = true;
			this.label31.Location = new System.Drawing.Point(12, 78);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(81, 17);
			this.label31.TabIndex = 43;
			this.label31.Text = "Fire Height:";
			// 
			// tabPageMeteors
			// 
			this.tabPageMeteors.BackColor = System.Drawing.Color.Azure;
			this.tabPageMeteors.Controls.Add(this.buttonPlayMeteor);
			this.tabPageMeteors.Controls.Add(this.label102);
			this.tabPageMeteors.Controls.Add(this.comboBoxMeteorName);
			this.tabPageMeteors.Controls.Add(this.buttonRemoveMeteor);
			this.tabPageMeteors.Controls.Add(this.buttonAddMeteor);
			this.tabPageMeteors.Controls.Add(this.checkBoxRandom3);
			this.tabPageMeteors.Controls.Add(this.label55);
			this.tabPageMeteors.Controls.Add(this.checkBoxMeteorColour6);
			this.tabPageMeteors.Controls.Add(this.checkBoxMeteorColour5);
			this.tabPageMeteors.Controls.Add(this.checkBoxMeteorColour4);
			this.tabPageMeteors.Controls.Add(this.MeteorColour5);
			this.tabPageMeteors.Controls.Add(this.checkBoxMeteorColour3);
			this.tabPageMeteors.Controls.Add(this.MeteorColour6);
			this.tabPageMeteors.Controls.Add(this.checkBoxMeteorColour2);
			this.tabPageMeteors.Controls.Add(this.MeteorColour4);
			this.tabPageMeteors.Controls.Add(this.checkBoxMeteorColour1);
			this.tabPageMeteors.Controls.Add(this.MeteorColour3);
			this.tabPageMeteors.Controls.Add(this.MeteorColour1);
			this.tabPageMeteors.Controls.Add(this.MeteorColour2);
			this.tabPageMeteors.Controls.Add(this.label18);
			this.tabPageMeteors.Controls.Add(this.trackBarSpeedMeteors);
			this.tabPageMeteors.Controls.Add(this.MeteorColour);
			this.tabPageMeteors.Controls.Add(this.label35);
			this.tabPageMeteors.Controls.Add(this.MeteorTrailLength);
			this.tabPageMeteors.Controls.Add(this.label34);
			this.tabPageMeteors.Controls.Add(this.MeteorCount);
			this.tabPageMeteors.Controls.Add(this.label33);
			this.tabPageMeteors.Location = new System.Drawing.Point(4, 25);
			this.tabPageMeteors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageMeteors.Name = "tabPageMeteors";
			this.tabPageMeteors.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageMeteors.Size = new System.Drawing.Size(762, 177);
			this.tabPageMeteors.TabIndex = 2;
			this.tabPageMeteors.Text = "Meteors";
			// 
			// buttonPlayMeteor
			// 
			this.buttonPlayMeteor.BackColor = System.Drawing.Color.Azure;
			this.buttonPlayMeteor.FlatAppearance.BorderSize = 0;
			this.buttonPlayMeteor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonPlayMeteor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonPlayMeteor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPlayMeteor.Location = new System.Drawing.Point(369, 27);
			this.buttonPlayMeteor.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPlayMeteor.Name = "buttonPlayMeteor";
			this.buttonPlayMeteor.Size = new System.Drawing.Size(34, 30);
			this.buttonPlayMeteor.TabIndex = 93;
			this.buttonPlayMeteor.Text = "P";
			this.toolTip1.SetToolTip(this.buttonPlayMeteor, "Play selected Effect. Useful for testing current Effect with no text.");
			this.buttonPlayMeteor.UseVisualStyleBackColor = false;
			this.buttonPlayMeteor.Click += new System.EventHandler(this.buttonPlayMeteor_Click);
			// 
			// label102
			// 
			this.label102.AutoSize = true;
			this.label102.Location = new System.Drawing.Point(9, 8);
			this.label102.Name = "label102";
			this.label102.Size = new System.Drawing.Size(97, 17);
			this.label102.TabIndex = 94;
			this.label102.Text = "Meteor Name:";
			// 
			// comboBoxMeteorName
			// 
			this.comboBoxMeteorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxMeteorName.FormattingEnabled = true;
			this.comboBoxMeteorName.Location = new System.Drawing.Point(12, 32);
			this.comboBoxMeteorName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxMeteorName.Name = "comboBoxMeteorName";
			this.comboBoxMeteorName.Size = new System.Drawing.Size(254, 24);
			this.comboBoxMeteorName.TabIndex = 90;
			this.toolTip1.SetToolTip(this.comboBoxMeteorName, "List of all Meteor effects that have been created.");
			this.comboBoxMeteorName.SelectedIndexChanged += new System.EventHandler(this.comboBoxMeteorName_SelectedIndexChanged);
			// 
			// buttonRemoveMeteor
			// 
			this.buttonRemoveMeteor.BackColor = System.Drawing.Color.Azure;
			this.buttonRemoveMeteor.FlatAppearance.BorderSize = 0;
			this.buttonRemoveMeteor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveMeteor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveMeteor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveMeteor.Location = new System.Drawing.Point(324, 27);
			this.buttonRemoveMeteor.Margin = new System.Windows.Forms.Padding(0);
			this.buttonRemoveMeteor.Name = "buttonRemoveMeteor";
			this.buttonRemoveMeteor.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveMeteor.TabIndex = 92;
			this.buttonRemoveMeteor.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveMeteor, "Delete selected effect.");
			this.buttonRemoveMeteor.UseVisualStyleBackColor = false;
			this.buttonRemoveMeteor.Click += new System.EventHandler(this.buttonRemoveMeteor_Click);
			// 
			// buttonAddMeteor
			// 
			this.buttonAddMeteor.BackColor = System.Drawing.Color.Azure;
			this.buttonAddMeteor.FlatAppearance.BorderSize = 0;
			this.buttonAddMeteor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonAddMeteor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonAddMeteor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAddMeteor.Location = new System.Drawing.Point(278, 27);
			this.buttonAddMeteor.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAddMeteor.Name = "buttonAddMeteor";
			this.buttonAddMeteor.Size = new System.Drawing.Size(34, 30);
			this.buttonAddMeteor.TabIndex = 91;
			this.buttonAddMeteor.Text = "+";
			this.toolTip1.SetToolTip(this.buttonAddMeteor, "Create new Meteor effect.");
			this.buttonAddMeteor.UseVisualStyleBackColor = false;
			this.buttonAddMeteor.Click += new System.EventHandler(this.buttonAddMeteor_Click);
			// 
			// checkBoxRandom3
			// 
			this.checkBoxRandom3.AutoSize = true;
			this.checkBoxRandom3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRandom3.Location = new System.Drawing.Point(505, 5);
			this.checkBoxRandom3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxRandom3.Name = "checkBoxRandom3";
			this.checkBoxRandom3.Size = new System.Drawing.Size(213, 21);
			this.checkBoxRandom3.TabIndex = 82;
			this.checkBoxRandom3.Text = "Include in Random Selection:";
			this.checkBoxRandom3.UseVisualStyleBackColor = true;
			this.checkBoxRandom3.Leave += new System.EventHandler(this.checkBoxRandom3_Leave);
			// 
			// label55
			// 
			this.label55.AutoSize = true;
			this.label55.Location = new System.Drawing.Point(581, 90);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(93, 17);
			this.label55.TabIndex = 81;
			this.label55.Text = "Effect Colour:";
			// 
			// checkBoxMeteorColour6
			// 
			this.checkBoxMeteorColour6.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxMeteorColour6.Location = new System.Drawing.Point(722, 118);
			this.checkBoxMeteorColour6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxMeteorColour6.Name = "checkBoxMeteorColour6";
			this.checkBoxMeteorColour6.Size = new System.Drawing.Size(20, 18);
			this.checkBoxMeteorColour6.TabIndex = 80;
			this.checkBoxMeteorColour6.UseVisualStyleBackColor = true;
			this.checkBoxMeteorColour6.Leave += new System.EventHandler(this.checkBoxMeteorColour6_Leave);
			// 
			// checkBoxMeteorColour5
			// 
			this.checkBoxMeteorColour5.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxMeteorColour5.Location = new System.Drawing.Point(674, 118);
			this.checkBoxMeteorColour5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxMeteorColour5.Name = "checkBoxMeteorColour5";
			this.checkBoxMeteorColour5.Size = new System.Drawing.Size(20, 18);
			this.checkBoxMeteorColour5.TabIndex = 79;
			this.checkBoxMeteorColour5.UseVisualStyleBackColor = true;
			this.checkBoxMeteorColour5.Leave += new System.EventHandler(this.checkBoxMeteorColour5_Leave);
			// 
			// checkBoxMeteorColour4
			// 
			this.checkBoxMeteorColour4.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxMeteorColour4.Location = new System.Drawing.Point(629, 118);
			this.checkBoxMeteorColour4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxMeteorColour4.Name = "checkBoxMeteorColour4";
			this.checkBoxMeteorColour4.Size = new System.Drawing.Size(20, 18);
			this.checkBoxMeteorColour4.TabIndex = 78;
			this.checkBoxMeteorColour4.UseVisualStyleBackColor = true;
			this.checkBoxMeteorColour4.Leave += new System.EventHandler(this.checkBoxMeteorColour4_Leave);
			// 
			// MeteorColour5
			// 
			this.MeteorColour5.BackColor = System.Drawing.Color.Orange;
			this.MeteorColour5.Location = new System.Drawing.Point(667, 139);
			this.MeteorColour5.Margin = new System.Windows.Forms.Padding(0);
			this.MeteorColour5.Name = "MeteorColour5";
			this.MeteorColour5.Size = new System.Drawing.Size(36, 32);
			this.MeteorColour5.TabIndex = 73;
			this.toolTip1.SetToolTip(this.MeteorColour5, "Select a colour to edit.");
			this.MeteorColour5.UseVisualStyleBackColor = false;
			this.MeteorColour5.Click += new System.EventHandler(this.MeteorColour5_Click);
			// 
			// checkBoxMeteorColour3
			// 
			this.checkBoxMeteorColour3.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxMeteorColour3.Location = new System.Drawing.Point(586, 118);
			this.checkBoxMeteorColour3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxMeteorColour3.Name = "checkBoxMeteorColour3";
			this.checkBoxMeteorColour3.Size = new System.Drawing.Size(20, 18);
			this.checkBoxMeteorColour3.TabIndex = 77;
			this.checkBoxMeteorColour3.UseVisualStyleBackColor = true;
			this.checkBoxMeteorColour3.Leave += new System.EventHandler(this.checkBoxMeteorColour3_Leave);
			// 
			// MeteorColour6
			// 
			this.MeteorColour6.BackColor = System.Drawing.Color.Pink;
			this.MeteorColour6.Location = new System.Drawing.Point(715, 139);
			this.MeteorColour6.Margin = new System.Windows.Forms.Padding(0);
			this.MeteorColour6.Name = "MeteorColour6";
			this.MeteorColour6.Size = new System.Drawing.Size(36, 32);
			this.MeteorColour6.TabIndex = 74;
			this.toolTip1.SetToolTip(this.MeteorColour6, "Select a colour to edit.");
			this.MeteorColour6.UseVisualStyleBackColor = false;
			this.MeteorColour6.Click += new System.EventHandler(this.MeteorColour6_Click);
			// 
			// checkBoxMeteorColour2
			// 
			this.checkBoxMeteorColour2.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxMeteorColour2.Location = new System.Drawing.Point(544, 118);
			this.checkBoxMeteorColour2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxMeteorColour2.Name = "checkBoxMeteorColour2";
			this.checkBoxMeteorColour2.Size = new System.Drawing.Size(20, 18);
			this.checkBoxMeteorColour2.TabIndex = 76;
			this.checkBoxMeteorColour2.UseVisualStyleBackColor = true;
			this.checkBoxMeteorColour2.Leave += new System.EventHandler(this.checkBoxMeteorColour2_Leave);
			// 
			// MeteorColour4
			// 
			this.MeteorColour4.BackColor = System.Drawing.Color.Yellow;
			this.MeteorColour4.Location = new System.Drawing.Point(622, 139);
			this.MeteorColour4.Margin = new System.Windows.Forms.Padding(0);
			this.MeteorColour4.Name = "MeteorColour4";
			this.MeteorColour4.Size = new System.Drawing.Size(36, 32);
			this.MeteorColour4.TabIndex = 72;
			this.toolTip1.SetToolTip(this.MeteorColour4, "Select a colour to edit.");
			this.MeteorColour4.UseVisualStyleBackColor = false;
			this.MeteorColour4.Click += new System.EventHandler(this.MeteorColour4_Click);
			// 
			// checkBoxMeteorColour1
			// 
			this.checkBoxMeteorColour1.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxMeteorColour1.Location = new System.Drawing.Point(505, 118);
			this.checkBoxMeteorColour1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxMeteorColour1.Name = "checkBoxMeteorColour1";
			this.checkBoxMeteorColour1.Size = new System.Drawing.Size(20, 18);
			this.checkBoxMeteorColour1.TabIndex = 75;
			this.checkBoxMeteorColour1.UseVisualStyleBackColor = true;
			this.checkBoxMeteorColour1.Leave += new System.EventHandler(this.checkBoxMeteorColour1_Leave);
			// 
			// MeteorColour3
			// 
			this.MeteorColour3.BackColor = System.Drawing.Color.Blue;
			this.MeteorColour3.Location = new System.Drawing.Point(580, 139);
			this.MeteorColour3.Margin = new System.Windows.Forms.Padding(0);
			this.MeteorColour3.Name = "MeteorColour3";
			this.MeteorColour3.Size = new System.Drawing.Size(36, 32);
			this.MeteorColour3.TabIndex = 71;
			this.toolTip1.SetToolTip(this.MeteorColour3, "Select a colour to edit.");
			this.MeteorColour3.UseVisualStyleBackColor = false;
			this.MeteorColour3.Click += new System.EventHandler(this.MeteorColour3_Click);
			// 
			// MeteorColour1
			// 
			this.MeteorColour1.BackColor = System.Drawing.Color.Red;
			this.MeteorColour1.Location = new System.Drawing.Point(496, 139);
			this.MeteorColour1.Margin = new System.Windows.Forms.Padding(0);
			this.MeteorColour1.Name = "MeteorColour1";
			this.MeteorColour1.Size = new System.Drawing.Size(36, 32);
			this.MeteorColour1.TabIndex = 69;
			this.toolTip1.SetToolTip(this.MeteorColour1, "Select a colour to edit.");
			this.MeteorColour1.UseVisualStyleBackColor = false;
			this.MeteorColour1.Click += new System.EventHandler(this.MeteorColour1_Click);
			// 
			// MeteorColour2
			// 
			this.MeteorColour2.BackColor = System.Drawing.Color.Lime;
			this.MeteorColour2.Location = new System.Drawing.Point(537, 139);
			this.MeteorColour2.Margin = new System.Windows.Forms.Padding(0);
			this.MeteorColour2.Name = "MeteorColour2";
			this.MeteorColour2.Size = new System.Drawing.Size(36, 32);
			this.MeteorColour2.TabIndex = 70;
			this.toolTip1.SetToolTip(this.MeteorColour2, "Select a colour to edit.");
			this.MeteorColour2.UseVisualStyleBackColor = false;
			this.MeteorColour2.Click += new System.EventHandler(this.MeteorColour2_Click);
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(375, 130);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(53, 17);
			this.label18.TabIndex = 51;
			this.label18.Text = "Speed:";
			// 
			// trackBarSpeedMeteors
			// 
			this.trackBarSpeedMeteors.AutoSize = false;
			this.trackBarSpeedMeteors.Location = new System.Drawing.Point(435, 6);
			this.trackBarSpeedMeteors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarSpeedMeteors.Maximum = 20;
			this.trackBarSpeedMeteors.Minimum = 1;
			this.trackBarSpeedMeteors.Name = "trackBarSpeedMeteors";
			this.trackBarSpeedMeteors.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBarSpeedMeteors.Size = new System.Drawing.Size(36, 166);
			this.trackBarSpeedMeteors.TabIndex = 4;
			this.trackBarSpeedMeteors.Value = 5;
			this.trackBarSpeedMeteors.Scroll += new System.EventHandler(this.trackBarSpeedMeteors_Scroll);
			this.trackBarSpeedMeteors.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarSpeedMeteors_MouseDown);
			this.trackBarSpeedMeteors.MouseLeave += new System.EventHandler(this.trackBarSpeedMeteors_MouseLeave);
			this.trackBarSpeedMeteors.MouseHover += new System.EventHandler(this.trackBarSpeedMeteors_MouseHover);
			// 
			// MeteorColour
			// 
			this.MeteorColour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.MeteorColour.FormattingEnabled = true;
			this.MeteorColour.Items.AddRange(new object[] {
            "Rainbow",
            "Range",
            "Palette"});
			this.MeteorColour.Location = new System.Drawing.Point(121, 66);
			this.MeteorColour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MeteorColour.Name = "MeteorColour";
			this.MeteorColour.Size = new System.Drawing.Size(120, 24);
			this.MeteorColour.TabIndex = 1;
			this.MeteorColour.SelectionChangeCommitted += new System.EventHandler(this.MeteorColour_SelectionChangeCommitted);
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Location = new System.Drawing.Point(9, 69);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(89, 17);
			this.label35.TabIndex = 48;
			this.label35.Text = "Colour Type:";
			// 
			// MeteorTrailLength
			// 
			this.MeteorTrailLength.Location = new System.Drawing.Point(121, 146);
			this.MeteorTrailLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MeteorTrailLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MeteorTrailLength.Name = "MeteorTrailLength";
			this.MeteorTrailLength.Size = new System.Drawing.Size(64, 22);
			this.MeteorTrailLength.TabIndex = 3;
			this.MeteorTrailLength.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
			this.MeteorTrailLength.Leave += new System.EventHandler(this.MeteorTrailLength_Leave);
			// 
			// label34
			// 
			this.label34.AutoSize = true;
			this.label34.Location = new System.Drawing.Point(9, 146);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(88, 17);
			this.label34.TabIndex = 47;
			this.label34.Text = "Trail Length:";
			// 
			// MeteorCount
			// 
			this.MeteorCount.Location = new System.Drawing.Point(121, 102);
			this.MeteorCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MeteorCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MeteorCount.Name = "MeteorCount";
			this.MeteorCount.Size = new System.Drawing.Size(64, 22);
			this.MeteorCount.TabIndex = 2;
			this.MeteorCount.Value = new decimal(new int[] {
            11,
            0,
            0,
            0});
			this.MeteorCount.Leave += new System.EventHandler(this.MeteorCount_Leave);
			// 
			// label33
			// 
			this.label33.AutoSize = true;
			this.label33.Location = new System.Drawing.Point(9, 103);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(49, 17);
			this.label33.TabIndex = 45;
			this.label33.Text = "Count:";
			// 
			// tabPageTwinkles
			// 
			this.tabPageTwinkles.BackColor = System.Drawing.Color.Azure;
			this.tabPageTwinkles.Controls.Add(this.buttonPlayTwinkle);
			this.tabPageTwinkles.Controls.Add(this.label103);
			this.tabPageTwinkles.Controls.Add(this.comboBoxTwinkleName);
			this.tabPageTwinkles.Controls.Add(this.buttonRemoveTwinkle);
			this.tabPageTwinkles.Controls.Add(this.buttonAddTwinkle);
			this.tabPageTwinkles.Controls.Add(this.checkBoxRandom4);
			this.tabPageTwinkles.Controls.Add(this.label54);
			this.tabPageTwinkles.Controls.Add(this.checkBoxTwinkleColour6);
			this.tabPageTwinkles.Controls.Add(this.checkBoxTwinkleColour5);
			this.tabPageTwinkles.Controls.Add(this.checkBoxTwinkleColour4);
			this.tabPageTwinkles.Controls.Add(this.TwinkleColour5);
			this.tabPageTwinkles.Controls.Add(this.checkBoxTwinkleColour3);
			this.tabPageTwinkles.Controls.Add(this.TwinkleColour6);
			this.tabPageTwinkles.Controls.Add(this.checkBoxTwinkleColour2);
			this.tabPageTwinkles.Controls.Add(this.TwinkleColour4);
			this.tabPageTwinkles.Controls.Add(this.checkBoxTwinkleColour1);
			this.tabPageTwinkles.Controls.Add(this.TwinkleColour3);
			this.tabPageTwinkles.Controls.Add(this.TwinkleColour1);
			this.tabPageTwinkles.Controls.Add(this.TwinkleColour2);
			this.tabPageTwinkles.Controls.Add(this.label53);
			this.tabPageTwinkles.Controls.Add(this.trackBarSpeedTwinkles);
			this.tabPageTwinkles.Controls.Add(this.label52);
			this.tabPageTwinkles.Controls.Add(this.label51);
			this.tabPageTwinkles.Controls.Add(this.trackBarTwinkleSteps);
			this.tabPageTwinkles.Controls.Add(this.trackBarTwinkleLights);
			this.tabPageTwinkles.Location = new System.Drawing.Point(4, 25);
			this.tabPageTwinkles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageTwinkles.Name = "tabPageTwinkles";
			this.tabPageTwinkles.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageTwinkles.Size = new System.Drawing.Size(762, 177);
			this.tabPageTwinkles.TabIndex = 3;
			this.tabPageTwinkles.Text = "Twinkles";
			// 
			// buttonPlayTwinkle
			// 
			this.buttonPlayTwinkle.BackColor = System.Drawing.Color.Azure;
			this.buttonPlayTwinkle.FlatAppearance.BorderSize = 0;
			this.buttonPlayTwinkle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonPlayTwinkle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonPlayTwinkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPlayTwinkle.Location = new System.Drawing.Point(369, 27);
			this.buttonPlayTwinkle.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPlayTwinkle.Name = "buttonPlayTwinkle";
			this.buttonPlayTwinkle.Size = new System.Drawing.Size(34, 30);
			this.buttonPlayTwinkle.TabIndex = 98;
			this.buttonPlayTwinkle.Text = "P";
			this.toolTip1.SetToolTip(this.buttonPlayTwinkle, "Play selected Effect. Useful for testing current Effect with no text.");
			this.buttonPlayTwinkle.UseVisualStyleBackColor = false;
			this.buttonPlayTwinkle.Click += new System.EventHandler(this.buttonPlayTwinkle_Click);
			// 
			// label103
			// 
			this.label103.AutoSize = true;
			this.label103.Location = new System.Drawing.Point(9, 8);
			this.label103.Name = "label103";
			this.label103.Size = new System.Drawing.Size(100, 17);
			this.label103.TabIndex = 99;
			this.label103.Text = "Twinkle Name:";
			// 
			// comboBoxTwinkleName
			// 
			this.comboBoxTwinkleName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxTwinkleName.FormattingEnabled = true;
			this.comboBoxTwinkleName.Location = new System.Drawing.Point(12, 32);
			this.comboBoxTwinkleName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxTwinkleName.Name = "comboBoxTwinkleName";
			this.comboBoxTwinkleName.Size = new System.Drawing.Size(254, 24);
			this.comboBoxTwinkleName.TabIndex = 95;
			this.toolTip1.SetToolTip(this.comboBoxTwinkleName, "List of all Twinkle effects that have been created.");
			this.comboBoxTwinkleName.SelectedIndexChanged += new System.EventHandler(this.comboBoxTwinkleName_SelectedIndexChanged);
			// 
			// buttonRemoveTwinkle
			// 
			this.buttonRemoveTwinkle.BackColor = System.Drawing.Color.Azure;
			this.buttonRemoveTwinkle.FlatAppearance.BorderSize = 0;
			this.buttonRemoveTwinkle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveTwinkle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveTwinkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveTwinkle.Location = new System.Drawing.Point(324, 27);
			this.buttonRemoveTwinkle.Margin = new System.Windows.Forms.Padding(0);
			this.buttonRemoveTwinkle.Name = "buttonRemoveTwinkle";
			this.buttonRemoveTwinkle.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveTwinkle.TabIndex = 97;
			this.buttonRemoveTwinkle.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveTwinkle, "Delete selected effect.");
			this.buttonRemoveTwinkle.UseVisualStyleBackColor = false;
			this.buttonRemoveTwinkle.Click += new System.EventHandler(this.buttonRemoveTwinkle_Click);
			// 
			// buttonAddTwinkle
			// 
			this.buttonAddTwinkle.BackColor = System.Drawing.Color.Azure;
			this.buttonAddTwinkle.FlatAppearance.BorderSize = 0;
			this.buttonAddTwinkle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonAddTwinkle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonAddTwinkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAddTwinkle.Location = new System.Drawing.Point(278, 27);
			this.buttonAddTwinkle.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAddTwinkle.Name = "buttonAddTwinkle";
			this.buttonAddTwinkle.Size = new System.Drawing.Size(34, 30);
			this.buttonAddTwinkle.TabIndex = 96;
			this.buttonAddTwinkle.Text = "+";
			this.toolTip1.SetToolTip(this.buttonAddTwinkle, "Create new Twinkle effect.");
			this.buttonAddTwinkle.UseVisualStyleBackColor = false;
			this.buttonAddTwinkle.Click += new System.EventHandler(this.buttonAddTwinkle_Click);
			// 
			// checkBoxRandom4
			// 
			this.checkBoxRandom4.AutoSize = true;
			this.checkBoxRandom4.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRandom4.Location = new System.Drawing.Point(505, 5);
			this.checkBoxRandom4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxRandom4.Name = "checkBoxRandom4";
			this.checkBoxRandom4.Size = new System.Drawing.Size(213, 21);
			this.checkBoxRandom4.TabIndex = 69;
			this.checkBoxRandom4.Text = "Include in Random Selection:";
			this.checkBoxRandom4.UseVisualStyleBackColor = true;
			this.checkBoxRandom4.Leave += new System.EventHandler(this.checkBoxRandom4_Leave);
			// 
			// label54
			// 
			this.label54.AutoSize = true;
			this.label54.Location = new System.Drawing.Point(581, 90);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(93, 17);
			this.label54.TabIndex = 68;
			this.label54.Text = "Effect Colour:";
			// 
			// checkBoxTwinkleColour6
			// 
			this.checkBoxTwinkleColour6.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxTwinkleColour6.Location = new System.Drawing.Point(722, 118);
			this.checkBoxTwinkleColour6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxTwinkleColour6.Name = "checkBoxTwinkleColour6";
			this.checkBoxTwinkleColour6.Size = new System.Drawing.Size(20, 18);
			this.checkBoxTwinkleColour6.TabIndex = 67;
			this.checkBoxTwinkleColour6.UseVisualStyleBackColor = true;
			// 
			// checkBoxTwinkleColour5
			// 
			this.checkBoxTwinkleColour5.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxTwinkleColour5.Location = new System.Drawing.Point(674, 118);
			this.checkBoxTwinkleColour5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxTwinkleColour5.Name = "checkBoxTwinkleColour5";
			this.checkBoxTwinkleColour5.Size = new System.Drawing.Size(20, 18);
			this.checkBoxTwinkleColour5.TabIndex = 66;
			this.checkBoxTwinkleColour5.UseVisualStyleBackColor = true;
			// 
			// checkBoxTwinkleColour4
			// 
			this.checkBoxTwinkleColour4.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxTwinkleColour4.Location = new System.Drawing.Point(629, 118);
			this.checkBoxTwinkleColour4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxTwinkleColour4.Name = "checkBoxTwinkleColour4";
			this.checkBoxTwinkleColour4.Size = new System.Drawing.Size(20, 18);
			this.checkBoxTwinkleColour4.TabIndex = 65;
			this.checkBoxTwinkleColour4.UseVisualStyleBackColor = true;
			// 
			// TwinkleColour5
			// 
			this.TwinkleColour5.BackColor = System.Drawing.Color.Orange;
			this.TwinkleColour5.Location = new System.Drawing.Point(667, 139);
			this.TwinkleColour5.Margin = new System.Windows.Forms.Padding(0);
			this.TwinkleColour5.Name = "TwinkleColour5";
			this.TwinkleColour5.Size = new System.Drawing.Size(36, 32);
			this.TwinkleColour5.TabIndex = 60;
			this.toolTip1.SetToolTip(this.TwinkleColour5, "Select a colour to edit.");
			this.TwinkleColour5.UseVisualStyleBackColor = false;
			this.TwinkleColour5.Click += new System.EventHandler(this.TwinkleColour5_Click);
			this.TwinkleColour5.Leave += new System.EventHandler(this.checkBoxTwinkleColour5_Leave);
			// 
			// checkBoxTwinkleColour3
			// 
			this.checkBoxTwinkleColour3.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxTwinkleColour3.Location = new System.Drawing.Point(586, 118);
			this.checkBoxTwinkleColour3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxTwinkleColour3.Name = "checkBoxTwinkleColour3";
			this.checkBoxTwinkleColour3.Size = new System.Drawing.Size(20, 18);
			this.checkBoxTwinkleColour3.TabIndex = 64;
			this.checkBoxTwinkleColour3.UseVisualStyleBackColor = true;
			// 
			// TwinkleColour6
			// 
			this.TwinkleColour6.BackColor = System.Drawing.Color.Pink;
			this.TwinkleColour6.Location = new System.Drawing.Point(715, 139);
			this.TwinkleColour6.Margin = new System.Windows.Forms.Padding(0);
			this.TwinkleColour6.Name = "TwinkleColour6";
			this.TwinkleColour6.Size = new System.Drawing.Size(36, 32);
			this.TwinkleColour6.TabIndex = 61;
			this.toolTip1.SetToolTip(this.TwinkleColour6, "Select a colour to edit.");
			this.TwinkleColour6.UseVisualStyleBackColor = false;
			this.TwinkleColour6.Click += new System.EventHandler(this.TwinkleColour6_Click);
			this.TwinkleColour6.Leave += new System.EventHandler(this.checkBoxTwinkleColour6_Leave);
			// 
			// checkBoxTwinkleColour2
			// 
			this.checkBoxTwinkleColour2.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxTwinkleColour2.Location = new System.Drawing.Point(544, 118);
			this.checkBoxTwinkleColour2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxTwinkleColour2.Name = "checkBoxTwinkleColour2";
			this.checkBoxTwinkleColour2.Size = new System.Drawing.Size(20, 18);
			this.checkBoxTwinkleColour2.TabIndex = 63;
			this.checkBoxTwinkleColour2.UseVisualStyleBackColor = true;
			// 
			// TwinkleColour4
			// 
			this.TwinkleColour4.BackColor = System.Drawing.Color.Yellow;
			this.TwinkleColour4.Location = new System.Drawing.Point(622, 139);
			this.TwinkleColour4.Margin = new System.Windows.Forms.Padding(0);
			this.TwinkleColour4.Name = "TwinkleColour4";
			this.TwinkleColour4.Size = new System.Drawing.Size(36, 32);
			this.TwinkleColour4.TabIndex = 59;
			this.toolTip1.SetToolTip(this.TwinkleColour4, "Select a colour to edit.");
			this.TwinkleColour4.UseVisualStyleBackColor = false;
			this.TwinkleColour4.Click += new System.EventHandler(this.TwinkleColour4_Click);
			this.TwinkleColour4.Leave += new System.EventHandler(this.checkBoxTwinkleColour4_Leave);
			// 
			// checkBoxTwinkleColour1
			// 
			this.checkBoxTwinkleColour1.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxTwinkleColour1.Location = new System.Drawing.Point(505, 118);
			this.checkBoxTwinkleColour1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxTwinkleColour1.Name = "checkBoxTwinkleColour1";
			this.checkBoxTwinkleColour1.Size = new System.Drawing.Size(20, 18);
			this.checkBoxTwinkleColour1.TabIndex = 62;
			this.checkBoxTwinkleColour1.UseVisualStyleBackColor = true;
			// 
			// TwinkleColour3
			// 
			this.TwinkleColour3.BackColor = System.Drawing.Color.Blue;
			this.TwinkleColour3.Location = new System.Drawing.Point(580, 139);
			this.TwinkleColour3.Margin = new System.Windows.Forms.Padding(0);
			this.TwinkleColour3.Name = "TwinkleColour3";
			this.TwinkleColour3.Size = new System.Drawing.Size(36, 32);
			this.TwinkleColour3.TabIndex = 58;
			this.toolTip1.SetToolTip(this.TwinkleColour3, "Select a colour to edit.");
			this.TwinkleColour3.UseVisualStyleBackColor = false;
			this.TwinkleColour3.Click += new System.EventHandler(this.TwinkleColour3_Click);
			this.TwinkleColour3.Leave += new System.EventHandler(this.checkBoxTwinkleColour3_Leave);
			// 
			// TwinkleColour1
			// 
			this.TwinkleColour1.BackColor = System.Drawing.Color.Red;
			this.TwinkleColour1.Location = new System.Drawing.Point(496, 139);
			this.TwinkleColour1.Margin = new System.Windows.Forms.Padding(0);
			this.TwinkleColour1.Name = "TwinkleColour1";
			this.TwinkleColour1.Size = new System.Drawing.Size(36, 32);
			this.TwinkleColour1.TabIndex = 56;
			this.toolTip1.SetToolTip(this.TwinkleColour1, "Select a colour to edit.");
			this.TwinkleColour1.UseVisualStyleBackColor = false;
			this.TwinkleColour1.Click += new System.EventHandler(this.TwinkleColour1_Click);
			this.TwinkleColour1.Leave += new System.EventHandler(this.checkBoxTwinkleColour1_Leave);
			// 
			// TwinkleColour2
			// 
			this.TwinkleColour2.BackColor = System.Drawing.Color.Lime;
			this.TwinkleColour2.Location = new System.Drawing.Point(537, 139);
			this.TwinkleColour2.Margin = new System.Windows.Forms.Padding(0);
			this.TwinkleColour2.Name = "TwinkleColour2";
			this.TwinkleColour2.Size = new System.Drawing.Size(36, 32);
			this.TwinkleColour2.TabIndex = 57;
			this.toolTip1.SetToolTip(this.TwinkleColour2, "Select a colour to edit.");
			this.TwinkleColour2.UseVisualStyleBackColor = false;
			this.TwinkleColour2.Click += new System.EventHandler(this.TwinkleColour2_Click);
			this.TwinkleColour2.Leave += new System.EventHandler(this.checkBoxTwinkleColour2_Leave);
			// 
			// label53
			// 
			this.label53.AutoSize = true;
			this.label53.Location = new System.Drawing.Point(375, 130);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(53, 17);
			this.label53.TabIndex = 55;
			this.label53.Text = "Speed:";
			// 
			// trackBarSpeedTwinkles
			// 
			this.trackBarSpeedTwinkles.AutoSize = false;
			this.trackBarSpeedTwinkles.Location = new System.Drawing.Point(434, 4);
			this.trackBarSpeedTwinkles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarSpeedTwinkles.Maximum = 20;
			this.trackBarSpeedTwinkles.Minimum = 1;
			this.trackBarSpeedTwinkles.Name = "trackBarSpeedTwinkles";
			this.trackBarSpeedTwinkles.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBarSpeedTwinkles.Size = new System.Drawing.Size(36, 171);
			this.trackBarSpeedTwinkles.TabIndex = 3;
			this.trackBarSpeedTwinkles.Value = 1;
			this.trackBarSpeedTwinkles.Scroll += new System.EventHandler(this.trackBarSpeedTwinkles_Scroll);
			this.trackBarSpeedTwinkles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarSpeedTwinkles_MouseDown);
			this.trackBarSpeedTwinkles.MouseLeave += new System.EventHandler(this.trackBarSpeedTwinkles_MouseLeave);
			this.trackBarSpeedTwinkles.MouseHover += new System.EventHandler(this.trackBarSpeedTwinkles_MouseHover);
			// 
			// label52
			// 
			this.label52.AutoSize = true;
			this.label52.Location = new System.Drawing.Point(4, 66);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(73, 17);
			this.label52.TabIndex = 53;
			this.label52.Text = "# of lights:";
			// 
			// label51
			// 
			this.label51.AutoSize = true;
			this.label51.Location = new System.Drawing.Point(4, 122);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(99, 17);
			this.label51.TabIndex = 52;
			this.label51.Text = "Twinkle Steps:";
			// 
			// trackBarTwinkleSteps
			// 
			this.trackBarTwinkleSteps.AutoSize = false;
			this.trackBarTwinkleSteps.Location = new System.Drawing.Point(5, 143);
			this.trackBarTwinkleSteps.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarTwinkleSteps.Maximum = 50;
			this.trackBarTwinkleSteps.Minimum = 1;
			this.trackBarTwinkleSteps.Name = "trackBarTwinkleSteps";
			this.trackBarTwinkleSteps.Size = new System.Drawing.Size(354, 32);
			this.trackBarTwinkleSteps.TabIndex = 2;
			this.trackBarTwinkleSteps.Value = 20;
			this.trackBarTwinkleSteps.Scroll += new System.EventHandler(this.trackBarTwinkleSteps_Scroll);
			this.trackBarTwinkleSteps.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTwinkleSteps_MouseDown);
			this.trackBarTwinkleSteps.MouseLeave += new System.EventHandler(this.trackBarStepsTwinkles_MouseLeave);
			this.trackBarTwinkleSteps.MouseHover += new System.EventHandler(this.trackBarTwinkleSteps_MouseHover);
			// 
			// trackBarTwinkleLights
			// 
			this.trackBarTwinkleLights.AutoSize = false;
			this.trackBarTwinkleLights.Location = new System.Drawing.Point(4, 85);
			this.trackBarTwinkleLights.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarTwinkleLights.Maximum = 100;
			this.trackBarTwinkleLights.Minimum = 1;
			this.trackBarTwinkleLights.Name = "trackBarTwinkleLights";
			this.trackBarTwinkleLights.Size = new System.Drawing.Size(355, 32);
			this.trackBarTwinkleLights.TabIndex = 1;
			this.trackBarTwinkleLights.Value = 25;
			this.trackBarTwinkleLights.Scroll += new System.EventHandler(this.trackBarTwinkleLights_Scroll);
			this.trackBarTwinkleLights.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTwinkleLights_MouseDown);
			this.trackBarTwinkleLights.MouseLeave += new System.EventHandler(this.trackBarLightsTwinkles_MouseLeave);
			this.trackBarTwinkleLights.MouseHover += new System.EventHandler(this.trackBarTwinkleLights_MouseHover);
			// 
			// tabPageMovie
			// 
			this.tabPageMovie.BackColor = System.Drawing.Color.Azure;
			this.tabPageMovie.Controls.Add(this.buttonPlayMovie);
			this.tabPageMovie.Controls.Add(this.label77);
			this.tabPageMovie.Controls.Add(this.label76);
			this.tabPageMovie.Controls.Add(this.label75);
			this.tabPageMovie.Controls.Add(this.numericUpDownMatrixH);
			this.tabPageMovie.Controls.Add(this.numericUpDownMatrixW);
			this.tabPageMovie.Controls.Add(this.checkBoxRandom5);
			this.tabPageMovie.Controls.Add(this.buttonMovieDelete);
			this.tabPageMovie.Controls.Add(this.label72);
			this.tabPageMovie.Controls.Add(this.label73);
			this.tabPageMovie.Controls.Add(this.trackBarMovieSpeed);
			this.tabPageMovie.Controls.Add(this.trackBarThumbnail);
			this.tabPageMovie.Controls.Add(this.pictureBoxMovie);
			this.tabPageMovie.Location = new System.Drawing.Point(4, 25);
			this.tabPageMovie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageMovie.Name = "tabPageMovie";
			this.tabPageMovie.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageMovie.Size = new System.Drawing.Size(762, 177);
			this.tabPageMovie.TabIndex = 4;
			this.tabPageMovie.Text = "Movie";
			// 
			// buttonPlayMovie
			// 
			this.buttonPlayMovie.BackColor = System.Drawing.Color.Azure;
			this.buttonPlayMovie.FlatAppearance.BorderSize = 0;
			this.buttonPlayMovie.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonPlayMovie.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonPlayMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPlayMovie.Location = new System.Drawing.Point(244, 5);
			this.buttonPlayMovie.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPlayMovie.Name = "buttonPlayMovie";
			this.buttonPlayMovie.Size = new System.Drawing.Size(34, 30);
			this.buttonPlayMovie.TabIndex = 89;
			this.buttonPlayMovie.Text = "P";
			this.toolTip1.SetToolTip(this.buttonPlayMovie, "Play selected Effect. Useful for testing current Effect with no text.");
			this.buttonPlayMovie.UseVisualStyleBackColor = false;
			this.buttonPlayMovie.Click += new System.EventHandler(this.buttonPlayMovie_Click);
			// 
			// label77
			// 
			this.label77.AutoSize = true;
			this.label77.Location = new System.Drawing.Point(389, 30);
			this.label77.Name = "label77";
			this.label77.Size = new System.Drawing.Size(79, 17);
			this.label77.TabIndex = 55;
			this.label77.Text = "Video Size:";
			this.toolTip1.SetToolTip(this.label77, "Ensure you reload movie whenever you change the Matrix size");
			// 
			// label76
			// 
			this.label76.AutoSize = true;
			this.label76.Location = new System.Drawing.Point(315, 52);
			this.label76.Name = "label76";
			this.label76.Size = new System.Drawing.Size(25, 17);
			this.label76.TabIndex = 54;
			this.label76.Text = "W:";
			this.toolTip1.SetToolTip(this.label76, "Width");
			// 
			// label75
			// 
			this.label75.AutoSize = true;
			this.label75.Location = new System.Drawing.Point(420, 52);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(22, 17);
			this.label75.TabIndex = 53;
			this.label75.Text = "H:";
			this.toolTip1.SetToolTip(this.label75, "Height");
			// 
			// numericUpDownMatrixH
			// 
			this.numericUpDownMatrixH.Location = new System.Drawing.Point(448, 50);
			this.numericUpDownMatrixH.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.numericUpDownMatrixH.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownMatrixH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMatrixH.Name = "numericUpDownMatrixH";
			this.numericUpDownMatrixH.Size = new System.Drawing.Size(60, 22);
			this.numericUpDownMatrixH.TabIndex = 52;
			this.toolTip1.SetToolTip(this.numericUpDownMatrixH, "Ensure you reload movie whenever you change the Matrix size");
			this.numericUpDownMatrixH.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// numericUpDownMatrixW
			// 
			this.numericUpDownMatrixW.Location = new System.Drawing.Point(346, 50);
			this.numericUpDownMatrixW.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.numericUpDownMatrixW.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numericUpDownMatrixW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMatrixW.Name = "numericUpDownMatrixW";
			this.numericUpDownMatrixW.Size = new System.Drawing.Size(60, 22);
			this.numericUpDownMatrixW.TabIndex = 51;
			this.toolTip1.SetToolTip(this.numericUpDownMatrixW, "Ensure you reload movie whenever you change the Matrix size");
			this.numericUpDownMatrixW.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			// 
			// checkBoxRandom5
			// 
			this.checkBoxRandom5.AutoSize = true;
			this.checkBoxRandom5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRandom5.Location = new System.Drawing.Point(9, 11);
			this.checkBoxRandom5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxRandom5.Name = "checkBoxRandom5";
			this.checkBoxRandom5.Size = new System.Drawing.Size(213, 21);
			this.checkBoxRandom5.TabIndex = 50;
			this.checkBoxRandom5.Text = "Include in Random Selection:";
			this.checkBoxRandom5.UseVisualStyleBackColor = true;
			// 
			// buttonMovieDelete
			// 
			this.buttonMovieDelete.FlatAppearance.BorderSize = 0;
			this.buttonMovieDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMovieDelete.Location = new System.Drawing.Point(493, 5);
			this.buttonMovieDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonMovieDelete.Name = "buttonMovieDelete";
			this.buttonMovieDelete.Size = new System.Drawing.Size(34, 30);
			this.buttonMovieDelete.TabIndex = 49;
			this.buttonMovieDelete.Text = "-";
			this.toolTip1.SetToolTip(this.buttonMovieDelete, "Remove Sequence File Path");
			this.buttonMovieDelete.UseVisualStyleBackColor = true;
			this.buttonMovieDelete.Click += new System.EventHandler(this.buttonMovieDelete_Click);
			// 
			// label72
			// 
			this.label72.AutoSize = true;
			this.label72.Location = new System.Drawing.Point(9, 53);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(94, 17);
			this.label72.TabIndex = 48;
			this.label72.Text = "Movie Speed:";
			this.toolTip1.SetToolTip(this.label72, "Speed of the output movie.");
			// 
			// label73
			// 
			this.label73.AutoSize = true;
			this.label73.Location = new System.Drawing.Point(9, 117);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(132, 17);
			this.label73.TabIndex = 47;
			this.label73.Text = "Thumbnail Position:";
			this.toolTip1.SetToolTip(this.label73, "Visual only, has no effect on output.");
			// 
			// trackBarMovieSpeed
			// 
			this.trackBarMovieSpeed.AutoSize = false;
			this.trackBarMovieSpeed.Location = new System.Drawing.Point(12, 75);
			this.trackBarMovieSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarMovieSpeed.Maximum = 100;
			this.trackBarMovieSpeed.Minimum = -100;
			this.trackBarMovieSpeed.Name = "trackBarMovieSpeed";
			this.trackBarMovieSpeed.Size = new System.Drawing.Size(515, 32);
			this.trackBarMovieSpeed.TabIndex = 45;
			this.trackBarMovieSpeed.Scroll += new System.EventHandler(this.trackBarMovieSpeed_Scroll);
			this.trackBarMovieSpeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarMovieSpeed_MouseDown);
			this.trackBarMovieSpeed.MouseHover += new System.EventHandler(this.trackBarMovieSpeed_MouseHover);
			// 
			// trackBarThumbnail
			// 
			this.trackBarThumbnail.AutoSize = false;
			this.trackBarThumbnail.Location = new System.Drawing.Point(9, 135);
			this.trackBarThumbnail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarThumbnail.Maximum = 20000;
			this.trackBarThumbnail.Minimum = 1;
			this.trackBarThumbnail.Name = "trackBarThumbnail";
			this.trackBarThumbnail.Size = new System.Drawing.Size(518, 32);
			this.trackBarThumbnail.TabIndex = 44;
			this.trackBarThumbnail.Value = 1;
			this.trackBarThumbnail.Scroll += new System.EventHandler(this.trackBarThumbnail_Scroll);
			this.trackBarThumbnail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarThumbnail_MouseDown);
			this.trackBarThumbnail.MouseHover += new System.EventHandler(this.trackBarThumbnail_MouseHover);
			// 
			// pictureBoxMovie
			// 
			this.pictureBoxMovie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxMovie.Location = new System.Drawing.Point(534, 5);
			this.pictureBoxMovie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBoxMovie.Name = "pictureBoxMovie";
			this.pictureBoxMovie.Size = new System.Drawing.Size(187, 160);
			this.pictureBoxMovie.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxMovie.TabIndex = 2;
			this.pictureBoxMovie.TabStop = false;
			this.pictureBoxMovie.Click += new System.EventHandler(this.pictureBoxMovie_Click);
			// 
			// tabPageGlediator
			// 
			this.tabPageGlediator.BackColor = System.Drawing.Color.Azure;
			this.tabPageGlediator.Controls.Add(this.buttonPlayGled);
			this.tabPageGlediator.Controls.Add(this.label80);
			this.tabPageGlediator.Controls.Add(this.label79);
			this.tabPageGlediator.Controls.Add(this.trackBarGlediator);
			this.tabPageGlediator.Controls.Add(this.checkBoxRandom6);
			this.tabPageGlediator.Controls.Add(this.textBoxGlediator);
			this.tabPageGlediator.Controls.Add(this.buttonGlediator);
			this.tabPageGlediator.Location = new System.Drawing.Point(4, 25);
			this.tabPageGlediator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageGlediator.Name = "tabPageGlediator";
			this.tabPageGlediator.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageGlediator.Size = new System.Drawing.Size(762, 177);
			this.tabPageGlediator.TabIndex = 5;
			this.tabPageGlediator.Text = "Glediator/Jinx";
			// 
			// buttonPlayGled
			// 
			this.buttonPlayGled.BackColor = System.Drawing.Color.Azure;
			this.buttonPlayGled.FlatAppearance.BorderSize = 0;
			this.buttonPlayGled.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonPlayGled.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonPlayGled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPlayGled.Location = new System.Drawing.Point(396, 96);
			this.buttonPlayGled.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPlayGled.Name = "buttonPlayGled";
			this.buttonPlayGled.Size = new System.Drawing.Size(34, 30);
			this.buttonPlayGled.TabIndex = 90;
			this.buttonPlayGled.Text = "P";
			this.toolTip1.SetToolTip(this.buttonPlayGled, "Play selected Effect. Useful for testing current Effect with no text.");
			this.buttonPlayGled.UseVisualStyleBackColor = false;
			this.buttonPlayGled.Click += new System.EventHandler(this.buttonPlayGled_Click);
			// 
			// label80
			// 
			this.label80.Location = new System.Drawing.Point(20, 14);
			this.label80.Name = "label80";
			this.label80.Size = new System.Drawing.Size(365, 41);
			this.label80.TabIndex = 73;
			this.label80.Text = "Note: Jinx effects need to be setup and recorder to a .gled file in the Jinx app " +
    "to be imported to Vixen.";
			this.toolTip1.SetToolTip(this.label80, "Speed of the output Glediator.");
			// 
			// label79
			// 
			this.label79.AutoSize = true;
			this.label79.Location = new System.Drawing.Point(20, 70);
			this.label79.Name = "label79";
			this.label79.Size = new System.Drawing.Size(143, 17);
			this.label79.TabIndex = 72;
			this.label79.Text = "Glediator/Jinx Speed:";
			this.toolTip1.SetToolTip(this.label79, "Speed of the output Glediator.");
			// 
			// trackBarGlediator
			// 
			this.trackBarGlediator.AutoSize = false;
			this.trackBarGlediator.Location = new System.Drawing.Point(12, 96);
			this.trackBarGlediator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarGlediator.Maximum = 20;
			this.trackBarGlediator.Minimum = 1;
			this.trackBarGlediator.Name = "trackBarGlediator";
			this.trackBarGlediator.Size = new System.Drawing.Size(340, 32);
			this.trackBarGlediator.TabIndex = 71;
			this.trackBarGlediator.Value = 9;
			this.trackBarGlediator.Scroll += new System.EventHandler(this.trackBarGlediator_Scroll);
			this.trackBarGlediator.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarGlediator_MouseDown);
			this.trackBarGlediator.MouseHover += new System.EventHandler(this.trackBarGlediator_MouseHover);
			// 
			// checkBoxRandom6
			// 
			this.checkBoxRandom6.AutoSize = true;
			this.checkBoxRandom6.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRandom6.Location = new System.Drawing.Point(429, 4);
			this.checkBoxRandom6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxRandom6.Name = "checkBoxRandom6";
			this.checkBoxRandom6.Size = new System.Drawing.Size(213, 21);
			this.checkBoxRandom6.TabIndex = 70;
			this.checkBoxRandom6.Text = "Include in Random Selection:";
			this.checkBoxRandom6.UseVisualStyleBackColor = true;
			// 
			// textBoxGlediator
			// 
			this.textBoxGlediator.Enabled = false;
			this.textBoxGlediator.Location = new System.Drawing.Point(12, 146);
			this.textBoxGlediator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxGlediator.Name = "textBoxGlediator";
			this.textBoxGlediator.Size = new System.Drawing.Size(715, 22);
			this.textBoxGlediator.TabIndex = 1;
			// 
			// buttonGlediator
			// 
			this.buttonGlediator.Location = new System.Drawing.Point(624, 96);
			this.buttonGlediator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonGlediator.Name = "buttonGlediator";
			this.buttonGlediator.Size = new System.Drawing.Size(103, 34);
			this.buttonGlediator.TabIndex = 0;
			this.buttonGlediator.Text = "Load Effect";
			this.buttonGlediator.UseVisualStyleBackColor = true;
			this.buttonGlediator.Click += new System.EventHandler(this.buttonGlediator_Click);
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(541, 25);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(124, 17);
			this.label28.TabIndex = 37;
			this.label28.Text = "Sequence Length:";
			this.toolTip1.SetToolTip(this.label28, "Set length. Message will repeat until seq length time has reached.");
			// 
			// EffectTime
			// 
			this.EffectTime.Location = new System.Drawing.Point(676, 22);
			this.EffectTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.EffectTime.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
			this.EffectTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.EffectTime.Name = "EffectTime";
			this.EffectTime.Size = new System.Drawing.Size(64, 22);
			this.EffectTime.TabIndex = 2;
			this.EffectTime.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.EffectTime.ValueChanged += new System.EventHandler(this.EffectTime_ValueChanged);
			// 
			// TabSeq1
			// 
			this.TabSeq1.BackColor = System.Drawing.Color.Azure;
			this.TabSeq1.Controls.Add(this.label48);
			this.TabSeq1.Controls.Add(this.textBoxSequenceLength1);
			this.TabSeq1.Controls.Add(this.label22);
			this.TabSeq1.Controls.Add(this.buttonRemoveSeq1);
			this.TabSeq1.Controls.Add(this.label40);
			this.TabSeq1.Controls.Add(this.textBoxVixenSeq1);
			this.TabSeq1.Controls.Add(this.buttonVixenSeq1);
			this.TabSeq1.Controls.Add(this.label19);
			this.TabSeq1.Location = new System.Drawing.Point(4, 25);
			this.TabSeq1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq1.Name = "TabSeq1";
			this.TabSeq1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq1.Size = new System.Drawing.Size(760, 165);
			this.TabSeq1.TabIndex = 0;
			this.TabSeq1.Text = "Seq 1";
			this.toolTip1.SetToolTip(this.TabSeq1, "Remove Sequence File Path");
			// 
			// label48
			// 
			this.label48.Location = new System.Drawing.Point(4, 122);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(702, 39);
			this.label48.TabIndex = 33;
			this.label48.Text = "Note: This will not modify your Vixen 3 sequence in any way, Vixen Messaging will" +
    " create and modify a copy of your sequence to be used when a message has been re" +
    "ceived. Filename is Vixen3Out.tim";
			// 
			// textBoxSequenceLength1
			// 
			this.textBoxSequenceLength1.BackColor = System.Drawing.Color.White;
			this.textBoxSequenceLength1.Enabled = false;
			this.textBoxSequenceLength1.Location = new System.Drawing.Point(592, 90);
			this.textBoxSequenceLength1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxSequenceLength1.Name = "textBoxSequenceLength1";
			this.textBoxSequenceLength1.Size = new System.Drawing.Size(114, 22);
			this.textBoxSequenceLength1.TabIndex = 4;
			this.textBoxSequenceLength1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(453, 93);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(124, 17);
			this.label22.TabIndex = 28;
			this.label22.Text = "Sequence Length:";
			// 
			// buttonRemoveSeq1
			// 
			this.buttonRemoveSeq1.FlatAppearance.BorderSize = 0;
			this.buttonRemoveSeq1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveSeq1.Location = new System.Drawing.Point(672, 12);
			this.buttonRemoveSeq1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonRemoveSeq1.Name = "buttonRemoveSeq1";
			this.buttonRemoveSeq1.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveSeq1.TabIndex = 4;
			this.buttonRemoveSeq1.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveSeq1, "Remove Sequence File Path");
			this.buttonRemoveSeq1.UseVisualStyleBackColor = true;
			this.buttonRemoveSeq1.Click += new System.EventHandler(this.buttonRemoveSeq1_Click);
			// 
			// label40
			// 
			this.label40.Location = new System.Drawing.Point(231, 46);
			this.label40.Name = "label40";
			this.label40.Size = new System.Drawing.Size(475, 42);
			this.label40.TabIndex = 26;
			this.label40.Text = "Select the Vixen Sequence you would like to use. Normally located in your Documen" +
    "ts\\Vixen 3\\Sequence\\ Folder.";
			// 
			// textBoxVixenSeq1
			// 
			this.textBoxVixenSeq1.BackColor = System.Drawing.Color.White;
			this.textBoxVixenSeq1.Enabled = false;
			this.textBoxVixenSeq1.Location = new System.Drawing.Point(135, 14);
			this.textBoxVixenSeq1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxVixenSeq1.Name = "textBoxVixenSeq1";
			this.textBoxVixenSeq1.Size = new System.Drawing.Size(532, 22);
			this.textBoxVixenSeq1.TabIndex = 3;
			// 
			// buttonVixenSeq1
			// 
			this.buttonVixenSeq1.Location = new System.Drawing.Point(5, 50);
			this.buttonVixenSeq1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonVixenSeq1.Name = "buttonVixenSeq1";
			this.buttonVixenSeq1.Size = new System.Drawing.Size(190, 34);
			this.buttonVixenSeq1.TabIndex = 5;
			this.buttonVixenSeq1.Text = "Set Vixen Sequence Path";
			this.buttonVixenSeq1.UseVisualStyleBackColor = true;
			this.buttonVixenSeq1.Click += new System.EventHandler(this.buttonVixenSeq1_Click);
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(11, 20);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(114, 17);
			this.label19.TabIndex = 5;
			this.label19.Text = "Vixen Sequence:";
			// 
			// TabSeq2
			// 
			this.TabSeq2.BackColor = System.Drawing.Color.Azure;
			this.TabSeq2.Controls.Add(this.label49);
			this.TabSeq2.Controls.Add(this.textBoxSequenceLength2);
			this.TabSeq2.Controls.Add(this.label24);
			this.TabSeq2.Controls.Add(this.buttonRemoveSeq2);
			this.TabSeq2.Controls.Add(this.label39);
			this.TabSeq2.Controls.Add(this.textBoxVixenSeq2);
			this.TabSeq2.Controls.Add(this.buttonVixenSeq2);
			this.TabSeq2.Controls.Add(this.label20);
			this.TabSeq2.Location = new System.Drawing.Point(4, 25);
			this.TabSeq2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq2.Name = "TabSeq2";
			this.TabSeq2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq2.Size = new System.Drawing.Size(760, 165);
			this.TabSeq2.TabIndex = 1;
			this.TabSeq2.Text = "Seq 2";
			this.toolTip1.SetToolTip(this.TabSeq2, "Remove Sequence File Path");
			// 
			// label49
			// 
			this.label49.Location = new System.Drawing.Point(4, 122);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(702, 39);
			this.label49.TabIndex = 33;
			this.label49.Text = "Note: This will not modify your Vixen 3 sequence in any way, Vixen Messaging will" +
    " create and modify a copy of your sequence to be used when a message has been re" +
    "ceived. Filename is Vixen3Out.tim";
			// 
			// textBoxSequenceLength2
			// 
			this.textBoxSequenceLength2.BackColor = System.Drawing.Color.White;
			this.textBoxSequenceLength2.Enabled = false;
			this.textBoxSequenceLength2.Location = new System.Drawing.Point(592, 90);
			this.textBoxSequenceLength2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxSequenceLength2.Name = "textBoxSequenceLength2";
			this.textBoxSequenceLength2.Size = new System.Drawing.Size(114, 22);
			this.textBoxSequenceLength2.TabIndex = 4;
			this.textBoxSequenceLength2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label24
			// 
			this.label24.AutoSize = true;
			this.label24.Location = new System.Drawing.Point(453, 93);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(124, 17);
			this.label24.TabIndex = 30;
			this.label24.Text = "Sequence Length:";
			// 
			// buttonRemoveSeq2
			// 
			this.buttonRemoveSeq2.FlatAppearance.BorderSize = 0;
			this.buttonRemoveSeq2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveSeq2.Location = new System.Drawing.Point(672, 12);
			this.buttonRemoveSeq2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonRemoveSeq2.Name = "buttonRemoveSeq2";
			this.buttonRemoveSeq2.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveSeq2.TabIndex = 2;
			this.buttonRemoveSeq2.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveSeq2, "Remove Sequence File Path");
			this.buttonRemoveSeq2.UseVisualStyleBackColor = true;
			this.buttonRemoveSeq2.Click += new System.EventHandler(this.buttonRemoveSeq2_Click);
			// 
			// label39
			// 
			this.label39.Location = new System.Drawing.Point(231, 46);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(475, 42);
			this.label39.TabIndex = 26;
			this.label39.Text = "Select the Vixen Sequence you would like to use. Normally located in your Documen" +
    "ts\\Vixen 3\\Sequence\\ Folder.";
			// 
			// textBoxVixenSeq2
			// 
			this.textBoxVixenSeq2.BackColor = System.Drawing.Color.White;
			this.textBoxVixenSeq2.Enabled = false;
			this.textBoxVixenSeq2.Location = new System.Drawing.Point(135, 14);
			this.textBoxVixenSeq2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxVixenSeq2.Name = "textBoxVixenSeq2";
			this.textBoxVixenSeq2.Size = new System.Drawing.Size(532, 22);
			this.textBoxVixenSeq2.TabIndex = 3;
			// 
			// buttonVixenSeq2
			// 
			this.buttonVixenSeq2.Location = new System.Drawing.Point(5, 50);
			this.buttonVixenSeq2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonVixenSeq2.Name = "buttonVixenSeq2";
			this.buttonVixenSeq2.Size = new System.Drawing.Size(190, 34);
			this.buttonVixenSeq2.TabIndex = 1;
			this.buttonVixenSeq2.Text = "Set Vixen Sequence Path";
			this.buttonVixenSeq2.UseVisualStyleBackColor = true;
			this.buttonVixenSeq2.Click += new System.EventHandler(this.buttonVixenSeq2_Click);
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(11, 20);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(114, 17);
			this.label20.TabIndex = 17;
			this.label20.Text = "Vixen Sequence:";
			// 
			// buttonRemoveSeq3
			// 
			this.buttonRemoveSeq3.FlatAppearance.BorderSize = 0;
			this.buttonRemoveSeq3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveSeq3.Location = new System.Drawing.Point(672, 12);
			this.buttonRemoveSeq3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonRemoveSeq3.Name = "buttonRemoveSeq3";
			this.buttonRemoveSeq3.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveSeq3.TabIndex = 2;
			this.buttonRemoveSeq3.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveSeq3, "Remove Sequence File Path");
			this.buttonRemoveSeq3.UseVisualStyleBackColor = true;
			this.buttonRemoveSeq3.Click += new System.EventHandler(this.buttonRemoveSeq3_Click);
			// 
			// checkBoxManEnterSettings
			// 
			this.checkBoxManEnterSettings.AutoSize = true;
			this.checkBoxManEnterSettings.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxManEnterSettings.Location = new System.Drawing.Point(14, 67);
			this.checkBoxManEnterSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxManEnterSettings.Name = "checkBoxManEnterSettings";
			this.checkBoxManEnterSettings.Size = new System.Drawing.Size(220, 21);
			this.checkBoxManEnterSettings.TabIndex = 2;
			this.checkBoxManEnterSettings.Text = "Manually enter Vixen Settings:";
			this.toolTip1.SetToolTip(this.checkBoxManEnterSettings, "Not normally required, use the Get \"Vixen Data Setting\" button below.");
			this.checkBoxManEnterSettings.UseVisualStyleBackColor = true;
			this.checkBoxManEnterSettings.CheckedChanged += new System.EventHandler(this.checkBoxManEnterSettings_CheckedChanged);
			// 
			// buttonRemoveSeq4
			// 
			this.buttonRemoveSeq4.FlatAppearance.BorderSize = 0;
			this.buttonRemoveSeq4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveSeq4.Location = new System.Drawing.Point(672, 12);
			this.buttonRemoveSeq4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonRemoveSeq4.Name = "buttonRemoveSeq4";
			this.buttonRemoveSeq4.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveSeq4.TabIndex = 2;
			this.buttonRemoveSeq4.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveSeq4, "Remove Sequence File Path");
			this.buttonRemoveSeq4.UseVisualStyleBackColor = true;
			this.buttonRemoveSeq4.Click += new System.EventHandler(this.buttonRemoveSeq4_Click_1);
			// 
			// checkBoxEnableSqnctrl
			// 
			this.checkBoxEnableSqnctrl.AutoSize = true;
			this.checkBoxEnableSqnctrl.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxEnableSqnctrl.Location = new System.Drawing.Point(331, 18);
			this.checkBoxEnableSqnctrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxEnableSqnctrl.Name = "checkBoxEnableSqnctrl";
			this.checkBoxEnableSqnctrl.Size = new System.Drawing.Size(172, 21);
			this.checkBoxEnableSqnctrl.TabIndex = 1;
			this.checkBoxEnableSqnctrl.Text = "Use Vixen Sequences:";
			this.toolTip1.SetToolTip(this.checkBoxEnableSqnctrl, "Selects and adds locally generated effects OR when checked will add the Text mess" +
        "age to your selected Vixen 3 Sequence.");
			this.checkBoxEnableSqnctrl.UseVisualStyleBackColor = true;
			this.checkBoxEnableSqnctrl.CheckedChanged += new System.EventHandler(this.checkBoxEnableSqnctrl_CheckedChanged);
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
			this.RandomColourSelection.Location = new System.Drawing.Point(7, 205);
			this.RandomColourSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RandomColourSelection.Name = "RandomColourSelection";
			this.RandomColourSelection.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RandomColourSelection.Size = new System.Drawing.Size(598, 74);
			this.RandomColourSelection.TabIndex = 9;
			this.RandomColourSelection.TabStop = false;
			this.RandomColourSelection.Text = "Colours";
			this.toolTip1.SetToolTip(this.RandomColourSelection, "Select a colour to edit. Number idicates colours that are enabled and will change" +
        " depending on selected Colour Option..");
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
			// checkBoxRandomSeqSelection
			// 
			this.checkBoxRandomSeqSelection.AutoSize = true;
			this.checkBoxRandomSeqSelection.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxRandomSeqSelection.Location = new System.Drawing.Point(588, 18);
			this.checkBoxRandomSeqSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxRandomSeqSelection.Name = "checkBoxRandomSeqSelection";
			this.checkBoxRandomSeqSelection.Size = new System.Drawing.Size(155, 21);
			this.checkBoxRandomSeqSelection.TabIndex = 2;
			this.checkBoxRandomSeqSelection.Text = "Random Sequence:";
			this.toolTip1.SetToolTip(this.checkBoxRandomSeqSelection, "Select this to enable Random Sequence selection for each message that comes throu" +
        "gh.");
			this.checkBoxRandomSeqSelection.UseVisualStyleBackColor = true;
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
			// buttonRemoveSeq5
			// 
			this.buttonRemoveSeq5.FlatAppearance.BorderSize = 0;
			this.buttonRemoveSeq5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveSeq5.Location = new System.Drawing.Point(672, 12);
			this.buttonRemoveSeq5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonRemoveSeq5.Name = "buttonRemoveSeq5";
			this.buttonRemoveSeq5.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveSeq5.TabIndex = 41;
			this.buttonRemoveSeq5.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveSeq5, "Remove Sequence File Path");
			this.buttonRemoveSeq5.UseVisualStyleBackColor = true;
			this.buttonRemoveSeq5.Click += new System.EventHandler(this.buttonRemoveSeq5_Click);
			// 
			// buttonRemoveSeq6
			// 
			this.buttonRemoveSeq6.FlatAppearance.BorderSize = 0;
			this.buttonRemoveSeq6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveSeq6.Location = new System.Drawing.Point(672, 12);
			this.buttonRemoveSeq6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonRemoveSeq6.Name = "buttonRemoveSeq6";
			this.buttonRemoveSeq6.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveSeq6.TabIndex = 41;
			this.buttonRemoveSeq6.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveSeq6, "Remove Sequence File Path");
			this.buttonRemoveSeq6.UseVisualStyleBackColor = true;
			this.buttonRemoveSeq6.Click += new System.EventHandler(this.buttonRemoveSeq6_Click);
			// 
			// checkBoxDisableSeq
			// 
			this.checkBoxDisableSeq.AutoSize = true;
			this.checkBoxDisableSeq.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxDisableSeq.Location = new System.Drawing.Point(55, 18);
			this.checkBoxDisableSeq.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxDisableSeq.Name = "checkBoxDisableSeq";
			this.checkBoxDisableSeq.Size = new System.Drawing.Size(175, 21);
			this.checkBoxDisableSeq.TabIndex = 0;
			this.checkBoxDisableSeq.Text = "Disable All Sequences:";
			this.toolTip1.SetToolTip(this.checkBoxDisableSeq, "Will Disable all sequences and only display messages.");
			this.checkBoxDisableSeq.UseVisualStyleBackColor = true;
			this.checkBoxDisableSeq.CheckedChanged += new System.EventHandler(this.checkBoxDisableSeq_CheckedChanged);
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(14, 155);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(156, 42);
			this.label9.TabIndex = 7;
			this.label9.Text = "Return Message when User gets Banned:";
			this.toolTip1.SetToolTip(this.label9, "This is used to check for agaist in th eincoming SMS messages from you SMS provid" +
        "er");
			// 
			// label78
			// 
			this.label78.AutoSize = true;
			this.label78.Location = new System.Drawing.Point(14, 112);
			this.label78.Name = "label78";
			this.label78.Size = new System.Drawing.Size(168, 17);
			this.label78.TabIndex = 10;
			this.label78.Text = "Remote Access Keyword:";
			this.toolTip1.SetToolTip(this.label78, "Enter a keyword that you will use when you want to email setting to Messaging. In" +
        " your subject heading for example you will type \"Messaging Northridge\".");
			// 
			// textBoxAccessPWD
			// 
			this.textBoxAccessPWD.Location = new System.Drawing.Point(196, 110);
			this.textBoxAccessPWD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxAccessPWD.Name = "textBoxAccessPWD";
			this.textBoxAccessPWD.Size = new System.Drawing.Size(147, 22);
			this.textBoxAccessPWD.TabIndex = 3;
			this.textBoxAccessPWD.Text = "Northridge";
			this.toolTip1.SetToolTip(this.textBoxAccessPWD, "Enter a password that you will use when you want to email setting to Messaging. I" +
        "n your subject heading for example you will type \"Messaging Northridge\"");
			this.textBoxAccessPWD.TextChanged += new System.EventHandler(this.textBoxAccessPWD_TextChanged);
			// 
			// checkBoxEmail
			// 
			this.checkBoxEmail.AutoSize = true;
			this.checkBoxEmail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxEmail.Checked = true;
			this.checkBoxEmail.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxEmail.Location = new System.Drawing.Point(6, 29);
			this.checkBoxEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.checkBoxEmail.Name = "checkBoxEmail";
			this.checkBoxEmail.Size = new System.Drawing.Size(177, 21);
			this.checkBoxEmail.TabIndex = 9;
			this.checkBoxEmail.Tag = "4";
			this.checkBoxEmail.Text = "Email/SMS (from Email)";
			this.toolTip1.SetToolTip(this.checkBoxEmail, "Select to retrieve messages from an email address");
			this.checkBoxEmail.UseVisualStyleBackColor = true;
			this.checkBoxEmail.CheckedChanged += new System.EventHandler(this.checkBoxEmail_CheckedChanged);
			// 
			// checkBoxLocal
			// 
			this.checkBoxLocal.AutoSize = true;
			this.checkBoxLocal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxLocal.Location = new System.Drawing.Point(207, 29);
			this.checkBoxLocal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
			this.checkBoxTwilio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
			// numericUpDownMultiLine
			// 
			this.numericUpDownMultiLine.Enabled = false;
			this.numericUpDownMultiLine.Location = new System.Drawing.Point(259, 14);
			this.numericUpDownMultiLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.numericUpDownMultiLine.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.numericUpDownMultiLine.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownMultiLine.Name = "numericUpDownMultiLine";
			this.numericUpDownMultiLine.Size = new System.Drawing.Size(64, 22);
			this.numericUpDownMultiLine.TabIndex = 7;
			this.toolTip1.SetToolTip(this.numericUpDownMultiLine, "Vixen provides support for 4 lines of text. Select the total number of lines you " +
        "would like to use.");
			this.numericUpDownMultiLine.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label85
			// 
			this.label85.AutoSize = true;
			this.label85.Location = new System.Drawing.Point(141, 15);
			this.label85.Name = "label85";
			this.label85.Size = new System.Drawing.Size(114, 17);
			this.label85.TabIndex = 61;
			this.label85.Text = "No of lines used:";
			this.toolTip1.SetToolTip(this.label85, "Vixen provides support for 4 lines of text. Select the total number of lines you " +
        "would like to use.");
			// 
			// checkBoxMultiLine
			// 
			this.checkBoxMultiLine.AutoSize = true;
			this.checkBoxMultiLine.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxMultiLine.Location = new System.Drawing.Point(3, 14);
			this.checkBoxMultiLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxMultiLine.Name = "checkBoxMultiLine";
			this.checkBoxMultiLine.Size = new System.Drawing.Size(123, 21);
			this.checkBoxMultiLine.TabIndex = 6;
			this.checkBoxMultiLine.Text = "Multi Line Use:";
			this.toolTip1.SetToolTip(this.checkBoxMultiLine, "Will automatically split the message over the selected number of lines.");
			this.checkBoxMultiLine.UseVisualStyleBackColor = true;
			this.checkBoxMultiLine.CheckedChanged += new System.EventHandler(this.checkBoxMultiLine_CheckedChanged);
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
			// groupBox7
			// 
			this.groupBox7.Controls.Add(this.label85);
			this.groupBox7.Controls.Add(this.checkBoxMultiLine);
			this.groupBox7.Controls.Add(this.numericUpDownMultiLine);
			this.groupBox7.Location = new System.Drawing.Point(7, 106);
			this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox7.Name = "groupBox7";
			this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox7.Size = new System.Drawing.Size(360, 39);
			this.groupBox7.TabIndex = 65;
			this.groupBox7.TabStop = false;
			this.toolTip1.SetToolTip(this.groupBox7, "Not used on Custom messages.");
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
			// groupBoxCountDown
			// 
			this.groupBoxCountDown.Controls.Add(this.label106);
			this.groupBoxCountDown.Controls.Add(this.label37);
			this.groupBoxCountDown.Controls.Add(this.customMessageNodeSel);
			this.groupBoxCountDown.Controls.Add(this.label99);
			this.groupBoxCountDown.Controls.Add(this.customMessageSeqSel);
			this.groupBoxCountDown.Controls.Add(this.checkBoxCentreStop);
			this.groupBoxCountDown.Controls.Add(this.label97);
			this.groupBoxCountDown.Controls.Add(this.messageColourOption);
			this.groupBoxCountDown.Controls.Add(this.line1Colour);
			this.groupBoxCountDown.Controls.Add(this.line2Colour);
			this.groupBoxCountDown.Controls.Add(this.line3Colour);
			this.groupBoxCountDown.Controls.Add(this.line4Colour);
			this.groupBoxCountDown.Controls.Add(this.label95);
			this.groupBoxCountDown.Controls.Add(this.trackBarCustomSpeed);
			this.groupBoxCountDown.Controls.Add(this.buttonPlay);
			this.groupBoxCountDown.Controls.Add(this.CustomMsgLength);
			this.groupBoxCountDown.Controls.Add(this.label94);
			this.groupBoxCountDown.Controls.Add(this.textBoxCustomFontSize);
			this.groupBoxCountDown.Controls.Add(this.textBoxCustomFont);
			this.groupBoxCountDown.Controls.Add(this.buttonCustomFont);
			this.groupBoxCountDown.Controls.Add(this.label93);
			this.groupBoxCountDown.Controls.Add(this.comboBoxName);
			this.groupBoxCountDown.Controls.Add(this.checkBoxMessageEnabled);
			this.groupBoxCountDown.Controls.Add(this.buttonRemoveMessage);
			this.groupBoxCountDown.Controls.Add(this.buttonAddMessage);
			this.groupBoxCountDown.Controls.Add(this.comboBoxCountDownDirection);
			this.groupBoxCountDown.Controls.Add(this.label10);
			this.groupBoxCountDown.Controls.Add(this.label92);
			this.groupBoxCountDown.Controls.Add(this.label91);
			this.groupBoxCountDown.Controls.Add(this.label90);
			this.groupBoxCountDown.Controls.Add(this.label89);
			this.groupBoxCountDown.Controls.Add(this.textBoxLine1);
			this.groupBoxCountDown.Controls.Add(this.textBoxLine2);
			this.groupBoxCountDown.Controls.Add(this.label86);
			this.groupBoxCountDown.Controls.Add(this.textBoxLine3);
			this.groupBoxCountDown.Controls.Add(this.trackBarCountDownPosition);
			this.groupBoxCountDown.Controls.Add(this.textBoxLine4);
			this.groupBoxCountDown.Enabled = false;
			this.groupBoxCountDown.Location = new System.Drawing.Point(6, 59);
			this.groupBoxCountDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxCountDown.Name = "groupBoxCountDown";
			this.groupBoxCountDown.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxCountDown.Size = new System.Drawing.Size(780, 318);
			this.groupBoxCountDown.TabIndex = 1;
			this.groupBoxCountDown.TabStop = false;
			this.groupBoxCountDown.Text = "Custom Messages";
			this.toolTip1.SetToolTip(this.groupBoxCountDown, "Add the word COUNTDOWN to your message to display\r\nthe number fo days to the Coun" +
        "tDown date.");
			// 
			// label106
			// 
			this.label106.AutoSize = true;
			this.label106.Location = new System.Drawing.Point(559, 101);
			this.label106.Name = "label106";
			this.label106.Size = new System.Drawing.Size(32, 17);
			this.label106.TabIndex = 103;
			this.label106.Text = "Sec";
			// 
			// label37
			// 
			this.label37.AutoSize = true;
			this.label37.Location = new System.Drawing.Point(9, 59);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(90, 17);
			this.label37.TabIndex = 102;
			this.label37.Text = "Group Node:";
			this.toolTip1.SetToolTip(this.label37, "Select the Group Node to use for this message.");
			// 
			// customMessageNodeSel
			// 
			this.customMessageNodeSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.customMessageNodeSel.FormattingEnabled = true;
			this.customMessageNodeSel.Location = new System.Drawing.Point(136, 57);
			this.customMessageNodeSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.customMessageNodeSel.Name = "customMessageNodeSel";
			this.customMessageNodeSel.Size = new System.Drawing.Size(245, 24);
			this.customMessageNodeSel.TabIndex = 101;
			this.customMessageNodeSel.SelectionChangeCommitted += new System.EventHandler(this.customMessageNodeSel_SelectionChangeCommitted);
			// 
			// label99
			// 
			this.label99.AutoSize = true;
			this.label99.Location = new System.Drawing.Point(9, 92);
			this.label99.Name = "label99";
			this.label99.Size = new System.Drawing.Size(122, 17);
			this.label99.TabIndex = 100;
			this.label99.Text = "Sequence Option:";
			this.toolTip1.SetToolTip(this.label99, "Automatically Assigned - Will select an effect based on the selection you have se" +
        "t up on the Sequence settings tab.\r\nOther selections are as per selection.");
			// 
			// customMessageSeqSel
			// 
			this.customMessageSeqSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.customMessageSeqSel.FormattingEnabled = true;
			this.customMessageSeqSel.Items.AddRange(new object[] {
            "Automatically Assigned",
            "Movie",
            "Glediator/Jinx"});
			this.customMessageSeqSel.Location = new System.Drawing.Point(136, 90);
			this.customMessageSeqSel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.customMessageSeqSel.Name = "customMessageSeqSel";
			this.customMessageSeqSel.Size = new System.Drawing.Size(245, 24);
			this.customMessageSeqSel.TabIndex = 8;
			this.customMessageSeqSel.SelectionChangeCommitted += new System.EventHandler(this.customMessageSeqSel_SelectionChangeCommitted);
			// 
			// checkBoxCentreStop
			// 
			this.checkBoxCentreStop.AutoSize = true;
			this.checkBoxCentreStop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxCentreStop.Location = new System.Drawing.Point(404, 135);
			this.checkBoxCentreStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxCentreStop.Name = "checkBoxCentreStop";
			this.checkBoxCentreStop.Size = new System.Drawing.Size(109, 21);
			this.checkBoxCentreStop.TabIndex = 13;
			this.checkBoxCentreStop.Text = "Center Stop:";
			this.toolTip1.SetToolTip(this.checkBoxCentreStop, "Enable this message to be included in the selection to display.");
			this.checkBoxCentreStop.UseVisualStyleBackColor = true;
			this.checkBoxCentreStop.Leave += new System.EventHandler(this.checkBoxCentreStop_Leave);
			// 
			// label97
			// 
			this.label97.AutoSize = true;
			this.label97.Location = new System.Drawing.Point(9, 126);
			this.label97.Name = "label97";
			this.label97.Size = new System.Drawing.Size(99, 17);
			this.label97.TabIndex = 97;
			this.label97.Text = "Colour Option:";
			this.toolTip1.SetToolTip(this.label97, resources.GetString("label97.ToolTip"));
			// 
			// messageColourOption
			// 
			this.messageColourOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.messageColourOption.FormattingEnabled = true;
			this.messageColourOption.Items.AddRange(new object[] {
            "Single",
            "Multi",
            "Random"});
			this.messageColourOption.Location = new System.Drawing.Point(136, 123);
			this.messageColourOption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.messageColourOption.Name = "messageColourOption";
			this.messageColourOption.Size = new System.Drawing.Size(117, 24);
			this.messageColourOption.TabIndex = 9;
			this.messageColourOption.SelectionChangeCommitted += new System.EventHandler(this.messageColourOption_SelectionChangeCommitted);
			// 
			// line1Colour
			// 
			this.line1Colour.BackColor = System.Drawing.Color.Red;
			this.line1Colour.FlatAppearance.BorderSize = 0;
			this.line1Colour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.line1Colour.Location = new System.Drawing.Point(345, 154);
			this.line1Colour.Margin = new System.Windows.Forms.Padding(0);
			this.line1Colour.Name = "line1Colour";
			this.line1Colour.Size = new System.Drawing.Size(36, 32);
			this.line1Colour.TabIndex = 18;
			this.toolTip1.SetToolTip(this.line1Colour, "Select a colour to edit.");
			this.line1Colour.UseVisualStyleBackColor = false;
			this.line1Colour.Click += new System.EventHandler(this.line1Colour_Click);
			// 
			// line2Colour
			// 
			this.line2Colour.BackColor = System.Drawing.Color.Lime;
			this.line2Colour.FlatAppearance.BorderSize = 0;
			this.line2Colour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.line2Colour.Location = new System.Drawing.Point(346, 194);
			this.line2Colour.Margin = new System.Windows.Forms.Padding(0);
			this.line2Colour.Name = "line2Colour";
			this.line2Colour.Size = new System.Drawing.Size(36, 32);
			this.line2Colour.TabIndex = 19;
			this.toolTip1.SetToolTip(this.line2Colour, "Select a colour to edit.");
			this.line2Colour.UseVisualStyleBackColor = false;
			this.line2Colour.Click += new System.EventHandler(this.line2Colour_Click);
			// 
			// line3Colour
			// 
			this.line3Colour.BackColor = System.Drawing.Color.Blue;
			this.line3Colour.FlatAppearance.BorderSize = 0;
			this.line3Colour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.line3Colour.Location = new System.Drawing.Point(346, 234);
			this.line3Colour.Margin = new System.Windows.Forms.Padding(0);
			this.line3Colour.Name = "line3Colour";
			this.line3Colour.Size = new System.Drawing.Size(36, 32);
			this.line3Colour.TabIndex = 20;
			this.toolTip1.SetToolTip(this.line3Colour, "Select a colour to edit.");
			this.line3Colour.UseVisualStyleBackColor = false;
			this.line3Colour.Click += new System.EventHandler(this.line3Colour_Click);
			// 
			// line4Colour
			// 
			this.line4Colour.BackColor = System.Drawing.Color.Yellow;
			this.line4Colour.FlatAppearance.BorderSize = 0;
			this.line4Colour.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.line4Colour.Location = new System.Drawing.Point(346, 274);
			this.line4Colour.Margin = new System.Windows.Forms.Padding(0);
			this.line4Colour.Name = "line4Colour";
			this.line4Colour.Size = new System.Drawing.Size(36, 32);
			this.line4Colour.TabIndex = 21;
			this.toolTip1.SetToolTip(this.line4Colour, "Select a colour to edit.");
			this.line4Colour.UseVisualStyleBackColor = false;
			this.line4Colour.Click += new System.EventHandler(this.line4Colour_Click);
			// 
			// label95
			// 
			this.label95.AutoSize = true;
			this.label95.Location = new System.Drawing.Point(440, 247);
			this.label95.Name = "label95";
			this.label95.Size = new System.Drawing.Size(62, 17);
			this.label95.TabIndex = 91;
			this.label95.Text = "Position:";
			// 
			// trackBarCustomSpeed
			// 
			this.trackBarCustomSpeed.AutoSize = false;
			this.trackBarCustomSpeed.Location = new System.Drawing.Point(401, 195);
			this.trackBarCustomSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarCustomSpeed.Maximum = 20;
			this.trackBarCustomSpeed.Minimum = 1;
			this.trackBarCustomSpeed.Name = "trackBarCustomSpeed";
			this.trackBarCustomSpeed.Size = new System.Drawing.Size(373, 32);
			this.trackBarCustomSpeed.TabIndex = 22;
			this.trackBarCustomSpeed.Value = 5;
			this.trackBarCustomSpeed.Scroll += new System.EventHandler(this.trackBarCustomSpeed_Scroll);
			this.trackBarCustomSpeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarCustomSpeed_MouseDown);
			this.trackBarCustomSpeed.MouseLeave += new System.EventHandler(this.trackBarCustomSpeed_MouseLeave);
			this.trackBarCustomSpeed.MouseHover += new System.EventHandler(this.trackBarCustomSpeed_MouseHover);
			// 
			// buttonPlay
			// 
			this.buttonPlay.BackColor = System.Drawing.Color.Azure;
			this.buttonPlay.FlatAppearance.BorderSize = 0;
			this.buttonPlay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonPlay.Location = new System.Drawing.Point(548, 18);
			this.buttonPlay.Margin = new System.Windows.Forms.Padding(0);
			this.buttonPlay.Name = "buttonPlay";
			this.buttonPlay.Size = new System.Drawing.Size(34, 30);
			this.buttonPlay.TabIndex = 6;
			this.buttonPlay.Text = "P";
			this.toolTip1.SetToolTip(this.buttonPlay, "Play selected message. Useful for testing current message\r\nor displaying an immed" +
        "iate message to the audience.");
			this.buttonPlay.UseVisualStyleBackColor = false;
			this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
			// 
			// CustomMsgLength
			// 
			this.CustomMsgLength.Location = new System.Drawing.Point(509, 99);
			this.CustomMsgLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.CustomMsgLength.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
			this.CustomMsgLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.CustomMsgLength.Name = "CustomMsgLength";
			this.CustomMsgLength.Size = new System.Drawing.Size(44, 22);
			this.CustomMsgLength.TabIndex = 12;
			this.CustomMsgLength.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.CustomMsgLength.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CustomMsgLength_MouseClick);
			this.CustomMsgLength.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CustomMsgLength_MouseDown);
			// 
			// label94
			// 
			this.label94.AutoSize = true;
			this.label94.Location = new System.Drawing.Point(405, 101);
			this.label94.Name = "label94";
			this.label94.Size = new System.Drawing.Size(86, 17);
			this.label94.TabIndex = 87;
			this.label94.Text = "Msg Length:";
			this.toolTip1.SetToolTip(this.label94, "Time the message is displayed for in seconds.");
			// 
			// textBoxCustomFontSize
			// 
			this.textBoxCustomFontSize.BackColor = System.Drawing.Color.White;
			this.textBoxCustomFontSize.Enabled = false;
			this.textBoxCustomFontSize.Location = new System.Drawing.Point(652, 134);
			this.textBoxCustomFontSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxCustomFontSize.Name = "textBoxCustomFontSize";
			this.textBoxCustomFontSize.Size = new System.Drawing.Size(77, 22);
			this.textBoxCustomFontSize.TabIndex = 86;
			this.textBoxCustomFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBoxCustomFontSize.MouseLeave += new System.EventHandler(this.textBoxCustomFontSize_MouseLeave);
			// 
			// textBoxCustomFont
			// 
			this.textBoxCustomFont.BackColor = System.Drawing.Color.White;
			this.textBoxCustomFont.Enabled = false;
			this.textBoxCustomFont.ForeColor = System.Drawing.SystemColors.InfoText;
			this.textBoxCustomFont.Location = new System.Drawing.Point(612, 98);
			this.textBoxCustomFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxCustomFont.Name = "textBoxCustomFont";
			this.textBoxCustomFont.Size = new System.Drawing.Size(158, 22);
			this.textBoxCustomFont.TabIndex = 67;
			this.textBoxCustomFont.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBoxCustomFont.MouseLeave += new System.EventHandler(this.textBoxCustomFont_MouseLeave);
			// 
			// buttonCustomFont
			// 
			this.buttonCustomFont.BackColor = System.Drawing.Color.Honeydew;
			this.buttonCustomFont.Location = new System.Drawing.Point(631, 62);
			this.buttonCustomFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonCustomFont.Name = "buttonCustomFont";
			this.buttonCustomFont.Size = new System.Drawing.Size(115, 26);
			this.buttonCustomFont.TabIndex = 11;
			this.buttonCustomFont.Text = "Font Selection";
			this.buttonCustomFont.UseVisualStyleBackColor = false;
			this.buttonCustomFont.Click += new System.EventHandler(this.buttonCustomFont_Click);
			// 
			// label93
			// 
			this.label93.AutoSize = true;
			this.label93.Location = new System.Drawing.Point(131, 25);
			this.label93.Name = "label93";
			this.label93.Size = new System.Drawing.Size(110, 17);
			this.label93.TabIndex = 84;
			this.label93.Text = "Message Name:";
			// 
			// comboBoxName
			// 
			this.comboBoxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxName.FormattingEnabled = true;
			this.comboBoxName.Location = new System.Drawing.Point(248, 22);
			this.comboBoxName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxName.Name = "comboBoxName";
			this.comboBoxName.Size = new System.Drawing.Size(194, 24);
			this.comboBoxName.TabIndex = 3;
			this.toolTip1.SetToolTip(this.comboBoxName, "List all messages that have been created.");
			this.comboBoxName.SelectedIndexChanged += new System.EventHandler(this.comboBoxName_SelectedIndexChanged);
			// 
			// checkBoxMessageEnabled
			// 
			this.checkBoxMessageEnabled.AutoSize = true;
			this.checkBoxMessageEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxMessageEnabled.Location = new System.Drawing.Point(633, 24);
			this.checkBoxMessageEnabled.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxMessageEnabled.Name = "checkBoxMessageEnabled";
			this.checkBoxMessageEnabled.Size = new System.Drawing.Size(108, 21);
			this.checkBoxMessageEnabled.TabIndex = 7;
			this.checkBoxMessageEnabled.Text = "Enable Msg:";
			this.toolTip1.SetToolTip(this.checkBoxMessageEnabled, "Enable this message to be included in the selection to be displayed.");
			this.checkBoxMessageEnabled.UseVisualStyleBackColor = true;
			this.checkBoxMessageEnabled.MouseLeave += new System.EventHandler(this.checkBoxMessageEnabled_MouseLeave);
			// 
			// buttonRemoveMessage
			// 
			this.buttonRemoveMessage.BackColor = System.Drawing.Color.Azure;
			this.buttonRemoveMessage.FlatAppearance.BorderSize = 0;
			this.buttonRemoveMessage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveMessage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveMessage.Location = new System.Drawing.Point(503, 18);
			this.buttonRemoveMessage.Margin = new System.Windows.Forms.Padding(0);
			this.buttonRemoveMessage.Name = "buttonRemoveMessage";
			this.buttonRemoveMessage.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveMessage.TabIndex = 5;
			this.buttonRemoveMessage.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveMessage, "Delete selected message.");
			this.buttonRemoveMessage.UseVisualStyleBackColor = false;
			this.buttonRemoveMessage.Click += new System.EventHandler(this.buttonRemoveMessage_Click);
			// 
			// buttonAddMessage
			// 
			this.buttonAddMessage.BackColor = System.Drawing.Color.Azure;
			this.buttonAddMessage.FlatAppearance.BorderSize = 0;
			this.buttonAddMessage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonAddMessage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonAddMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAddMessage.Location = new System.Drawing.Point(458, 18);
			this.buttonAddMessage.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAddMessage.Name = "buttonAddMessage";
			this.buttonAddMessage.Size = new System.Drawing.Size(34, 30);
			this.buttonAddMessage.TabIndex = 4;
			this.buttonAddMessage.Text = "+";
			this.toolTip1.SetToolTip(this.buttonAddMessage, "Create new message.");
			this.buttonAddMessage.UseVisualStyleBackColor = false;
			this.buttonAddMessage.Click += new System.EventHandler(this.buttonAddMessage_Click);
			// 
			// comboBoxCountDownDirection
			// 
			this.comboBoxCountDownDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCountDownDirection.FormattingEnabled = true;
			this.comboBoxCountDownDirection.Items.AddRange(new object[] {
            "Left",
            "Right",
            "Up",
            "Down",
            "None"});
			this.comboBoxCountDownDirection.Location = new System.Drawing.Point(509, 65);
			this.comboBoxCountDownDirection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxCountDownDirection.Name = "comboBoxCountDownDirection";
			this.comboBoxCountDownDirection.Size = new System.Drawing.Size(77, 24);
			this.comboBoxCountDownDirection.TabIndex = 10;
			this.toolTip1.SetToolTip(this.comboBoxCountDownDirection, "Direction of Text");
			this.comboBoxCountDownDirection.SelectionChangeCommitted += new System.EventHandler(this.comboBoxCountDownDirection_SelectionChangeCommitted);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(405, 67);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(99, 17);
			this.label10.TabIndex = 77;
			this.label10.Text = "Text Direction:";
			// 
			// label92
			// 
			this.label92.AutoSize = true;
			this.label92.Location = new System.Drawing.Point(9, 285);
			this.label92.Name = "label92";
			this.label92.Size = new System.Drawing.Size(16, 17);
			this.label92.TabIndex = 77;
			this.label92.Text = "4";
			// 
			// label91
			// 
			this.label91.AutoSize = true;
			this.label91.Location = new System.Drawing.Point(9, 245);
			this.label91.Name = "label91";
			this.label91.Size = new System.Drawing.Size(16, 17);
			this.label91.TabIndex = 76;
			this.label91.Text = "3";
			// 
			// label90
			// 
			this.label90.AutoSize = true;
			this.label90.Location = new System.Drawing.Point(9, 204);
			this.label90.Name = "label90";
			this.label90.Size = new System.Drawing.Size(16, 17);
			this.label90.TabIndex = 75;
			this.label90.Text = "2";
			// 
			// label89
			// 
			this.label89.AutoSize = true;
			this.label89.Location = new System.Drawing.Point(9, 162);
			this.label89.Name = "label89";
			this.label89.Size = new System.Drawing.Size(16, 17);
			this.label89.TabIndex = 74;
			this.label89.Text = "1";
			// 
			// textBoxLine1
			// 
			this.textBoxLine1.Location = new System.Drawing.Point(27, 159);
			this.textBoxLine1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxLine1.Name = "textBoxLine1";
			this.textBoxLine1.Size = new System.Drawing.Size(285, 22);
			this.textBoxLine1.TabIndex = 14;
			this.toolTip1.SetToolTip(this.textBoxLine1, "Add the word COUNTDOWN to your message to display the number of days until select" +
        "ed date.");
			this.textBoxLine1.Leave += new System.EventHandler(this.textBoxLine1_MouseLeave);
			// 
			// textBoxLine2
			// 
			this.textBoxLine2.Location = new System.Drawing.Point(27, 199);
			this.textBoxLine2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxLine2.Name = "textBoxLine2";
			this.textBoxLine2.Size = new System.Drawing.Size(285, 22);
			this.textBoxLine2.TabIndex = 15;
			this.toolTip1.SetToolTip(this.textBoxLine2, "Add the word COUNTDOWN to your message to display the number of days until select" +
        "ed date.");
			this.textBoxLine2.Leave += new System.EventHandler(this.textBoxLine2_MouseLeave);
			// 
			// label86
			// 
			this.label86.AutoSize = true;
			this.label86.Location = new System.Drawing.Point(440, 170);
			this.label86.Name = "label86";
			this.label86.Size = new System.Drawing.Size(53, 17);
			this.label86.TabIndex = 73;
			this.label86.Text = "Speed:";
			// 
			// textBoxLine3
			// 
			this.textBoxLine3.Location = new System.Drawing.Point(27, 240);
			this.textBoxLine3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxLine3.Name = "textBoxLine3";
			this.textBoxLine3.Size = new System.Drawing.Size(285, 22);
			this.textBoxLine3.TabIndex = 16;
			this.toolTip1.SetToolTip(this.textBoxLine3, "Add the word COUNTDOWN to your message to display the number of days until select" +
        "ed date.");
			this.textBoxLine3.Leave += new System.EventHandler(this.textBoxLine3_MouseLeave);
			// 
			// trackBarCountDownPosition
			// 
			this.trackBarCountDownPosition.AutoSize = false;
			this.trackBarCountDownPosition.Location = new System.Drawing.Point(401, 272);
			this.trackBarCountDownPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarCountDownPosition.Maximum = 100;
			this.trackBarCountDownPosition.Minimum = 1;
			this.trackBarCountDownPosition.Name = "trackBarCountDownPosition";
			this.trackBarCountDownPosition.Size = new System.Drawing.Size(373, 32);
			this.trackBarCountDownPosition.TabIndex = 23;
			this.trackBarCountDownPosition.Value = 65;
			this.trackBarCountDownPosition.Scroll += new System.EventHandler(this.trackBarCountDownPosition_Scroll);
			this.trackBarCountDownPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarCountDownPosition_MouseDown);
			this.trackBarCountDownPosition.MouseLeave += new System.EventHandler(this.trackBarCountDownPosition_MouseLeave);
			this.trackBarCountDownPosition.MouseHover += new System.EventHandler(this.trackBarCountDownPosition_MouseHover);
			// 
			// textBoxLine4
			// 
			this.textBoxLine4.Location = new System.Drawing.Point(27, 280);
			this.textBoxLine4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxLine4.Name = "textBoxLine4";
			this.textBoxLine4.Size = new System.Drawing.Size(285, 22);
			this.textBoxLine4.TabIndex = 17;
			this.toolTip1.SetToolTip(this.textBoxLine4, "Add the word COUNTDOWN to your message to display the number of days until select" +
        "ed date.");
			this.textBoxLine4.Leave += new System.EventHandler(this.textBoxLine4_MouseLeave);
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
			// checkBoxCountDownEnable
			// 
			this.checkBoxCountDownEnable.AutoSize = true;
			this.checkBoxCountDownEnable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxCountDownEnable.Location = new System.Drawing.Point(562, 34);
			this.checkBoxCountDownEnable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxCountDownEnable.Name = "checkBoxCountDownEnable";
			this.checkBoxCountDownEnable.Size = new System.Drawing.Size(197, 21);
			this.checkBoxCountDownEnable.TabIndex = 2;
			this.checkBoxCountDownEnable.Text = "Enable Custom Messages:";
			this.checkBoxCountDownEnable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.toolTip1.SetToolTip(this.checkBoxCountDownEnable, "Enables Custom messages using Lines below and will be added to the Random/Sequent" +
        "ial play list.\r\nCOUNTDOWN can still be used in the Standard messages list.");
			this.checkBoxCountDownEnable.UseVisualStyleBackColor = true;
			this.checkBoxCountDownEnable.CheckedChanged += new System.EventHandler(this.checkBoxCountDownEnable_CheckedChanged);
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
			this.checkBoxBlacklist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
			this.checkBoxWhitelist.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
			// label46
			// 
			this.label46.AutoSize = true;
			this.label46.Location = new System.Drawing.Point(12, 71);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(93, 17);
			this.label46.TabIndex = 53;
			this.label46.Text = "Line Number:";
			this.toolTip1.SetToolTip(this.label46, "Select the line number for the mesdsage to be displayed on.");
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
			// comboBoxNodeID
			// 
			this.comboBoxNodeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxNodeID.FormattingEnabled = true;
			this.comboBoxNodeID.Location = new System.Drawing.Point(154, 34);
			this.comboBoxNodeID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxNodeID.Name = "comboBoxNodeID";
			this.comboBoxNodeID.Size = new System.Drawing.Size(267, 24);
			this.comboBoxNodeID.TabIndex = 85;
			this.toolTip1.SetToolTip(this.comboBoxNodeID, "List of NodeID\'s");
			this.comboBoxNodeID.SelectedIndexChanged += new System.EventHandler(this.comboBoxNodeID_SelectedIndexChanged);
			// 
			// buttonRemoveNodeID
			// 
			this.buttonRemoveNodeID.BackColor = System.Drawing.Color.Azure;
			this.buttonRemoveNodeID.FlatAppearance.BorderSize = 0;
			this.buttonRemoveNodeID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveNodeID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonRemoveNodeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonRemoveNodeID.Location = new System.Drawing.Point(484, 30);
			this.buttonRemoveNodeID.Margin = new System.Windows.Forms.Padding(0);
			this.buttonRemoveNodeID.Name = "buttonRemoveNodeID";
			this.buttonRemoveNodeID.Size = new System.Drawing.Size(34, 30);
			this.buttonRemoveNodeID.TabIndex = 87;
			this.buttonRemoveNodeID.Text = "-";
			this.toolTip1.SetToolTip(this.buttonRemoveNodeID, "Delete selected NodeID.");
			this.buttonRemoveNodeID.UseVisualStyleBackColor = false;
			this.buttonRemoveNodeID.Click += new System.EventHandler(this.buttonRemoveNodeID_Click);
			// 
			// buttonAddNodeID
			// 
			this.buttonAddNodeID.BackColor = System.Drawing.Color.Azure;
			this.buttonAddNodeID.FlatAppearance.BorderSize = 0;
			this.buttonAddNodeID.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.buttonAddNodeID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.buttonAddNodeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonAddNodeID.Location = new System.Drawing.Point(439, 30);
			this.buttonAddNodeID.Margin = new System.Windows.Forms.Padding(0);
			this.buttonAddNodeID.Name = "buttonAddNodeID";
			this.buttonAddNodeID.Size = new System.Drawing.Size(34, 30);
			this.buttonAddNodeID.TabIndex = 86;
			this.buttonAddNodeID.Text = "+";
			this.toolTip1.SetToolTip(this.buttonAddNodeID, "Add new NodeID.");
			this.buttonAddNodeID.UseVisualStyleBackColor = false;
			this.buttonAddNodeID.Click += new System.EventHandler(this.buttonAddNodeID_Click);
			// 
			// label100
			// 
			this.label100.AutoSize = true;
			this.label100.Location = new System.Drawing.Point(12, 37);
			this.label100.Name = "label100";
			this.label100.Size = new System.Drawing.Size(107, 17);
			this.label100.TabIndex = 89;
			this.label100.Text = "Group Node ID:";
			this.toolTip1.SetToolTip(this.label100, "Displayed Group ID will be the one used for Incoming Messages.");
			// 
			// checkBoxTextFile
			// 
			this.checkBoxTextFile.AutoSize = true;
			this.checkBoxTextFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxTextFile.Location = new System.Drawing.Point(422, 29);
			this.checkBoxTextFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.checkBoxTextFile.Name = "checkBoxTextFile";
			this.checkBoxTextFile.Size = new System.Drawing.Size(83, 21);
			this.checkBoxTextFile.TabIndex = 60;
			this.checkBoxTextFile.Tag = "4";
			this.checkBoxTextFile.Text = "Text File";
			this.toolTip1.SetToolTip(this.checkBoxTextFile, "Select to retrieve messages from a local Text File.\r\nOptions found in Messaging S" +
        "ettings Tab.");
			this.checkBoxTextFile.UseVisualStyleBackColor = true;
			this.checkBoxTextFile.CheckedChanged += new System.EventHandler(this.checkBoxTextFile_CheckedChanged);
			// 
			// checkBoxdeleteTextFile
			// 
			this.checkBoxdeleteTextFile.AutoSize = true;
			this.checkBoxdeleteTextFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxdeleteTextFile.Location = new System.Drawing.Point(15, 213);
			this.checkBoxdeleteTextFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxdeleteTextFile.Name = "checkBoxdeleteTextFile";
			this.checkBoxdeleteTextFile.Size = new System.Drawing.Size(299, 21);
			this.checkBoxdeleteTextFile.TabIndex = 11;
			this.checkBoxdeleteTextFile.Text = "Delete Text File Message after processing:";
			this.toolTip1.SetToolTip(this.checkBoxdeleteTextFile, "Select to delete the file once the message has been processed. If unchecked the f" +
        "ile will be processed and then moved to the Processed folder.");
			this.checkBoxdeleteTextFile.UseVisualStyleBackColor = true;
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
			this.tabControlMain.Controls.Add(this.tabPageMessagingSettings);
			this.tabControlMain.Controls.Add(this.tabPageTextSetting);
			this.tabControlMain.Controls.Add(this.localMsgs);
			this.tabControlMain.Controls.Add(this.tabPageSeqSettings);
			this.tabControlMain.Controls.Add(this.tabPageWordLists);
			this.tabControlMain.Controls.Add(this.remoteCmds);
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
			this.tabPageMain.Controls.Add(this.groupBoxPlayOptions);
			this.tabPageMain.Controls.Add(this.label74);
			this.tabPageMain.Controls.Add(this.numericUpDownIntervalMsgs);
			this.tabPageMain.Controls.Add(this.label71);
			this.tabPageMain.Controls.Add(this.label14);
			this.tabPageMain.Controls.Add(this.checkBoxBlacklist);
			this.tabPageMain.Controls.Add(this.checkBoxWhitelist);
			this.tabPageMain.Controls.Add(this.groupBox1);
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
			// groupBoxPlayOptions
			// 
			this.groupBoxPlayOptions.Controls.Add(this.checkBoxTextFile);
			this.groupBoxPlayOptions.Controls.Add(this.comboBoxPlayMode);
			this.groupBoxPlayOptions.Controls.Add(this.checkBoxEmail);
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
			// tabPageMessagingSettings
			// 
			this.tabPageMessagingSettings.BackColor = System.Drawing.Color.Azure;
			this.tabPageMessagingSettings.Controls.Add(this.groupBox3);
			this.tabPageMessagingSettings.Controls.Add(this.groupBox6);
			this.tabPageMessagingSettings.Controls.Add(this.groupBox5);
			this.tabPageMessagingSettings.Controls.Add(this.buttonResetToDefault);
			this.tabPageMessagingSettings.Location = new System.Drawing.Point(4, 25);
			this.tabPageMessagingSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageMessagingSettings.Name = "tabPageMessagingSettings";
			this.tabPageMessagingSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageMessagingSettings.Size = new System.Drawing.Size(793, 707);
			this.tabPageMessagingSettings.TabIndex = 1;
			this.tabPageMessagingSettings.Text = "Messaging Settings";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label100);
			this.groupBox3.Controls.Add(this.comboBoxNodeID);
			this.groupBox3.Controls.Add(this.buttonRemoveNodeID);
			this.groupBox3.Controls.Add(this.buttonAddNodeID);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.buttonGetVixenData);
			this.groupBox3.Controls.Add(this.textBoxVixenFolder);
			this.groupBox3.Controls.Add(this.label32);
			this.groupBox3.Controls.Add(this.textBoxNodeId);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.textBoxOutputSequence);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.textBoxSequenceTemplate);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.textBoxVixenServer);
			this.groupBox3.Location = new System.Drawing.Point(12, 264);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox3.Size = new System.Drawing.Size(773, 298);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Vixen Settings";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(10, 111);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(102, 17);
			this.label7.TabIndex = 7;
			this.label7.Text = "Vixen 3 Folder:";
			// 
			// buttonGetVixenData
			// 
			this.buttonGetVixenData.BackColor = System.Drawing.Color.Honeydew;
			this.buttonGetVixenData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.buttonGetVixenData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.buttonGetVixenData.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
			this.buttonGetVixenData.Location = new System.Drawing.Point(322, 262);
			this.buttonGetVixenData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonGetVixenData.Name = "buttonGetVixenData";
			this.buttonGetVixenData.Size = new System.Drawing.Size(254, 32);
			this.buttonGetVixenData.TabIndex = 11;
			this.buttonGetVixenData.Text = "Get Vixen Data Settings";
			this.buttonGetVixenData.UseVisualStyleBackColor = false;
			this.buttonGetVixenData.Click += new System.EventHandler(this.buttonGetVixenData_Click);
			// 
			// textBoxVixenFolder
			// 
			this.textBoxVixenFolder.Enabled = false;
			this.textBoxVixenFolder.Location = new System.Drawing.Point(154, 110);
			this.textBoxVixenFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxVixenFolder.Name = "textBoxVixenFolder";
			this.textBoxVixenFolder.Size = new System.Drawing.Size(599, 22);
			this.textBoxVixenFolder.TabIndex = 6;
			// 
			// textBoxNodeId
			// 
			this.textBoxNodeId.Enabled = false;
			this.textBoxNodeId.Location = new System.Drawing.Point(154, 72);
			this.textBoxNodeId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxNodeId.Name = "textBoxNodeId";
			this.textBoxNodeId.Size = new System.Drawing.Size(599, 22);
			this.textBoxNodeId.TabIndex = 10;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(8, 239);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(123, 17);
			this.label6.TabIndex = 6;
			this.label6.Text = "Output Sequence:";
			// 
			// textBoxOutputSequence
			// 
			this.textBoxOutputSequence.Enabled = false;
			this.textBoxOutputSequence.Location = new System.Drawing.Point(154, 236);
			this.textBoxOutputSequence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxOutputSequence.Name = "textBoxOutputSequence";
			this.textBoxOutputSequence.Size = new System.Drawing.Size(599, 22);
			this.textBoxOutputSequence.TabIndex = 9;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 194);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(124, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "Messaging Folder:";
			// 
			// textBoxSequenceTemplate
			// 
			this.textBoxSequenceTemplate.Enabled = false;
			this.textBoxSequenceTemplate.Location = new System.Drawing.Point(154, 191);
			this.textBoxSequenceTemplate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxSequenceTemplate.Name = "textBoxSequenceTemplate";
			this.textBoxSequenceTemplate.Size = new System.Drawing.Size(599, 22);
			this.textBoxSequenceTemplate.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(10, 150);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(92, 17);
			this.label4.TabIndex = 2;
			this.label4.Text = "Vixen Server:";
			// 
			// textBoxVixenServer
			// 
			this.textBoxVixenServer.Enabled = false;
			this.textBoxVixenServer.Location = new System.Drawing.Point(154, 150);
			this.textBoxVixenServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxVixenServer.Name = "textBoxVixenServer";
			this.textBoxVixenServer.Size = new System.Drawing.Size(599, 22);
			this.textBoxVixenServer.TabIndex = 7;
			// 
			// groupBox6
			// 
			this.groupBox6.Controls.Add(this.label12);
			this.groupBox6.Controls.Add(this.textBoxBlacklistEmailLog);
			this.groupBox6.Controls.Add(this.label8);
			this.groupBox6.Controls.Add(this.textBoxLogFileName);
			this.groupBox6.Location = new System.Drawing.Point(9, 567);
			this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox6.Size = new System.Drawing.Size(775, 90);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Logs";
			// 
			// textBoxBlacklistEmailLog
			// 
			this.textBoxBlacklistEmailLog.Location = new System.Drawing.Point(160, 59);
			this.textBoxBlacklistEmailLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxBlacklistEmailLog.Name = "textBoxBlacklistEmailLog";
			this.textBoxBlacklistEmailLog.Size = new System.Drawing.Size(594, 22);
			this.textBoxBlacklistEmailLog.TabIndex = 13;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(13, 27);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(97, 17);
			this.label8.TabIndex = 15;
			this.label8.Text = "Message Log:";
			// 
			// textBoxLogFileName
			// 
			this.textBoxLogFileName.Location = new System.Drawing.Point(160, 25);
			this.textBoxLogFileName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxLogFileName.Name = "textBoxLogFileName";
			this.textBoxLogFileName.Size = new System.Drawing.Size(594, 22);
			this.textBoxLogFileName.TabIndex = 12;
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.label105);
			this.groupBox5.Controls.Add(this.textBoxTextFileFolder);
			this.groupBox5.Controls.Add(this.checkBoxdeleteTextFile);
			this.groupBox5.Controls.Add(this.label78);
			this.groupBox5.Controls.Add(this.textBoxAccessPWD);
			this.groupBox5.Controls.Add(this.textBoxReturnBannedMSG);
			this.groupBox5.Controls.Add(this.label9);
			this.groupBox5.Controls.Add(this.checkBoxManEnterSettings);
			this.groupBox5.Controls.Add(this.checkBoxAutoStart);
			this.groupBox5.Controls.Add(this.label16);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Controls.Add(this.textBoxSubjectHeader);
			this.groupBox5.Location = new System.Drawing.Point(12, 14);
			this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox5.Size = new System.Drawing.Size(773, 245);
			this.groupBox5.TabIndex = 1;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Vixen Messaging Options";
			// 
			// label105
			// 
			this.label105.AutoSize = true;
			this.label105.Location = new System.Drawing.Point(344, 214);
			this.label105.Name = "label105";
			this.label105.Size = new System.Drawing.Size(109, 17);
			this.label105.TabIndex = 13;
			this.label105.Text = "Text File Folder:";
			// 
			// textBoxTextFileFolder
			// 
			this.textBoxTextFileFolder.Location = new System.Drawing.Point(468, 211);
			this.textBoxTextFileFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxTextFileFolder.Name = "textBoxTextFileFolder";
			this.textBoxTextFileFolder.ReadOnly = true;
			this.textBoxTextFileFolder.Size = new System.Drawing.Size(284, 22);
			this.textBoxTextFileFolder.TabIndex = 12;
			this.textBoxTextFileFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBoxTextFileFolder_MouseClick);
			// 
			// textBoxReturnBannedMSG
			// 
			this.textBoxReturnBannedMSG.Location = new System.Drawing.Point(176, 155);
			this.textBoxReturnBannedMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxReturnBannedMSG.Multiline = true;
			this.textBoxReturnBannedMSG.Name = "textBoxReturnBannedMSG";
			this.textBoxReturnBannedMSG.Size = new System.Drawing.Size(576, 45);
			this.textBoxReturnBannedMSG.TabIndex = 4;
			// 
			// checkBoxAutoStart
			// 
			this.checkBoxAutoStart.AutoSize = true;
			this.checkBoxAutoStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxAutoStart.Location = new System.Drawing.Point(14, 30);
			this.checkBoxAutoStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxAutoStart.Name = "checkBoxAutoStart";
			this.checkBoxAutoStart.Size = new System.Drawing.Size(281, 21);
			this.checkBoxAutoStart.TabIndex = 0;
			this.checkBoxAutoStart.Text = "Auto Start Message retrieval on startup:";
			this.checkBoxAutoStart.UseVisualStyleBackColor = true;
			// 
			// textBoxSubjectHeader
			// 
			this.textBoxSubjectHeader.Location = new System.Drawing.Point(572, 28);
			this.textBoxSubjectHeader.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxSubjectHeader.Name = "textBoxSubjectHeader";
			this.textBoxSubjectHeader.Size = new System.Drawing.Size(181, 22);
			this.textBoxSubjectHeader.TabIndex = 1;
			this.textBoxSubjectHeader.Text = "SMS from";
			// 
			// buttonResetToDefault
			// 
			this.buttonResetToDefault.BackColor = System.Drawing.Color.Honeydew;
			this.buttonResetToDefault.Location = new System.Drawing.Point(603, 671);
			this.buttonResetToDefault.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonResetToDefault.Name = "buttonResetToDefault";
			this.buttonResetToDefault.Size = new System.Drawing.Size(183, 34);
			this.buttonResetToDefault.TabIndex = 14;
			this.buttonResetToDefault.Text = "Reset to Default Setting";
			this.buttonResetToDefault.UseVisualStyleBackColor = false;
			this.buttonResetToDefault.Click += new System.EventHandler(this.buttonResetToDefault_Click);
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
			this.groupBox4.Location = new System.Drawing.Point(3, 317);
			this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox4.Size = new System.Drawing.Size(783, 388);
			this.groupBox4.TabIndex = 58;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Log";
			// 
			// richTextBoxLog1
			// 
			this.richTextBoxLog1.Location = new System.Drawing.Point(5, 23);
			this.richTextBoxLog1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxLog1.Name = "richTextBoxLog1";
			this.richTextBoxLog1.Size = new System.Drawing.Size(773, 361);
			this.richTextBoxLog1.TabIndex = 2;
			this.richTextBoxLog1.Text = "";
			// 
			// groupBoxSeqSettings
			// 
			this.groupBoxSeqSettings.Controls.Add(this.label98);
			this.groupBoxSeqSettings.Controls.Add(this.incomingMessageColourOption);
			this.groupBoxSeqSettings.Controls.Add(this.label88);
			this.groupBoxSeqSettings.Controls.Add(this.numericUpDownMaxWords);
			this.groupBoxSeqSettings.Controls.Add(this.groupBox7);
			this.groupBoxSeqSettings.Controls.Add(this.textBoxFontSize);
			this.groupBoxSeqSettings.Controls.Add(this.buttonFont);
			this.groupBoxSeqSettings.Controls.Add(this.textBoxFont);
			this.groupBoxSeqSettings.Controls.Add(this.comboBoxString);
			this.groupBoxSeqSettings.Controls.Add(this.label36);
			this.groupBoxSeqSettings.Controls.Add(this.TextLineNumber);
			this.groupBoxSeqSettings.Controls.Add(this.label46);
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
			this.groupBoxSeqSettings.Size = new System.Drawing.Size(780, 288);
			this.groupBoxSeqSettings.TabIndex = 1;
			this.groupBoxSeqSettings.TabStop = false;
			this.groupBoxSeqSettings.Text = "Incoming Message / Text Settings";
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
			// TextLineNumber
			// 
			this.TextLineNumber.Location = new System.Drawing.Point(111, 69);
			this.TextLineNumber.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TextLineNumber.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.TextLineNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.TextLineNumber.Name = "TextLineNumber";
			this.TextLineNumber.Size = new System.Drawing.Size(64, 22);
			this.TextLineNumber.TabIndex = 3;
			this.TextLineNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            "None"});
			this.comboBoxTextDirection.Location = new System.Drawing.Point(291, 69);
			this.comboBoxTextDirection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxTextDirection.Name = "comboBoxTextDirection";
			this.comboBoxTextDirection.Size = new System.Drawing.Size(77, 24);
			this.comboBoxTextDirection.TabIndex = 4;
			// 
			// trackBarTextPosition
			// 
			this.trackBarTextPosition.AutoSize = false;
			this.trackBarTextPosition.Location = new System.Drawing.Point(100, 159);
			this.trackBarTextPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarTextPosition.Maximum = 100;
			this.trackBarTextPosition.Minimum = 1;
			this.trackBarTextPosition.Name = "trackBarTextPosition";
			this.trackBarTextPosition.Size = new System.Drawing.Size(300, 32);
			this.trackBarTextPosition.TabIndex = 8;
			this.trackBarTextPosition.Value = 10;
			this.trackBarTextPosition.Scroll += new System.EventHandler(this.trackBarTextPosition_Scroll);
			this.trackBarTextPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextPosition_MouseDown);
			this.trackBarTextPosition.MouseHover += new System.EventHandler(this.trackBarTextPosition_MouseHover);
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(10, 166);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(93, 17);
			this.label44.TabIndex = 50;
			this.label44.Text = "Text Position:";
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
			this.trackBarTextSpeed.Value = 5;
			this.trackBarTextSpeed.Scroll += new System.EventHandler(this.trackBarTextSpeed_Scroll);
			this.trackBarTextSpeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextSpeed_MouseDown);
			this.trackBarTextSpeed.MouseHover += new System.EventHandler(this.trackBarTextSpeed_MouseHover);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(413, 166);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(84, 17);
			this.label21.TabIndex = 48;
			this.label21.Text = "Text Speed:";
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
			this.groupBoxMessages.Controls.Add(this.groupBoxCountDown);
			this.groupBoxMessages.Controls.Add(this.checkBoxCountDownEnable);
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
			this.dateCountDown.CustomFormat = "";
			this.dateCountDown.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateCountDown.Location = new System.Drawing.Point(168, 31);
			this.dateCountDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.dateCountDown.Name = "dateCountDown";
			this.dateCountDown.Size = new System.Drawing.Size(123, 22);
			this.dateCountDown.TabIndex = 0;
			this.dateCountDown.Value = new System.DateTime(2015, 12, 25, 0, 0, 0, 0);
			// 
			// tabPageSeqSettings
			// 
			this.tabPageSeqSettings.BackColor = System.Drawing.Color.Azure;
			this.tabPageSeqSettings.Controls.Add(this.groupBoxLog);
			this.tabPageSeqSettings.Controls.Add(this.checkBoxDisableSeq);
			this.tabPageSeqSettings.Controls.Add(this.checkBoxRandomSeqSelection);
			this.tabPageSeqSettings.Controls.Add(this.groupBoxSeqControl);
			this.tabPageSeqSettings.Controls.Add(this.groupBoxEffects);
			this.tabPageSeqSettings.Controls.Add(this.label26);
			this.tabPageSeqSettings.Controls.Add(this.checkBoxEnableSqnctrl);
			this.tabPageSeqSettings.Location = new System.Drawing.Point(4, 25);
			this.tabPageSeqSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageSeqSettings.Name = "tabPageSeqSettings";
			this.tabPageSeqSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabPageSeqSettings.Size = new System.Drawing.Size(793, 707);
			this.tabPageSeqSettings.TabIndex = 3;
			this.tabPageSeqSettings.Text = "Sequence Settings";
			// 
			// groupBoxLog
			// 
			this.groupBoxLog.Controls.Add(this.richTextBoxLog2);
			this.groupBoxLog.Location = new System.Drawing.Point(3, 557);
			this.groupBoxLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxLog.Name = "groupBoxLog";
			this.groupBoxLog.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxLog.Size = new System.Drawing.Size(790, 152);
			this.groupBoxLog.TabIndex = 42;
			this.groupBoxLog.TabStop = false;
			this.groupBoxLog.Text = "Log";
			// 
			// richTextBoxLog2
			// 
			this.richTextBoxLog2.Location = new System.Drawing.Point(3, 21);
			this.richTextBoxLog2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxLog2.Name = "richTextBoxLog2";
			this.richTextBoxLog2.Size = new System.Drawing.Size(779, 130);
			this.richTextBoxLog2.TabIndex = 41;
			this.richTextBoxLog2.Text = "";
			// 
			// groupBoxSeqControl
			// 
			this.groupBoxSeqControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxSeqControl.Controls.Add(this.tabControlSequence);
			this.groupBoxSeqControl.Location = new System.Drawing.Point(5, 302);
			this.groupBoxSeqControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxSeqControl.Name = "groupBoxSeqControl";
			this.groupBoxSeqControl.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxSeqControl.Size = new System.Drawing.Size(780, 226);
			this.groupBoxSeqControl.TabIndex = 39;
			this.groupBoxSeqControl.TabStop = false;
			this.groupBoxSeqControl.Text = "Vixen Sequences";
			// 
			// tabControlSequence
			// 
			this.tabControlSequence.Controls.Add(this.TabSeq1);
			this.tabControlSequence.Controls.Add(this.TabSeq2);
			this.tabControlSequence.Controls.Add(this.TabSeq3);
			this.tabControlSequence.Controls.Add(this.TabSeq4);
			this.tabControlSequence.Controls.Add(this.TabSeq5);
			this.tabControlSequence.Controls.Add(this.TabSeq6);
			this.tabControlSequence.Location = new System.Drawing.Point(4, 23);
			this.tabControlSequence.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.tabControlSequence.Name = "tabControlSequence";
			this.tabControlSequence.SelectedIndex = 0;
			this.tabControlSequence.Size = new System.Drawing.Size(768, 194);
			this.tabControlSequence.TabIndex = 3;
			this.tabControlSequence.SelectedIndexChanged += new System.EventHandler(this.tabControlSequence_SelectedIndexChanged_1);
			// 
			// TabSeq3
			// 
			this.TabSeq3.BackColor = System.Drawing.Color.Azure;
			this.TabSeq3.Controls.Add(this.label47);
			this.TabSeq3.Controls.Add(this.textBoxSequenceLength3);
			this.TabSeq3.Controls.Add(this.label25);
			this.TabSeq3.Controls.Add(this.buttonRemoveSeq3);
			this.TabSeq3.Controls.Add(this.label38);
			this.TabSeq3.Controls.Add(this.textBoxVixenSeq3);
			this.TabSeq3.Controls.Add(this.buttonVixenSeq3);
			this.TabSeq3.Controls.Add(this.label23);
			this.TabSeq3.Location = new System.Drawing.Point(4, 25);
			this.TabSeq3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq3.Name = "TabSeq3";
			this.TabSeq3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq3.Size = new System.Drawing.Size(760, 165);
			this.TabSeq3.TabIndex = 2;
			this.TabSeq3.Text = "Seq 3";
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(4, 122);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(702, 39);
			this.label47.TabIndex = 32;
			this.label47.Text = "Note: This will not modify your Vixen 3 sequence in any way, Vixen Messaging will" +
    " create and modify a copy of your sequence to be used when a message has been re" +
    "ceived. Filename is Vixen3Out.tim";
			// 
			// textBoxSequenceLength3
			// 
			this.textBoxSequenceLength3.BackColor = System.Drawing.Color.White;
			this.textBoxSequenceLength3.Enabled = false;
			this.textBoxSequenceLength3.Location = new System.Drawing.Point(592, 90);
			this.textBoxSequenceLength3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxSequenceLength3.Name = "textBoxSequenceLength3";
			this.textBoxSequenceLength3.Size = new System.Drawing.Size(114, 22);
			this.textBoxSequenceLength3.TabIndex = 4;
			this.textBoxSequenceLength3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(453, 93);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(124, 17);
			this.label25.TabIndex = 30;
			this.label25.Text = "Sequence Length:";
			// 
			// label38
			// 
			this.label38.Location = new System.Drawing.Point(231, 46);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(475, 42);
			this.label38.TabIndex = 25;
			this.label38.Text = "Select the Vixen Sequence you would like to use. Normally located in your Documen" +
    "ts\\Vixen 3\\Sequence\\ Folder.";
			// 
			// textBoxVixenSeq3
			// 
			this.textBoxVixenSeq3.BackColor = System.Drawing.Color.White;
			this.textBoxVixenSeq3.Enabled = false;
			this.textBoxVixenSeq3.Location = new System.Drawing.Point(135, 14);
			this.textBoxVixenSeq3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxVixenSeq3.Name = "textBoxVixenSeq3";
			this.textBoxVixenSeq3.Size = new System.Drawing.Size(533, 22);
			this.textBoxVixenSeq3.TabIndex = 3;
			// 
			// buttonVixenSeq3
			// 
			this.buttonVixenSeq3.Location = new System.Drawing.Point(5, 50);
			this.buttonVixenSeq3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonVixenSeq3.Name = "buttonVixenSeq3";
			this.buttonVixenSeq3.Size = new System.Drawing.Size(190, 34);
			this.buttonVixenSeq3.TabIndex = 1;
			this.buttonVixenSeq3.Text = "Set Vixen Sequence Path";
			this.buttonVixenSeq3.UseVisualStyleBackColor = true;
			this.buttonVixenSeq3.Click += new System.EventHandler(this.buttonVixenSeq3_Click);
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Location = new System.Drawing.Point(11, 20);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(114, 17);
			this.label23.TabIndex = 22;
			this.label23.Text = "Vixen Sequence:";
			// 
			// TabSeq4
			// 
			this.TabSeq4.BackColor = System.Drawing.Color.Azure;
			this.TabSeq4.Controls.Add(this.label50);
			this.TabSeq4.Controls.Add(this.textBoxSequenceLength4);
			this.TabSeq4.Controls.Add(this.label41);
			this.TabSeq4.Controls.Add(this.buttonRemoveSeq4);
			this.TabSeq4.Controls.Add(this.label42);
			this.TabSeq4.Controls.Add(this.textBoxVixenSeq4);
			this.TabSeq4.Controls.Add(this.buttonVixenSeq4);
			this.TabSeq4.Controls.Add(this.label43);
			this.TabSeq4.Location = new System.Drawing.Point(4, 25);
			this.TabSeq4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq4.Name = "TabSeq4";
			this.TabSeq4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq4.Size = new System.Drawing.Size(760, 165);
			this.TabSeq4.TabIndex = 3;
			this.TabSeq4.Text = "Seq 4";
			// 
			// label50
			// 
			this.label50.Location = new System.Drawing.Point(4, 122);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(702, 39);
			this.label50.TabIndex = 39;
			this.label50.Text = "Note: This will not modify your Vixen 3 sequence in any way, Vixen Messaging will" +
    " create and modify a copy of your sequence to be used when a message has been re" +
    "ceived. Filename is Vixen3Out.tim";
			// 
			// textBoxSequenceLength4
			// 
			this.textBoxSequenceLength4.BackColor = System.Drawing.Color.White;
			this.textBoxSequenceLength4.Enabled = false;
			this.textBoxSequenceLength4.Location = new System.Drawing.Point(592, 90);
			this.textBoxSequenceLength4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxSequenceLength4.Name = "textBoxSequenceLength4";
			this.textBoxSequenceLength4.Size = new System.Drawing.Size(114, 22);
			this.textBoxSequenceLength4.TabIndex = 4;
			this.textBoxSequenceLength4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label41
			// 
			this.label41.AutoSize = true;
			this.label41.Location = new System.Drawing.Point(453, 93);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(124, 17);
			this.label41.TabIndex = 37;
			this.label41.Text = "Sequence Length:";
			// 
			// label42
			// 
			this.label42.Location = new System.Drawing.Point(231, 46);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(475, 42);
			this.label42.TabIndex = 35;
			this.label42.Text = "Select the Vixen Sequence you would like to use. Normally located in your Documen" +
    "ts\\Vixen 3\\Sequence\\ Folder.";
			// 
			// textBoxVixenSeq4
			// 
			this.textBoxVixenSeq4.BackColor = System.Drawing.Color.White;
			this.textBoxVixenSeq4.Enabled = false;
			this.textBoxVixenSeq4.Location = new System.Drawing.Point(135, 14);
			this.textBoxVixenSeq4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxVixenSeq4.Name = "textBoxVixenSeq4";
			this.textBoxVixenSeq4.Size = new System.Drawing.Size(532, 22);
			this.textBoxVixenSeq4.TabIndex = 3;
			// 
			// buttonVixenSeq4
			// 
			this.buttonVixenSeq4.Location = new System.Drawing.Point(5, 50);
			this.buttonVixenSeq4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonVixenSeq4.Name = "buttonVixenSeq4";
			this.buttonVixenSeq4.Size = new System.Drawing.Size(190, 34);
			this.buttonVixenSeq4.TabIndex = 1;
			this.buttonVixenSeq4.Text = "Set Vixen Sequence Path";
			this.buttonVixenSeq4.UseVisualStyleBackColor = true;
			this.buttonVixenSeq4.Click += new System.EventHandler(this.buttonVixenSeq4_Click);
			// 
			// label43
			// 
			this.label43.AutoSize = true;
			this.label43.Location = new System.Drawing.Point(11, 20);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(114, 17);
			this.label43.TabIndex = 32;
			this.label43.Text = "Vixen Sequence:";
			// 
			// TabSeq5
			// 
			this.TabSeq5.BackColor = System.Drawing.Color.Azure;
			this.TabSeq5.Controls.Add(this.label27);
			this.TabSeq5.Controls.Add(this.textBoxSequenceLength5);
			this.TabSeq5.Controls.Add(this.label57);
			this.TabSeq5.Controls.Add(this.buttonRemoveSeq5);
			this.TabSeq5.Controls.Add(this.label58);
			this.TabSeq5.Controls.Add(this.textBoxVixenSeq5);
			this.TabSeq5.Controls.Add(this.buttonVixenSeq5);
			this.TabSeq5.Controls.Add(this.label59);
			this.TabSeq5.Location = new System.Drawing.Point(4, 25);
			this.TabSeq5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq5.Name = "TabSeq5";
			this.TabSeq5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq5.Size = new System.Drawing.Size(760, 165);
			this.TabSeq5.TabIndex = 4;
			this.TabSeq5.Text = "Seq 5";
			// 
			// label27
			// 
			this.label27.Location = new System.Drawing.Point(4, 122);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(702, 39);
			this.label27.TabIndex = 47;
			this.label27.Text = "Note: This will not modify your Vixen 3 sequence in any way, Vixen Messaging will" +
    " create and modify a copy of your sequence to be used when a message has been re" +
    "ceived. Filename is Vixen3Out.tim";
			// 
			// textBoxSequenceLength5
			// 
			this.textBoxSequenceLength5.BackColor = System.Drawing.Color.White;
			this.textBoxSequenceLength5.Enabled = false;
			this.textBoxSequenceLength5.Location = new System.Drawing.Point(592, 90);
			this.textBoxSequenceLength5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxSequenceLength5.Name = "textBoxSequenceLength5";
			this.textBoxSequenceLength5.Size = new System.Drawing.Size(114, 22);
			this.textBoxSequenceLength5.TabIndex = 43;
			this.textBoxSequenceLength5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label57
			// 
			this.label57.AutoSize = true;
			this.label57.Location = new System.Drawing.Point(453, 93);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(124, 17);
			this.label57.TabIndex = 46;
			this.label57.Text = "Sequence Length:";
			// 
			// label58
			// 
			this.label58.Location = new System.Drawing.Point(231, 46);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(475, 42);
			this.label58.TabIndex = 45;
			this.label58.Text = "Select the Vixen Sequence you would like to use. Normally located in your Documen" +
    "ts\\Vixen 3\\Sequence\\ Folder.";
			// 
			// textBoxVixenSeq5
			// 
			this.textBoxVixenSeq5.BackColor = System.Drawing.Color.White;
			this.textBoxVixenSeq5.Enabled = false;
			this.textBoxVixenSeq5.Location = new System.Drawing.Point(135, 14);
			this.textBoxVixenSeq5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxVixenSeq5.Name = "textBoxVixenSeq5";
			this.textBoxVixenSeq5.Size = new System.Drawing.Size(532, 22);
			this.textBoxVixenSeq5.TabIndex = 42;
			// 
			// buttonVixenSeq5
			// 
			this.buttonVixenSeq5.Location = new System.Drawing.Point(5, 50);
			this.buttonVixenSeq5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonVixenSeq5.Name = "buttonVixenSeq5";
			this.buttonVixenSeq5.Size = new System.Drawing.Size(190, 34);
			this.buttonVixenSeq5.TabIndex = 40;
			this.buttonVixenSeq5.Text = "Set Vixen Sequence Path";
			this.buttonVixenSeq5.UseVisualStyleBackColor = true;
			this.buttonVixenSeq5.Click += new System.EventHandler(this.buttonVixenSeq5_Click);
			// 
			// label59
			// 
			this.label59.AutoSize = true;
			this.label59.Location = new System.Drawing.Point(11, 20);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(114, 17);
			this.label59.TabIndex = 44;
			this.label59.Text = "Vixen Sequence:";
			// 
			// TabSeq6
			// 
			this.TabSeq6.BackColor = System.Drawing.Color.Azure;
			this.TabSeq6.Controls.Add(this.label60);
			this.TabSeq6.Controls.Add(this.textBoxSequenceLength6);
			this.TabSeq6.Controls.Add(this.label61);
			this.TabSeq6.Controls.Add(this.buttonRemoveSeq6);
			this.TabSeq6.Controls.Add(this.label62);
			this.TabSeq6.Controls.Add(this.textBoxVixenSeq6);
			this.TabSeq6.Controls.Add(this.buttonVixenSeq6);
			this.TabSeq6.Controls.Add(this.label63);
			this.TabSeq6.Location = new System.Drawing.Point(4, 25);
			this.TabSeq6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq6.Name = "TabSeq6";
			this.TabSeq6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.TabSeq6.Size = new System.Drawing.Size(760, 165);
			this.TabSeq6.TabIndex = 5;
			this.TabSeq6.Text = "Seq 6";
			// 
			// label60
			// 
			this.label60.Location = new System.Drawing.Point(4, 122);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(702, 39);
			this.label60.TabIndex = 47;
			this.label60.Text = "Note: This will not modify your Vixen 3 sequence in any way, Vixen Messaging will" +
    " create and modify a copy of your sequence to be used when a message has been re" +
    "ceived. Filename is Vixen3Out.tim";
			// 
			// textBoxSequenceLength6
			// 
			this.textBoxSequenceLength6.BackColor = System.Drawing.Color.White;
			this.textBoxSequenceLength6.Enabled = false;
			this.textBoxSequenceLength6.Location = new System.Drawing.Point(592, 90);
			this.textBoxSequenceLength6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxSequenceLength6.Name = "textBoxSequenceLength6";
			this.textBoxSequenceLength6.Size = new System.Drawing.Size(114, 22);
			this.textBoxSequenceLength6.TabIndex = 43;
			this.textBoxSequenceLength6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label61
			// 
			this.label61.AutoSize = true;
			this.label61.Location = new System.Drawing.Point(453, 93);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(124, 17);
			this.label61.TabIndex = 46;
			this.label61.Text = "Sequence Length:";
			// 
			// label62
			// 
			this.label62.Location = new System.Drawing.Point(231, 46);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(475, 42);
			this.label62.TabIndex = 45;
			this.label62.Text = "Select the Vixen Sequence you would like to use. Normally located in your Documen" +
    "ts\\Vixen 3\\Sequence\\ Folder.";
			// 
			// textBoxVixenSeq6
			// 
			this.textBoxVixenSeq6.BackColor = System.Drawing.Color.White;
			this.textBoxVixenSeq6.Enabled = false;
			this.textBoxVixenSeq6.Location = new System.Drawing.Point(135, 14);
			this.textBoxVixenSeq6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxVixenSeq6.Name = "textBoxVixenSeq6";
			this.textBoxVixenSeq6.Size = new System.Drawing.Size(532, 22);
			this.textBoxVixenSeq6.TabIndex = 42;
			// 
			// buttonVixenSeq6
			// 
			this.buttonVixenSeq6.Location = new System.Drawing.Point(5, 50);
			this.buttonVixenSeq6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonVixenSeq6.Name = "buttonVixenSeq6";
			this.buttonVixenSeq6.Size = new System.Drawing.Size(190, 34);
			this.buttonVixenSeq6.TabIndex = 40;
			this.buttonVixenSeq6.Text = "Set Vixen Sequence Path";
			this.buttonVixenSeq6.UseVisualStyleBackColor = true;
			this.buttonVixenSeq6.Click += new System.EventHandler(this.buttonVixenSeq6_Click);
			// 
			// label63
			// 
			this.label63.AutoSize = true;
			this.label63.Location = new System.Drawing.Point(11, 20);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(114, 17);
			this.label63.TabIndex = 44;
			this.label63.Text = "Vixen Sequence:";
			// 
			// label26
			// 
			this.label26.Location = new System.Drawing.Point(16, 530);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(727, 42);
			this.label26.TabIndex = 22;
			this.label26.Text = "When \"Use Vixen Sequences\" is Enabled Vixen Messaging will use one of your Vixen " +
    "3 sequences and can be selected Randomly or whichever one is displayed.";
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
			// remoteCmds
			// 
			this.remoteCmds.BackColor = System.Drawing.Color.Azure;
			this.remoteCmds.Controls.Add(this.label84);
			this.remoteCmds.Controls.Add(this.label83);
			this.remoteCmds.Controls.Add(this.label82);
			this.remoteCmds.Controls.Add(this.richTextBox1);
			this.remoteCmds.Controls.Add(this.label81);
			this.remoteCmds.Location = new System.Drawing.Point(4, 25);
			this.remoteCmds.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.remoteCmds.Name = "remoteCmds";
			this.remoteCmds.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.remoteCmds.Size = new System.Drawing.Size(793, 707);
			this.remoteCmds.TabIndex = 6;
			this.remoteCmds.Text = "Remote Commands";
			// 
			// label84
			// 
			this.label84.Location = new System.Drawing.Point(5, 53);
			this.label84.Name = "label84";
			this.label84.Size = new System.Drawing.Size(754, 38);
			this.label84.TabIndex = 5;
			this.label84.Text = "Enter the command into the body of an email and  the word \"Messaging\" plus your r" +
    "emote access keyword in the subject line and then send the email to the address " +
    "you have set up.";
			// 
			// label83
			// 
			this.label83.AutoSize = true;
			this.label83.Location = new System.Drawing.Point(5, 118);
			this.label83.Name = "label83";
			this.label83.Size = new System.Drawing.Size(78, 17);
			this.label83.TabIndex = 4;
			this.label83.Text = "Commands";
			// 
			// label82
			// 
			this.label82.AutoSize = true;
			this.label82.Location = new System.Drawing.Point(197, 118);
			this.label82.Name = "label82";
			this.label82.Size = new System.Drawing.Size(48, 17);
			this.label82.TabIndex = 3;
			this.label82.Text = "Result";
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.Color.Azure;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Location = new System.Drawing.Point(9, 147);
			this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(777, 467);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// label81
			// 
			this.label81.AutoSize = true;
			this.label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label81.Location = new System.Drawing.Point(129, 14);
			this.label81.Name = "label81";
			this.label81.Size = new System.Drawing.Size(447, 20);
			this.label81.TabIndex = 0;
			this.label81.Text = "Use these commands to control Vixen Meesaging settings.";
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
			this.Text = "Vixen Messaging - v3.3.1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBoxEffects.ResumeLayout(false);
			this.groupBoxEffects.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.extraTime)).EndInit();
			this.tabControlEffects.ResumeLayout(false);
			this.tabPageSnowFlake.ResumeLayout(false);
			this.tabPageSnowFlake.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSpeedSnowFlakes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EffectType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaxSnowFlake)).EndInit();
			this.tabPageFire.ResumeLayout(false);
			this.tabPageFire.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.FireHeight)).EndInit();
			this.tabPageMeteors.ResumeLayout(false);
			this.tabPageMeteors.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSpeedMeteors)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MeteorTrailLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MeteorCount)).EndInit();
			this.tabPageTwinkles.ResumeLayout(false);
			this.tabPageTwinkles.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarSpeedTwinkles)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTwinkleSteps)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTwinkleLights)).EndInit();
			this.tabPageMovie.ResumeLayout(false);
			this.tabPageMovie.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatrixH)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatrixW)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarMovieSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarThumbnail)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxMovie)).EndInit();
			this.tabPageGlediator.ResumeLayout(false);
			this.tabPageGlediator.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarGlediator)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.EffectTime)).EndInit();
			this.TabSeq1.ResumeLayout(false);
			this.TabSeq1.PerformLayout();
			this.TabSeq2.ResumeLayout(false);
			this.TabSeq2.PerformLayout();
			this.RandomColourSelection.ResumeLayout(false);
			this.RandomColourSelection.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMultiLine)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWords)).EndInit();
			this.groupBox7.ResumeLayout(false);
			this.groupBox7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.SaveAll)).EndInit();
			this.groupBoxCountDown.ResumeLayout(false);
			this.groupBoxCountDown.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarCustomSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.CustomMsgLength)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarCountDownPosition)).EndInit();
			this.tabControlMain.ResumeLayout(false);
			this.tabPageMain.ResumeLayout(false);
			this.tabPageMain.PerformLayout();
			this.groupBoxPlayOptions.ResumeLayout(false);
			this.groupBoxPlayOptions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownIntervalMsgs)).EndInit();
			this.tabPageMessagingSettings.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox6.ResumeLayout(false);
			this.groupBox6.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.tabPageTextSetting.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBoxSeqSettings.ResumeLayout(false);
			this.groupBoxSeqSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.TextLineNumber)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextPosition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextSpeed)).EndInit();
			this.localMsgs.ResumeLayout(false);
			this.groupBoxMessages.ResumeLayout(false);
			this.groupBoxMessages.PerformLayout();
			this.groupBox8.ResumeLayout(false);
			this.tabPageSeqSettings.ResumeLayout(false);
			this.tabPageSeqSettings.PerformLayout();
			this.groupBoxLog.ResumeLayout(false);
			this.groupBoxSeqControl.ResumeLayout(false);
			this.tabControlSequence.ResumeLayout(false);
			this.TabSeq3.ResumeLayout(false);
			this.TabSeq3.PerformLayout();
			this.TabSeq4.ResumeLayout(false);
			this.TabSeq4.PerformLayout();
			this.TabSeq5.ResumeLayout(false);
			this.TabSeq5.PerformLayout();
			this.TabSeq6.ResumeLayout(false);
			this.TabSeq6.PerformLayout();
			this.tabPageWordLists.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveBlacklist)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxSaveWhitelist)).EndInit();
			this.remoteCmds.ResumeLayout(false);
			this.remoteCmds.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.buttonStart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonStop)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.buttonHelp)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxUID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPWD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Timer timerCheckMail;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TabPage tabPageMessagingSettings;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxBlacklistEmailLog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLogFileName;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxOutputSequence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSequenceTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxVixenServer;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBoxBlacklist;
        private System.Windows.Forms.CheckBox checkBoxWhitelist;
        private System.Windows.Forms.TextBox textBoxSubjectHeader;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TabPage tabPageSeqSettings;
        private System.Windows.Forms.TabPage tabPageWordLists;
        private System.Windows.Forms.RichTextBox richTextBoxWhitelist;
        private System.Windows.Forms.RichTextBox richTextBoxBlacklist;
        private System.Windows.Forms.CheckBox checkBoxEnableSqnctrl;
        private System.Windows.Forms.TabControl tabControlSequence;
        private System.Windows.Forms.TabPage TabSeq1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage TabSeq2;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TabPage TabSeq3;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox groupBoxEffects;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown EffectTime;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown MaxSnowFlake;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.NumericUpDown EffectType;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.NumericUpDown FireHeight;
        private System.Windows.Forms.TabControl tabControlEffects;
        private System.Windows.Forms.TabPage tabPageSnowFlake;
        private System.Windows.Forms.TabPage tabPageFire;
        private System.Windows.Forms.GroupBox groupBoxSeqControl;
        private System.Windows.Forms.TabPage tabPageMeteors;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox textBoxNodeId;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.NumericUpDown MeteorTrailLength;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.NumericUpDown MeteorCount;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox MeteorColour;
		private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Button buttonVixenSeq1;
        private System.Windows.Forms.TextBox textBoxVixenSeq1;
        private System.Windows.Forms.TextBox textBoxVixenSeq2;
        private System.Windows.Forms.Button buttonVixenSeq2;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBoxVixenSeq3;
        private System.Windows.Forms.Button buttonVixenSeq3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Button buttonResetToDefault;
        private System.Windows.Forms.Button buttonRemoveSeq1;
        private System.Windows.Forms.Button buttonRemoveSeq2;
        private System.Windows.Forms.Button buttonRemoveSeq3;
        private System.Windows.Forms.PictureBox buttonStart;
        private System.Windows.Forms.PictureBox buttonStop;
        private System.Windows.Forms.PictureBox buttonHelp;
        private System.Windows.Forms.Button buttonGetVixenData;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxVixenFolder;
        private System.Windows.Forms.CheckBox checkBoxAutoStart;
        private System.Windows.Forms.CheckBox checkBoxManEnterSettings;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TrackBar trackBarSpeedSnowFlakes;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TrackBar trackBarSpeedMeteors;
        private System.Windows.Forms.TextBox textBoxSequenceLength1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBoxSequenceLength2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBoxSequenceLength3;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TabPage TabSeq4;
        private System.Windows.Forms.TextBox textBoxSequenceLength4;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Button buttonRemoveSeq4;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox textBoxVixenSeq4;
        private System.Windows.Forms.Button buttonVixenSeq4;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TabPage tabPageTextSetting;
        private System.Windows.Forms.GroupBox groupBoxSeqSettings;
        private System.Windows.Forms.NumericUpDown TextLineNumber;
        private System.Windows.Forms.Label label46;
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
        private System.Windows.Forms.CheckBox checkBoxRandomSeqSelection;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Button WebServerStatus;
		private System.Windows.Forms.TextBox textBoxFont;
        private System.Windows.Forms.Button buttonFont;
        private System.Windows.Forms.TextBox textBoxFontSize;
        private System.Windows.Forms.PictureBox pictureBoxSaveBlacklist;
        private System.Windows.Forms.PictureBox pictureBoxSaveWhitelist;
        private System.Windows.Forms.TabPage tabPageTwinkles;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.TrackBar trackBarSpeedTwinkles;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TrackBar trackBarTwinkleSteps;
        private System.Windows.Forms.TrackBar trackBarTwinkleLights;
        private System.Windows.Forms.Label label56;
        public System.Windows.Forms.CheckBox checkBoxSnowFlakeColour6;
        public System.Windows.Forms.CheckBox checkBoxSnowFlakeColour5;
        public System.Windows.Forms.CheckBox checkBoxSnowFlakeColour4;
        private System.Windows.Forms.Button SnowFlakeColour5;
        public System.Windows.Forms.CheckBox checkBoxSnowFlakeColour3;
        private System.Windows.Forms.Button SnowFlakeColour6;
        public System.Windows.Forms.CheckBox checkBoxSnowFlakeColour2;
        private System.Windows.Forms.Button SnowFlakeColour4;
        public System.Windows.Forms.CheckBox checkBoxSnowFlakeColour1;
        private System.Windows.Forms.Button SnowFlakeColour3;
        private System.Windows.Forms.Button SnowFlakeColour1;
        private System.Windows.Forms.Button SnowFlakeColour2;
        private System.Windows.Forms.Label label55;
        public System.Windows.Forms.CheckBox checkBoxMeteorColour6;
        public System.Windows.Forms.CheckBox checkBoxMeteorColour5;
        public System.Windows.Forms.CheckBox checkBoxMeteorColour4;
        private System.Windows.Forms.Button MeteorColour5;
        public System.Windows.Forms.CheckBox checkBoxMeteorColour3;
        private System.Windows.Forms.Button MeteorColour6;
        public System.Windows.Forms.CheckBox checkBoxMeteorColour2;
        private System.Windows.Forms.Button MeteorColour4;
        public System.Windows.Forms.CheckBox checkBoxMeteorColour1;
        private System.Windows.Forms.Button MeteorColour3;
        private System.Windows.Forms.Button MeteorColour1;
        private System.Windows.Forms.Button MeteorColour2;
        private System.Windows.Forms.Label label54;
        public System.Windows.Forms.CheckBox checkBoxTwinkleColour6;
        public System.Windows.Forms.CheckBox checkBoxTwinkleColour5;
        public System.Windows.Forms.CheckBox checkBoxTwinkleColour4;
        private System.Windows.Forms.Button TwinkleColour5;
        public System.Windows.Forms.CheckBox checkBoxTwinkleColour3;
        private System.Windows.Forms.Button TwinkleColour6;
        public System.Windows.Forms.CheckBox checkBoxTwinkleColour2;
        private System.Windows.Forms.Button TwinkleColour4;
        public System.Windows.Forms.CheckBox checkBoxTwinkleColour1;
        private System.Windows.Forms.Button TwinkleColour3;
        private System.Windows.Forms.Button TwinkleColour1;
        private System.Windows.Forms.Button TwinkleColour2;
        private System.Windows.Forms.TabPage TabSeq5;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox textBoxSequenceLength5;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Button buttonRemoveSeq5;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox textBoxVixenSeq5;
        private System.Windows.Forms.Button buttonVixenSeq5;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TabPage TabSeq6;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TextBox textBoxSequenceLength6;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Button buttonRemoveSeq6;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.TextBox textBoxVixenSeq6;
        private System.Windows.Forms.Button buttonVixenSeq6;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox textBoxSMTP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxReturnSubjectHeading;
        private System.Windows.Forms.TextBox textBoxFromEmailAddress;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.ComboBox comboBoxEmailSettings;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.CheckBox checkBoxDisableSeq;
		private System.Windows.Forms.Label label65;
        private System.Windows.Forms.CheckBox checkBoxVariableLength;
        private System.Windows.Forms.TextBox textBoxReturnBannedMSG;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog1;
        private System.Windows.Forms.RichTextBox richTextBoxLog2;
        private System.Windows.Forms.NumericUpDown extraTime;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Button buttonSaveLog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button buttonStopSequence;
        private System.Windows.Forms.TabPage tabPageMovie;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.PictureBox pictureBoxMovie;
        private System.Windows.Forms.TrackBar trackBarMovieSpeed;
        private System.Windows.Forms.TrackBar trackBarThumbnail;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label label73;
        private System.Windows.Forms.Button buttonMovieDelete;
        private System.Windows.Forms.NumericUpDown numericUpDownIntervalMsgs;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.CheckBox checkBoxRandom1;
        private System.Windows.Forms.CheckBox checkBoxRandom2;
        private System.Windows.Forms.CheckBox checkBoxRandom3;
        private System.Windows.Forms.CheckBox checkBoxRandom4;
        private System.Windows.Forms.CheckBox checkBoxRandom5;
        private System.Windows.Forms.Label label74;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label label75;
        private System.Windows.Forms.NumericUpDown numericUpDownMatrixH;
        private System.Windows.Forms.NumericUpDown numericUpDownMatrixW;
        private System.Windows.Forms.Label label77;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.TextBox textBoxAccessPWD;
        private System.Windows.Forms.TabPage tabPageGlediator;
        private System.Windows.Forms.TextBox textBoxGlediator;
        private System.Windows.Forms.Button buttonGlediator;
        private System.Windows.Forms.CheckBox checkBoxRandom6;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.TrackBar trackBarGlediator;
        private System.Windows.Forms.Label label80;
        private System.Windows.Forms.Button buttonTwilio;
        private System.Windows.Forms.GroupBox groupBoxPlayOptions;
        private System.Windows.Forms.ComboBox comboBoxPlayMode;
        private System.Windows.Forms.CheckBox checkBoxEmail;
        private System.Windows.Forms.CheckBox checkBoxTwilio;
        private System.Windows.Forms.CheckBox checkBoxLocal;
        private System.Windows.Forms.TabPage remoteCmds;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.NumericUpDown numericUpDownMultiLine;
        private System.Windows.Forms.Label label85;
		private System.Windows.Forms.CheckBox checkBoxMultiLine;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label88;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxWords;
        private System.Windows.Forms.Timer timerCheckVixenEnabled;
		private System.Windows.Forms.CheckBox checkBoxVixenControl;
		private System.Windows.Forms.PictureBox SaveAll;
		private System.Windows.Forms.TabPage localMsgs;
		private System.Windows.Forms.GroupBox groupBoxMessages;
		private System.Windows.Forms.CheckBox checkBoxLocalRandom;
		private System.Windows.Forms.GroupBox groupBoxCountDown;
		private System.Windows.Forms.Label label95;
		private System.Windows.Forms.TrackBar trackBarCustomSpeed;
		private System.Windows.Forms.Button buttonPlay;
		private System.Windows.Forms.NumericUpDown CustomMsgLength;
		private System.Windows.Forms.Label label94;
		private System.Windows.Forms.TextBox textBoxCustomFontSize;
		private System.Windows.Forms.TextBox textBoxCustomFont;
		private System.Windows.Forms.Button buttonCustomFont;
		private System.Windows.Forms.Label label93;
		private System.Windows.Forms.ComboBox comboBoxName;
		private System.Windows.Forms.CheckBox checkBoxMessageEnabled;
		private System.Windows.Forms.Button buttonRemoveMessage;
		private System.Windows.Forms.Button buttonAddMessage;
		private System.Windows.Forms.ComboBox comboBoxCountDownDirection;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label92;
		private System.Windows.Forms.Label label91;
		private System.Windows.Forms.Label label90;
		private System.Windows.Forms.Label label89;
		private System.Windows.Forms.TextBox textBoxLine1;
		private System.Windows.Forms.TextBox textBoxLine2;
		private System.Windows.Forms.Label label86;
		private System.Windows.Forms.TextBox textBoxLine3;
		private System.Windows.Forms.TrackBar trackBarCountDownPosition;
		private System.Windows.Forms.TextBox textBoxLine4;
		private System.Windows.Forms.RichTextBox richTextBoxMessage;
		private System.Windows.Forms.CheckBox checkBoxCountDownEnable;
		private System.Windows.Forms.DateTimePicker dateCountDown;
		private System.Windows.Forms.Label label87;
		private System.Windows.Forms.Label label96;
		private System.Windows.Forms.Button line1Colour;
		private System.Windows.Forms.Button line2Colour;
		private System.Windows.Forms.Button line3Colour;
		private System.Windows.Forms.Button line4Colour;
		private System.Windows.Forms.Label label97;
		private System.Windows.Forms.ComboBox messageColourOption;
		private System.Windows.Forms.CheckBox checkBoxCentreStop;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label labelColour4;
		private System.Windows.Forms.Label labelColour3;
		private System.Windows.Forms.Label labelColour2;
		private System.Windows.Forms.Label labelColour1;
		private System.Windows.Forms.Label label98;
		private System.Windows.Forms.ComboBox incomingMessageColourOption;
		private System.Windows.Forms.GroupBox groupBoxLog;
		private System.Windows.Forms.Label labelColour10;
		private System.Windows.Forms.Label labelColour9;
		private System.Windows.Forms.Label labelColour8;
		private System.Windows.Forms.Label labelColour7;
		private System.Windows.Forms.Label labelColour6;
		private System.Windows.Forms.Label labelColour5;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.Label label99;
		private System.Windows.Forms.ComboBox customMessageSeqSel;
		private System.Windows.Forms.Label label100;
		private System.Windows.Forms.ComboBox comboBoxNodeID;
		private System.Windows.Forms.Button buttonRemoveNodeID;
		private System.Windows.Forms.Button buttonAddNodeID;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.ComboBox customMessageNodeSel;
		private System.Windows.Forms.Button buttonPlaySnowFlake;
		private System.Windows.Forms.Label label101;
		private System.Windows.Forms.ComboBox comboBoxSnowFlakeName;
		private System.Windows.Forms.Button buttonRemoveSnowFlake;
		private System.Windows.Forms.Button buttonAddSnowFlake;
		private System.Windows.Forms.Button buttonPlayMeteor;
		private System.Windows.Forms.Label label102;
		private System.Windows.Forms.ComboBox comboBoxMeteorName;
		private System.Windows.Forms.Button buttonRemoveMeteor;
		private System.Windows.Forms.Button buttonAddMeteor;
		private System.Windows.Forms.Button buttonPlayTwinkle;
		private System.Windows.Forms.Label label103;
		private System.Windows.Forms.ComboBox comboBoxTwinkleName;
		private System.Windows.Forms.Button buttonRemoveTwinkle;
		private System.Windows.Forms.Button buttonAddTwinkle;
		private System.Windows.Forms.Button buttonPlayFire;
		private System.Windows.Forms.Button buttonPlayMovie;
		private System.Windows.Forms.Button buttonPlayGled;
		private System.Windows.Forms.Label label104;
		private System.Windows.Forms.ComboBox comboBoxFireName;
		private System.Windows.Forms.Button buttonRemoveFire;
		private System.Windows.Forms.Button buttonAddFire;
		private System.Windows.Forms.CheckBox checkBoxTextFile;
		private System.Windows.Forms.CheckBox checkBoxdeleteTextFile;
		private System.Windows.Forms.Label label105;
		private System.Windows.Forms.TextBox textBoxTextFileFolder;
		private System.Windows.Forms.Label label106;
    }
}

