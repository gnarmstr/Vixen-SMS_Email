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
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// checkBoxWebServer
			// 
			this.checkBoxWebServer.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxWebServer.Location = new System.Drawing.Point(400, 67);
			this.checkBoxWebServer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxWebServer.Name = "checkBoxWebServer";
			this.checkBoxWebServer.Size = new System.Drawing.Size(20, 18);
			this.checkBoxWebServer.TabIndex = 1;
			this.toolTip1.SetToolTip(this.checkBoxWebServer, "Server port used for the Vixen Web access");
			this.checkBoxWebServer.UseVisualStyleBackColor = true;
			// 
			// checkBoxNodeID
			// 
			this.checkBoxNodeID.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxNodeID.Location = new System.Drawing.Point(162, 102);
			this.checkBoxNodeID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxNodeID.Name = "checkBoxNodeID";
			this.checkBoxNodeID.Size = new System.Drawing.Size(20, 18);
			this.checkBoxNodeID.TabIndex = 2;
			this.toolTip1.SetToolTip(this.checkBoxNodeID, "This is the Node ID for your Group that you will use to add effects and Message f" +
        "rom the audience. Ex Front Matrix");
			this.checkBoxNodeID.UseVisualStyleBackColor = true;
			// 
			// checkBoxVixenPath
			// 
			this.checkBoxVixenPath.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBoxVixenPath.Location = new System.Drawing.Point(162, 65);
			this.checkBoxVixenPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.checkBoxVixenPath.Name = "checkBoxVixenPath";
			this.checkBoxVixenPath.Size = new System.Drawing.Size(20, 18);
			this.checkBoxVixenPath.TabIndex = 0;
			this.toolTip1.SetToolTip(this.checkBoxVixenPath, "This is the main Vixen path, normaly located in your Documents folder. Must have " +
        "a Path before other data can be retrieved.");
			this.checkBoxVixenPath.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(195, 283);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(71, 64);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Tag = "7";
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.Location = new System.Drawing.Point(305, 283);
			this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(71, 64);
			this.pictureBox2.TabIndex = 4;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Tag = "8";
			this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(134, 17);
			this.label1.TabIndex = 6;
			this.label1.Text = "Vixen 3 Folder path:";
			this.toolTip1.SetToolTip(this.label1, "This is the main Vixen path, normally located in your Documents folder. Must have" +
        " a Path before other data can be retrieved.");
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(221, 67);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(125, 17);
			this.label2.TabIndex = 7;
			this.label2.Text = "Vixen Web Server:";
			this.toolTip1.SetToolTip(this.label2, "Server port used for the Vixen Web access");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 102);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(107, 17);
			this.label3.TabIndex = 8;
			this.label3.Text = "Group Node ID:";
			this.toolTip1.SetToolTip(this.label3, "This is the Node ID for your Group that you will use to add effects and Message f" +
        "rom the audience. Ex Front Matrix");
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 138);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(131, 17);
			this.label6.TabIndex = 12;
			this.label6.Text = "Vixen Group Name:";
			this.toolTip1.SetToolTip(this.label6, "This is the exact name of the Group in your Vixen sequence that you will be sendi" +
        "ng the Text Message to and is case sensitive. Example Front Matrix.");
			// 
			// textBoxVixenGroupName
			// 
			this.textBoxVixenGroupName.Location = new System.Drawing.Point(225, 136);
			this.textBoxVixenGroupName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxVixenGroupName.Name = "textBoxVixenGroupName";
			this.textBoxVixenGroupName.Size = new System.Drawing.Size(196, 22);
			this.textBoxVixenGroupName.TabIndex = 3;
			this.toolTip1.SetToolTip(this.textBoxVixenGroupName, "This is the exact name of the Group in your Vixen sequence that you will be sendi" +
        "ng the Text Message to and is case sensitive. Example Front Matrix.");
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(16, 19);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(421, 41);
			this.label5.TabIndex = 10;
			this.label5.Text = "Only select and/or enter the information Settings you would like to retrieve and " +
    "then select Ok.";
			// 
			// RetrieveVixenSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(454, 362);
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
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(472, 409);
			this.MinimumSize = new System.Drawing.Size(472, 409);
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
        private System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox textBoxVixenGroupName;
        public System.Windows.Forms.PictureBox pictureBox2;
    }
}