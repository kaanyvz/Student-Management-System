using System;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.TeacherCRUD.Add;
using schoolManagementSystem.Admin.TeacherCRUD.Delete;
using schoolManagementSystem.Admin.TeacherCRUD.Update;

namespace schoolManagementSystem.Admin.TeacherCRUD
{
    public partial class TeacherSettings : Form
    {
        private string adminUsername;
        private string schoolName;
        public TeacherSettings(string adminUsername, string schoolName)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            InitializeComponent();
        }

        private void addNewTeacherBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void addNewTeacherBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void addNewTeacherBtn_Click(object sender, EventArgs e)
        {
            AddNewTeacher addNewTeacher = new AddNewTeacher(adminUsername, schoolName);
            addNewTeacher.StartPosition = FormStartPosition.Manual;
            addNewTeacher.Location = this.Location;
            this.Hide();
            addNewTeacher.ShowDialog();
            this.Close();
        }

        private void updateTeacherBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void updateTeacherBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void updateTeacherBtn_Click(object sender, EventArgs e)
        {
            UpdateTeacher updateTeacher = new UpdateTeacher(adminUsername, schoolName);
            updateTeacher.StartPosition = FormStartPosition.Manual;
            updateTeacher.Location = this.Location;
            this.Hide();
            updateTeacher.ShowDialog();
            this.Close();
        }

        private void deleteTeacherBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void deleteTeacherBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void deleteTeacherBtn_Click(object sender, EventArgs e)
        {
            DeleteTeacher deleteTeacher = new DeleteTeacher(adminUsername, schoolName);
            deleteTeacher.StartPosition = FormStartPosition.Manual;
            deleteTeacher.Location = this.Location;
            this.Hide();
            deleteTeacher.ShowDialog();
            this.Close();
        }

        private void teacherDetailsBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void teacherDetailsBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void teacherDetailsBtn_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}