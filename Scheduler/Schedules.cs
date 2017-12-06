using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using Vixen_Messaging.Theme;

namespace Vixen_Messaging
{
	public partial class Schedules : Form
	{
		private bool _envokeChanges;
		private bool _envokeChanges1;
		private bool localSaveFlag;
		private List<GlobalVar.SchedulerClass> schedules;
		private bool _scheduleChange;

		public Schedules()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width - 10, ActiveForm.Location.Y);
			_envokeChanges = true;
			_envokeChanges1 = true;
			InitializeComponent();
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			dateTimePickerOn.ShowUpDown = true;
			dateTimePickerOff.ShowUpDown = true;
			ThemeUpdateControls.UpdateControls(this);
		}

		private void Schedules_Load(object sender, EventArgs e)
		{
			ok.Image = Tools.GetIcon(Resources.Ok, 40);
			ok.Text = "";
			Cancel.Image = Tools.GetIcon(Resources.Cancel, 40);
			Cancel.Text = "";

			schedules = GlobalVar._schedules;

			comboBoxSchedulerDay.SelectedIndex = 0;
			dateTimePickerOn.Value = schedules[0].Schedule_TimeOn;
			dateTimePickerOff.Value = schedules[0].Schedule_TimeOff;

			_envokeChanges = false;
			_envokeChanges1 = false;
			localSaveFlag = false;
			if (GlobalVar.SaveFlag)
				_envokeChanges = true;
		}

		private void Ok_Click(object sender, EventArgs e)
		{
			GlobalVar._schedules = schedules;
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

		private void Scheduler_FormClosing(object sender, FormClosingEventArgs e)
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

		private void Time_Change(object sender, EventArgs e)
		{
			if (!_scheduleChange)
			{
				_scheduleChange = true;
				schedules[comboBoxSchedulerDay.SelectedIndex].Schedule_TimeOn = dateTimePickerOn.Value;
				schedules[comboBoxSchedulerDay.SelectedIndex].Schedule_TimeOff = dateTimePickerOff.Value;
				Update_Save_Flag();
				_scheduleChange = false;
			}
		}

		private void comboBoxSchedulerDay_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_scheduleChange)
			{
				_scheduleChange = true;
				dateTimePickerOn.Value = schedules[comboBoxSchedulerDay.SelectedIndex].Schedule_TimeOn;
				dateTimePickerOff.Value = schedules[comboBoxSchedulerDay.SelectedIndex].Schedule_TimeOff;
				_scheduleChange = false;
			}
		}
	}
}
