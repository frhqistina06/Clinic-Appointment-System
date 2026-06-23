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
        // FIXED ADMIN CREDENTIALS (ONLY ONE ACCOUNT)
        private const string AdminEmail = "admin@gmail.com";
        private const string AdminPassword = "Admin1234";

        public FormAdminLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // CHECK IF FIELDS ARE EMPTY
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Please fill in all fields!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // STOP IF ANY FIELD IS EMPTY
            }

            // VALIDATE ADMIN CREDENTIALS
            if (txtEmail.Text == AdminEmail && txtPassword.Text == AdminPassword)
            {
                MessageBox.Show("Admin Login Successful!", "Welcome Admin",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormAdminDashboard adminDashboard = new FormAdminDashboard();
                adminDashboard.Show();
                this.Hide(); 
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
                txtPassword.PasswordChar = '\0'; 
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormMainPage mainPage = new FormMainPage();
            mainPage.Show();
            this.Close();
        }

        private void FormAdminLogin_Load(object sender, EventArgs e)
        {

        }
    }
}