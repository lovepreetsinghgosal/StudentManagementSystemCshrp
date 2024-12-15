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
    public partial class Report : Form
    {
        private List<Student> students;
        private string filePath;
        public Report(string filePath)
        {
            InitializeComponent();
            this.filePath = filePath;
            students = new List<Student>();
        }
        private void Report_Load(object sender, EventArgs e)
        {
            LoadStudentsFromFile(filePath);
            InitializeReportGrid();
            PopulateReportData();
        }
        private void LoadStudentsFromFile(string filePath)
        {
            // Use the TxtReader to load the students from the file
            TxtReader txtReader = new TxtReader();
            students = txtReader.LoadStudentsFromTxt(filePath); // Load students
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

      
        private void InitializeReportGrid()
        {
            // Add columns for student report (Total Credits, Average, Percentile, etc.)
            dataGridReport.Columns.Add("StudentName", "Student Name");
            dataGridReport.Columns.Add("TotalCreditsPassed", "Total Credits Passed");
            dataGridReport.Columns.Add("TotalAverageMark", "Total Average Mark");
            dataGridReport.Columns.Add("Percentile", "Percentile");

            // Add columns for each course (mean and standard deviation)
            dataGridReport.Columns.Add("CourseMean", "Course Mean");
            dataGridReport.Columns.Add("CourseStdDev", "Course StdDev");
            
        }
        private void PopulateReportData()
        {
            foreach (var student in students)
            {
                // Calculate student statistics
                double totalCreditsPassed = student.TotalCreditsPassed();
                double totalAverageMark = student.TotalAverageMark();
                double stdDev = student.StandardDeviation();
                double percentile = student.CalculatePercentile(students);

                // Add student row
                int rowIndex = dataGridReport.Rows.Add(student.FirstName + " " + student.LastName,
                    totalCreditsPassed, totalAverageMark.ToString("F3"), percentile.ToString("F3"));

                // Add each course's data dynamically
                double totalCourseMean = 0;
                double totalCourseStdDev = 0;
                foreach (var course in student.Courses)
                {
                    totalCourseMean += course.Mark;  // Simplified mean calculation
                    totalCourseStdDev += Math.Pow(course.Mark - totalAverageMark, 2);
                }

                // Calculate course mean and standard deviation
                double courseMean = student.Courses.Count > 0 ? totalCourseMean / student.Courses.Count : 0;
                double courseStdDev = student.Courses.Count > 0 ? Math.Sqrt(totalCourseStdDev / student.Courses.Count) : 0;

                // Update dataGridReport with course stats for each student
                dataGridReport.Rows[rowIndex].Cells["CourseMean"].Value = courseMean.ToString("F3");
                dataGridReport.Rows[rowIndex].Cells["CourseStdDev"].Value = courseStdDev.ToString("F3");
            }

            // Calculate school-wide statistics (total average and standard deviation)
            double schoolTotalMarks = 0;
            double schoolTotalCredits = 0;
            double schoolVarianceSum = 0;

            foreach (var student in students)
            {
                schoolTotalMarks += student.TotalAverageMark() * student.TotalCreditsPassed();
                schoolTotalCredits += student.TotalCreditsPassed();
                double studentMean = student.TotalAverageMark();
                double studentVariance = student.StandardDeviation() * student.StandardDeviation();
                schoolVarianceSum += studentVariance * student.TotalCreditsPassed();
            }
        

            double schoolAverageMark = schoolTotalCredits == 0 ? 0 : schoolTotalMarks / schoolTotalCredits;

            double schoolVariance = schoolVarianceSum / schoolTotalCredits;
            double schoolStdDev = Math.Sqrt(schoolVariance);

            txtBoxSchoolAvg.Text = schoolAverageMark.ToString("F3");
            txtBoxSchoolStdDev.Text = schoolStdDev.ToString("F3");
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
