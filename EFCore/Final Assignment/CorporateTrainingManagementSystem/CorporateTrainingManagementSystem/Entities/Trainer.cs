using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CorporateTrainingManagementSystem.Model
{
    public class Trainer
    {
        
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public int ExpertiseLevel { get; set; }

        public virtual ICollection<TrainingProgram> TrainingPrograms { get; set; }
    }
}
