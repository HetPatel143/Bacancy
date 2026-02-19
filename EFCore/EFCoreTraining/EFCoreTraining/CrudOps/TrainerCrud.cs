using Azure;
using EFCoreTraining.Data;
using EFCoreTraining.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.CrudOps
{
    public class TrainerCrud
    {
        public void GoTrainer(AddDbContext context)
        {
            bool exitTrainer = false;
            while (!exitTrainer)
            {
                Console.WriteLine("Enter your choice");

                Console.WriteLine("1 - Add Trainer");
                Console.WriteLine("2 - Show Trainer");
                Console.WriteLine("3 - Update Trainer");
                Console.WriteLine("4 - Delete Trainer");
                Console.WriteLine("5 - Back to Main Menu\n");

                var Response = int.Parse(Console.ReadLine());
                try
                {
                    switch (Response)
                    {

                        case 1: AddTrainer(context); break;
                        case 2: ShowTrainer(context); break;
                        case 3: UpdateTrainer(context); break; 
                        case 4: DeleteTrainer(context); break;
                        case 5: break;
                        default:
                            Console.WriteLine("enter valid input");
                            GoTrainer(context);
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
                    exitTrainer = true;
                }
            }
        }

        public void AddTrainer(AddDbContext context)
        {
            Trainer trainer = new Trainer();
            Console.WriteLine("Enter Trainer Name ");
            trainer.Name = Console.ReadLine();

            Console.WriteLine("Enter Trainer Experience");
            trainer.ExperienceYears = int.Parse(Console.ReadLine());

            context.trainers.Add(trainer);

            Console.WriteLine($"state before update: {context.Entry(trainer).State}");
            context.SaveChanges();
            Console.WriteLine($"state after update: {context.Entry(trainer).State}");

            Console.WriteLine("Trainer added");

        }

        public void ShowTrainer(AddDbContext context)
        {
            var result = context.trainers.Select(s => new
            {
                s.Name,
                s.ExperienceYears
            }).ToList();

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name}\t{item.ExperienceYears}");
            }
        }
        public void UpdateTrainer(AddDbContext context)
        {

            Console.WriteLine("Enter TrainerId");
            var OldId = Convert.ToInt32(Console.ReadLine());

            var trainer = context.trainers.FirstOrDefault(x => x.TrainerId == OldId);
            if (trainer == null)
            {
                Console.WriteLine($"Trainer with {OldId} didnot exist");
                return;
            }

            Console.WriteLine("Enter what do you want to Update \n 1:Name\n 2:Experience\n3:All Details ");

            var result = Convert.ToInt32(Console.ReadLine());
            switch (result)
            {
                case 1:
                    Console.WriteLine("Enter new name");
                    trainer.Name = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Enter Years of experience");
                    trainer.ExperienceYears = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.WriteLine("Enter new name");
                    trainer.Name = Console.ReadLine();
                    Console.WriteLine("Enter Years of experience");
                    trainer.ExperienceYears = Convert.ToInt32(Console.ReadLine());
                    break;
                default:
                    Console.WriteLine("enter valid options\n");
                    UpdateTrainer(context);
                    break;
            }
            Console.WriteLine($"state before update: {context.Entry(trainer).State}");
            context.SaveChanges();
            Console.WriteLine($"state after update: {context.Entry(trainer).State}");
            Console.WriteLine("Trainer Updated");

        }
        public void DeleteTrainer(AddDbContext context)
        {

            Console.WriteLine("Enter TrainerId");
            var FindId = Convert.ToInt32(Console.ReadLine());

            var trainer = context.trainers.FirstOrDefault(x => x.TrainerId == FindId);
            if (trainer == null)
            {
                Console.WriteLine($"trainer with {FindId} didnot exist");
                return;
            }
            
            context.trainers.Remove(trainer);
            Console.WriteLine($"state before update: {context.Entry(trainer).State}");
            context.SaveChanges();
            Console.WriteLine($"state after update: {context.Entry(trainer).State}");
            Console.WriteLine("trainer Deleted");
            
        }
    }
}
