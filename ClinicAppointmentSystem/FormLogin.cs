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
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Requirement: Validate email format (name@gmail.com)
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address (example@gmail.com)!",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // If all fields are filled, proceed with login validation
            // (We'll add actual login validation later)
            MessageBox.Show("Login successful!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            FormPatientDashboard patientdashboardForm = new FormPatientDashboard();
            patientdashboardForm.Show();
            this.Hide(); //hide main page
        }

        // Email validation method - checks for @gmail.com format
        private bool IsValidEmail(string email)
        {
            // Check if email is not empty and contains @gmail.com
            if (string.IsNullOrWhiteSpace(email))
                return false;

            if (email.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase) &&
                email.Length > "@gmail.com".Length)
            {
                // Make sure there's something before @gmail.com
                string username = email.Substring(0, email.Length - "@gmail.com".Length);
                return !string.IsNullOrWhiteSpace(username);
            }

            return false;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                // Show password (plain text)
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                // Hide password (show *)
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            FormRegister registerForm = new FormRegister();
            registerForm.Show();
            this.Hide(); //hide main page
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMainPage mainPage = new FormMainPage();
            mainPage.Show();
            this.Close();
        }
    }
}
