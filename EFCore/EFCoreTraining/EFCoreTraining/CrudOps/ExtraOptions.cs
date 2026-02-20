using EFCoreTraining.Data;
using EFCoreTraining.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.CrudOps
{
    public class ExtraOptions
    {
        public void GoExtra(AddDbContext context)
        { 
        bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Enter your choice");

                Console.WriteLine("1 - Create Batch");
                Console.WriteLine("2 - Enroll Student");
                Console.WriteLine("3 - Course with Student");
                Console.WriteLine("4 - Trainer with batch");
                Console.WriteLine("5 - Back to Main Menu\n");

                var Response = int.Parse(Console.ReadLine());
                try
                {
                    switch (Response)
                    {

                        case 1: CreateBatch(context); break;
                        case 2: EnrollStudent(context); break;
                        case 3: CourseStudent(context); break; ;
                        case 4: TrainerBatches(context); break;
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
                    exit = true;
                }
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
            public void EnrollStudent(AddDbContext context)
            {
                Console.WriteLine("enter course title");
                string CName = Console.ReadLine();

                Console.WriteLine("enter student name");
                string SName = Console.ReadLine();

                var course = context.courses.FirstOrDefault(x => x.Title == CName);
                var student = context.students.Include(s => s.Courses).FirstOrDefault(x => x.Name == SName);

                if (student == null && course == null)
                {
                    Console.WriteLine("Student or course didnot exist");
                }
            if (student.Courses.Any(c => c.CourseId == course.CourseId))
            {
                Console.WriteLine("student already in course");
            }
                    student.Courses.Add(course);

                    context.SaveChanges();
                    Console.WriteLine("Student enrolled");
                

            }
            public void CourseStudent(AddDbContext context)
            {
                var result = context.batches.Include(c => c.Course).ThenInclude(c=>c.Students).ToList();
                var show = result.SelectMany(b => b.Course.Students.DefaultIfEmpty(), (Batch, Student) => new
            {
                BatchId = Batch.BatchId,
                CourseTitle = Batch.Course.Title,
                StudentName = Student!=null ?  Student.Name:"no student"
            });
                foreach(var i in show)
            {
                Console.WriteLine($"batch: {i.BatchId} \t course: {i.CourseTitle} \t student: {i.StudentName}");
            }
            }
            public void TrainerBatches(AddDbContext context)
            {
                //var trainerbatch = context.trainers.ToList();
                //var trainerbatch = context.trainers.Include(c => c.Batch).ToList();
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

