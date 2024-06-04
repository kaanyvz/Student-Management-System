using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using schoolManagementSystem.Admin.CardCRUD.Add;
using schoolManagementSystem.Admin.CardCRUD.Details;

namespace schoolManagementSystem.Admin.CardCRUD.Update
{
    public partial class UpdateCard : Form
    {
        private string adminUsername;
        private string schoolName;
        private DataGridView _dataGridView;
        
        public UpdateCard(string adminUsername, string schoolName)
        {
            this.adminUsername = adminUsername;
            this.schoolName = schoolName;
            InitializeComponent();
            this._dataGridView = new DataGridView();
            this.Controls.Add(this._dataGridView);
            this.Load += UpdateStudent_Load;
            this.StartPosition = FormStartPosition.Manual;
            
            this._dataGridView.Location = new Point(227, 150);
            this._dataGridView.Size = new Size(1200, 450);
            this._dataGridView.BackgroundColor = SystemColors.ControlLight;
            this._dataGridView.BorderStyle = BorderStyle.None;
            this.nameFilter.Height = 40;
            
            
            // Handle the CellContentClick event
            this._dataGridView.CellContentClick += _dataGridView_CellContentClick;
            this._dataGridView.RowPrePaint += _dataGridView_RowPrePaint;
            this._dataGridView.RowHeadersVisible = false;
            this._dataGridView.ReadOnly = true;
            this._dataGridView.RowTemplate.Height = 40;
            this._dataGridView.AllowUserToResizeRows = false;
            this._dataGridView.AllowUserToAddRows = false;
            
        }
        
        
        private void AddUpdateButtonColumn()
        {
            // Add a button column to the DataGridView
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "updateButtonColumn";
            buttonColumn.Text = "Update";
            buttonColumn.HeaderText = "Update";
            buttonColumn.UseColumnTextForButtonValue = false;
            this._dataGridView.Columns.Add(buttonColumn);
        }
        
        private void _dataGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == this._dataGridView.Columns["updateButtonColumn"].Index && e.RowIndex >= 0)
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
            if (e.ColumnIndex == this._dataGridView.Columns["updateButtonColumn"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = this._dataGridView.Rows[e.RowIndex];
                int studentId = Convert.ToInt32(row.Cells["Id"].Value);

                UpdateCardInformations updateCardInformations = new UpdateCardInformations(adminUsername, schoolName, studentId);
                updateCardInformations.StartPosition = FormStartPosition.Manual;
                updateCardInformations.Location = this.Location;
                this.Hide();
                updateCardInformations.ShowDialog();
                this.Close();
                
            }
        }
        
        private void _dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == this._dataGridView.Columns["updateButtonColumn"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                TextRenderer.DrawText(e.Graphics, "Update", e.CellStyle.Font, e.CellBounds, e.CellStyle.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);

                e.Handled = true;
            }
        }

        
        private void UpdateStudent_Load(object sender, EventArgs e)
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
                sc.cardNumber as CardNumber,
                sc.balance as Balance,
                sc.isBlocked as 'Is Blocked'
            FROM
                Student s
                INNER JOIN Class c ON s.classId = c.id
                INNER JOIN StudentCard sc ON s.id = sc.studentId
            WHERE
                c.schoolId = @schoolId AND s.hasOwnCard = 1";

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.Parameters.AddWithValue("@schoolId", schoolId);

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            DataTable dataTable = new DataTable();
                            sqlDataAdapter.Fill(dataTable);
                            

                            _dataGridView.DataSource = dataTable;
                            AdjustColumnWidths();
                            AddUpdateButtonColumn();
                        }
                    }
                }
            }
        }
        
        private void AdjustColumnWidths()
        {
            _dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            _dataGridView.Columns["Name"].Width = 130;
            _dataGridView.Columns["Surname"].Width = 130;
            _dataGridView.Columns["Class"].Width = 50;
            _dataGridView.Columns["Number"].Width = 100;
            _dataGridView.Columns["Gender"].Width = 90;
            _dataGridView.Columns["Age"].Width = 50;
            _dataGridView.Columns["Card"].Width = 80;
            _dataGridView.Columns["CardNumber"].Width = 150;
            _dataGridView.Columns["Balance"].Width = 100;
            _dataGridView.Columns["Is Blocked"].Width = 80;
            
            foreach (DataGridViewColumn column in _dataGridView.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
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
                    sc.cardNumber as CardNumber,
                    sc.balance as Balance,
                    sc.isBlocked as 'Is Blocked'
                FROM
                    Student s
                    INNER JOIN Class c ON s.classId = c.id
                    INNER JOIN StudentCard sc ON s.id = sc.studentId
                WHERE
                    c.schoolId = @schoolId AND s.hasOwnCard = 1";

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

            if (!string.IsNullOrEmpty(cardNumberFilter.Text))
            {
                query += " AND sc.cardNumber LIKE @cardNumber";
                parameters.Add(new SqlParameter("@cardNumber", SqlDbType.NVarChar) { Value = "%" + cardNumberFilter.Text + "%" });
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

        private void backIcon_Click_1(object sender, EventArgs e)
        {
            CardSettings cardSettings = new CardSettings(adminUsername, schoolName);
            cardSettings.StartPosition = FormStartPosition.Manual;
            cardSettings.Location = this.Location;
            this.Hide();
            cardSettings.ShowDialog();
            this.Close(); 
        }
        

        private void cardDetailsButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void cardDetailsButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void addNewCardButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(55, 55, 70);
            }
        }

        private void addNewCardButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.FromArgb(35, 35, 45); 
            }
        }

        private void addNewCardButton_Click(object sender, EventArgs e)
        {
            AddNewCard addNewCard = new AddNewCard(adminUsername, schoolName);
            addNewCard.StartPosition = FormStartPosition.Manual;
            addNewCard.Location = this.Location;
            this.Hide();
            addNewCard.ShowDialog();
            this.Close();
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
        
        private void cardNumberFilter_TextChanged(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void clearFiltersBtn_Click(object sender, EventArgs e)
        {
            nameFilter.Text = "";
            surnameFilter.Text = "";
            numberFilter.Text = "";
            cardNumberFilter.Text = "";

            FilterStudents();
        }

        private void adminDashboardTurnOffButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the application?", "Exit Application", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cardDetailsButton_Click(object sender, EventArgs e)
        {
            StudentCardDetails studentCardDetails = new StudentCardDetails(adminUsername, schoolName);
            studentCardDetails.StartPosition = FormStartPosition.Manual;
            studentCardDetails.Location = this.Location;
            this.Hide();
            studentCardDetails.ShowDialog();
            this.Close();
        }

        private void backIcon_Click(object sender, EventArgs e)
        {
            AdminSettings adminSettings = new AdminSettings(adminUsername, schoolName);
            adminSettings.StartPosition = FormStartPosition.Manual;
            adminSettings.Location = this.Location;
            this.Hide();
            adminSettings.ShowDialog();
            this.Close();
        }
    }
}