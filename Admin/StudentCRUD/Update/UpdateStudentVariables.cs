using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.StudentCRUD.Add;
using schoolManagementSystem.Model;

namespace schoolManagementSystem.Admin.StudentCRUD.Update
{
    
    
    public partial class UpdateStudentVariables : Form
    {
        private int studentId;
        private string adminUsername;
        private string schoolName;
        public UpdateStudentVariables(int studentId, string adminUsername, string schoolName)
        {
            this.studentId = studentId;
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            InitializeComponent();
            
            this.studentGenderBox.FormattingEnabled = true;
            this.studentGenderBox.Items.AddRange(new object[] {
                "Male", 
                "Female" 
            });
            this.studentTCBox.KeyPress += new KeyPressEventHandler(studentTC_KeyPress_1);
            PopulateClassDropdown();
            
        }
        
        private void studentTC_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        
        private void backIcon_Click(object sender, EventArgs e)
        {
            UpdateStudent updateStudent = new UpdateStudent(adminUsername, schoolName);
            updateStudent.StartPosition = FormStartPosition.Manual;
            updateStudent.Location = this.Location;
            this.Hide();
            updateStudent.ShowDialog();
            this.Close();
        }

        private void UpdateStudentVariables_Load_1(object sender, EventArgs e)
        {
            
            
            string studentQuery = "SELECT firstname, studentNumber, lastname, gender, email, birthDate, TCNumber, classId FROM student WHERE id = @studentId";

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(studentQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        studentNameBox.Text = reader["firstname"].ToString();
                        studentSurnameBox.Text = reader["lastname"].ToString();
                        studentGenderBox.Text = reader["gender"].ToString();
                        studentNumberBox.Text = reader["studentNumber"].ToString();
                        studentMailBox.Text = reader["email"].ToString();
                        studentBirthdate.Value = Convert.ToDateTime(reader["birthDate"]);
                        studentTCBox.Text = reader["TCNumber"].ToString();

                        int classId = Convert.ToInt32(reader["classId"]);
                        string classQuery = "SELECT className FROM Class WHERE id = @classId";

                        reader.Close(); 

                        using (SqlCommand classCommand = new SqlCommand(classQuery, connection))
                        {
                            classCommand.Parameters.AddWithValue("@classId", classId);
                            SqlDataReader classReader = classCommand.ExecuteReader();

                            if (classReader.Read())
                            {
                                studentClassBox.Text = classReader["className"].ToString();
                            }

                            classReader.Close();
                        }
                    }
                }
            }
        }
        
        private void PopulateClassDropdown()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                // Get the schoolId from the School table using the schoolName
                SqlCommand schoolCmd = new SqlCommand("SELECT id FROM School WHERE SchoolName = @SchoolName", connection);
                schoolCmd.Parameters.AddWithValue("@SchoolName", schoolName);
                int schoolId = (int)schoolCmd.ExecuteScalar();

                // Use the schoolId to filter the classes from the Class table
                SqlCommand classCmd = new SqlCommand("SELECT className, capacity FROM Class WHERE schoolId = @SchoolId", connection);
                classCmd.Parameters.AddWithValue("@SchoolId", schoolId);
                SqlDataReader reader = classCmd.ExecuteReader();

                while (reader.Read())
                {
                    string className = reader["className"].ToString();
                    int capacity = Convert.ToInt32(reader["capacity"]);
                    studentClassBox.Items.Add($"{className} - {capacity}");
                }
            }
        }
        

        private void addParentalInfosBtn_Click(object sender, EventArgs e)
        {
            Student student = new Student();

            student.Firstname = studentNameBox.Text;
            student.Lastname = studentSurnameBox.Text;
            student.Gender = studentGenderBox.Text;
            student.Email = studentMailBox.Text;
            student.StudentNumber = int.Parse(studentNumberBox.Text);
            student.TCNumber = studentTCBox.Text;
            student.BirthDate = studentBirthdate.Value;
            student.ClassName = studentClassBox.Text;
            
            UpdateStudentParentInfos updateStudentParentInfos = new UpdateStudentParentInfos(studentId, adminUsername, schoolName, student);
            
            updateStudentParentInfos.StartPosition = FormStartPosition.Manual;
            updateStudentParentInfos.Location = this.Location;
            this.Hide();
            updateStudentParentInfos.ShowDialog();
            this.Close();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}