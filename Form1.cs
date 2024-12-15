using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG455LabProjecct
{
    public partial class Main : Form
    {
        private List<Student> students;
        private string filePath;
        public Main()
        {
            InitializeComponent();
            students = new List<Student>();
        }


        private void Main_Load(object sender, EventArgs e)
        {
            lblEdit.Visible = false;
            dataGridStudentInfo.Visible = false;
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog.Title = "Select a Student Data File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                RefreshData();  // Call RefreshData to load and display the data
            }

        }

        public void RefreshData()
        {

            TxtReader txtReader = new TxtReader();
            students = txtReader.LoadStudentsFromTxt(filePath);
            
            dataGridStudentInfo.Rows.Clear();  // Clear the existing rows
            AddDynamicCourseColumns();

            foreach (Student student in students)
            {
                string formattedDateOfBirth = student.DateOfBirth.ToString("MM/dd/yyyy");

                int rowIndex = dataGridStudentInfo.Rows.Add(student.FirstName, student.MiddleName, student.LastName, formattedDateOfBirth, student.Email, student.StatusInCanada, student.HomeAddress, student.PhoneNumber);

                for (int i = 0; i < student.Courses.Count; i++)
                {
                    Course course = student.Courses[i];
                    dataGridStudentInfo.Rows[rowIndex].Cells[$"CourseName{i + 1}"].Value = course.Name;
                    dataGridStudentInfo.Rows[rowIndex].Cells[$"Mark{i + 1}"].Value = course.Mark;
                    dataGridStudentInfo.Rows[rowIndex].Cells[$"Credits{i + 1}"].Value = course.Credits;
                    dataGridStudentInfo.Rows[rowIndex].Cells[$"Semester{i + 1}"].Value = course.Semester;
                }
            }

            lblEdit.Visible = true;
            dataGridStudentInfo.Visible = true;  // Ensure the DataGridView is visible after data load
        }


        private void AddDynamicCourseColumns()
        {
            // Initialize a variable to store the maximum number of courses any student has
            // Initialize a variable to store the maximum number of courses any student has
            int maxCourses = 0;

            // Loop through each student to find the maximum number of courses
            foreach (var student in students)
            {
                if (student.Courses.Count > maxCourses)
                {
                    maxCourses = student.Courses.Count;  // Update maxCourses if the current student has more courses
                }
            }

            // Clear existing columns before adding new ones
            dataGridStudentInfo.Columns.Clear();

            // Add standard columns (FirstName, LastName, etc.) if necessary
            dataGridStudentInfo.Columns.Add("FirstName", "First Name");
            dataGridStudentInfo.Columns.Add("MiddleName", "Middle Name");
            dataGridStudentInfo.Columns.Add("LastName", "Last Name");
            dataGridStudentInfo.Columns.Add("DateOfBirth", "Date of Birth");
            dataGridStudentInfo.Columns.Add("Email", "Email");
            dataGridStudentInfo.Columns.Add("StatusInCanada", "Status in Canada");
            dataGridStudentInfo.Columns.Add("HomeAddress", "Home Address");
            dataGridStudentInfo.Columns.Add("PhoneNumber", "Phone Number");

            // Dynamically add columns for each course
            for (int i = 0; i < maxCourses; i++)
            {
                // Check if the columns already exist by name
                if (!dataGridStudentInfo.Columns.Contains($"CourseName{i + 1}"))
                {
                    dataGridStudentInfo.Columns.Add($"CourseName{i + 1}", $"Course {i + 1} Name");
                    dataGridStudentInfo.Columns.Add($"Mark{i + 1}", $"Course {i + 1} Mark");
                    dataGridStudentInfo.Columns.Add($"Credits{i + 1}", $"Course {i + 1} Credits");
                    dataGridStudentInfo.Columns.Add($"Semester{i + 1}", $"Course {i + 1} Semester");
                }
            }
        }
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No data was loaded. The file may be empty or in an incorrect format.", "No Data Loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit if no data is loaded
            }
            Report reportForm = new Report(filePath);
            reportForm.Show();

        }

        private void dataGridStudentInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Student selectedStudent = students[e.RowIndex];
                ChoiceForm choiceForm = new ChoiceForm(selectedStudent, filePath);
                choiceForm.ShowDialog();
            }
        }
        


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No data was loaded. The file may be empty or in an incorrect format.", "No Data Loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit if no data is loaded
            }
            AddStudent addStudentForm = new AddStudent(filePath);
            addStudentForm.ShowDialog();
        }

        private void btnDeleteStudent_Click(object sender, EventArgs e)
        {
            if (students.Count == 0)
            {
                MessageBox.Show("No data was loaded. The file may be empty or in an incorrect format.", "No Data Loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit if no data is loaded
            }

            DeleteStudent deleteForm = new DeleteStudent(filePath);
            deleteForm.ShowDialog();
        }
    }
}

    
