using System;
using System.Windows.Forms;

namespace schoolManagementSystem.Admin.TeacherCRUD.Add
{
    public partial class AddNewTeacherSuccess : Form
    {
        private string adminUsername;
        private string schoolName;
        
        public AddNewTeacherSuccess(string adminUsername, string schoolName)
        {
            InitializeComponent();
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
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