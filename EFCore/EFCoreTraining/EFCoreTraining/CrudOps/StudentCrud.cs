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
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter your choice");
                Console.WriteLine("1 - Add Student");
                Console.WriteLine("2 - Add Course");
                Console.WriteLine("3 - Show Student");
                Console.WriteLine("4 - Show Course");
                Console.WriteLine("5 - Enroll student in course");
                Console.WriteLine("6 - create batch");
                Console.WriteLine("7 - Show course with Student");
                Console.WriteLine("8 - Show trainer with batch");
                Console.WriteLine("9 - exit\n");

                var Response = int.Parse(Console.ReadLine());
                try
                {
                    switch (Response)
                    {
                        case 1: AddStudent(context); break;
                        case 2: AddCourse(context); break;
                        case 3: ShowStudent(context); break;
                        case 4: ShowCourse(context); break;
                        case 5: EnrollStudent(context); break;
                        case 6: CreateBatch(context); break;
                        case 7: CourseStudent(context); break;
                        case 8: TrainerBatches(context); break;
                        case 9: break;
                        default:
                            Console.WriteLine("enter valid input");
                            break;


                    }
                    if (Response == 9)
                    {
                        break;
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }
                Console.WriteLine("enter choice y/n");
                var choice = Console.ReadLine();
                var LowChoice = choice.ToLower();
                if (LowChoice == "y")
                {
                    continue;
                }
                else
                {
                    exit = true;
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

            context.SaveChanges();

            Console.WriteLine("student added");

        }
        public void AddCourse(AddDbContext context)
        {
            //Console.WriteLine("Enter Course Id ");
            //var CouId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter course title ");
            var CouName = Console.ReadLine();

            Console.WriteLine("Enter course fees ");
            var CouFees = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter course duration ");
            var CouDuration = int.Parse(Console.ReadLine());

            context.courses.Add(new Course { Title = CouName, Fees = CouFees, DurationInMonths = CouDuration });

            context.SaveChanges();

            Console.WriteLine("course added");

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
        public void ShowCourse(AddDbContext context)
        {
            var result = context.courses.Select(s => new
            {
                s.CourseId,
                s.Title,
                s.Fees,
                s.DurationInMonths
            }).ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.CourseId}\t{item.Title}\t{item.Fees}\t{item.DurationInMonths}");
            }
        }

        public void EnrollStudent(AddDbContext context)
        {
            Console.WriteLine("enter course title");
            string CName = Console.ReadLine();

            Console.WriteLine("enter student name");
            string SName = Console.ReadLine();

            var course = context.courses.FirstOrDefault(x => x.Title == CName);
            var student = context.students.Include(s => s.Courses).FirstOrDefault(x => x.Name == SName);

            if (student != null && course != null)
            {
                student.Courses.Add(course);

                context.SaveChanges();
                Console.WriteLine("Student enrolled");
            }
            else
            {
                Console.WriteLine("Student or course didnot exist");
            }

        }
        public void CreateBatch(AddDbContext context)
        {
            Batch batch = new Batch();

            Console.WriteLine("Enter batch start date in format (YYYY-MM-DD)");
            batch.StartDate = DateOnly.Parse(Console.ReadLine());

            Console.WriteLine("Enter course title ");
            string CName = Console.ReadLine();

            Console.WriteLine("Enter trainer name ");
            string TName = Console.ReadLine();

            var course = context.courses.FirstOrDefault(x => x.Title == CName);
            var trainer = context.trainers.FirstOrDefault(x => x.Name == TName);

            if (course == null || trainer == null)
            {
                Console.WriteLine("Course or Trainer not found.");
                return;
            }

            batch.TrainerId = trainer.TrainerId;
            batch.CourseId = course.CourseId;

            context.batches.Add(batch);
            context.SaveChanges();

        }

        public void CourseStudent(AddDbContext context)
        {
            var courses = context.courses.Include(c => c.Students).ToList();
            foreach (var i in courses)
            {

                Console.WriteLine($"course name {i.Title} with students");

                if (i.Students.Count == 0)
                {
                    Console.WriteLine("No students in batch");
                }
                else
                {
                    foreach (var j in i.Students)
                    {
                        Console.WriteLine($"\tstudent {j.Name}");
                    }
                }
            }
        }
        public void TrainerBatches(AddDbContext context)
        {
            var trainerbatch = context.trainers.Include(c => c.Batch).ThenInclude(c => c.Course).ToList();
            foreach (var i in trainerbatch)
            {
                Console.WriteLine($"Trainer name {i.Name} with batch");
                if (i.Batch.Count == 0)
                {
                    Console.WriteLine("No students in batch");
                }
                else
                {
                    foreach (var j in i.Batch)
                    {
                        Console.WriteLine($"\tbatch of {j.Course.Title} with batchid:{j.BatchId}");
                    }
                }
            }
        }
    }
}