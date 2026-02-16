using Assignment_1;
using Assignment_1.extension;
using Assignment_1.home_device;
using Assignment_1.Interface;
using Assignment_1.Publish;
using System;

class Program
{
    public static void Main()
    {
        Console.Write("Enter coding exam score: ");
        int score = int.Parse(Console.ReadLine());
        IExam exam = new Coding();

        Console.Write("Enter mcq exam score: ");
        int score1 = int.Parse(Console.ReadLine());
        IExam exam1 = new Mcq();

        IResult result = new ConsoleResult();
        ExamEvaluator evaluator = new ExamEvaluator(result);
        
        IResult result1 = new FileResult();
        ExamEvaluator evaluator1 = new ExamEvaluator(result1);
        
        evaluator.EvaluateExam(exam, score);
        evaluator.EvaluateExam(exam1, score1);
        evaluator1.EvaluateExam(exam, score);
        evaluator1.EvaluateExam(exam1, score1);

    }
}
