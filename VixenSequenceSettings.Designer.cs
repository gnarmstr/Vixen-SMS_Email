namespace Vixen_Messaging
{
	partial class VixenSequenceSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VixenSequenceSettings));
			this.ok = new System.Windows.Forms.PictureBox();
			this.Cancel = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.buttonLoadSequences = new System.Windows.Forms.Button();
			this.listBoxSequences = new System.Windows.Forms.ListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBoxSequences = new System.Windows.Forms.CheckBox();
			this.trackBarRandomVixenSequenceSensitivity = new System.Windows.Forms.TrackBar();
			this.label8 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomVixenSequenceSensitivity)).BeginInit();
			this.SuspendLayout();
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(286, 590);
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
			this.Cancel.Location = new System.Drawing.Point(362, 590);
			this.Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(61, 61);
			this.Cancel.TabIndex = 4;
			this.Cancel.TabStop = false;
			this.Cancel.Tag = "8";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.AddExtension = false;
			this.openFileDialog1.FileName = "openFileDialog1";
			this.openFileDialog1.Multiselect = true;
			// 
			// buttonLoadSequences
			// 
			this.buttonLoadSequences.BackColor = System.Drawing.Color.Honeydew;
			this.buttonLoadSequences.Location = new System.Drawing.Point(23, 22);
			this.buttonLoadSequences.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonLoadSequences.Name = "buttonLoadSequences";
			this.buttonLoadSequences.Size = new System.Drawing.Size(173, 39);
			this.buttonLoadSequences.TabIndex = 110;
			this.buttonLoadSequences.Text = "Load Vixen Sequences";
			this.buttonLoadSequences.UseVisualStyleBackColor = false;
			this.buttonLoadSequences.Click += new System.EventHandler(this.buttonLoadSequences_Click);
			this.buttonLoadSequences.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonLoadSequences.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// listBoxSequences
			// 
			this.listBoxSequences.ContextMenuStrip = this.contextMenuStrip1;
			this.listBoxSequences.FormattingEnabled = true;
			this.listBoxSequences.ItemHeight = 16;
			this.listBoxSequences.Location = new System.Drawing.Point(117, 165);
			this.listBoxSequences.Name = "listBoxSequences";
			this.listBoxSequences.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.listBoxSequences.Size = new System.Drawing.Size(269, 308);
			this.listBoxSequences.TabIndex = 111;
			this.listBoxSequences.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBoxSequences_KeyUp);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(129, 30);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(128, 26);
			this.toolStripMenuItem1.Text = "Delete";
			this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 485);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(466, 87);
			this.label1.TabIndex = 112;
			this.label1.Text = "Note: Add Vixen Sequences here that will be displayed randomly when enables and t" +
    "here are no incoming messages from the audiance.";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// checkBoxSequences
			// 
			this.checkBoxSequences.AutoSize = true;
			this.checkBoxSequences.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxSequences.Location = new System.Drawing.Point(258, 32);
			this.checkBoxSequences.Name = "checkBoxSequences";
			this.checkBoxSequences.Size = new System.Drawing.Size(149, 21);
			this.checkBoxSequences.TabIndex = 113;
			this.checkBoxSequences.Text = "Enable Sequences";
			this.checkBoxSequences.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBoxSequences.UseVisualStyleBackColor = true;
			this.checkBoxSequences.CheckedChanged += new System.EventHandler(this.checkBoxSequences_CheckedChanged);
			// 
			// trackBarRandomVixenSequenceSensitivity
			// 
			this.trackBarRandomVixenSequenceSensitivity.AutoSize = false;
			this.trackBarRandomVixenSequenceSensitivity.LargeChange = 1;
			this.trackBarRandomVixenSequenceSensitivity.Location = new System.Drawing.Point(23, 110);
			this.trackBarRandomVixenSequenceSensitivity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.trackBarRandomVixenSequenceSensitivity.Maximum = 50;
			this.trackBarRandomVixenSequenceSensitivity.Minimum = 1;
			this.trackBarRandomVixenSequenceSensitivity.Name = "trackBarRandomVixenSequenceSensitivity";
			this.trackBarRandomVixenSequenceSensitivity.Size = new System.Drawing.Size(455, 32);
			this.trackBarRandomVixenSequenceSensitivity.TabIndex = 114;
			this.toolTip1.SetToolTip(this.trackBarRandomVixenSequenceSensitivity, "This will adjust the sensitivity of how often a Vixen Sequence is displayed.");
			this.trackBarRandomVixenSequenceSensitivity.Value = 1;
			this.trackBarRandomVixenSequenceSensitivity.Scroll += new System.EventHandler(this.trackBarRandomVixenSequenceSensitivity_MouseDown);
			this.trackBarRandomVixenSequenceSensitivity.ValueChanged += new System.EventHandler(this.trackBarRandomVixenSequenceSensitivity_ValueChanged);
			this.trackBarRandomVixenSequenceSensitivity.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBarRandomVixenSequenceSensitivity_MouseDown);
			this.trackBarRandomVixenSequenceSensitivity.MouseHover += new System.EventHandler(this.trackBarRandomVixenSequenceSensitivity_MouseDown);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(147, 81);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(200, 17);
			this.label8.TabIndex = 115;
			this.label8.Text = "Random Sequence Sensitivity:";
			this.toolTip1.SetToolTip(this.label8, "This will adjust the sensitivity of how often a Vixen Sequence is displayed.");
			// 
			// VixenSequenceSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(482, 633);
			this.Controls.Add(this.trackBarRandomVixenSequenceSensitivity);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.checkBoxSequences);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBoxSequences);
			this.Controls.Add(this.buttonLoadSequences);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.ok);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(500, 680);
			this.MinimumSize = new System.Drawing.Size(500, 680);
			this.Name = "VixenSequenceSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Vixen Sequences";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MessagingSettings_FormClosing);
			this.Load += new System.EventHandler(this.VixenSequenceSettings_Load);
			((System.ComponentModel.ISupportInitialize)(this.ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.Cancel)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBarRandomVixenSequenceSensitivity)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.PictureBox ok;
		private System.Windows.Forms.ToolTip toolTip1;
		public System.Windows.Forms.PictureBox Cancel;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button buttonLoadSequences;
		private System.Windows.Forms.ListBox listBoxSequences;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox checkBoxSequences;
		private System.Windows.Forms.TrackBar trackBarRandomVixenSequenceSensitivity;
		private System.Windows.Forms.Label label8;
    }
}