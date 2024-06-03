using System.Windows.Forms;

namespace schoolManagementSystem.Admin.TeacherCRUD.Details
{
    public partial class TeacherDetailsPage : Form
    {
        private string adminUsername;
        private string schoolName;
        private int teacherId;
        public TeacherDetailsPage(string adminUsername, string schoolName, int teacherId)
        {
            InitializeComponent();
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            this.teacherId = teacherId;
            
            
        }
    }
}