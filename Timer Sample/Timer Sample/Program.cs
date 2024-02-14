using System;
using System.Timers;

namespace Timer_Sample
{
    class Program
    {
        static Timer timer = new Timer();

        static void Main(string[] args)
        {
            timer.Interval = 1000;
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            Console.Read();
        }

        private static void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
