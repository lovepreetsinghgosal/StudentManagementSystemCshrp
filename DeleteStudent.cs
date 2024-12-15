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
    public partial class DeleteStudent : Form
    {
        private string filepath;
        public DeleteStudent(string filepath)
        {
            InitializeComponent();
            this.filepath = filepath;
            LoadStudents();
        }

        private void LoadStudents()
        {
            dataGridViewStudents.Columns.Clear();

            // Add columns to DataGridView
            dataGridViewStudents.Columns.Add("FirstName", "First Name");
            dataGridViewStudents.Columns.Add("LastName", "Last Name");
            dataGridViewStudents.Columns.Add("Email", "Email");

            // Read the students from the file
            TxtReader txtReader = new TxtReader();
            List<Student> students = txtReader.LoadStudentsFromTxt(filepath);

            // Clear any existing rows
            dataGridViewStudents.Rows.Clear();

            // Populate DataGridView with students' first name, last name, and email
            foreach (Student student in students)
            {
                dataGridViewStudents.Rows.Add(student.FirstName, student.LastName, student.Email);
            }
        }
        private void DeleteStudent_Load(object sender, EventArgs e)
        {

        }

        private void dataGridViewStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is selected
            {
                // Get the selected student's email
                string studentEmail = dataGridViewStudents.Rows[e.RowIndex].Cells["Email"].Value.ToString();

                // Ask for confirmation to delete the student
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the student account associated with the email address: {studentEmail}?",
                                                      "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Proceed to delete the student
                    DeleteStudentFromFile(studentEmail);
                    MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload the DataGridView to reflect the deletion
                    LoadStudents();
                    Form mainForm = Application.OpenForms["Main"];
                    ((Main)mainForm).RefreshData();
                }
            }
        }
        private void DeleteStudentFromFile(string studentEmail)
        {
            TxtReader txtReader = new TxtReader();
            List<Student> students = txtReader.LoadStudentsFromTxt(filepath);

            // Find the student by email and remove it from the list
            Student studentToDelete = null;

            foreach (Student student in students)
            {
                if (student.Email == studentEmail)
                {
                    studentToDelete = student;
                    break; // Exit loop once we find the student
                }
            }

            // If the student was found, remove them from the list
            if (studentToDelete != null)
            {
                students.Remove(studentToDelete);

                // Save the updated list of students back to the file using TxtWriter
                TxtWriter txtWriter = new TxtWriter();
                txtWriter.SaveStudentsToTxt(filepath, students);
            }
            else
            {
                MessageBox.Show("Student not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
  
}
