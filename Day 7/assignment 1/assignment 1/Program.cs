using System;
using System.Collections.Concurrent;

class Program
{
    static int accnum = 101;
    static string holderName = "Procedural";
    static double balance = 5000;
    public static void Main(string[] args)
    {
        Console.WriteLine("THIS IS PROCEDURAL");
        Console.WriteLine();
        show();
        Console.WriteLine("enter money you want to deposit");
        double money = Convert.ToDouble(Console.ReadLine());
        deposit(money);
        Console.WriteLine("enter cash you want to withdraw");
        double cash = Convert.ToDouble(Console.ReadLine());
        withDraw(cash);
        Console.WriteLine();

        Console.WriteLine("THIS IS OOP");
        Console.WriteLine();
        BankAcc bank1 = new BankAcc("OOP", 111, 1000);
        bank1.show();
        Console.WriteLine("enter money you want to deposit");
        double oopMoney = Convert.ToDouble(Console.ReadLine());
        bank1.deposit(oopMoney);
        Console.WriteLine("enter cash you want to withdraw");
        double oopCash = Convert.ToDouble(Console.ReadLine());
        bank1.withDraw(oopCash);

    }
    static void deposit(double amount)
    {
        balance += amount;
        Console.WriteLine($"money deposited {amount} and your balance is {balance}");
    }
    static void withDraw(double amount)
    {

        if (amount > balance)
        {
            Console.WriteLine("insufficient balance");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"money withdrawen {amount} remaining balance is {balance}");
        }
    }
    static void show()
    {
        Console.WriteLine($"account number is {accnum}");
        Console.WriteLine($"account holder name is {holderName}");
        Console.WriteLine($"balance is {balance}");
    }
}
class BankAcc
{
    public string name;
    public int id;
    private double balance;
    public BankAcc(string oopName, int oopId, double oopBalance)
    {
        this.balance = oopBalance;
        this.id = oopId;
        this.name = oopName;
    }
    public void deposit(double amount)
    {
        balance += amount;
        Console.WriteLine($"money deposited {amount} and your balance is {balance}");
    }
    public void withDraw(double amount)
    {

        if (amount > balance)
        {
            Console.WriteLine("insufficient balance");
        }
        else
        {
            balance -= amount;
            Console.WriteLine($"money withdrawen {amount} remaining balance is {balance}");
        }
    }
    public void show()
    {
        Console.WriteLine($"account number is {id}");
        Console.WriteLine($"account holder name is {name}");
        Console.WriteLine($"balance is {balance}");
    }
}
