using EFCoreTraining.CrudOps;
using EFCoreTraining.Data;
using EFCoreTraining.Models;
using Microsoft.Identity.Client;

namespace EFCoreTraining
{
    class Program
    {
        public static void Main(String[] args)
        {
            using (var context = new AddDbContext())
            {
                
                bool flag = false;
                while (!flag) {
                Console.WriteLine("-------------MAIN MENU-------------");
                Console.WriteLine("Enter your choice \n 1:Student \n 2:Course \n 3:Trainer \n 4:More Options \n 5:Exit \n 6:Eager Loading/lazy Loading/explicit loading");
                var choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        StudentCrud studentCrud = new StudentCrud();
                        studentCrud.GoStudent(context);
                        break;
                    case 2:
                        CourseCRUD CourseCrud = new CourseCRUD();
                        CourseCrud.GoCourse(context);
                        break;
                    case 3:
                        TrainerCrud trainerCrud = new TrainerCrud();
                        trainerCrud.GoTrainer(context);
                        break;
                    case 4:
                        ExtraOptions extraOptions = new ExtraOptions();
                        extraOptions.GoExtra(context);
                        break;
                    case 5:
                        flag = true;
                        break;
                    case 6:
                            LoadingDemo loadingDemo = new LoadingDemo();
                            loadingDemo.EagerLoading(context);
                            loadingDemo.LazyLoading(context);
                            loadingDemo.ExplicitLoading(context);
                            break;
                    default:
                        Console.WriteLine("enter valid options");
                        break;
                }
                }
            }
        }
    }
}