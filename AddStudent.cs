using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG455LabProjecct
{
    public partial class AddStudent : Form
    {
        private string filePath;
        public AddStudent(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text;
            string middleName = txtMiddleName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string statusInCanada = cmbBoxStatusInCanada.SelectedItem?.ToString(); // Use ComboBox for StatusInCanada
            string homeAddress = txtHomeAddress.Text;
            string phoneNumber = txtPhoneNumber.Text;
            DateTime dateOfBirth = dtpDateOfBirth.Value; // Date Picker for DOB

            // Validate that the user has entered data
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(middleName)|| string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(statusInCanada) ||
                string.IsNullOrEmpty(homeAddress) ||
                string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Create a new student object with all the details
            Student newStudent = new Student
            {
                FirstName = firstName,
                MiddleName = middleName,  // Add MiddleName
                LastName = lastName,
                Email = email,
                StatusInCanada = statusInCanada,  // Add StatusInCanada
                HomeAddress = homeAddress,  // Add HomeAddress
                PhoneNumber = phoneNumber,  // Add PhoneNumber
                DateOfBirth = dateOfBirth,
                Courses = new List<Course>()  // New student starts with no courses
            };

            // Read existing students from the file
            TxtReader txtReader = new TxtReader();
            List<Student> students = txtReader.LoadStudentsFromTxt(filePath);

            // Add the new student to the list
            students.Add(newStudent);

            // Use TxtWriter to save the students back to the file
            TxtWriter txtWriter = new TxtWriter();
            txtWriter.SaveStudentsToTxt(filePath, students);

            // Notify the user
            MessageBox.Show("New student added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Open the EditCoursesForm to add courses to the new student
            EditCourses editCoursesForm = new EditCourses(newStudent, filePath); // Pass the new student
            editCoursesForm.ShowDialog();

            // Close the AddStudentForm after saving and editing courses
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}
