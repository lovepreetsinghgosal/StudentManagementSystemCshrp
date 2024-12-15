using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG455LabProjecct
{
    public class Course
    {
        public string Name { get; set; }
        public double Mark { get; set; }
        public double Credits { get; set; }
        public string Semester { get; set; }

        public Course(string name, double mark, double credits, string semester)
        {
            Name = name;
            Mark = mark;
            Credits = credits;
            Semester = semester;
        }
    }
}
