using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common.Resources.Properties;
using Vixen_Messaging.Theme;

namespace Vixen_Messaging
{
	public partial class MessageBoxForm : Form
	{
		//This whole thing needs rewritten. It needs to act like the real messagebox.
		public static Icon msgIcon;

		//public MessageBoxForm(string messageBoxData, string messageBoxTitle, bool buttonNoVisible, bool buttonCancelVisible)
		//{
		//	InitializeComponent();
		//	InitMessageBox(messageBoxData, messageBoxTitle);
		//	buttonNo.Visible = buttonNoVisible;
		//	buttonCancel.Visible = buttonCancelVisible;
		//	if (!buttonCancelVisible & !buttonNoVisible)
		//	{
		//		buttonOk.Location = buttonCancel.Location;
		//	}
		//	else
		//	{
		//		buttonOk.Text = "YES";
		//	}
		//}

		/// <summary>
		/// Create a messagebox with the specific buttons. This is a temporary addition until this can be rewritten.
		/// </summary>
		/// <param name="messageBoxData"></param>
		/// <param name="messageBoxTitle"></param>
		/// <param name="buttons"></param>
		/// <param name="icon"></param>
		public MessageBoxForm(string messageBoxData, string messageBoxTitle, MessageBoxButtons buttons, Icon icon)
		{
			if (icon != null)
			{
				msgIcon = icon;
			}
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X, ActiveForm.Location.Y + 100);
			InitializeComponent();
			InitMessageBox(messageBoxData, messageBoxTitle);

			if (buttons == MessageBoxButtons.OKCancel)
			{
				buttonOk.Location = buttonNo.Location;
				buttonCancel.Visible = true;
			}
			else if (buttons == MessageBoxButtons.YesNo)
			{
				buttonCancel.Visible = false;
				buttonOk.Text = @"YES";
				buttonNo.Visible = true;
			}
			else if (buttons == MessageBoxButtons.YesNoCancel)
			{
				buttonCancel.Visible = true;
				buttonOk.Visible = true;
				buttonNo.Visible = true;
				buttonOk.Text = @"YES";
			}

		}

		private void InitMessageBox(string messageBoxData, string messageBoxTitle)
		{
			Height = 0;
			txtMessage.AutoSize = true;
			messageIcon.AutoSize = true;
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			ThemeUpdateControls.UpdateControls(this, new List<Control>(new[] { txtMessage }));
			txtMessage.BackColor = ThemeColorTable.BackgroundColor; //override theme as we are using this as a label.
			txtMessage.ForeColor = ThemeColorTable.ForeColor;
			txtMessage.Text = messageBoxData;
			Text = messageBoxTitle;
			AdjustHeight();
		}

		private void buttonBackground_MouseHover(object sender, EventArgs e)
		{
			var btn = (Button)sender;
			btn.BackgroundImage = Resources.ButtonBackgroundImageHover;
		}

		private void buttonBackground_MouseLeave(object sender, EventArgs e)
		{
			var btn = (Button)sender;
			btn.BackgroundImage = Resources.ButtonBackgroundImage;

		}

		private void messageIcon_Paint(object sender, PaintEventArgs e)
		{
			if (msgIcon != null)
				e.Graphics.DrawIcon(msgIcon, 24, 24);
		}

		private void MessageBoxForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			msgIcon = null;
		}

		private void buttonOk_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void AdjustHeight()
		{
			// amount of padding to add
			const int padding = 3;
			// get number of lines (first line is 0, so add 1)
			int numLines = txtMessage.GetLineFromCharIndex(txtMessage.TextLength) + 1;
			// get border thickness
			int border = txtMessage.Height - txtMessage.ClientSize.Height;
			// set height (height of one line * number of lines + spacing)
			txtMessage.Height = txtMessage.Font.Height * numLines + padding + border;
		}
	}
}
