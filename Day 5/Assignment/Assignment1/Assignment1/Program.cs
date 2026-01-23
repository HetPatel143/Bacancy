using System;


class Program
{
    delegate void MyDelegate(string msg);
    static void Main(string[] args)
    {
        convert();
        string msg = "this is for  ? word count in string";
        Console.WriteLine($"word count is {msg.WordCount()}");

        MyDelegate d = show;
        d("this is delegate after assigning 1 method");
        d += text;
        d.Invoke("this is delegate after assigning 2 methods");

    }
    
    static void convert()
    {
        double a = 5.5;
        Console.WriteLine($"value of a before boxing is {a} and type is {a.GetType()}");
        object obj = a;
        Console.WriteLine($"value of a after boxing is {obj} and type is {obj.GetType()}");
        double b = (double)obj;
        Console.WriteLine($"value of a after unboxing is {b} and type is {b.GetType()}");

        int c = (int)a;
        Console.WriteLine($"value of a after changing it from double to int is {c} and type is {c.GetType()}");
        string d = a.ToString();
        Console.WriteLine($"value of a after changing it from double to string is {d} and type is {d.GetType()}");

    }
    static void show(string s)
    {
        Console.WriteLine(s);
    }
    static void text(string s)
    {
        Console.WriteLine(s);
    }
}
public static class ExtensionMethod
{
    
    public static int WordCount(this string s)
    {
        //string[] words = s.Split(new char[] { ' ', '.', '?' });
        //int count = words.Length;
        //return count;
        return s.Split(new char[] { ' ', '.', '?' },StringSplitOptions.RemoveEmptyEntries).Length;

    }
}

