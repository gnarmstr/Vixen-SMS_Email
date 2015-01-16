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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDemo = new System.Windows.Forms.Button();
            this.buttonInstallation = new System.Windows.Forms.Button();
            this.buttonGmail = new System.Windows.Forms.Button();
            this.buttonEmails = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonTwilio = new System.Windows.Forms.Button();
            this.buttonRemoteCommands = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(46, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(696, 717);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // buttonDemo
            // 
            this.buttonDemo.Location = new System.Drawing.Point(50, 831);
            this.buttonDemo.Name = "buttonDemo";
            this.buttonDemo.Size = new System.Drawing.Size(319, 33);
            this.buttonDemo.TabIndex = 3;
            this.buttonDemo.Text = "Demo";
            this.buttonDemo.UseVisualStyleBackColor = true;
            this.buttonDemo.Click += new System.EventHandler(this.buttonDemo_Click);
            // 
            // buttonInstallation
            // 
            this.buttonInstallation.Location = new System.Drawing.Point(50, 886);
            this.buttonInstallation.Name = "buttonInstallation";
            this.buttonInstallation.Size = new System.Drawing.Size(319, 33);
            this.buttonInstallation.TabIndex = 4;
            this.buttonInstallation.Text = "Installation";
            this.buttonInstallation.UseVisualStyleBackColor = true;
            this.buttonInstallation.Click += new System.EventHandler(this.buttonInstallation_Click);
            // 
            // buttonGmail
            // 
            this.buttonGmail.Location = new System.Drawing.Point(423, 831);
            this.buttonGmail.Name = "buttonGmail";
            this.buttonGmail.Size = new System.Drawing.Size(319, 33);
            this.buttonGmail.TabIndex = 5;
            this.buttonGmail.Text = "Setting up a Gmail account";
            this.buttonGmail.UseVisualStyleBackColor = true;
            this.buttonGmail.Click += new System.EventHandler(this.buttonGmail_Click);
            // 
            // buttonEmails
            // 
            this.buttonEmails.Location = new System.Drawing.Point(50, 940);
            this.buttonEmails.Name = "buttonEmails";
            this.buttonEmails.Size = new System.Drawing.Size(319, 33);
            this.buttonEmails.TabIndex = 6;
            this.buttonEmails.Text = "Retrieving Emails";
            this.buttonEmails.UseVisualStyleBackColor = true;
            this.buttonEmails.Click += new System.EventHandler(this.buttonEmails_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(290, 778);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 50);
            this.label2.TabIndex = 7;
            this.label2.Text = "Video links";
            // 
            // buttonTwilio
            // 
            this.buttonTwilio.Location = new System.Drawing.Point(423, 886);
            this.buttonTwilio.Name = "buttonTwilio";
            this.buttonTwilio.Size = new System.Drawing.Size(319, 33);
            this.buttonTwilio.TabIndex = 8;
            this.buttonTwilio.Text = "Setting up a Twilio account";
            this.buttonTwilio.UseVisualStyleBackColor = true;
            this.buttonTwilio.Click += new System.EventHandler(this.buttonTwilio_Click);
            // 
            // buttonRemoteCommands
            // 
            this.buttonRemoteCommands.Location = new System.Drawing.Point(423, 940);
            this.buttonRemoteCommands.Name = "buttonRemoteCommands";
            this.buttonRemoteCommands.Size = new System.Drawing.Size(319, 33);
            this.buttonRemoteCommands.TabIndex = 9;
            this.buttonRemoteCommands.Text = "Using Remote Commands";
            this.buttonRemoteCommands.UseVisualStyleBackColor = true;
            this.buttonRemoteCommands.Click += new System.EventHandler(this.buttonRemoteCommands_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Version 3.1.1";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(784, 1035);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonRemoteCommands);
            this.Controls.Add(this.buttonTwilio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonEmails);
            this.Controls.Add(this.buttonGmail);
            this.Controls.Add(this.buttonInstallation);
            this.Controls.Add(this.buttonDemo);
            this.Controls.Add(this.label1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(806, 1091);
            this.MinimumSize = new System.Drawing.Size(806, 1091);
            this.Name = "HelpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Vixen Messaging Help";
            this.Load += new System.EventHandler(this.Help_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDemo;
        private System.Windows.Forms.Button buttonInstallation;
        private System.Windows.Forms.Button buttonGmail;
        private System.Windows.Forms.Button buttonEmails;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonTwilio;
        private System.Windows.Forms.Button buttonRemoteCommands;
        private System.Windows.Forms.Label label3;
    }
}