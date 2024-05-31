using System;
using System.Windows.Forms;

namespace schoolManagementSystem.Admin.StudentCRUD.Update
{
    public partial class UpdateStudentSuccess : Form
    {
        private string adminUsername;
        private string schoolName;
        public UpdateStudentSuccess(string adminUsername, string schoolName)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            InitializeComponent();
        }
        

        private void backButton_Click(object sender, EventArgs e)
        {
            StudentSettings studentSettings = new StudentSettings(adminUsername, schoolName);
            studentSettings.StartPosition = FormStartPosition.Manual;
            studentSettings.Location = this.Location;
            this.Hide();
            studentSettings.ShowDialog();
            this.Close();
        }
    }
}