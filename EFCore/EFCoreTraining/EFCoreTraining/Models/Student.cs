using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string? Name  { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
