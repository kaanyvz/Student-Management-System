using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.StudentCRUD.Add;
using schoolManagementSystem.Admin.StudentCRUD.Delete;
using schoolManagementSystem.Admin.StudentCRUD.Update;

namespace schoolManagementSystem.Admin.StudentCRUD.Details
{
    public partial class StudentInformationsDetails : Form
    {
        private string adminUsername;
        private string schoolName;
        private int studentId;
        private DataGridView _dataGridView;
        
        public StudentInformationsDetails(string adminUsername, string schoolName, int studentId)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            this.studentId = studentId;
            InitializeComponent();
            this._dataGridView = new DataGridView();
            this.Controls.Add(this._dataGridView);
            this.Load += StudentInformationsDetails_Load;
            this.StartPosition = FormStartPosition.Manual;
            this._dataGridView.Location = new Point(549, 454);
            this._dataGridView.Size = new Size(805, 226);
            this._dataGridView.AllowUserToResizeColumns = false;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.AllowUserToAddRows = false;
        }


        private void StudentInformationsDetails_Load(object sender, EventArgs e)
        {
            FetchStudentInformations();
            LoadAbsenceData(studentId);
        }

        private void FetchStudentInformations()
        {

            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                string studentQuery = "SELECT s.firstname, s.lastname, s.classId, s.studentNumber, s.gender, s.email, s.birthDate, s.TCNumber, s.hasOwnCard, c.classname " +
                                      "FROM Student s " +
                                      "INNER JOIN Class c ON s.classId = c.id " +
                                      "WHERE s.id = @studentId";
                using (SqlCommand command = new SqlCommand(studentQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        studentName.Text = reader["firstname"].ToString();
                        studentSurname.Text = reader["lastname"].ToString();
                        studentClass.Text = reader["classname"].ToString(); 
                        studentSchoolNumber.Text = reader["studentNumber"].ToString();
                        studentGender.Text = reader["gender"].ToString();
                        studentMail.Text = reader["email"].ToString();
                        studentBirthdate.Text = reader["birthDate"].ToString();
                        studentTC.Text = reader["TCNumber"].ToString();
                        bool hasOwnCard = (bool)reader["hasOwnCard"];
                        hasOwnCardBox.Text = hasOwnCard ? "YES" : "NO";
                        
                        if (!hasOwnCard)
                        {
                            balanceBox.Text = "** FIRST CREATE A CARD **";
                            cardNumberBox.Text = "** FIRST CREATE A CARD **";
                            isBlockedBox.Text = "** FIRST CREATE A CARD **";
                            entranceTimeBox.Text = "** FIRST CREATE A CARD **";
                            exitTimeBox.Text = "** FIRST CREATE A CARD **";
                        }
                        
                        nameSurnameRichBox.Text = $"          {studentName.Text} {studentSurname.Text}";
                        nameSurnameRichBox.Font = new Font("Times New Roman", 14, FontStyle.Bold);
                    }
                    reader.Close();
                }

                int studentCardId = 0;
                string cardQuery = "SELECT id AS studentCardId, balance, cardNumber, isBlocked FROM StudentCard WHERE studentId = @studentId";
                using (SqlCommand command = new SqlCommand(cardQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        studentCardId = (int)reader["studentCardId"];
                        balanceBox.Text = reader["balance"].ToString();
                        cardNumberBox.Text = reader["cardNumber"].ToString();
                        isBlockedBox.Text = (bool)reader["isBlocked"]? "YES" : "NO";
                    }
                    reader.Close();
                }

                string entranceQuery = "SELECT entranceTime, exitTime FROM EntranceTracking WHERE studentCardId = @studentCardId";
                using (SqlCommand command = new SqlCommand(entranceQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentCardId", studentCardId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        entranceTimeBox.Text = reader["entranceTime"].ToString();
                        exitTimeBox.Text = reader["exitTime"].ToString();
                    }
                    reader.Close();
                }

                string parentQuery = "SELECT p.firstname, p.lastname, p.email, p.phone, p.gender, p.birthDate, p.TCNumber FROM Parent p INNER JOIN StudentParents sp ON p.id = sp.parentId WHERE sp.studentId = @studentId";
                using (SqlCommand command = new SqlCommand(parentQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Populate text boxes with parent information
                        parentName1.Text = reader["firstname"].ToString();
                        parentSurname1.Text = reader["lastname"].ToString();
                        parentMail1.Text = reader["email"].ToString();
                        parentPhone1.Text = reader["phone"].ToString();
                        parentGender1.Text = reader["gender"].ToString();
                        parentBirthdate1.Text = reader["birthDate"].ToString();
                        parentTC1.Text = reader["TCNumber"].ToString();
                    }
                    reader.Close();
                }
            }
        }
        
        private void LoadAbsenceData(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                connection.Open();

                string query = "SELECT ROW_NUMBER() OVER(ORDER BY id) AS [Count], " +
                               "CONVERT(VARCHAR, absenceDate, 23) AS Date, " +
                               "CONVERT(VARCHAR, absenceDate, 108) AS Time, " +
                               "absenceHours as 'Absence Hour' " +
                               "FROM Absence WHERE studentId = @studentId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataTable.Columns.Add("Day", typeof(string));

                        foreach (DataRow row in dataTable.Rows)
                        {
                            DateTime date = Convert.ToDateTime(row["Date"]);
                            string dayOfWeek = date.DayOfWeek.ToString();
                            row["Day"] = dayOfWeek;
                        }

                        _dataGridView.DataSource = dataTable;
                        _dataGridView.BackgroundColor = SystemColors.ControlLight;
                        _dataGridView.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                        _dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        foreach (DataGridViewColumn column in _dataGridView.Columns)
                        {
                            column.MinimumWidth = 150;
                        }
                        _dataGridView.BorderStyle = BorderStyle.None;
                    }
                }

                string totalAbsenceQuery = "SELECT COUNT(*) as TotalAbsenceHours FROM Absence WHERE studentId = @studentId";

                using (SqlCommand command = new SqlCommand(totalAbsenceQuery, connection))
                {
                    command.Parameters.AddWithValue("@studentId", studentId);

                    var result = command.ExecuteScalar();
                    int totalAbsenceHours = result != DBNull.Value ? Convert.ToInt32(result) : 0;

                    int remainingHours = 240 - totalAbsenceHours;

                    totalAbsences.Text = $"{totalAbsenceHours} Hours absences has done by student.";
                    remainingAbsences.Text = $"{remainingHours} Hours absences has left for student.";
                    totalAbsences.Font = new Font("Times New Roman",11, FontStyle.Bold);
                    remainingAbsences.Font = new Font("Times New Roman",11, FontStyle.Bold);
                }
            }
        }
                

        private void backIcon_Click(object sender, EventArgs e)
        {
            StudentDetails studentDetails = new StudentDetails(adminUsername, schoolName);
            studentDetails.StartPosition = FormStartPosition.Manual;
            studentDetails.Location = this.Location;
            this.Hide();
            studentDetails.ShowDialog();
        }

        private void deleteStudentButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void deleteStudentButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
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

        private void updateStudentButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void updateStudentButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void updateStudentButton_MouseClick(object sender, MouseEventArgs e)
        {
            UpdateStudent updateStudent = new UpdateStudent(adminUsername, schoolName);
            updateStudent.StartPosition = FormStartPosition.Manual;
            updateStudent.Location = this.Location;
            this.Hide();
            updateStudent.ShowDialog();
            this.Close();
        }

        private void addStudentButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void addStudentButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
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
    }
}