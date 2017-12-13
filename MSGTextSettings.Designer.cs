namespace Vixen_Messaging
{
	partial class MSGTextSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MSGTextSettings));
			this.ok = new System.Windows.Forms.PictureBox();
			this.Cancel = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label88 = new System.Windows.Forms.Label();
			this.numericUpDownMaxWords = new System.Windows.Forms.NumericUpDown();
			this.label36 = new System.Windows.Forms.Label();
			this.label45 = new System.Windows.Forms.Label();
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
			this.groupBoxSeqSettings = new System.Windows.Forms.GroupBox();
			this.trackBarTextSpeed = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.comboBoxGradientMode = new System.Windows.Forms.ComboBox();
			this.trackBarIntensity = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
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
			this.trackBarTextIterations = new System.Windows.Forms.TrackBar();
			this.label21 = new System.Windows.Forms.Label();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.checkBoxSingleLine = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWords)).BeginInit();
			this.RandomColourSelection.SuspendLayout();
			this.groupBoxSeqSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarIntensity)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextPosition)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextIterations)).BeginInit();
			this.SuspendLayout();
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(438, 452);
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
			this.Cancel.Location = new System.Drawing.Point(512, 452);
			this.Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(61, 61);
			this.Cancel.TabIndex = 4;
			this.Cancel.TabStop = false;
			this.Cancel.Tag = "8";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// label88
			// 
			this.label88.AutoSize = true;
			this.label88.Location = new System.Drawing.Point(217, 102);
			this.label88.Name = "label88";
			this.label88.Size = new System.Drawing.Size(82, 17);
			this.label88.TabIndex = 66;
			this.label88.Text = "Max Words:";
			this.toolTip1.SetToolTip(this.label88, "Enter the Maximum number of words in a message or 0 for unlimited.\r\nWill send rep" +
        "ly message to sender informing them that their message was too long.");
			// 
			// numericUpDownMaxWords
			// 
			this.numericUpDownMaxWords.Location = new System.Drawing.Point(303, 101);
			this.numericUpDownMaxWords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.numericUpDownMaxWords.Name = "numericUpDownMaxWords";
			this.numericUpDownMaxWords.Size = new System.Drawing.Size(64, 22);
			this.numericUpDownMaxWords.TabIndex = 5;
			this.toolTip1.SetToolTip(this.numericUpDownMaxWords, "Enter 0 for unlimited words.");
			this.numericUpDownMaxWords.ValueChanged += new System.EventHandler(this.numericUpDownMaxWords_ValueChanged);
			// 
			// label36
			// 
			this.label36.AutoSize = true;
			this.label36.Location = new System.Drawing.Point(296, 31);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(123, 17);
			this.label36.TabIndex = 55;
			this.label36.Text = "String Orientation:";
			this.toolTip1.SetToolTip(this.label36, "Set this as per the requirement in Vixen");
			// 
			// label45
			// 
			this.label45.AutoSize = true;
			this.label45.Location = new System.Drawing.Point(37, 103);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(68, 17);
			this.label45.TabIndex = 51;
			this.label45.Text = "Direction:";
			this.toolTip1.SetToolTip(this.label45, "Text direction");
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
			this.RandomColourSelection.Location = new System.Drawing.Point(6, 341);
			this.RandomColourSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RandomColourSelection.Name = "RandomColourSelection";
			this.RandomColourSelection.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.RandomColourSelection.Size = new System.Drawing.Size(574, 74);
			this.RandomColourSelection.TabIndex = 9;
			this.RandomColourSelection.TabStop = false;
			this.RandomColourSelection.Text = "Colors";
			this.toolTip1.SetToolTip(this.RandomColourSelection, "Select a color to edit. Number idicates colours that are enabled and will change " +
        "depending on selected Colour Option..");
			// 
			// labelColour10
			// 
			this.labelColour10.AutoSize = true;
			this.labelColour10.Location = new System.Drawing.Point(534, 18);
			this.labelColour10.Name = "labelColour10";
			this.labelColour10.Size = new System.Drawing.Size(24, 17);
			this.labelColour10.TabIndex = 76;
			this.labelColour10.Text = "10";
			this.labelColour10.Visible = false;
			// 
			// labelColour9
			// 
			this.labelColour9.AutoSize = true;
			this.labelColour9.Location = new System.Drawing.Point(476, 18);
			this.labelColour9.Name = "labelColour9";
			this.labelColour9.Size = new System.Drawing.Size(16, 17);
			this.labelColour9.TabIndex = 75;
			this.labelColour9.Text = "9";
			this.labelColour9.Visible = false;
			// 
			// labelColour8
			// 
			this.labelColour8.AutoSize = true;
			this.labelColour8.Location = new System.Drawing.Point(418, 18);
			this.labelColour8.Name = "labelColour8";
			this.labelColour8.Size = new System.Drawing.Size(16, 17);
			this.labelColour8.TabIndex = 74;
			this.labelColour8.Text = "8";
			this.labelColour8.Visible = false;
			// 
			// labelColour7
			// 
			this.labelColour7.AutoSize = true;
			this.labelColour7.Location = new System.Drawing.Point(362, 18);
			this.labelColour7.Name = "labelColour7";
			this.labelColour7.Size = new System.Drawing.Size(16, 17);
			this.labelColour7.TabIndex = 73;
			this.labelColour7.Text = "7";
			this.labelColour7.Visible = false;
			// 
			// labelColour6
			// 
			this.labelColour6.AutoSize = true;
			this.labelColour6.Location = new System.Drawing.Point(303, 18);
			this.labelColour6.Name = "labelColour6";
			this.labelColour6.Size = new System.Drawing.Size(16, 17);
			this.labelColour6.TabIndex = 72;
			this.labelColour6.Text = "6";
			this.labelColour6.Visible = false;
			// 
			// labelColour5
			// 
			this.labelColour5.AutoSize = true;
			this.labelColour5.Location = new System.Drawing.Point(246, 18);
			this.labelColour5.Name = "labelColour5";
			this.labelColour5.Size = new System.Drawing.Size(16, 17);
			this.labelColour5.TabIndex = 71;
			this.labelColour5.Text = "5";
			this.labelColour5.Visible = false;
			// 
			// labelColour4
			// 
			this.labelColour4.AutoSize = true;
			this.labelColour4.Location = new System.Drawing.Point(189, 18);
			this.labelColour4.Name = "labelColour4";
			this.labelColour4.Size = new System.Drawing.Size(16, 17);
			this.labelColour4.TabIndex = 70;
			this.labelColour4.Text = "4";
			this.labelColour4.Visible = false;
			// 
			// labelColour3
			// 
			this.labelColour3.AutoSize = true;
			this.labelColour3.Location = new System.Drawing.Point(133, 18);
			this.labelColour3.Name = "labelColour3";
			this.labelColour3.Size = new System.Drawing.Size(16, 17);
			this.labelColour3.TabIndex = 69;
			this.labelColour3.Text = "3";
			this.labelColour3.Visible = false;
			// 
			// labelColour2
			// 
			this.labelColour2.AutoSize = true;
			this.labelColour2.Location = new System.Drawing.Point(80, 18);
			this.labelColour2.Name = "labelColour2";
			this.labelColour2.Size = new System.Drawing.Size(16, 17);
			this.labelColour2.TabIndex = 68;
			this.labelColour2.Text = "2";
			this.labelColour2.Visible = false;
			// 
			// labelColour1
			// 
			this.labelColour1.AutoSize = true;
			this.labelColour1.Location = new System.Drawing.Point(25, 18);
			this.labelColour1.Name = "labelColour1";
			this.labelColour1.Size = new System.Drawing.Size(16, 17);
			this.labelColour1.TabIndex = 67;
			this.labelColour1.Text = "1";
			this.labelColour1.Visible = false;
			// 
			// TextColor1
			// 
			this.TextColor1.BackColor = System.Drawing.Color.Red;
			this.TextColor1.Location = new System.Drawing.Point(14, 38);
			this.TextColor1.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor1.Name = "TextColor1";
			this.TextColor1.Size = new System.Drawing.Size(36, 32);
			this.TextColor1.TabIndex = 10;
			this.toolTip1.SetToolTip(this.TextColor1, "Select a colour to edit.");
			this.TextColor1.UseVisualStyleBackColor = false;
			this.TextColor1.Click += new System.EventHandler(this.TextColor_Click);
			// 
			// TextColor10
			// 
			this.TextColor10.BackColor = System.Drawing.Color.DodgerBlue;
			this.TextColor10.Location = new System.Drawing.Point(524, 38);
			this.TextColor10.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor10.Name = "TextColor10";
			this.TextColor10.Size = new System.Drawing.Size(36, 32);
			this.TextColor10.TabIndex = 19;
			this.toolTip1.SetToolTip(this.TextColor10, "Select a colour to edit.");
			this.TextColor10.UseVisualStyleBackColor = false;
			this.TextColor10.Click += new System.EventHandler(this.TextColor_Click);
			// 
			// TextColor8
			// 
			this.TextColor8.BackColor = System.Drawing.Color.Maroon;
			this.TextColor8.Location = new System.Drawing.Point(409, 38);
			this.TextColor8.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor8.Name = "TextColor8";
			this.TextColor8.Size = new System.Drawing.Size(36, 32);
			this.TextColor8.TabIndex = 17;
			this.toolTip1.SetToolTip(this.TextColor8, "Select a colour to edit.");
			this.TextColor8.UseVisualStyleBackColor = false;
			this.TextColor8.Click += new System.EventHandler(this.TextColor_Click);
			// 
			// TextColor9
			// 
			this.TextColor9.BackColor = System.Drawing.Color.Brown;
			this.TextColor9.Location = new System.Drawing.Point(466, 38);
			this.TextColor9.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor9.Name = "TextColor9";
			this.TextColor9.Size = new System.Drawing.Size(36, 32);
			this.TextColor9.TabIndex = 18;
			this.toolTip1.SetToolTip(this.TextColor9, "Select a colour to edit.");
			this.TextColor9.UseVisualStyleBackColor = false;
			this.TextColor9.Click += new System.EventHandler(this.TextColor_Click);
			// 
			// TextColor2
			// 
			this.TextColor2.BackColor = System.Drawing.Color.Lime;
			this.TextColor2.Location = new System.Drawing.Point(69, 38);
			this.TextColor2.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor2.Name = "TextColor2";
			this.TextColor2.Size = new System.Drawing.Size(36, 32);
			this.TextColor2.TabIndex = 11;
			this.toolTip1.SetToolTip(this.TextColor2, "Select a colour to edit.");
			this.TextColor2.UseVisualStyleBackColor = false;
			this.TextColor2.Click += new System.EventHandler(this.TextColor_Click);
			// 
			// TextColor3
			// 
			this.TextColor3.BackColor = System.Drawing.Color.Blue;
			this.TextColor3.Location = new System.Drawing.Point(122, 38);
			this.TextColor3.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor3.Name = "TextColor3";
			this.TextColor3.Size = new System.Drawing.Size(36, 32);
			this.TextColor3.TabIndex = 12;
			this.toolTip1.SetToolTip(this.TextColor3, "Select a colour to edit.");
			this.TextColor3.UseVisualStyleBackColor = false;
			this.TextColor3.Click += new System.EventHandler(this.TextColor_Click);
			// 
			// TextColor7
			// 
			this.TextColor7.BackColor = System.Drawing.Color.LightBlue;
			this.TextColor7.Location = new System.Drawing.Point(352, 38);
			this.TextColor7.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor7.Name = "TextColor7";
			this.TextColor7.Size = new System.Drawing.Size(36, 32);
			this.TextColor7.TabIndex = 16;
			this.toolTip1.SetToolTip(this.TextColor7, "Select a colour to edit.");
			this.TextColor7.UseVisualStyleBackColor = false;
			this.TextColor7.Click += new System.EventHandler(this.TextColor_Click);
			// 
			// TextColor4
			// 
			this.TextColor4.BackColor = System.Drawing.Color.Yellow;
			this.TextColor4.Location = new System.Drawing.Point(178, 38);
			this.TextColor4.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor4.Name = "TextColor4";
			this.TextColor4.Size = new System.Drawing.Size(36, 32);
			this.TextColor4.TabIndex = 13;
			this.toolTip1.SetToolTip(this.TextColor4, "Select a colour to edit.");
			this.TextColor4.UseVisualStyleBackColor = false;
			this.TextColor4.Click += new System.EventHandler(this.TextColor_Click);
			// 
			// TextColor6
			// 
			this.TextColor6.BackColor = System.Drawing.Color.Pink;
			this.TextColor6.Location = new System.Drawing.Point(294, 38);
			this.TextColor6.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor6.Name = "TextColor6";
			this.TextColor6.Size = new System.Drawing.Size(36, 32);
			this.TextColor6.TabIndex = 15;
			this.toolTip1.SetToolTip(this.TextColor6, "Select a colour to edit.");
			this.TextColor6.UseVisualStyleBackColor = false;
			this.TextColor6.Click += new System.EventHandler(this.TextColor_Click);
			// 
			// TextColor5
			// 
			this.TextColor5.BackColor = System.Drawing.Color.Orange;
			this.TextColor5.Location = new System.Drawing.Point(236, 38);
			this.TextColor5.Margin = new System.Windows.Forms.Padding(0);
			this.TextColor5.Name = "TextColor5";
			this.TextColor5.Size = new System.Drawing.Size(36, 32);
			this.TextColor5.TabIndex = 14;
			this.toolTip1.SetToolTip(this.TextColor5, "Select a colour to edit.");
			this.TextColor5.UseVisualStyleBackColor = false;
			this.TextColor5.Click += new System.EventHandler(this.TextColor_Click);
			// 
			// groupBoxSeqSettings
			// 
			this.groupBoxSeqSettings.Controls.Add(this.checkBoxSingleLine);
			this.groupBoxSeqSettings.Controls.Add(this.trackBarTextSpeed);
			this.groupBoxSeqSettings.Controls.Add(this.label2);
			this.groupBoxSeqSettings.Controls.Add(this.label1);
			this.groupBoxSeqSettings.Controls.Add(this.comboBoxGradientMode);
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
			this.groupBoxSeqSettings.Controls.Add(this.trackBarTextIterations);
			this.groupBoxSeqSettings.Controls.Add(this.label21);
			this.groupBoxSeqSettings.Controls.Add(this.RandomColourSelection);
			this.groupBoxSeqSettings.Location = new System.Drawing.Point(1, 11);
			this.groupBoxSeqSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxSeqSettings.Name = "groupBoxSeqSettings";
			this.groupBoxSeqSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBoxSeqSettings.Size = new System.Drawing.Size(587, 426);
			this.groupBoxSeqSettings.TabIndex = 5;
			this.groupBoxSeqSettings.TabStop = false;
			this.groupBoxSeqSettings.Text = "Incoming Message / Text Settings";
			// 
			// trackBarTextSpeed
			// 
			this.trackBarTextSpeed.AutoSize = false;
			this.trackBarTextSpeed.Location = new System.Drawing.Point(100, 305);
			this.trackBarTextSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarTextSpeed.Minimum = 1;
			this.trackBarTextSpeed.Name = "trackBarTextSpeed";
			this.trackBarTextSpeed.Size = new System.Drawing.Size(299, 32);
			this.trackBarTextSpeed.TabIndex = 106;
			this.trackBarTextSpeed.Value = 1;
			this.trackBarTextSpeed.Scroll += new System.EventHandler(this.trackBarTextPosition_ToolTip);
			this.trackBarTextSpeed.ValueChanged += new System.EventHandler(this.trackBarIntensity_ValueChanged);
			this.trackBarTextSpeed.MouseHover += new System.EventHandler(this.trackBarTextPosition_ToolTip);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 305);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(53, 17);
			this.label2.TabIndex = 107;
			this.label2.Text = "Speed:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 17);
			this.label1.TabIndex = 105;
			this.label1.Text = "Gradient Mode:";
			// 
			// comboBoxGradientMode
			// 
			this.comboBoxGradientMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxGradientMode.FormattingEnabled = true;
			this.comboBoxGradientMode.Items.AddRange(new object[] {
            "Across Text",
            "Across Element",
            "Vertical Across Text",
            "Vertical Across Element",
            "Diagonal Across Text",
            "Diagonal Across Element",
            "Backward Diagonal Across Text",
            "Backward Diagonal Across Element",
            "Random Gradient Mode"});
			this.comboBoxGradientMode.Location = new System.Drawing.Point(111, 65);
			this.comboBoxGradientMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxGradientMode.Name = "comboBoxGradientMode";
			this.comboBoxGradientMode.Size = new System.Drawing.Size(256, 24);
			this.comboBoxGradientMode.TabIndex = 104;
			// 
			// trackBarIntensity
			// 
			this.trackBarIntensity.AutoSize = false;
			this.trackBarIntensity.Location = new System.Drawing.Point(100, 214);
			this.trackBarIntensity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarIntensity.Maximum = 100;
			this.trackBarIntensity.Minimum = 1;
			this.trackBarIntensity.Name = "trackBarIntensity";
			this.trackBarIntensity.Size = new System.Drawing.Size(299, 32);
			this.trackBarIntensity.TabIndex = 102;
			this.trackBarIntensity.Value = 1;
			this.trackBarIntensity.Scroll += new System.EventHandler(this.trackBarTextPosition_ToolTip);
			this.trackBarIntensity.ValueChanged += new System.EventHandler(this.trackBarIntensity_ValueChanged);
			this.trackBarIntensity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextPosition_ToolTip);
			this.trackBarIntensity.MouseHover += new System.EventHandler(this.trackBarTextPosition_ToolTip);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 221);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 17);
			this.label3.TabIndex = 103;
			this.label3.Text = "Brightness:";
			// 
			// checkBoxCenterText
			// 
			this.checkBoxCenterText.AutoSize = true;
			this.checkBoxCenterText.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxCenterText.Location = new System.Drawing.Point(145, 140);
			this.checkBoxCenterText.Name = "checkBoxCenterText";
			this.checkBoxCenterText.Size = new System.Drawing.Size(103, 21);
			this.checkBoxCenterText.TabIndex = 101;
			this.checkBoxCenterText.Text = "Center Text";
			this.checkBoxCenterText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxCenterText.UseVisualStyleBackColor = true;
			this.checkBoxCenterText.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// checkBoxCenterStop
			// 
			this.checkBoxCenterStop.AutoSize = true;
			this.checkBoxCenterStop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxCenterStop.Location = new System.Drawing.Point(23, 140);
			this.checkBoxCenterStop.Name = "checkBoxCenterStop";
			this.checkBoxCenterStop.Size = new System.Drawing.Size(105, 21);
			this.checkBoxCenterStop.TabIndex = 100;
			this.checkBoxCenterStop.Text = "Center Stop";
			this.checkBoxCenterStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBoxCenterStop.UseVisualStyleBackColor = true;
			this.checkBoxCenterStop.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
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
            "Gradient",
            "Random",
            "Random Gradient",
            "Random Color Option"});
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
			this.textBoxFontSize.Location = new System.Drawing.Point(456, 141);
			this.textBoxFontSize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxFontSize.Name = "textBoxFontSize";
			this.textBoxFontSize.Size = new System.Drawing.Size(77, 22);
			this.textBoxFontSize.TabIndex = 59;
			this.textBoxFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// buttonFont
			// 
			this.buttonFont.Location = new System.Drawing.Point(430, 72);
			this.buttonFont.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonFont.Name = "buttonFont";
			this.buttonFont.Size = new System.Drawing.Size(117, 26);
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
			this.textBoxFont.Location = new System.Drawing.Point(401, 115);
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
			this.comboBoxString.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
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
			this.comboBoxTextDirection.Location = new System.Drawing.Point(111, 100);
			this.comboBoxTextDirection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.comboBoxTextDirection.Name = "comboBoxTextDirection";
			this.comboBoxTextDirection.Size = new System.Drawing.Size(82, 24);
			this.comboBoxTextDirection.TabIndex = 4;
			this.comboBoxTextDirection.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
			// 
			// trackBarTextPosition
			// 
			this.trackBarTextPosition.AutoSize = false;
			this.trackBarTextPosition.Location = new System.Drawing.Point(100, 169);
			this.trackBarTextPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarTextPosition.Maximum = 100;
			this.trackBarTextPosition.Minimum = -100;
			this.trackBarTextPosition.Name = "trackBarTextPosition";
			this.trackBarTextPosition.Size = new System.Drawing.Size(299, 32);
			this.trackBarTextPosition.TabIndex = 8;
			this.trackBarTextPosition.Scroll += new System.EventHandler(this.trackBarTextPosition_ToolTip);
			this.trackBarTextPosition.ValueChanged += new System.EventHandler(this.trackBarIntensity_ValueChanged);
			this.trackBarTextPosition.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextPosition_ToolTip);
			this.trackBarTextPosition.MouseHover += new System.EventHandler(this.trackBarTextPosition_ToolTip);
			// 
			// label44
			// 
			this.label44.AutoSize = true;
			this.label44.Location = new System.Drawing.Point(10, 176);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(62, 17);
			this.label44.TabIndex = 50;
			this.label44.Text = "Position:";
			// 
			// trackBarTextIterations
			// 
			this.trackBarTextIterations.AutoSize = false;
			this.trackBarTextIterations.Location = new System.Drawing.Point(100, 262);
			this.trackBarTextIterations.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarTextIterations.Maximum = 5;
			this.trackBarTextIterations.Minimum = 1;
			this.trackBarTextIterations.Name = "trackBarTextIterations";
			this.trackBarTextIterations.Size = new System.Drawing.Size(299, 32);
			this.trackBarTextIterations.TabIndex = 9;
			this.trackBarTextIterations.Value = 1;
			this.trackBarTextIterations.Scroll += new System.EventHandler(this.trackBarTextPosition_ToolTip);
			this.trackBarTextIterations.ValueChanged += new System.EventHandler(this.trackBarIntensity_ValueChanged);
			this.trackBarTextIterations.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarTextPosition_ToolTip);
			this.trackBarTextIterations.MouseHover += new System.EventHandler(this.trackBarTextPosition_ToolTip);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(10, 262);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(70, 17);
			this.label21.TabIndex = 48;
			this.label21.Text = "Iterations:";
			// 
			// colorDialog1
			// 
			this.colorDialog1.AnyColor = true;
			// 
			// fontDialog1
			// 
			this.fontDialog1.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			// 
			// checkBoxSingleLine
			// 
			this.checkBoxSingleLine.AutoSize = true;
			this.checkBoxSingleLine.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxSingleLine.Location = new System.Drawing.Point(264, 140);
			this.checkBoxSingleLine.Name = "checkBoxSingleLine";
			this.checkBoxSingleLine.Size = new System.Drawing.Size(100, 21);
			this.checkBoxSingleLine.TabIndex = 108;
			this.checkBoxSingleLine.Text = "Single Line";
			this.checkBoxSingleLine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip1.SetToolTip(this.checkBoxSingleLine, "Convert multi line incoming messages to single line of text.");
			this.checkBoxSingleLine.UseVisualStyleBackColor = true;
			this.checkBoxSingleLine.CheckedChanged += new System.EventHandler(this.checkBox_CheckedChanged);
			// 
			// MSGTextSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(597, 503);
			this.Controls.Add(this.groupBoxSeqSettings);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.ok);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(615, 550);
			this.MinimumSize = new System.Drawing.Size(615, 550);
			this.Name = "MSGTextSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Text Settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MSGTextSettings_FormClosing);
			this.Load += new System.EventHandler(this.MessagingSettings_Load);
			((System.ComponentModel.ISupportInitialize)(this.ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWords)).EndInit();
			this.RandomColourSelection.ResumeLayout(false);
			this.RandomColourSelection.PerformLayout();
			this.groupBoxSeqSettings.ResumeLayout(false);
			this.groupBoxSeqSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarIntensity)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextPosition)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBarTextIterations)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.PictureBox ok;
		private System.Windows.Forms.ToolTip toolTip1;
		public System.Windows.Forms.PictureBox Cancel;
		private System.Windows.Forms.GroupBox groupBoxSeqSettings;
		private System.Windows.Forms.TrackBar trackBarIntensity;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox checkBoxCenterText;
		private System.Windows.Forms.CheckBox checkBoxCenterStop;
		private System.Windows.Forms.Label label98;
		private System.Windows.Forms.ComboBox incomingMessageColourOption;
		private System.Windows.Forms.Label label88;
		private System.Windows.Forms.NumericUpDown numericUpDownMaxWords;
		private System.Windows.Forms.TextBox textBoxFontSize;
		private System.Windows.Forms.Button buttonFont;
		private System.Windows.Forms.TextBox textBoxFont;
		private System.Windows.Forms.ComboBox comboBoxString;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.ComboBox comboBoxTextDirection;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.TrackBar trackBarTextPosition;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TrackBar trackBarTextIterations;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.GroupBox RandomColourSelection;
		private System.Windows.Forms.Label labelColour10;
		private System.Windows.Forms.Label labelColour9;
		private System.Windows.Forms.Label labelColour8;
		private System.Windows.Forms.Label labelColour7;
		private System.Windows.Forms.Label labelColour6;
		private System.Windows.Forms.Label labelColour5;
		private System.Windows.Forms.Label labelColour4;
		private System.Windows.Forms.Label labelColour3;
		private System.Windows.Forms.Label labelColour2;
		private System.Windows.Forms.Label labelColour1;
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
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBoxGradientMode;
		private System.Windows.Forms.TrackBar trackBarTextSpeed;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox checkBoxSingleLine;
    }
}