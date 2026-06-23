namespace ClinicAppointmentSystem
{
    partial class FormPayment
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
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.grpCardDetails = new System.Windows.Forms.GroupBox();
            this.chkAgree = new System.Windows.Forms.CheckBox();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExpiryDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardHolderName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.lblCreateAcc = new System.Windows.Forms.Label();
            this.groupBxPayment = new System.Windows.Forms.GroupBox();
            this.radCreditCard = new System.Windows.Forms.RadioButton();
            this.radFPX = new System.Windows.Forms.RadioButton();
            this.radEWallet = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.grpFPXDetails = new System.Windows.Forms.GroupBox();
            this.btnCompleted = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.grpCardDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.groupBxPayment.SuspendLayout();
            this.grpFPXDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboBank
            // 
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Items.AddRange(new object[] {
            "Select Your Bank",
            "Maybank",
            "CIMB Bank",
            "Public Bank",
            "RHB Bank",
            "Hong Leong Bank",
            "AmBank",
            "Bank Islam",
            "Bank Rakyat"});
            this.cboBank.Location = new System.Drawing.Point(12, 42);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(222, 24);
            this.cboBank.TabIndex = 33;
            // 
            // grpCardDetails
            // 
            this.grpCardDetails.Controls.Add(this.chkAgree);
            this.grpCardDetails.Controls.Add(this.txtCVV);
            this.grpCardDetails.Controls.Add(this.label3);
            this.grpCardDetails.Controls.Add(this.txtExpiryDate);
            this.grpCardDetails.Controls.Add(this.label2);
            this.grpCardDetails.Controls.Add(this.txtCardNumber);
            this.grpCardDetails.Controls.Add(this.label1);
            this.grpCardDetails.Controls.Add(this.txtCardHolderName);
            this.grpCardDetails.Controls.Add(this.lblFullName);
            this.grpCardDetails.Location = new System.Drawing.Point(258, 167);
            this.grpCardDetails.Name = "grpCardDetails";
            this.grpCardDetails.Size = new System.Drawing.Size(260, 280);
            this.grpCardDetails.TabIndex = 31;
            this.grpCardDetails.TabStop = false;
            this.grpCardDetails.Text = "Card Details";
            // 
            // chkAgree
            // 
            this.chkAgree.AutoSize = true;
            this.chkAgree.ForeColor = System.Drawing.Color.Red;
            this.chkAgree.Location = new System.Drawing.Point(10, 240);
            this.chkAgree.Name = "chkAgree";
            this.chkAgree.Size = new System.Drawing.Size(220, 20);
            this.chkAgree.TabIndex = 20;
            this.chkAgree.Text = "I Agree To The Term and Policy";
            this.chkAgree.UseVisualStyleBackColor = true;
            // 
            // txtCVV
            // 
            this.txtCVV.Location = new System.Drawing.Point(10, 192);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.PasswordChar = '*';
            this.txtCVV.Size = new System.Drawing.Size(204, 22);
            this.txtCVV.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(6, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 19);
            this.label3.TabIndex = 18;
            this.label3.Text = "CVV";
            // 
            // txtExpiryDate
            // 
            this.txtExpiryDate.Location = new System.Drawing.Point(10, 145);
            this.txtExpiryDate.MaxLength = 5;
            this.txtExpiryDate.Name = "txtExpiryDate";
            this.txtExpiryDate.Size = new System.Drawing.Size(204, 22);
            this.txtExpiryDate.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(6, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Expiry Date (MM/YY)";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(10, 98);
            this.txtCardNumber.MaxLength = 19;
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(204, 22);
            this.txtCardNumber.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(6, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.label1.TabIndex = 14;
            this.label1.Text = "Card Number";
            // 
            // txtCardHolderName
            // 
            this.txtCardHolderName.Location = new System.Drawing.Point(10, 51);
            this.txtCardHolderName.Name = "txtCardHolderName";
            this.txtCardHolderName.Size = new System.Drawing.Size(204, 22);
            this.txtCardHolderName.TabIndex = 13;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFullName.Location = new System.Drawing.Point(6, 29);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(136, 19);
            this.lblFullName.TabIndex = 12;
            this.lblFullName.Text = "Card Holder Name";
            // 
            // picQRCode
            // 
            this.picQRCode.Image = global::ClinicAppointmentSystem.Properties.Resources.tng;
            this.picQRCode.Location = new System.Drawing.Point(26, 179);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(191, 237);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQRCode.TabIndex = 30;
            this.picQRCode.TabStop = false;
            // 
            // lblCreateAcc
            // 
            this.lblCreateAcc.AutoSize = true;
            this.lblCreateAcc.Font = new System.Drawing.Font("Segoe UI Symbol", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreateAcc.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblCreateAcc.Location = new System.Drawing.Point(177, 3);
            this.lblCreateAcc.Name = "lblCreateAcc";
            this.lblCreateAcc.Size = new System.Drawing.Size(476, 81);
            this.lblCreateAcc.TabIndex = 29;
            this.lblCreateAcc.Text = "Payment Details";
            // 
            // groupBxPayment
            // 
            this.groupBxPayment.Controls.Add(this.radCreditCard);
            this.groupBxPayment.Controls.Add(this.radFPX);
            this.groupBxPayment.Controls.Add(this.radEWallet);
            this.groupBxPayment.Location = new System.Drawing.Point(26, 87);
            this.groupBxPayment.Name = "groupBxPayment";
            this.groupBxPayment.Size = new System.Drawing.Size(748, 74);
            this.groupBxPayment.TabIndex = 28;
            this.groupBxPayment.TabStop = false;
            this.groupBxPayment.Text = "Payment Method";
            // 
            // radCreditCard
            // 
            this.radCreditCard.AutoSize = true;
            this.radCreditCard.Location = new System.Drawing.Point(315, 31);
            this.radCreditCard.Name = "radCreditCard";
            this.radCreditCard.Size = new System.Drawing.Size(131, 20);
            this.radCreditCard.TabIndex = 29;
            this.radCreditCard.TabStop = true;
            this.radCreditCard.Text = "Credit/Debit Card";
            this.radCreditCard.UseVisualStyleBackColor = true;
            // 
            // radFPX
            // 
            this.radFPX.AutoSize = true;
            this.radFPX.Location = new System.Drawing.Point(567, 31);
            this.radFPX.Name = "radFPX";
            this.radFPX.Size = new System.Drawing.Size(154, 20);
            this.radFPX.TabIndex = 28;
            this.radFPX.TabStop = true;
            this.radFPX.Text = "FPX (Online Banking)";
            this.radFPX.UseVisualStyleBackColor = true;
            // 
            // radEWallet
            // 
            this.radEWallet.AutoSize = true;
            this.radEWallet.Location = new System.Drawing.Point(16, 31);
            this.radEWallet.Name = "radEWallet";
            this.radEWallet.Size = new System.Drawing.Size(162, 20);
            this.radEWallet.TabIndex = 27;
            this.radEWallet.TabStop = true;
            this.radEWallet.Text = "E-Wallet (Touch \'n Go)";
            this.radEWallet.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 36;
            // 
            // grpFPXDetails
            // 
            this.grpFPXDetails.Controls.Add(this.cboBank);
            this.grpFPXDetails.Location = new System.Drawing.Point(540, 174);
            this.grpFPXDetails.Name = "grpFPXDetails";
            this.grpFPXDetails.Size = new System.Drawing.Size(244, 92);
            this.grpFPXDetails.TabIndex = 37;
            this.grpFPXDetails.TabStop = false;
            this.grpFPXDetails.Text = "Select Your Bank";
            // 
            // btnCompleted
            // 
            this.btnCompleted.Location = new System.Drawing.Point(579, 368);
            this.btnCompleted.Name = "btnCompleted";
            this.btnCompleted.Size = new System.Drawing.Size(148, 48);
            this.btnCompleted.TabIndex = 38;
            this.btnCompleted.Text = "Completed";
            this.btnCompleted.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(26, 368);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(148, 48);
            this.btnBack.TabIndex = 39;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // FormPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCompleted);
            this.Controls.Add(this.grpFPXDetails);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grpCardDetails);
            this.Controls.Add(this.picQRCode);
            this.Controls.Add(this.lblCreateAcc);
            this.Controls.Add(this.groupBxPayment);
            this.Name = "FormPayment";
            this.Text = "Form Payment";
            this.grpCardDetails.ResumeLayout(false);
            this.grpCardDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.groupBxPayment.ResumeLayout(false);
            this.groupBxPayment.PerformLayout();
            this.grpFPXDetails.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.GroupBox grpCardDetails;
        private System.Windows.Forms.CheckBox chkAgree;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExpiryDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCardHolderName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.PictureBox picQRCode;
        private System.Windows.Forms.Label lblCreateAcc;
        private System.Windows.Forms.GroupBox groupBxPayment;
        private System.Windows.Forms.RadioButton radCreditCard;
        private System.Windows.Forms.RadioButton radFPX;
        private System.Windows.Forms.RadioButton radEWallet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpFPXDetails;
        private System.Windows.Forms.Button btnCompleted;
        private System.Windows.Forms.Button btnBack;
    }
}