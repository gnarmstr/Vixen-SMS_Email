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
		public bool _envokeChanges;

		public Twilio()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width - 10, ActiveForm.Location.Y);
			_envokeChanges = true;
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
			if (GlobalVar.SaveFlag)
				_envokeChanges = true;
		}

		private void pictureBoxOk_Click(object sender, EventArgs e)
		{
			GlobalVar.TwilioSID = textBoxSID.Text;
			GlobalVar.TwilioToken = textBoxToken.Text;
			GlobalVar.TwilioPhoneNumber = textBoxPhoneNumber.Text;
			_envokeChanges = true;
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
				GlobalVar.SaveFlag = true;
		}

		private void Twilio_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_envokeChanges)
				GlobalVar.SaveFlag = false;
		}
	}
}
