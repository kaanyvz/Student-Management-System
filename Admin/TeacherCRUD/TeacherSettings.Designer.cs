using System.ComponentModel;

namespace schoolManagementSystem.Admin.TeacherCRUD
{
    partial class TeacherSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeacherSettings));
            this.studentManagementSystemPanel = new System.Windows.Forms.Panel();
            this.adminDashboardTurnOffButton = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.studentSettingsPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.addNewTeacherBtn = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.updateTeacherBtn = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.deleteTeacherBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.teacherDetailsBtn = new System.Windows.Forms.Button();
            this.backIcon = new System.Windows.Forms.PictureBox();
            this.pieChart1 = new LiveCharts.WinForms.PieChart();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.studentManagementSystemPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDashboardTurnOffButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.studentSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // studentManagementSystemPanel
            // 
            this.studentManagementSystemPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.studentManagementSystemPanel.Controls.Add(this.adminDashboardTurnOffButton);
            this.studentManagementSystemPanel.Controls.Add(this.label3);
            this.studentManagementSystemPanel.Controls.Add(this.pictureBox1);
            this.studentManagementSystemPanel.Location = new System.Drawing.Point(200, 0);
            this.studentManagementSystemPanel.Name = "studentManagementSystemPanel";
            this.studentManagementSystemPanel.Size = new System.Drawing.Size(1064, 83);
            this.studentManagementSystemPanel.TabIndex = 44;
            // 
            // adminDashboardTurnOffButton
            // 
            this.adminDashboardTurnOffButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.adminDashboardTurnOffButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminDashboardTurnOffButton.Image = ((System.Drawing.Image)(resources.GetObject("adminDashboardTurnOffButton.Image")));
            this.adminDashboardTurnOffButton.Location = new System.Drawing.Point(1001, 21);
            this.adminDashboardTurnOffButton.Name = "adminDashboardTurnOffButton";
            this.adminDashboardTurnOffButton.Size = new System.Drawing.Size(52, 47);
            this.adminDashboardTurnOffButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.adminDashboardTurnOffButton.TabIndex = 6;
            this.adminDashboardTurnOffButton.TabStop = false;
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
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.backIcon);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(197, 561);
            this.flowLayoutPanel1.TabIndex = 43;
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
            this.label1.Size = new System.Drawing.Size(70, 54);
            this.label1.TabIndex = 6;
            this.label1.Text = "Teacher\r\nSettings";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.addNewTeacherBtn);
            this.panel7.Location = new System.Drawing.Point(3, 89);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(189, 60);
            this.panel7.TabIndex = 0;
            // 
            // addNewTeacherBtn
            // 
            this.addNewTeacherBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.addNewTeacherBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addNewTeacherBtn.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addNewTeacherBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addNewTeacherBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewTeacherBtn.Location = new System.Drawing.Point(-26, -20);
            this.addNewTeacherBtn.Name = "addNewTeacherBtn";
            this.addNewTeacherBtn.Size = new System.Drawing.Size(236, 93);
            this.addNewTeacherBtn.TabIndex = 2;
            this.addNewTeacherBtn.Text = "Add New Teacher";
            this.addNewTeacherBtn.UseVisualStyleBackColor = false;
            this.addNewTeacherBtn.Click += new System.EventHandler(this.addNewTeacherBtn_Click);
            this.addNewTeacherBtn.MouseEnter += new System.EventHandler(this.addNewTeacherBtn_MouseEnter);
            this.addNewTeacherBtn.MouseLeave += new System.EventHandler(this.addNewTeacherBtn_MouseLeave);
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.updateTeacherBtn);
            this.panel9.Location = new System.Drawing.Point(3, 155);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(189, 60);
            this.panel9.TabIndex = 0;
            // 
            // updateTeacherBtn
            // 
            this.updateTeacherBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.updateTeacherBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateTeacherBtn.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.updateTeacherBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.updateTeacherBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateTeacherBtn.Location = new System.Drawing.Point(-26, -15);
            this.updateTeacherBtn.Name = "updateTeacherBtn";
            this.updateTeacherBtn.Size = new System.Drawing.Size(236, 83);
            this.updateTeacherBtn.TabIndex = 2;
            this.updateTeacherBtn.Text = "Update Teacher";
            this.updateTeacherBtn.UseVisualStyleBackColor = false;
            this.updateTeacherBtn.Click += new System.EventHandler(this.updateTeacherBtn_Click);
            this.updateTeacherBtn.MouseEnter += new System.EventHandler(this.updateTeacherBtn_MouseEnter);
            this.updateTeacherBtn.MouseLeave += new System.EventHandler(this.updateTeacherBtn_MouseLeave);
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.deleteTeacherBtn);
            this.panel11.Location = new System.Drawing.Point(3, 221);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(189, 60);
            this.panel11.TabIndex = 0;
            // 
            // deleteTeacherBtn
            // 
            this.deleteTeacherBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.deleteTeacherBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteTeacherBtn.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deleteTeacherBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.deleteTeacherBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteTeacherBtn.Location = new System.Drawing.Point(-26, -14);
            this.deleteTeacherBtn.Name = "deleteTeacherBtn";
            this.deleteTeacherBtn.Size = new System.Drawing.Size(236, 83);
            this.deleteTeacherBtn.TabIndex = 2;
            this.deleteTeacherBtn.Text = "Delete Teacher";
            this.deleteTeacherBtn.UseVisualStyleBackColor = false;
            this.deleteTeacherBtn.Click += new System.EventHandler(this.deleteTeacherBtn_Click);
            this.deleteTeacherBtn.MouseEnter += new System.EventHandler(this.deleteTeacherBtn_MouseEnter);
            this.deleteTeacherBtn.MouseLeave += new System.EventHandler(this.deleteTeacherBtn_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.teacherDetailsBtn);
            this.panel1.Location = new System.Drawing.Point(3, 287);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(189, 60);
            this.panel1.TabIndex = 0;
            // 
            // teacherDetailsBtn
            // 
            this.teacherDetailsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.teacherDetailsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.teacherDetailsBtn.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.teacherDetailsBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.teacherDetailsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.teacherDetailsBtn.Location = new System.Drawing.Point(-26, -14);
            this.teacherDetailsBtn.Name = "teacherDetailsBtn";
            this.teacherDetailsBtn.Size = new System.Drawing.Size(236, 83);
            this.teacherDetailsBtn.TabIndex = 2;
            this.teacherDetailsBtn.Text = "Teacher Details";
            this.teacherDetailsBtn.UseVisualStyleBackColor = false;
            this.teacherDetailsBtn.Click += new System.EventHandler(this.teacherDetailsBtn_Click);
            this.teacherDetailsBtn.MouseEnter += new System.EventHandler(this.teacherDetailsBtn_MouseEnter);
            this.teacherDetailsBtn.MouseLeave += new System.EventHandler(this.teacherDetailsBtn_MouseLeave);
            // 
            // backIcon
            // 
            this.backIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(50)))));
            this.backIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backIcon.Image = ((System.Drawing.Image)(resources.GetObject("backIcon.Image")));
            this.backIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.backIcon.Location = new System.Drawing.Point(3, 353);
            this.backIcon.Name = "backIcon";
            this.backIcon.Size = new System.Drawing.Size(39, 37);
            this.backIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.backIcon.TabIndex = 41;
            this.backIcon.TabStop = false;
            this.backIcon.Click += new System.EventHandler(this.backIcon_Click);
            // 
            // pieChart1
            // 
            this.pieChart1.Location = new System.Drawing.Point(228, 100);
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(425, 430);
            this.pieChart1.TabIndex = 45;
            this.pieChart1.Text = "pieChart1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBox1.Location = new System.Drawing.Point(668, 142);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(544, 290);
            this.richTextBox1.TabIndex = 46;
            this.richTextBox1.Text = "";
            // 
            // TeacherSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1264, 561);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.studentManagementSystemPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "TeacherSettings";
            this.Text = "TeacherSettings";
            this.Load += new System.EventHandler(this.TeacherSettings_Load_1);
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
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.backIcon)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel studentManagementSystemPanel;
        private System.Windows.Forms.PictureBox adminDashboardTurnOffButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel studentSettingsPanel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button addNewTeacherBtn;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button updateTeacherBtn;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button deleteTeacherBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button teacherDetailsBtn;
        private System.Windows.Forms.PictureBox backIcon;

        #endregion

        private LiveCharts.WinForms.PieChart pieChart1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}