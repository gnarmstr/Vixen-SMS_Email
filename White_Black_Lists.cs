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
	public partial class White_Black_Lists : Form
	{
		public White_Black_Lists()
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

			richTextBoxBlacklist.Text = GlobalVar.Blacklist;
			richTextBoxWhitelist.Text = GlobalVar.Whitelist;
		}

		private void Ok_Click(object sender, EventArgs e)
		{
			SaveBlackList();
			SaveWhiteList();
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

		private void SaveBlackList()
		{
			richTextBoxBlacklist.SaveFile(GlobalVar.Blacklistlocation, RichTextBoxStreamType.PlainText);
			richTextBoxBlacklist.SaveFile(GlobalVar.Blacklistlocation + ".bkp", RichTextBoxStreamType.PlainText);
			GlobalVar.Blacklist = richTextBoxBlacklist.Text;
		}

		private void SaveWhiteList()
		{
			richTextBoxWhitelist.SaveFile(GlobalVar.Whitelistlocation, RichTextBoxStreamType.PlainText);
			richTextBoxWhitelist.SaveFile(GlobalVar.Whitelistlocation + ".bkp", RichTextBoxStreamType.PlainText);
			GlobalVar.Whitelist = richTextBoxWhitelist.Text;
		}

		private void buttonDefaultLists_Click(object sender, EventArgs e)
		{

			richTextBoxBlacklist.Text = Resources.Blacklist;
			richTextBoxWhitelist.Text = Resources.Whitelist;
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
