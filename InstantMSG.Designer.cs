namespace Vixen_Messaging
{
	partial class InstantMSG
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
			this.textBoxInstantMSG = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.pictureBoxOk = new System.Windows.Forms.PictureBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOk)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxInstantMSG
			// 
			this.textBoxInstantMSG.Location = new System.Drawing.Point(12, 55);
			this.textBoxInstantMSG.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxInstantMSG.Name = "textBoxInstantMSG";
			this.textBoxInstantMSG.Size = new System.Drawing.Size(459, 22);
			this.textBoxInstantMSG.TabIndex = 0;
			this.toolTip1.SetToolTip(this.textBoxInstantMSG, "Enter your Twilio Account SID.");
			this.textBoxInstantMSG.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxInstantMSG_KeyUp);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(95, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(305, 29);
			this.label3.TabIndex = 4;
			this.label3.Text = "Enter your message below.";
			// 
			// pictureBoxOk
			// 
			this.pictureBoxOk.Location = new System.Drawing.Point(386, 96);
			this.pictureBoxOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.pictureBoxOk.Name = "pictureBoxOk";
			this.pictureBoxOk.Size = new System.Drawing.Size(71, 64);
			this.pictureBoxOk.TabIndex = 5;
			this.pictureBoxOk.TabStop = false;
			this.pictureBoxOk.Tag = "7";
			this.pictureBoxOk.Click += new System.EventHandler(this.pictureBoxOk_Click);
			// 
			// InstantMSG
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(482, 148);
			this.Controls.Add(this.pictureBoxOk);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxInstantMSG);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(500, 195);
			this.MinimumSize = new System.Drawing.Size(500, 195);
			this.Name = "InstantMSG";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Twilio Settings";
			this.Load += new System.EventHandler(this.Twilio_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxOk)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.TextBox textBoxInstantMSG;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBoxOk;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}