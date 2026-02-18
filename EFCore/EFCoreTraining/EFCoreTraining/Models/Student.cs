using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCoreTraining.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required,MaxLength(50)]
        public string? Name  { get; set; }

        [Required]
        public string? Email { get; set; }
        public DateOnly CreatedDate { get; set; }

        public List<Course> Courses { get; set;}
    }
}
