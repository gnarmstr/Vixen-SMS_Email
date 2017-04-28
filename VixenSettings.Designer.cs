namespace Vixen_Messaging
{
	partial class VixenSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VixenSettings));
			this.ok = new System.Windows.Forms.PictureBox();
			this.Cancel = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.label100 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.textBoxGroupName = new System.Windows.Forms.TextBox();
			this.buttonGetVixenData = new System.Windows.Forms.Button();
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
			((System.ComponentModel.ISupportInitialize)(this.ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(555, 245);
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
			this.Cancel.Location = new System.Drawing.Point(631, 245);
			this.Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(61, 61);
			this.Cancel.TabIndex = 4;
			this.Cancel.TabStop = false;
			this.Cancel.Tag = "8";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
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
			// textBoxGroupName
			// 
			this.textBoxGroupName.Location = new System.Drawing.Point(143, 27);
			this.textBoxGroupName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxGroupName.Name = "textBoxGroupName";
			this.textBoxGroupName.Size = new System.Drawing.Size(273, 22);
			this.textBoxGroupName.TabIndex = 90;
			this.toolTip1.SetToolTip(this.textBoxGroupName, "Enter your Matrix/Megatree group name that you will be sending messages to.");
			this.textBoxGroupName.TextChanged += new System.EventHandler(this.textBox_Changed);
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
			this.groupBox3.Location = new System.Drawing.Point(12, 11);
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
			this.textBoxVixenFolder.TextChanged += new System.EventHandler(this.textBox_Changed);
			// 
			// textBoxNodeId
			// 
			this.textBoxNodeId.Enabled = false;
			this.textBoxNodeId.Location = new System.Drawing.Point(143, 64);
			this.textBoxNodeId.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxNodeId.Name = "textBoxNodeId";
			this.textBoxNodeId.Size = new System.Drawing.Size(559, 22);
			this.textBoxNodeId.TabIndex = 10;
			this.textBoxNodeId.TextChanged += new System.EventHandler(this.textBox_Changed);
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
			this.textBoxOutputSequence.TextChanged += new System.EventHandler(this.textBox_Changed);
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
			this.textBoxSequenceTemplate.TextChanged += new System.EventHandler(this.textBox_Changed);
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
			this.textBoxVixenServer.TextChanged += new System.EventHandler(this.textBox_Changed);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.AddExtension = false;
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// VixenSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(732, 298);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.ok);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(750, 345);
			this.MinimumSize = new System.Drawing.Size(750, 345);
			this.Name = "VixenSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Messaging Settings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessagingSettings_FormClosing);
			this.Load += new System.EventHandler(this.VixenSettings_Load);
			((System.ComponentModel.ISupportInitialize)(this.ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.PictureBox ok;
		private System.Windows.Forms.ToolTip toolTip1;
		public System.Windows.Forms.PictureBox Cancel;
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
    }
}