using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class CustomGenForm : Form
    {
        public CustomGenForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomData_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAnnouncement_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOutputFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.Size = new Size(544, 574);
            button3.Enabled = false;
            button4.Show();
            this.ResumeLayout();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.Size = new Size(920, 574);
            button3.Enabled = true;
            button4.Hide();
            this.ResumeLayout();
        }
    }
}
