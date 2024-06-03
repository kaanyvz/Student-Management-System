using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using schoolManagementSystem.Admin;

namespace schoolManagementSystem.Teacher
{
    public partial class TeacherLogin : Form
    {
        public TeacherLogin()
        {
            InitializeComponent();
        }

        private void loginAsAdminBtn_Click(object sender, EventArgs e)
        {
            AdminLogin loginForm = new AdminLogin();
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (emailBox.Text == "" || passwordBox.Text == "")
            {
                MessageBox.Show("Please provide Email and Password");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand(
                            "SELECT schoolId FROM Teacher " +
                            "WHERE email = @Email AND password = @Password",
                            connection);

                        cmd.Parameters.AddWithValue("@Email", emailBox.Text);
                        cmd.Parameters.AddWithValue("@Password", passwordBox.Text);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            reader.Read();
                            int schoolId = reader.GetInt32(0);
                            string schoolName = GetSchoolName(schoolId);
                            this.Hide();

                            TeacherLoginSettings teacherSettings = new TeacherLoginSettings(schoolName, emailBox.Text);
                            teacherSettings.ShowDialog();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Invalid Email or Password");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private string GetSchoolName(int schoolId)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT SchoolName " +
                    "FROM School " +
                    "WHERE id = @SchoolId", 
                    connection);
                
                cmd.Parameters.AddWithValue("@SchoolId", schoolId);
                return (string) cmd.ExecuteScalar();
            }
        }
    }
}