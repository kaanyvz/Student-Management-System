using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using schoolManagementSystem.Admin;
using schoolManagementSystem.Teacher;

namespace schoolManagementSystem.Canteen
{
    public partial class CanteenLogin : Form
    {
        
        public CanteenLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.AcceptButton = loginBtn;
            this.StartPosition = FormStartPosition.CenterScreen;
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

        private void canteenOwnerBtn_Click(object sender, EventArgs e)
        {
            TeacherLogin loginForm = new TeacherLogin();
            loginForm.StartPosition = FormStartPosition.Manual;
            loginForm.Location = this.Location;
            this.Hide();
            loginForm.ShowDialog();
            this.Close();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string canteenName = canteenNameBox.Text;
            string canteenPassword = canteenPasswordBox.Text;

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand cmd = new SqlCommand(
                        "SELECT COUNT(*), schoolId FROM Canteen " +
                        "WHERE canteenName = @CanteenName AND canteenPassword = @CanteenPassword group by schoolId", 
                        connection);
            
                    cmd.Parameters.AddWithValue("@CanteenName", canteenName); 
                    cmd.Parameters.AddWithValue("@CanteenPassword", canteenPassword);
            
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() && reader.GetInt32(0) > 0)
                    {
                        int schoolId = reader.GetInt32(1);
                        reader.Close();

                        cmd = new SqlCommand(
                            "SELECT SchoolName FROM School " +
                            "WHERE id = @SchoolId", 
                            connection);
                
                        cmd.Parameters.AddWithValue("@SchoolId", schoolId);
                        string schoolName = (string) cmd.ExecuteScalar();

                        CanteenSettings canteenSettings = new CanteenSettings(canteenName, schoolName);
                        canteenSettings.StartPosition = FormStartPosition.Manual;
                        canteenSettings.Location = this.Location;
                        this.Hide();
                        canteenSettings.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Canteen Name or Password");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
    }
}