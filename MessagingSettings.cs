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
	public partial class MessagingSettings : Form
	{
		private bool _envokeChanges;
		private bool _envokeChanges1;
		private bool localSaveFlag;

		public MessagingSettings()
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
			label11.Font = font;
			label11.ForeColor = Color.Red;
		}

		private void MessagingSettings_Load(object sender, EventArgs e)
		{
			ok.Image = Tools.GetIcon(Resources.Ok, 40);
			ok.Text = "";
			Cancel.Image = Tools.GetIcon(Resources.Cancel, 40);
			Cancel.Text = "";

			checkBoxAutoStart.Checked = GlobalVar.AutoStartMsgRetrieval;
			checkBoxRepeatDisplayMessage.Checked = GlobalVar.RepeatDisplayMessage;
			textBoxReturnBannedMSG.Text = GlobalVar.ReturnBannedMSG;
			textBoxReturnWarningMSG.Text = GlobalVar.ReturnWarningMSG;
			textBoxReturnSuccessMSG.Text = GlobalVar.ReturnSuccessMSG;
			textBoxAdvertisingMSG.Text = GlobalVar.AdvertisingMSG;
			dateCountDown.Value = Convert.ToDateTime(GlobalVar.CountDownDate);
			textBoxCountDownMSG.Text = GlobalVar.CountDownMSG;
			comboBoxBlack_Whitelist.SelectedItem = GlobalVar.Black_WhiteSelection;
			numericUpDownIntervalMsgs.Value = GlobalVar.IntervalMsgs;
			trackBarRandomCountDownSensitivity.Value = GlobalVar.RandomCountDownSensitivity;
			trackBarRandomAdvetisingSensitivity.Value = GlobalVar.RandomAdvertisingSensitivity;
			_envokeChanges = false;
			_envokeChanges1 = false;
			localSaveFlag = false;
			if (GlobalVar.SaveFlag)
				_envokeChanges = true;
		}

		private void Ok_Click(object sender, EventArgs e)
		{
			GlobalVar.AutoStartMsgRetrieval = checkBoxAutoStart.Checked;
			GlobalVar.RepeatDisplayMessage = checkBoxRepeatDisplayMessage.Checked;
			GlobalVar.ReturnBannedMSG = textBoxReturnBannedMSG.Text;
			GlobalVar.ReturnWarningMSG = textBoxReturnWarningMSG.Text;
			GlobalVar.ReturnSuccessMSG = textBoxReturnSuccessMSG.Text;
			GlobalVar.AdvertisingMSG = textBoxAdvertisingMSG.Text;
			GlobalVar.CountDownDate = dateCountDown.Value.ToString();
			GlobalVar.CountDownMSG = textBoxCountDownMSG.Text;
			GlobalVar.Black_WhiteSelection = comboBoxBlack_Whitelist.SelectedItem.ToString();
			GlobalVar.IntervalMsgs = Convert.ToInt16(numericUpDownIntervalMsgs.Value);
			GlobalVar.RandomCountDownSensitivity = trackBarRandomCountDownSensitivity.Value;
			GlobalVar.RandomAdvertisingSensitivity = trackBarRandomAdvetisingSensitivity.Value ;
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

		private void textBoxReturnBannedMSG_TextChanged(object sender, EventArgs e)
		{
			Update_Save_Flag();
		}

		private void numericUpDownIntervalMsgs_ValueChanged(object sender, EventArgs e)
		{
			Update_Save_Flag();
		}

		private void comboBoxBlack_Whitelist_SelectedIndexChanged(object sender, EventArgs e)
		{
			Update_Save_Flag();
		}

		private void checkBoxAutoStart_CheckedChanged(object sender, EventArgs e)
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
