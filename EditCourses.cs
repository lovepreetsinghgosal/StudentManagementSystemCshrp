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
    public partial class EditCourses : Form
    {
        private Student selectedStudent;
        private string filePath;
        public EditCourses(Student student, string filePath)
        {
            InitializeComponent();
            selectedStudent = student;
            this.filePath = filePath;
            PopulateCourseList();
        }

        private void EditCourses_Load(object sender, EventArgs e)
        {

        }

        private void PopulateCourseList()
        {
            lstCoursesName.Items.Clear();

            // Add each course of the selected student to the list
            foreach (Course course in selectedStudent.Courses)
            {
                lstCoursesName.Items.Add(course.Name); // Assuming lstCourses is a ListBox
            }
        }

        private void lstCoursesName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstCoursesName.SelectedIndex >= 0)
            {
                Course selectedCourse = selectedStudent.Courses[lstCoursesName.SelectedIndex];
                txtCourseName.Text = selectedCourse.Name;
                txtMark.Text = selectedCourse.Mark.ToString();
                txtCredits.Text = selectedCourse.Credits.ToString();
                cmbSemester.SelectedItem = selectedCourse.Semester; 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           


            string courseName = txtCourseName.Text;
            double courseMark = double.Parse(txtMark.Text);
            double courseCredits = double.Parse(txtCredits.Text);
            string semester = cmbSemester.SelectedItem.ToString();

            if (lstCoursesName.SelectedIndex >= 0)
            {
                
                Course selectedCourse = selectedStudent.Courses[lstCoursesName.SelectedIndex];

                
                selectedCourse.Name = courseName;
                selectedCourse.Mark = courseMark;
                selectedCourse.Credits = courseCredits;
                selectedCourse.Semester = semester;

                MessageBox.Show("Course updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Course newCourse = new Course(courseName, courseMark, courseCredits, semester);
                selectedStudent.Courses.Add(newCourse);

                MessageBox.Show("New course added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

             // to refresh the main table on the main form

            PopulateCourseList();
            SaveStudentToFile(filePath);
            Form mainForm = Application.OpenForms["Main"];
            ((Main)mainForm).RefreshData();

        }

        private void SaveStudentToFile(string filePath)
        {
            TxtReader txtReader = new TxtReader();
            List<Student> students = txtReader.LoadStudentsFromTxt(filePath);

            // Find the student we are modifying and update their course list
            foreach (Student student in students)
            {
                if (student.Email == selectedStudent.Email)
                {
                    // Update the student's courses (this includes newly added courses)
                    student.Courses = selectedStudent.Courses;
                    break;
                }
            }

            TxtWriter txtWriter = new TxtWriter();
            txtWriter.SaveStudentsToTxt(filePath, students);

            MessageBox.Show("Student data saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCourseName.Clear();
            txtMark.Clear();
            txtCredits.Clear();
            cmbSemester.SelectedIndex = 0;  

            txtCourseName.Focus();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstCoursesName.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a course to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
                
            Course selectedCourse = selectedStudent.Courses[lstCoursesName.SelectedIndex];

            
            DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete the course: {selectedCourse.Name}?", //Confirmation
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialogResult == DialogResult.Yes)
            {
                selectedStudent.Courses.RemoveAt(lstCoursesName.SelectedIndex);

                MessageBox.Show("Course deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                PopulateCourseList();
                SaveStudentToFile(filePath);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
