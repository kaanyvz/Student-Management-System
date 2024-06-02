using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using schoolManagementSystem.Admin.TeacherCRUD.Delete;
using schoolManagementSystem.Admin.TeacherCRUD.Update;

namespace schoolManagementSystem.Admin.TeacherCRUD.Add
{
    public partial class AddNewTeacher : Form
    {
        private string adminUsername;
        private string schoolName;
        public AddNewTeacher(string adminUsername, string schoolName)
        {
            InitializeComponent();
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            PopulateMajorDropdown();
            PopulateClassFilterDropdown();
        }
        
        private string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        
        private void PopulateMajorDropdown()
        {
            majorDropdown.Items.Clear();

            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();

                string query = "SELECT DISTINCT Subjectname FROM Subject";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["Subjectname"].ToString();
                            majorDropdown.Items.Add(subjectName);
                        }
                    }
                }
            }
        }
        
        private void PopulateClassFilterDropdown()
        {
            headClass.Items.Clear();

            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();

                string query = "SELECT DISTINCT classname FROM Class WHERE headTeacherId IS NULL";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string className = reader["classname"].ToString();
                            headClass.Items.Add(className);
                        }
                    }
                }
            }
        }

        private void addTeacherBtn_Click(object sender, EventArgs e)
        {
            string password = GeneratePassword();

            Model.Teacher newTeacher = new Model.Teacher
            {
                Firstname = teacherName.Text,
                Lastname = teacherSurname.Text,
                Email = teacherMail.Text,
                Phone = teacherPhone.Text,
                TCNumber = teacherTC.Text,
                BirthDate = dateTimePicker1.Value,
                Major = majorDropdown.SelectedItem.ToString(),
                Password = password
            };

            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();

                // Get the schoolId using the schoolName
                string schoolQuery = "SELECT id FROM School WHERE SchoolName = @SchoolName";
                using (SqlCommand schoolCommand = new SqlCommand(schoolQuery, sqlConnection))
                {
                    schoolCommand.Parameters.AddWithValue("@SchoolName", schoolName);
                    int schoolId = (int)schoolCommand.ExecuteScalar();

                    string query = @"
                        INSERT INTO Teacher (Firstname, Lastname, Email, Phone, TCNumber, BirthDate, Major, Password, SchoolId)
                        OUTPUT INSERTED.id
                        VALUES (@Firstname, @Lastname, @Email, @Phone, @TCNumber, @BirthDate,  @Major, @Password, @SchoolId)";

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@Firstname", newTeacher.Firstname);
                        sqlCommand.Parameters.AddWithValue("@Lastname", newTeacher.Lastname);
                        sqlCommand.Parameters.AddWithValue("@Email", newTeacher.Email);
                        sqlCommand.Parameters.AddWithValue("@Phone", newTeacher.Phone);
                        sqlCommand.Parameters.AddWithValue("@TCNumber", newTeacher.TCNumber);
                        sqlCommand.Parameters.AddWithValue("@BirthDate", newTeacher.BirthDate);
                        sqlCommand.Parameters.AddWithValue("@Major", newTeacher.Major);
                        sqlCommand.Parameters.AddWithValue("@Password", newTeacher.Password);
                        sqlCommand.Parameters.AddWithValue("@SchoolId", schoolId); 

                        int newTeacherId = (int)sqlCommand.ExecuteScalar();

                        query = "UPDATE Class SET headTeacherId = @headTeacherId WHERE classname = @classname";
                        using (SqlCommand updateCommand = new SqlCommand(query, sqlConnection))
                        {
                            updateCommand.Parameters.AddWithValue("@headTeacherId", newTeacherId);
                            updateCommand.Parameters.AddWithValue("@classname", headClass.SelectedItem.ToString());

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            
            AddNewTeacherSuccess addTeacherSuccess = new AddNewTeacherSuccess(adminUsername, schoolName);
            addTeacherSuccess.StartPosition = FormStartPosition.Manual;
            addTeacherSuccess.Location = this.Location;
            this.Hide();
            addTeacherSuccess.ShowDialog();
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

        private void deleteTeacherBtn_Click(object sender, EventArgs e)
        {
            DeleteTeacher deleteTeacher = new DeleteTeacher(adminUsername, schoolName);
            deleteTeacher.StartPosition = FormStartPosition.Manual;
            deleteTeacher.Location = this.Location;
            this.Hide();
            deleteTeacher.ShowDialog();
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

        private void backIcon_Click(object sender, EventArgs e)
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