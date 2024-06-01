using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using schoolManagementSystem.Model;

namespace schoolManagementSystem.Admin.StudentCRUD.Add
{
    public partial class AddParentalInformations : Form
    {
        // Student Informations
        private Student _student;
        private string _adminUsername;
        private string _schoolName;
        
        private int _studentIdFromDatabase;
        private int _parentIdFromDatabase;

        
        
        private int parentId;
      
        
        public AddParentalInformations(string _adminUsername, string _schoolName, Student student)
        {
            this._adminUsername = _adminUsername;
            this._schoolName = _schoolName;
            InitializeComponent();


            _student = student;
            this.parentGender1.FormattingEnabled = true;
            this.parentGender1.Items.AddRange(new object[] {
                "Male",
                "Female" 
            });
            
            this.parentTC1.KeyPress += new KeyPressEventHandler(parentTC1_KeyPress);
        
        }

        private void addParentalInformationsBtn_Click(object sender, EventArgs e)
        {
            string password = System.IO.Path.GetRandomFileName().Replace(".", "").Substring(0, 8); 
            string parentName1Text = parentName1.Text;
            string parentSurname1Text = parentSurname1.Text;
            string parentMail1Text = parentMail1.Text;
            string parentPhone1Text = parentPhone1.Text;
            string parentGender1Text = parentGender1?.SelectedItem?.ToString();
            string parentTCNumber1Text = parentTC1.Text;
            DateTime birthdate1Text = parentBirthdate1.Value;
            
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                _studentIdFromDatabase = InsertStudentIntoDatabase(_student);
            }

            Parent parent = new Parent
            {
                Firstname = parentName1Text,
                Lastname = parentSurname1Text,
                Email = parentMail1Text,
                PhoneNumber = parentPhone1Text,
                BirthDate = birthdate1Text,
                TCNumber = parentTCNumber1Text,
                Password = password,
                Gender = parentGender1Text
            };

            _parentIdFromDatabase = InsertParentalInformationsIntoDatabase(parent);
            
            if( _parentIdFromDatabase > 0 && _studentIdFromDatabase > 0)
            {
                
                using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO StudentParents (StudentId, ParentId) VALUES (@StudentId, @ParentId)",
                        connection);
                    cmd.Parameters.AddWithValue("@StudentId", _studentIdFromDatabase);
                    cmd.Parameters.AddWithValue("@ParentId", _parentIdFromDatabase);
                    cmd.ExecuteNonQuery();
                }
                AddStudentSuccess addStudentSuccess = new AddStudentSuccess(_studentIdFromDatabase, _parentIdFromDatabase, _adminUsername, _schoolName);
                addStudentSuccess.StartPosition = FormStartPosition.Manual;
                addStudentSuccess.Location = this.Location;
                this.Hide();
                addStudentSuccess.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("An error occurred while adding the student and parent to the system.");
            }
        }
        
        private int InsertStudentIntoDatabase(Student student)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Student (classId, firstname, studentNumber, lastname, gender, email, birthDate, TCNumber, hasOwnCard) " +
                    "VALUES ((SELECT id FROM Class WHERE className = @ClassName), @Firstname, @StudentNumber, @Lastname, @Gender, @Email, @BirthDate, @TCNumber, 0);" +
                    "SELECT SCOPE_IDENTITY();", // Retrieve the inserted student ID
                    connection);
                cmd.Parameters.AddWithValue("@ClassName", student.ClassName);
                cmd.Parameters.AddWithValue("@Firstname", student.Firstname);
                cmd.Parameters.AddWithValue("@StudentNumber", student.StudentNumber);
                cmd.Parameters.AddWithValue("@Lastname", student.Lastname);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@BirthDate", student.BirthDate);
                cmd.Parameters.AddWithValue("@TCNumber", student.TCNumber); // Add TCNumber parameter
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private int InsertParentalInformationsIntoDatabase(Parent parent)
        {
            
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Parent (firstname, lastname, email, phone, birthDate, TCNumber, password, gender) " +
                    "VALUES (@Firstname, @Lastname, @Email, @Phone, @BirthDate, @TCNumber, @Password, @Gender);" +
                    "SELECT SCOPE_IDENTITY();", // Retrieve the inserted parent ID
                    connection);
                cmd.Parameters.AddWithValue("@Firstname", parent.Firstname);
                cmd.Parameters.AddWithValue("@Lastname", parent.Lastname);
                cmd.Parameters.AddWithValue("@Email", parent.Email);
                cmd.Parameters.AddWithValue("@Phone", parent.PhoneNumber);
                cmd.Parameters.AddWithValue("@BirthDate", parent.BirthDate);
                cmd.Parameters.AddWithValue("@TCNumber", parent.TCNumber);
                cmd.Parameters.AddWithValue("@Password", parent.Password);
                cmd.Parameters.AddWithValue("@Gender", parent.Gender);
                parentId = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return parentId;
        }
        

        private void backIcon_Click(object sender, EventArgs e)
        {
            AddNewStudent addNewStudent = new AddNewStudent(_adminUsername, _schoolName);
            addNewStudent.StartPosition = FormStartPosition.Manual;
            addNewStudent.Location = this.Location;
            this.Hide();
            addNewStudent.ShowDialog();
            this.Close();
        }

        private void parentTC1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}