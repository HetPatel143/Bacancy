using System;
using System.Collections;
using System.Collections.Generic;

class studentRec
{
    public static void Main(string[] args)
    {
        arrayEX();
        listEX();
        DictEX();
    }
    static void arrayEX()
    {
        Console.WriteLine("Student record in Array");
        string[] student1 = new string[3];

        student1[0] = "aaa";
        student1[1] = "bbb";
        student1[2] = "ccc";

        
        foreach(string s in student1)
        {
            if (s == "aaa")
            {
                Console.WriteLine("aaa found");
            }
        }
        student1[1] = "ddd";
        Console.WriteLine($"student update at {student1[1]}");
    }
    static void listEX()
    {
        Console.WriteLine("Student record in list");
        List<string> student2 = new List<string>();
        student2.Add("fff");
        student2.Add("ggg");
        student2.Add("hhh");
               
        if (student2.Contains("ggg"))
        {
            Console.WriteLine("student found ggg");
        }
        int index = student2.IndexOf("ggg");
        if(index != -1)
        {
            student2[index] = "kkk";
        }

        Console.WriteLine("Updated list:");
        foreach (string s in student2)
        {
            Console.WriteLine(s);
        }
    }
    static void DictEX()
    {
        Console.WriteLine("student record in dictionary");
        Dictionary<int,string> student3 = new Dictionary<int,string>();
        student3.Add(1, "mmm");
        student3.Add(2, "nnn");
        student3.Add(3, "ooo");

        if (student3.ContainsKey(1))
        {
            Console.WriteLine($"student found at {student3[1]}");
        }
        student3[2] = "ppp";

        foreach(var std in student3)
        {
            Console.WriteLine($"id {std.Key}, name: {std.Value}");
        }
    }
}