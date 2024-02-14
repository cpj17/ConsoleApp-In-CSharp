using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_18
{
    class Program
    {
        static void Main(string[] args)
        {
            //Swapping w/o using temp variable
            int a = 10, b = 20;
            Console.WriteLine("Before Swapping....");
            Console.WriteLine("A = "+a);
            Console.WriteLine("B = " +b);

            //Swap Process
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine();
            Console.WriteLine("After Swapping....");
            Console.WriteLine("A = " + a);
            Console.WriteLine("B = " + b);
        }
    }
}
