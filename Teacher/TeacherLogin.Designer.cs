namespace schoolManagementSystem.Teacher
{
    partial class TeacherLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherLogin));
            this.emailBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.teacherLoginTitle = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.adminDashboardTurnOffButton = new System.Windows.Forms.PictureBox();
            this.mainTitle = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.loginAsAdminBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDashboardTurnOffButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // emailBox
            // 
            this.emailBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.emailBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.emailBox.Location = new System.Drawing.Point(416, 211);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(254, 22);
            this.emailBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            this.passwordBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.passwordBox.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.passwordBox.Location = new System.Drawing.Point(416, 285);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(254, 22);
            this.passwordBox.TabIndex = 1;
            // 
            // teacherLoginTitle
            // 
            this.teacherLoginTitle.AutoSize = true;
            this.teacherLoginTitle.Font = new System.Drawing.Font("Cascadia Code", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.teacherLoginTitle.ForeColor = System.Drawing.Color.Firebrick;
            this.teacherLoginTitle.Location = new System.Drawing.Point(460, 131);
            this.teacherLoginTitle.Name = "teacherLoginTitle";
            this.teacherLoginTitle.Size = new System.Drawing.Size(168, 28);
            this.teacherLoginTitle.TabIndex = 1;
            this.teacherLoginTitle.Text = "TEACHER LOGIN";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.passwordLabel.Location = new System.Drawing.Point(294, 288);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(81, 15);
            this.passwordLabel.TabIndex = 1;
            this.passwordLabel.Text = "PASSWORD:";
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.SystemColors.Info;
            this.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginBtn.Location = new System.Drawing.Point(416, 416);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(254, 48);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "LOGIN";
            this.loginBtn.UseVisualStyleBackColor = false;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.usernameLabel.Location = new System.Drawing.Point(326, 214);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(49, 15);
            this.usernameLabel.TabIndex = 1;
            this.usernameLabel.Text = "EMAIL:";
            // 
            // labelTime
            // 
            this.labelTime.BackColor = System.Drawing.SystemColors.ControlLight;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTime.Location = new System.Drawing.Point(909, 475);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(163, 25);
            this.labelTime.TabIndex = 5;
            this.labelTime.Text = "TIME";
            this.labelTime.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel1.Controls.Add(this.adminDashboardTurnOffButton);
            this.panel1.Controls.Add(this.mainTitle);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1080, 83);
            this.panel1.TabIndex = 6;
            // 
            // adminDashboardTurnOffButton
            // 
            this.adminDashboardTurnOffButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.adminDashboardTurnOffButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminDashboardTurnOffButton.Image = ((System.Drawing.Image)(resources.GetObject("adminDashboardTurnOffButton.Image")));
            this.adminDashboardTurnOffButton.Location = new System.Drawing.Point(1019, 20);
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
            // loginAsAdminBtn
            // 
            this.loginAsAdminBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.loginAsAdminBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginAsAdminBtn.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginAsAdminBtn.Location = new System.Drawing.Point(460, 346);
            this.loginAsAdminBtn.Name = "loginAsAdminBtn";
            this.loginAsAdminBtn.Size = new System.Drawing.Size(163, 35);
            this.loginAsAdminBtn.TabIndex = 7;
            this.loginAsAdminBtn.Text = "Login As Admin";
            this.loginAsAdminBtn.UseVisualStyleBackColor = false;
            this.loginAsAdminBtn.Click += new System.EventHandler(this.loginAsAdminBtn_Click);
            // 
            // TeacherLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1084, 509);
            this.Controls.Add(this.loginAsAdminBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.teacherLoginTitle);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.emailBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TeacherLogin";
            this.Text = "Student Management System";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDashboardTurnOffButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button loginAsAdminBtn;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox adminDashboardTurnOffButton;
        private System.Windows.Forms.Label mainTitle;
        private System.Windows.Forms.PictureBox pictureBox1;

        private System.Windows.Forms.Label labelTime;

        #endregion

        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label teacherLoginTitle;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label usernameLabel;
    }
}

