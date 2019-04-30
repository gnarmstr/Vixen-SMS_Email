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
				Cursor.Current = Cursors.WaitCursor;
				if (checkBoxSingleSMS.Checked)
				{
					SendMessageToAllMobiles(textBoxSingleSMS.Text);
					labelBulkStatus.Text = "Messages have been sent.";
				}
				else
				{
					HashSet<string>  mobileNumbers = GetMobilNumber();

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
				Cursor.Current = Cursors.Default;
				return;
			}
			var messageBox1 = new MessageBoxForm("\n\nThere is no text in the message box to be sent, please add text and resend.", @"Empty Message Box",
				MessageBoxButtons.OK, SystemIcons.Information);
			messageBox1.ShowDialog();
		}

		private HashSet<string> GetMobilNumber()
		{
			//Check against your Blacklist
			using (var file = new StreamReader(GlobalVar.PhoneNumberLog))
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
			string accountSid = GlobalVar.TwilioSID;
			string authToken = GlobalVar.TwilioToken;
			var twilio = new TwilioRestClient(accountSid, authToken);
			twilio.SendMessage(GlobalVar.TwilioPhoneNumber, number, textBoxMessage.Text);
		}

		private void checkBoxSingleSMS_CheckedChanged(object sender, EventArgs e)
		{
			textBoxSingleSMS.Visible = label1.Visible = checkBoxSingleSMS.Checked;
		}
	}
}
