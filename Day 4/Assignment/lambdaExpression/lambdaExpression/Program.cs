using System;
using System.Collections.Generic;
using System.Linq;
class LambdaEx
{
    static int[] num ={1,8,5,7,10,4,9,2,6,3};
    public static void Main(string[] args)
    {
        evenNumber();
        maxVal();
        sortedColl();
    }
    static void evenNumber()
    {
        
        Console.WriteLine("numbers are:");
        Array.ForEach(num, n => Console.WriteLine(n));
        Console.WriteLine("even numbers are:");
        int[] evenNum = num.Where(x => x % 2 == 0).ToArray();
        Array.ForEach(evenNum,m => Console.WriteLine(m));
    }
    static void maxVal()
    {
        var maximum = num.Max(x => x);
        Console.WriteLine($"max value is {maximum}");
    }
    static void sortedColl()
    {
        Array.Sort(num);
        Array.ForEach(num, n => Console.WriteLine(n));

    }
}