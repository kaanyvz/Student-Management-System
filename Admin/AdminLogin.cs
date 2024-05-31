﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using schoolManagementSystem.Teacher;

namespace schoolManagementSystem.Admin
{
    public partial class AdminLogin : Form
    {

        public AdminLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.AcceptButton = loginBtn;
            
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateTimeLabel();
        }
    
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTimeLabel();
        }

        private void UpdateTimeLabel()
        {
            labelTime.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameBox.Text == "" || passwordBox.Text == "")
            {
                MessageBox.Show("Please provide UserName and Password");
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
                {
                    try
                    {
                        connection.Open();

                        SqlCommand cmd = new SqlCommand(
                            "SELECT COUNT(*) FROM SchoolAdmin " +
                            "WHERE username = @Username AND password = @Password", 
                            connection);
                        
                        cmd.Parameters.AddWithValue("@Username", usernameBox.Text); 
                        cmd.Parameters.AddWithValue("@Password", passwordBox.Text);
                        int count = (int)cmd.ExecuteScalar();


                        if (count > 0)
                        {
                            string adminUsername = usernameBox.Text;
                            string schoolName = GetSchoolName(adminUsername);
                            this.Hide();

                            SplashScreen splashScreen = new SplashScreen();
                            splashScreen.StartPosition = FormStartPosition.Manual;
                            splashScreen.Location = this.Location;
                            splashScreen.Show();
                            Timer timer = new Timer();
                            timer.Start();

                            timer.Interval = 1000; 
                            timer.Tick += (s, args) =>
                            {
                                timer.Stop();
                                splashScreen.Close();

                                AdminSettings adminSettings = new AdminSettings(adminUsername, schoolName);
                                adminSettings.StartPosition = FormStartPosition.Manual;
                                adminSettings.Location = this.Location;
                                adminSettings.ShowDialog();
                                this.Close();
                            };
                        }
                        else
                        {
                            MessageBox.Show("Invalid Username or Password");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void loginAsTeacherBtn_Click(object sender, EventArgs e)
        {
            TeacherLogin teacherLogin = new TeacherLogin();
            this.Hide();
            teacherLogin.ShowDialog();
            this.Close();
        }
        
        private string GetSchoolName(string adminUsername)
        {
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
                return (string) cmd.ExecuteScalar();
            }
        }
    }
}




