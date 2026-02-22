using Azure;
using CorporateTrainingManagementSystem.Data;
using CorporateTrainingManagementSystem.Repository;

namespace CorporateTrainingManagementSystem
{
    class Program
    {
        public static void Main(String[] args)
        {

            using (var context = new AppDbContext())
            {
                TrainingProgramRepository trainingProgramRepository = new TrainingProgramRepository();
                EmployeeRepository employeeRepository = new EmployeeRepository();
                EnrollmentRepository enrollmentRepository = new EnrollmentRepository();
                DepartmentRepository departmentRepository = new DepartmentRepository();

                try
                {

                    bool flag = false;
                    while (!flag)
                    {
                        Console.WriteLine("-------------MAIN MENU-------------");
                        Console.WriteLine("Enter your choice \n1. Create Training Program\r\n2. Register Employee\r\n3. Enroll Employee in Training\r\n4. Show Training Details (With Employees)\r\n5. Show Department Report\r\n6. Update Employee Performance\r\n7. Delete Training Program\r\n8. Exit\r\n");

                        if (!int.TryParse(Console.ReadLine(), out int choice))
                        {
                            Console.WriteLine("Invalid input Please enter only number");
                            continue;
                        }
                        switch (choice)
                        {
                            case 1:

                                trainingProgramRepository.ProgramCreation(context);
                                break;
                            case 2:

                                employeeRepository.RegisterEmployee(context);
                                break;
                            case 3:

                                enrollmentRepository.EnrollEmployee(context);
                                break;
                            case 4:

                                trainingProgramRepository.ShowTrainingDetails(context);
                                break;
                            case 5:
                                departmentRepository.ShowDepartment(context);
                                break;
                            case 6:
                                employeeRepository.EmployeePerformance(context);
                                break;
                            case 7:
                                trainingProgramRepository.DeleteTraining(context);
                                break;
                            case 8:
                                flag = true;
                                break;
                            default:
                                Console.WriteLine("enter valid options");
                                break;
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                }
            }
        }
    }
}