using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG455LabProjecct
{
    public class TxtWriter
    {
        public void SaveStudentsToTxt(string filePath, List<Student> students)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                
                writer.WriteLine("FirstName,MiddleName,LastName,DateOfBirth,Email,StatusInCanada,HomeAddress,PhoneNumber");

                foreach (Student student in students)
                {
                    writer.Write(student.FirstName + ",");
                    writer.Write(student.MiddleName + ",");
                    writer.Write(student.LastName + ",");
                    writer.Write(student.DateOfBirth.ToString("yyyy-MM-dd") + ",");
                    writer.Write(student.Email + ",");
                    writer.Write(student.StatusInCanada + ",");
                    writer.Write(student.HomeAddress + ",");
                    writer.Write(student.PhoneNumber);

                    foreach (Course course in student.Courses)
                    {
                        writer.Write("," + course.Name + "," + course.Mark + "," + course.Credits + "," + course.Semester);
                    }

                    writer.WriteLine();
                }
            }
        }
    }
}
