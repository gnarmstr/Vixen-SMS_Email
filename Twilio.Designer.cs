namespace Vixen_Messaging
{
    partial class Twilio
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
            this.textBoxSID = new System.Windows.Forms.TextBox();
            this.textBoxToken = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxOk = new System.Windows.Forms.PictureBox();
            this.pictureBoxCancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSID
            // 
            this.textBoxSID.Location = new System.Drawing.Point(272, 114);
            this.textBoxSID.Name = "textBoxSID";
            this.textBoxSID.Size = new System.Drawing.Size(343, 26);
            this.textBoxSID.TabIndex = 0;
            this.textBoxSID.Text = "AC29390b0fe3f4cb763862eefedb8afc41";
            // 
            // textBoxToken
            // 
            this.textBoxToken.Location = new System.Drawing.Point(272, 170);
            this.textBoxToken.Name = "textBoxToken";
            this.textBoxToken.Size = new System.Drawing.Size(343, 26);
            this.textBoxToken.TabIndex = 1;
            this.textBoxToken.Text = "d68a401090af00f63bbecb4a3e502a7f";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account SID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Authorisation Token:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(86, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(514, 32);
            this.label3.TabIndex = 4;
            this.label3.Text = "Enter your Twilio account details below.";
            // 
            // pictureBoxOk
            // 
            this.pictureBoxOk.Location = new System.Drawing.Point(402, 228);
            this.pictureBoxOk.Name = "pictureBoxOk";
            this.pictureBoxOk.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxOk.TabIndex = 5;
            this.pictureBoxOk.TabStop = false;
            this.pictureBoxOk.Tag = "7";
            this.pictureBoxOk.Click += new System.EventHandler(this.pictureBoxOk_Click);
            // 
            // pictureBoxCancel
            // 
            this.pictureBoxCancel.Location = new System.Drawing.Point(535, 228);
            this.pictureBoxCancel.Name = "pictureBoxCancel";
            this.pictureBoxCancel.Size = new System.Drawing.Size(80, 80);
            this.pictureBoxCancel.TabIndex = 6;
            this.pictureBoxCancel.TabStop = false;
            this.pictureBoxCancel.Tag = "7";
            this.pictureBoxCancel.Click += new System.EventHandler(this.pictureBoxCancel_Click);
            // 
            // Twilio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(653, 342);
            this.Controls.Add(this.pictureBoxCancel);
            this.Controls.Add(this.pictureBoxOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxToken);
            this.Controls.Add(this.textBoxSID);
            this.Name = "Twilio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Twilio Settings";
            this.Load += new System.EventHandler(this.Twilio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSID;
        private System.Windows.Forms.TextBox textBoxToken;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxOk;
        private System.Windows.Forms.PictureBox pictureBoxCancel;
    }
}