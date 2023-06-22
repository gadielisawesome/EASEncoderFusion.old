using System;
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
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ApplicationExit += ProperTermination;
            Application.ThreadException += UnhandledTermination;
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            MessageBox.Show("This program is in pre-release stages and is known to be unstable. Use caution before proceeding. Do not rely on this software during life threatening situations.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
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

            if (MessageBox.Show("Uh oh, something went wrong. (" + e.Exception.HResult + ")\n" + e.Exception.Message + "\n" + e.Exception.StackTrace, "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.None) == DialogResult.OK)
            {

            }
            Application.Exit();
        }
    }
}