using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo psInfo = new ProcessStartInfo
            //{
            //    FileName = "https://discord.gg/2mfsz5bCnk",
            //    UseShellExecute = true
            //};
            //Process.Start(psInfo);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("'Output errors and warnings quietly'\nThis will silence any errors and warnings that may occur while using the app.\n\n'Use Windows 95/98 design'\nThis can improve visual performance on older systems.\n\n'Wait 15 seconds before relaying message'\nThis will process the audio first, wait 15 seconds, then relay it.");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SilenceErrors = checkBox1.Checked;
            Properties.Settings.Default.Use95Design = checkBox2.Checked;
            Properties.Settings.Default.UseCountdown = checkBox3.Checked;
            Properties.Settings.Default.Save();
            MessageBox.Show("Some changes may not take effect until you restart the program.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.SilenceErrors;
            checkBox2.Checked = Properties.Settings.Default.Use95Design;
            checkBox3.Checked = Properties.Settings.Default.UseCountdown;
        }
    }
}
