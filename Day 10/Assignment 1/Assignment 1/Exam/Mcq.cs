using Assignment_1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1.home_device
{
    public class Mcq : IExam
    {
        public int Evaluate(int score)
        {
            return score;
        }
    }
}
