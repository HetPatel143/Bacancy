using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CorporateTrainingManagementSystem.Model
{
    public class Enrollment
    {
        
        public int EnrollmentId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int TrProgramId { get; set; }
        public virtual TrainingProgram TrainingProgram { get; set; }
        public DateOnly EnrollmentDate { get; set; }
        public int PerformanceScore { get; set; }
    }
}
