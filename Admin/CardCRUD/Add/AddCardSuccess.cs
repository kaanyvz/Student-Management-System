using System;
using System.Windows.Forms;

namespace schoolManagementSystem.Admin.CardCRUD.Add
{
    public partial class AddCardSuccess : Form
    {
        private string adminUsername;
        private string schoolName;
        private int cardId;
        public AddCardSuccess(string adminUsername, string schoolName, int cardId)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            this.cardId = cardId;
            InitializeComponent();
            
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            AddNewCard addNewCard = new AddNewCard(adminUsername, schoolName);
            addNewCard.StartPosition = FormStartPosition.Manual;
            addNewCard.Location = this.Location;
            this.Hide();
            addNewCard.ShowDialog();
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