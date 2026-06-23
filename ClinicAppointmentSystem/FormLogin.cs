using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ClinicAppointmentSystem
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            // Set password character to * by default
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Requirement 1: Check if all fields are filled
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter your Email!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter your Username!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please enter your Password!",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Validate email format
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address (example@gmail.com)!",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtEmail.Focus();
                txtEmail.SelectAll();
                return;
            }

            // ✅ LOGIN WITH BOTH EMAIL AND USERNAME
            string query = @"SELECT Password FROM Patients 
                            WHERE Email = @Email 
                            AND Username = @Username";

            SqlParameter[] parameters = {
                new SqlParameter("@Email", txtEmail.Text.Trim()),
                new SqlParameter("@Username", txtUsername.Text.Trim())
            };

            try
            {
                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);

                if (dt.Rows.Count > 0)
                {

                    string storedPassword = dt.Rows[0]["Password"].ToString();

                    // ✅ Case-sensitive comparison in C#
                    if (storedPassword == txtPassword.Text)
                    {
                        // ✅ Login successful - open dashboard
                        MessageBox.Show("Login successful! Welcome back, " + txtUsername.Text + "!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        FormPatientDashboard patientDashboard = new FormPatientDashboard();
                        patientDashboard.Show();
                        this.Hide();
                    }

                }
                else
                {
                    // ❌ Login failed
                    MessageBox.Show("Invalid email, username, or password!\n\n" +
                        "Please check your credentials or sign up if you haven't registered.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // Clear password for security
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Email validation method
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FormRegister registerForm = new FormRegister();
            registerForm.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMainPage mainPage = new FormMainPage();
            mainPage.Show();
            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Optional: Set focus to first field
            txtEmail.Focus();
        }
    }
}