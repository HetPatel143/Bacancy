using System;
class Program
{
    public static void Main(string[] args)
    {
        Thread t1 = new Thread(print1);
        Thread t2 = new Thread(print2);
        t1.Start();
        Thread.Sleep(1000);
        t2.Start();
        Thread t3 = new Thread(print3);
        Thread t4 = new Thread(print4);
        Thread t5 = new Thread(print5);
        t3.Start();
        Thread.Sleep(1000);
        t4.Start();
        Thread.Sleep(2000);
        t5.Start();
        

    }
    static void print1()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"thread 1 {(DateTime.Now.ToString())}");
        }
    }
    static void print2()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"thread 2 {(DateTime.Now.ToString())}");
        }
    }
    static void print3()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"thread 3 {(DateTime.Now.ToString())}");
        }
    }
    static void print4()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"thread 4 {(DateTime.Now.ToString())}");
        }
    }
    static void print5()
    {
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"thread 5 {(DateTime.Now.ToString())}");
        }
    }
}