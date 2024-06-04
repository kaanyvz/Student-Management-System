using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using LiveCharts.Wpf;
using System.Windows.Forms;
using LiveCharts;
using schoolManagementSystem.Admin.CardCRUD.Add;
using schoolManagementSystem.Admin.CardCRUD.Update;

namespace schoolManagementSystem.Admin.CardCRUD.Details
{
    public partial class StudentCardDetailsInfos : Form
    {
        private string adminUsername;
        private string schoolName;
        private int studentId;
        public StudentCardDetailsInfos(string adminUsername, string schoolName, int studentId)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            this.studentId = studentId;
            InitializeComponent();
            InitializePeriodDropdown();
        }

        private void StudentCardDetailsInfos_Load(object sender, EventArgs e)
        {
            FetchStudentCardDetails();
            FetchAndDisplayData();
        }

        private void InitializePeriodDropdown()
        {
            periodDropdown.Items.AddRange(new object[] { "Year", "Month", "Week", "Day" });
            periodDropdown.SelectedIndex = 0; // Select the first item by default
            periodDropdown.SelectedIndexChanged += PeriodDropdown_SelectedIndexChanged;
        }

        private void PeriodDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchAndDisplayData();
        }

        private void FetchStudentCardDetails()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                // Fetch student information
                string studentQuery = "SELECT s.firstname, s.lastname, s.TCNumber, s.studentNumber, s.email, s.gender, s.birthDate, c.classname " +
                                      "FROM Student s " +
                                      "INNER JOIN Class c ON s.classId = c.id " +
                                      "WHERE s.id = @studentId";
                using (SqlCommand command = new SqlCommand(studentQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        studentName.Text = reader["firstname"].ToString();
                        studentSurname.Text = reader["lastname"].ToString();
                        studentTC.Text = reader["TCNumber"].ToString();
                        studentSchoolNumber.Text = reader["studentNumber"].ToString();
                        studentMail.Text = reader["email"].ToString();
                        studentGender.Text = reader["gender"].ToString();
                        studentClass.Text = reader["classname"].ToString();
                        studentBirthdate.Text = reader["birthDate"].ToString();
                        
                        nameSurnameRichBox.Text = $"          {studentName.Text} {studentSurname.Text}";
                        nameSurnameRichBox.Font = new Font("Times New Roman", 14, FontStyle.Bold);
                    }
                    reader.Close();
                }

                // Fetch card information
                string cardQuery = "SELECT cardNumber, balance, isBlocked FROM StudentCard WHERE studentId = @studentId";
                using (SqlCommand command = new SqlCommand(cardQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        cardNumberBox.Text = reader["cardNumber"].ToString();
                        balanceBox.Text = reader["balance"].ToString();
                        statusBox.Text = (bool)reader["isBlocked"] ? "BLOCKED" : "ACTIVE";
                    }
                    reader.Close();
                }

                // Fetch purchase history and calculate total spent
                string purchaseQuery = "SELECT cp.id, cp.purchaseAmount, cp.purchaseDate, pr.price " +
                                       "FROM CanteenPurchase cp " +
                                       "INNER JOIN dbo.CanteenProduct pr ON cp.canteenProductId = pr.id " +
                                       "WHERE cp.studentId = @studentId";
                using (SqlCommand command = new SqlCommand(purchaseQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    SqlDataReader reader = command.ExecuteReader();
                    double totalSpent = 0;
                    while (reader.Read())
                    {
                        double price = Convert.ToDouble(reader["price"]);
                        int purchaseAmount = Convert.ToInt32(reader["purchaseAmount"]);
                        totalSpent += price * purchaseAmount;
                    }
                    totalSpentBox.Text = totalSpent.ToString() + " ₺";
                    reader.Close();
                }
                
                string mostPurchasedProductQuery = "SELECT pr.productName " +
                                           "FROM (SELECT canteenProductId, COUNT(*) as purchaseCount " +
                                                 "FROM CanteenPurchase " +
                                                 "WHERE studentId = @studentId " +
                                                 "GROUP BY canteenProductId) as cp " +
                                           "INNER JOIN CanteenProduct pr ON cp.canteenProductId = pr.id " +
                                           "WHERE cp.purchaseCount = (SELECT MAX(purchaseCount) FROM (SELECT COUNT(*) as purchaseCount " +
                                                                     "FROM CanteenPurchase " +
                                                                     "WHERE studentId = @studentId " +
                                                                     "GROUP BY canteenProductId) as cp)";
                using (SqlCommand command = new SqlCommand(mostPurchasedProductQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    SqlDataReader reader = command.ExecuteReader();
                    string mostPurchasedProducts = "";
                    while (reader.Read())
                    {
                        mostPurchasedProducts += reader["productName"].ToString() + ", ";
                    }
                    mostPurchasedProductBox.Text = mostPurchasedProducts.TrimEnd(',', ' ');
                    reader.Close();
                }

                // Fetch total spent this month
                string totalSpentThisMonthQuery = "SELECT SUM(pr.price * cp.purchaseAmount) as totalSpent " +
                                                  "FROM CanteenPurchase cp " +
                                                  "INNER JOIN CanteenProduct pr ON cp.canteenProductId = pr.id " +
                                                  "WHERE cp.studentId = @studentId AND MONTH(cp.purchaseDate) = MONTH(GETDATE()) AND YEAR(cp.purchaseDate) = YEAR(GETDATE())";
                using (SqlCommand command = new SqlCommand(totalSpentThisMonthQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    object result = command.ExecuteScalar();
                    double totalSpentThisMonth = result != DBNull.Value ? Convert.ToDouble(result) : 0;
                    totalSpentThisMonthBox.Text = totalSpentThisMonth.ToString() + " ₺";
                }
            }
        }

        private void FetchAndDisplayData()
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                try
                {
                    connection.Open();

                    // Clear previous chart data
                    cartesianChart1.Series.Clear();
                    cartesianChart1.AxisX.Clear();
                    cartesianChart1.AxisY.Clear();

                    string selectedPeriod = periodDropdown.SelectedItem.ToString();
                    string timeConstraint = "";

                    switch (selectedPeriod)
                    {
                        case "Year":
                            timeConstraint = "AND YEAR(cp.purchaseDate) = YEAR(GETDATE())";
                            break;
                        case "Month":
                            timeConstraint = "AND MONTH(cp.purchaseDate) = MONTH(GETDATE()) AND YEAR(cp.purchaseDate) = YEAR(GETDATE())";
                            break;
                        case "Week":
                            DateTime startDate = DateTime.Today.AddDays(-6);
                            // Format the date to match SQL format (yyyy-MM-dd)
                            string formattedStartDate = startDate.ToString("yyyy-MM-dd");
                            // Construct the time constraint
                            timeConstraint = $"AND cp.purchaseDate >= '{formattedStartDate}' AND cp.purchaseDate <= GETDATE()";
                            break;
                        case "Day":
                            timeConstraint = "AND CAST(cp.purchaseDate AS DATE) = CAST(GETDATE() AS DATE)";
                            break;
                        default:
                            break;
                    }

                    string query = "SELECT cp.purchaseDate as PurchaseDate, SUM(pr.price * cp.purchaseAmount) as TotalSpent " +
                                   "FROM CanteenPurchase cp " +
                                   "INNER JOIN CanteenProduct pr ON cp.canteenProductId = pr.id " +
                                   $"WHERE cp.studentId = @studentId {timeConstraint} " +
                                   "GROUP BY cp.purchaseDate " +
                                   "ORDER BY PurchaseDate";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentId", studentId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            var dateValues = new ChartValues<DateTime>();
                            var spentValues = new ChartValues<double>();

                            while (reader.Read())
                            {
                                dateValues.Add(Convert.ToDateTime(reader["PurchaseDate"]));
                                spentValues.Add(Convert.ToDouble(reader["TotalSpent"]));
                            }

                            cartesianChart1.Series = new SeriesCollection
                            {
                                new LineSeries
                                {
                                    Values = spentValues
                                }
                            };

                            cartesianChart1.AxisX.Add(new Axis
                            {
                                Title = "Date",
                                Labels = dateValues.Select(date => date.ToString("yyyy-MM-dd")).ToList()
                            });

                            cartesianChart1.AxisY.Add(new Axis
                            {
                                Title = "Spent",
                                MinValue = 0,
                                MaxValue = 200,
                                Separator = new Separator { Step = 20 },
                                LabelFormatter = value => $"{value} ₺"
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }



        private void backIcon_Click(object sender, EventArgs e)
        {
            StudentCardDetails studentCardDetails = new StudentCardDetails(adminUsername, schoolName);
            studentCardDetails.StartPosition = FormStartPosition.Manual;
            studentCardDetails.Location = this.Location;
            this.Hide();
            studentCardDetails.ShowDialog();
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
                button.BackColor = Color.FromArgb(35, 35, 50); 
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

        private void updateCardButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70); 
            }
        }

        private void updateCardButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 50); 
            }
        }

        private void updateCardButton_Click(object sender, EventArgs e)
        {
            UpdateCard updateCard = new UpdateCard(adminUsername, schoolName);
            updateCard.StartPosition = FormStartPosition.Manual;
            updateCard.Location = this.Location;
            this.Hide();
            updateCard.ShowDialog();
            this.Close();
        }
    }
}