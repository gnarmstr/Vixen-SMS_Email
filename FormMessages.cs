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
    public partial class FormMessages : Form
    {
        public FormMessages()
        {
            if (ActiveForm != null)
                Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width, ActiveForm.Location.Y);
            InitializeComponent();
            ClientSize = new Size(531, 453);
        }

        private void FormMessages_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Tools.GetIcon(Resources.Ok, 40);
            pictureBox1.Text = "";
            pictureBox2.Image = Tools.GetIcon(Resources.Cancel, 40);
            pictureBox2.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" & (textBoxLine1.Text != "" | textBoxLine2.Text != "" | textBoxLine3.Text != "" | textBoxLine4.Text != "" | trackBarCountDownPosition.Value != 10))
            {
                MessageBox.Show(@"Please enter a Name before selecting Ok or select Cancel");
            }
            else
            {
                Close();
            }
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
