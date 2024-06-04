using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.StudentCRUD.Delete;
using schoolManagementSystem.Admin.StudentCRUD.Details;
using schoolManagementSystem.Admin.StudentCRUD.Update;
using schoolManagementSystem.Model;

namespace schoolManagementSystem.Admin.StudentCRUD.Add
{
    public partial class AddNewStudent : Form
    {
        private string adminUsername;
        private string schoolName;
        
        private int  studentId;
        private int studentNumber;

        public AddNewStudent(string adminUsername, string schoolName)
        {
            InitializeComponent();
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            this.studentGender.FormattingEnabled = true;
            this.studentGender.Items.AddRange(new object[] {
                "Male", 
                "Female" 
            });
            this.studentGender.Location = new System.Drawing.Point(798, 225);
            this.studentGender.Name = "studentGender";
            this.studentGender.Size = new System.Drawing.Size(148, 21);
            this.studentGender.TabIndex = 4;
            PopulateClassDropdown();

            studentNumber = GenerateUniqueStudentNumber();
            string email = $"{studentNumber}@{GetFirstWordOfSchoolName()}.edu.tr";

            studentSchoolNumber.Text = studentNumber.ToString();
            studentMail.Text = email;
            
            this.studentTC.KeyPress += new KeyPressEventHandler(studentTC_KeyPress_1);
        }
        
        private void addParentalInformationsBtn_Click(object sender, EventArgs e)
        {
            
            string firstname = studentName?.Text;
            string lastname = studentSurname?.Text;
            string gender = studentGender?.SelectedItem?.ToString();
            DateTime birthDate = dateTimePicker1.Value;
            string TCNumber = studentTC?.Text;
            string className = studentGrade?.SelectedItem?.ToString();

            if(firstname == null || lastname == null || gender == null || birthDate == null || TCNumber == null || className == null)
            {
                MessageBox.Show("All fields must be filled");
                return;
            }

            string email = $"{studentNumber}@{GetFirstWordOfSchoolName()}.edu.tr";

            Student student = new Student
            {
                BirthDate = birthDate,
                ClassName = className,
                Email = email,
                Firstname = firstname,
                Lastname = lastname,
                StudentNumber = studentNumber,
                Gender = gender,
                TCNumber = TCNumber
            };
            

            AddParentalInformations addParentalInformations = new AddParentalInformations(adminUsername, schoolName, student);
            addParentalInformations.StartPosition = FormStartPosition.Manual;
            addParentalInformations.Location = this.Location;
            this.Hide();
            addParentalInformations.ShowDialog();
            this.Close();
            
            
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
                    studentGrade.Items.Add($"{className} - {capacity}");
                }
            }
        }
        
        private int GenerateUniqueStudentNumber()
        {
            Random random = new Random();
            int studentNumber;
            bool isUnique;

            do
            {
                studentNumber = random.Next(10000, 100000);
                isUnique = CheckIfStudentNumberIsUnique(studentNumber);
            } while (!isUnique);

            return studentNumber;
        }

        private bool CheckIfStudentNumberIsUnique(int studentNumber)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Student WHERE studentNumber = @StudentNumber", connection);
                cmd.Parameters.AddWithValue("@StudentNumber", studentNumber);
                int count = (int)cmd.ExecuteScalar();
                return count == 0;
            }
        }
        
        private string GetFirstWordOfSchoolName()
        {
            string schoolName = "";

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT SC.SchoolName " +
                    "FROM SchoolAdmin SA " +
                    "INNER JOIN School AS SC " +
                    "ON SA.schoolId = SC.id " +
                    "WHERE SA.username = @Username", 
                    connection);
        
                cmd.Parameters.AddWithValue("@Username", adminUsername);
                schoolName = (string) cmd.ExecuteScalar();
            }

            return schoolName.Split(' ')[0].ToLower();
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
            StudentSettings studentSettings = new StudentSettings(adminUsername, schoolName);
            studentSettings.StartPosition = FormStartPosition.Manual;
            studentSettings.Location = this.Location;
            this.Hide();
            studentSettings.ShowDialog();
            this.Close();
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

        private void studentDetailsBtn_Click(object sender, EventArgs e)
        {
            StudentDetails studentDetails = new StudentDetails(adminUsername, schoolName);
            studentDetails.StartPosition = FormStartPosition.Manual;
            studentDetails.Location = this.Location;
            this.Hide();
            studentDetails.ShowDialog();
            this.Close();
        }

        private void adminDashboardTurnOffButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
    
    
}