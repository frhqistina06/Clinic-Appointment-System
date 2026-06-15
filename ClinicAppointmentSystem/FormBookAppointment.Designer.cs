namespace ClinicAppointmentSystem
{
    partial class FormBookAppointment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStripBookAppointment = new System.Windows.Forms.MenuStrip();
            this.bookAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtSymptoms = new System.Windows.Forms.TextBox();
            this.lblSymptoms = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.cboDoctor = new System.Windows.Forms.ComboBox();
            this.lblDoctor = new System.Windows.Forms.Label();
            this.cboSpecialization = new System.Windows.Forms.ComboBox();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.menuStripBookAppointment.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripBookAppointment
            // 
            this.menuStripBookAppointment.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripBookAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookAppointmentToolStripMenuItem,
            this.viewAppointmentToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStripBookAppointment.Location = new System.Drawing.Point(0, 0);
            this.menuStripBookAppointment.Name = "menuStripBookAppointment";
            this.menuStripBookAppointment.Size = new System.Drawing.Size(800, 28);
            this.menuStripBookAppointment.TabIndex = 44;
            this.menuStripBookAppointment.Text = "menuStrip1";
            // 
            // bookAppointmentToolStripMenuItem
            // 
            this.bookAppointmentToolStripMenuItem.Name = "bookAppointmentToolStripMenuItem";
            this.bookAppointmentToolStripMenuItem.Size = new System.Drawing.Size(149, 24);
            this.bookAppointmentToolStripMenuItem.Text = "Book Appointment";
            this.bookAppointmentToolStripMenuItem.Click += new System.EventHandler(this.bookAppointmentToolStripMenuItem_Click);
            // 
            // viewAppointmentToolStripMenuItem
            // 
            this.viewAppointmentToolStripMenuItem.Name = "viewAppointmentToolStripMenuItem";
            this.viewAppointmentToolStripMenuItem.Size = new System.Drawing.Size(147, 24);
            this.viewAppointmentToolStripMenuItem.Text = "View Appointment";
            this.viewAppointmentToolStripMenuItem.Click += new System.EventHandler(this.btnViewAppointment_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // dtpTime
            // 
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(163, 283);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(200, 22);
            this.dtpTime.TabIndex = 43;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSubmit.Location = new System.Drawing.Point(622, 397);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(129, 38);
            this.btnSubmit.TabIndex = 42;
            this.btnSubmit.Text = "Submit>>>";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnClear.Location = new System.Drawing.Point(409, 397);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(129, 38);
            this.btnClear.TabIndex = 41;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // txtSymptoms
            // 
            this.txtSymptoms.Location = new System.Drawing.Point(409, 197);
            this.txtSymptoms.Multiline = true;
            this.txtSymptoms.Name = "txtSymptoms";
            this.txtSymptoms.Size = new System.Drawing.Size(342, 157);
            this.txtSymptoms.TabIndex = 40;
            // 
            // lblSymptoms
            // 
            this.lblSymptoms.AutoSize = true;
            this.lblSymptoms.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSymptoms.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSymptoms.Location = new System.Drawing.Point(405, 162);
            this.lblSymptoms.Name = "lblSymptoms";
            this.lblSymptoms.Size = new System.Drawing.Size(94, 19);
            this.lblSymptoms.TabIndex = 39;
            this.lblSymptoms.Text = "Symptoms:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTime.Location = new System.Drawing.Point(24, 283);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(50, 19);
            this.lblTime.TabIndex = 38;
            this.lblTime.Text = "Time:";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(163, 242);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(200, 22);
            this.dtpDate.TabIndex = 37;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDate.Location = new System.Drawing.Point(24, 242);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(49, 19);
            this.lblDate.TabIndex = 36;
            this.lblDate.Text = "Date:";
            // 
            // cboDoctor
            // 
            this.cboDoctor.FormattingEnabled = true;
            this.cboDoctor.Location = new System.Drawing.Point(163, 202);
            this.cboDoctor.Name = "cboDoctor";
            this.cboDoctor.Size = new System.Drawing.Size(200, 24);
            this.cboDoctor.TabIndex = 35;
            // 
            // lblDoctor
            // 
            this.lblDoctor.AutoSize = true;
            this.lblDoctor.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoctor.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDoctor.Location = new System.Drawing.Point(24, 203);
            this.lblDoctor.Name = "lblDoctor";
            this.lblDoctor.Size = new System.Drawing.Size(65, 19);
            this.lblDoctor.TabIndex = 34;
            this.lblDoctor.Text = "Doctor:";
            // 
            // cboSpecialization
            // 
            this.cboSpecialization.FormattingEnabled = true;
            this.cboSpecialization.Location = new System.Drawing.Point(163, 165);
            this.cboSpecialization.Name = "cboSpecialization";
            this.cboSpecialization.Size = new System.Drawing.Size(200, 24);
            this.cboSpecialization.TabIndex = 33;
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialization.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSpecialization.Location = new System.Drawing.Point(24, 166);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(117, 19);
            this.lblSpecialization.TabIndex = 32;
            this.lblSpecialization.Text = "Specialization:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Symbol", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(120, 28);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(551, 81);
            this.lblTitle.TabIndex = 31;
            this.lblTitle.Text = "Book Appointment";
            // 
            // FormBookAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStripBookAppointment);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtSymptoms);
            this.Controls.Add(this.lblSymptoms);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.cboDoctor);
            this.Controls.Add(this.lblDoctor);
            this.Controls.Add(this.cboSpecialization);
            this.Controls.Add(this.lblSpecialization);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormBookAppointment";
            this.Text = "FormBookAppointment";
            this.menuStripBookAppointment.ResumeLayout(false);
            this.menuStripBookAppointment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripBookAppointment;
        private System.Windows.Forms.ToolStripMenuItem bookAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtSymptoms;
        private System.Windows.Forms.Label lblSymptoms;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.ComboBox cboDoctor;
        private System.Windows.Forms.Label lblDoctor;
        private System.Windows.Forms.ComboBox cboSpecialization;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.Label lblTitle;
    }
}