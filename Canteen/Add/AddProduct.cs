using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace schoolManagementSystem.Canteen.Add
{
    public partial class AddProduct : Form
    {
        private string canteenName;
        private string schoolName;
        public AddProduct(string canteenName, string schoolName)
        {
            this.canteenName = canteenName;
            this.schoolName = schoolName;
            InitializeComponent();
            this.AcceptButton = addProductBtn;
        }

        private void addProductBtn_Click(object sender, EventArgs e)
        {
            string productName = this.productName.Text;
            int stockCount = int.Parse(productStockCount.Text);
            decimal price = decimal.Parse(productPrice.Text, System.Globalization.CultureInfo.InvariantCulture);

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT id FROM Canteen WHERE canteenName = @CanteenName", 
                    connection);
                cmd.Parameters.AddWithValue("@CanteenName", canteenName);
                int canteenId = (int)cmd.ExecuteScalar();

                cmd = new SqlCommand(
                    "INSERT INTO CanteenProduct (canteenId, productName, price, stockCount) VALUES (@CanteenId, @ProductName, @Price, @StockCount)", 
                    connection);
                cmd.Parameters.AddWithValue("@CanteenId", canteenId);
                cmd.Parameters.AddWithValue("@ProductName", productName);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@StockCount", stockCount);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Product added successfully!");
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

        private void deleteProductBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.MediumSeaGreen;
            }
        }

        private void deleteProductBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.SeaGreen;
            }
        }
        

        private void productListBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.MediumSeaGreen;
            }
        }

        private void productListBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.SeaGreen;
            }
        }

        

        private void makeSaleBtn_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        
        private void deleteProductBtn_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void productListBtn_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void backIcon_Click(object sender, EventArgs e)
        {
            CanteenSettings canteenSettings = new CanteenSettings(canteenName, schoolName);
            canteenSettings.StartPosition = FormStartPosition.Manual;
            canteenSettings.Location = this.Location;
            this.Hide();
            canteenSettings.ShowDialog();
            this.Close();
        }
    }
}