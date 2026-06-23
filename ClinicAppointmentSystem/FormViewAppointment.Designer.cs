namespace ClinicAppointmentSystem
{
    partial class FormViewAppointment
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
            this.dgvViewPatient = new System.Windows.Forms.DataGridView();
            this.menuStripBookAppointment = new System.Windows.Forms.MenuStrip();
            this.bookAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAppointmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPatient)).BeginInit();
            this.menuStripBookAppointment.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvViewPatient
            // 
            this.dgvViewPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewPatient.Location = new System.Drawing.Point(105, 61);
            this.dgvViewPatient.Name = "dgvViewPatient";
            this.dgvViewPatient.RowHeadersWidth = 51;
            this.dgvViewPatient.RowTemplate.Height = 24;
            this.dgvViewPatient.Size = new System.Drawing.Size(545, 203);
            this.dgvViewPatient.TabIndex = 0;
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
            this.menuStripBookAppointment.TabIndex = 45;
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
            this.viewAppointmentToolStripMenuItem.Click += new System.EventHandler(this.viewAppointmentToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // FormViewAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStripBookAppointment);
            this.Controls.Add(this.dgvViewPatient);
            this.Name = "FormViewAppointment";
            this.Text = "FormViewAppointment";
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewPatient)).EndInit();
            this.menuStripBookAppointment.ResumeLayout(false);
            this.menuStripBookAppointment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvViewPatient;
        private System.Windows.Forms.MenuStrip menuStripBookAppointment;
        private System.Windows.Forms.ToolStripMenuItem bookAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAppointmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    }
}