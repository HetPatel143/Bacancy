using assignment_3;
using System;

class Program
{
    static void Main(string[] args)
    {
        Student student=new Student(101,"name",22,"ahmedabad");
        student.course = "cse";
        student.cgpa = 9.9;
        student.grade = 'A';
        student.profile();

    }
}