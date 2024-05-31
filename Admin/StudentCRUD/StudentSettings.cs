using System;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.StudentCRUD.Add;
using schoolManagementSystem.Admin.StudentCRUD.Delete;
using schoolManagementSystem.Admin.StudentCRUD.Update;

namespace schoolManagementSystem.Admin.StudentCRUD
{
    public partial class StudentSettings : Form
    {
        private string adminUsername;
        private string schoolName;
        
        public StudentSettings(string adminUsername, string schoolName)
        {
            InitializeComponent();
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
        }

        private void addStudentButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void addStudentButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }


        private void updateStudentButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void updateStudentButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45);
            }
        }

        private void deleteStudentButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void deleteStudentButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void allStudentsButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void allStudentsButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            AddNewStudent addNewStudent = new AddNewStudent(adminUsername, schoolName);
            addNewStudent.StartPosition = FormStartPosition.Manual;
            addNewStudent.Location = this.Location;
            this.Hide();
            addNewStudent.ShowDialog();
            this.Close();
        }

        private void backIcon_Click(object sender, EventArgs e)
        {
            AdminSettings adminSettings = new AdminSettings(adminUsername, schoolName);
            adminSettings.StartPosition = FormStartPosition.Manual;
            adminSettings.Location = this.Location;
            this.Hide();
            adminSettings.ShowDialog();
            this.Close();
        }

        private void updateStudentButton_Click(object sender, EventArgs e)
        {
            UpdateStudent updateStudent = new UpdateStudent(adminUsername, schoolName);
            updateStudent.StartPosition = FormStartPosition.Manual;
            updateStudent.Location = this.Location;
            this.Hide();
            updateStudent.ShowDialog();
            this.Close();
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            DeleteStudent deleteStudent = new DeleteStudent(adminUsername, schoolName);
            deleteStudent.StartPosition = FormStartPosition.Manual;
            deleteStudent.Location = this.Location;
            this.Hide();
            deleteStudent.ShowDialog();
            this.Close();
        }
    }
}