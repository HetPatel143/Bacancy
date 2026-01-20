using System;

class balanceEx : Exception
{
    public balanceEx(string message) : base(message)
    {

    }
}

class Banking
{
    public static void main(string[] args)
    {
        double balance = 4999;

        Console.WriteLine($"your balance {balance}");

        try
        {
            Console.WriteLine("enter amount you want");
            double amount = double.Parse(Console.ReadLine());
            withdraw(balance, amount);
        }
        catch(balanceEx ex)
        {
            Console.WriteLine($"exception {ex.Message}");
        }
        finally
        {
            Console.WriteLine("your account credited");
        }
    }
    static void withdraw(double balance, double amount)
    {
        if (amount > balance)
        {
            throw new balanceEx("not enough balance");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"money credited successfully. your balance is {balance}");
        }
    }
}

