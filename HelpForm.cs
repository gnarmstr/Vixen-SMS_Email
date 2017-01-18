using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Common.Resources.Properties;
using Vixen_Messaging.Theme;

namespace Vixen_Messaging
{
	public partial class HelpForm : Form
	{
		private static HelpForm _helpForm;
		public HelpForm()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width - 10, ActiveForm.Location.Y);
			InitializeComponent();
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			ThemeUpdateControls.UpdateControls(this, new List<Control>(new[] {label2}));
			label2.ForeColor = Color.WhiteSmoke;
			ClientSize = new Size(806, 1091);
		}

		private void Help_Load(object sender, EventArgs e)
		{

		}
		public static HelpForm Instance
		{
			get { return _helpForm ?? (_helpForm = new HelpForm()); }
		}

		private void buttonDemo_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.dropbox.com/s/mkurn960dx6s9so/Vixen%20Messaging%20Demo.mp4?dl=0");
		}

		private void buttonTwilio_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.dropbox.com/s/p8qnogrjqnpga14/Twilio.mp4?dl=0");
		}

		private void buttonLauncher_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://www.dropbox.com/s/28egjk9qmxmo8fd/Control%20Messaging%20From%20Vixen.mp4?dl=0");
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
	}
}
