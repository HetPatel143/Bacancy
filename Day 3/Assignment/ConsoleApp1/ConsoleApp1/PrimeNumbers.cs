using System;

class PrimeNumbers
{
    public static void Run()
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
}


