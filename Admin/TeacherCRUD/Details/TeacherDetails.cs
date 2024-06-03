using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.StudentCRUD;
using schoolManagementSystem.Admin.TeacherCRUD.Add;
using schoolManagementSystem.Admin.TeacherCRUD.Delete;

namespace schoolManagementSystem.Admin.TeacherCRUD.Details
{
    public partial class TeacherDetails : Form
    {
        private string adminUsername;
        private string schoolName;
        private DataGridView _dataGridView;
        
        public TeacherDetails(string adminUsername, string schoolName)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            InitializeComponent();
            this._dataGridView = new DataGridView();
            this.Controls.Add(this._dataGridView);
            this.Load += TeacherDetails_Load;
            this.StartPosition = FormStartPosition.Manual;
            
            this._dataGridView.Location = new Point(227, 150);
            this._dataGridView.Size = new Size(1200, 450);
            this._dataGridView.BackgroundColor = SystemColors.ControlLight;
            this._dataGridView.BorderStyle = BorderStyle.None;
            
            
            // Handle the CellContentClick event
            this._dataGridView.CellContentClick += _dataGridView_CellContentClick;
            this._dataGridView.RowPrePaint += _dataGridView_RowPrePaint;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowTemplate.Height = 40;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.AllowUserToAddRows = false;
            
            
            PopulateClassFilterDropdown();
            PopulateMajorFilterDropdown();

        }
        
        
        private void AddDetailsButtonColumn()
        {
            
            // Add a button column to the DataGridView
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
                int teacherId = Convert.ToInt32(row.Cells["Id"].Value);

               
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

        
        private void TeacherDetails_Load(object sender, EventArgs e)
        {
            LoadTeacherData();
            this._dataGridView.CellMouseMove += _dataGridView_CellMouseMove;
            this._dataGridView.CellPainting += _dataGridView_CellPainting;
            
        }

        private void LoadTeacherData()
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
                            t.id as Id,
                            t.firstname as Name,
                            t.lastname as Surname,
                            t.email as Email,
                            t.major as Major,
                            YEAR(GETDATE()) - YEAR(t.birthDate) as Age,
                            COALESCE(c.classname, '----') as ClassName,
                            s.schoolName as School
                        FROM
                            Teacher t
                            LEFT JOIN Class c ON t.id = c.headTeacherId
                            INNER JOIN School s ON t.schoolId = s.id
                        WHERE
                            t.schoolId = 1
                        ORDER BY t.id";

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
            _dataGridView.Columns["Name"].Width = 120;
            _dataGridView.Columns["Surname"].Width = 120;
            _dataGridView.Columns["ClassName"].Width = 100;
            _dataGridView.Columns["Email"].Width = 200;
            _dataGridView.Columns["Major"].Width = 150;
            _dataGridView.Columns["Age"].Width = 70;
            _dataGridView.Columns["School"].Width = 200;
            _dataGridView.Columns["Id"].Width = 60;
            
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
        
        private void PopulateMajorFilterDropdown()
        {
            majorFilter.Items.Clear();

            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();

                string query = "SELECT DISTINCT subjectName FROM Subject";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string subjectName = reader["subjectName"].ToString();
                            majorFilter.Items.Add(subjectName);
                        }
                    }
                }
            }
        }
        
        private void FilterTeachers()
        {
            // Construct the base query
            string query = @"
                SELECT
                    t.id as Id,
                    t.firstname as Name,
                    t.lastname as Surname,
                    t.email as Email,
                    t.major as Major,
                    YEAR(GETDATE()) - YEAR(t.birthDate) as Age,
                    COALESCE(c.classname, '----') as ClassName,
                    s.schoolName as School
                FROM
                    Teacher t
                    LEFT JOIN Class c ON t.id = c.headTeacherId
                    INNER JOIN School s ON t.schoolId = s.id
                WHERE
                    t.schoolId = @schoolId";

            // Initialize parameters
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@schoolId", SqlDbType.Int) { Value = GetSchoolId() });

            // Add filters if they are filled
            if (!string.IsNullOrEmpty(nameFilter.Text))
            {
                query += " AND t.firstname LIKE @firstName";
                parameters.Add(new SqlParameter("@firstName", SqlDbType.NVarChar) { Value = "%" + nameFilter.Text + "%" });
            }

            if (!string.IsNullOrEmpty(surnameFilter.Text))
            {
                query += " AND t.lastname LIKE @lastName";
                parameters.Add(new SqlParameter("@lastName", SqlDbType.NVarChar) { Value = "%" + surnameFilter.Text + "%" });
            }

            if (majorFilter.SelectedItem!= null)
            {
                query += " AND t.major = @major";
                parameters.Add(new SqlParameter("@major", SqlDbType.NVarChar) { Value = majorFilter.SelectedItem.ToString() });
            }

            if (classFilterDropdown.SelectedItem != null)
            {
                if (classFilterDropdown.SelectedItem.ToString() == "NONE")
                {
                    query += " AND c.classname IS NULL";
                }
                else
                {
                    query += " AND c.classname = @className";
                    parameters.Add(new SqlParameter("@className", SqlDbType.NVarChar) { Value = classFilterDropdown.SelectedItem.ToString() });
                }
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
            classFilterDropdown.Items.Clear();
            classFilterDropdown.Items.Add("NONE"); // Add NONE option

            using (SqlConnection sqlConnection = new SqlConnection(DatabaseConnection.ConnectionString))
            {
                sqlConnection.Open();

                string query = "SELECT DISTINCT classname FROM Class WHERE schoolId = @schoolId";
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@schoolId", GetSchoolId());
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string className = reader["classname"].ToString();
                            classFilterDropdown.Items.Add(className);
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
            FilterTeachers();
        }

        private void surnameFilter_TextChanged(object sender, EventArgs e)
        {
            FilterTeachers();
        }

        private void majorFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTeachers();
        }

        private void classFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTeachers();
        }
        
        private void clearFiltersBtn_Click(object sender, EventArgs e)
        {
            // Clear filter textboxes
            nameFilter.Text = "";
            surnameFilter.Text = "";

            // Reset major and class filter dropdowns
            majorFilter.SelectedIndex = -1;
            classFilterDropdown.SelectedIndex = -1;

            // Perform filtering with reset filters
            FilterTeachers();
        }

        private void backIcon_Click_1(object sender, EventArgs e)
        {
            TeacherSettings teacherSettings = new TeacherSettings(adminUsername, schoolName);
            teacherSettings.StartPosition = FormStartPosition.Manual;
            teacherSettings.Location = this.Location;
            this.Hide();
            teacherSettings.ShowDialog();
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
    }
}