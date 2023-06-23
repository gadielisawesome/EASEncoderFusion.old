using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Thread thread;
            thread = Thread.CurrentThread;

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ApplicationExit += ProperTermination;
            Application.ThreadException += UnhandledTermination;
            if (Properties.Settings.Default.Use95Design) Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            else Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //if (!Properties.Settings.Default.IsActivated)
            //{
            //    if (new ActivateForm().ShowDialog() == DialogResult.Yes)
            //    {
            //        Process.Start(Application.ExecutablePath);
            //        return;
            //    }
            //    else return;
            //}
            //else
            {
                MessageBox.Show("This program is in pre-release stages and is known to be unstable. Use caution before proceeding. Do not rely on this software for life threatening situations.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Run(new MainForm());
            }
        }

        internal static void ProperTermination(object sender, EventArgs e)
        {
            
        }

        internal static void UnhandledTermination(object sender, ThreadExceptionEventArgs e)
        {
            //Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            //foreach (Form form in Application.OpenForms)
            //{
            //    form.Dispose();
            //}

            if (System.Windows.Forms.MessageBox.Show("Uh oh, something went wrong. (" + e.Exception.HResult + ")\n" + e.Exception.Message + "\n" + e.Exception.StackTrace + "\nIt may be possible to continue normally.\n\nClick OK to resume activites.\nClick CANCEL to close the application.", "EASEncoder Fusion", MessageBoxButtons.OKCancel, MessageBoxIcon.None) == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }
    }

    public static class MessageBox
    {
        public static DialogResult Show(string text = "", string title = "EASEncoder Fusion", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            if (Properties.Settings.Default.SilenceErrors) return System.Windows.Forms.MessageBox.Show(text, title, buttons);
            else return System.Windows.Forms.MessageBox.Show(text, title, buttons, icon);
        }
    }
}