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
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if(emailBox.Text == "" || passwordBox.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
            }
            else
            {
                using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
                {
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand sqlCommand = new SqlCommand(
                            "SELECT COUNT(*) FROM SchoolManagementSystem.dbo.Teacher " +
                            "WHERE email = @Email AND password = @Password",
                            sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@Email", emailBox.Text);
                        sqlCommand.Parameters.AddWithValue("@Password", passwordBox.Text);
                        int result = (int) sqlCommand.ExecuteScalar();
                        
                        if (result > 0)
                        {
                            //print success message
                            MessageBox.Show("Login Successful");
                        }
                        else
                        {
                            MessageBox.Show("Login Failed");
                        }
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                        throw;
                    }
                }
            }
        }
    }
}