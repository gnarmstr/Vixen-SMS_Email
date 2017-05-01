using System;
using System.Drawing;
using Common.Resources;
using Common.Resources.Properties;
using System.Windows.Forms;
using Vixen_Messaging.Theme;

namespace Vixen_Messaging
{
	public partial class Twilio : Form
	{
		private bool _envokeChanges;
		private bool _envokeChanges1;
		private bool localSaveFlag;

		public Twilio()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width - 10, ActiveForm.Location.Y);
			_envokeChanges = true;
			_envokeChanges1 = true;
			InitializeComponent();
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			ThemeUpdateControls.UpdateControls(this);
		}

		private void Twilio_Load(object sender, EventArgs e)
		{
			pictureBoxOk.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxOk.Text = "";
			pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
			pictureBoxCancel.Text = "";
			textBoxSID.Text = GlobalVar.TwilioSID;
			textBoxToken.Text = GlobalVar.TwilioToken;
			textBoxPhoneNumber.Text = GlobalVar.TwilioPhoneNumber;
			_envokeChanges = false;
			_envokeChanges1 = false;
			localSaveFlag = false;
			if (GlobalVar.SaveFlag)
				_envokeChanges = true;
		}

		private void pictureBoxOk_Click(object sender, EventArgs e)
		{
			GlobalVar.TwilioSID = textBoxSID.Text;
			GlobalVar.TwilioToken = textBoxToken.Text;
			GlobalVar.TwilioPhoneNumber = textBoxPhoneNumber.Text;
			_envokeChanges = true;
			localSaveFlag = false;
			Close();
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void textBoxSID_TextChanged(object sender, EventArgs e)
		{
			Update_Save_Flag();
		}

		private void Update_Save_Flag()
		{
			if (!_envokeChanges)
			{
				GlobalVar.SaveFlag = true;
			}
			if (!_envokeChanges1)
			{
				localSaveFlag = true;
			}
		}

		private void Twilio_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (localSaveFlag && !_envokeChanges1)
			{
				var messageBox = new MessageBoxForm(@"Changes have been made and will be disgarded", @"Warning",
						MessageBoxButtons.OKCancel, SystemIcons.Warning);
				messageBox.ShowDialog();
				if (messageBox.DialogResult == DialogResult.Cancel)
				{
					e.Cancel = true;
				}
			}
			if (!_envokeChanges && !e.Cancel)
				GlobalVar.SaveFlag = false;
		}
	}
}
