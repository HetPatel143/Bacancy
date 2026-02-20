using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using EFCoreTraining.Data;
using EFCoreTraining.Models;
using System.Linq.Expressions;
namespace EFCoreTraining.CrudOps

{
    public class StudentCrud
    {
        public void GoStudent(AddDbContext context)
        {
            bool exitStudent = false;
            while (!exitStudent)
            {
                Console.WriteLine("Enter your choice");

                Console.WriteLine("1 - Add Student");
                Console.WriteLine("2 - Show Student");
                Console.WriteLine("3 - Update Student");
                Console.WriteLine("4 - Delete Student");
                Console.WriteLine("5 - Detach Student");
                Console.WriteLine("6 - Attach Student");
                Console.WriteLine("7 - Back to Main Menu\n");

                var Response = int.Parse(Console.ReadLine());
                try
                {
                    switch (Response)
                    {

                        case 1: AddStudent(context); break;
                        case 2: ShowStudent(context); break;
                        case 3: UpdateStudent(context); break; 
                        case 4: DeleteStudent(context); break;
                        case 5: DetachedStudent(context); break;
                        case 6: attachedStudent(context); break;
                        case 7: break;
                        default:
                            Console.WriteLine("enter valid input");
                            break;


                    }
                    if (Response == 6)
                    {
                        break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }
                Console.WriteLine("to stay inside enter Y to go to Main Menu N");
                var choice = Console.ReadLine();
                var LowChoice = choice.ToLower();
                if (LowChoice == "y")
                {
                    continue;
                }
                else
                {
                    exitStudent = true;
                }
            }
        }
        public void AddStudent(AddDbContext context)
        {
            //Console.WriteLine("Enter Student Id ");
            //var StuId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student Name ");
            Student student = new Student();
            student.Name = Console.ReadLine();

            Console.WriteLine("Enter Student Email ");
            student.Email = Console.ReadLine();

            student.CreatedDate = DateOnly.FromDateTime(DateTime.Now);
            context.students.Add(student);

            Console.WriteLine($"state before update: {context.Entry(student).State}");
            context.SaveChanges();
            Console.WriteLine($"state after update: {context.Entry(student).State}");

            Console.WriteLine("student added");

        }
        
        public void ShowStudent(AddDbContext context)
        {
            var result = context.students.Select(s => new
            {
                s.StudentId,
                s.Name,
                s.Email,
                s.CreatedDate
            }).ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.StudentId}\t{item.Name}\t{item.Email}\t{item.CreatedDate}");
            }
        }
        
        public void UpdateStudent(AddDbContext context)
        {
            Console.WriteLine("Enter StudentId");
            var OldId = Convert.ToInt32(Console.ReadLine());

            var Student = context.students.FirstOrDefault(x => x.StudentId == OldId);
            if (Student == null)
            {
                Console.WriteLine($"Student with {OldId} didnot exist");
                return;
            }

            Console.WriteLine("Enter what do you want to Update \n 1:Name\n 2:Email\n 3:Created Date");
            var result = Convert.ToInt32(Console.ReadLine());
            switch (result) { 
                case 1:
                    Console.WriteLine("Enter new name");
                    Student.Name= Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter new email");
                    Student.Email = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Enter new date");
                    Student.CreatedDate = DateOnly.Parse(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("enter valid options");
                    break;
            }

            Console.WriteLine($"state before update: {context.Entry(Student).State}");
            context.SaveChanges();
            Console.WriteLine($"state after update: {context.Entry(Student).State}");
            Console.WriteLine("Student Updated");
        }

        public void DeleteStudent(AddDbContext context)
        {
            Console.WriteLine("Enter StudentId");
            var FindId = Convert.ToInt32(Console.ReadLine());

            var student = context.students.FirstOrDefault(x => x.StudentId == FindId);
            if (student == null)
            {
                Console.WriteLine($"student with {FindId} didnot exist");
                return;
            }
            
            context.students.Remove(student);
            Console.WriteLine($"state before update: {context.Entry(student).State}");
            context.SaveChanges();
            Console.WriteLine($"state after update: {context.Entry(student).State}");
            Console.WriteLine("Student Deleted");
        }
        public void DetachedStudent(AddDbContext context)
        {
            var student = new Student
            {
                Name = "himanshu",
                Email="himanshu@gmail.com",
                CreatedDate=DateOnly.FromDateTime(DateTime.Now)

            };


            context.students.Add(student);
            Console.WriteLine($"{student.Name} before detach: {context.Entry(student).State}");
            context.SaveChanges();

            context.Entry(student).State = EntityState.Detached;

            Console.WriteLine($"state after detach: {context.Entry(student).State}");
            
        }
        public void attachedStudent(AddDbContext context)
        {
            var student = new Student
            {
                Name = "himanshu",
                Email = "himanshu@gmail.com",
                CreatedDate = DateOnly.FromDateTime(DateTime.Now)

            };


            Console.WriteLine($"{student.Name} before attach: {context.Entry(student).State}");
            context.students.Attach(student);
            context.SaveChanges();

            context.Entry(student).State = EntityState.Modified;

            Console.WriteLine($"state after attach and modify: {context.Entry(student).State}");

            context.students.Remove(student);
            context.SaveChanges();

        }


    }
}