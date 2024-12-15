using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRG455LabProjecct
{
    public class TxtReader
    {
        public List<Student> LoadStudentsFromTxt(string filePath)
        {
            var students = new List<Student>();
           
            var lines = File.ReadLines(filePath);  

            bool isFirstLine = true; 

            foreach (var line in lines)
            {
                if (isFirstLine)
                {
                    isFirstLine = false; // Skip the first the header
                    continue;
                }

                var values = line.Split(',');

                if (values.Length < 8) 
                    continue;

                Student student = new Student
                {
                    FirstName = values[0],
                    MiddleName = values[1],
                    LastName = values[2],
                    DateOfBirth = DateTime.TryParse(values[3], out var dob) ? dob : DateTime.MinValue,  // Use a default date if invalid
                    Email = values[4],
                    StatusInCanada = values[5],
                    HomeAddress = values[6],
                    PhoneNumber = values[7]
                };

                for (int i = 8; i < values.Length; i += 4)  
                {
                    if (i + 3 < values.Length) 
                    {
                        string courseName = values[i];
                        double courseMark = Double.Parse(values[i + 1]);
                        double courseCredits = Double.Parse(values[i + 2]);
                        string courseSemester = values[i + 3]; 

                        student.Courses.Add(new Course(courseName, courseMark, courseCredits, courseSemester));
                    }
                }

                students.Add(student);
            }

            return students;
        }

    }
}
