using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_3
{
    public partial class Student
    {
        public int enrollment;
        public string name;
        public int age;
        public string add;
        public Student(int enrollment, string name, int age, string add)
        {
            this.enrollment = enrollment;
            this.name = name;
            this.age = age;
            this.add = add;
        }

    }
}
