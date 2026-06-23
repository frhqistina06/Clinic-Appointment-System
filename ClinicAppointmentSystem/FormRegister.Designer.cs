namespace ClinicAppointmentSystem
{
    partial class FormRegister
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
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.chkShowPassword = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblLoginCreden = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.txtIC = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblContactInfo = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.lblIC = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblPersonalinfo = new System.Windows.Forms.Label();
            this.lblNoteCreateAcc = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rbFemale
            // 
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(256, 269);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(74, 20);
            this.rbFemale.TabIndex = 52;
            this.rbFemale.TabStop = true;
            this.rbFemale.Text = "Female";
            this.rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            this.rbMale.AutoSize = true;
            this.rbMale.Location = new System.Drawing.Point(169, 269);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(58, 20);
            this.rbMale.TabIndex = 51;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Male";
            this.rbMale.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnCreate.Location = new System.Drawing.Point(655, 402);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(129, 38);
            this.btnCreate.TabIndex = 50;
            this.btnCreate.Text = "Create Account";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreateAccount_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnBack.Location = new System.Drawing.Point(474, 402);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(135, 38);
            this.btnBack.TabIndex = 49;
            this.btnBack.Text = "Back to Login";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBackToLogin_Click);
            // 
            // chkShowPassword
            // 
            this.chkShowPassword.AutoSize = true;
            this.chkShowPassword.Location = new System.Drawing.Point(647, 267);
            this.chkShowPassword.Name = "chkShowPassword";
            this.chkShowPassword.Size = new System.Drawing.Size(125, 20);
            this.chkShowPassword.TabIndex = 48;
            this.chkShowPassword.Text = "Show Password";
            this.chkShowPassword.UseVisualStyleBackColor = true;
            this.chkShowPassword.CheckedChanged += new System.EventHandler(this.chkShowPassword_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(567, 232);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(204, 22);
            this.txtPassword.TabIndex = 47;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(568, 197);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(204, 22);
            this.txtUsername.TabIndex = 46;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPassword.Location = new System.Drawing.Point(422, 232);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(81, 19);
            this.lblPassword.TabIndex = 45;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUsername.Location = new System.Drawing.Point(422, 198);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(86, 19);
            this.lblUsername.TabIndex = 44;
            this.lblUsername.Text = "Username";
            // 
            // lblLoginCreden
            // 
            this.lblLoginCreden.AutoSize = true;
            this.lblLoginCreden.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginCreden.Location = new System.Drawing.Point(415, 131);
            this.lblLoginCreden.Name = "lblLoginCreden";
            this.lblLoginCreden.Size = new System.Drawing.Size(203, 25);
            this.lblLoginCreden.TabIndex = 43;
            this.lblLoginCreden.Text = "LOGIN CREDENTIALS";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(166, 391);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(204, 49);
            this.txtAddress.TabIndex = 42;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(167, 356);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(204, 22);
            this.txtPhone.TabIndex = 41;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Location = new System.Drawing.Point(170, 232);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(204, 22);
            this.dtpDOB.TabIndex = 40;
            // 
            // txtIC
            // 
            this.txtIC.Location = new System.Drawing.Point(170, 199);
            this.txtIC.Name = "txtIC";
            this.txtIC.Size = new System.Drawing.Size(204, 22);
            this.txtIC.TabIndex = 39;
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(170, 166);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(204, 22);
            this.txtFullName.TabIndex = 38;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblAddress.Location = new System.Drawing.Point(21, 391);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(119, 19);
            this.lblAddress.TabIndex = 37;
            this.lblAddress.Text = "Home Address";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblPhone.Location = new System.Drawing.Point(21, 357);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(125, 19);
            this.lblPhone.TabIndex = 36;
            this.lblPhone.Text = "Phone Number";
            // 
            // lblContactInfo
            // 
            this.lblContactInfo.AutoSize = true;
            this.lblContactInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactInfo.Location = new System.Drawing.Point(17, 321);
            this.lblContactInfo.Name = "lblContactInfo";
            this.lblContactInfo.Size = new System.Drawing.Size(246, 25);
            this.lblContactInfo.TabIndex = 35;
            this.lblContactInfo.Text = "CONTACT INFORMATION";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblGender.Location = new System.Drawing.Point(21, 269);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(64, 19);
            this.lblGender.TabIndex = 34;
            this.lblGender.Text = "Gender";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblDOB.Location = new System.Drawing.Point(20, 235);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(105, 19);
            this.lblDOB.TabIndex = 33;
            this.lblDOB.Text = "Date of Birth";
            // 
            // lblIC
            // 
            this.lblIC.AutoSize = true;
            this.lblIC.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIC.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblIC.Location = new System.Drawing.Point(20, 199);
            this.lblIC.Name = "lblIC";
            this.lblIC.Size = new System.Drawing.Size(24, 19);
            this.lblIC.TabIndex = 32;
            this.lblIC.Text = "IC";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFullName.Location = new System.Drawing.Point(20, 165);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(85, 19);
            this.lblFullName.TabIndex = 31;
            this.lblFullName.Text = "Full Name";
            // 
            // lblPersonalinfo
            // 
            this.lblPersonalinfo.AutoSize = true;
            this.lblPersonalinfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonalinfo.Location = new System.Drawing.Point(20, 131);
            this.lblPersonalinfo.Name = "lblPersonalinfo";
            this.lblPersonalinfo.Size = new System.Drawing.Size(256, 25);
            this.lblPersonalinfo.TabIndex = 30;
            this.lblPersonalinfo.Text = "PERSONAL INFORMATION";
            // 
            // lblNoteCreateAcc
            // 
            this.lblNoteCreateAcc.AutoSize = true;
            this.lblNoteCreateAcc.Font = new System.Drawing.Font("Segoe UI Symbol", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoteCreateAcc.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblNoteCreateAcc.Location = new System.Drawing.Point(221, 82);
            this.lblNoteCreateAcc.Name = "lblNoteCreateAcc";
            this.lblNoteCreateAcc.Size = new System.Drawing.Size(331, 25);
            this.lblNoteCreateAcc.TabIndex = 29;
            this.lblNoteCreateAcc.Text = "Fill in your details to register as a patient";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Symbol", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTitle.Location = new System.Drawing.Point(155, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(454, 81);
            this.lblTitle.TabIndex = 28;
            this.lblTitle.Text = "Create Account";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(567, 162);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(204, 22);
            this.txtEmail.TabIndex = 54;
            this.txtEmail.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEmail.Location = new System.Drawing.Point(421, 163);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(50, 19);
            this.lblEmail.TabIndex = 53;
            this.lblEmail.Text = "Email";
            this.lblEmail.Click += new System.EventHandler(this.label1_Click);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.rbFemale);
            this.Controls.Add(this.rbMale);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.chkShowPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblLoginCreden);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.txtIC);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblContactInfo);
            this.Controls.Add(this.lblGender);
            this.Controls.Add(this.lblDOB);
            this.Controls.Add(this.lblIC);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblPersonalinfo);
            this.Controls.Add(this.lblNoteCreateAcc);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormRegister";
            this.Text = "Sign Up";
            this.Load += new System.EventHandler(this.FormRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.CheckBox chkShowPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblLoginCreden;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.TextBox txtIC;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblContactInfo;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label lblIC;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblPersonalinfo;
        private System.Windows.Forms.Label lblNoteCreateAcc;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
    }
}