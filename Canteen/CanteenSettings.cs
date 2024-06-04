using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;
using schoolManagementSystem.Canteen.Add;
using schoolManagementSystem.Canteen.Sale;

namespace schoolManagementSystem.Canteen
{
    public partial class CanteenSettings : Form
    {
        private string canteenName;
        private string schoolName;
        
        public CanteenSettings(string canteenName, string schoolName)
        {
            this.canteenName = canteenName;
            this.schoolName = schoolName;
            InitializeComponent();
            
        }

        private void CanteenSettings_Load(object sender, EventArgs e)
        {
            
            periodDropdown.Items.AddRange(new object[] { "Year", "Month", "Week", "Day" });
            periodDropdown.SelectedIndex = 1; // Select the first item by default
            periodDropdown.SelectedIndexChanged += PeriodDropdown_SelectedIndexChanged;
            
            FetchAndDisplayData();
        }
        
        private void PeriodDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            FetchAndDisplayData();
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
                    string timeConstraint = "1=1"; // Default time constraint that always evaluates to true
                    string groupBy = "cp.purchaseDate"; // Default group by clause

                    switch (selectedPeriod)
                    {
                        case "Year":
                            timeConstraint = $" YEAR(cp.purchaseDate) = YEAR(GETDATE())";
                            groupBy = "CAST(cp.purchaseDate AS DATE)"; // Group by date part of purchaseDate
                            break;
                        case "Month":
                            timeConstraint = $" YEAR(cp.purchaseDate) = YEAR(GETDATE()) AND MONTH(cp.purchaseDate) = MONTH(GETDATE())";
                            groupBy = "CAST(cp.purchaseDate AS DATE)"; // Group by date part of purchaseDate
                            break;
                        case "Week":
                            DateTime startOfWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                            string formattedStartOfWeek = startOfWeek.ToString("yyyy-MM-dd");
                            timeConstraint = $" cp.purchaseDate >= '{formattedStartOfWeek}' AND cp.purchaseDate < DATEADD(wk, DATEDIFF(wk, 0, GETDATE()) + 1, 0)";
                            groupBy = "CAST(cp.purchaseDate AS DATE)"; // Group by date part of purchaseDate
                            break;
                        case "Day":
                            timeConstraint = " CAST(cp.purchaseDate AS DATE) = CAST(GETDATE() AS DATE)";
                            groupBy = "DATEPART(hour, cp.purchaseDate)"; // Group by hour part of purchaseDate
                            break;
                        default:
                            break;
                    }

                    // Query to find schoolId from schoolName
                    string schoolIdQuery = "SELECT id FROM School WHERE schoolName = @schoolName";

                    using (SqlCommand schoolIdCommand = new SqlCommand(schoolIdQuery, connection))
                    {
                        schoolIdCommand.Parameters.AddWithValue("@schoolName", schoolName);

                        // Execute the query to get the schoolId
                        int schoolId = (int)schoolIdCommand.ExecuteScalar();

                        string query = $"SELECT {groupBy} as PurchaseDate, SUM(pr.price * cp.purchaseAmount) as TotalIncome " +
                                       "FROM CanteenPurchase cp " +
                                       "INNER JOIN CanteenProduct pr ON cp.canteenProductId = pr.id " +
                                       "INNER JOIN Canteen c ON pr.canteenId = c.id " +
                                       $"WHERE c.schoolId = @schoolId AND {timeConstraint} " +
                                       $"GROUP BY {groupBy} " +
                                       "ORDER BY PurchaseDate";

                        Console.WriteLine(query); // Print out the SQL query for debugging

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@schoolId", schoolId);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                var dateValues = new ChartValues<string>();
                                var incomeValues = new ChartValues<double>();

                                while (reader.Read())
                                {
                                    string purchaseDate = reader["PurchaseDate"].ToString();
                                    double totalIncome = Convert.ToDouble(reader["TotalIncome"]);

                                    dateValues.Add(purchaseDate);
                                    incomeValues.Add(totalIncome);

                                    Console.WriteLine($"Date: {purchaseDate}, Income: {totalIncome}"); // Print out the data for debugging
                                }

                                cartesianChart1.Series = new SeriesCollection
                                {
                                    new LineSeries
                                    {
                                        Values = incomeValues
                                    }
                                };

                                cartesianChart1.AxisX.Add(new Axis
                                {
                                    Title = "Date",
                                    Labels = dateValues.ToList()
                                });

                                cartesianChart1.AxisY.Add(new Axis
                                {
                                    Title = "Income",
                                    MinValue = 0,
                                    Separator = new Separator { Step = 20 },
                                    LabelFormatter = value => $"{value} ₺"
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
        }

        private void addNewProductBtn_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct(canteenName, schoolName);
            addProduct.StartPosition = FormStartPosition.Manual;
            addProduct.Location = this.Location;
            this.Hide();
            addProduct.ShowDialog();
            this.Close();
            
        }

        private void makeSaleBtn_Click(object sender, EventArgs e)
        {
            MakeSale makeSale = new MakeSale(canteenName, schoolName);
            makeSale.StartPosition = FormStartPosition.Manual;
            makeSale.Location = this.Location;
            this.Hide();
            makeSale.ShowDialog();
            this.Close();
        }

        private void makeSaleBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.MediumSeaGreen;
            }
        }

        private void makeSaleBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.SeaGreen;
            }
        }

        private void addNewProductBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.MediumSeaGreen;
            }
        }

        private void addNewProductBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.SeaGreen;
            }
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