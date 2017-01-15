namespace Vixen_Messaging
{
	partial class MessageBoxForm
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
			this.messageIcon = new System.Windows.Forms.PictureBox();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonNo = new System.Windows.Forms.Button();
			this.buttonOk = new System.Windows.Forms.Button();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.txtMessage = new System.Windows.Forms.RichTextBox();
			((System.ComponentModel.ISupportInitialize)(this.messageIcon)).BeginInit();
			this.flowLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// messageIcon
			// 
			this.messageIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.messageIcon.Location = new System.Drawing.Point(2, 3);
			this.messageIcon.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
			this.messageIcon.Name = "messageIcon";
			this.messageIcon.Size = new System.Drawing.Size(108, 98);
			this.messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.messageIcon.TabIndex = 5;
			this.messageIcon.TabStop = false;
			this.messageIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.messageIcon_Paint);
			// 
			// buttonCancel
			// 
			this.buttonCancel.AutoSize = true;
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.buttonCancel.Location = new System.Drawing.Point(213, 4);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(99, 39);
			this.buttonCancel.TabIndex = 3;
			this.buttonCancel.Text = "CANCEL";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Visible = false;
			this.buttonCancel.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonCancel.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// buttonNo
			// 
			this.buttonNo.AutoSize = true;
			this.buttonNo.DialogResult = System.Windows.Forms.DialogResult.No;
			this.buttonNo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonNo.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.buttonNo.Location = new System.Drawing.Point(108, 4);
			this.buttonNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonNo.Name = "buttonNo";
			this.buttonNo.Size = new System.Drawing.Size(99, 39);
			this.buttonNo.TabIndex = 4;
			this.buttonNo.Text = "NO";
			this.buttonNo.UseVisualStyleBackColor = true;
			this.buttonNo.Visible = false;
			this.buttonNo.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonNo.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// buttonOk
			// 
			this.buttonOk.AutoSize = true;
			this.buttonOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
			this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOk.ForeColor = System.Drawing.SystemColors.ControlText;
			this.buttonOk.Location = new System.Drawing.Point(3, 4);
			this.buttonOk.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.buttonOk.Name = "buttonOk";
			this.buttonOk.Size = new System.Drawing.Size(99, 39);
			this.buttonOk.TabIndex = 2;
			this.buttonOk.Text = "OK";
			this.buttonOk.UseVisualStyleBackColor = false;
			this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
			this.buttonOk.MouseLeave += new System.EventHandler(this.buttonBackground_MouseLeave);
			this.buttonOk.MouseHover += new System.EventHandler(this.buttonBackground_MouseHover);
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.flowLayoutPanel1.AutoSize = true;
			this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.SetColumnSpan(this.flowLayoutPanel1, 2);
			this.flowLayoutPanel1.Controls.Add(this.buttonCancel);
			this.flowLayoutPanel1.Controls.Add(this.buttonNo);
			this.flowLayoutPanel1.Controls.Add(this.buttonOk);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(132, 108);
			this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(315, 47);
			this.flowLayoutPanel1.TabIndex = 7;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
			this.tableLayoutPanel1.Controls.Add(this.messageIcon, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.txtMessage, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 163);
			this.tableLayoutPanel1.TabIndex = 9;
			// 
			// txtMessage
			// 
			this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
			this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtMessage.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.txtMessage.Location = new System.Drawing.Point(114, 7);
			this.txtMessage.Margin = new System.Windows.Forms.Padding(2, 7, 6, 1);
			this.txtMessage.Name = "txtMessage";
			this.txtMessage.ReadOnly = true;
			this.txtMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.txtMessage.Size = new System.Drawing.Size(330, 94);
			this.txtMessage.TabIndex = 8;
			this.txtMessage.Text = "";
			// 
			// MessageBoxForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(450, 163);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "MessageBoxForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "MessageBoxForm";
			((System.ComponentModel.ISupportInitialize)(this.messageIcon)).EndInit();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox messageIcon;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonNo;
		private System.Windows.Forms.Button buttonOk;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.RichTextBox txtMessage;
	}
}