using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace schoolManagementSystem.Canteen.Sale
{
    public partial class MakeSale : Form
    {
        private string canteenName;
        private string schoolName;
        private List<ComboBox> productNameBoxes = new List<ComboBox>(); // Changed to ComboBox
        private List<ComboBox> productCountBoxes = new List<ComboBox>();

        public MakeSale(string canteenName, string schoolName)
        {
            InitializeComponent();
            this.canteenName = canteenName;
            this.schoolName = schoolName;

            // Add initial ComboBoxes to the lists
            productNameBoxes.Add(productDropdown);
            productCountBoxes.Add(countDropdown);
            
            FillCountDropdown(countDropdown);
            FillProductDropdown(productDropdown);
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            // Create new ComboBox for product name
            ComboBox newProductNameBox = new ComboBox
            {
                Font = productDropdown.Font,
                Location = new Point(productNameBoxes[productNameBoxes.Count - 1].Location.X, productNameBoxes[productNameBoxes.Count - 1].Location.Y + productNameBoxes[productNameBoxes.Count - 1].Height + 10),
                Size = productDropdown.Size
            };
            
            

            // Create new ComboBox for product count
            ComboBox newProductCountBox = new ComboBox
            {
                Font = countDropdown.Font,
                Location = new Point(productCountBoxes[productCountBoxes.Count - 1].Location.X, productCountBoxes[productCountBoxes.Count - 1].Location.Y + productCountBoxes[productCountBoxes.Count - 1].Height + 10),
                Size = countDropdown.Size
            };

            // Add new ComboBoxes to the lists
            productNameBoxes.Add(newProductNameBox);
            productCountBoxes.Add(newProductCountBox);

            // Add new ComboBoxes to the form
            this.Controls.Add(newProductNameBox);
            this.Controls.Add(newProductCountBox);
            
            FillProductDropdown(newProductNameBox);
            FillCountDropdown(newProductCountBox);

            // Refresh the form
            this.Refresh();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            // Check if there are more than one ComboBoxes
            if (productNameBoxes.Count > 1 && productCountBoxes.Count > 1)
            {
                // Remove the last ComboBoxes from the form
                this.Controls.Remove(productNameBoxes[productNameBoxes.Count - 1]);
                this.Controls.Remove(productCountBoxes[productCountBoxes.Count - 1]);

                // Remove the last ComboBoxes from the lists
                productNameBoxes.RemoveAt(productNameBoxes.Count - 1);
                productCountBoxes.RemoveAt(productCountBoxes.Count - 1);

                // Refresh the form
                this.Refresh();
            }
        }
        
        private void FillProductDropdown(ComboBox comboBox)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT CP.productName " +
                    "FROM Canteen C " +
                    "INNER JOIN CanteenProduct CP ON C.id = CP.canteenId " +
                    "WHERE C.canteenName = @CanteenName",
                    connection);

                cmd.Parameters.AddWithValue("@CanteenName", canteenName);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string productName = reader.GetString(0);
                        comboBox.Items.Add(productName);
                    }
                }
            }
        }

        private void FillCountDropdown(ComboBox comboBox)
        {
            for (int i = 1; i <= 20; i++)
            {
                comboBox.Items.Add(i);
            }
        }

        private void purchaseBtn_Click(object sender, EventArgs e)
        {
            int studentId = GetStudentId(studentNumber.Text);
            int parentId = GetParentId(studentId);

            for (int i = 0; i < productNameBoxes.Count; i++)
            {
                string productName = productNameBoxes[i].SelectedItem.ToString();
                int productCount = int.Parse(productCountBoxes[i].SelectedItem.ToString());

                int productId = GetProductId(productName);

                if (IsProductRestricted(parentId, productId))
                {
                    MessageBox.Show($"Cannot sell product {productName} to student {studentNumber.Text} as it is restricted by their parent.");
                    return;
                }

                int productStock = GetProductStock(productId);
                if (productStock < productCount)
                {
                    MessageBox.Show($"Cannot sell product {productName} as there is not that much stock.");
                    return;
                }

                InsertPurchase(studentId, productId, productCount);
                DecreaseProductStock(productId, productCount);
                MessageBox.Show($"Successfully purchased.");
            }
        }

        private int GetProductStock(int productId)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT CP.stockCount " +
                    "FROM CanteenProduct CP " +
                    "WHERE CP.id = @ProductId",
                    connection);

                cmd.Parameters.AddWithValue("@ProductId", productId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        throw new Exception($"Product with ID {productId} not found in the database.");
                    }
                }
            }
        }

        private void DecreaseProductStock(int productId, int productCount)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    "UPDATE CanteenProduct " +
                    "SET stockCount = stockCount - @ProductCount " +
                    "WHERE id = @ProductId",
                    connection);

                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@ProductCount", productCount);

                cmd.ExecuteNonQuery();
            }
        }

        private int GetParentId(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT SP.parentId " +
                    "FROM StudentParents SP " +
                    "WHERE SP.studentId = @StudentId",
                    connection);

                cmd.Parameters.AddWithValue("@StudentId", studentId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        throw new Exception($"Parent for student with ID {studentId} not found in the database.");
                    }
                }
            }
        }

        private bool IsProductRestricted(int parentId, int productId)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) " +
                    "FROM ParentRestriction PR " +
                    "WHERE PR.parentId = @ParentId AND PR.canteenProductId = @ProductId",
                    connection);

                cmd.Parameters.AddWithValue("@ParentId", parentId);
                cmd.Parameters.AddWithValue("@ProductId", productId);

                int count = (int)cmd.ExecuteScalar();

                return count > 0;
            }
        }

        private int GetStudentId(string enteredNumber)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT S.id " +
                    "FROM Student S " +
                    "WHERE S.studentNumber = @Number",
                    connection);

                cmd.Parameters.AddWithValue("@Number", enteredNumber);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        throw new Exception($"Student with number {enteredNumber} not found in the database.");
                    }
                }
            }
        }

        private int GetProductId(string productName)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT CP.id " +
                    "FROM CanteenProduct CP " +
                    "WHERE CP.productName = @ProductName",
                    connection);

                cmd.Parameters.AddWithValue("@ProductName", productName);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetInt32(0);
                    }
                    else
                    {
                        throw new Exception($"Product {productName} not found in the database.");
                    }
                }
            }
        }

        private void InsertPurchase(int studentId, int productId, int productCount)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO CanteenPurchase (studentId, canteenProductId, purchaseAmount, purchaseDate) " +
                    "VALUES (@StudentId, @ProductId, @ProductCount, @PurchaseDate)",
                    connection);

                cmd.Parameters.AddWithValue("@StudentId", studentId);
                cmd.Parameters.AddWithValue("@ProductId", productId);
                cmd.Parameters.AddWithValue("@ProductCount", productCount);
                cmd.Parameters.AddWithValue("@PurchaseDate", DateTime.Now);

                cmd.ExecuteNonQuery();
            }
        }
        
        private void calculateBtn_Click(object sender, EventArgs e)
        {
            decimal totalSum = 0;

            for (int i = 0; i < productNameBoxes.Count; i++)
            {
                string productName = productNameBoxes[i].SelectedItem.ToString();
                int productCount = int.Parse(productCountBoxes[i].SelectedItem.ToString());

                decimal productPrice = GetProductPrice(productName);

                decimal lineTotal = productCount * productPrice;
                totalSum += lineTotal;

                receiptRichTextBox.AppendText($"{productName}, Count: {productCount}, Line Total: {lineTotal}\n");
            }

            receiptRichTextBox.AppendText($"Total Sum: {totalSum}");
        }

        private decimal GetProductPrice(string productName)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    "SELECT CP.price " +
                    "FROM CanteenProduct CP " +
                    "WHERE CP.productName = @ProductName",
                    connection);

                cmd.Parameters.AddWithValue("@ProductName", productName);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return reader.GetDecimal(0);
                    }
                    else
                    {
                        throw new Exception($"Product {productName} not found in the database.");
                    }
                }
            }
        }
    }
}