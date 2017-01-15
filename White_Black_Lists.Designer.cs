namespace Vixen_Messaging
{
	partial class White_Black_Lists
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(White_Black_Lists));
			this.ok = new System.Windows.Forms.PictureBox();
			this.Cancel = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.richTextBoxWhitelist = new System.Windows.Forms.RichTextBox();
			this.richTextBoxBlacklist = new System.Windows.Forms.RichTextBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonDefaultLists = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).BeginInit();
			this.SuspendLayout();
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(274, 528);
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
			this.Cancel.Location = new System.Drawing.Point(345, 528);
			this.Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(61, 61);
			this.Cancel.TabIndex = 4;
			this.Cancel.TabStop = false;
			this.Cancel.Tag = "8";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// richTextBoxWhitelist
			// 
			this.richTextBoxWhitelist.Location = new System.Drawing.Point(222, 52);
			this.richTextBoxWhitelist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxWhitelist.Name = "richTextBoxWhitelist";
			this.richTextBoxWhitelist.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.richTextBoxWhitelist.Size = new System.Drawing.Size(191, 462);
			this.richTextBoxWhitelist.TabIndex = 17;
			this.richTextBoxWhitelist.Text = "";
			this.toolTip1.SetToolTip(this.richTextBoxWhitelist, "Can edit directly in the text box and then save. Not required to use non Alphanum" +
        "eric characters.");
			// 
			// richTextBoxBlacklist
			// 
			this.richTextBoxBlacklist.Location = new System.Drawing.Point(12, 52);
			this.richTextBoxBlacklist.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBoxBlacklist.Name = "richTextBoxBlacklist";
			this.richTextBoxBlacklist.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.richTextBoxBlacklist.Size = new System.Drawing.Size(191, 462);
			this.richTextBoxBlacklist.TabIndex = 16;
			this.richTextBoxBlacklist.Text = "";
			this.toolTip1.SetToolTip(this.richTextBoxBlacklist, "Can edit directly in the text box and then save. Not required to use non Alphanum" +
        "eric characters.");
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.AddExtension = false;
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(57, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 17);
			this.label1.TabIndex = 18;
			this.label1.Text = "Black List";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(288, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 17);
			this.label2.TabIndex = 19;
			this.label2.Text = "White List";
			// 
			// buttonDefaultLists
			// 
			this.buttonDefaultLists.Location = new System.Drawing.Point(26, 534);
			this.buttonDefaultLists.Name = "buttonDefaultLists";
			this.buttonDefaultLists.Size = new System.Drawing.Size(168, 40);
			this.buttonDefaultLists.TabIndex = 20;
			this.buttonDefaultLists.Text = "Reset to default Lists";
			this.buttonDefaultLists.UseVisualStyleBackColor = true;
			this.buttonDefaultLists.Click += new System.EventHandler(this.buttonDefaultLists_Click);
			this.buttonDefaultLists.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonDefaultLists.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// White_Black_Lists
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(432, 583);
			this.Controls.Add(this.buttonDefaultLists);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.richTextBoxWhitelist);
			this.Controls.Add(this.richTextBoxBlacklist);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.ok);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(450, 630);
			this.MinimumSize = new System.Drawing.Size(450, 630);
			this.Name = "White_Black_Lists";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Messaging Settings";
			this.Load += new System.EventHandler(this.MessagingSettings_Load);
			((System.ComponentModel.ISupportInitialize)(this.ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.PictureBox ok;
		private System.Windows.Forms.ToolTip toolTip1;
		public System.Windows.Forms.PictureBox Cancel;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.RichTextBox richTextBoxWhitelist;
		private System.Windows.Forms.RichTextBox richTextBoxBlacklist;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonDefaultLists;
    }
}