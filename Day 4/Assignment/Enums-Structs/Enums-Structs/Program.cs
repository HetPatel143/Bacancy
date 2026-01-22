//using System;

//class Program
//{
//    public static void Main(string[] args)
//    {
//        Enum1();
//        Struct1();
//        CordClass1();
//        Console.WriteLine("in struct change in copy will not affect the original whereas in class it will change both copy and real");
//    }
//    static void Enum1()
//    {
//        OrderStatus status = OrderStatus.failed;
//        Console.WriteLine($"your order is {status}");
//        double some=(double)OrderStatus.Success;
//        Console.WriteLine($"some {some}");
//        OrderStatus any = (OrderStatus)3;
//        Console.WriteLine($"any {any}");
//        String how=OrderStatus.failed.ToString();
//        Console.WriteLine("how is "+how);
//    }
//    public enum OrderStatus
//    {
//        Success,
//        failed,
//        cancelled,
//        delivered
//    }
//    static void Struct1()
//    {
//        Cordinates c1 = new Cordinates(5, 6);
//        Cordinates c2 = c1;
//        c2.Y = 7;
//        Console.WriteLine($"struct");
//        Console.WriteLine($"c1 cordinates {c1.X} and {c1.Y}");
//        Console.WriteLine($"c2 cordinates {c2.X} and {c2.Y}");
//    }
//    public struct Cordinates
//    {
//        public double X { get; set; }
//        public double Y { get; set; }
//        public Cordinates(double x, double y)
//        {
//            X = x;
//            Y = y;
//        }
//        public double dist()
//        {
//            return (X+Y);
//        }


//    }
//    static void CordClass1()
//    {
//        CordClass c1 = new CordClass(5, 6);
//        CordClass c2 = c1;
//        c2.Y = 8;
//        Console.WriteLine($"class");
//        Console.WriteLine($"c1 cordinates {c1.X} and {c1.Y}");
//        Console.WriteLine($"c2 cordinates {c2.X} and {c2.Y}");
//    }
//    public class CordClass
//    {
//        public double X { get; set; }
//        public double Y { get; set; }
//        public CordClass(double x, double y)
//        {
//            X = x;
//            Y = y;
//        }

//    }
//}


using System;

// Define a class containing methods we might want to call dynamically
public class Calculator
{
    public int Add(int a, int b)
    {
        return a + b;
    }

    public void Greet(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}

class Program
{
    static void Main()
    {
        var calculator = new Calculator();

        // 1. Create a delegate instance that points to the 'Add' method.
        // We use the generic 'Func' delegate type for flexibility.
        // The cast to Delegate is necessary to use DynamicInvoke() later.
        Delegate addDelegate = new Func<int, int, int>(calculator.Add);

        // 2. Dynamically invoke the method
        // We pass arguments as an object array at runtime.
        object[] addArgs = { 5, 10 };
        object result = addDelegate.DynamicInvoke(addArgs);

        Console.WriteLine($"Dynamically invoked Add result: {result}");

        // 3. Example with a different method signature (void return, one string param)
        Delegate greetDelegate = new Action<string>(calculator.Greet);
        object[] greetArgs = { "World" };

        Console.Write("Dynamically invoked Greet: ");
        greetDelegate.DynamicInvoke(greetArgs);
    }
}
