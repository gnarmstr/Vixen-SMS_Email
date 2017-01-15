using System;
using System.Collections.Generic;
using System.Drawing;
using Common.Resources;
using Common.Resources.Properties;
using System.Windows.Forms;
using Vixen_Messaging.Theme;

namespace Vixen_Messaging
{
	public partial class InstantMSG : Form
	{

		public InstantMSG()
		{
			if (ActiveForm != null)
				Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width, ActiveForm.Location.Y);
			InitializeComponent();
			ForeColor = ThemeColorTable.ForeColor;
			BackColor = ThemeColorTable.BackgroundColor;
			ThemeUpdateControls.UpdateControls(this, new List<Control>(new[] { label3 }));
			label3.ForeColor = Color.WhiteSmoke;
		}

		private void Twilio_Load(object sender, EventArgs e)
		{
			pictureBoxOk.Image = Tools.GetIcon(Resources.Ok, 40);
			pictureBoxOk.Text = "";
			GlobalVar.CloseInstantMSGForm = true;
		}

		private void pictureBoxOk_Click(object sender, EventArgs e)
		{
			GlobalVar.InstantMSG = textBoxInstantMSG.Text;
			GlobalVar.CloseInstantMSGForm = false;
			Close();
		}

		private void textBoxInstantMSG_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				GlobalVar.InstantMSG = textBoxInstantMSG.Text;
				GlobalVar.CloseInstantMSGForm = false;
				Close();
			}
		}
	}
}
