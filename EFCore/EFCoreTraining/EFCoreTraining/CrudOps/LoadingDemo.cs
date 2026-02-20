using EFCoreTraining.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.CrudOps
{
    public class LoadingDemo
    {
        public void EagerLoading(AddDbContext context)
        {
            Console.WriteLine("---------------Eager Loading------------");
            
            var batch = context.batches.Include(b => b.Course).ThenInclude(b => b.Students).ToList();
            foreach(var i in batch)
            {
                
                Console.WriteLine($"batch {i.BatchId}");
                Console.WriteLine($"course {i.Course.Title}");
                foreach(var j in i.Course.Students)
                {
                    
                    Console.WriteLine($"\tstudent name {j.Name}");
                }
            }
            
        }
        public void LazyLoading(AddDbContext context)
        {
            Console.WriteLine("--------lazy loading with n+1-----------");
            AddDbContext.QueryCount = 0;
            var batches = context.batches.ToList();
            //var batches = context.batches.Include(b => b.Course).ThenInclude(b => b.Students).ToList();
            foreach (var i in batches)
            {
                
                Console.WriteLine("----------processing batch--------");
                Console.WriteLine($"Batch {i.BatchId}");
                Console.WriteLine($"Course {i.Course.Title}");
                foreach (var j in i.Course.Students)
                {
                    
                    Console.WriteLine($"\tStudent: {j.Name}");
                }
            }
            Console.WriteLine($"total queries {AddDbContext.QueryCount}");
        }
        public void ExplicitLoading(AddDbContext context)
        {
            Console.WriteLine("-------------Explicit Loading--------------");
            var batches = context.batches.ToList();
            
            foreach(var i in batches)
            {
                context.Entry(i).Reference(b => b.Course).Load();
                context.Entry(i.Course).Collection(b => b.Students).Load();

                Console.WriteLine($"batch {i.BatchId}");
                Console.WriteLine($"course {i.Course.Title}");
                foreach (var j in i.Course.Students)
                {
                    Console.WriteLine($"\tstudent name {j.Name}");
                }
            }
        }
    }
}
