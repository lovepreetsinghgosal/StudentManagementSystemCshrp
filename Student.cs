using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG455LabProjecct
{
    public class Student
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string StatusInCanada { get; set; }
        public string HomeAddress { get; set; }
        public string PhoneNumber { get; set; }
        public List<Course> Courses { get; set; }

        public Student()
        {
            Courses = new List<Course>();
        }

        public double TotalCreditsPassed()
        {
            double totalCredits = 0;

            // Loop through each course and add its credits
            foreach (var course in Courses)
            {
                totalCredits += course.Credits;  // Add the credits of all courses
            }

            return totalCredits;
        }

        // Method to calculate the average mark for a specific semester (weighted average)
        public double AverageMarkForSemester(string semester)
        {
            double totalMarks = 0;
            double totalCredits = 0;

            // Loop through each course in the specific semester
            foreach (var course in Courses)
            {
                if (course.Semester == semester)
                {
                    totalMarks += course.Mark * course.Credits;  // Multiply mark by credits
                    totalCredits += course.Credits;
                }
            }

            // Prevent division by zero and return the average
            return totalCredits == 0 ? 0 : totalMarks / totalCredits;
        }

        // Method to calculate total average mark for all courses
        public double TotalAverageMark()
        {
            double totalMarks = 0;
            double totalCredits = 0;

            // Loop through each course and add its weighted mark and credits
            foreach (var course in Courses)
            {
                totalMarks += course.Mark * course.Credits;  // Multiply mark by credits
                totalCredits += course.Credits;
            }

            // Prevent division by zero and return the average
            return totalCredits == 0 ? 0 : totalMarks / totalCredits;
        }

        // Method to calculate the standard deviation of marks (weighted by credits)
        public double StandardDeviation()
        {
            double mean = TotalAverageMark();
            double varianceSum = 0;
            double totalCredits = 0;

            // Loop through each course and calculate the variance for standard deviation
            foreach (var course in Courses)
            {
                varianceSum += Math.Pow(course.Mark - mean, 2) * course.Credits;
                totalCredits += course.Credits;
            }

            // Return standard deviation, prevent division by zero
            return totalCredits == 0 ? 0 : Math.Sqrt(varianceSum / totalCredits);
        }

        // Method to calculate percentile (simplified, rank-based approach)
        public double CalculatePercentile(List<Student> allStudents)
        {
            List<Student> sortedStudents = new List<Student>(allStudents);

            for (int i = 1; i < sortedStudents.Count; i++)
            {
                Student currentStudent = sortedStudents[i];
                double currentMark = currentStudent.TotalAverageMark();

                int j = i - 1;

                // Shift elements that are less than currentStudent's average mark
                while (j >= 0 && sortedStudents[j].TotalAverageMark() < currentMark)
                {
                    sortedStudents[j + 1] = sortedStudents[j];
                    j--;
                }

                // Place currentStudent in its correct position
                sortedStudents[j + 1] = currentStudent;
            }


            // Initialize rank as 1
            int rank = 1;

            // Loop over sorted students to calculate rank for the current student
            for (int i = 0; i < sortedStudents.Count; i++)
            {
                // If the current student has the same mark as the previous one, keep the same rank
                if (i > 0 && sortedStudents[i].TotalAverageMark() == sortedStudents[i - 1].TotalAverageMark())
                {
                    // Same rank as the previous student
                    continue;
                }

                // Otherwise, assign the rank based on the index (rank starts from 1)
                rank = i + 1;

                // If the current student is the one whose percentile we need, break out of the loop
                if (sortedStudents[i] == this)
                {
                    break;
                }
            }

            // Calculate percentile: rank divided by total number of students
            return (double)rank / allStudents.Count * 100;
        }
    }
}
