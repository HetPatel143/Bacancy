using System;
using System.Collections.Generic;

class CollectionDemo
{
    public static void Run()
    {
        List<string> names = new List<string>()
        {
            "abc", "bcd", "cde"
        };

        Console.WriteLine("Names in collection:");
        foreach (string i in names)
        {
            Console.WriteLine(i);
        }
    }
}
