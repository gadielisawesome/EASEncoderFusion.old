using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://www.youtube.com/channel/UCyWfIuvzwDRu6J9N9c0VP_Q",
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ProcessStartInfo psInfo = new ProcessStartInfo
            {
                FileName = "https://discord.gg/2mfsz5bCnk",
                UseShellExecute = true
            };
            Process.Start(psInfo);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Output Errors and Warnings Quietly - This will silence any errors and warnings that may occur while using the app.");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
