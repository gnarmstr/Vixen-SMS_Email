using System;
using System.Drawing;
using System.Windows.Forms;
using Common.Resources;
using Common.Resources.Properties;

namespace Vixen_Messaging
{
    public partial class RetrieveVixenSettings : Form
    {
        public RetrieveVixenSettings()
        {
            if (ActiveForm != null)
                Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width, ActiveForm.Location.Y);
            InitializeComponent();
        }

        private void RetrieveVixenSettings_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Tools.GetIcon(Resources.Ok, 40);
            pictureBox1.Text = "";
            pictureBox2.Image = Tools.GetIcon(Resources.Cancel, 40);
            pictureBox2.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close_Form();
        }

        private void Close_Form()
        {
            checkBoxVixenPath.Checked = false;
            checkBoxWebServer.Checked = false;
            checkBoxNodeID.Checked = false;
            textBoxVixenGroupName.Text = "";
            textBoxUID.Text = "";
            textBoxPWD.Text = "";
            textBoxServer.Text = "";
            Close();
        }
    }
}
