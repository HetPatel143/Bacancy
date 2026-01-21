using System;

class Program
{
    public static void Main(string[] args)
    {
        Enum1();
        Struct1();
        CordClass1();
        Console.WriteLine("in struct change in copy will not affect the original whereas in class it will change both copy and real");
    }
    static void Enum1()
    {
        OrderStatus status = OrderStatus.failed;
        Console.WriteLine($"your order is {status}");

    }
    public enum OrderStatus
    {
        Success,
        failed,
        cancelled,
        delivered
    }
    static void Struct1()
    {
        Cordinates c1 = new Cordinates(5, 6);
        Cordinates c2 = c1;
        c2.Y = 7;
        Console.WriteLine($"struct");
        Console.WriteLine($"c1 cordinates {c1.X} and {c1.Y}");
        Console.WriteLine($"c2 cordinates {c2.X} and {c2.Y}");
    }
    public struct Cordinates
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Cordinates(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double dist()
        {
            return (X+Y);
        }


    }
    static void CordClass1()
    {
        CordClass c1 = new CordClass(5, 6);
        CordClass c2 = c1;
        c2.Y = 8;
        Console.WriteLine($"class");
        Console.WriteLine($"c1 cordinates {c1.X} and {c1.Y}");
        Console.WriteLine($"c2 cordinates {c2.X} and {c2.Y}");
    }
    public class CordClass
    {
        public double X { get; set; }
        public int Y { get; set; }
        public CordClass(double x, double y)
        {
            X = x;
            Y = y;
        }

    }
}