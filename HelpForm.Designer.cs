namespace Vixen_Messaging
{
    partial class HelpForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
			this.buttonDemo = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonTwilio = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonLauncher = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// buttonDemo
			// 
			this.buttonDemo.BackColor = System.Drawing.Color.Honeydew;
			this.buttonDemo.Location = new System.Drawing.Point(44, 559);
			this.buttonDemo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonDemo.Name = "buttonDemo";
			this.buttonDemo.Size = new System.Drawing.Size(225, 26);
			this.buttonDemo.TabIndex = 3;
			this.buttonDemo.Text = "Demo";
			this.buttonDemo.UseVisualStyleBackColor = false;
			this.buttonDemo.Click += new System.EventHandler(this.buttonDemo_Click);
			this.buttonDemo.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonDemo.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(200, 508);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(188, 33);
			this.label2.TabIndex = 7;
			this.label2.Text = "Video links";
			// 
			// buttonTwilio
			// 
			this.buttonTwilio.BackColor = System.Drawing.Color.Honeydew;
			this.buttonTwilio.Location = new System.Drawing.Point(304, 559);
			this.buttonTwilio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonTwilio.Name = "buttonTwilio";
			this.buttonTwilio.Size = new System.Drawing.Size(225, 26);
			this.buttonTwilio.TabIndex = 8;
			this.buttonTwilio.Text = "Setting up a Twilio account";
			this.buttonTwilio.UseVisualStyleBackColor = false;
			this.buttonTwilio.Click += new System.EventHandler(this.buttonTwilio_Click);
			this.buttonTwilio.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonTwilio.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 17);
			this.label3.TabIndex = 10;
			this.label3.Text = "Version 3.3u2";
			// 
			// buttonLauncher
			// 
			this.buttonLauncher.BackColor = System.Drawing.Color.Honeydew;
			this.buttonLauncher.Location = new System.Drawing.Point(73, 600);
			this.buttonLauncher.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonLauncher.Name = "buttonLauncher";
			this.buttonLauncher.Size = new System.Drawing.Size(411, 26);
			this.buttonLauncher.TabIndex = 11;
			this.buttonLauncher.Text = "Controlling this messaging app with the Vixen 3 Launcher";
			this.buttonLauncher.UseVisualStyleBackColor = false;
			this.buttonLauncher.Click += new System.EventHandler(this.buttonLauncher_Click);
			this.buttonLauncher.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonLauncher.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.Color.Azure;
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Location = new System.Drawing.Point(14, 38);
			this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.richTextBox1.Size = new System.Drawing.Size(541, 458);
			this.richTextBox1.TabIndex = 12;
			this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
			// 
			// HelpForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.Azure;
			this.ClientSize = new System.Drawing.Size(562, 653);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.buttonLauncher);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.buttonTwilio);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.buttonDemo);
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximumSize = new System.Drawing.Size(580, 700);
			this.MinimumSize = new System.Drawing.Size(580, 700);
			this.Name = "HelpForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Vixen Messaging Help";
			this.Load += new System.EventHandler(this.Help_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button buttonDemo;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button buttonTwilio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonLauncher;
		private System.Windows.Forms.RichTextBox richTextBox1;
    }
}