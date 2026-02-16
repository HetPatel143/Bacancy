using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.Models
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Fees { get; set; }
        public int DurationInMonths { get; set; }
    }
}
