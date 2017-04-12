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
	public partial class MSGTextSettings : Form
	{
		private bool _envokeChanges;

		private int _incomingMessageColourOption;

		private string _stringOrientation;

		private string _textDirection;

		private bool _centerText;

		private bool _centerStop;

		private int _textPosition;

		private int _textSpeed;

		private int _intensity;

		private string _font;

		private string _fontSize;

		private decimal _maxWords;

		private string _gradientMode;

		private List<Color> _textColor = new List<Color>(10);

		public MSGTextSettings()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width - 10, ActiveForm.Location.Y);
			InitializeComponent();
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			ThemeUpdateControls.UpdateControls(this, new List<Control>(new[] { TextColor1, TextColor2, TextColor3, TextColor4, TextColor5, TextColor6, TextColor7, TextColor8, TextColor9, TextColor10 }));
		}

		private void MessagingSettings_Load(object sender, EventArgs e)
		{
			ok.Image = Tools.GetIcon(Resources.Ok, 40);
			ok.Text = "";
			Cancel.Image = Tools.GetIcon(Resources.Cancel, 40);
			Cancel.Text = "";
			_envokeChanges = true;
			ColorVisible();

			incomingMessageColourOption.SelectedIndex = _incomingMessageColourOption = GlobalVar.IncomingMessageColourOption;
			comboBoxString.SelectedItem = _stringOrientation = GlobalVar.StringOrientation;
			comboBoxTextDirection.SelectedItem = _textDirection = GlobalVar.TextDirection;
			checkBoxCenterText.Checked = _centerText = GlobalVar.CenterText;
			checkBoxCenterStop.Checked = _centerStop = GlobalVar.CenterStop;
			trackBarTextPosition.Value = _textPosition = GlobalVar.TextPosition;
			trackBarTextSpeed.Value = _textSpeed = GlobalVar.TextSpeed;
			trackBarIntensity.Value = _intensity = GlobalVar.Intensity;
			textBoxFont.Text = _font = GlobalVar.Font;
			textBoxFontSize.Text = _fontSize = GlobalVar.FontSize;
			numericUpDownMaxWords.Value = _maxWords = GlobalVar.MaxWords;
			TextColor1.BackColor = GlobalVar.TextColor[1];
			TextColor2.BackColor = GlobalVar.TextColor[2];
			TextColor3.BackColor = GlobalVar.TextColor[3];
			TextColor4.BackColor = GlobalVar.TextColor[4];
			TextColor5.BackColor = GlobalVar.TextColor[5];
			TextColor6.BackColor = GlobalVar.TextColor[6];
			TextColor7.BackColor = GlobalVar.TextColor[7];
			TextColor8.BackColor = GlobalVar.TextColor[8];
			TextColor9.BackColor = GlobalVar.TextColor[9];
			TextColor10.BackColor = GlobalVar.TextColor[0];
			comboBoxGradientMode.SelectedItem = _gradientMode = GlobalVar.GradientMode;
			comboBoxGradientMode.Visible = GlobalVar.IncomingMessageColourOption == 1;
			_textColor.Add(GlobalVar.TextColor[0]);
			_textColor.Add(GlobalVar.TextColor[1]);
			_textColor.Add(GlobalVar.TextColor[2]);
			_textColor.Add(GlobalVar.TextColor[3]);
			_textColor.Add(GlobalVar.TextColor[4]);
			_textColor.Add(GlobalVar.TextColor[5]);
			_textColor.Add(GlobalVar.TextColor[6]);
			_textColor.Add(GlobalVar.TextColor[7]);
			_textColor.Add(GlobalVar.TextColor[8]);
			_textColor.Add(GlobalVar.TextColor[9]);
			_envokeChanges = false;
			if (GlobalVar.SaveFlag)
				_envokeChanges = true;
		}

		private void Ok_Click(object sender, EventArgs e)
		{
			_envokeChanges = true;
			Close();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			Close_Form();
		}

		private void Close_Form()
		{
			GlobalVar.IncomingMessageColourOption = _incomingMessageColourOption;
			GlobalVar.StringOrientation = _stringOrientation;
			GlobalVar.TextDirection = _textDirection;
			GlobalVar.CenterText = _centerText;
			GlobalVar.CenterStop = _centerStop;
			GlobalVar.TextPosition = _textPosition;
			GlobalVar.TextSpeed = _textSpeed;
			GlobalVar.Intensity = _intensity;
			GlobalVar.Font = _font;
			GlobalVar.FontSize = _fontSize;
			GlobalVar.MaxWords = _maxWords;
			GlobalVar.TextColor = _textColor;
			GlobalVar.GradientMode = _gradientMode;
			Close();
		}

		private void trackBarTextPosition_ToolTip(object sender, EventArgs e)
		{
			var trackBar = (TrackBar)sender;
			toolTip1.SetToolTip(trackBar, trackBar.Value.ToString());
		}

		private void trackBarTextPosition_ToolTip(object sender, MouseEventArgs e)
		{
			var trackBar = (TrackBar)sender;
			toolTip1.SetToolTip(trackBar, trackBar.Value.ToString());
		}

		#region Colour Dialog Box and button colour settings

		private void TextColor_Click(object sender, EventArgs e)
		{
			var btn = (Button)sender;
			colorDialog1.Color = btn.BackColor;
			colorDialog1.ShowDialog();
			btn.BackColor = colorDialog1.Color;
			updateChanges();
		}

		private void ColorVisible()
		{
			var colourVisible = new Label[]
			{
				labelColour1, labelColour2, labelColour3, labelColour4, labelColour5, labelColour6, labelColour7, labelColour8,
				labelColour9, labelColour10
			};
			var i = 0;
			switch (incomingMessageColourOption.Text)
			{
				case "Single":
					RandomColourSelection.Text = @"Single Colour Selection";
					colourVisible[i].Visible = true;
					do
					{
						i++;
						colourVisible[i].Visible = false;
					} while (i < 9);
					break;
				case "Gradient":
					RandomColourSelection.Text = @"Gradient Colour Selection";
					do
					{
						colourVisible[i].Visible = true;
						i++;
					} while (i < 2);
					do
					{
						colourVisible[i].Visible = false;
						i++;
					} while (i < 10);
					break;
				case "Random":
					RandomColourSelection.Text = @"Random Colour Selection";
					do
					{
						colourVisible[i].Visible = true;
						i++;
					} while (i < 10);
					break;
			}
		}

		private void incomingMessageColourOption_SelectedIndexChanged(object sender, EventArgs e)
		{
			ColorVisible();
			comboBoxGradientMode.Visible = incomingMessageColourOption.SelectedIndex == 1;
			updateChanges();
		}

		#endregion

		#region Font Selection
		private void FontSelection()
		{
			fontDialog1.Font = new Font(textBoxFont.Text, (int)Math.Round(double.Parse(textBoxFontSize.Text)));
			if (fontDialog1.ShowDialog() != DialogResult.Cancel)
			{

				textBoxFont.Text = string.Format(fontDialog1.Font.Name);
				textBoxFontSize.Text = string.Format(fontDialog1.Font.Size.ToString());
			}
		}

		private void buttonFont_Click(object sender, EventArgs e)
		{
			FontSelection();
			updateChanges();
		}
		#endregion

		private void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			updateChanges();
		}

		private void updateChanges()
		{
			if (!_envokeChanges)
			{
				GlobalVar.IncomingMessageColourOption = incomingMessageColourOption.SelectedIndex;
				GlobalVar.StringOrientation = comboBoxString.SelectedItem.ToString();
				GlobalVar.TextDirection = comboBoxTextDirection.SelectedItem.ToString();
				GlobalVar.CenterText = checkBoxCenterText.Checked;
				GlobalVar.CenterStop = checkBoxCenterStop.Checked;
				GlobalVar.TextPosition = trackBarTextPosition.Value;
				GlobalVar.TextSpeed = trackBarTextSpeed.Value;
				GlobalVar.Intensity = trackBarIntensity.Value;
				GlobalVar.Font = textBoxFont.Text;
				GlobalVar.FontSize = textBoxFontSize.Text;
				GlobalVar.MaxWords = numericUpDownMaxWords.Value;
				GlobalVar.TextColor[1] = TextColor1.BackColor;
				GlobalVar.TextColor[2] = TextColor2.BackColor;
				GlobalVar.TextColor[3] = TextColor3.BackColor;
				GlobalVar.TextColor[4] = TextColor4.BackColor;
				GlobalVar.TextColor[5] = TextColor5.BackColor;
				GlobalVar.TextColor[6] = TextColor6.BackColor;
				GlobalVar.TextColor[7] = TextColor7.BackColor;
				GlobalVar.TextColor[8] = TextColor8.BackColor;
				GlobalVar.TextColor[9] = TextColor9.BackColor;
				GlobalVar.TextColor[0] = TextColor10.BackColor;
				GlobalVar.GradientMode = comboBoxGradientMode.SelectedItem.ToString();
				GlobalVar.SaveFlag = true;
			}
		}

		

		private void numericUpDownMaxWords_ValueChanged(object sender, EventArgs e)
		{
			updateChanges();
		}

		private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			updateChanges();
		}

		private void trackBarIntensity_MouseLeave(object sender, EventArgs e)
		{
	//		updateChanges();
		}

		private void trackBarIntensity_ValueChanged(object sender, EventArgs e)
		{
			updateChanges();
		}

		private void MSGTextSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!_envokeChanges)
				GlobalVar.SaveFlag = false;
		}
	}
}
