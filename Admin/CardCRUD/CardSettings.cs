using System;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.CardCRUD.Add;
using schoolManagementSystem.Admin.CardCRUD.Update;

namespace schoolManagementSystem.Admin.CardCRUD
{
    public partial class CardSettings : Form
    {
        private string adminUsername;
        private string schoolName;
        public CardSettings(string adminUsername, string schoolName)
        {
            InitializeComponent();
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            AddNewCard addNewCard = new AddNewCard(adminUsername, schoolName);
            addNewCard.StartPosition = FormStartPosition.Manual;
            addNewCard.Location = this.Location;
            this.Hide();
            addNewCard.ShowDialog();
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
            UpdateCard updateCard = new UpdateCard(adminUsername, schoolName);
            updateCard.StartPosition = FormStartPosition.Manual;
            updateCard.Location = this.Location;
            this.Hide();
            updateCard.ShowDialog();
            this.Close();
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

        private void studentDetailsBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void studentDetailsBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }
    }
}