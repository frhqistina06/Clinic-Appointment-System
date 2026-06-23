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
    public partial class FormAdminDashboard : Form
    {
        public FormAdminDashboard()
        {
            InitializeComponent();
        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManagePatient managepatientForm = new FormManagePatient();
            managepatientForm.Show();
            this.Hide();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageDoctor managedoctorForm = new FormManageDoctor();
            managedoctorForm.Show();
            this.Hide();
        }

        private void appointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageAppointment manageappointmentForm = new FormManageAppointment();
            manageappointmentForm.Show();
            this.Hide();
        }

        private void specializationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageSpecialization managespecializationForm = new FormManageSpecialization();
            managespecializationForm.Show();
            this.Hide();
        }

        private void viewReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewReport reportForm = new FormViewReport();
            reportForm.Show();
            this.Hide();
        }
    }
}
