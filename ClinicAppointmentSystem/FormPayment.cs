using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicAppointmentSystem
{
    public partial class FormPayment : Form
    {
        // STORE APPOINTMENT DATA
        private readonly string doctorName;
        private readonly string specialization;
        private readonly string symptoms;
        private readonly DateTime appointmentDate;
        private readonly DateTime appointmentTime;
        private readonly decimal consultationFee;

        // UNTUK SIMPAN KE DATABASE
        private readonly int patientId;
        private readonly int doctorId;



        // ✅ TAMBAH: STORE PAYMENT METHOD
        private string selectedPaymentMethod = "";
        private string selectedBank = "";

        // RECEIVE DATA FROM BOOK APPOINTMENT FORM
        public FormPayment(string doctor, string spec, string symp, DateTime date, DateTime time, decimal fee)
        {
            InitializeComponent();

            // STORE THE DATA IN CLASS VARIABLES
            doctorName = doctor;
            specialization = spec;
            symptoms = symp;
            appointmentDate = date;
            appointmentTime = time;
            consultationFee = fee;

            // ✅ GET PATIENT AND DOCTOR IDs FROM DATABASE
            GetPatientAndDoctorIds();

            // SHOW APPOINTMENT SUMMARY
            ShowSummaryInMessageBox();

            // ✅ HIDE ALL PANELS INITIALLY
            picQRCode.Visible = false;
            grpCardDetails.Visible = false;
            grpFPXDetails.Visible = false;

            // ✅ DISABLE PROCESS BUTTON (ENABLE AFTER AGREE TERMS)
            btnCompleted.Enabled = false;

            // ✅ SET DEFAULT BANK SELECTION
            cboBank.SelectedIndex = 0;


        }

        // ✅ GET PATIENT AND DOCTOR IDs FROM DATABASE
        private void GetPatientAndDoctorIds()
        {
            try
            {
                // GET PATIENT ID (Assuming you have a logged-in user)
                // For now, we'll use a default patient ID 1
                // You should replace this with actual logged-in user ID
                patientId = GetPatientIdFromDatabase();

                // GET DOCTOR ID BASED ON DOCTOR NAME
                doctorId = GetDoctorIdFromDatabase(doctorName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting IDs: {ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ✅ GET PATIENT ID (Replace with your actual logic)
        private int GetPatientIdFromDatabase()
        {
            // Option 1: Use a default patient (for testing)
            // return 1;

            // Option 2: Get from logged-in user
            // return UserSession.PatientId;

            // Option 3: Get from database based on username/email
            string connectionString = "Your_Connection_String_Here"; // Replace with your connection string
            string query = "SELECT PatientID FROM Patients WHERE Username = @Username"; // Or Email, etc.

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                // Replace with actual logged-in username
                cmd.Parameters.AddWithValue("@Username", "testuser");

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    return Convert.ToInt32(result);
                else
                    throw new Exception("Patient not found");
            }
        }

        // ✅ GET DOCTOR ID BASED ON DOCTOR NAME
        private int GetDoctorIdFromDatabase(string doctorName)
        {
            string connectionString = "Your_Connection_String_Here"; // Replace with your connection string
            string query = "SELECT DoctorID FROM Doctors WHERE FullName = @DoctorName";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@DoctorName", doctorName);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                    return Convert.ToInt32(result);
                else
                    throw new Exception($"Doctor '{doctorName}' not found");
            }
        }

        private void ShowSummaryInMessageBox()
        {
            string summary =
                "APPOINTMENT DETAILS\n\n" +
                $"Doctor          : {doctorName}\n" +
                $"Specialization  : {specialization}\n" +
                $"Date            : {appointmentDate:dd MMMM yyyy}\n" +
                $"Time            : {appointmentTime:hh:mm tt}\n" +
                $"Symptoms        : {symptoms}\n\n" +
                $"Total Amount    : RM {consultationFee:F2}\n\n" +
                "Please proceed with payment.";

            MessageBox.Show(summary,
                "Appointment Summary",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // ============================================
        // E-WALLET SELECTED - SHOW QR CODE
        // ============================================
        private void RadEWallet_CheckedChanged(object sender, EventArgs e)
        {
            if (radEWallet.Checked)
            {
                picQRCode.Visible = true;
                grpCardDetails.Visible = false;
                grpFPXDetails.Visible = false;
            }
        }

        // ============================================
        // CREDIT CARD SELECTED - SHOW CARD DETAILS
        // ============================================
        private void RadCreditCard_CheckedChanged(object sender, EventArgs e)
        {
            if (radCreditCard.Checked)
            {
                picQRCode.Visible = false;
                grpCardDetails.Visible = true;
                grpFPXDetails.Visible = false;
            }
        }

        // ============================================
        // FPX SELECTED - SHOW BANK DETAILS
        // ============================================
        private void RadFPX_CheckedChanged(object sender, EventArgs e)
        {
            if (radFPX.Checked)
            {
                picQRCode.Visible = false;
                grpCardDetails.Visible = false;
                grpFPXDetails.Visible = true;
            }
        }

        // ============================================
        // TERMS AND CONDITIONS CHECKBOX
        // ============================================
        private void ChkAgreeTerms_CheckedChanged(object sender, EventArgs e)
        {
            btnCompleted.Enabled = chkAgree.Checked;
        }

        // ============================================
        // PROCESS PAYMENT BUTTON
        // ============================================
        private void BtnProcessPayment_Click(object sender, EventArgs e)
        {
            // VALIDASI
            if (!radEWallet.Checked && !radCreditCard.Checked && !radFPX.Checked)
            {
                MessageBox.Show("Please select a payment method!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!chkAgree.Checked)
            {
                MessageBox.Show("Please agree to the Terms and Policy!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (radCreditCard.Checked && !ValidateCardDetails())
                return;

            if (radFPX.Checked)
            {
                if (cboBank.SelectedIndex <= 0 || cboBank.SelectedItem.ToString() == "Select Your Bank")
                {
                    MessageBox.Show("Please select your bank!",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
                selectedBank = cboBank.SelectedItem.ToString();
            }

            // ✅ SAVE TO DATABASE
            if (SaveAppointmentToDatabase())
            {
                MessageBox.Show($"✅ Payment successful!\n\n" +
                    $"Appointment with {doctorName}\n" +
                    $"Date: {appointmentDate:dd MMMM yyyy}\n" +
                    $"Time: {appointmentTime:hh:mm tt}\n" +
                    $"Amount: RM {consultationFee:F2}",
                    "Payment Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                RefreshManageAppointment();
                this.Close();
            }
        }

        // ============================================
        // ✅ SAVE TO DATABASE
        // ============================================
        private bool SaveAppointmentToDatabase()
        {
            try
            {
                string query = @"INSERT INTO Appointments 
                                (PatientID, DoctorID, AppointmentDate, AppointmentTime, 
                                 Symptoms, Status, PaymentStatus, PaymentMethod, 
                                 PaymentDate, BankName, Price) 
                                VALUES 
                                (@PatientID, @DoctorID, @AppointmentDate, @AppointmentTime, 
                                 @Symptoms, 'Pending', 'Paid', @PaymentMethod, 
                                 @PaymentDate, @BankName, @Price)";


                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Parameters.AddWithValue("@PatientID", patientId);
                    cmd.Parameters.AddWithValue("@DoctorID", doctorId);
                    cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate.Date);
                    cmd.Parameters.AddWithValue("@AppointmentTime", appointmentTime.TimeOfDay);
                    cmd.Parameters.AddWithValue("@Symptoms", symptoms);
                    cmd.Parameters.AddWithValue("@PaymentMethod", selectedPaymentMethod);
                    cmd.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@BankName", string.IsNullOrEmpty(selectedBank) ? DBNull.Value : (object)selectedBank);
                    cmd.Parameters.AddWithValue("@Price", consultationFee);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error saving appointment:\n\n{ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        // ============================================
        // PROCESS PAYMENT
        // ============================================
        private void ProcessPayment()
        {
            string paymentMethod = "";
            string additionalInfo = "";

            if (radEWallet.Checked)
            {
                paymentMethod = "E-Wallet";
            }
            else if (radCreditCard.Checked)
            {
                paymentMethod = "Credit Card";
                string last4 = txtCardNumber.Text.Replace(" ", "");
                if (last4.Length >= 4)
                    last4 = last4.Substring(last4.Length - 4);
                additionalInfo = $" (Card ending: {last4})";
            }
            else if (radFPX.Checked)
            {
                paymentMethod = "FPX";
                additionalInfo = $" ({cboBank.SelectedItem})";
            }

            MessageBox.Show($"Payment of RM {consultationFee:F2} via {paymentMethod}{additionalInfo} successful!\n\nAppointment confirmed.",
                "Payment Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        // ============================================
        // VALIDATE CARD DETAILS
        // ============================================
        private bool ValidateCardDetails()
        {
            // CHECK CARD HOLDER NAME
            if (string.IsNullOrWhiteSpace(txtCardHolderName.Text))
            {
                MessageBox.Show("Please enter Card Holder Name!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCardHolderName.Focus();
                return false;
            }

            // CHECK CARD NUMBER (MUST BE 16 DIGITS)
            string cardNumber = txtCardNumber.Text.Replace(" ", "");
            if (cardNumber.Length != 16)
            {
                MessageBox.Show("Please enter a valid 16-digit Card Number!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCardNumber.Focus();
                return false;
            }

            // CHECK EXPIRY DATE (MUST BE AT LEAST 5 CHARACTERS: MM/YY)
            if (txtExpiryDate.Text.Length < 5)
            {
                MessageBox.Show("Please enter Expiry Date (MM/YY)!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtExpiryDate.Focus();
                return false;
            }

            // CHECK CVV (MUST BE 3 DIGITS)
            if (txtCVV.Text.Length < 3)
            {
                MessageBox.Show("Please enter a valid CVV (3 digits)!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtCVV.Focus();
                return false;
            }

            return true;
        }

        // ============================================
        // AUTO-FORMAT CARD NUMBER
        // ============================================
        private void TxtCardNumber_TextChanged(object sender, EventArgs e)
        {
            // REMOVE EXISTING SPACES
            string cleaned = txtCardNumber.Text.Replace(" ", "");

            // LIMIT TO 16 DIGITS
            if (cleaned.Length > 16)
                cleaned = cleaned.Substring(0, 16);

            // FORMAT WITH SPACES EVERY 4 DIGITS
            if (cleaned.Length >= 4 && cleaned.Length < 8)
                txtCardNumber.Text = cleaned.Substring(0, 4) + " " + cleaned.Substring(4);
            else if (cleaned.Length >= 8 && cleaned.Length < 12)
                txtCardNumber.Text = cleaned.Substring(0, 4) + " " + cleaned.Substring(4, 4) + " " + cleaned.Substring(8);
            else if (cleaned.Length >= 12)
                txtCardNumber.Text = cleaned.Substring(0, 4) + " " + cleaned.Substring(4, 4) + " " + cleaned.Substring(8, 4) + " " + cleaned.Substring(12);
            else
                txtCardNumber.Text = cleaned;

            txtCardNumber.SelectionStart = txtCardNumber.Text.Length;
        }

        // ============================================
        // AUTO-FORMAT EXPIRY DATE
        // ============================================
        private void TxtExpiryDate_TextChanged(object sender, EventArgs e)
        {
            // REMOVE EXISTING SLASH
            string cleaned = txtExpiryDate.Text.Replace("/", "");

            // LIMIT TO 4 DIGITS
            if (cleaned.Length > 4)
                cleaned = cleaned.Substring(0, 4);

            // ADD SLASH AFTER 2 DIGITS
            if (cleaned.Length >= 2 && cleaned.Length < 4)
                txtExpiryDate.Text = cleaned.Substring(0, 2) + "/" + cleaned.Substring(2);
            else if (cleaned.Length >= 4)
                txtExpiryDate.Text = cleaned.Substring(0, 2) + "/" + cleaned.Substring(2, 2);
            else
                txtExpiryDate.Text = cleaned;

            txtExpiryDate.SelectionStart = txtExpiryDate.Text.Length;
        }

        // ============================================
        // BACK BUTTON
        // ============================================
        private void BtnBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel payment?",
                "Cancel Payment",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Dalam FormPayment.cs - Tambah kod untuk refresh selepas payment
        private void ShowPaymentSuccess()
        {
            string paymentMethod = selectedPaymentMethod;
            string additionalInfo = "";

            if (paymentMethod == "Credit Card")
            {
                string last4 = txtCardNumber.Text.Replace(" ", "");
                if (last4.Length >= 4)
                    last4 = last4.Substring(last4.Length - 4);
                additionalInfo = $" (Card ending: {last4})";
            }
            else if (paymentMethod == "FPX")
            {
                additionalInfo = $" ({selectedBank})";
            }

            MessageBox.Show($"Payment of RM {consultationFee:F2} via {paymentMethod}{additionalInfo} successful!\n\nAppointment confirmed.",
                "Payment Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // ✅ REFRESH FORM MANAGE APPOINTMENT
            RefreshManageAppointment();

            this.Close();
        }

        // ============================================
        // ✅ REFRESH MANAGE APPOINTMENT FORM
        // ============================================
        private void RefreshManageAppointment()
        {
            // Cari form ManageAppointment yang sedang terbuka
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormManageAppointment manageForm)
                {
                    manageForm.RefreshAppointments();
                    break;
                }
            }
        }
    }
}