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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxUID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxPWD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxLogFileName = new System.Windows.Forms.TextBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.timerCheckMail = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxReplaceText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxOutputSequence = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxSequenceTemplate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxVixenServer = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.msgretrievaltime = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msgretrievaltime)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "POP3 Server:";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(135, 38);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(514, 26);
            this.textBoxServer.TabIndex = 1;
            // 
            // textBoxUID
            // 
            this.textBoxUID.Location = new System.Drawing.Point(135, 69);
            this.textBoxUID.Name = "textBoxUID";
            this.textBoxUID.Size = new System.Drawing.Size(514, 26);
            this.textBoxUID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Name:";
            // 
            // textBoxPWD
            // 
            this.textBoxPWD.Location = new System.Drawing.Point(135, 98);
            this.textBoxPWD.Name = "textBoxPWD";
            this.textBoxPWD.PasswordChar = '*';
            this.textBoxPWD.Size = new System.Drawing.Size(514, 26);
            this.textBoxPWD.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxPWD);
            this.groupBox1.Controls.Add(this.textBoxServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxUID);
            this.groupBox1.Location = new System.Drawing.Point(12, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(669, 145);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mail Server";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(409, 720);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(123, 46);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(546, 720);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(123, 46);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxLogFileName);
            this.groupBox2.Controls.Add(this.listBoxLog);
            this.groupBox2.Location = new System.Drawing.Point(12, 354);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(669, 266);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Log";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "Log File:";
            // 
            // textBoxLogFileName
            // 
            this.textBoxLogFileName.Location = new System.Drawing.Point(93, 229);
            this.textBoxLogFileName.Name = "textBoxLogFileName";
            this.textBoxLogFileName.Size = new System.Drawing.Size(553, 26);
            this.textBoxLogFileName.TabIndex = 12;
            // 
            // listBoxLog
            // 
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.HorizontalScrollbar = true;
            this.listBoxLog.ItemHeight = 20;
            this.listBoxLog.Location = new System.Drawing.Point(21, 35);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(625, 184);
            this.listBoxLog.TabIndex = 0;
            this.listBoxLog.SelectedIndexChanged += new System.EventHandler(this.listBoxLog_SelectedIndexChanged);
            // 
            // timerCheckMail
            // 
            this.timerCheckMail.Interval = 1000;
            this.timerCheckMail.Tick += new System.EventHandler(this.timerCheckMail_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxReplaceText);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBoxOutputSequence);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBoxSequenceTemplate);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxVixenServer);
            this.groupBox3.Location = new System.Drawing.Point(12, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(669, 178);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vixen Info";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "Text to Replace:";
            this.toolTip1.SetToolTip(this.label7, "This same text should be added to a Nutcracker text effect in the HelloX.tim file" +
        "s");
            // 
            // textBoxReplaceText
            // 
            this.textBoxReplaceText.Location = new System.Drawing.Point(183, 123);
            this.textBoxReplaceText.Name = "textBoxReplaceText";
            this.textBoxReplaceText.Size = new System.Drawing.Size(463, 26);
            this.textBoxReplaceText.TabIndex = 9;
            this.textBoxReplaceText.TextChanged += new System.EventHandler(this.textBoxReplaceText_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Output Sequence:";
            // 
            // textBoxOutputSequence
            // 
            this.textBoxOutputSequence.Location = new System.Drawing.Point(183, 92);
            this.textBoxOutputSequence.Name = "textBoxOutputSequence";
            this.textBoxOutputSequence.Size = new System.Drawing.Size(463, 26);
            this.textBoxOutputSequence.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Template Folder:";
            // 
            // textBoxSequenceTemplate
            // 
            this.textBoxSequenceTemplate.Location = new System.Drawing.Point(183, 63);
            this.textBoxSequenceTemplate.Name = "textBoxSequenceTemplate";
            this.textBoxSequenceTemplate.Size = new System.Drawing.Size(463, 26);
            this.textBoxSequenceTemplate.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Vixen Server:";
            // 
            // textBoxVixenServer
            // 
            this.textBoxVixenServer.Location = new System.Drawing.Point(183, 34);
            this.textBoxVixenServer.Name = "textBoxVixenServer";
            this.textBoxVixenServer.Size = new System.Drawing.Size(463, 26);
            this.textBoxVixenServer.TabIndex = 3;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 300;
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 300;
            this.toolTip1.ReshowDelay = 60;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(711, 684);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(703, 651);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.msgretrievaltime);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(703, 651);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Options";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 39);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Message Retrieval time:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(294, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 20);
            this.label10.TabIndex = 2;
            this.label10.Text = "Sec";
            // 
            // msgretrievaltime
            // 
            this.msgretrievaltime.Location = new System.Drawing.Point(213, 37);
            this.msgretrievaltime.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.msgretrievaltime.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.msgretrievaltime.Name = "msgretrievaltime";
            this.msgretrievaltime.Size = new System.Drawing.Size(75, 26);
            this.msgretrievaltime.TabIndex = 3;
            this.msgretrievaltime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.msgretrievaltime.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.msgretrievaltime.ValueChanged += new System.EventHandler(this.msgretrievaltime_ValueChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 793);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(743, 849);
            this.Name = "FormMain";
            this.Text = "Vixen Messaging";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.msgretrievaltime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxUID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxPWD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Timer timerCheckMail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxOutputSequence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxSequenceTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxVixenServer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxReplaceText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxLogFileName;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown msgretrievaltime;
    }
}

