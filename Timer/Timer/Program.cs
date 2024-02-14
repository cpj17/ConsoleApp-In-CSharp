using System;
using System.Threading;

namespace Timer2
{
    class Program
    {
        static void Main(string[] args)
        {
            int sec = 1 * 1000;

            var timer = new Timer(TimerMethod, null, 0, sec);
            Console.ReadKey();
        }
        public static void TimerMethod(object e)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
