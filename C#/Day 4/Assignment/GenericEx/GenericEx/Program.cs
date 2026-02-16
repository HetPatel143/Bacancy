using System;
using System.Collections.Generic;
class Program
{
    public static void Main(string[] args)
    {
        TestSwap();
        TestRepo();
    }
    public static void TestSwap()
    {
        int a = 1, b = 2;
        Console.WriteLine($"before swap a={a} b={b}");
        Swap(ref a, ref b);
        Console.WriteLine($"after swap a={a} b={b}");
        string c = "s1", d = "s2";
        Console.WriteLine($"before swap a={c} b={d}");
        Swap(ref c, ref d);
        Console.WriteLine($"after swap a={c} b={d}");
    }
    public static void Swap<T>(ref T x, ref T y)
    {
        T temp = x;
        x = y;
        y = temp;
    }
    static void TestRepo()
    {
        GenericRepo<String> repoItems = new GenericRepo<String>();
        repoItems.Add("item 1");
        repoItems.Add("item 2");
        repoItems.Add("item 3");
        repoItems.Add("item 4");
        Console.WriteLine("repo items");
        foreach (var item in repoItems.GetAll()){
            Console.WriteLine(item);
        }
        Console.WriteLine("after update and delete:");
        repoItems.Update(1, "item 5");
        repoItems.Delete(3);
        foreach (var item in repoItems.GetAll())
        {
            Console.WriteLine(item);
        }
    }
    public class GenericRepo<T>
    {
        List<T> repo = new List<T>();

        public void Add(T item)
        {
            repo.Add(item);
        }
        public List<T> GetAll()
        {
            return repo;
        }
        public void Update(int index, T item)
        {
            if(index >= 0 && index < repo.Count)
            {
                repo[index]=item;
            }

        }
        public void Delete(int index)
        {
            repo.RemoveAt(index);
        }
    }
}
