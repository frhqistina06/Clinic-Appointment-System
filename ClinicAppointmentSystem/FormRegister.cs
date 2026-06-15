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

namespace ClinicAppointmentSystem
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            // Check if all fields are filled
            if (!AreAllFieldsFilled())
            {
                MessageBox.Show("Please fill in all fields!", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate IC (numbers only, 12 digits)
            if (!IsNumeric(txtIC.Text))
            {
                MessageBox.Show("IC/Passport Number can only contain numbers!", "Invalid IC",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtIC.Text.Length != 12)
            {
                MessageBox.Show("IC/Passport Number must be 12 digits!", "Invalid IC",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Phone (numbers only, 10-11 digits)
            if (!IsNumeric(txtPhone.Text))
            {
                MessageBox.Show("Phone Number can only contain numbers!", "Invalid Phone",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPhone.Text.Length < 10 || txtPhone.Text.Length > 11)
            {
                MessageBox.Show("Phone Number must be 10-11 digits!", "Invalid Phone",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if patient already exists
            if (PatientExists())
            {
                MessageBox.Show("Patient already exists! Please login instead.", "Registration Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save to database
            bool saved = SavePatientToDatabase();

            if (saved)
            {
                MessageBox.Show("Account Created Successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to create account. Please try again.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool PatientExists()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM PatientTable WHERE IC = @IC OR Username = @Username";

                SqlParameter[] parameters = {
                    new SqlParameter("@IC", txtIC.Text),
                    new SqlParameter("@Username", txtUsername.Text)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                int count = Convert.ToInt32(dt.Rows[0][0]);
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check existence error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool SavePatientToDatabase()
        {
            try
            {
                MessageBox.Show("Attempting to save: " + txtFullName.Text);

                string query = @"INSERT INTO PatientTable (FullName, IC, Phone, Address, Username, Password, RegisterDate) 
                         VALUES (@FullName, @IC, @Phone, @Address, @Username, @Password, @RegisterDate)";

                string gender = rbMale.Checked ? "Male" : "Female";
                string fullAddress = txtAddress.Text + " | Gender: " + gender;

                SqlParameter[] parameters = {
                    new SqlParameter("@FullName", txtFullName.Text),
                    new SqlParameter("@IC", txtIC.Text),
                    new SqlParameter("@Phone", txtPhone.Text),
                    new SqlParameter("@Address", fullAddress),
                    new SqlParameter("@Username", txtUsername.Text),
                    new SqlParameter("@Password", txtPassword.Text),
                    new SqlParameter("@RegisterDate", DateTime.Now)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool AreAllFieldsFilled()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtIC.Text)) return false;
            if (!rbMale.Checked && !rbFemale.Checked) return false;
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtPhone.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtAddress.Text)) return false;

            return true;
        }

        private bool IsNumeric(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Hide();
        }
    }
}