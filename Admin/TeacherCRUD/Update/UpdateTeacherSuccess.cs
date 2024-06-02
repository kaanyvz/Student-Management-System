﻿using System;
using System.Windows.Forms;

namespace schoolManagementSystem.Admin.TeacherCRUD.Update
{
    public partial class UpdateTeacherSuccess : Form
    {
        private string adminUsername;
        private string schoolName;
        
        public UpdateTeacherSuccess(string adminUsername, string schoolName)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            TeacherSettings teacherSettings = new TeacherSettings(adminUsername, schoolName);
            teacherSettings.StartPosition = FormStartPosition.Manual;
            teacherSettings.Location = this.Location;
            this.Hide();
            teacherSettings.ShowDialog();
            this.Close();
        }
    }
}