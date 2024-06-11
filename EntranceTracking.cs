using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace schoolManagementSystem
{
    public partial class EntranceTracking : Form
    {
        public EntranceTracking()
        {
            InitializeComponent();
        }
        
        private void InsertEntranceTracking(string cardNumber)
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
                    // Insert a new row into the EntranceTracking table
                    SqlCommand insertCmd = new SqlCommand(
                        "INSERT INTO EntranceTracking (studentCardId, entranceTime, exitTime) " +
                        "VALUES (@StudentCardId, @EntranceTime, NULL)",
                        connection);

                    insertCmd.Parameters.AddWithValue("@StudentCardId", studentCardId.Value);
                    insertCmd.Parameters.AddWithValue("@EntranceTime", DateTime.Now);

                    insertCmd.ExecuteNonQuery();

                    // Show a message box to confirm the process
                    MessageBox.Show("Entrance tracking record has been successfully inserted.", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            InsertEntranceTracking(cardNumber);
        }

        private void goExitScreenBtn_Click(object sender, EventArgs e)
        {
            ExitTracking exitTracking = new ExitTracking();
            exitTracking.StartPosition = FormStartPosition.Manual;
            exitTracking.Location = this.Location;
            this.Hide();
            exitTracking.ShowDialog();
            this.Close();
        }
    }
}