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
    public partial class FormManagePatient : Form
    {
        private int selectedPatientID = -1;

        public FormManagePatient()
        {
            InitializeComponent();
            this.Load += FormManagePatient_Load;
            this.dgvPatients.CellClick += dgvPatients_CellContentClick;
            this.btnSearch.Click += btnSearch_Click;
            this.btnAdd.Click += btnAdd_Click;
            this.btnUpdate.Click += btnUpdate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

   

        private void LoadAllPatients()
        {
            try
            {
                string query = @"SELECT PatientID, FullName, IC, Email, PhoneNumber, HomeAddress AS Address, Gender, DateOfBirth 
                                FROM Patients 
                                ORDER BY PatientID";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvPatients.DataSource = dt;

                // Hide PatientID column
                if (dgvPatients.Columns["PatientID"] != null)
                    dgvPatients.Columns["PatientID"].Visible = false;

                // Set column headers
                if (dgvPatients.Columns["FullName"] != null)
                    dgvPatients.Columns["FullName"].HeaderText = "Full Name";
                if (dgvPatients.Columns["PhoneNumber"] != null)
                    dgvPatients.Columns["PhoneNumber"].HeaderText = "Phone No.";
                if (dgvPatients.Columns["HomeAddress"] != null)
                    dgvPatients.Columns["HomeAddress"].HeaderText = "Address";
                if (dgvPatients.Columns["DateOfBirth"] != null)
                    dgvPatients.Columns["DateOfBirth"].HeaderText = "Date of Birth";

                // Auto resize columns
                dgvPatients.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patients: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // Get PatientID
                    selectedPatientID = Convert.ToInt32(dgvPatients.Rows[e.RowIndex].Cells["PatientID"].Value);
                    txtIC.Text = selectedPatientID.ToString();

                    // Load data to textboxes
                    txtFullName.Text = dgvPatients.Rows[e.RowIndex].Cells["FullName"].Value?.ToString() ?? "";
                    txtIC.Text = dgvPatients.Rows[e.RowIndex].Cells["IC"].Value?.ToString() ?? "";
                    txtEmail.Text = dgvPatients.Rows[e.RowIndex].Cells["Email"].Value?.ToString() ?? "";
                    txtPhone.Text = dgvPatients.Rows[e.RowIndex].Cells["PhoneNumber"].Value?.ToString() ?? "";
                    txtAddress.Text = dgvPatients.Rows[e.RowIndex].Cells["Address"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading patient data: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate fields
                if (!ValidateFields())
                    return;

                // Check if patient already exists (by IC or Email)
                if (PatientExists())
                {
                    MessageBox.Show("Patient with this IC or Email already exists!",
                                   "Validation Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                    return;
                }

                // Insert patient
                string query = @"INSERT INTO Patients (FullName, IC, Email, PhoneNumber, HomeAddress) 
                                VALUES (@FullName, @IC, @Email, @PhoneNumber, @HomeAddress)";

                SqlParameter[] parameters = {
                    new SqlParameter("@FullName", txtFullName.Text.Trim()),
                    new SqlParameter("@IC", txtIC.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@PhoneNumber", txtPhone.Text.Trim()),
                    new SqlParameter("@HomeAddress", txtAddress.Text.Trim())
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Patient added successfully!", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllPatients();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to add patient!", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding patient: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedPatientID == -1)
                {
                    MessageBox.Show("Please select a patient to update!", "Validation",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateFields())
                    return;

                // Update patient
                string query = @"UPDATE Patients 
                                SET FullName = @FullName, 
                                    IC = @IC, 
                                    Email = @Email, 
                                    PhoneNumber = @PhoneNumber, 
                                    HomeAddress = @HomeAddress 
                                WHERE PatientID = @PatientID";

                SqlParameter[] parameters = {
                    new SqlParameter("@FullName", txtFullName.Text.Trim()),
                    new SqlParameter("@IC", txtIC.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@PhoneNumber", txtPhone.Text.Trim()),
                    new SqlParameter("@HomeAddress", txtAddress.Text.Trim()),
                    new SqlParameter("@PatientID", selectedPatientID)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Patient updated successfully!", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllPatients();
                    ClearFields();
                    selectedPatientID = -1;
                }
                else
                {
                    MessageBox.Show("Failed to update patient!", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating patient: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            selectedPatientID = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedPatientID == -1)
                {
                    MessageBox.Show("Please select a patient to delete!", "Validation",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm deletion
                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete patient: {txtFullName.Text}?",
                                                       "Confirm Delete",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Check if patient has appointments
                    string checkQuery = "SELECT COUNT(*) FROM Appointments WHERE PatientID = @PatientID";
                    SqlParameter[] checkParams = {
                        new SqlParameter("@PatientID", selectedPatientID)
                    };

                    DataTable dt = DatabaseHelper.ExecuteQuery(checkQuery, checkParams);
                    int appointmentCount = Convert.ToInt32(dt.Rows[0][0]);

                    if (appointmentCount > 0)
                    {
                        MessageBox.Show($"Cannot delete patient! They have {appointmentCount} appointment(s).",
                                       "Delete Failed",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                        return;
                    }

                    // Delete patient
                    string query = "DELETE FROM Patients WHERE PatientID = @PatientID";
                    SqlParameter[] parameters = {
                        new SqlParameter("@PatientID", selectedPatientID)
                    };

                    int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                    if (result > 0)
                    {
                        MessageBox.Show("Patient deleted successfully!", "Success",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllPatients();
                        ClearFields();
                        selectedPatientID = -1;
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete patient!", "Error",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting patient: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();

                if (string.IsNullOrEmpty(keyword))
                {
                    LoadAllPatients();
                    return;
                }

                string query = @"SELECT PatientID, FullName, IC, Email, PhoneNumber, HomeAddress AS Address, Gender, DateOfBirth 
                                FROM Patients 
                                WHERE FullName LIKE @Keyword 
                                OR IC LIKE @Keyword 
                                OR Email LIKE @Keyword 
                                OR PhoneNumber LIKE @Keyword
                                OR Username LIKE @Keyword
                                ORDER BY PatientID";

                SqlParameter[] parameters = {
                    new SqlParameter("@Keyword", "%" + keyword + "%")
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvPatients.DataSource = dt;

                // Hide PatientID column
                if (dgvPatients.Columns["PatientID"] != null)
                    dgvPatients.Columns["PatientID"].Visible = false;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No patients found!", "Search Result",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormManagePatient_Load(object sender, EventArgs e)
        {
            LoadAllPatients();
            ClearFields();
            
        }

        private void ClearFields()
        {
            
            txtFullName.Clear();
            txtIC.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtSearch.Clear();
            selectedPatientID = -1;
        }


        private bool ValidateFields()
        {
            // Check Full Name
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter Full Name!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }

            // Check IC
            if (string.IsNullOrWhiteSpace(txtIC.Text))
            {
                MessageBox.Show("Please enter IC Number!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIC.Focus();
                return false;
            }

            // Check Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Please enter Email!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validate Email format
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid Email address!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                txtEmail.SelectAll();
                return false;
            }

            // Check Phone
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please enter Phone Number!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            // Check Address
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Please enter Address!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }

            return true;
        }

        private bool PatientExists()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Patients WHERE IC = @IC OR Email = @Email";

                // If updating, exclude current patient
                if (selectedPatientID != -1)
                {
                    query += " AND PatientID != @PatientID";
                }

                SqlParameter[] parameters = {
                    new SqlParameter("@IC", txtIC.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim())
                };

                if (selectedPatientID != -1)
                {
                    Array.Resize(ref parameters, 3);
                    parameters[2] = new SqlParameter("@PatientID", selectedPatientID);
                }

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                int count = Convert.ToInt32(dt.Rows[0][0]);
                return count > 0;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidEmail(string email)
        {
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

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManagePatient patientForm = new FormManagePatient();
            patientForm.Show();
            this.Hide();
        }

        private void doctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageDoctor doctorForm = new FormManageDoctor();
            doctorForm.Show();
            this.Hide();
        }

        private void appointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageAppointment appointmentForm = new FormManageAppointment();
            appointmentForm.Show();
            this.Hide();
        }

        private void specializationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageSpecialization specializationForm = new FormManageSpecialization();
            specializationForm.Show();
            this.Hide();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void viewReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewReport reportForm = new FormViewReport();
            reportForm.Show();
            this.Hide();
        }
    }
}

