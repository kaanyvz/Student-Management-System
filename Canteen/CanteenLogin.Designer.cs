using System.ComponentModel;

namespace schoolManagementSystem.Canteen
{
    partial class CanteenLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CanteenLogin));
            this.loginAsTeacherBtn = new System.Windows.Forms.Button();
            this.loginAsAdminBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.adminDashboardTurnOffButton = new System.Windows.Forms.PictureBox();
            this.mainTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.canteenPasswordBox = new System.Windows.Forms.TextBox();
            this.canteenNameBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDashboardTurnOffButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // loginAsTeacherBtn
            // 
            this.loginAsTeacherBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loginAsTeacherBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginAsTeacherBtn.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginAsTeacherBtn.Location = new System.Drawing.Point(672, 345);
            this.loginAsTeacherBtn.Name = "loginAsTeacherBtn";
            this.loginAsTeacherBtn.Size = new System.Drawing.Size(118, 44);
            this.loginAsTeacherBtn.TabIndex = 18;
            this.loginAsTeacherBtn.Text = "Login As \r\nTeacher";
            this.loginAsTeacherBtn.UseVisualStyleBackColor = false;
            this.loginAsTeacherBtn.Click += new System.EventHandler(this.canteenOwnerBtn_Click);
            // 
            // loginAsAdminBtn
            // 
            this.loginAsAdminBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loginAsAdminBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginAsAdminBtn.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginAsAdminBtn.Location = new System.Drawing.Point(536, 345);
            this.loginAsAdminBtn.Name = "loginAsAdminBtn";
            this.loginAsAdminBtn.Size = new System.Drawing.Size(118, 44);
            this.loginAsAdminBtn.TabIndex = 17;
            this.loginAsAdminBtn.Text = "Login As Admin";
            this.loginAsAdminBtn.UseVisualStyleBackColor = false;
            this.loginAsAdminBtn.Click += new System.EventHandler(this.loginAsAdminBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.adminDashboardTurnOffButton);
            this.panel1.Controls.Add(this.mainTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1259, 83);
            this.panel1.TabIndex = 16;
            // 
            // adminDashboardTurnOffButton
            // 
            this.adminDashboardTurnOffButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.adminDashboardTurnOffButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminDashboardTurnOffButton.Image = ((System.Drawing.Image)(resources.GetObject("adminDashboardTurnOffButton.Image")));
            this.adminDashboardTurnOffButton.Location = new System.Drawing.Point(1197, 11);
            this.adminDashboardTurnOffButton.Name = "adminDashboardTurnOffButton";
            this.adminDashboardTurnOffButton.Size = new System.Drawing.Size(52, 47);
            this.adminDashboardTurnOffButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.adminDashboardTurnOffButton.TabIndex = 6;
            this.adminDashboardTurnOffButton.TabStop = false;
            // 
            // mainTitle
            // 
            this.mainTitle.AutoSize = true;
            this.mainTitle.Font = new System.Drawing.Font("Cascadia Code", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.mainTitle.Location = new System.Drawing.Point(141, 29);
            this.mainTitle.Name = "mainTitle";
            this.mainTitle.Size = new System.Drawing.Size(312, 28);
            this.mainTitle.TabIndex = 6;
            this.mainTitle.Text = "STUDENT MANAGEMENT SYSTEM";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(28, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.SystemColors.Info;
            this.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginBtn.Location = new System.Drawing.Point(536, 425);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(254, 48);
            this.loginBtn.TabIndex = 3;
            this.loginBtn.Text = "LOGIN";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.passwordLabel.Location = new System.Drawing.Point(418, 297);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(81, 15);
            this.passwordLabel.TabIndex = 10;
            this.passwordLabel.Text = "PASSWORD:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.usernameLabel.Location = new System.Drawing.Point(448, 223);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(49, 15);
            this.usernameLabel.TabIndex = 11;
            this.usernameLabel.Text = "NAME:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(573, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "CANTEEN LOGIN";
            // 
            // canteenPasswordBox
            // 
            this.canteenPasswordBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canteenPasswordBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.canteenPasswordBox.Location = new System.Drawing.Point(536, 294);
            this.canteenPasswordBox.Name = "canteenPasswordBox";
            this.canteenPasswordBox.PasswordChar = '*';
            this.canteenPasswordBox.Size = new System.Drawing.Size(254, 22);
            this.canteenPasswordBox.TabIndex = 2;
            // 
            // canteenNameBox
            // 
            this.canteenNameBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canteenNameBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.canteenNameBox.Location = new System.Drawing.Point(536, 220);
            this.canteenNameBox.Name = "canteenNameBox";
            this.canteenNameBox.Size = new System.Drawing.Size(254, 22);
            this.canteenNameBox.TabIndex = 1;
            // 
            // CanteenLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1264, 561);
            this.Controls.Add(this.loginAsTeacherBtn);
            this.Controls.Add(this.loginAsAdminBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.canteenPasswordBox);
            this.Controls.Add(this.canteenNameBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CanteenLogin";
            this.Text = "Student Management System";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDashboardTurnOffButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button loginAsTeacherBtn;
        private System.Windows.Forms.Button loginAsAdminBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox adminDashboardTurnOffButton;
        private System.Windows.Forms.Label mainTitle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox canteenPasswordBox;
        private System.Windows.Forms.TextBox canteenNameBox;

        #endregion
    }
}