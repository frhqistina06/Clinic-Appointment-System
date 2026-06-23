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
using System.Windows.Forms.DataVisualization.Charting;

namespace ClinicAppointmentSystem
{
    public partial class FormViewReport : Form
    {
        // ✅ FIX IDE0044 - Add readonly
        private readonly string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;Integrated Security=True";

        public FormViewReport()
        {
            InitializeComponent();
            this.Load += FormViewReport_Load;
        }

        private void FormViewReport_Load(object sender, EventArgs e)
        {
            LoadReservationStatusChart();
            LoadEarningsChart();
        }

        // ============================================
        // 1. PIE CHART - RESERVATION STATUS
        // ============================================
        private void LoadReservationStatusChart()
        {
            try
            {
                string query = @"SELECT 
                                    Status, 
                                    COUNT(*) AS Count 
                                FROM Appointments 
                                WHERE Status IN ('Pending', 'Completed', 'Cancelled')
                                GROUP BY Status";

                DataTable dt = GetData(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    dt = GetSampleStatusData();
                }

                chartStatus.Series.Clear();
                chartStatus.Titles.Clear();
                chartStatus.ChartAreas.Clear();

                // ✅ FIX IDE0017 - Object Initializer
                ChartArea chartArea = new ChartArea
                {
                    Name = "PieArea"
                };
                chartStatus.ChartAreas.Add(chartArea);

                // ✅ FIX IDE0017 - Object Initializer
                Title title = new Title
                {
                    Text = "Reservation Status Distribution",
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Alignment = ContentAlignment.TopCenter
                };
                chartStatus.Titles.Add(title);

                // ✅ FIX IDE0017 - Object Initializer
                Series series = new Series
                {
                    Name = "Status",
                    ChartType = SeriesChartType.Pie,
                    ChartArea = "PieArea",
                    IsValueShownAsLabel = true,
                    Label = "#VALY (#PERCENT)",
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    LabelForeColor = Color.Black
                };

                Color[] colors = { Color.Orange, Color.Green, Color.Red };

                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string status = row["Status"].ToString();
                    int count = Convert.ToInt32(row["Count"]);
                    int index = series.Points.AddXY(status, count);
                    series.Points[index].Color = colors[i % colors.Length];
                    i++;
                }

                chartStatus.Series.Add(series);

                // ✅ FIX IDE0017 - Object Initializer
                Legend legend = new Legend
                {
                    Name = "Legend",
                    Docking = Docking.Bottom
                };
                chartStatus.Legends.Add(legend);

                chartStatus.Refresh();
                chartStatus.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading reservation chart: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================
        // 2. BAR CHART - EARNINGS PER SPECIALIZATION
        // ============================================
        private void LoadEarningsChart()
        {
            try
            {
                string query = @"SELECT TOP 6
                                    s.SpecializationName AS Specialization,
                                    SUM(a.Price) AS TotalEarnings 
                                FROM Appointments a
                                INNER JOIN Doctors d ON a.DoctorID = d.DoctorID
                                INNER JOIN Specialization s ON d.SpecializationID = s.SpecializationID
                                WHERE a.Price IS NOT NULL
                                GROUP BY s.SpecializationName
                                ORDER BY TotalEarnings DESC";

                DataTable dt = GetData(query);

                if (dt == null || dt.Rows.Count == 0)
                {
                    dt = GetSampleEarningsData();
                }

                chartEarnings.Series.Clear();
                chartEarnings.Titles.Clear();
                chartEarnings.ChartAreas.Clear();

                // ✅ FIX IDE0017 - Object Initializer
                ChartArea chartArea = new ChartArea
                {
                    Name = "BarArea"
                };

                // Set Axis properties
                chartArea.AxisX.Title = "Specialization";
                chartArea.AxisX.TitleFont = new Font("Arial", 10, FontStyle.Bold);
                chartArea.AxisX.TitleForeColor = Color.Black;
                chartArea.AxisX.LabelStyle.Font = new Font("Arial", 9);
                chartArea.AxisX.Interval = 1;
                chartArea.AxisX.IsMarginVisible = true;

                chartArea.AxisY.Title = "Earnings (RM)";
                chartArea.AxisY.TitleFont = new Font("Arial", 10, FontStyle.Bold);
                chartArea.AxisY.TitleForeColor = Color.Black;
                chartArea.AxisY.LabelStyle.Font = new Font("Arial", 9);
                chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;

                chartEarnings.ChartAreas.Add(chartArea);

                // ✅ FIX IDE0017 - Object Initializer
                Title title = new Title
                {
                    Text = "Earnings per Specialization",
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    ForeColor = Color.Black,
                    Alignment = ContentAlignment.TopCenter
                };
                chartEarnings.Titles.Add(title);

                // ✅ FIX IDE0017 - Object Initializer
                Series series = new Series
                {
                    Name = "Earnings",
                    ChartType = SeriesChartType.Column,
                    ChartArea = "BarArea",
                    IsValueShownAsLabel = true,
                    Label = "RM#VALY",
                    Font = new Font("Arial", 9, FontStyle.Bold),
                    LabelForeColor = Color.DarkBlue
                };

                Color[] colors = {
                    Color.DarkBlue, Color.ForestGreen, Color.OrangeRed,
                    Color.Purple, Color.SteelBlue, Color.Gold
                };

                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string specialization = row["Specialization"].ToString();
                    decimal totalEarnings = Convert.ToDecimal(row["TotalEarnings"]);
                    int index = series.Points.AddXY(specialization, totalEarnings);
                    series.Points[index].Color = colors[i % colors.Length];
                    i++;
                }

                chartEarnings.Series.Add(series);

                // ✅ FIX IDE0017 - Object Initializer
                Legend legend = new Legend
                {
                    Name = "Legend",
                    Docking = Docking.Bottom
                };
                chartEarnings.Legends.Add(legend);

                chartEarnings.Refresh();
                chartEarnings.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading earnings chart: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================================
        // SAMPLE DATA
        // ============================================
        private DataTable GetSampleStatusData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Count", typeof(int));
            dt.Rows.Add("Pending", 5);
            dt.Rows.Add("Completed", 12);
            dt.Rows.Add("Cancelled", 3);
            return dt;
        }

        private DataTable GetSampleEarningsData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Specialization", typeof(string));
            dt.Columns.Add("TotalEarnings", typeof(decimal));
            dt.Rows.Add("Cardiology", 1500);
            dt.Rows.Add("Dermatology", 1200);
            dt.Rows.Add("Orthopedics", 900);
            dt.Rows.Add("Pediatrics", 750);
            dt.Rows.Add("Neurology", 600);
            dt.Rows.Add("Ophthalmology", 400);
            return dt;
        }

        // ============================================
        // DATABASE HELPER
        // ============================================
        private DataTable GetData(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    conn.Open();
                    da.Fill(dt);
                }
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message,
                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
        }

        // ============================================
        // GENERATE REPORT BUTTON - FIX IDE1006
        // ============================================
        private void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                LoadReservationStatusChart();
                LoadEarningsChart();
                Cursor = Cursors.Default;

                MessageBox.Show("Report generated successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error generating report: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ============================================
        // MENU ITEMS - FIX IDE1006
        // ============================================
        private void DoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageDoctor doctorForm = new FormManageDoctor();
            doctorForm.Show();
            this.Hide();
        }

        private void AppointmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageAppointment appointmentForm = new FormManageAppointment();
            appointmentForm.Show();
            this.Hide();
        }

        private void SpecializationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManageSpecialization specializationForm = new FormManageSpecialization();
            specializationForm.Show();
            this.Hide();
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

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