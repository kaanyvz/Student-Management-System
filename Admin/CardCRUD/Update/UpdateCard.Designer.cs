using System.ComponentModel;

namespace schoolManagementSystem.Admin.CardCRUD.Update
{
    partial class UpdateCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateCard));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.numberFilter = new System.Windows.Forms.TextBox();
            this.surnameFilter = new System.Windows.Forms.TextBox();
            this.nameFilter = new System.Windows.Forms.TextBox();
            this.studentManagementSystemPanel = new System.Windows.Forms.Panel();
            this.adminDashboardTurnOffButton = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.studentSettingsPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.addNewCardButton = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.updateCardButton = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cardDetailsButton = new System.Windows.Forms.Button();
            this.backIcon = new System.Windows.Forms.PictureBox();
            this.clearFiltersBtn = new System.Windows.Forms.Button();
            this.cardNumberFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.studentManagementSystemPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDashboardTurnOffButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.studentSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.richTextBox1.Location = new System.Drawing.Point(278, 89);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(451, 50);
            this.richTextBox1.TabIndex = 101;
            this.richTextBox1.Text = "⚫  You can select one of the students to be updated.\n⚫  The first 50 students add" + "ed to the system are listed.\n⚫  You can also filter students by first name, last" + " name, number or card number.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(763, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 97;
            this.label2.Text = "Student Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(1086, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 99;
            this.label4.Text = "Number:";
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.usernameLabel.Location = new System.Drawing.Point(745, 120);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(116, 15);
            this.usernameLabel.TabIndex = 100;
            this.usernameLabel.Text = "Student Surname:";
            // 
            // numberFilter
            // 
            this.numberFilter.BackColor = System.Drawing.Color.MintCream;
            this.numberFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numberFilter.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numberFilter.ForeColor = System.Drawing.SystemColors.WindowText;
            this.numberFilter.Location = new System.Drawing.Point(1152, 89);
            this.numberFilter.Name = "numberFilter";
            this.numberFilter.Size = new System.Drawing.Size(179, 22);
            this.numberFilter.TabIndex = 2;
            this.numberFilter.TextChanged += new System.EventHandler(this.numberFilter_TextChanged);
            // 
            // surnameFilter
            // 
            this.surnameFilter.BackColor = System.Drawing.Color.MintCream;
            this.surnameFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.surnameFilter.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.surnameFilter.ForeColor = System.Drawing.SystemColors.WindowText;
            this.surnameFilter.Location = new System.Drawing.Point(867, 118);
            this.surnameFilter.Name = "surnameFilter";
            this.surnameFilter.Size = new System.Drawing.Size(179, 22);
            this.surnameFilter.TabIndex = 3;
            this.surnameFilter.TextChanged += new System.EventHandler(this.surnameFilter_TextChanged);
            // 
            // nameFilter
            // 
            this.nameFilter.BackColor = System.Drawing.Color.MintCream;
            this.nameFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameFilter.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.nameFilter.ForeColor = System.Drawing.SystemColors.WindowText;
            this.nameFilter.Location = new System.Drawing.Point(867, 89);
            this.nameFilter.Name = "nameFilter";
            this.nameFilter.Size = new System.Drawing.Size(179, 22);
            this.nameFilter.TabIndex = 1;
            this.nameFilter.TextChanged += new System.EventHandler(this.nameFilter_TextChanged);
            // 
            // studentManagementSystemPanel
            // 
            this.studentManagementSystemPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.studentManagementSystemPanel.Controls.Add(this.adminDashboardTurnOffButton);
            this.studentManagementSystemPanel.Controls.Add(this.label3);
            this.studentManagementSystemPanel.Controls.Add(this.pictureBox1);
            this.studentManagementSystemPanel.Location = new System.Drawing.Point(201, 0);
            this.studentManagementSystemPanel.Name = "studentManagementSystemPanel";
            this.studentManagementSystemPanel.Size = new System.Drawing.Size(1263, 83);
            this.studentManagementSystemPanel.TabIndex = 92;
            // 
            // adminDashboardTurnOffButton
            // 
            this.adminDashboardTurnOffButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.adminDashboardTurnOffButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminDashboardTurnOffButton.Image = ((System.Drawing.Image)(resources.GetObject("adminDashboardTurnOffButton.Image")));
            this.adminDashboardTurnOffButton.Location = new System.Drawing.Point(1200, 14);
            this.adminDashboardTurnOffButton.Name = "adminDashboardTurnOffButton";
            this.adminDashboardTurnOffButton.Size = new System.Drawing.Size(52, 47);
            this.adminDashboardTurnOffButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.adminDashboardTurnOffButton.TabIndex = 6;
            this.adminDashboardTurnOffButton.TabStop = false;
            this.adminDashboardTurnOffButton.Click += new System.EventHandler(this.adminDashboardTurnOffButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(141, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(312, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "STUDENT MANAGEMENT SYSTEM";
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.flowLayoutPanel1.Controls.Add(this.studentSettingsPanel);
            this.flowLayoutPanel1.Controls.Add(this.panel7);
            this.flowLayoutPanel1.Controls.Add(this.panel9);
            this.flowLayoutPanel1.Controls.Add(this.panel11);
            this.flowLayoutPanel1.Controls.Add(this.backIcon);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(197, 661);
            this.flowLayoutPanel1.TabIndex = 91;
            // 
            // studentSettingsPanel
            // 
            this.studentSettingsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.studentSettingsPanel.Controls.Add(this.pictureBox2);
            this.studentSettingsPanel.Controls.Add(this.label1);
            this.studentSettingsPanel.Location = new System.Drawing.Point(3, 3);
            this.studentSettingsPanel.Name = "studentSettingsPanel";
            this.studentSettingsPanel.Size = new System.Drawing.Size(189, 80);
            this.studentSettingsPanel.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(13, 17);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(56, 54);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(75, 10);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.label1.Size = new System.Drawing.Size(63, 54);
            this.label1.TabIndex = 6;
            this.label1.Text = "Update\r\nCard";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.addNewCardButton);
            this.panel7.Location = new System.Drawing.Point(3, 89);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(189, 60);
            this.panel7.TabIndex = 0;
            // 
            // addNewCardButton
            // 
            this.addNewCardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.addNewCardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addNewCardButton.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addNewCardButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addNewCardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewCardButton.Location = new System.Drawing.Point(-26, -20);
            this.addNewCardButton.Name = "addNewCardButton";
            this.addNewCardButton.Size = new System.Drawing.Size(236, 93);
            this.addNewCardButton.TabIndex = 2;
            this.addNewCardButton.Text = "Add New Card";
            this.addNewCardButton.UseVisualStyleBackColor = false;
            this.addNewCardButton.Click += new System.EventHandler(this.addNewCardButton_Click);
            this.addNewCardButton.MouseEnter += new System.EventHandler(this.addNewCardButton_MouseEnter);
            this.addNewCardButton.MouseLeave += new System.EventHandler(this.addNewCardButton_MouseLeave);
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.updateCardButton);
            this.panel9.Location = new System.Drawing.Point(3, 155);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(189, 60);
            this.panel9.TabIndex = 0;
            // 
            // updateCardButton
            // 
            this.updateCardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.updateCardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateCardButton.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.updateCardButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.updateCardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateCardButton.Location = new System.Drawing.Point(-26, -15);
            this.updateCardButton.Name = "updateCardButton";
            this.updateCardButton.Size = new System.Drawing.Size(236, 83);
            this.updateCardButton.TabIndex = 2;
            this.updateCardButton.Text = "Update Card";
            this.updateCardButton.UseVisualStyleBackColor = false;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.cardDetailsButton);
            this.panel11.Location = new System.Drawing.Point(3, 221);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(189, 60);
            this.panel11.TabIndex = 0;
            // 
            // cardDetailsButton
            // 
            this.cardDetailsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.cardDetailsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardDetailsButton.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardDetailsButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cardDetailsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cardDetailsButton.Location = new System.Drawing.Point(-26, -14);
            this.cardDetailsButton.Name = "cardDetailsButton";
            this.cardDetailsButton.Size = new System.Drawing.Size(236, 83);
            this.cardDetailsButton.TabIndex = 2;
            this.cardDetailsButton.Text = "Card Activity Details";
            this.cardDetailsButton.UseVisualStyleBackColor = false;
            this.cardDetailsButton.Click += new System.EventHandler(this.cardDetailsButton_Click);
            this.cardDetailsButton.MouseEnter += new System.EventHandler(this.cardDetailsButton_MouseEnter);
            this.cardDetailsButton.MouseLeave += new System.EventHandler(this.cardDetailsButton_MouseLeave);
            // 
            // backIcon
            // 
            this.backIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.backIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backIcon.Image = ((System.Drawing.Image)(resources.GetObject("backIcon.Image")));
            this.backIcon.Location = new System.Drawing.Point(3, 287);
            this.backIcon.Name = "backIcon";
            this.backIcon.Size = new System.Drawing.Size(39, 37);
            this.backIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backIcon.TabIndex = 103;
            this.backIcon.TabStop = false;
            this.backIcon.Click += new System.EventHandler(this.backIcon_Click);
            // 
            // clearFiltersBtn
            // 
            this.clearFiltersBtn.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.clearFiltersBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearFiltersBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.clearFiltersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearFiltersBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.clearFiltersBtn.Location = new System.Drawing.Point(1342, 114);
            this.clearFiltersBtn.Name = "clearFiltersBtn";
            this.clearFiltersBtn.Size = new System.Drawing.Size(111, 25);
            this.clearFiltersBtn.TabIndex = 5;
            this.clearFiltersBtn.Text = "Clear Filters";
            this.clearFiltersBtn.UseVisualStyleBackColor = false;
            this.clearFiltersBtn.Click += new System.EventHandler(this.clearFiltersBtn_Click);
            // 
            // cardNumberFilter
            // 
            this.cardNumberFilter.BackColor = System.Drawing.Color.MintCream;
            this.cardNumberFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardNumberFilter.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardNumberFilter.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cardNumberFilter.Location = new System.Drawing.Point(1152, 117);
            this.cardNumberFilter.Name = "cardNumberFilter";
            this.cardNumberFilter.Size = new System.Drawing.Size(179, 22);
            this.cardNumberFilter.TabIndex = 4;
            this.cardNumberFilter.TextChanged += new System.EventHandler(this.cardNumberFilter_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(1054, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 15);
            this.label5.TabIndex = 99;
            this.label5.Text = "Card Number:";
            // 
            // UpdateCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1464, 661);
            this.Controls.Add(this.clearFiltersBtn);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.cardNumberFilter);
            this.Controls.Add(this.numberFilter);
            this.Controls.Add(this.surnameFilter);
            this.Controls.Add(this.nameFilter);
            this.Controls.Add(this.studentManagementSystemPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateCard";
            this.Text = "Student Management System";
            this.studentManagementSystemPanel.ResumeLayout(false);
            this.studentManagementSystemPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDashboardTurnOffButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.studentSettingsPanel.ResumeLayout(false);
            this.studentSettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.PictureBox backIcon;

        private System.Windows.Forms.TextBox cardNumberFilter;

        private System.Windows.Forms.Button clearFiltersBtn;

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox numberFilter;
        private System.Windows.Forms.TextBox surnameFilter;
        private System.Windows.Forms.TextBox nameFilter;

        private System.Windows.Forms.Panel studentManagementSystemPanel;
        private System.Windows.Forms.PictureBox adminDashboardTurnOffButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel studentSettingsPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button addNewCardButton;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button updateCardButton;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button cardDetailsButton;

        #endregion
    }
}