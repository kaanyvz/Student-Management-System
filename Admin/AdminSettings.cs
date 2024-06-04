using System;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.CardCRUD;
using schoolManagementSystem.Admin.CardCRUD.Add;
using schoolManagementSystem.Admin.StudentCRUD;
using schoolManagementSystem.Admin.TeacherCRUD;

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
            UpdateInformationRichText();
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

        private void cardSettingsBtn_Click(object sender, EventArgs e)
        {
            AddNewCard addNewCard = new AddNewCard(adminUsername, schoolName);
            addNewCard.StartPosition = FormStartPosition.Manual;
            addNewCard.Location = this.Location;
            this.Hide();
            addNewCard.ShowDialog();
            this.Close();
        }

        private void teacherSettingsBtn_Click(object sender, EventArgs e)
        {
            TeacherSettings teacherSettings = new TeacherSettings(adminUsername, schoolName);
            teacherSettings.StartPosition = FormStartPosition.Manual;
            teacherSettings.Location = this.Location;
            this.Hide();
            teacherSettings.ShowDialog();
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