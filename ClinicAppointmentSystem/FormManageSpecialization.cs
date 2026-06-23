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
    public partial class FormManageSpecialization : Form
    {
        private int selectedSpecializationID = -1;

        public FormManageSpecialization()
        {
            InitializeComponent();
            this.Load += FormManageSpecialization_Load;
            this.dgvSpecialization.CellClick += dgvSpecialization_CellContentClick;
            this.btnSearch.Click += btnSearch_Click;
            this.btnAdd.Click += btnAdd_Click;
            this.btnUpdate.Click += btnUpdate_Click;
            this.btnDelete.Click += btnDelete_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

                string query = @"SELECT SpecializationID, 
                                SpecializationName, 
                                Fee
                                FROM Specializations 
                                WHERE CreatedAt BETWEEN @FromDate AND @ToDate
                                ORDER BY SpecializationID";

                SqlParameter[] parameters = {
                    new SqlParameter("@FromDate", fromDate),
                    new SqlParameter("@ToDate", toDate)
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvSpecialization.DataSource = dt;

                if (dgvSpecialization.Columns["SpecializationID"] != null)
                    dgvSpecialization.Columns["SpecializationID"].Visible = false;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No specializations found in this date range!", "Search Result",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Found {dt.Rows.Count} specialization(s)!", "Search Result",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LoadAllSpecializations()
        {
            try
            {
                string query = @"SELECT SpecializationID, 
                                SpecializationName, 
                                Fee
                                FROM Specializations
                                ORDER BY SpecializationID";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvSpecialization.DataSource = dt;

                // Hide SpecializationID column
                if (dgvSpecialization.Columns["SpecializationID"] != null)
                    dgvSpecialization.Columns["SpecializationID"].Visible = false;

                // Set column headers
                if (dgvSpecialization.Columns["SpecializationName"] != null)
                    dgvSpecialization.Columns["SpecializationName"].HeaderText = "Specialization";
                if (dgvSpecialization.Columns["Fee"] != null)
                    dgvSpecialization.Columns["Fee"].HeaderText = "Fee (RM)";
                if (dgvSpecialization.Columns["CreatedAt"] != null)
                    dgvSpecialization.Columns["CreatedAt"].HeaderText = "Created Date";

                dgvSpecialization.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading specializations: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
            selectedSpecializationID = -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate fields
                if (!ValidateFields())
                    return;

                // Check if specialization already exists
                if (SpecializationExists())
                {
                    MessageBox.Show("Specialization already exists!",
                                   "Validation Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                    return;
                }

                // Insert specialization
                string query = @"INSERT INTO Specializations (SpecializationName, Fee) 
                                VALUES (@SpecializationName, @Fee)";

                SqlParameter[] parameters = {
                    new SqlParameter("@SpecializationName", txtSpecialization.Text.Trim()),
                    new SqlParameter("@Fee", Convert.ToDecimal(txtFee.Text.Trim()))
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Specialization added successfully!", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllSpecializations();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to add specialization!", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding specialization: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSpecializationID == -1)
                {
                    MessageBox.Show("Please select a specialization to delete!", "Validation",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirm deletion
                DialogResult confirm = MessageBox.Show($"Are you sure you want to delete specialization: {txtSpecialization.Text}?",
                                                       "Confirm Delete",
                                                       MessageBoxButtons.YesNo,
                                                       MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Check if specialization is used by doctors
                    string checkQuery = "SELECT COUNT(*) FROM Doctors WHERE SpecializationID = @SpecializationID";
                    SqlParameter[] checkParams = {
                        new SqlParameter("@SpecializationID", selectedSpecializationID)
                    };

                    DataTable dt = DatabaseHelper.ExecuteQuery(checkQuery, checkParams);
                    int doctorCount = Convert.ToInt32(dt.Rows[0][0]);

                    if (doctorCount > 0)
                    {
                        MessageBox.Show($"Cannot delete specialization! It is used by {doctorCount} doctor(s).",
                                       "Delete Failed",
                                       MessageBoxButtons.OK,
                                       MessageBoxIcon.Warning);
                        return;
                    }

                    // Delete specialization
                    string query = "DELETE FROM Specializations WHERE SpecializationID = @SpecializationID";
                    SqlParameter[] parameters = {
                        new SqlParameter("@SpecializationID", selectedSpecializationID)
                    };

                    int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                    if (result > 0)
                    {
                        MessageBox.Show("Specialization deleted successfully!", "Success",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllSpecializations();
                        ClearFields();
                        selectedSpecializationID = -1;
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete specialization!", "Error",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting specialization: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSpecializationID == -1)
                {
                    MessageBox.Show("Please select a specialization to update!", "Validation",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateFields())
                    return;

                // Update specialization
                string query = @"UPDATE Specializations 
                                SET SpecializationName = @SpecializationName, 
                                    Fee = @Fee 
                                WHERE SpecializationID = @SpecializationID";

                SqlParameter[] parameters = {
                    new SqlParameter("@SpecializationName", txtSpecialization.Text.Trim()),
                    new SqlParameter("@Fee", Convert.ToDecimal(txtFee.Text.Trim())),
                    new SqlParameter("@SpecializationID", selectedSpecializationID)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Specialization updated successfully!", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllSpecializations();
                    ClearFields();
                    selectedSpecializationID = -1;
                }
                else
                {
                    MessageBox.Show("Failed to update specialization!", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating specialization: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvSpecialization_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // Get SpecializationID
                    selectedSpecializationID = Convert.ToInt32(dgvSpecialization.Rows[e.RowIndex].Cells["SpecializationID"].Value);
                    

                    // Load data to textboxes
                    txtSpecialization.Text = dgvSpecialization.Rows[e.RowIndex].Cells["SpecializationName"].Value?.ToString() ?? "";
                    txtFee.Text = dgvSpecialization.Rows[e.RowIndex].Cells["Fee"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading specialization data: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormManageSpecialization_Load(object sender, EventArgs e)
        {
            LoadAllSpecializations();
            ClearFields();
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;
        }

        private bool ValidateFields()
        {
            // Check Specialization Name
            if (string.IsNullOrWhiteSpace(txtSpecialization.Text))
            {
                MessageBox.Show("Please enter Specialization name!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSpecialization.Focus();
                return false;
            }

            // Check Fee
            if (string.IsNullOrWhiteSpace(txtFee.Text))
            {
                MessageBox.Show("Please enter Fee!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFee.Focus();
                return false;
            }

            // Validate Fee is numeric
            decimal fee;
            if (!decimal.TryParse(txtFee.Text, out fee))
            {
                MessageBox.Show("Please enter a valid Fee (numbers only)!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFee.Focus();
                txtFee.SelectAll();
                return false;
            }

            if (fee <= 0)
            {
                MessageBox.Show("Fee must be greater than 0!", "Validation",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFee.Focus();
                txtFee.SelectAll();
                return false;
            }

            return true;
        }

        private bool SpecializationExists()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Specializations WHERE SpecializationName = @SpecializationName";

                // If updating, exclude current specialization
                if (selectedSpecializationID != -1)
                {
                    query += " AND SpecializationID != @SpecializationID";
                }

                SqlParameter[] parameters = {
                    new SqlParameter("@SpecializationName", txtSpecialization.Text.Trim())
                };

                if (selectedSpecializationID != -1)
                {
                    Array.Resize(ref parameters, 2);
                    parameters[1] = new SqlParameter("@SpecializationID", selectedSpecializationID);
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

        private void ClearFields()
        {
           
            txtSpecialization.Clear();
            txtFee.Clear();
            dtpFrom.Value = DateTime.Now.AddDays(-30);
            dtpTo.Value = DateTime.Now;
            selectedSpecializationID = -1;
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

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormViewReport reportForm = new FormViewReport();
            reportForm.Show();
            this.Hide();
        }
    }
}
