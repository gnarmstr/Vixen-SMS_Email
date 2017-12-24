namespace Vixen_Messaging
{
	partial class BulkSMS
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkSMS));
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.ok = new System.Windows.Forms.PictureBox();
			this.textBoxMessage = new System.Windows.Forms.TextBox();
			this.SendMessage = new System.Windows.Forms.PictureBox();
			this.labelBulkStatus = new System.Windows.Forms.Label();
			this.checkBoxSingleSMS = new System.Windows.Forms.CheckBox();
			this.textBoxSingleSMS = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.ok)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SendMessage)).BeginInit();
			this.SuspendLayout();
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.AddExtension = false;
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// toolTip2
			// 
			this.toolTip2.AutoPopDelay = 10000;
			this.toolTip2.InitialDelay = 500;
			this.toolTip2.ReshowDelay = 100;
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
			this.label3.Location = new System.Drawing.Point(26, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(472, 42);
			this.label3.TabIndex = 102;
			this.label3.Text = "Message to be sent to Mobile number/s in the Phone log or below if Single Mobile " +
    "is selected:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ok
			// 
			this.ok.Location = new System.Drawing.Point(437, 404);
			this.ok.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.ok.Name = "ok";
			this.ok.Size = new System.Drawing.Size(61, 61);
			this.ok.TabIndex = 92;
			this.ok.TabStop = false;
			this.ok.Tag = "7";
			this.ok.Click += new System.EventHandler(this.Ok_Click);
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.Location = new System.Drawing.Point(30, 69);
			this.textBoxMessage.Multiline = true;
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.Size = new System.Drawing.Size(468, 221);
			this.textBoxMessage.TabIndex = 103;
			// 
			// SendMessage
			// 
			this.SendMessage.Location = new System.Drawing.Point(89, 356);
			this.SendMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.SendMessage.Name = "SendMessage";
			this.SendMessage.Size = new System.Drawing.Size(131, 48);
			this.SendMessage.TabIndex = 104;
			this.SendMessage.TabStop = false;
			this.SendMessage.Tag = "7";
			this.SendMessage.Click += new System.EventHandler(this.SendMessage_Click);
			// 
			// labelBulkStatus
			// 
			this.labelBulkStatus.Location = new System.Drawing.Point(98, 421);
			this.labelBulkStatus.Name = "labelBulkStatus";
			this.labelBulkStatus.Size = new System.Drawing.Size(301, 23);
			this.labelBulkStatus.TabIndex = 105;
			// 
			// checkBoxSingleSMS
			// 
			this.checkBoxSingleSMS.AutoSize = true;
			this.checkBoxSingleSMS.Location = new System.Drawing.Point(30, 307);
			this.checkBoxSingleSMS.Name = "checkBoxSingleSMS";
			this.checkBoxSingleSMS.Size = new System.Drawing.Size(221, 21);
			this.checkBoxSingleSMS.TabIndex = 106;
			this.checkBoxSingleSMS.Text = "Send to Single Mobile Number";
			this.checkBoxSingleSMS.UseVisualStyleBackColor = true;
			this.checkBoxSingleSMS.CheckedChanged += new System.EventHandler(this.checkBoxSingleSMS_CheckedChanged);
			// 
			// textBoxSingleSMS
			// 
			this.textBoxSingleSMS.Location = new System.Drawing.Point(278, 307);
			this.textBoxSingleSMS.Name = "textBoxSingleSMS";
			this.textBoxSingleSMS.Size = new System.Drawing.Size(220, 22);
			this.textBoxSingleSMS.TabIndex = 107;
			this.textBoxSingleSMS.Visible = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(278, 336);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(220, 56);
			this.label1.TabIndex = 108;
			this.label1.Text = "Only enter one number and must have country code in front. Ex +61425183697";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.label1.Visible = false;
			// 
			// BulkSMS
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(532, 453);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxSingleSMS);
			this.Controls.Add(this.checkBoxSingleSMS);
			this.Controls.Add(this.labelBulkStatus);
			this.Controls.Add(this.SendMessage);
			this.Controls.Add(this.textBoxMessage);
			this.Controls.Add(this.ok);
			this.Controls.Add(this.label3);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(550, 500);
			this.MinimumSize = new System.Drawing.Size(550, 500);
			this.Name = "BulkSMS";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Send SMS";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Scheduler_FormClosing);
			this.Load += new System.EventHandler(this.Schedules_Load);
			((System.ComponentModel.ISupportInitialize)(this.ok)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SendMessage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.ToolTip toolTip2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox ok;
		private System.Windows.Forms.TextBox textBoxMessage;
		private System.Windows.Forms.PictureBox SendMessage;
		private System.Windows.Forms.Label labelBulkStatus;
		private System.Windows.Forms.CheckBox checkBoxSingleSMS;
		private System.Windows.Forms.TextBox textBoxSingleSMS;
		private System.Windows.Forms.Label label1;
    }
}