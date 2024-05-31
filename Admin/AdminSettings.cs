using System;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.StudentCRUD;

namespace schoolManagementSystem.Admin
{
    public partial class AdminSettings : Form
    {
        
        private string adminUsername;
        private string schoolName;

        public AdminSettings(string adminUsername, string schoolName)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
        }
        
        
        private void AdminDashboardForm_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
            timer.Start();

            UpdateTimeLabel();
            UpdateInformationRichText();
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTimeLabel();
        }

        private void UpdateTimeLabel()
        {
            labelTime.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }
        
        private void UpdateInformationRichText()
        {
            informationRichText.Text = $"   Dear {adminUsername},\n\n" +
                                       $"   Welcome to {schoolName}  Management System!\n\n" +
                                       $"   You can manage the school by using the options on the left side of the screen.\n\n" +
                                       $"   If you have any questions, please contact the system administrator.\n\n" +
                                       $"   Best Regards,\n" +
                                       $"   {schoolName} School Management System";
                                       
        }
        
        
        private void studentSettingsBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void studentSettingsBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }
        
        private void cardSettingsBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void cardSettingsBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }
        
        private void teacherSettingsBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70); 
            }
        }
        
        private void teacherSettingsBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }


        private void studentSettingsBtn_Click(object sender, EventArgs e)
        {
            StudentSettings studentSettings = new StudentSettings(adminUsername, schoolName);
            studentSettings.StartPosition = FormStartPosition.Manual;
            studentSettings.Location = this.Location;
            this.Hide();
            studentSettings.ShowDialog();
            this.Close(); 
            
        }

        private void backIcon_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                AdminLogin adminLogin = new AdminLogin();
                adminLogin.StartPosition = FormStartPosition.Manual;
                adminLogin.Location = this.Location;
                this.Hide();
                adminLogin.ShowDialog();
                this.Close(); 
            }
            
        }
    }
}