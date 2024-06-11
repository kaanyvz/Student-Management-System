using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.TeacherCRUD.Add;
using schoolManagementSystem.Admin.TeacherCRUD.Delete;
using schoolManagementSystem.Admin.TeacherCRUD.Update;

namespace schoolManagementSystem.Admin.TeacherCRUD.Details
{
    public partial class TeacherDetailsPage : Form
    {
        private string adminUsername;
        private string schoolName;
        private int teacherId;
        public TeacherDetailsPage(string adminUsername, string schoolName, int teacherId)
        {
            InitializeComponent();
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            this.teacherId = teacherId;
            
            
        }

        private void backIcon_Click(object sender, EventArgs e)
        {
            TeacherDetails teacherDetails = new TeacherDetails(adminUsername, schoolName);
            teacherDetails.StartPosition = FormStartPosition.Manual;
            teacherDetails.Location = this.Location;
            this.Hide();
            teacherDetails.ShowDialog();
            this.Close();
        }

        private void TeacherDetailsPage_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();

                // Fetch teacher's information
                string teacherQuery = "SELECT * FROM Teacher WHERE id = @TeacherId";
                using (SqlCommand teacherCommand = new SqlCommand(teacherQuery, sqlConnection))
                {
                    teacherCommand.Parameters.AddWithValue("@TeacherId", teacherId);
                    using (SqlDataReader reader = teacherCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            teacherName.Text = reader["Firstname"].ToString();
                            teacherSurname.Text = reader["Lastname"].ToString();
                            teacherTC.Text = reader["TCNumber"].ToString();
                            teacherPhone.Text = reader["Phone"].ToString();
                            teacherMail.Text = reader["Email"].ToString();
                            teacherMajor.Text = reader["Major"].ToString();
                            teacherBirthdate.Value = Convert.ToDateTime(reader["BirthDate"]);
                        }
                    }
                }

                // Fetch class information
                string classQuery = "SELECT * FROM Class WHERE headTeacherId = @TeacherId";
                using (SqlCommand classCommand = new SqlCommand(classQuery, sqlConnection))
                {
                    classCommand.Parameters.AddWithValue("@TeacherId", teacherId);
                    using (SqlDataReader reader = classCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            className.Text = reader["classname"].ToString();
                            classCapacity.Text = reader["capacity"].ToString();
                            classSchoolName.Text = schoolName;
                        }
                        else
                        {
                            className.Text = "NO INFORMATION";
                            classCapacity.Text = "NO INFORMATION";
                            classSchoolName.Text = schoolName;
                        }
                    }
                }

                sqlConnection.Close();
            }
        }
        
        private void adminDashboardTurnOffButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
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
                button.BackColor = Color.FromArgb(35, 35, 50);
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
                button.BackColor = Color.FromArgb(35, 35, 50);
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
                button.BackColor = Color.FromArgb(35, 35, 50);
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
    }
}