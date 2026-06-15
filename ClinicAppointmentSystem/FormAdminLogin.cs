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
    public partial class FormAdminLogin : Form
    {
        // Fixed admin credentials (from your PDF)
        private const string AdminEmail = "admin@gmail.com";
        private const string AdminPassword = "Admin1234";

        public FormAdminLogin()
        {
            InitializeComponent();

            // Set password character to * by default
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Check if fields are empty
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate admin credentials
            if (txtEmail.Text == AdminEmail && txtPassword.Text == AdminPassword)
            {
                MessageBox.Show("Admin Login Successful!", "Welcome Admin",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open Admin Dashboard
                FormAdminDashboard adminDashboard = new FormAdminDashboard();
                adminDashboard.Show();
                this.Hide(); // Hide admin login form
            }
            else
            {
                MessageBox.Show("Invalid email or password!\n\nLogin Failed", "Login Failed",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Show password
            }
            else
            {
                txtPassword.PasswordChar = '*'; // Hide password
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMainPage mainPage = new FormMainPage();
            mainPage.Show();
            this.Close();
        }
    }
}