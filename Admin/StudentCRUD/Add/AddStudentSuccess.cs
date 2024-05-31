using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace schoolManagementSystem.Admin.StudentCRUD.Add
{
    public partial class AddStudentSuccess : Form
    {
        
        private string adminUsername;
        private string schoolName;
        public AddStudentSuccess(int studentId, int parentId, string adminUsername, string schoolName)
        {
            InitializeComponent();
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;

            string studentName = GetStudentName(studentId);
            string parentName = GetParentName(parentId);

            richTextBoxInside.Text = $"  *{studentName} has successfully been added to the system." +"\n" + $"  *{parentName} has successfully been added to the system.";
            richTextBoxInside.Font = new Font("Times New Roman", 14, FontStyle.Bold);
        }

        private string GetStudentName(int studentId)
        {
            string studentName = "";

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT firstname, lastname FROM Student WHERE id = @StudentId", 
                    connection);
                cmd.Parameters.AddWithValue("@StudentId", studentId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        studentName = $"{reader["firstname"]} {reader["lastname"]}";
                    }
                }
            }

            return studentName;
        }

        private string GetParentName(int parentId)
        {
            string parentName = "";

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT firstname, lastname FROM Parent WHERE id = @ParentId", 
                    connection);
                cmd.Parameters.AddWithValue("@ParentId", parentId);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        parentName = $"{reader["firstname"]} {reader["lastname"]}";
                    }
                }
            }

            return parentName;
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