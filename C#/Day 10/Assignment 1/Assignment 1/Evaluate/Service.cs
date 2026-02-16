using Assignment_1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.extension
{
    public class ExamEvaluator
    {
        private readonly IResult respublisher;

        public ExamEvaluator(IResult publisher)
        {
            respublisher = publisher;
        }

        public void EvaluateExam(IExam exam,int score)
        {
            int finalscore = exam.Evaluate(score);
            respublisher.DeclareResult(finalscore);
        }
    }
}
