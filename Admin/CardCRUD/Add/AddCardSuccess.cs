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
       
    }
}