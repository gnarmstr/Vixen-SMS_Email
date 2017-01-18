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

		public Twilio()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width - 10, ActiveForm.Location.Y);
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
		}

		private void pictureBoxOk_Click(object sender, EventArgs e)
		{
			GlobalVar.TwilioSID = textBoxSID.Text;
			GlobalVar.TwilioToken = textBoxToken.Text;
			GlobalVar.TwilioPhoneNumber = textBoxPhoneNumber.Text;
			Close();
		}

		private void pictureBoxCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
