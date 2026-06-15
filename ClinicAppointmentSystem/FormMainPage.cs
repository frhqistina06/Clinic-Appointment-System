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
    public partial class FormMainPage : Form
    {
        public FormMainPage()
        {
            InitializeComponent();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            FormLogin loginForm = new FormLogin();
            loginForm.Show();
            this.Hide(); //hide main page
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            FormAdminLogin loginForm = new FormAdminLogin();
            loginForm.Show();
            this.Hide(); //hide main page
        }
    }
}
