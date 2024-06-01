using System.ComponentModel;

namespace schoolManagementSystem
{
    partial class template
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(template));
            this.studentManagementSystemPanel = new System.Windows.Forms.Panel();
            this.adminDashboardTurnOffButton = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.studentSettingsPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.addStudentButton = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.updateStudentButton = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.deleteStudentButton = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.studentDetailsBtn = new System.Windows.Forms.Button();
            this.studentManagementSystemPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDashboardTurnOffButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.studentSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentManagementSystemPanel
            // 
            this.studentManagementSystemPanel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.studentManagementSystemPanel.Controls.Add(this.adminDashboardTurnOffButton);
            this.studentManagementSystemPanel.Controls.Add(this.label3);
            this.studentManagementSystemPanel.Controls.Add(this.pictureBox1);
            this.studentManagementSystemPanel.Location = new System.Drawing.Point(199, 0);
            this.studentManagementSystemPanel.Name = "studentManagementSystemPanel";
            this.studentManagementSystemPanel.Size = new System.Drawing.Size(1064, 83);
            this.studentManagementSystemPanel.TabIndex = 7;
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
            this.flowLayoutPanel1.Controls.Add(this.panel10);
            this.flowLayoutPanel1.Controls.Add(this.panel11);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(197, 561);
            this.flowLayoutPanel1.TabIndex = 6;
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
            this.label1.Size = new System.Drawing.Size(72, 54);
            this.label1.TabIndex = 6;
            this.label1.Text = "Student \r\nSettings";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.addStudentButton);
            this.panel7.Location = new System.Drawing.Point(3, 89);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(189, 60);
            this.panel7.TabIndex = 0;
            // 
            // addStudentButton
            // 
            this.addStudentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.addStudentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addStudentButton.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addStudentButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addStudentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addStudentButton.Location = new System.Drawing.Point(-26, -20);
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(236, 93);
            this.addStudentButton.TabIndex = 2;
            this.addStudentButton.Text = "Add New Student";
            this.addStudentButton.UseVisualStyleBackColor = false;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.updateStudentButton);
            this.panel9.Location = new System.Drawing.Point(3, 155);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(189, 60);
            this.panel9.TabIndex = 0;
            // 
            // updateStudentButton
            // 
            this.updateStudentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.updateStudentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateStudentButton.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.updateStudentButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.updateStudentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateStudentButton.Location = new System.Drawing.Point(-26, -15);
            this.updateStudentButton.Name = "updateStudentButton";
            this.updateStudentButton.Size = new System.Drawing.Size(236, 83);
            this.updateStudentButton.TabIndex = 2;
            this.updateStudentButton.Text = "Update Student";
            this.updateStudentButton.UseVisualStyleBackColor = false;
            // 
            // panel10
            // 
            this.panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel10.Controls.Add(this.deleteStudentButton);
            this.panel10.Location = new System.Drawing.Point(3, 221);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(189, 60);
            this.panel10.TabIndex = 0;
            // 
            // deleteStudentButton
            // 
            this.deleteStudentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.deleteStudentButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteStudentButton.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.deleteStudentButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.deleteStudentButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteStudentButton.Location = new System.Drawing.Point(-26, -12);
            this.deleteStudentButton.Name = "deleteStudentButton";
            this.deleteStudentButton.Size = new System.Drawing.Size(236, 83);
            this.deleteStudentButton.TabIndex = 2;
            this.deleteStudentButton.Text = "Delete Student";
            this.deleteStudentButton.UseVisualStyleBackColor = false;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.studentDetailsBtn);
            this.panel11.Location = new System.Drawing.Point(3, 287);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(189, 60);
            this.panel11.TabIndex = 0;
            // 
            // studentDetailsBtn
            // 
            this.studentDetailsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.studentDetailsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.studentDetailsBtn.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.studentDetailsBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.studentDetailsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.studentDetailsBtn.Location = new System.Drawing.Point(-26, -14);
            this.studentDetailsBtn.Name = "studentDetailsBtn";
            this.studentDetailsBtn.Size = new System.Drawing.Size(236, 83);
            this.studentDetailsBtn.TabIndex = 2;
            this.studentDetailsBtn.Text = "Student Details";
            this.studentDetailsBtn.UseVisualStyleBackColor = false;
            // 
            // template
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1264, 561);
            this.Controls.Add(this.studentManagementSystemPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "template";
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
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
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
        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button updateStudentButton;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button deleteStudentButton;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button studentDetailsBtn;

        #endregion
    }
}