using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using schoolManagementSystem.Admin.StudentCRUD.Add;
using schoolManagementSystem.Admin.StudentCRUD.Delete;
using schoolManagementSystem.Admin.StudentCRUD.Details;
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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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

        private void StudentSettings_Load(object sender, EventArgs e)
        {
            LoadStudentClasses();
        }
        
        
        private void LoadStudentClasses()
        {
            // Assuming you have a method to retrieve data from your database
            Dictionary<string, int> studentClassesCount = GetStudentClassesCount();

            // Clear previous data from the chart
            pieChart1.Series.Clear();

            // Add data to the chart
            SeriesCollection seriesCollection = new SeriesCollection();
            richTextBox1.Clear();

            // Calculate total student count
            int totalStudentCount = 0;
            foreach (var classCount in studentClassesCount)
            {
                totalStudentCount += classCount.Value;
            }

            richTextBox1.AppendText($"In {schoolName}, there're {totalStudentCount} students.\n\n");
            foreach (var classCount in studentClassesCount)
            {
                seriesCollection.Add(new PieSeries
                {
                    Title = classCount.Key,
                    Values = new ChartValues<int> { classCount.Value },
                    DataLabels = true
                });
                richTextBox1.AppendText($"{classCount.Value} students in {classCount.Key} class,\n");
            }
            richTextBox1.AppendText("\nTo make student operations, you can select one of the options in sidebar.");

            pieChart1.Series = seriesCollection;
        }

        // Method to retrieve student classes count from the database
        private Dictionary<string, int> GetStudentClassesCount()
        {
            Dictionary<string, int> studentClassesCount = new Dictionary<string, int>();

            // Your database connection string

            // Your SQL query to retrieve student classes count
            string query = "SELECT c.className, COUNT(*) FROM Student s INNER JOIN Class c ON s.classId = c.id GROUP BY c.className";

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string className = reader.GetString(0);
                    int count = reader.GetInt32(1);

                    studentClassesCount.Add(className, count);
                }

                reader.Close();
            }

            return studentClassesCount;
        }

    }
}