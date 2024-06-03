using System;
using System.Data.SqlClient;
using System.Windows.Forms;

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
    }
}