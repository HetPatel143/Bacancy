using System;
using System.IO;

#region  IDisposable
//class Program
//{
//    public static void Main(string[] args)
//    {
//        string filename = @"C:\Bacancy\C sharp\Day 10\log.txt";
//        string text = "user logged in";
//        File.WriteAllText(filename, text);

//        using (FileLog fl = new FileLog(filename))
//        {
//            fl.ReadLog();
//        }
//    }
//}
//class FileLog : IDisposable
//{
//    private StreamReader sr1;
//    public FileLog(string filename)
//    {
//       sr1=new StreamReader(filename);
//        Console.WriteLine("file open");
//    }
//    public void ReadLog()
//    {
//        Console.WriteLine(sr1.ReadLine());
//    }
//    public void Dispose()
//    {
//        if(sr1 != null)
//        {
//            sr1.Dispose();
//            Console.WriteLine("file close");
//        }
//    }
//}

#endregion

#region Garbage Collection

class MyObject
{
    private int id;
    public MyObject(int i)
    {
        id = i;
        Console.WriteLine($"object {id}");
    }
    ~MyObject()
    {
        Console.WriteLine($"object {id} finalized");
    }
}
class Program
{
    public static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            if (i == 2 || i == 5 || i == 7 || i == 9)
            {
                System.GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            else
            {
                MyObject obj = new MyObject(i);

            }
        }
    }
}

#endregion