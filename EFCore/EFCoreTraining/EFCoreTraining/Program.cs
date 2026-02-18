using EFCoreTraining.CrudOps;
using EFCoreTraining.Data;
using EFCoreTraining.Models;

namespace EFCoreTraining
{
    class Program
    {
        public static void Main(String[] args)
        {
            using(var context=new AddDbContext()) {
                StudentCrud studentCrud = new StudentCrud();
                studentCrud.GoStudent(context);
            }
        }
    }
}