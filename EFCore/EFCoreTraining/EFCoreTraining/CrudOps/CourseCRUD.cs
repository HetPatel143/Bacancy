using EFCoreTraining.Data;
using EFCoreTraining.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.CrudOps
{
    public class CourseCRUD
    {
        public void GoCourse(AddDbContext context)
        {
            bool exitCourse = false;
            while (!exitCourse)
            {
                Console.WriteLine("Enter your choice");

                Console.WriteLine("1 - Add Course");
                Console.WriteLine("2 - Show Course");
                Console.WriteLine("3 - Update Course");
                Console.WriteLine("4 - Delete Course");
                Console.WriteLine("5 - Back to Main Menu\n");

                var Response = int.Parse(Console.ReadLine());
                try
                {
                    switch (Response)
                    {

                        case 1: AddCourse(context); break;
                        case 2: ShowCourse(context); break;
                        case 3: UpdateCourse(context); break; 
                        case 4: DeleteCourse(context); break;
                        case 5: break;
                        default:
                            Console.WriteLine("enter valid input");
                            break;


                    }
                    if (Response == 5)
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
                    exitCourse = true;
                }
            }
        }

        public void AddCourse(AddDbContext context)
        {
            //Console.WriteLine("Enter Course Id ");
            //var CouId = int.Parse(Console.ReadLine());
            Course course = new Course();
            Console.WriteLine("Enter course title ");
            course.Title = Console.ReadLine();

            var exists = context.courses.Any(c => c.Title == course.Title);
            if (exists)
            {
                Console.WriteLine("course with same name exists");
                return;
            }

            Console.WriteLine("Enter course fees ");
            course.Fees= int.Parse(Console.ReadLine());

            Console.WriteLine("Enter course duration ");
            course.DurationInMonths = int.Parse(Console.ReadLine());

            context.courses.Add(course);
            Console.WriteLine($"state before update: {context.Entry(course).State}");
            context.SaveChanges();
            Console.WriteLine($"state after update: {context.Entry(course).State}");
            Console.WriteLine("course added");

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
        public void UpdateCourse(AddDbContext context)
        {
            Console.WriteLine("Enter CourseId");
            var OldId = Convert.ToInt32(Console.ReadLine());

            var CId = context.courses.FirstOrDefault(x => x.CourseId == OldId);
            if (CId == null)
            {
                Console.WriteLine($"Course with {OldId} didnot exist");
                return;
            }
            Console.WriteLine("Enter what do you want to Update \n 1:Name\n 2:Experience\n3:All Details ");

            var result = Convert.ToInt32(Console.ReadLine());
            switch (result)
            {
                case 1:
                    Console.WriteLine("Enter new title");
                    CId.Title = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter new fees");
                    CId.Fees = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Enter new duration");
                    CId.DurationInMonths = Convert.ToInt32(Console.ReadLine());
                    break;
                case 4:
                    Console.WriteLine("Enter new title");
                    CId.Title = Console.ReadLine();
                    Console.WriteLine("Enter new fees");
                    CId.Fees = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter new duration");
                    CId.DurationInMonths = Convert.ToInt32(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("enter valid options\n");
                    UpdateCourse(context);
                    break;
            }

            Console.WriteLine($"state before update: {context.Entry(CId).State}");
            context.SaveChanges();
            Console.WriteLine($"state after update: {context.Entry(CId).State}");
            Console.WriteLine("Course Updated");

        }
        public void DeleteCourse(AddDbContext context)
        {
            
            Console.WriteLine("Enter CourseId");
            var FindId = Convert.ToInt32(Console.ReadLine());

            var course = context.courses.FirstOrDefault(x => x.CourseId == FindId);
            if (FindId == null)
            {
                Console.WriteLine($"Course with {FindId} didnot exist");
                return;
            }
            
            context.courses.Remove(course);
            Console.WriteLine($"state before update: {context.Entry(course).State}");
            context.SaveChanges();
            Console.WriteLine($"state after update: {context.Entry(course).State}");
            Console.WriteLine("Course Deleted");
            
        }

    }
}

