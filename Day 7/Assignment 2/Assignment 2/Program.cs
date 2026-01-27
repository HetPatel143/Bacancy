using System;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace assignment_2;

class Program
{
    static void Main(string[] args)
    {
        Profile p1 = new Profile("username", "user@gmail.com", "pass123");
        //we can not directly print password as it is private so we use a method to return the value
        Console.WriteLine($"user name is {p1.Username} and mail is {p1.Mail} and password is {p1.pass}");
    }
}
class Profile
{
    public string Username;
    public string Mail;
    private string Password;
    
    public Profile(string username, string mail, string password)
    {
        if(Regex.IsMatch(mail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) { 
        Username = username;
        Mail=mail;
        Password = password;
        }
        else
        {
            Console.WriteLine("details are wrong");
        }
    }
    public string pass
    {
        get { return Password; }
    }
}
