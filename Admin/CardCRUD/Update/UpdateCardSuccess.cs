using System;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.CardCRUD.Add;

namespace schoolManagementSystem.Admin.CardCRUD.Update
{
    public partial class UpdateCardSuccess : Form
    {
        private string adminUsername;
        private string schoolName;
        
        public UpdateCardSuccess(string adminUsername, string schoolName)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            CardSettings cardSettings = new CardSettings(adminUsername, schoolName);
            cardSettings.StartPosition = FormStartPosition.Manual;
            cardSettings.Location = this.Location;
            this.Hide();
            cardSettings.ShowDialog();
            this.Close();
        }

        private void addNewCardButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void addNewCardButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void addNewCardButton_Click(object sender, EventArgs e)
        {
            AddNewCard addNewCard = new AddNewCard(adminUsername, schoolName);
            addNewCard.StartPosition = FormStartPosition.Manual;
            addNewCard.Location = this.Location;
            this.Hide();
            addNewCard.ShowDialog();
            this.Close();
        }

        private void deleteStudentCardButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void deleteStudentCardButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void cardActivityDetailsBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void cardActivityDetailsBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }
    }
}