using System.ComponentModel;

namespace schoolManagementSystem
{
    partial class EntranceTracking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntranceTracking));
            this.studentManagementSystemPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cardNumberBox = new System.Windows.Forms.TextBox();
            this.enterCardNumberText = new System.Windows.Forms.TextBox();
            this.enterButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.goExitScreenBtn = new System.Windows.Forms.Button();
            this.studentManagementSystemPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // studentManagementSystemPanel
            // 
            this.studentManagementSystemPanel.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.studentManagementSystemPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("studentManagementSystemPanel.BackgroundImage")));
            this.studentManagementSystemPanel.Controls.Add(this.label3);
            this.studentManagementSystemPanel.Controls.Add(this.pictureBox1);
            this.studentManagementSystemPanel.Enabled = false;
            this.studentManagementSystemPanel.Location = new System.Drawing.Point(-1, 0);
            this.studentManagementSystemPanel.Name = "studentManagementSystemPanel";
            this.studentManagementSystemPanel.Size = new System.Drawing.Size(1186, 202);
            this.studentManagementSystemPanel.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Cascadia Code", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(452, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(312, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "STUDENT MANAGEMENT SYSTEM";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(452, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(312, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // cardNumberBox
            // 
            this.cardNumberBox.BackColor = System.Drawing.Color.Honeydew;
            this.cardNumberBox.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cardNumberBox.Location = new System.Drawing.Point(451, 433);
            this.cardNumberBox.Name = "cardNumberBox";
            this.cardNumberBox.Size = new System.Drawing.Size(312, 29);
            this.cardNumberBox.TabIndex = 1;
            // 
            // enterCardNumberText
            // 
            this.enterCardNumberText.BackColor = System.Drawing.Color.MintCream;
            this.enterCardNumberText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.enterCardNumberText.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.enterCardNumberText.Enabled = false;
            this.enterCardNumberText.Font = new System.Drawing.Font("Arial Black", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.enterCardNumberText.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.enterCardNumberText.Location = new System.Drawing.Point(451, 358);
            this.enterCardNumberText.Name = "enterCardNumberText";
            this.enterCardNumberText.ReadOnly = true;
            this.enterCardNumberText.Size = new System.Drawing.Size(312, 39);
            this.enterCardNumberText.TabIndex = 11;
            this.enterCardNumberText.Text = " Enter Card Number";
            // 
            // enterButton
            // 
            this.enterButton.BackColor = System.Drawing.Color.Moccasin;
            this.enterButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enterButton.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.enterButton.Location = new System.Drawing.Point(494, 530);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(231, 41);
            this.enterButton.TabIndex = 2;
            this.enterButton.Text = "ENTER";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Cascadia Code", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(472, 205);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "School Entrance Screen";
            // 
            // goExitScreenBtn
            // 
            this.goExitScreenBtn.BackColor = System.Drawing.Color.Moccasin;
            this.goExitScreenBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.goExitScreenBtn.Font = new System.Drawing.Font("Arial Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.goExitScreenBtn.Location = new System.Drawing.Point(494, 264);
            this.goExitScreenBtn.Name = "goExitScreenBtn";
            this.goExitScreenBtn.Size = new System.Drawing.Size(231, 41);
            this.goExitScreenBtn.TabIndex = 14;
            this.goExitScreenBtn.Text = "Go Exit";
            this.goExitScreenBtn.UseVisualStyleBackColor = false;
            this.goExitScreenBtn.Click += new System.EventHandler(this.goExitScreenBtn_Click);
            // 
            // EntranceTracking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.goExitScreenBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.enterCardNumberText);
            this.Controls.Add(this.cardNumberBox);
            this.Controls.Add(this.studentManagementSystemPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EntranceTracking";
            this.Text = "Student Management System";
            this.studentManagementSystemPanel.ResumeLayout(false);
            this.studentManagementSystemPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button goExitScreenBtn;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button enterButton;

        private System.Windows.Forms.TextBox cardNumberBox;
        private System.Windows.Forms.TextBox enterCardNumberText;

        private System.Windows.Forms.Panel studentManagementSystemPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;

        #endregion
    }
}