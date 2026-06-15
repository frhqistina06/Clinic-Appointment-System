namespace ClinicAppointmentSystem
{
    partial class FormManageDoctor
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvDoctor = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblIC = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblConsultationFee = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.managePatientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specializationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feedbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbSpecialization = new System.Windows.Forms.ComboBox();
            this.lblRM = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctor)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(199, 416);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(204, 22);
            this.txtAddress.TabIndex = 70;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(32, 95);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(77, 25);
            this.lblSearch.TabIndex = 53;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(115, 98);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(205, 22);
            this.txtSearch.TabIndex = 54;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearch.Location = new System.Drawing.Point(350, 90);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 39);
            this.btnSearch.TabIndex = 55;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // dgvDoctor
            // 
            this.dgvDoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctor.Location = new System.Drawing.Point(20, 135);
            this.dgvDoctor.Name = "dgvDoctor";
            this.dgvDoctor.RowHeadersWidth = 51;
            this.dgvDoctor.RowTemplate.Height = 24;
            this.dgvDoctor.Size = new System.Drawing.Size(761, 130);
            this.dgvDoctor.TabIndex = 56;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAdd.Location = new System.Drawing.Point(697, 273);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 39);
            this.btnAdd.TabIndex = 57;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnUpdate.Location = new System.Drawing.Point(697, 318);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 39);
            this.btnUpdate.TabIndex = 58;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCancel.Location = new System.Drawing.Point(697, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 39);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFullName.Location = new System.Drawing.Point(86, 286);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(89, 19);
            this.lblFullName.TabIndex = 61;
            this.lblFullName.Text = "Full Name:";
            // 
            // lblIC
            // 
            this.lblIC.AutoSize = true;
            this.lblIC.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIC.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIC.Location = new System.Drawing.Point(58, 318);
            this.lblIC.Name = "lblIC";
            this.lblIC.Size = new System.Drawing.Size(117, 19);
            this.lblIC.TabIndex = 62;
            this.lblIC.Text = "Specialization:";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(199, 286);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(204, 22);
            this.txtFullName.TabIndex = 63;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEmail.Location = new System.Drawing.Point(121, 350);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(54, 19);
            this.lblEmail.TabIndex = 65;
            this.lblEmail.Text = "Email:";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPhone.Location = new System.Drawing.Point(86, 383);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(89, 19);
            this.lblPhone.TabIndex = 66;
            this.lblPhone.Text = "No.Phone:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(200, 350);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(204, 22);
            this.txtEmail.TabIndex = 67;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(200, 383);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(204, 22);
            this.txtPhone.TabIndex = 68;
            // 
            // lblConsultationFee
            // 
            this.lblConsultationFee.AutoSize = true;
            this.lblConsultationFee.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConsultationFee.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblConsultationFee.Location = new System.Drawing.Point(36, 416);
            this.lblConsultationFee.Name = "lblConsultationFee";
            this.lblConsultationFee.Size = new System.Drawing.Size(139, 19);
            this.lblConsultationFee.TabIndex = 69;
            this.lblConsultationFee.Text = "Consultation Fee:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Symbol", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(236, 33);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(311, 54);
            this.lblTitle.TabIndex = 71;
            this.lblTitle.Text = "Manage Doctor";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.managePatientToolStripMenuItem,
            this.viewReportToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 72;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // managePatientToolStripMenuItem
            // 
            this.managePatientToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.patientToolStripMenuItem,
            this.doctorToolStripMenuItem,
            this.appointmentToolStripMenuItem,
            this.specializationToolStripMenuItem});
            this.managePatientToolStripMenuItem.Name = "managePatientToolStripMenuItem";
            this.managePatientToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.managePatientToolStripMenuItem.Text = "Manage";
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.patientToolStripMenuItem.Text = "Patient";
            // 
            // doctorToolStripMenuItem
            // 
            this.doctorToolStripMenuItem.Name = "doctorToolStripMenuItem";
            this.doctorToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.doctorToolStripMenuItem.Text = "Doctor";
            // 
            // appointmentToolStripMenuItem
            // 
            this.appointmentToolStripMenuItem.Name = "appointmentToolStripMenuItem";
            this.appointmentToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.appointmentToolStripMenuItem.Text = "Appointment";
            // 
            // specializationToolStripMenuItem
            // 
            this.specializationToolStripMenuItem.Name = "specializationToolStripMenuItem";
            this.specializationToolStripMenuItem.Size = new System.Drawing.Size(185, 26);
            this.specializationToolStripMenuItem.Text = "Specialization";
            // 
            // viewReportToolStripMenuItem
            // 
            this.viewReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToolStripMenuItem,
            this.feedbackToolStripMenuItem});
            this.viewReportToolStripMenuItem.Name = "viewReportToolStripMenuItem";
            this.viewReportToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewReportToolStripMenuItem.Text = "View";
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // feedbackToolStripMenuItem
            // 
            this.feedbackToolStripMenuItem.Name = "feedbackToolStripMenuItem";
            this.feedbackToolStripMenuItem.Size = new System.Drawing.Size(155, 26);
            this.feedbackToolStripMenuItem.Text = "Feedback";
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.logOutToolStripMenuItem.Text = "Log Out";
            // 
            // cbSpecialization
            // 
            this.cbSpecialization.FormattingEnabled = true;
            this.cbSpecialization.Location = new System.Drawing.Point(200, 318);
            this.cbSpecialization.Name = "cbSpecialization";
            this.cbSpecialization.Size = new System.Drawing.Size(203, 24);
            this.cbSpecialization.TabIndex = 73;
            // 
            // lblRM
            // 
            this.lblRM.AutoSize = true;
            this.lblRM.Location = new System.Drawing.Point(416, 422);
            this.lblRM.Name = "lblRM";
            this.lblRM.Size = new System.Drawing.Size(28, 16);
            this.lblRM.TabIndex = 74;
            this.lblRM.Text = "RM";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDelete.Location = new System.Drawing.Point(697, 407);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 39);
            this.btnDelete.TabIndex = 75;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // FormManageDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblRM);
            this.Controls.Add(this.cbSpecialization);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblConsultationFee);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblIC);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvDoctor);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Name = "FormManageDoctor";
            this.Text = "FormManageDoctor";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctor)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvDoctor;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblIC;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblConsultationFee;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem managePatientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doctorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specializationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem feedbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbSpecialization;
        private System.Windows.Forms.Label lblRM;
        private System.Windows.Forms.Button btnDelete;
    }
}