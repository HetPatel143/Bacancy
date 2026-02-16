using System;

class GuessingGame
{
    public static void Run()
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
}
