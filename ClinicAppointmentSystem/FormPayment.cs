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
    public partial class FormPayment : Form
    {
        // STORE APPOINTMENT DATA
        private readonly string doctorName;
        private readonly string specialization;
        private readonly string symptoms;
        private readonly DateTime appointmentDate;
        private readonly DateTime appointmentTime;
        private readonly decimal consultationFee;

        // UNTUK SIMPAN KE DATABASE
        private readonly int patientId;
        private readonly int doctorId;



        // ✅ TAMBAH: STORE PAYMENT METHOD
        private string selectedPaymentMethod = "";
        private string selectedBank = "";

        // RECEIVE DATA FROM BOOK APPOINTMENT FORM
        public FormPayment(string doctor, string spec, string symp, DateTime date, DateTime time, decimal fee)
        {
            InitializeComponent();


        }

    };

}