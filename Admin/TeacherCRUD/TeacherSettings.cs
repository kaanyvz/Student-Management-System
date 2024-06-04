using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using LiveCharts.Wpf;
using LiveCharts;
using schoolManagementSystem.Admin.TeacherCRUD.Add;
using schoolManagementSystem.Admin.TeacherCRUD.Delete;
using schoolManagementSystem.Admin.TeacherCRUD.Details;
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
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen; // Add this line
            InitializeComponent();
        }

        private void TeacherSettings_Load_1(object sender, EventArgs e)
        {
            LoadTeacherMajors();
        }

        private void LoadTeacherMajors()
        {
            // Assuming you have a method to retrieve data from your database
            Dictionary<string, int> teacherMajorsCount = GetTeacherMajorsCount();

            // Clear previous data from the chart
            pieChart1.Series.Clear();

            // Add data to the chart
            SeriesCollection seriesCollection = new SeriesCollection();
            richTextBox1.Clear();

            // Calculate total teacher count
            int totalTeacherCount = 0;
            foreach (var majorCount in teacherMajorsCount)
            {
                totalTeacherCount += majorCount.Value;
            }

            richTextBox1.AppendText($"In {schoolName}, there're {totalTeacherCount} teachers.\n\n");
            foreach (var majorCount in teacherMajorsCount)
            {
                seriesCollection.Add(new PieSeries
                {
                    Title = majorCount.Key,
                    Values = new ChartValues<int> { majorCount.Value },
                    DataLabels = true
                });
                richTextBox1.AppendText($"{majorCount.Value} {majorCount.Key},\n");
            }
            richTextBox1.AppendText("\nTo make teacher operations, you can select one of the options in sidebar.");


            pieChart1.Series = seriesCollection;
        }

        // Method to retrieve teacher majors count from the database
        private Dictionary<string, int> GetTeacherMajorsCount()
        {
            Dictionary<string, int> teacherMajorsCount = new Dictionary<string, int>();

            // Your database connection string

            // Your SQL query to retrieve schoolId
            string schoolIdQuery = "SELECT id FROM School WHERE schoolName = @schoolName";

            int schoolId;
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                SqlCommand command = new SqlCommand(schoolIdQuery, connection);
                command.Parameters.AddWithValue("@schoolName", schoolName);
                connection.Open();

                schoolId = (int)command.ExecuteScalar();
            }

            // Your SQL query to retrieve teacher majors count
            string query = "SELECT Major, COUNT(*) FROM Teacher WHERE schoolId = @schoolId GROUP BY Major";

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@schoolId", schoolId);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string major = reader.GetString(0);
                    int count = reader.GetInt32(1);

                    teacherMajorsCount.Add(major, count);
                }

                reader.Close();
            }

            return teacherMajorsCount;
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
            TeacherDetails teacherDetails = new TeacherDetails(adminUsername, schoolName);
            teacherDetails.StartPosition = FormStartPosition.Manual;
            teacherDetails.Location = this.Location;
            this.Hide();
            teacherDetails.ShowDialog();
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
