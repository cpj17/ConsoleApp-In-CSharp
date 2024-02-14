using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_17
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, temp;
            a = 10;
            b = 20;
            Console.WriteLine("Before Swap..");
            Console.WriteLine("A = "+a);
            Console.WriteLine("B = "+b);
            temp = a;
            a = b;
            b = temp;
            Console.WriteLine();
            Console.WriteLine("After Swap..");
            Console.WriteLine("A = " + a);
            Console.WriteLine("B = " + b);
        }
    }
}
