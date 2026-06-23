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
using System.Data.SqlClient;
using System.Text.RegularExpressions; // ADD THIS FOR EMAIL VALIDATION

namespace ClinicAppointmentSystem
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            // WHEN FORM LOADS > RUN FormRegister_Load (SAME GOES TO OTHERS
            this.Load += FormRegister_Load;
            this.btnCreate.Click += btnCreateAccount_Click;
            this.btnBack.Click += btnBackToLogin_Click;
            this.chkShowPassword.CheckedChanged += chkShowPassword_CheckedChanged;
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            // SET DEFAULT DOB (USER AT LEAST 18 YEARS OLD)
            dtpDOB.Value = DateTime.Now.AddYears(-18);

            //HIDE PASSWORD CHARACTERS WITH STAR
            txtPassword.PasswordChar = '*';
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            try
            {
                // CHECK IF USER FILLED EVERYTHING CORRECT
                if (!ValidateAllFields())
                    return; //STOP IF FAILS

                // CHECK IF PATIENT ALREADY EXISTS IN DATABASE
                if (PatientExists())
                {
                    MessageBox.Show("Patient already exists! Please login.",
                        "Registration Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return; //STOP IF PATIENT ALREADY EXISTS
                }

                // SAVE PATIENT DATA TO DATABASE
                bool saved = SavePatientToDatabase();

                if (saved)
                {
                    MessageBox.Show("Account Created Successfully!",
                                   "Success",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);

                    ClearFields();

                    FormLogin loginForm = new FormLogin();
                    loginForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to create account. Please try again.",
                                   "Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // CATCH FOR ANY UNEXPECTED ERRORS
                MessageBox.Show($"An error occurred: {ex.Message}",
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
            }
        }

        //VALIDATES ALL INPUT FIELDS BEFORE SAVING TO DATABASE
        // RETURNS TRUE IF ALL FIELDS ARE VALID
        // RETURNS FALSE IF ANY FIELD IS INVALID
        private bool ValidateAllFields()
        {
            // CHECK IF FULL NAME IS EMPTY OR ONLY SPACE
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter your Full Name!",
                               "Validation Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            // ============================================
            // EMAIL VALIDATION - ADD THIS SECTION
            // ============================================
            // CHECK IF EMAIL IS EMPTY
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter your Email!",
                               "Validation Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // VALIDATE EMAIL FORMAT
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address! (e.g., name@domain.com)",
                               "Invalid Email",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtEmail.Focus();
                txtEmail.SelectAll();
                return false;
            }

            // CHECK IF IC IS EMPTY
            if (string.IsNullOrWhiteSpace(txtIC.Text))
            {
                MessageBox.Show("Please enter your IC number!",
                               "Validation Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtIC.Focus();
                return false;
            }

            // CHECK IF IC CONTAINS NUMBERS ONLY
            if (!IsNumeric(txtIC.Text))
            {
                MessageBox.Show("IC number can only contain numbers!",
                               "Invalid IC",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtIC.Focus();
                txtIC.SelectAll();
                return false;
            }

            // CHECK IF IC LENGTH IS 12 (FOLLOW MALAYSIA IC)
            if (txtIC.Text.Length != 12)
            {
                MessageBox.Show("IC number must be 12 digits (YYMMDD-XX-XXXX)",
                               "Invalid IC",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtIC.Focus();
                txtIC.SelectAll();
                return false;
            }

            // CHECK IF EITHER MALE OR FEMALE RADBUTTON SELECTED
            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("Please select your Gender!",
                               "Validation Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return false;
            }

            // CHECK IF PHONE NUMBER IS EMPTY
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter your Phone Number!",
                               "Validation Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            // REMOVE SPACE AND DASH BEFORE CHECKING
            string phoneClean = txtPhone.Text.Replace(" ", "").Replace("-", "");
            //CHECK IF PHONE NUMBER CONTAINS NUMBERS ONLY
            if (!IsNumeric(phoneClean))
            {
                MessageBox.Show("Phone number can only contain numbers!",
                               "Invalid Phone Number",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtPhone.Focus();
                txtPhone.SelectAll();
                return false;
            }

            // CHECK IF PHONE LENGTH IS 10-11 DIGITS
            if (phoneClean.Length < 10 || phoneClean.Length > 11)
            {
                MessageBox.Show("Phone number must be 10-11 digits (e.g., 0123456789)!",
                               "Invalid Phone",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtPhone.Focus();
                txtPhone.SelectAll();
                return false;
            }

            // CHECK ADDRESS
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter your Home Address!",
                               "Validation Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter a Username!",
                               "Validation Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            // USERNAME MUST BE AT LEAST 3 CHARACTERS
            if (txtUsername.Text.Length < 3)
            {
                MessageBox.Show("Username must be at least 3 characters!",
                               "Validation Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtUsername.Focus();
                txtUsername.SelectAll();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter a Password!",
                               "Validation Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            // PASSWORD MUST BE AT LEAST 6 CHARACTERS
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters!",
                               "Validation Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                txtPassword.Focus();
                txtPassword.SelectAll();
                return false;
            }

            // IF ALL VALIDATIONS OKAY
            return true;
        }

        // CHECK IF A STRING CONTAINS NUMBER ONLY
        private bool IsNumeric(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        // ============================================
        // EMAIL VALIDATION METHOD - ADD THIS
        // ============================================
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Simple email validation using Regex
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, pattern);
            }
            catch
            {
                return false;
            }
        }

        //CHECK IF A PATIENT ALREADY EXISTS IN THE DATABASE
        private bool PatientExists()
        {
            try
            {
                // Check by IC, Username, OR Email - ADD EMAIL CHECK
                string query = "SELECT COUNT(*) FROM Patients WHERE IC = @IC OR Username = @Username OR Email = @Email";

                SqlParameter[] parameters = {
                    new SqlParameter("@IC", txtIC.Text),
                    new SqlParameter("@Username", txtUsername.Text),
                    new SqlParameter("@Email", txtEmail.Text) // ADD EMAIL PARAMETER
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                int count = Convert.ToInt32(dt.Rows[0][0]);
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check existence error: " + ex.Message,
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return false;
            }
        }

        // ============================================
        // SAVE TO DATABASE - FIXED WITH EMAIL
        // ============================================

        private bool SavePatientToDatabase()
        {
            try
            {
                // Get values from form
                string fullName = txtFullName.Text.Trim();
                string email = txtEmail.Text.Trim();  // GET EMAIL
                string ic = txtIC.Text.Trim();
                DateTime dob = dtpDOB.Value;
                string gender = rbMale.Checked ? "Male" : "Female";
                string phone = txtPhone.Text.Trim();
                string address = txtAddress.Text.Trim();
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                // ✅ FIXED: Include Email in INSERT
                string query = @"INSERT INTO Patients (FullName, Email, IC, DateOfBirth, Gender, 
                        PhoneNumber, HomeAddress, Username, Password) 
                        VALUES (@FullName, @Email, @IC, @DateOfBirth, @Gender, 
                               @PhoneNumber, @HomeAddress, @Username, @Password)";

                SqlParameter[] parameters = {
            new SqlParameter("@FullName", fullName),
            new SqlParameter("@Email", email),  // ✅ EMAIL PARAMETER - CRITICAL!
            new SqlParameter("@IC", ic),
            new SqlParameter("@DateOfBirth", dob),
            new SqlParameter("@Gender", gender),
            new SqlParameter("@PhoneNumber", phone),
            new SqlParameter("@HomeAddress", address),
            new SqlParameter("@Username", username),
            new SqlParameter("@Password", password)
        };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                               "Error",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Error);
                return false;
            }
        }

        // ============================================
        // SHOW/HIDE PASSWORD
        // ============================================

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '●';
        }

        // ============================================
        // BACK TO LOGIN
        // ============================================

        private void btnBackToLogin_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Hide();
        }

        // ============================================
        // CLEAR FIELDS
        // ============================================

        private void ClearFields()
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtIC.Clear();
            dtpDOB.Value = DateTime.Now.AddYears(-18);
            rbMale.Checked = true;
            txtPhone.Clear();
            txtAddress.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            chkShowPassword.Checked = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}