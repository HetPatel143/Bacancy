using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTraining.Models
{
    public class Trainer
    {
        public int TrainerId { get; set; }
        public string Name { get; set; }
        public int ExperienceYears { get; set; }

        public List<Batch> Batch { get; set; }
    }
}
