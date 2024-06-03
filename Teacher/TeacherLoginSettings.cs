using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.StudentCRUD;
using schoolManagementSystem.Admin.StudentCRUD.Details;

namespace schoolManagementSystem.Teacher
{
    public partial class TeacherLoginSettings : Form
    {
        private string schoolName;
        private string teacherEmail;
        private DataGridView _dataGridView;
        private int selectedStudentCount = 0;
        private List<int> selectedStudentIds = new List<int>();
        public TeacherLoginSettings(string schoolName, string teacherEmail)
        {
            InitializeComponent();
            this.schoolName = schoolName;
            this.teacherEmail = teacherEmail;
        this._dataGridView = new DataGridView();
            this.Controls.Add(this._dataGridView);
            this.Load += StudentDetails_Load;
            this.StartPosition = FormStartPosition.Manual;
            
            this._dataGridView.Location = new Point(229, 221);
            this._dataGridView.Size = new Size(1223, 487);
            this._dataGridView.BackgroundColor = SystemColors.ControlLight;
            this._dataGridView.BorderStyle = BorderStyle.None;
            this.nameFilter.Height = 40;
            
            
            // Handle the CellContentClick event
            this._dataGridView.CellContentClick += _dataGridView_CellContentClick;
            this._dataGridView.RowPrePaint += _dataGridView_RowPrePaint;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.RowTemplate.Height = 40;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.AllowUserToAddRows = false;
            
            
            
            //PopulateClassFilterDropdown();
        }
        
        
        private void AddCheckBoxColumn()
        {
            if (this._dataGridView.Columns.Contains("checkBoxColumn")) return;
            DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.Name = "checkBoxColumn";
            checkBoxColumn.HeaderText = "Absence";
            this._dataGridView.Columns.Add(checkBoxColumn);
            MessageBox.Show(checkBoxColumn.Name);
            
        }
        
        /*private void _dataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && this._dataGridView.Columns.Contains("checkBoxColumn") && e.ColumnIndex == this._dataGridView.Columns["checkBoxColumn"].Index)
            {
                Cursor.Current = Cursors.Hand;
            }
            else
            {
                Cursor.Current = Cursors.Default;
            }
        }*/

        
        private void _dataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                this._dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
            }
            else
            {
                this._dataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(173, 216, 230);
            }
        }
        private void _dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this._dataGridView.Columns.Contains("checkBoxColumn") && e.ColumnIndex == this._dataGridView.Columns["checkBoxColumn"].Index)
            {
                DataGridViewRow row = this._dataGridView.Rows[e.RowIndex];
                int studentId = Convert.ToInt32(row.Cells["Id"].Value);
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)row.Cells["checkBoxColumn"];

                if ((bool)checkBoxCell.Value)
                {
                    if (!selectedStudentIds.Contains(studentId))
                    {
                        selectedStudentIds.Add(studentId);
                    }
                }
                else
                {
                    if (selectedStudentIds.Contains(studentId))
                    {
                        selectedStudentIds.Remove(studentId);
                    }
                }
            }
        }
        /*
        
        private void _dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && this._dataGridView.Columns.Contains("checkBoxColumn") && e.ColumnIndex == this._dataGridView.Columns["checkBoxColumn"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                TextRenderer.DrawText(e.Graphics, "Absence", e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                e.Handled = true;
            }
        }*/
        
        private void _dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this._dataGridView.Columns.Contains("checkBoxColumn") && e.ColumnIndex == this._dataGridView.Columns["checkBoxColumn"].Index)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)_dataGridView.Rows[e.RowIndex].Cells["checkBoxColumn"];
                if ((bool)checkBoxCell.Value)
                {
                    selectedStudentCount++;
                }
                else{
                    selectedStudentCount--;
                }

                selectedStudentCountBox.Text = $"{selectedStudentCount} Student(s) selected as Absence.";
            }
        }
        
        private void _dataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (this._dataGridView.IsCurrentCellDirty)
            {
                // Commit the changes immediately
                this._dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        
        
        private void StudentDetails_Load(object sender, EventArgs e)
        {
            LoadStudentData();
           // this._dataGridView.CellMouseMove += _dataGridView_CellMouseMove;
            //this._dataGridView.CellPainting += _dataGridView_CellPainting;
            this._dataGridView.CellValueChanged += _dataGridView_CellValueChanged;
            this._dataGridView.CurrentCellDirtyStateChanged += _dataGridView_CurrentCellDirtyStateChanged;

            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();

                // Get teacherId using teacherEmail
                string teacherIdQuery = "SELECT id, firstname, lastname FROM Teacher WHERE email = @teacherEmail";
                int teacherId; // Define teacherId here
                using (SqlCommand teacherIdCommand = new SqlCommand(teacherIdQuery, sqlConnection))
                {
                    teacherIdCommand.Parameters.AddWithValue("@teacherEmail", teacherEmail);
                    using (SqlDataReader reader = teacherIdCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            teacherId = reader.GetInt32(0); // Set teacherId here
                            string teacherName = reader["firstname"].ToString();
                            string teacherSurname = reader["lastname"].ToString();
                            teacherNameSurnameBox.Text = $"{teacherName} {teacherSurname}";
                        }
                    }
                }
                
            }
        }
        
        
        private void LoadStudentData()
        {
            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();

                // Get teacherId using teacherEmail
                string teacherIdQuery = "SELECT id FROM Teacher WHERE email = @teacherEmail";
                using (SqlCommand teacherIdCommand = new SqlCommand(teacherIdQuery, sqlConnection))
                {
                    teacherIdCommand.Parameters.AddWithValue("@teacherEmail", teacherEmail);
                    object result = teacherIdCommand.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("No teacher found with the provided email.");
                        return;
                    }
                    int teacherId = Convert.ToInt32(result);

                    // Get classname using teacherId
                    string classNameQuery = "SELECT classname FROM Class WHERE headTeacherId = @teacherId";
                    using (SqlCommand classNameCommand = new SqlCommand(classNameQuery, sqlConnection))
                    {
                        classNameCommand.Parameters.AddWithValue("@teacherId", teacherId);
                        object classNameResult = classNameCommand.ExecuteScalar();
                        if (classNameResult == null)
                        {
                            MessageBox.Show("No class found for the logged in teacher.");
                            return;
                        }
                        string className = classNameResult.ToString();
                        classNameTextBox.Text = className;

                        // Get students in the class
                        string query = @"
                        SELECT
                            s.id as Id,
                            s.firstname as Name,
                            s.lastname as Surname,
                            s.studentNumber as Number,
                            c.classname as Class,
                            s.gender as Gender,
                            YEAR(GETDATE()) - YEAR(s.birthDate) as Age,
                            s.hasOwnCard as Card,
                            p.firstname as 'Parent Name',
                            p.lastname as 'Parent Surname'
                        FROM
                            Student s
                            INNER JOIN Class c ON s.classId = c.id
                            INNER JOIN StudentParents sp ON s.id = sp.studentId
                            INNER JOIN Parent p ON sp.parentId = p.id
                        WHERE
                            c.classname = @className";

                        using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                        {
                            sqlCommand.Parameters.AddWithValue("@className", className);

                            using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                            {
                                DataTable dataTable = new DataTable();
                                sqlDataAdapter.Fill(dataTable);

                                _dataGridView.DataSource = dataTable;
                                AdjustColumnWidths();
                                AddCheckBoxColumn();
                            }
                        }
                    }
                }
            }
        }
                
        private void AdjustColumnWidths()
        {
            _dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _dataGridView.Columns["Name"].Width = 150;
            _dataGridView.Columns["Surname"].Width = 150;
            _dataGridView.Columns["Class"].Width = 50;
            _dataGridView.Columns["Number"].Width = 100;
            _dataGridView.Columns["Gender"].Width = 90;
            _dataGridView.Columns["Age"].Width = 50;
            _dataGridView.Columns["Card"].Width = 80;
            _dataGridView.Columns["Parent Name"].Width = 150;
            _dataGridView.Columns["Parent Surname"].Width = 150;
            _dataGridView.Columns["Id"].Width = 80;
            
            foreach (DataGridViewColumn column in _dataGridView.Columns)
            {
                if (column.Name != "checkBoxColumn") // Exclude the Absence checkbox column
                {
                    column.ReadOnly = true; // Make other columns read-only
                }
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            for (int i = 1; i <= 8; i++)
            {
                lessonHour.Items.Add(i);
            }
        }


        private int GetSchoolId()
        {
            int schoolId = 0;

            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();

                string schoolIdQuery = "SELECT id FROM School WHERE schoolName = @schoolName";
                using (SqlCommand schoolIdCommand = new SqlCommand(schoolIdQuery, sqlConnection))
                {
                    schoolIdCommand.Parameters.AddWithValue("@schoolName", schoolName);
                    object result = schoolIdCommand.ExecuteScalar();
                    if (result != null)
                    {
                        schoolId = Convert.ToInt32(result);
                    }
                }
            }

            return schoolId;
        }

        private void sendAbsencesButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();

                foreach (int studentId in selectedStudentIds)
                {
                    string query = "INSERT INTO Absence (studentId, absenceDate, absenceHours) VALUES (@studentId, @absenceDate, @absenceHours)";
                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@studentId", studentId);
                        sqlCommand.Parameters.AddWithValue("@absenceDate", DateTime.Now);
                        sqlCommand.Parameters.AddWithValue("@absenceHours", lessonHour.SelectedItem);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Absences have been recorded.");
        }
    }
}