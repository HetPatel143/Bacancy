using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EFCoreTraining.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public DateOnly StartDate { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        [ForeignKey("Trainer")]
        public int TrainerId { get; set; }

        public Course Course { get; set; }
        public Trainer trainer { get; set; }
    }
}
