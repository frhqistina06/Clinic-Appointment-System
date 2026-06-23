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
    public partial class FormPatientDashboard : Form
    {
        public FormPatientDashboard()
        {
            InitializeComponent();
        }

        private void bookAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBookAppointment bookappointmentForm = new FormBookAppointment();
            bookappointmentForm.Show();
        }

        private void viewAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewAppointment viewappointmentForm = new FormViewAppointment();
            viewappointmentForm.Show();
        }


        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have been logged out successfully!", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Hide();
        }
    }
}
