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
            this.btnComplete = new System.Windows.Forms.Button();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAgree = new System.Windows.Forms.CheckBox();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExpiryDate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCardHolderName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCreateAcc = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCard = new System.Windows.Forms.RadioButton();
            this.rbFPX = new System.Windows.Forms.RadioButton();
            this.rbTNG = new System.Windows.Forms.RadioButton();
            this.lblFee = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnComplete
            // 
            this.btnComplete.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnComplete.Location = new System.Drawing.Point(542, 404);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(232, 38);
            this.btnComplete.TabIndex = 34;
            this.btnComplete.Text = "Process N Completed Book >>>";
            this.btnComplete.UseVisualStyleBackColor = false;
            // 
            // cboBank
            // 
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Location = new System.Drawing.Point(552, 201);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(222, 24);
            this.cboBank.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(548, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 19);
            this.label4.TabIndex = 32;
            this.label4.Text = "Select Your Bank";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAgree);
            this.groupBox2.Controls.Add(this.txtCVV);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtExpiryDate);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtCardNumber);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtCardHolderName);
            this.groupBox2.Controls.Add(this.lblFullName);
            this.groupBox2.Location = new System.Drawing.Point(258, 167);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(260, 280);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Card Details";
            // 
            // chkAgree
            // 
            this.chkAgree.AutoSize = true;
            this.chkAgree.ForeColor = System.Drawing.Color.Red;
            this.chkAgree.Location = new System.Drawing.Point(11, 237);
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ClinicAppointmentSystem.Properties.Resources.tng;
            this.pictureBox1.Location = new System.Drawing.Point(26, 167);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 237);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCard);
            this.groupBox1.Controls.Add(this.rbFPX);
            this.groupBox1.Controls.Add(this.rbTNG);
            this.groupBox1.Location = new System.Drawing.Point(26, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 74);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Method";
            // 
            // rbCard
            // 
            this.rbCard.AutoSize = true;
            this.rbCard.Location = new System.Drawing.Point(315, 31);
            this.rbCard.Name = "rbCard";
            this.rbCard.Size = new System.Drawing.Size(131, 20);
            this.rbCard.TabIndex = 29;
            this.rbCard.TabStop = true;
            this.rbCard.Text = "Credit/Debit Card";
            this.rbCard.UseVisualStyleBackColor = true;
            // 
            // rbFPX
            // 
            this.rbFPX.AutoSize = true;
            this.rbFPX.Location = new System.Drawing.Point(567, 31);
            this.rbFPX.Name = "rbFPX";
            this.rbFPX.Size = new System.Drawing.Size(154, 20);
            this.rbFPX.TabIndex = 28;
            this.rbFPX.TabStop = true;
            this.rbFPX.Text = "FPX (Online Banking)";
            this.rbFPX.UseVisualStyleBackColor = true;
            // 
            // rbTNG
            // 
            this.rbTNG.AutoSize = true;
            this.rbTNG.Location = new System.Drawing.Point(16, 31);
            this.rbTNG.Name = "rbTNG";
            this.rbTNG.Size = new System.Drawing.Size(162, 20);
            this.rbTNG.TabIndex = 27;
            this.rbTNG.TabStop = true;
            this.rbTNG.Text = "E-Wallet (Touch \'n Go)";
            this.rbTNG.UseVisualStyleBackColor = true;
            // 
            // lblFee
            // 
            this.lblFee.AutoSize = true;
            this.lblFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFee.Location = new System.Drawing.Point(12, 9);
            this.lblFee.Name = "lblFee";
            this.lblFee.Size = new System.Drawing.Size(46, 20);
            this.lblFee.TabIndex = 35;
            this.lblFee.Text = "Fee:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 36;
            // 
            // FormPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblFee);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.cboBank);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCreateAcc);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPayment";
            this.Text = "FormPayment";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAgree;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExpiryDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCardHolderName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCreateAcc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCard;
        private System.Windows.Forms.RadioButton rbFPX;
        private System.Windows.Forms.RadioButton rbTNG;
        private System.Windows.Forms.Label lblFee;
        private System.Windows.Forms.Label label5;
    }
}