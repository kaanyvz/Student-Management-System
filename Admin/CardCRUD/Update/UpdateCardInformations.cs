using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.CardCRUD.Add;
using schoolManagementSystem.Admin.CardCRUD.Details;

namespace schoolManagementSystem.Admin.CardCRUD.Update
{
    public partial class UpdateCardInformations : Form
    {
        private string adminUsername;
        private string schoolName;
        private int studentId;
        public UpdateCardInformations(string adminUsername, string schoolName, int studentId)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            this.studentId = studentId;
            InitializeComponent();
            
        }
        
        private void UpdateCardInformations_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Student.*, StudentCard.*, Class.classname FROM StudentCard INNER JOIN Student ON StudentCard.studentId = Student.id INNER JOIN Class ON Student.classId = Class.id WHERE studentId = @StudentId", connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cardBalanceBox.Text = reader["balance"].ToString();
                            bool isBlocked = Convert.ToBoolean(reader["isBlocked"]);
                            blockedCheckBox.Checked = isBlocked;
                            notBlockedCheckBox.Checked = !isBlocked;
                            blockedCheckBox.CheckedChanged += blockedCheckBox_CheckedChanged;
                            notBlockedCheckBox.CheckedChanged += notBlockedCheckBox_CheckedChanged;
                            
                            
                            // Assuming you have these textboxes in your form
                            studentName.Text = reader["firstname"].ToString();
                            studentSchoolNumber.Text = reader["studentNumber"].ToString();
                            cardNumberBox.Text = reader["cardNumber"].ToString();
                            studentSurname.Text = reader["lastname"].ToString();
                            studentTC.Text = reader["studentNumber"].ToString();
                            studentClassname.Text = reader["classname"].ToString();
                            studentGender.Text = reader["gender"].ToString();
                            studentMail.Text = reader["email"].ToString();
                            studentBirthDateBox.Value = Convert.ToDateTime(reader["birthDate"]);
                        }
                    }
                }
            }
        }

        
        private void blockedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (blockedCheckBox.Checked)
            {
                notBlockedCheckBox.Checked = false;
            }
        }

        private void notBlockedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (notBlockedCheckBox.Checked)
            {
                blockedCheckBox.Checked = false;
            }
        }
        private void updateCardBtn_Click(object sender, EventArgs e)
        {
            decimal newCardBalance = decimal.Parse(cardBalanceBox.Text);
            bool isBlocked = blockedCheckBox.Checked;

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("UPDATE StudentCard SET balance = @CardBalance, isBlocked = @IsBlocked WHERE studentId = @StudentId", connection))
                {
                    command.Parameters.AddWithValue("@CardBalance", newCardBalance);
                    command.Parameters.AddWithValue("@IsBlocked", isBlocked);
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    command.ExecuteNonQuery();
                    
                    UpdateCardSuccess updateCardSuccess = new UpdateCardSuccess(adminUsername, schoolName);
                    updateCardSuccess.StartPosition = FormStartPosition.Manual;
                    updateCardSuccess.Location = this.Location;
                    this.Hide();
                    updateCardSuccess.ShowDialog();
                    this.Close();
                }
            }
        }


        private void backIcon_Click(object sender, EventArgs e)
        {
            UpdateCard updateCard = new UpdateCard(adminUsername, schoolName);
            updateCard.StartPosition = FormStartPosition.Manual;
            updateCard.Location = this.Location;
            this.Hide();
            updateCard.ShowDialog();
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

        private void cardDetailsBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70); 
            }
        }

        private void cardDetailsBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 50); 
            }
        }

        private void cardDetailsBtn_Click(object sender, EventArgs e)
        {
            StudentCardDetails studentCardDetails = new StudentCardDetails(adminUsername, schoolName);
            studentCardDetails.StartPosition = FormStartPosition.Manual;
            studentCardDetails.Location = this.Location;
            this.Hide();
            studentCardDetails.ShowDialog();
            this.Close();
            
        }

        private void addNewCardBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70); 
            }
        }

        private void addNewCardBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 50); 
            }
        }

        private void addNewCardBtn_Click(object sender, EventArgs e)
        {
            AddNewCard addNewCard = new AddNewCard(adminUsername, schoolName);
            addNewCard.StartPosition = FormStartPosition.Manual;
            addNewCard.Location = this.Location;
            this.Hide();
            addNewCard.ShowDialog();
            this.Close();
        }
    }
}