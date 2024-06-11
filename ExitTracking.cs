using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace schoolManagementSystem
{
    public partial class ExitTracking : Form
    {
        public ExitTracking()
        {
            InitializeComponent();
        }
        
        private void UpdateExitTracking(string cardNumber)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                // Get the id of the student card with the entered number
                SqlCommand cmd = new SqlCommand(
                    "SELECT id " +
                    "FROM StudentCard " +
                    "WHERE cardNumber = @CardNumber",
                    connection);

                cmd.Parameters.AddWithValue("@CardNumber", cardNumber);

                int? studentCardId = null;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        studentCardId = reader.GetInt32(0);
                    }
                }

                if (studentCardId.HasValue)
                {
                    // Update the exitTime in the EntranceTracking table
                    SqlCommand updateCmd = new SqlCommand(
                        "UPDATE EntranceTracking " +
                        "SET exitTime = @ExitTime " +
                        "WHERE studentCardId = @StudentCardId AND exitTime IS NULL",
                        connection);

                    updateCmd.Parameters.AddWithValue("@StudentCardId", studentCardId.Value);
                    updateCmd.Parameters.AddWithValue("@ExitTime", DateTime.Now);

                    int rowsAffected = updateCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Show a message box to confirm the process
                        MessageBox.Show("Exit tracking record has been successfully updated.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Show a message box if no matching record was found
                        MessageBox.Show($"No active entrance record found for student card {cardNumber}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Clear the text box
                    cardNumberBox.Text = string.Empty;
                }
                else
                {
                    // Show a message box if the student card does not exist
                    MessageBox.Show($"Student card {cardNumber} not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            string cardNumber = cardNumberBox.Text;
            UpdateExitTracking(cardNumber);
        }

        private void goEntranceScreenBtn_Click(object sender, EventArgs e)
        {
            EntranceTracking entranceTracking = new EntranceTracking();
            entranceTracking.StartPosition = FormStartPosition.Manual;
            entranceTracking.Location = this.Location;
            this.Hide();
            entranceTracking.ShowDialog();
            this.Close();
            
        }
    }
}