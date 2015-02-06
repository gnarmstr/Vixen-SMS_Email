using System;
using System.Drawing;
using Common.Resources;
using Common.Resources.Properties;
using System.Windows.Forms;

namespace Vixen_Messaging
{
    public partial class FormMessages : Form
    {
        public FormMessages()
        {
            if (ActiveForm != null)Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width, ActiveForm.Location.Y);
            InitializeComponent();
            ClientSize = new Size(531, 453);
        }

	    private void FormMessages_Load(object sender, EventArgs e)
	    {
		    pictureBox1.Image = Tools.GetIcon(Resources.Ok, 40);
		    pictureBox1.Text = "";
		    pictureBox2.Image = Tools.GetIcon(Resources.Cancel, 40);
		    pictureBox2.Text = "";
		    for (int i = 0; i < GlobalVar.GroupNameID.Count; i++)
		    {
			    customMessageNodeSel.Items.Add(GlobalVar.GroupNameID[i]);
		    }
		    if (customMessageNodeSel.Items.Count > 0)
			{
			    customMessageNodeSel.SelectedIndex = 0;
			}
			messageColourOption.SelectedIndex = 1;
			customMessageSeqSel.SelectedIndex = 0;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" & (textBoxLine1.Text != "" | textBoxLine2.Text != "" | textBoxLine3.Text != "" | textBoxLine4.Text != "" | trackBarCountDownPosition.Value != 65))
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

        private void trackBarCountDownPosition_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarCountDownPosition, trackBarCountDownPosition.Value.ToString());
        }

        private void trackBarCountDownPosition_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarCountDownPosition, trackBarCountDownPosition.Value.ToString());
        }

        private void trackBarCountDownPosition_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarCountDownPosition, trackBarCountDownPosition.Value.ToString());
        }

        private void buttonCustomFont_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                textBoxCustomFont.Text = string.Format(fontDialog1.Font.Name);
                textBoxCustomFontSize.Text = string.Format(fontDialog1.Font.Size.ToString());
            }
        }

        private void trackBarCustomSpeed_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarCustomSpeed, trackBarCustomSpeed.Value.ToString());
        }

        private void trackBarCustomSpeed_Scroll(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(trackBarCustomSpeed, trackBarCustomSpeed.Value.ToString());
        }

        private void trackBarCustomSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            toolTip1.SetToolTip(trackBarCustomSpeed, trackBarCustomSpeed.Value.ToString());
		}
    }
}
