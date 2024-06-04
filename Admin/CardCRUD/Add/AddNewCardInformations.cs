using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.CardCRUD.Details;
using schoolManagementSystem.Admin.CardCRUD.Update;

namespace schoolManagementSystem.Admin.CardCRUD.Add
{
    public partial class AddNewCardInformations : Form
    {
        private string adminUsername;
        private string schoolName;
        private int studentId;
        public AddNewCardInformations(string adminUsername, string schoolName, int studentId)
        {
            InitializeComponent();
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            this.studentId = studentId;
        }

        private void AddNewCardInformations_Load(object sender, EventArgs e)
        {
            
                // Fetch student's information
                string studentQuery = "SELECT firstname, lastname, studentNumber, TCNumber, gender, email, classId, birthDate FROM student WHERE id = @studentId";

                using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(studentQuery, connection))
                    {
                        command.Parameters.AddWithValue("@studentId", studentId);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            studentName.Text = reader["firstname"].ToString();
                            studentSurname.Text = reader["lastname"].ToString();
                            studentGender.Text = reader["gender"].ToString();
                            studentMail.Text = reader["email"].ToString();
                            studentTC.Text = reader["TCNumber"].ToString();
                            studentSchoolNumber.Text = reader["studentNumber"].ToString();
                            studentBirthDateBox.Value = Convert.ToDateTime(reader["birthDate"]);

                            int classId = Convert.ToInt32(reader["classId"]);
                            string classQuery = "SELECT className FROM Class WHERE id = @classId";

                            reader.Close(); 

                            using (SqlCommand classCommand = new SqlCommand(classQuery, connection))
                            {
                                classCommand.Parameters.AddWithValue("@classId", classId);
                                SqlDataReader classReader = classCommand.ExecuteReader();

                                if (classReader.Read())
                                {
                                    studentClassname.Text = classReader["className"].ToString();
                                }

                                classReader.Close();
                            }
                        }
                    }
                }

                Random random = new Random();
                string cardNumberPart1 = random.Next(10000, 99999).ToString();
                string cardNumberPart2 = random.Next(10000, 99999).ToString();
                cardNumberBox.Text = cardNumberPart1 + cardNumberPart2;

                cardBalanceBox.Text = "0";
            
        }

        private void addCardBtn_Click(object sender, EventArgs e)
        {
            // Add the card to the database
            string addCardQuery = "INSERT INTO StudentCard (cardNumber, balance, studentId, isBlocked) VALUES (@cardNumber, @balance, @studentId, @isBlocked)";

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(addCardQuery, connection))
                {
                    command.Parameters.AddWithValue("@cardNumber", cardNumberBox.Text);
                    command.Parameters.AddWithValue("@balance", cardBalanceBox.Text);
                    command.Parameters.AddWithValue("@studentId", studentId);
                    command.Parameters.AddWithValue("@isBlocked", 0);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            
            string updateStudentQuery = "UPDATE Student SET hasOwnCard = 1 WHERE id = @studentId";

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(updateStudentQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            AddCardSuccess addCardSuccess = new AddCardSuccess(adminUsername, schoolName, studentId);
            addCardSuccess.StartPosition = FormStartPosition.Manual;
            addCardSuccess.Location = this.Location;
            this.Hide();
            addCardSuccess.ShowDialog();
            this.Close();
        }

        private void backIcon_Click(object sender, EventArgs e)
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

        private void updateCardBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70); 
            }
        }

        private void updateCardBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 50); 
            }
        }

        private void updateCardBtn_Click(object sender, EventArgs e)
        {
            UpdateCard updateCard = new UpdateCard(adminUsername, schoolName);
            updateCard.StartPosition = FormStartPosition.Manual;
            updateCard.Location = this.Location;
            this.Hide();
            updateCard.ShowDialog();
            this.Close();
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
                button.BackColor = Color.FromArgb(35, 35, 50); 
            }
        }

        private void cardActivityDetailsBtn_Click(object sender, EventArgs e)
        {
            StudentCardDetails studentCardDetails = new StudentCardDetails(adminUsername, schoolName);
            studentCardDetails.StartPosition = FormStartPosition.Manual;
            studentCardDetails.Location = this.Location;
            this.Hide();
            studentCardDetails.ShowDialog();
            this.Close();
        }
    }
}