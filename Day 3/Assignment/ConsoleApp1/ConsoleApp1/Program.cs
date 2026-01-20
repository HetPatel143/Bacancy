using System;

class Program
{
    public static void Main(string[] args)
    {
        Prime();
        Guess();
        coll();
    }
    static void Prime()
    {
        Console.Write("Enter a number: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Prime numbers:");
        for (int num = 2; num <= n; num++)
        {
            bool isPrime = true;

            for (int i = 2; i <= num / 2; i++)
            {
                if (num % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine(num);
            }
        }

    }
    static void Guess()
    
        {
            int secret = 7;
            int num = 0;


            while (num != secret)
            {
                Console.Write("Enter your guess: ");
                num = int.Parse(Console.ReadLine());

                if (num > secret)
                    Console.WriteLine("Too high");
                else if (num < secret)
                    Console.WriteLine("Too low");
                else
                    Console.WriteLine($"Your guess is correct: {num}");
            }
        }
    static void coll()
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
