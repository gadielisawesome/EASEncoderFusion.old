using System;
using System.Linq;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class UnusedActivateForm : Form
    {
        public UnusedActivateForm()
        {
            InitializeComponent();
        }

        internal string[] activationList = {
            "DZRAKC3JCA",
            "HKSB75EKTK",
            "J8HHG3X55H",
            "MZNQPPX5BA",
            "R2KEXAX694"
        };

        private void btnActivate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //if (textBox1.Text == "DZRAKC3JCA")

                string userInput = textBox1.Text; // Assuming textBox1 is the name of the TextBox control

                bool isMatched = activationList.Any(word => word.Equals(userInput, StringComparison.Ordinal));

                if (isMatched)
                {
                    Properties.Settings.Default.IsActivated = true;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("The activation key is correct. The application will now restart.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.Yes;
                }
                else
                {
                    MessageBox.Show("The activation key is incorrect. The application will now terminate.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.No;
                }

            }
        }
    }
}
