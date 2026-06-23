using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointmentSystem
{
    public partial class FormViewAppointment : Form
    {
        public FormViewAppointment()
        {
            InitializeComponent();
        }

        private void bookAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBookAppointment bookForm = new FormBookAppointment();
            bookForm.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ASK USER TO CONFIRM
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Close();
            }
        }

        private void viewAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewAppointment viewForm = new FormViewAppointment();
            viewForm.Show();
            this.Hide();
        }
    }
}
