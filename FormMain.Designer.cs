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
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 26);
			this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "POP3 Server:";
			// 
			// textBoxServer
			// 
			this.textBoxServer.Location = new System.Drawing.Point(88, 24);
			this.textBoxServer.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxServer.Name = "textBoxServer";
			this.textBoxServer.Size = new System.Drawing.Size(344, 20);
			this.textBoxServer.TabIndex = 1;
			// 
			// textBoxUID
			// 
			this.textBoxUID.Location = new System.Drawing.Point(88, 44);
			this.textBoxUID.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxUID.Name = "textBoxUID";
			this.textBoxUID.Size = new System.Drawing.Size(344, 20);
			this.textBoxUID.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 45);
			this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "UID:";
			// 
			// textBoxPWD
			// 
			this.textBoxPWD.Location = new System.Drawing.Point(88, 63);
			this.textBoxPWD.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxPWD.Name = "textBoxPWD";
			this.textBoxPWD.PasswordChar = '*';
			this.textBoxPWD.Size = new System.Drawing.Size(344, 20);
			this.textBoxPWD.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(14, 64);
			this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(36, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "PWD:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.textBoxPWD);
			this.groupBox1.Controls.Add(this.textBoxServer);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.textBoxUID);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox1.Size = new System.Drawing.Size(446, 94);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mail Server";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(279, 413);
			this.buttonStart.Margin = new System.Windows.Forms.Padding(2);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(82, 30);
			this.buttonStart.TabIndex = 7;
			this.buttonStart.Text = "Start";
			this.buttonStart.UseVisualStyleBackColor = true;
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// buttonStop
			// 
			this.buttonStop.Location = new System.Drawing.Point(370, 413);
			this.buttonStop.Margin = new System.Windows.Forms.Padding(2);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(82, 30);
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
			this.groupBox2.Location = new System.Drawing.Point(6, 230);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox2.Size = new System.Drawing.Size(446, 173);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Log";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 151);
			this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(47, 13);
			this.label8.TabIndex = 11;
			this.label8.Text = "Log File:";
			// 
			// textBoxLogFileName
			// 
			this.textBoxLogFileName.Location = new System.Drawing.Point(62, 149);
			this.textBoxLogFileName.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxLogFileName.Name = "textBoxLogFileName";
			this.textBoxLogFileName.Size = new System.Drawing.Size(370, 20);
			this.textBoxLogFileName.TabIndex = 12;
			// 
			// listBoxLog
			// 
			this.listBoxLog.FormattingEnabled = true;
			this.listBoxLog.HorizontalScrollbar = true;
			this.listBoxLog.Location = new System.Drawing.Point(14, 23);
			this.listBoxLog.Margin = new System.Windows.Forms.Padding(2);
			this.listBoxLog.Name = "listBoxLog";
			this.listBoxLog.Size = new System.Drawing.Size(418, 121);
			this.listBoxLog.TabIndex = 0;
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
			this.groupBox3.Location = new System.Drawing.Point(6, 103);
			this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
			this.groupBox3.Size = new System.Drawing.Size(446, 116);
			this.groupBox3.TabIndex = 10;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Vixen Info";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(14, 81);
			this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(86, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "Text to Replace:";
			// 
			// textBoxReplaceText
			// 
			this.textBoxReplaceText.Location = new System.Drawing.Point(122, 80);
			this.textBoxReplaceText.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxReplaceText.Name = "textBoxReplaceText";
			this.textBoxReplaceText.Size = new System.Drawing.Size(310, 20);
			this.textBoxReplaceText.TabIndex = 9;
			this.textBoxReplaceText.TextChanged += new System.EventHandler(this.textBoxReplaceText_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(14, 62);
			this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(94, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "Output Sequence:";
			// 
			// textBoxOutputSequence
			// 
			this.textBoxOutputSequence.Location = new System.Drawing.Point(122, 60);
			this.textBoxOutputSequence.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxOutputSequence.Name = "textBoxOutputSequence";
			this.textBoxOutputSequence.Size = new System.Drawing.Size(310, 20);
			this.textBoxOutputSequence.TabIndex = 7;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 43);
			this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(86, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Template Folder:";
			// 
			// textBoxSequenceTemplate
			// 
			this.textBoxSequenceTemplate.Location = new System.Drawing.Point(122, 41);
			this.textBoxSequenceTemplate.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxSequenceTemplate.Name = "textBoxSequenceTemplate";
			this.textBoxSequenceTemplate.Size = new System.Drawing.Size(310, 20);
			this.textBoxSequenceTemplate.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 23);
			this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(70, 13);
			this.label4.TabIndex = 2;
			this.label4.Text = "Vixen Server:";
			// 
			// textBoxVixenServer
			// 
			this.textBoxVixenServer.Location = new System.Drawing.Point(122, 22);
			this.textBoxVixenServer.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxVixenServer.Name = "textBoxVixenServer";
			this.textBoxVixenServer.Size = new System.Drawing.Size(310, 20);
			this.textBoxVixenServer.TabIndex = 3;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(471, 459);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.buttonStop);
			this.Controls.Add(this.buttonStart);
			this.Controls.Add(this.groupBox1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(487, 498);
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
    }
}

