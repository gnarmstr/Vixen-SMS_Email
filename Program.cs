using System;
using System.Threading;
using System.Windows.Forms;

namespace Vixen_Messaging
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                bool result;
                var mutex = new Mutex(true, "VixenMessagingRunningInstance", out result);

                if (!result)
                {
                    MessageBox.Show("Another instance of Vixen Messaging is already running; this instance will be closed.",
                                    "Vixen Messaging already open", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var mutex1 = new Mutex(true, "Vixen3RunningInstance", out result);
                if (result)
                {
                    MessageBox.Show("Vixen 3 is Not currently running and must be open when Messages are being retrieved.",
                                    "Vixen 3 not running", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());

                // mutex shouldn't be released - important line
                GC.KeepAlive(mutex);
            }
            catch (Exception)
            {
                Environment.Exit(1);
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            var e = (Exception)args.ExceptionObject;
            Environment.Exit(1);
        }
    }
}
