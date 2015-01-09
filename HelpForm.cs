using System;
using System.Windows.Forms;

namespace Vixen_Messaging
{
    public partial class HelpForm : Form
    {
        private static HelpForm _helpForm;
        public HelpForm()
        {
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
