using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace ClinicAppointmentSystem
{
    public partial class FormBookAppointment : Form
    {
        public FormBookAppointment()
        {
            InitializeComponent();
            PopulateComboBoxes();
        }

        private void PopulateComboBoxes()
        {
            // Populate Specialization
            cboSpecialization.Items.AddRange(new string[]
            {
                "Cardiologist",
                "Dermatologist",
                "Neurologist",
                "Pediatrician",
                "Psychiatrist",
                "General Physician"
            });

            // Populate Doctor
            cboDoctor.Items.AddRange(new string[]
            {
                "Dr. Ahmad Abdullah",
                "Dr. Siti Nurhaliza",
                "Dr. Tan Wei Ming",
                "Dr. Rajesh Kumar",
                "Dr. Lisa Wong"
            });

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Check if ALL fields are filled/selected
            if (!AreAllFieldsFilled())
            {
                MessageBox.Show("Please fill in all fields and make selections in all dropdowns!",
                    "Incomplete Appointment",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // If all fields are filled, proceed
            string appointmentDetails =
                $"Specialization: {cboSpecialization.SelectedItem}\n" +
                $"Symptoms: {txtSymptoms.Text}\n" +
                $"Doctor: {cboDoctor.SelectedItem}\n" +
                $"Date: {dtpDate.Value.ToString("dd MMMM yyyy")}\n" +
                $"Time: {dtpTime.Value.ToString("hh:mm tt")}";

            DialogResult result = MessageBox.Show(
                $"Confirm your appointment:\n\n{appointmentDetails}\n\n\nProceed with booking?",
                "Confirm Appointment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Appointment Booked Successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear form after successful booking
                ClearForm();
            }

            FormPayment paymentForm = new FormPayment();
            paymentForm.Show();
            this.Hide();


        }

        // Check if all fields are filled
        private bool AreAllFieldsFilled()
        {
            // Check Symptoms TextBox
            if (string.IsNullOrWhiteSpace(txtSymptoms.Text))
                return false;

            // Check ComboBoxes have selected items
            if (cboSpecialization.SelectedIndex == -1)
                return false;
            if (cboDoctor.SelectedIndex == -1)
                return false;

            // DateTimePickers always have values, no need to check
            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            // Clear TextBox
            txtSymptoms.Text = "";

            // Reset ComboBoxes
            cboSpecialization.SelectedIndex = -1;
            cboDoctor.SelectedIndex = -1;

            // Reset Date to today
            dtpDate.Value = DateTime.Today;

            // Reset Time to 9:00 AM
            dtpTime.Value = DateTime.Today.AddHours(9).AddMinutes(0);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Close();
            }
        }

        private void bookAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // View Appointment button
        private void btnViewAppointment_Click(object sender, EventArgs e)
        {
            FormViewAppointment viewForm = new FormViewAppointment();
            viewForm.Show();
            this.Hide();
        }
    }
}
