using CorporateTrainingManagementSystem.Data;
using CorporateTrainingManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CorporateTrainingManagementSystem.Repository
{
    public class TrainingProgramRepository
    {
        public void ProgramCreation(AppDbContext context)
        {
            TrainingProgram trainingProgram = new TrainingProgram();

            Console.WriteLine("Enter Program Title");
            trainingProgram.Title = Console.ReadLine();

            Console.WriteLine("Enter Program Duration in Days");
            trainingProgram.Duration = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Date in Format YYYY-MM-DD");
            trainingProgram.StartDate = DateOnly.Parse(Console.ReadLine());

            Console.WriteLine("Choose a TrainerId from the list");
            var result = context.Trainers.ToList();
            foreach(var trainer in result)
            {
                Console.WriteLine($"{trainer.TrainerId} for {trainer.TrainerName}");
            }
            trainingProgram.TrainerId = Convert.ToInt32(Console.ReadLine());

            context.TrainingPrograms.Add(trainingProgram);
            context.SaveChanges();
            Console.WriteLine("Program created");
        }
        public void ShowTrainingDetails(AppDbContext context)
        {
            Console.WriteLine("Choose training Program");
            
            var program = context.TrainingPrograms.ToList();
            foreach(var result in program)
            {
                Console.WriteLine($"{result.TrProgramId}: \t {result.Title}");
            }

            Console.WriteLine("Enter Program Id");
            var ProgramId = Convert.ToInt32(Console.ReadLine());

            var training = context.TrainingPrograms.Include(e => e.Trainer).FirstOrDefault(e => e.TrProgramId == ProgramId);
            if (training == null)
            {
                Console.WriteLine("ProgramId not found");
                return;
            }

            Console.WriteLine($"\nTraining: {training.Title}");
            Console.WriteLine($"\nTrainer: {training.Trainer.TrainerName}");
            Console.WriteLine($"\nDuration: {training.Duration} days");

            var employee = context.Enrollments.Include(e => e.Employee).ThenInclude(d => d.Department)
                .Where(e => e.TrProgramId == ProgramId).ToList();

            Console.WriteLine("\nEnrolled Employee:\n");
            if (!employee.Any())
            {
                Console.WriteLine("no employee enrolled yet");
                return;
            }

            Console.WriteLine($"ID \t Name \t Department \t Score");
            foreach(var result in employee)
            {
                Console.WriteLine($"{result.EmployeeId}\t{result.Employee.EmployeeName}" +
                    $"\t{result.Employee.Department.DepartmentName}\t{result.PerformanceScore}");
            }

        }
        public void DeleteTraining(AppDbContext context)
        {
            Console.WriteLine("Choose training Program to delete");

            var program = context.TrainingPrograms.ToList();
            foreach (var result in program)
            {
                Console.WriteLine($"{result.TrProgramId}: \t {result.Title}");
            }

            Console.WriteLine("Enter Program Id");
            var ProgramId = Convert.ToInt32(Console.ReadLine());

            var training = context.TrainingPrograms.Include(e => e.Trainer).FirstOrDefault(e => e.TrProgramId == ProgramId);
            if (training == null)
            {
                Console.WriteLine("ProgramId not found");
                return;
            }

            context.TrainingPrograms.Remove(training);
            context.SaveChanges();
            Console.WriteLine("Program Deleted");
        }
    }
}
