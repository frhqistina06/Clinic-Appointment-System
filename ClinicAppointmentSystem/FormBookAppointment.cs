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
            this.cboSpecialization.SelectedIndexChanged += cboSpecialization_SelectedIndexChanged;
        }

        // CALCULATES CONSULTATION FEE BASED ON SELECTED SPECIALIZATION
        private decimal GetConsultationFee(string specialization)
        {
            switch (specialization)
            {
                case "Cardiologist": return 150.00m; // HEART
                case "Dermatologist": return 120.00m; // SKIN
                case "Neurologist": return 180.00m; // BRAIN
                case "Pediatrician": return 90.00m; // CHILDREN
                case "Psychiatrist": return 130.00m; // MENTAL HEALTH 
                case "General Physician": return 60.00m; // GENERAL DOCTOR BIASA
                default: return 80.00m;
            }
        }

        // UPDATE FEE DISPLAY WHEN SPECIALIZATION CHANGES
        private void UpdateFeeDisplay()
        {
            // CHECK IF USER ADA SELECT A SPECIALIZATION
            if (cboSpecialization.SelectedIndex != -1)
            {
                // CALCULATE FEE
                decimal fee = GetConsultationFee(cboSpecialization.SelectedItem.ToString());
                // UPDATE LABEL TEXT WITH THE FEE
                lblFee.Text = $"RM {fee:F2}";
                // MAKE THE LABEL VISIBLE
                lblFee.Visible = true;
                lblFee.BringToFront();
            }
            else
            {
                // HIDE THE FEE LABEL IF NO SPECIALIZATION IS SELECT
                lblFee.Visible = false;
            }
        }

        // WHEN USER SELECT A SPECIALIZATION FROM DROPDOWN MENU
        // UPDATES FEE DISPLAY AND FILTERS DOCTORS BASED ON SPECIALIZATION
        private void cboSpecialization_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFeeDisplay();

            //IF SPECIALIZATION IS SELECT, FILTER DOCTORS
            if (cboSpecialization.SelectedIndex != -1)
            {
                string selectedSpecialization = cboSpecialization.SelectedItem.ToString();
                FilterDoctorsBySpecialization(selectedSpecialization);
            }
            else
            {
                // IF NO SPECIALIZATION SELECT, CLEAR DOCTOR LIST
                cboDoctor.Items.Clear();
                cboDoctor.SelectedIndex = -1;
            }
        }



        // CHECK IF ALL FIELDS ARE FILL
        private bool AreAllFieldsFilled()
        {
            if (string.IsNullOrWhiteSpace(txtSymptoms.Text))
                return false;

            if (cboSpecialization.SelectedIndex == -1)
                return false;
            if (cboDoctor.SelectedIndex == -1)
                return false;

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtSymptoms.Text = "";
            cboSpecialization.SelectedIndex = -1;
            cboDoctor.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today;
            dtpTime.Value = DateTime.Today.AddHours(9).AddMinutes(0);
            lblFee.Visible = false;
        }

        // LOG OUT THE CURRENT USER AND BACK TO LOGIN PAGE
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ASK USER TO CONFIRM
            DialogResult result = MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Hide();
            }
        }

        private void bookAppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnViewAppointment_Click(object sender, EventArgs e)
        {
            FormViewAppointment viewForm = new FormViewAppointment();
            viewForm.Show();
            this.Hide();
        }

        // SHOWS ONLY DOCTORS THAT BELONG TO THE SELECTED SPECIALIZATION
        private void FilterDoctorsBySpecialization(string specialization)
        {
            cboDoctor.Items.Clear();

            // EACH SPECIALIZATION ADA SPECIFIC DOCTOR ASSIGNED TO IT
            switch (specialization)
            {
                case "Cardiologist":
                    cboDoctor.Items.AddRange(new string[]
                    {
                "Dr. Ahmad Abdullah",
                "Dr. Siti Nurhaliza"
                    });
                    break;
                case "Dermatologist":
                    cboDoctor.Items.AddRange(new string[]
                    {
                "Dr. Tan Wei Ming"
                    });
                    break;
                case "Neurologist":
                    cboDoctor.Items.AddRange(new string[]
                    {
                "Dr. Rajesh Kumar"
                    });
                    break;
                case "Pediatrician":
                    cboDoctor.Items.AddRange(new string[]
                    {
                "Dr. Lisa Wong"
                    });
                    break;
                case "Psychiatrist":
                    cboDoctor.Items.AddRange(new string[]
                    {
                "Dr. Ahmad Abdullah"
                    });
                    break;
                case "General Physician":
                    cboDoctor.Items.AddRange(new string[]
                    {
                "Dr. Lisa Wong",
                "Dr. Tan Wei Ming"
                    });
                    break;
                default:
                    cboDoctor.Items.Clear();
                    break;
            }

            cboDoctor.SelectedIndex = -1;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // DAPATKAN DATA DARI FORM
            string doctor = cboDoctor.SelectedItem?.ToString() ?? "";
            string specialization = cboSpecialization.SelectedItem?.ToString() ?? "";
            string symptoms = txtSymptoms.Text.Trim();
            DateTime date = dtpDate.Value;
            DateTime time = dtpTime.Value;
            decimal fee = GetConsultationFee(specialization);

            // ✅ VALIDASI
            if (string.IsNullOrEmpty(doctor))
            {
                MessageBox.Show("Please select a doctor!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cboDoctor.Focus();
                return;
            }

            if (string.IsNullOrEmpty(specialization))
            {
                MessageBox.Show("Please select a specialization!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cboSpecialization.Focus();
                return;
            }

            if (string.IsNullOrEmpty(symptoms))
            {
                MessageBox.Show("Please enter your symptoms!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtSymptoms.Focus();
                return;
            }

            // ✅ TUNJUK SUMMARY SEBELUM KE PAYMENT
            string summary =
                "APPOINTMENT SUMMARY\n\n" +
                $"Doctor          : {doctor}\n" +
                $"Specialization  : {specialization}\n" +
                $"Date            : {date:dd MMMM yyyy}\n" +
                $"Time            : {time:hh:mm tt}\n" +
                $"Symptoms        : {symptoms}\n" +
                $"Consultation Fee: RM {fee:F2}\n\n" +
                "Proceed to payment?";

            DialogResult result = MessageBox.Show(summary,
                "Confirm Appointment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
                return;

            // ✅ HANTAR DATA KE FORM PAYMENT
            FormPayment paymentForm = new FormPayment(
                doctor,
                specialization,
                symptoms,
                date,
                time,
                fee
            );

            paymentForm.Show();
            this.Hide();
        }

        
    }

}
