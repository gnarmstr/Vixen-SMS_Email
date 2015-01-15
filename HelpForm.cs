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
        }

        private void Help_Load(object sender, EventArgs e)
        {

        }
        public static HelpForm Instance
        {
            get { return _helpForm ?? (_helpForm = new HelpForm()); }
        }

    }
}
