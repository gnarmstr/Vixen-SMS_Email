using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using Vixen_Messaging.Theme;

namespace Vixen_Messaging
{
	public partial class Messages : Form
	{
		private bool _envokeChanges;
		private bool _envokeChanges1;
		private bool localSaveFlag;

		public Messages()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width - 10, ActiveForm.Location.Y);
			_envokeChanges = true;
			_envokeChanges1 = true;
			InitializeComponent();
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			ThemeUpdateControls.UpdateControls(this);
			Font font = new Font(new FontFamily("Times New Roman"), 12.0f);
			label1.Font = font;
			label1.ForeColor = Color.Red;
		}

		private void Messages_Load(object sender, EventArgs e)
		{
			ok.Image = Tools.GetIcon(Resources.Ok, 40);
			ok.Text = "";
			Cancel.Image = Tools.GetIcon(Resources.Cancel, 40);
			Cancel.Text = "";

			textBoxAdvertisingMSG.Text = GlobalVar.AdvertisingMSG;
			textBoxCountDownMSG.Text = GlobalVar.CountDownMSG;
			textBoxMessages.Text = string.Join("\n", GlobalVar.Messages);
			trackBarRandomCountDownSensitivity.Value = GlobalVar.RandomCountDownSensitivity;
			trackBarRandomAdvetisingSensitivity.Value = GlobalVar.RandomAdvertisingSensitivity;
			trackBarRandomMessagesSensitivity.Value = GlobalVar.RandomMessagesSensitivity;
			_envokeChanges = false;
			_envokeChanges1 = false;
			localSaveFlag = false;
			if (GlobalVar.SaveFlag)
				_envokeChanges = true;
		}

		private void Ok_Click(object sender, EventArgs e)
		{
			GlobalVar.AdvertisingMSG = textBoxAdvertisingMSG.Text;
			GlobalVar.CountDownMSG = textBoxCountDownMSG.Text;
			GlobalVar.Messages = textBoxMessages.Text.Split('\n');
			GlobalVar.RandomCountDownSensitivity = trackBarRandomCountDownSensitivity.Value;
			GlobalVar.RandomAdvertisingSensitivity = trackBarRandomAdvetisingSensitivity.Value;
			GlobalVar.RandomMessagesSensitivity = trackBarRandomMessagesSensitivity.Value;
			_envokeChanges = true;
			localSaveFlag = false;
			Close();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			Close_Form();
		}

		private void Close_Form()
		{
			Close();
		}

		private void textBoxMessages_TextChanged(object sender, EventArgs e)
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

		private void MessagingSettings_FormClosing(object sender, FormClosingEventArgs e)
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

		private void trackBarTextPosition_MouseDown(object sender, MouseEventArgs e)
		{
			var trackBar = (TrackBar)sender;
			toolTip1.SetToolTip(trackBar, trackBar.Value.ToString());
		}

		private void trackBarTextPosition_MouseDown(object sender, EventArgs e)
		{
			var trackBar = (TrackBar)sender;
			toolTip1.SetToolTip(trackBar, trackBar.Value.ToString());
		}

		private void trackBarTextPosition_VisibleChanged(object sender, EventArgs e)
		{
			Update_Save_Flag();
		}
	}
}
