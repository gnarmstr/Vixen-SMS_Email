using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using Twilio;
using Vixen_Messaging.Theme;

namespace Vixen_Messaging
{
	public partial class BulkSMS : Form
	{

		public BulkSMS()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width - 10, ActiveForm.Location.Y);
			InitializeComponent();
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			ThemeUpdateControls.UpdateControls(this);
		}

		private void Schedules_Load(object sender, EventArgs e)
		{
			ok.Image = Tools.GetIcon(Resources.Ok, 40);
			ok.Text = "";
			SendMessage.Image = Resources.Send;
			SendMessage.Text = "";
		}

		private void Ok_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void Scheduler_FormClosing(object sender, FormClosingEventArgs e)
		{
		}

		private void SendMessage_Click(object sender, EventArgs e)
		{
			if (textBoxMessage.Text != String.Empty)
			{
				HashSet<string> mobileNumbers = GetMobilNumber();

				var messageBox = new MessageBoxForm("\n\nThere are " + mobileNumbers.Count + " mobile numbers that will be sent the bulk message. Do you want to continue as this will cost money through Twilio?", @"Bulk Messages",
					MessageBoxButtons.YesNo, SystemIcons.Information);

				var bulkMessage = messageBox.ShowDialog();
				switch (bulkMessage)
				{
					case DialogResult.OK:
						int i = 1;
						foreach (var number in mobileNumbers)
						{
							SendMessageToAllMobiles(number);
							labelBulkStatus.Text = i + " of " + mobileNumbers.Count + " messages sent.";
							i++;
						}
						break;
				}
			}
		}

		private HashSet<string> GetMobilNumber()
		{
			//Check against your Blacklist
			using (var file = new StreamReader(GlobalVar.MessageLog))
			{
				HashSet<string> uniqueMobile = new HashSet<string>();

				do
				{
					var textLine = file.ReadLine().Substring(0, 12);

					//only unique mobiule numbers will be added.
					if (uniqueMobile.Contains(textLine)) continue;
					uniqueMobile.Add(textLine);

				} while (file.Peek() != -1);
				file.Close();
				return uniqueMobile;
			}
		}

		private void SendMessageToAllMobiles(string number)
		{
			string accountSid = GlobalVar.TwilioSID; // "AC29390b0fe3f4cb763862eefedb8afc41";
			string authToken = GlobalVar.TwilioToken; // "d68a401090af00f63bbecb4a3e502a7f";
			var twilio = new TwilioRestClient(accountSid, authToken);
			twilio.SendMessage(GlobalVar.TwilioPhoneNumber, number, textBoxMessage.Text);
		}
	}
}
