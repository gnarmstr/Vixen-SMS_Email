using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Resources;
using Common.Resources.Properties;
using System.Windows.Forms;

namespace Vixen_Messaging
{
    public partial class Twilio : Form
    {

        public Twilio()
        {
            if (ActiveForm != null)
                Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width, ActiveForm.Location.Y);
            InitializeComponent();
        }

        private void Twilio_Load(object sender, EventArgs e)
        {
            pictureBoxOk.Image = Tools.GetIcon(Resources.Ok, 40);
            pictureBoxOk.Text = "";
            pictureBoxCancel.Image = Tools.GetIcon(Resources.Cancel, 40);
            pictureBoxCancel.Text = "";
            textBoxSID.Text = GlobalVar.TwilioSID;
            textBoxToken.Text = GlobalVar.TwilioToken;
            pictureBoxOk.Text = "";
        }

        private void pictureBoxOk_Click(object sender, EventArgs e)
        {
            GlobalVar.TwilioSID = textBoxSID.Text;
            GlobalVar.TwilioToken = textBoxToken.Text;
            Close();
        }

        private void pictureBoxCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
