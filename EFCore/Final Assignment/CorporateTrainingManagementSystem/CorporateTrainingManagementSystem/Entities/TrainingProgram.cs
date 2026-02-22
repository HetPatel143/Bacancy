using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CorporateTrainingManagementSystem.Model
{
    public class TrainingProgram
    {
        public int TrProgramId { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public DateOnly StartDate { get; set; }
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
