namespace ClinicAppointmentSystem
{
    partial class FormManageSpecialization
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtFee = new System.Windows.Forms.ComboBox();
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
            this.txtSpecialization = new System.Windows.Forms.TextBox();
            this.lblFee = new System.Windows.Forms.Label();
            this.lblSpecialization = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDelete.Location = new System.Drawing.Point(597, 320);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 39);
            this.btnDelete.TabIndex = 96;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // txtFee
            // 
            this.txtFee.FormattingEnabled = true;
            this.txtFee.Location = new System.Drawing.Point(200, 320);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(203, 24);
            this.txtFee.TabIndex = 94;
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
            this.menuStrip1.TabIndex = 93;
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
            // txtSpecialization
            // 
            this.txtSpecialization.Location = new System.Drawing.Point(199, 288);
            this.txtSpecialization.Name = "txtSpecialization";
            this.txtSpecialization.Size = new System.Drawing.Size(204, 22);
            this.txtSpecialization.TabIndex = 85;
            // 
            // lblFee
            // 
            this.lblFee.AutoSize = true;
            this.lblFee.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFee.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFee.Location = new System.Drawing.Point(95, 321);
            this.lblFee.Name = "lblFee";
            this.lblFee.Size = new System.Drawing.Size(80, 19);
            this.lblFee.TabIndex = 84;
            this.lblFee.Text = "Fee (RM):";
            // 
            // lblSpecialization
            // 
            this.lblSpecialization.AutoSize = true;
            this.lblSpecialization.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpecialization.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSpecialization.Location = new System.Drawing.Point(58, 289);
            this.lblSpecialization.Name = "lblSpecialization";
            this.lblSpecialization.Size = new System.Drawing.Size(117, 19);
            this.lblSpecialization.TabIndex = 83;
            this.lblSpecialization.Text = "Specialization:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCancel.Location = new System.Drawing.Point(597, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 39);
            this.btnCancel.TabIndex = 82;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnUpdate.Location = new System.Drawing.Point(697, 320);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(84, 39);
            this.btnUpdate.TabIndex = 81;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnAdd.Location = new System.Drawing.Point(697, 275);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 39);
            this.btnAdd.TabIndex = 80;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSearch.Location = new System.Drawing.Point(347, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 39);
            this.btnSearch.TabIndex = 78;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(115, 56);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(205, 22);
            this.txtFrom.TabIndex = 98;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(32, 53);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(65, 25);
            this.lblFrom.TabIndex = 97;
            this.lblFrom.Text = "From:";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(115, 92);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(205, 22);
            this.txtTo.TabIndex = 100;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(57, 89);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(40, 25);
            this.lblTo.TabIndex = 99;
            this.lblTo.Text = "To:";
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(20, 137);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.RowHeadersWidth = 51;
            this.dgvReport.RowTemplate.Height = 24;
            this.dgvReport.Size = new System.Drawing.Size(761, 130);
            this.dgvReport.TabIndex = 79;
            // 
            // FormManageSpecialization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtFee);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.txtSpecialization);
            this.Controls.Add(this.lblFee);
            this.Controls.Add(this.lblSpecialization);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.btnSearch);
            this.Name = "FormManageSpecialization";
            this.Text = "FormManageSpecialization";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox txtFee;
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
        private System.Windows.Forms.TextBox txtSpecialization;
        private System.Windows.Forms.Label lblFee;
        private System.Windows.Forms.Label lblSpecialization;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DataGridView dgvReport;
    }
}