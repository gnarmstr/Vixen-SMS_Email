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
	public partial class VixenSettings : Form
	{
		private bool _envokeChanges;
		private bool _envokeChanges1;
		private bool localSaveFlag;
		private bool clearSequences;

		public VixenSettings()
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

		private void VixenSettings_Load(object sender, EventArgs e)
		{
			ok.Image = Tools.GetIcon(Resources.Ok, 40);
			ok.Text = "";
			Cancel.Image = Tools.GetIcon(Resources.Cancel, 40);
			Cancel.Text = "";

			textBoxGroupName.Text = GlobalVar.GroupName;
			textBoxNodeId.Text = GlobalVar.GroupID;
			textBoxVixenFolder.Text = GlobalVar.Vixen3Folder;
			textBoxOutputSequence.Text = GlobalVar.OutputSequenceFolder;
			textBoxVixenServer.Text = GlobalVar.VixenServer;
			textBoxSequenceTemplate.Text = GlobalVar.SequenceTemplate;
			_envokeChanges = false;
			_envokeChanges1 = false;
			clearSequences = false;
			localSaveFlag = false;
			if (GlobalVar.SaveFlag)
				_envokeChanges = true;
		}

		private void Ok_Click(object sender, EventArgs e)
		{
			GlobalVar.GroupName = textBoxGroupName.Text;
			GlobalVar.GroupID = textBoxNodeId.Text;
			GlobalVar.Vixen3Folder = textBoxVixenFolder.Text;
			GlobalVar.OutputSequenceFolder = textBoxOutputSequence.Text;
			GlobalVar.VixenServer = textBoxVixenServer.Text;
			if (clearSequences)
				GlobalVar.VixenSequencesList.Clear();
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

		private void buttonGetVixenData_Click(object sender, EventArgs e)
		{
			string currentProfileFolder = textBoxVixenFolder.Text;
			getSettings();
			if (currentProfileFolder != textBoxVixenFolder.Text)
			{
				var messageBox = new MessageBoxForm(@"Your Vixen profile folder has changed and therefore and loaded Vixen Sequences will be removed from this app. Reload new sequences in Vixen Sequence Settings", @"Information", MessageBoxButtons.OK, SystemIcons.Information);
				messageBox.ShowDialog();
				clearSequences = true;
			}
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

		private void textBox_Changed(object sender, EventArgs e)
		{
			Update_Save_Flag();
		}
	}
}
