using System;
using System.Diagnostics;
using System.Threading;

namespace Sleep
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Going to sleep…");
            Thread.Sleep(1000);
            Console.WriteLine("Woke up after 1 sec!");

            //Method 2
            //Console.WriteLine("Going to sleep…");
            //Stopwatch stopwatch = Stopwatch.StartNew();
            //while (stopwatch.ElapsedMilliseconds < 1000) ;
            //Console.WriteLine("Woke up after 1 sec!");

            Console.Read();
        }
    }
}
