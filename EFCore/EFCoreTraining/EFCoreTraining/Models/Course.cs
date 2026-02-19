using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreTraining.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; }

        [Column(TypeName = "Decimal(10,2)")]
        public int Fees { get; set; }
        public int DurationInMonths { get; set; }

        public virtual List<Batch> Batch { get; set; }
        public virtual List<Student> Students { get; set; }
    }
}