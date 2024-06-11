using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using schoolManagementSystem.Admin.StudentCRUD.Add;
using schoolManagementSystem.Admin.StudentCRUD.Delete;
using schoolManagementSystem.Admin.StudentCRUD.Details;
using schoolManagementSystem.Model;

namespace schoolManagementSystem.Admin.StudentCRUD.Update
{
    public partial class UpdateStudentParentInfos : Form
    {
        private int studentId;
        private string adminUsername;
        private string schoolName;
        private Student student;

        public UpdateStudentParentInfos(int studentId, string adminUsername, string schoolName, Student student)
        {
            InitializeComponent();
            this.studentId = studentId;
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            this.student = student;
            
            this.parentGender1.FormattingEnabled = true;
            this.parentGender1.Items.AddRange(new object[] {
                "Male", 
                "Female" 
            });
            this.parentTC1.KeyPress += new KeyPressEventHandler(parentTC_KeyPress_1);
            this.parentPhone1.KeyPress += new KeyPressEventHandler(parentTC_KeyPress_1);
        }
        
        private void parentTC_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void UpdateStudentParentInfos_Load(object sender, EventArgs e)
        {
            MessageBox.Show(student.ClassName);
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                // Fetch the parent id from the StudentParents table
                string parentIdQuery = "SELECT parentId FROM StudentParents WHERE studentId = @studentId";
                using (SqlCommand parentIdCommand = new SqlCommand(parentIdQuery, connection))
                {
                    parentIdCommand.Parameters.AddWithValue("@studentId", studentId);
                    object parentIdResult = parentIdCommand.ExecuteScalar();

                    if (parentIdResult != null)
                    {
                        int parentId = Convert.ToInt32(parentIdResult);

                        // Fetch the parent information from the Parent table
                        string parentInfoQuery =
                            "SELECT firstname, lastname, email, phone, birthDate, TCNumber, gender FROM Parent WHERE id = @parentId";
                        using (SqlCommand parentInfoCommand = new SqlCommand(parentInfoQuery, connection))
                        {
                            parentInfoCommand.Parameters.AddWithValue("@parentId", parentId);
                            SqlDataReader parentInfoReader = parentInfoCommand.ExecuteReader();

                            if (parentInfoReader.Read())
                            {
                                // Assign the fetched parent information to the respective text boxes
                                parentName1.Text = parentInfoReader["firstname"].ToString();
                                parentSurname1.Text = parentInfoReader["lastname"].ToString();
                                parentPhone1.Text = parentInfoReader["phone"].ToString();
                                parentGender1.Text = parentInfoReader["gender"].ToString();
                                parentTC1.Text = parentInfoReader["TCNumber"].ToString();
                                parentBirthdate1.Value = Convert.ToDateTime(parentInfoReader["birthDate"]);
                                parentMail1.Text = parentInfoReader["email"].ToString();
                            }

                            parentInfoReader.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No parent found for the selected student.");
                    }
                }
            }
        }

        private void backIcon1_Click(object sender, EventArgs e)
        {
            UpdateStudentVariables updateStudentVariables =
                new UpdateStudentVariables(studentId, adminUsername, schoolName);

            updateStudentVariables.StartPosition = FormStartPosition.Manual;
            updateStudentVariables.Location = this.Location;
            this.Hide();
            updateStudentVariables.ShowDialog();
            this.Close();
        }

        private void updateStudentBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();
                
                
                // Fetch the classId from the Class table using the className and schoolId
                SqlCommand classCmd = new SqlCommand("SELECT id FROM Class WHERE className = @ClassName AND schoolId = (SELECT id FROM School WHERE SchoolName = @SchoolName)", connection);
                classCmd.Parameters.AddWithValue("@ClassName", student.ClassName.Split(' ')[0]); // Get the className part from the format '9D - 32'
                classCmd.Parameters.AddWithValue("@SchoolName", schoolName);
                int classId = (int)classCmd.ExecuteScalar();
                
                UpdateClassCapacity(studentId, schoolName);

                
                // Update the student information
                string updateStudentQuery =
                    "UPDATE Student SET firstname = @firstname, lastname = @lastname, gender = @gender, email = @email, studentNumber = @studentNumber, TCNumber = @TCNumber, birthDate = @birthDate, classId = @classId WHERE id = @studentId";
                using (SqlCommand updateStudentCommand = new SqlCommand(updateStudentQuery, connection))
                {
                    updateStudentCommand.Parameters.AddWithValue("@firstname", student.Firstname);
                    updateStudentCommand.Parameters.AddWithValue("@lastname", student.Lastname);
                    updateStudentCommand.Parameters.AddWithValue("@gender", student.Gender);
                    updateStudentCommand.Parameters.AddWithValue("@email", student.Email);
                    updateStudentCommand.Parameters.AddWithValue("@studentNumber", student.StudentNumber);
                    updateStudentCommand.Parameters.AddWithValue("@TCNumber", student.TCNumber);
                    updateStudentCommand.Parameters.AddWithValue("@birthDate", student.BirthDate);
                    updateStudentCommand.Parameters.AddWithValue("@classId", classId); // Update the classId
                    updateStudentCommand.Parameters.AddWithValue("@studentId", studentId);

                    int rowsAffected = updateStudentCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Update the parent information
                        string updateParentQuery =
                            "UPDATE Parent SET firstname = @firstname, lastname = @lastname, email = @email, phone = @phone, birthDate = @birthDate, TCNumber = @TCNumber, gender = @gender WHERE id = (SELECT parentId FROM StudentParents WHERE studentId = @studentId)";
                        using (SqlCommand updateParentCommand = new SqlCommand(updateParentQuery, connection))
                        {
                            updateParentCommand.Parameters.AddWithValue("@firstname", parentName1.Text);
                            updateParentCommand.Parameters.AddWithValue("@lastname", parentSurname1.Text);
                            updateParentCommand.Parameters.AddWithValue("@email", parentMail1.Text);
                            updateParentCommand.Parameters.AddWithValue("@phone", parentPhone1.Text);
                            updateParentCommand.Parameters.AddWithValue("@birthDate", parentBirthdate1.Value);
                            updateParentCommand.Parameters.AddWithValue("@TCNumber", parentTC1.Text);
                            updateParentCommand.Parameters.AddWithValue("@gender", parentGender1.Text);
                            updateParentCommand.Parameters.AddWithValue("@studentId", studentId);

                            rowsAffected = updateParentCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {

                                // Redirect to UpdateSuccess.cs
                                UpdateStudentSuccess updateSuccess = new UpdateStudentSuccess(adminUsername, schoolName);
                                updateSuccess.StartPosition = FormStartPosition.Manual;
                                updateSuccess.Location = this.Location;
                                this.Hide();
                                updateSuccess.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Failed to update parent information.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to update student information.");
                    }
                }
            }
        }
        
        private void UpdateClassCapacity(int studentId, string schoolName)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                // Fetch the old classId from the Student table
                SqlCommand oldClassCmd = new SqlCommand("SELECT classId FROM Student WHERE id = @StudentId", connection);
                oldClassCmd.Parameters.AddWithValue("@StudentId", studentId);
                int oldClassId = (int)oldClassCmd.ExecuteScalar();

                // Fetch the new classId from the Class table
                SqlCommand newClassCmd = new SqlCommand("SELECT id FROM Class WHERE className = @ClassName AND schoolId = (SELECT id FROM School WHERE SchoolName = @SchoolName)", connection);
                newClassCmd.Parameters.AddWithValue("@ClassName", student.ClassName.Split(' ')[0]); // Get the className part from the format '9D - 32'
                newClassCmd.Parameters.AddWithValue("@SchoolName", schoolName);
                int newClassId = (int)newClassCmd.ExecuteScalar();

                // Decrease the capacity of the new class
                SqlCommand decreaseCmd = new SqlCommand("UPDATE Class SET capacity = capacity - 1 WHERE id = @ClassId", connection);
                decreaseCmd.Parameters.AddWithValue("@ClassId", newClassId);
                decreaseCmd.ExecuteNonQuery();

                // Increase the capacity of the previous class
                SqlCommand increaseCmd = new SqlCommand("UPDATE Class SET capacity = capacity + 1 WHERE id = @ClassId", connection);
                increaseCmd.Parameters.AddWithValue("@ClassId", oldClassId);
                increaseCmd.ExecuteNonQuery();
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

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            AddNewStudent addNewStudent = new AddNewStudent(adminUsername, schoolName);
            addNewStudent.StartPosition = FormStartPosition.Manual;
            addNewStudent.Location = this.Location;
            this.Hide();
            addNewStudent.ShowDialog();
            this.Close();
        }

        private void deleteStudentButton_Click(object sender, EventArgs e)
        {
            DeleteStudent deleteStudent = new DeleteStudent(adminUsername, schoolName);
            deleteStudent.StartPosition = FormStartPosition.Manual;
            deleteStudent.Location = this.Location;
            
            this.Hide();
            deleteStudent.ShowDialog();
            this.Close();
        }

        private void studentDetailsBtn_Click(object sender, EventArgs e)
        {
            StudentDetails studentDetails = new StudentDetails(adminUsername, schoolName);
            studentDetails.StartPosition = FormStartPosition.Manual;
            studentDetails.Location = this.Location;
            this.Hide();
            studentDetails.ShowDialog();
            this.Close();
        }
    }
}