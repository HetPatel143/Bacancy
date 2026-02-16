using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace assignment_3
{
    public partial class Student
    {
        public string course;
        public double cgpa;
        public char grade;
        public void profile()
        {
            Console.WriteLine($"enrollment: {enrollment}");
            Console.WriteLine($"student name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"address: {add}");
            Console.WriteLine($"Course: {course}");
            Console.WriteLine($"CGPA: {cgpa}");
            Console.WriteLine($"grade {grade}");
        }
    }
}
