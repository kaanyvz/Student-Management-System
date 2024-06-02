using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.TeacherCRUD.Add;
using schoolManagementSystem.Admin.TeacherCRUD.Delete;

namespace schoolManagementSystem.Admin.TeacherCRUD.Update
{
    public partial class UpdateTeacherVariables : Form
    {
        private string adminUsername;
        private string schoolName;
        private int teacherId;
        public UpdateTeacherVariables(string adminUsername, string schoolName, int teacherId)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            this.teacherId = teacherId;
            InitializeComponent();
        }

        private void UpdateTeacherVariables_Load(object sender, EventArgs e)
        {
            // Fetch teacher information
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT firstname, lastname, TCNumber, phone, email, major, birthDate FROM Teacher WHERE id = @TeacherId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        teacherName.Text = reader["firstname"].ToString();
                        teacherSurname.Text = reader["lastname"].ToString();
                        teacherTC.Text = reader["TCNumber"].ToString();
                        teacherPhone.Text = reader["phone"].ToString();
                        teacherMail.Text = reader["email"].ToString();
                        teacherMajor.Text = reader["major"].ToString();
                        teacherBirthdate.Value = Convert.ToDateTime(reader["birthDate"]);
                    }
                    reader.Close();

                    // Fetch subject names and populate teacherMajorComboBox
                    query = "SELECT subjectName FROM Subject";
                    command = new SqlCommand(query, connection);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        teacherMajor.Items.Add(reader["subjectName"].ToString());
                    }
                    reader.Close();

                    // Fetch class names belonging to the schoolId and populate teacherClass ComboBox
                    query = "SELECT classname FROM Class WHERE schoolId = (SELECT id FROM School WHERE schoolName = @SchoolName)";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@SchoolName", schoolName);
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        teacherClass.Items.Add(reader["classname"].ToString());
                    }
                    reader.Close();

                    // Set the default selected item to the teacher's current head class
                    query = "SELECT classname FROM Class WHERE headTeacherId = @TeacherId";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    object headClassName = command.ExecuteScalar();
                    if (headClassName != null)
                    {
                        teacherClass.SelectedItem = headClassName.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void upateTeacherBtn_Click(object sender, EventArgs e)
        {
            string newSelectedClassname = teacherClass.SelectedItem.ToString();

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                // Fetch the current class of the teacher being updated
                string query = "SELECT classname FROM Class WHERE headTeacherId = @TeacherId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TeacherId", teacherId);
                object previousClassname = command.ExecuteScalar();

                // Check if the selected class already has a head teacher
                query = "SELECT headTeacherId FROM Class WHERE classname = @Classname";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Classname", newSelectedClassname);
                object currentHeadTeacherId = command.ExecuteScalar();

                if (currentHeadTeacherId != DBNull.Value && (int)currentHeadTeacherId != teacherId)
                {
                    // Fetch the current head teacher's details
                    query = "SELECT firstname, lastname FROM Teacher WHERE id = @TeacherId";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TeacherId", currentHeadTeacherId);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string currentHeadTeacherName = reader["firstname"].ToString();
                        string currentHeadTeacherSurname = reader["lastname"].ToString();

                        // Display a warning message to the admin
                        string message = $"Are you sure want to update head teacher. {currentHeadTeacherName} {currentHeadTeacherSurname} is the head teacher of {newSelectedClassname}. If you want to continue, then {currentHeadTeacherName} {currentHeadTeacherSurname} will be the new head teacher of {previousClassname}.";
                        DialogResult dialogResult = MessageBox.Show(message, "Confirm Update", MessageBoxButtons.YesNo);

                        if (dialogResult == DialogResult.No)
                        {
                            // If the admin chooses not to proceed, do not make any changes
                            return;
                        }
                    }

                    reader.Close();
                }

                // If the selected class does not have a head teacher or the admin chooses to proceed, update the teacher's details and set the new head teacher for the class
                query = "UPDATE Teacher SET firstname = @Firstname, lastname = @Lastname, TCNumber = @TCNumber, phone = @Phone, email = @Email, major = @Major, birthDate = @BirthDate WHERE id = @TeacherId";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Firstname", teacherName.Text);
                command.Parameters.AddWithValue("@Lastname", teacherSurname.Text);
                command.Parameters.AddWithValue("@TCNumber", teacherTC.Text);
                command.Parameters.AddWithValue("@Phone", teacherPhone.Text);
                command.Parameters.AddWithValue("@Email", teacherMail.Text);
                command.Parameters.AddWithValue("@Major", teacherMajor.Text);
                command.Parameters.AddWithValue("@BirthDate", teacherBirthdate.Value);
                command.Parameters.AddWithValue("@TeacherId", teacherId);
                command.ExecuteNonQuery();

                // Update the head teacher of the selected class
                query = "UPDATE Class SET headTeacherId = @TeacherId WHERE classname = @Classname";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TeacherId", teacherId);
                command.Parameters.AddWithValue("@Classname", newSelectedClassname);
                command.ExecuteNonQuery();

                // If the teacher was previously a head teacher, set the head teacher of the previous class to null
                if (previousClassname != null)
                {
                    query = "UPDATE Class SET headTeacherId = NULL WHERE classname = @PreviousClassname";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@PreviousClassname", previousClassname);
                    command.ExecuteNonQuery();
                }

                // Swap the head teacher of the class that the updated teacher was previously responsible for, only if there was a head teacher before
                if (currentHeadTeacherId != DBNull.Value)
                {
                    query = "UPDATE Class SET headTeacherId = @CurrentHeadTeacherId WHERE classname = @PreviousClassname";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CurrentHeadTeacherId", currentHeadTeacherId);
                    command.Parameters.AddWithValue("@PreviousClassname", previousClassname);
                    command.ExecuteNonQuery();
                }
                UpdateTeacherSuccess updateTeacherSuccess = new UpdateTeacherSuccess(adminUsername, schoolName);
                updateTeacherSuccess.StartPosition = FormStartPosition.Manual;
                updateTeacherSuccess.Location = this.Location;
                this.Hide();
                updateTeacherSuccess.ShowDialog();
                this.Close();
                
            }
        }

        private void backIcon_Click(object sender, EventArgs e)
        {
            UpdateTeacher updateTeacher = new UpdateTeacher(adminUsername, schoolName);
            updateTeacher.StartPosition = FormStartPosition.Manual;
            updateTeacher.Location = this.Location;
            this.Hide();
            updateTeacher.ShowDialog();
            this.Close();
            
        }

        private void addNewTeacherBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void addNewTeacherBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void addNewTeacherBtn_Click(object sender, EventArgs e)
        {
            AddNewTeacher addNewTeacher = new AddNewTeacher(adminUsername, schoolName);
            addNewTeacher.StartPosition = FormStartPosition.Manual;
            addNewTeacher.Location = this.Location;
            this.Hide();
            addNewTeacher.ShowDialog();
            this.Close();
        }

        private void deleteTeacherBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void deleteTeacherBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void deleteTeacherBtn_Click(object sender, EventArgs e)
        {
            DeleteTeacher deleteTeacher = new DeleteTeacher(adminUsername, schoolName);
            deleteTeacher.StartPosition = FormStartPosition.Manual;
            deleteTeacher.Location = this.Location;
            this.Hide();
            deleteTeacher.ShowDialog();
            this.Close();
        }

        private void teacherDetailsBtn_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }


        private void teacherDetailsBtn_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void teacherDetailsBtn_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}