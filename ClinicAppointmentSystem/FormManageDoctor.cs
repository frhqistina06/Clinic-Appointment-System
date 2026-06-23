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
    public partial class FormManageDoctor : Form
    {
        private int selectedDoctorID = -1;

        public FormManageDoctor()
        {
            InitializeComponent();
            this.Load += FormManageDoctor_Load;
            this.dgvDoctor.CellClick += dgvDoctor_CellContentClick;
            this.btnSearch.Click += btnSearch_Click;
            this.btnAdd.Click += btnAdd_Click;
            this.btnUpdate.Click += btnUpdate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void FormManageDoctor_Load(object sender, EventArgs e)
        {
            LoadSpecializationsIntoCombo();
            LoadAllDoctors();
            ClearFields();
        }

        private void LoadSpecializationsIntoCombo()
        {
            try
            {
                string query = "SELECT SpecializationID, SpecializationName FROM Specializations ORDER BY SpecializationName";
                DataTable dt = DatabaseHelper.ExecuteQuery(query);

                cbSpecialization.DataSource = dt;
                cbSpecialization.DisplayMember = "SpecializationName";
                cbSpecialization.ValueMember = "SpecializationID";
                cbSpecialization.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading specializations: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllDoctors()
        {
            try
            {
                string query = @"SELECT d.DoctorID, d.FullName, s.SpecializationName, 
                                d.Email, d.PhoneNumber, d.ConsultationFee
                                FROM Doctors d
                                INNER JOIN Specializations s ON d.SpecializationID = s.SpecializationID
                                ORDER BY d.DoctorID";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvDoctor.DataSource = dt;

                // Hide DoctorID column
                if (dgvDoctor.Columns["DoctorID"] != null)
                    dgvDoctor.Columns["DoctorID"].Visible = false;

                // Set column headers
                if (dgvDoctor.Columns["FullName"] != null)
                    dgvDoctor.Columns["FullName"].HeaderText = "Full Name";
                if (dgvDoctor.Columns["SpecializationName"] != null)
                    dgvDoctor.Columns["SpecializationName"].HeaderText = "Specialization";
                if (dgvDoctor.Columns["PhoneNumber"] != null)
                    dgvDoctor.Columns["PhoneNumber"].HeaderText = "Phone No.";
                if (dgvDoctor.Columns["ConsultationFee"] != null)
                    dgvDoctor.Columns["ConsultationFee"].HeaderText = "Fee (RM)";

                // Auto resize columns
                dgvDoctor.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctors: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvDoctor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // Get DoctorID
                    selectedDoctorID = Convert.ToInt32(dgvDoctor.Rows[e.RowIndex].Cells["DoctorID"].Value);
                    txtDoctorID.Text = selectedDoctorID.ToString();

                    // Load data to textboxes
                    txtFullName.Text = dgvDoctor.Rows[e.RowIndex].Cells["FullName"].Value?.ToString() ?? "";
                    txtEmail.Text = dgvDoctor.Rows[e.RowIndex].Cells["Email"].Value?.ToString() ?? "";
                    txtPhone.Text = dgvDoctor.Rows[e.RowIndex].Cells["PhoneNumber"].Value?.ToString() ?? "";
                    txtFee.Text = dgvDoctor.Rows[e.RowIndex].Cells["ConsultationFee"].Value?.ToString() ?? "";

                    // Load specialization
                    string specializationName = dgvDoctor.Rows[e.RowIndex].Cells["SpecializationName"].Value?.ToString() ?? "";
                    foreach (DataRowView item in cbSpecialization.Items)
                    {
                        if (item["SpecializationName"].ToString() == specializationName)
                        {
                            cbSpecialization.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading doctor data: {ex.Message}", "Error",
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

                // Check if doctor already exists (by Email)
                if (DoctorExists())
                {
                    MessageBox.Show("Doctor with this Email already exists!",
                                   "Validation Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                    return;
                }

                // Insert doctor
                string query = @"INSERT INTO Doctors (FullName, SpecializationID, Email, PhoneNumber, ConsultationFee) 
                                VALUES (@FullName, @SpecializationID, @Email, @PhoneNumber, @ConsultationFee)";

                SqlParameter[] parameters = {
                    new SqlParameter("@FullName", txtFullName.Text.Trim()),
                    new SqlParameter("@SpecializationID", Convert.ToInt32(cbSpecialization.SelectedValue)),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@PhoneNumber", txtPhone.Text.Trim()),
                    new SqlParameter("@ConsultationFee", Convert.ToDecimal(txtFee.Text.Trim()))
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Doctor added successfully!", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllDoctors();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to add doctor!", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding doctor: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedDoctorID == -1)
                {
                    MessageBox.Show("Please select a doctor to update!", "Validation",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateFields())
                    return;

                // Update doctor
                string query = @"UPDATE Doctors 
                                SET FullName = @FullName, 
                                    SpecializationID = @SpecializationID, 
                                    Email = @Email, 
                                    PhoneNumber = @PhoneNumber, 
                                    ConsultationFee = @ConsultationFee 
                                WHERE DoctorID = @DoctorID";

                SqlParameter[] parameters = {
                    new SqlParameter("@FullName", txtFullName.Text.Trim()),
                    new SqlParameter("@SpecializationID", Convert.ToInt32(cbSpecialization.SelectedValue)),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@PhoneNumber", txtPhone.Text.Trim()),
                    new SqlParameter("@ConsultationFee", Convert.ToDecimal(txtFee.Text.Trim())),
                    new SqlParameter("@DoctorID", selectedDoctorID)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Doctor updated successfully!", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllDoctors();
                    ClearFields();
                    selectedDoctorID = -1;
                }
                else
                {
                    MessageBox.Show("Failed to update doctor!", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating doctor: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            selectedDoctorID = -1;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedDoctorID == -1)
                {
                    MessageBox.Show("Please select a doctor to delete!", "Validation",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm deletion
                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete doctor: {txtFullName.Text}?",
                                                       "Confirm Delete",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Check if doctor has appointments
                    string checkQuery = "SELECT COUNT(*) FROM Appointments WHERE DoctorID = @DoctorID";
                    SqlParameter[] checkParams = {
                        new SqlParameter("@DoctorID", selectedDoctorID)
                    };

                    DataTable dt = DatabaseHelper.ExecuteQuery(checkQuery, checkParams);
                    int appointmentCount = Convert.ToInt32(dt.Rows[0][0]);

                    if (appointmentCount > 0)
                    {
                        MessageBox.Show($"Cannot delete doctor! They have {appointmentCount} appointment(s).",
                                       "Delete Failed",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                        return;
                    }

                    // Delete doctor
                    string query = "DELETE FROM Doctors WHERE DoctorID = @DoctorID";
                    SqlParameter[] parameters = {
                        new SqlParameter("@DoctorID", selectedDoctorID)
                    };

                    int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                    if (result > 0)
                    {
                        MessageBox.Show("Doctor deleted successfully!", "Success",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllDoctors();
                        ClearFields();
                        selectedDoctorID = -1;
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete doctor!", "Error",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting doctor: {ex.Message}", "Error",
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
                    LoadAllDoctors();
                    return;
                }

                string query = @"SELECT d.DoctorID, d.FullName, s.SpecializationName, 
                                d.Email, d.PhoneNumber, d.ConsultationFee
                                FROM Doctors d
                                INNER JOIN Specializations s ON d.SpecializationID = s.SpecializationID
                                WHERE d.FullName LIKE @Keyword 
                                OR d.Email LIKE @Keyword 
                                OR d.PhoneNumber LIKE @Keyword
                                OR s.SpecializationName LIKE @Keyword
                                ORDER BY d.DoctorID";

                SqlParameter[] parameters = {
                    new SqlParameter("@Keyword", "%" + keyword + "%")
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvDoctor.DataSource = dt;

                // Hide DoctorID column
                if (dgvDoctor.Columns["DoctorID"] != null)
                    dgvDoctor.Columns["DoctorID"].Visible = false;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No doctors found!", "Search Result",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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

            // Check Specialization
            if (cbSpecialization.SelectedIndex == -1)
            {
                MessageBox.Show("Please select Specialization!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbSpecialization.Focus();
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

            // Check Consultation Fee
            if (string.IsNullOrWhiteSpace(txtFee.Text))
            {
                MessageBox.Show("Please enter Consultation Fee!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFee.Focus();
                return false;
            }

            // Validate Fee is numeric
            decimal fee;
            if (!decimal.TryParse(txtFee.Text, out fee))
            {
                MessageBox.Show("Please enter a valid Consultation Fee (numbers only)!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFee.Focus();
                txtFee.SelectAll();
                return false;
            }

            return true;
        }

        private bool DoctorExists()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Doctors WHERE Email = @Email";

                // If updating, exclude current doctor
                if (selectedDoctorID != -1)
                {
                    query += " AND DoctorID != @DoctorID";
                }

                SqlParameter[] parameters = {
                    new SqlParameter("@Email", txtEmail.Text.Trim())
                };

                if (selectedDoctorID != -1)
                {
                    Array.Resize(ref parameters, 2);
                    parameters[1] = new SqlParameter("@DoctorID", selectedDoctorID);
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

        private void ClearFields()
        {
            txtDoctorID.Clear();
            txtFullName.Clear();
            cbSpecialization.SelectedIndex = -1;
            txtEmail.Clear();
            txtPhone.Clear();
            txtFee.Clear();
            txtSearch.Clear();
            selectedDoctorID = -1;
        }

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManagePatient patientForm = new FormManagePatient();
            patientForm.Show();
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

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewReport reportForm = new FormViewReport();
            reportForm.Show();
            this.Hide();
        }
    }
}

