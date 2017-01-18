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
		public MessagingSettings()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width - 10, ActiveForm.Location.Y);
			InitializeComponent();
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			ThemeUpdateControls.UpdateControls(this);
		}

		private void MessagingSettings_Load(object sender, EventArgs e)
		{
			ok.Image = Tools.GetIcon(Resources.Ok, 40);
			ok.Text = "";
			Cancel.Image = Tools.GetIcon(Resources.Cancel, 40);
			Cancel.Text = "";

			checkBoxAutoStart.Checked = GlobalVar.AutoStartMsgRetrieval;
			textBoxReturnBannedMSG.Text = GlobalVar.ReturnBannedMSG;
			textBoxReturnWarningMSG.Text = GlobalVar.ReturnWarningMSG;
			textBoxReturnSuccessMSG.Text = GlobalVar.ReturnSuccessMSG;
			textBoxGroupName.Text = GlobalVar.GroupName;
			textBoxNodeId.Text = GlobalVar.GroupID;
			textBoxVixenFolder.Text = GlobalVar.Vixen3Folder;
			textBoxOutputSequence.Text = GlobalVar.OutputSequenceFolder;
			textBoxVixenServer.Text = GlobalVar.VixenServer;
			textBoxSequenceTemplate.Text = GlobalVar.SequenceTemplate;
			textBoxLogFileName.Text = GlobalVar.MessageLog;
			textBoxBlacklistEmailLog.Text = GlobalVar.BlacklistLog;
			dateCountDown.Value = Convert.ToDateTime(GlobalVar.CountDownDate);
			textBoxCountDownMSG.Text = GlobalVar.CountDownMSG;
			comboBoxBlack_Whitelist.SelectedItem = GlobalVar.Black_WhiteSelection;
			numericUpDownIntervalMsgs.Value = GlobalVar.IntervalMsgs;
		}

		private void Ok_Click(object sender, EventArgs e)
		{
			GlobalVar.AutoStartMsgRetrieval = checkBoxAutoStart.Checked;
			GlobalVar.ReturnBannedMSG = textBoxReturnBannedMSG.Text;
			GlobalVar.ReturnWarningMSG = textBoxReturnWarningMSG.Text;
			GlobalVar.ReturnSuccessMSG = textBoxReturnSuccessMSG.Text;
			GlobalVar.GroupName = textBoxGroupName.Text;
			GlobalVar.GroupID = textBoxNodeId.Text;
			GlobalVar.Vixen3Folder = textBoxVixenFolder.Text;
			GlobalVar.OutputSequenceFolder = textBoxOutputSequence.Text;
			GlobalVar.VixenServer = textBoxVixenServer.Text;
			GlobalVar.CountDownDate = dateCountDown.Value.ToString();
			GlobalVar.CountDownMSG = textBoxCountDownMSG.Text;
			GlobalVar.Black_WhiteSelection = comboBoxBlack_Whitelist.SelectedItem.ToString();
			GlobalVar.IntervalMsgs = Convert.ToInt16(numericUpDownIntervalMsgs.Value);
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

		private void buttonGetVixenData_Click(object sender, EventArgs e)
		{
			getSettings();
		}

		public void getSettings()
		{
			if (textBoxGroupName.Text != "")
			{
				//Gets Vixen Folder location, NodeId, output folder and Server settings.
				var messageBox = new MessageBoxForm(@"Select your Vixen 3 folder. Normally located in your Documents Folder.", @"Locate Vixen Folder", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
				folderBrowserDialog1 = new FolderBrowserDialog
				{
					SelectedPath =
						Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents\\Vixen 3\\")
				};

				// Process input if the user clicked OK.
				if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
				{
					textBoxVixenFolder.Text = folderBrowserDialog1.SelectedPath;
					textBoxOutputSequence.Text = textBoxVixenFolder.Text + "\\Sequence\\VixenOut.tim";
				}
				GetServerSettings();
				GetNodeId(textBoxGroupName.Text);
			}
			else
			{
				var messageBox = new MessageBoxForm(@"Enter your group name for your matrix/megatree into the Group Node ID text box", @"Error", MessageBoxButtons.OK, SystemIcons.Error);
				messageBox.ShowDialog();
			}
		}

		#region Get Vixen Server Settings
		private void GetServerSettings()
		{
			var portResult = "";
			try
			{
				var fullFile = File.ReadAllLines(textBoxVixenFolder.Text + "\\SystemData\\ModuleStore.xml");
				var l = new List<string>();
				l.AddRange(fullFile);
				var i = 0;
				do
				{

					if (fullFile[i].Contains("<HttpPort>"))
					{
						portResult = fullFile[i];
					}
					i++;
				} while (i != l.Count);
			}
			// ReSharper disable once EmptyGeneralCatchClause
			catch
			{
			}

			if (portResult == "")
			{
				var messageBox = new MessageBoxForm(@"Unable to find Web Server settings, please ensure you have retrived the correct Vixen 3 Folder path", @"WARNING", MessageBoxButtons.OK, SystemIcons.Warning);
				messageBox.ShowDialog();
			}
			else
			{
				portResult = portResult.Replace("<HttpPort>", "");
				portResult = portResult.Replace("</HttpPort>", "");
				portResult = portResult.Replace(" ", "");
				textBoxVixenServer.Text = @"http://localhost:" + portResult + @"/api/play/playSequence";
			}
		}
		#endregion

		#region Get Nod ID
		private void GetNodeId(string addGroupName)
		{
			var nodeResult = "";

			try
			{
				//Used to find the NodeId of the Nutcracker effect.
				var reading = File.OpenText((textBoxVixenFolder.Text + "\\SystemData\\SystemConfig.xml"));
				string str;
				while ((str = reading.ReadLine()) != null)
				{
					if (str.Contains("<Node name=\"" + addGroupName + "\" id=\""))
					{
						nodeResult = str;
					}
				}

				nodeResult = nodeResult.Replace("<Node name=\"" + addGroupName + "\" id=\"", "");
				nodeResult = nodeResult.Trim(new Char[] { '\"', '>', ' ' });
				reading.Close();

				if (nodeResult == "")
				{
					var messageBox = new MessageBoxForm(@"Unable to find NodeId for your Group, please ensure you have entered the correct Group Name above and it is case sensitive", @"WARNING", MessageBoxButtons.OK, SystemIcons.Warning);
					messageBox.ShowDialog(); 
					GlobalVar.NoNodeID = true;
				}
				else
				{
					textBoxNodeId.Text = nodeResult;
					GlobalVar.NoNodeID = false;
				}
			}
			// ReSharper disable once EmptyGeneralCatchClause
			catch
			{
			}
		}
		#endregion

		#region Reset Vixen Messaging Setting to Default
		private void buttonResetToDefault_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(@"Are you sure you would like to revert all settings back to the default, this will include all settings on the Sequencing Tab too.", @"Reset Vixen Messaging setting to Default", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				File.Delete(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Vixen Messaging", "Settings.xml"));
			//	LoadData();
			}
		}
		#endregion

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
	}
}
