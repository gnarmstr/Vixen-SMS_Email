using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;
using Vixen_Messaging.Theme;

namespace Vixen_Messaging
{
	public partial class VixenSequenceSettings : Form
	{
		public bool _envokeChanges;

		public VixenSequenceSettings()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width - 10, ActiveForm.Location.Y);
			_envokeChanges = true;
			InitializeComponent();
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			ThemeUpdateControls.UpdateControls(this);
			contextMenuStrip1.Renderer = new ThemeToolStripRenderer();
			Font font = new Font(new FontFamily("Times New Roman"), 12.0f);
			label1.Font = font;
			label1.ForeColor = Color.Red;
			label1.BackColor = ThemeColorTable.ForeColor;
		}

		private void VixenSequenceSettings_Load(object sender, EventArgs e)
		{
			ok.Image = Tools.GetIcon(Resources.Ok, 40);
			ok.Text = "";
			Cancel.Image = Tools.GetIcon(Resources.Cancel, 40);
			Cancel.Text = "";

			if (GlobalVar.VixenSequencesList != null)
			{
				foreach (string vixenSequence in GlobalVar.VixenSequencesList)
				{
					listBoxSequences.Items.Add(vixenSequence);
				}
			}
			checkBoxSequences.Checked = GlobalVar.VixenSequences;
			trackBarRandomVixenSequenceSensitivity.Value = GlobalVar.RandomSequenceSensitivity;

			_envokeChanges = false;
			if (GlobalVar.SaveFlag)
				_envokeChanges = true;
		}

		private void Ok_Click(object sender, EventArgs e)
		{
			GlobalVar.VixenSequencesList = listBoxSequences.Items.Cast<String>().ToList();
			GlobalVar.VixenSequences = checkBoxSequences.Checked;
			GlobalVar.RandomSequenceSensitivity = trackBarRandomVixenSequenceSensitivity.Value;
			_envokeChanges = true;
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
				GlobalVar.SaveFlag = true;
		}

		private void MessagingSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_envokeChanges)
				GlobalVar.SaveFlag = false;
		}

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

		private void buttonLoadSequences_Click(object sender, EventArgs e)
		{
		//	Used to find the NodeId of the Nutcracker effect.
			var openFileDialog1 = new OpenFileDialog
			{
				Multiselect = true,
				Filter = @"Vixen Sequence Files (.tim)|*.tim",
				InitialDirectory = GlobalVar.Vixen3Folder + "\\Sequence\\"
			};

			// Set filter options and filter index.

			// Process input if the user clicked OK.
			if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
			{
				foreach (var fileName in openFileDialog1.SafeFileNames)
				{
					listBoxSequences.Items.Add(fileName);
				}
				Update_Save_Flag();
			}
		}

		private void toolStripMenuItem1_Click(object sender, EventArgs e)
		{
			RemoveSequencers();
		}

		private void RemoveSequencers()
		{
			for (int x = listBoxSequences.SelectedIndices.Count - 1; x >= 0; x--)
			{
				int selectedItem = listBoxSequences.SelectedIndices[x];
				listBoxSequences.Items.RemoveAt(selectedItem);
			}
			Update_Save_Flag();
		}

		private void listBoxSequences_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Delete && listBoxSequences.SelectedItems.Count > 0)
				RemoveSequencers();
		}

		private void checkBoxSequences_CheckedChanged(object sender, EventArgs e)
		{
			Update_Save_Flag();
		}

		private void trackBarRandomVixenSequenceSensitivity_VisibleChanged(object sender, EventArgs e)
		{
			var trackBar = (TrackBar)sender;
			toolTip1.SetToolTip(trackBar, trackBar.Value.ToString());
		}

		private void trackBarRandomVixenSequenceSensitivity_MouseDown(object sender, MouseEventArgs e)
		{
			var trackBar = (TrackBar)sender;
			toolTip1.SetToolTip(trackBar, trackBar.Value.ToString());
		}

		private void trackBarRandomVixenSequenceSensitivity_MouseDown(object sender, EventArgs e)
		{
			var trackBar = (TrackBar)sender;
			toolTip1.SetToolTip(trackBar, trackBar.Value.ToString());
		}

		private void trackBarRandomVixenSequenceSensitivity_ValueChanged(object sender, EventArgs e)
		{
			Update_Save_Flag();
		}
	}
}
