using System;
using System.Drawing;
using System.Windows.Forms;

namespace Vixen_Messaging
{
    public partial class HelpForm : Form
    {
        private static HelpForm _helpForm;
        public HelpForm()
        {
            if (ActiveForm != null)
                Location = new Point(ActiveForm.Location.X + ActiveForm.MaximumSize.Width, ActiveForm.Location.Y);
            InitializeComponent();
            ClientSize = new Size(784, 1091);
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
            System.Diagnostics.Process.Start("https://www.dropbox.com/s/eu40qx69z4a9nui/Vixen%20Messaging%20Demo%20Pt1.mp4?dl=0");
        }

        private void buttonInstallation_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.dropbox.com/s/uo8djes3gvtydj9/Vixen%20Messaging%20Installation%20Pt2.mp4?dl=0");
        }

        private void buttonGmail_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.dropbox.com/s/4nype5jnza7h7sa/Vixen%20Messaging%20Setting%20up%20email%20with%20a%20GMail%20account%20Pt3.mp4?dl=0");
        }

        private void buttonEmails_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.dropbox.com/s/bd4qu96kk0gwsv3/Vixen%20Messaging%20Retrieving%20Emails%20Pt4.mp4?dl=0");
        }

        private void buttonTwilio_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.dropbox.com/s/z0suapf42d7pv3p/Vixen%20Messaging%20Setting%20up%20email%20with%20a%20Twilio%20account%20Pt5.mp4?dl=0");
        }

        private void buttonRemoteCommands_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.dropbox.com/s/6ovb84iay123t8i/Vixen%20Messaging%20Remote%20Access%20Commands%20Pt6.mp4?dl=0");
        }

        private void buttonLauncher_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.dropbox.com/s/2cidc5wqklz151u/Vixen%20Messaging%20Auto%20Launcher%20Pt7.mp4?dl=0");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
