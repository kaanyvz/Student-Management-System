using System;
using System.Data.SqlClient;
using System.Windows.Forms;
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
        }

        private void UpdateStudentParentInfos_Load(object sender, EventArgs e)
        {
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
                // Update the student information
                string updateStudentQuery =
                    "UPDATE Student SET firstname = @firstname, lastname = @lastname, gender = @gender, email = @email, studentNumber = @studentNumber, TCNumber = @TCNumber, birthDate = @birthDate WHERE id = @studentId";
                using (SqlCommand updateStudentCommand = new SqlCommand(updateStudentQuery, connection))
                {
                    updateStudentCommand.Parameters.AddWithValue("@firstname", student.Firstname);
                    updateStudentCommand.Parameters.AddWithValue("@lastname", student.Lastname);
                    updateStudentCommand.Parameters.AddWithValue("@gender", student.Gender);
                    updateStudentCommand.Parameters.AddWithValue("@email", student.Email);
                    updateStudentCommand.Parameters.AddWithValue("@studentNumber", student.StudentNumber);
                    updateStudentCommand.Parameters.AddWithValue("@TCNumber", student.TCNumber);
                    updateStudentCommand.Parameters.AddWithValue("@birthDate", student.BirthDate);
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
    }
}