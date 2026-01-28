using System;
using System.Globalization;
#region Assignment 1
//class Program
//{
//    public static void Main(string[] args)
//    {
//        TemperatureSensor t1 = new TemperatureSensor();
//        t1.Temp = 20.5;
//        t1.Temp = 100;
//        t1.Temp = 50;
//        t1.Temp = -1;
//        t1.Temp = 10;
//        //t1.history.Add(35); //it will throw error
//        foreach (var Temperature in t1.History)
//        {
//            Console.WriteLine(Temperature);
//        }

//    }
//}
//class TemperatureSensor
//{
//    private double temp;
//    private List<double> history = new List<double>();
//    public IReadOnlyList<double> History => history.AsReadOnly();

//    public double Temp
//    {
//        get
//        {
//            return temp;
//        }
//        set
//        {
//            if (temp < 0)
//            {
//                Console.WriteLine($"temperature can not be absolute zero for the value {value}");
//            }
//            else
//            {
//                temp = value;
//                history.Add(temp);
//            }
//        }
//    }

//}
#endregion

#region Assignment 2


//class AppConfig
//{
//    private string AppName;
//    private string Version;
//    private DateTime CreatedDate;

//    public string appName
//    {
//        get
//        {
//            return AppName;
//        }
//    }
//    public string version
//    {
//        get
//        {
//            return Version;
//        }
//    }
//    public DateTime createdDate
//    {
//        get
//        {
//            return CreatedDate;
//        }
//    }
//    public AppConfig(string appName, string version, DateTime createdDate)
//    {
//        this.AppName = appName;
//        this.Version = version;
//        this.CreatedDate = createdDate;
//    }
//}
//class Program
//{
//    public static void Main(string[] args)
//    {
//        AppConfig app1 = new AppConfig("new app", "7.8.9", DateTime.Now);

//        Console.WriteLine(app1.appName);
//        Console.WriteLine(app1.version);
//        Console.WriteLine(app1.createdDate);

//    }
//}
#endregion

#region Assignment 3


//interface INotification
//{
//    void message();
//    String msg { get; set; }
//}
//public class EmailNotification:INotification
//{
//    public String msg { get; set; }
//    public void message()
//    {
//        Console.WriteLine($"you got a mail {msg}");
//    }
//}
//public class SMSNotification : INotification
//{
//    public String msg { get; set; }
//    public void message()
//    {
//        Console.WriteLine($"you got a sms {msg}");
//    }
//}
//class Program
//{
//    public static void Main(string[] args)
//    {
//        EmailNotification m1=new EmailNotification();
//        m1.msg = "email@123";
//        m1.message();
//        SMSNotification m2=new SMSNotification();
//        m2.msg = "sms123";
//        m2.message();
//    }
//}

#endregion

#region Assignment 4

//interface ILogging
//{
//    public void message();
//}
//interface IAuditing
//{
//    public void message();
//}
//class implemented : ILogging, IAuditing
//{
//    void ILogging.message()
//    {
//        Console.WriteLine("ILogging interface message method");
//    }
//    void IAuditing.message()
//    {
//        Console.WriteLine("IAuditing interface message method");
//    }
//}
//class Program
//{
//    public static void Main(string[] args)
//    {
//        implemented i1= new implemented();
//        ILogging l1 = i1;
//        l1.message();
//        IAuditing l2 = i1;
//        l2.message();

//    }
//}


#endregion

#region Assignment 5

//interface IUser
//{
//    void message();
//}
//interface IAdminUser : IUser
//{
//    void msg();
    
//}
//class Combine : IAdminUser
//{
//    public void message()
//    {
//        Console.WriteLine("IAdminUser message");
//    }
//   public void msg()
//    {
//        Console.WriteLine("IAdminUser msg");
//    }

//}
//class Combine2 : IUser
//{
//     public void message()
//    {
//        Console.WriteLine("IUser message");
//    }
//}
//class Program
//{
//    public static void Main(string[] args)
//    {
//        Combine c1 = new Combine();
//        c1.message();
//        c1.msg();
//        //IAdminUser i1 = c1;
//        //i1.msg();
//        //i1.message();
//        //IUser i2 = c1;
//        //i2.message();
//        Combine2 c = new Combine2();
//        c.message();

//    }
//}

#endregion