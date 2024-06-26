﻿using System.ComponentModel;

namespace schoolManagementSystem.Admin.CardCRUD.Add
{
    partial class AddCardSuccess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCardSuccess));
            this.backButton = new System.Windows.Forms.Button();
            this.richTextBoxInside = new System.Windows.Forms.RichTextBox();
            this.successTextBox = new System.Windows.Forms.TextBox();
            this.successPictureBox = new System.Windows.Forms.PictureBox();
            this.richTextBoxOutside = new System.Windows.Forms.RichTextBox();
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
            this.updateStudentCardButton = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cardActivityDetailsBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.successPictureBox)).BeginInit();
            this.studentManagementSystemPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDashboardTurnOffButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.studentSettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.SystemColors.Info;
            this.backButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backButton.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.backButton.Location = new System.Drawing.Point(261, 494);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(145, 44);
            this.backButton.TabIndex = 29;
            this.backButton.Text = "< Go Back";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // richTextBoxInside
            // 
            this.richTextBoxInside.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxInside.Enabled = false;
            this.richTextBoxInside.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextBoxInside.Location = new System.Drawing.Point(544, 346);
            this.richTextBoxInside.Name = "richTextBoxInside";
            this.richTextBoxInside.ReadOnly = true;
            this.richTextBoxInside.Size = new System.Drawing.Size(381, 60);
            this.richTextBoxInside.TabIndex = 28;
            this.richTextBoxInside.Text = "  * Card has assigned to student successfully. \n  * You can go back to main menu." + "";
            // 
            // successTextBox
            // 
            this.successTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.successTextBox.Enabled = false;
            this.successTextBox.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.successTextBox.ForeColor = System.Drawing.Color.ForestGreen;
            this.successTextBox.Location = new System.Drawing.Point(656, 275);
            this.successTextBox.Name = "successTextBox";
            this.successTextBox.ReadOnly = true;
            this.successTextBox.Size = new System.Drawing.Size(145, 35);
            this.successTextBox.TabIndex = 27;
            this.successTextBox.Text = "  SUCCESS!";
            // 
            // successPictureBox
            // 
            this.successPictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.successPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("successPictureBox.Image")));
            this.successPictureBox.Location = new System.Drawing.Point(656, 142);
            this.successPictureBox.Name = "successPictureBox";
            this.successPictureBox.Size = new System.Drawing.Size(145, 119);
            this.successPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.successPictureBox.TabIndex = 26;
            this.successPictureBox.TabStop = false;
            // 
            // richTextBoxOutside
            // 
            this.richTextBoxOutside.BackColor = System.Drawing.SystemColors.ControlLight;
            this.richTextBoxOutside.Enabled = false;
            this.richTextBoxOutside.Location = new System.Drawing.Point(261, 123);
            this.richTextBoxOutside.Name = "richTextBoxOutside";
            this.richTextBoxOutside.ReadOnly = true;
            this.richTextBoxOutside.Size = new System.Drawing.Size(949, 324);
            this.richTextBoxOutside.TabIndex = 25;
            this.richTextBoxOutside.Text = "\n\n\n\n\n\n\n\n\n\n\n\n\n                                                                    " + "                ";
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
            this.studentManagementSystemPanel.TabIndex = 31;
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
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(197, 561);
            this.flowLayoutPanel1.TabIndex = 30;
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
            this.label1.Size = new System.Drawing.Size(77, 54);
            this.label1.TabIndex = 6;
            this.label1.Text = "Add New\r\nCard";
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
            this.addNewCardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
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
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel9.Controls.Add(this.updateStudentCardButton);
            this.panel9.Location = new System.Drawing.Point(3, 155);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(189, 60);
            this.panel9.TabIndex = 0;
            // 
            // updateStudentCardButton
            // 
            this.updateStudentCardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.updateStudentCardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.updateStudentCardButton.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.updateStudentCardButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.updateStudentCardButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.updateStudentCardButton.Location = new System.Drawing.Point(-26, -15);
            this.updateStudentCardButton.Name = "updateStudentCardButton";
            this.updateStudentCardButton.Size = new System.Drawing.Size(236, 83);
            this.updateStudentCardButton.TabIndex = 2;
            this.updateStudentCardButton.Text = "Update Card";
            this.updateStudentCardButton.UseVisualStyleBackColor = false;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.cardActivityDetailsBtn);
            this.panel11.Location = new System.Drawing.Point(3, 221);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(189, 60);
            this.panel11.TabIndex = 0;
            // 
            // cardActivityDetailsBtn
            // 
            this.cardActivityDetailsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(45)))));
            this.cardActivityDetailsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cardActivityDetailsBtn.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardActivityDetailsBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.cardActivityDetailsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cardActivityDetailsBtn.Location = new System.Drawing.Point(-26, -14);
            this.cardActivityDetailsBtn.Name = "cardActivityDetailsBtn";
            this.cardActivityDetailsBtn.Size = new System.Drawing.Size(236, 83);
            this.cardActivityDetailsBtn.TabIndex = 2;
            this.cardActivityDetailsBtn.Text = "Card Activity Details";
            this.cardActivityDetailsBtn.UseVisualStyleBackColor = false;
            // 
            // AddCardSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 561);
            this.Controls.Add(this.studentManagementSystemPanel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.richTextBoxInside);
            this.Controls.Add(this.successTextBox);
            this.Controls.Add(this.successPictureBox);
            this.Controls.Add(this.richTextBoxOutside);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddCardSuccess";
            this.Text = "Student Management System";
            ((System.ComponentModel.ISupportInitialize)(this.successPictureBox)).EndInit();
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
            this.ResumeLayout(false);
            this.PerformLayout();
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
        private System.Windows.Forms.Button addNewCardButton;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Button updateStudentCardButton;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button cardActivityDetailsBtn;

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.RichTextBox richTextBoxInside;
        private System.Windows.Forms.TextBox successTextBox;
        private System.Windows.Forms.PictureBox successPictureBox;
        private System.Windows.Forms.RichTextBox richTextBoxOutside;

        #endregion
    }
}