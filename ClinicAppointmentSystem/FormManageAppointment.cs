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
    public partial class FormManageAppointment : Form
    {


        private int selectedAppointmentID = -1;

        public void RefreshAppointments()
        {
            LoadAllAppointments(); // Panggil method load data
        }
        public FormManageAppointment()
        {
            InitializeComponent();
            this.Load += FormManageAppointment_Load;
            this.dgvAppointment.CellClick += dgvAppointment_CellContentClick;
            this.btnSearch.Click += btnSearch_Click;
            this.btnApprove.Click += btnApprove_Click;
            this.btnReject.Click += btnReject_Click;
            this.btnComplete.Click += btnComplete_Click;
            this.btnReschedule.Click += btnReschedule_Click;
            this.btnCancel.Click += btnCancel_Click;
        }

        private void FormManageAppointment_Load(object sender, EventArgs e)
        {
            LoadAllAppointments();
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
        }



        private void LoadAllAppointments()
        {
            try
            {
                string query = @"SELECT a.AppointmentID, 
                                p.FullName AS PatientName,
                                d.FullName AS DoctorName,
                                s.SpecializationName,
                                a.AppointmentDate,
                                a.AppointmentTime,
                                a.Symptoms,
                                a.Status,
                                a.PaymentStatus,
                                a.PaymentMethod,
                                a.Price
                                FROM Appointments a
                                INNER JOIN Patients p ON a.PatientID = p.PatientID
                                INNER JOIN Doctors d ON a.DoctorID = d.DoctorID
                                INNER JOIN Specializations s ON d.SpecializationID = s.SpecializationID
                                ORDER BY a.AppointmentID";

                DataTable dt = DatabaseHelper.ExecuteQuery(query);
                dgvAppointment.DataSource = dt;

                // Hide AppointmentID column
                if (dgvAppointment.Columns["AppointmentID"] != null)
                    dgvAppointment.Columns["AppointmentID"].Visible = false;

                // Set column headers
                if (dgvAppointment.Columns["PatientName"] != null)
                    dgvAppointment.Columns["PatientName"].HeaderText = "Patient Name";
                if (dgvAppointment.Columns["DoctorName"] != null)
                    dgvAppointment.Columns["DoctorName"].HeaderText = "Doctor";
                if (dgvAppointment.Columns["SpecializationName"] != null)
                    dgvAppointment.Columns["SpecializationName"].HeaderText = "Specialization";
                if (dgvAppointment.Columns["AppointmentDate"] != null)
                    dgvAppointment.Columns["AppointmentDate"].HeaderText = "Date";
                if (dgvAppointment.Columns["AppointmentTime"] != null)
                    dgvAppointment.Columns["AppointmentTime"].HeaderText = "Time";
                if (dgvAppointment.Columns["Status"] != null)
                    dgvAppointment.Columns["Status"].HeaderText = "Status";
                if (dgvAppointment.Columns["PaymentStatus"] != null)
                    dgvAppointment.Columns["PaymentStatus"].HeaderText = "Payment";
                if (dgvAppointment.Columns["PaymentMethod"] != null)
                    dgvAppointment.Columns["PaymentMethod"].HeaderText = "Method";
                if (dgvAppointment.Columns["Price"] != null)
                    dgvAppointment.Columns["Price"].HeaderText = "Price";

                // Color code status
                foreach (DataGridViewRow row in dgvAppointment.Rows)
                {
                    string status = row.Cells["Status"].Value?.ToString() ?? "";
                    switch (status)
                    {
                        case "Pending":
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                        case "Completed":
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case "Rejected":
                            row.DefaultCellStyle.BackColor = Color.LightPink;
                            break;
                        case "Rescheduled":
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                            break;
                        case "Cancelled":
                            row.DefaultCellStyle.BackColor = Color.LightGray;
                            break;
                    }
                }

                dgvAppointment.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}", "Error",
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
                    LoadAllAppointments();
                    return;
                }

                string query = @"SELECT a.AppointmentID, 
                                a.PatientID,
                                p.FullName AS PatientName,
                                a.DoctorID,
                                d.FullName AS DoctorName,
                                s.SpecializationName,
                                a.AppointmentDate,
                                a.AppointmentTime,
                                a.Symptoms,
                                a.Status,
                                a.PaymentStatus,
                                a.PaymentMethod,
                                a.Price
                                FROM Appointments a
                                INNER JOIN Patients p ON a.PatientID = p.PatientID
                                INNER JOIN Doctors d ON a.DoctorID = d.DoctorID
                                INNER JOIN Specializations s ON d.SpecializationID = s.SpecializationID
                                WHERE p.FullName LIKE @Keyword 
                                OR d.FullName LIKE @Keyword 
                                OR s.SpecializationName LIKE @Keyword
                                OR a.Status LIKE @Keyword
                                OR a.Symptoms LIKE @Keyword
                                OR a.AppointmentID LIKE @Keyword
                                ORDER BY a.AppointmentID";

                SqlParameter[] parameters = {
                    new SqlParameter("@Keyword", "%" + keyword + "%")
                };

                DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
                dgvAppointment.DataSource = dt;

                // Hide columns
                if (dgvAppointment.Columns["AppointmentID"] != null)
                    dgvAppointment.Columns["AppointmentID"].Visible = false;
                if (dgvAppointment.Columns["PatientID"] != null)
                    dgvAppointment.Columns["PatientID"].Visible = false;
                if (dgvAppointment.Columns["DoctorID"] != null)
                    dgvAppointment.Columns["DoctorID"].Visible = false;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No appointments found!", "Search Result",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvAppointment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (e.RowIndex >= 0)
                {
                    // Get AppointmentID
                    selectedAppointmentID = Convert.ToInt32(dgvAppointment.Rows[e.RowIndex].Cells["AppointmentID"].Value);
                    txtID.Text = selectedAppointmentID.ToString();

                    // Get PatientID
                    int patientID = Convert.ToInt32(dgvAppointment.Rows[e.RowIndex].Cells["PatientID"].Value);
                    txtPatientID.Text = patientID.ToString();

                    // Get DoctorID
                    int doctorID = Convert.ToInt32(dgvAppointment.Rows[e.RowIndex].Cells["DoctorID"].Value);
                    txtDoctorID.Text = doctorID.ToString();

                    // Get Date and Time
                    dtpDate.Value = Convert.ToDateTime(dgvAppointment.Rows[e.RowIndex].Cells["AppointmentDate"].Value);
                    dtpTime.Value = Convert.ToDateTime(dgvAppointment.Rows[e.RowIndex].Cells["AppointmentTime"].Value);


                    // Get Status
                    cbStatus.Text = dgvAppointment.Rows[e.RowIndex].Cells["Status"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointment data: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            UpdateAppointmentStatus("Pending");
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            UpdateAppointmentStatus("Rejected");

        }

        private void btnComplete_Click(object sender, EventArgs e)
        {

            UpdateAppointmentStatus("Completed");

        }

        private void btnReschedule_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedAppointmentID == -1)
                {
                    MessageBox.Show("Please select an appointment to reschedule!", "Validation",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show("Do you want to reschedule this appointment?\nDate: " + dtpDate.Value.ToShortDateString() + "\nTime: " + dtpTime.Value.ToShortTimeString(),
                                                      "Reschedule Appointment",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    UpdateAppointmentStatus("Rescheduled");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error rescheduling: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Are you sure you want to cancel this appointment?",
                                                  "Cancel Appointment",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                UpdateAppointmentStatus("Cancelled");
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateAppointmentStatus(string status)
        {
            try
            {
                if (selectedAppointmentID == -1)
                {
                    MessageBox.Show("Please select an appointment!", "Validation",
                                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = @"UPDATE Appointments 
                                SET Status = @Status, 
                                    UpdatedAt = GETDATE() 
                                WHERE AppointmentID = @AppointmentID";

                SqlParameter[] parameters = {
                    new SqlParameter("@Status", status),
                    new SqlParameter("@AppointmentID", selectedAppointmentID)
                };

                int result = DatabaseHelper.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show($"Appointment {status} successfully!", "Success",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllAppointments();
                    ClearFields();
                    selectedAppointmentID = -1;
                }
                else
                {
                    MessageBox.Show("Failed to update appointment status!", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ClearFields()
        {
            txtID.Clear();
            txtPatientID.Clear();
            txtDoctorID.Clear();
            dtpDate.Value = DateTime.Now;
            dtpTime.Value = DateTime.Now;
            cbStatus.Text = "";
            txtSearch.Clear();
            selectedAppointmentID = -1;
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
