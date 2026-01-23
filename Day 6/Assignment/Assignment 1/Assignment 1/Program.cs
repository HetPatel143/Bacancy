using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

class Program
{

    static async Task Main()
    {
        var asynctime = Stopwatch.StartNew();
        await Task.WhenAll(
         AsyncMeth(),
         AsyncMeth(),
         AsyncMeth(),
         AsyncMeth());
        //await AsyncMeth();
        //await AsyncMeth();
        //await AsyncMeth();
        //await AsyncMeth();
        asynctime.Stop();

        Console.WriteLine($"async time {asynctime.ElapsedMilliseconds}");
        Console.WriteLine($"async time {asynctime.Elapsed}");
        SyncEx();
    }
    private static async Task AsyncMeth()
    {
        Console.WriteLine("api call start");
        await Task.Delay(1000);
        Console.WriteLine("finish");
    }
    public static async Task<string> SyncMeth(string str)
    {
        //Console.WriteLine("thread start");
        await Task.Delay(1000);
        //Console.WriteLine("thread finish");
        return str;
    }
    public static void SyncEx()
    {

        var synctime = Stopwatch.StartNew();
        string str1 = SyncMeth("erdcasd").Result;
        string str2 = SyncMeth("erdcasd").Result;
        string str3 = SyncMeth("erdcasd").Result;
        string str4 = SyncMeth("erdcasd").Result;
        //Task.Run(SyncMeth);
        synctime.Stop();
        Console.WriteLine($"sync time {synctime.ElapsedMilliseconds}"); //total elapsed time of process
        Console.WriteLine($"sync time {synctime.Elapsed}"); //gives duration of an operation
    }

}