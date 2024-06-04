using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.StudentCRUD.Add;
using schoolManagementSystem.Admin.StudentCRUD.Delete;
using schoolManagementSystem.Admin.StudentCRUD.Update;

namespace schoolManagementSystem.Admin.StudentCRUD.Details
{
    public partial class StudentDetails : Form
    {
        private string adminUsername;
        private string schoolName;
        private DataGridView _dataGridView;
        
        public StudentDetails(string adminUsername, string schoolName)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            InitializeComponent();
            
            this._dataGridView = new DataGridView();
            this.Controls.Add(this._dataGridView);
            this.Load += StudentDetails_Load;
            this.StartPosition = FormStartPosition.Manual;
            
            this._dataGridView.Location = new Point(227, 150);
            this._dataGridView.Size = new Size(1200, 450);
            this._dataGridView.BackgroundColor = SystemColors.ControlLight;
            this._dataGridView.BorderStyle = BorderStyle.None;
            this.nameFilter.Height = 40;
            
            
            this._dataGridView.CellContentClick += _dataGridView_CellContentClick;
            this._dataGridView.RowPrePaint += _dataGridView_RowPrePaint;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowTemplate.Height = 40;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.AllowUserToAddRows = false;

            
            PopulateClassFilterDropdown();
        }
        
        
         private void AddDetailsButtonColumn()
        {
            if (this._dataGridView.Columns.Contains("detailsButtonColumn")) return;
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "detailsButtonColumn";
            buttonColumn.Text = "Details";
            buttonColumn.HeaderText = "Details";
            buttonColumn.UseColumnTextForButtonValue = false;
            this._dataGridView.Columns.Add(buttonColumn);
        }
        
        private void _dataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == this._dataGridView.Columns["detailsButtonColumn"].Index && e.RowIndex >= 0)
            {
                Cursor.Current = Cursors.Hand;
            }
            else
            {
                Cursor.Current = Cursors.Default;
            }
        }

        
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
            if (e.ColumnIndex == this._dataGridView.Columns["detailsButtonColumn"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = this._dataGridView.Rows[e.RowIndex];
                int studentId = Convert.ToInt32(row.Cells["Id"].Value);
                StudentInformationsDetails studentInformationsDetails = new StudentInformationsDetails(adminUsername, schoolName, studentId);
                studentInformationsDetails.StartPosition = FormStartPosition.Manual;
                studentInformationsDetails.Location = this.Location;
                this.Hide();
                studentInformationsDetails.ShowDialog();
                this.Close();
                
                
            }
        }
        
        private void _dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == this._dataGridView.Columns["detailsButtonColumn"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                TextRenderer.DrawText(e.Graphics, "Details", e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                e.Handled = true;
            }
        }

        
        
        private void StudentDetails_Load(object sender, EventArgs e)
        {
            LoadStudentData();
            this._dataGridView.CellMouseMove += _dataGridView_CellMouseMove;
            this._dataGridView.CellPainting += _dataGridView_CellPainting;
        }

        private void LoadStudentData()
        {
            
            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                
                sqlConnection.Open();

                string schoolIdQuery = "SELECT id FROM School WHERE schoolName = @schoolName";
                using (SqlCommand schoolIdCommand = new SqlCommand(schoolIdQuery, sqlConnection))
                {
                    schoolIdCommand.Parameters.AddWithValue("@schoolName", schoolName);
                    object result = schoolIdCommand.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("No school found with the provided name.");
                        return;
                    }
                    int schoolId = Convert.ToInt32(result);

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
                    c.schoolId = @schoolId";

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@schoolId", schoolId);

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            DataTable dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);
                            

                            _dataGridView.DataSource = dataTable;
                            AdjustColumnWidths();
                            AddDetailsButtonColumn();
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
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void backIcon_Click(object sender, EventArgs e)
        {
            StudentSettings studentSettings = new StudentSettings(adminUsername, schoolName);
            studentSettings.StartPosition = FormStartPosition.Manual;
            studentSettings.Location = this.Location;
            this.Hide();
            studentSettings.ShowDialog();
            this.Close(); 
        }
        
        private void FilterStudents()
        {
            // Construct the base query
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
                    c.schoolId = @schoolId";
        
            // Initialize parameters
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@schoolId", SqlDbType.Int) { Value = GetSchoolId() });
        
            // Add filters if they are filled
            if (!string.IsNullOrEmpty(nameFilter.Text))
            {
                query += " AND s.firstname LIKE @firstName";
                parameters.Add(new SqlParameter("@firstName", SqlDbType.NVarChar) { Value = "%" + nameFilter.Text + "%" });
            }
        
            if (!string.IsNullOrEmpty(surnameFilter.Text))
            {
                query += " AND s.lastname LIKE @lastName";
                parameters.Add(new SqlParameter("@lastName", SqlDbType.NVarChar) { Value = "%" + surnameFilter.Text + "%" });
            }
        
            if (!string.IsNullOrEmpty(numberFilter.Text))
            {
                query += " AND s.studentNumber LIKE @studentNumber";
                parameters.Add(new SqlParameter("@studentNumber", SqlDbType.NVarChar) { Value = "%" + numberFilter.Text + "%" });
            }
        
            if (classFilter.SelectedItem != null)
            {
                query += " AND c.classname = @className";
                parameters.Add(new SqlParameter("@className", SqlDbType.NVarChar) { Value = classFilter.SelectedItem.ToString() });
            }
        
            // Execute the query
            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();
        
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddRange(parameters.ToArray());
        
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
        
                        _dataGridView.DataSource = dataTable;
                        AdjustColumnWidths();
                    }
                }
            }
        }

        private void PopulateClassFilterDropdown()
        {
            classFilter.Items.Clear();

            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();

                string query = "SELECT DISTINCT classname FROM Class";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string className = reader["classname"].ToString();
                            classFilter.Items.Add(className);
                        }
                    }
                }
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


        private void nameFilter_TextChanged(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void surnameFilter_TextChanged(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void numberFilter_TextChanged(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void classFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void clearFiltersBtn_Click(object sender, EventArgs e)
        {
          
            // Clear filter textboxes
            nameFilter.Text = "";
            surnameFilter.Text = "";
            numberFilter.Text = "";

            // Reset class filter dropdown
            classFilter.SelectedIndex = -1;

            // Perform filtering with reset filters
            FilterStudents();
        }

        private void backIcon_Click_1(object sender, EventArgs e)
        {
            StudentSettings studentSettings = new StudentSettings(adminUsername, schoolName);
            studentSettings.StartPosition = FormStartPosition.Manual;
            studentSettings.Location = this.Location;
            this.Hide();
            studentSettings.ShowDialog();
            this.Close();
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

        private void updateStudentButton_Click(object sender, EventArgs e)
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

        private void adminDashboardTurnOffButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}