using System;
using System.Windows.Forms;
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
    }
}