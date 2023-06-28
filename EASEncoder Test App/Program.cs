using EASEncoder_UI.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
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
            int MajorVersion = 0;
            int MinorVersion = 1;
            int Revision = 3;
            string FusionVersion = "v" + MajorVersion.ToString() + "." + MinorVersion.ToString() + "." + Revision.ToString();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ApplicationExit += ProperTermination;
            Application.ThreadException += UnhandledTermination;
            Settings.Default.SettingsSaving += SavingContents;

            if (Settings.Default.Use95Design) Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            else Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(Settings.Default.LegacyFont);
            if (!File.Exists("EASEncoderFusion.dll"))
            {
                MessageBox.Show("It appears that you either forgot to extract the *.zip file first, or you have deleted 'EASEncoderFusion.dll'. Please re-download the program.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists("NAudio.dll"))
            {
                MessageBox.Show("It appears that you either forgot to extract the *.zip file first, or you have deleted 'EASEncoderFusion.dll'. Please re-download the program.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            {
                //MessageBox.Show("This program is in pre-release stages and is known to be unstable. Use caution before proceeding. Do not rely on this software for life threatening situations.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (Screen.PrimaryScreen.Bounds.Width < 1280 || Screen.PrimaryScreen.Bounds.Height < 720)
                {
                    MessageBox.Show("The resolution on this display is lower than the recommended resolution of 1600x900. Some elements may not fit on the screen.");
                    Settings.Default.LowRes = true;
                    Settings.Default.Save();
                }
                //ThreadStart extUI = new ThreadStart(ExternalUI);
                //Thread extUIthread = new Thread(extUI);
                //extUIthread.SetApartmentState(ApartmentState.STA);
                //extUIthread.Start();
                Application.Run(new MainForm { Tag = FusionVersion });
                //Application.Run(new MainFormLowRes());
            }
        }

        //private static void ExternalUI()
        //{
        //    Application.Run(new MainFormLowRes());
        //}

        private static void SavingContents(object sender, CancelEventArgs e)
        {
            
        }

        //static string GetDownloadUrl(string releaseUrl)
        //{
        //    using (var client = new WebClient())
        //    {
        //        try
        //        {
        //            string htmlContent = client.DownloadString(releaseUrl);
        //            int assetIndex = htmlContent.IndexOf("browser_download_url");

        //            if (assetIndex != -1)
        //            {
        //                int downloadUrlStartIndex = htmlContent.IndexOf('"', assetIndex) + 1;
        //                int downloadUrlEndIndex = htmlContent.IndexOf('"', downloadUrlStartIndex);

        //                return htmlContent.Substring(downloadUrlStartIndex, downloadUrlEndIndex - downloadUrlStartIndex);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error fetching release information. " + ex.Message);
        //        }
        //    }

        //    return null;
        //}

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