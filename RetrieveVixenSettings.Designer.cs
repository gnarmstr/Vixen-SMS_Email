namespace Vixen_Messaging
{
    partial class RetrieveVixenSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetrieveVixenSettings));
            this.checkBoxWebServer = new System.Windows.Forms.CheckBox();
            this.checkBoxNodeID = new System.Windows.Forms.CheckBox();
            this.checkBoxVixenPath = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxVixenGroupName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPWD = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxUID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxWebServer
            // 
            this.checkBoxWebServer.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBoxWebServer.Location = new System.Drawing.Point(450, 84);
            this.checkBoxWebServer.Name = "checkBoxWebServer";
            this.checkBoxWebServer.Size = new System.Drawing.Size(23, 23);
            this.checkBoxWebServer.TabIndex = 1;
            this.toolTip1.SetToolTip(this.checkBoxWebServer, "Server port used for the Vixen Web access");
            this.checkBoxWebServer.UseVisualStyleBackColor = true;
            // 
            // checkBoxNodeID
            // 
            this.checkBoxNodeID.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBoxNodeID.Location = new System.Drawing.Point(182, 127);
            this.checkBoxNodeID.Name = "checkBoxNodeID";
            this.checkBoxNodeID.Size = new System.Drawing.Size(23, 23);
            this.checkBoxNodeID.TabIndex = 2;
            this.toolTip1.SetToolTip(this.checkBoxNodeID, "This is the Node ID for your Group that you will use to add effects and Message f" +
        "rom the audience. Ex Front Matrix");
            this.checkBoxNodeID.UseVisualStyleBackColor = true;
            // 
            // checkBoxVixenPath
            // 
            this.checkBoxVixenPath.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBoxVixenPath.Location = new System.Drawing.Point(182, 81);
            this.checkBoxVixenPath.Name = "checkBoxVixenPath";
            this.checkBoxVixenPath.Size = new System.Drawing.Size(23, 23);
            this.checkBoxVixenPath.TabIndex = 0;
            this.toolTip1.SetToolTip(this.checkBoxVixenPath, "This is the main Vixen path, normaly located in your Documents folder. Must have " +
        "a Path before other data can be retrieved.");
            this.checkBoxVixenPath.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(219, 354);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Tag = "7";
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(343, 354);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 80);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "8";
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Vixen 3 Folder path:";
            this.toolTip1.SetToolTip(this.label1, "This is the main Vixen path, normally located in your Documents folder. Must have" +
        " a Path before other data can be retrieved.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(249, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Vixen Web Server:";
            this.toolTip1.SetToolTip(this.label2, "Server port used for the Vixen Web access");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Group Node ID:";
            this.toolTip1.SetToolTip(this.label3, "This is the Node ID for your Group that you will use to add effects and Message f" +
        "rom the audience. Ex Front Matrix");
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Vixen Group Name:";
            this.toolTip1.SetToolTip(this.label6, "This is the exact name of the Group in your Vixen sequence that you will be sendi" +
        "ng the Text Message to and is case sensitive. Example Front Matrix.");
            // 
            // textBoxVixenGroupName
            // 
            this.textBoxVixenGroupName.Location = new System.Drawing.Point(253, 170);
            this.textBoxVixenGroupName.Name = "textBoxVixenGroupName";
            this.textBoxVixenGroupName.Size = new System.Drawing.Size(220, 26);
            this.textBoxVixenGroupName.TabIndex = 3;
            this.toolTip1.SetToolTip(this.textBoxVixenGroupName, "This is the exact name of the Group in your Vixen sequence that you will be sendi" +
        "ng the Text Message to and is case sensitive. Example Front Matrix.");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "POP3 Server:";
            this.toolTip1.SetToolTip(this.label7, "Enter email server. For Example:  pop.gmail.com");
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(18, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(474, 51);
            this.label5.TabIndex = 10;
            this.label5.Text = "Only select and/or enter the information Settings you would like to retrieve and " +
    "then select Ok.";
            // 
            // textBoxPWD
            // 
            this.textBoxPWD.Location = new System.Drawing.Point(129, 307);
            this.textBoxPWD.Name = "textBoxPWD";
            this.textBoxPWD.PasswordChar = '*';
            this.textBoxPWD.Size = new System.Drawing.Size(344, 26);
            this.textBoxPWD.TabIndex = 6;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(129, 220);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(344, 26);
            this.textBoxServer.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 310);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 266);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "User Name:";
            // 
            // textBoxUID
            // 
            this.textBoxUID.Location = new System.Drawing.Point(129, 263);
            this.textBoxUID.Name = "textBoxUID";
            this.textBoxUID.Size = new System.Drawing.Size(344, 26);
            this.textBoxUID.TabIndex = 5;
            // 
            // RetrieveVixenSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(507, 444);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxPWD);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxUID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxVixenGroupName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.checkBoxVixenPath);
            this.Controls.Add(this.checkBoxNodeID);
            this.Controls.Add(this.checkBoxWebServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(529, 500);
            this.MinimumSize = new System.Drawing.Size(529, 500);
            this.Name = "RetrieveVixenSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Retrieve Vixen Settings";
            this.Load += new System.EventHandler(this.RetrieveVixenSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.CheckBox checkBoxWebServer;
        public System.Windows.Forms.CheckBox checkBoxNodeID;
        public System.Windows.Forms.CheckBox checkBoxVixenPath;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox textBoxVixenGroupName;
        public System.Windows.Forms.TextBox textBoxPWD;
        public System.Windows.Forms.TextBox textBoxServer;
        public System.Windows.Forms.TextBox textBoxUID;
        public System.Windows.Forms.PictureBox pictureBox2;
    }
}