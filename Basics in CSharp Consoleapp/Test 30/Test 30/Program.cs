using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_30
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pattern 1
            Console.WriteLine("Pattern 1");
            for(int i=1;i<=5;i++)
            {
                for(int j=1;j<=i;j++)
                    Console.Write("*");
                Console.WriteLine();
            }

            //Pattern 2
            Console.WriteLine("\nPattern 2");
            for (int i = 5; i >= 1; i--)
            {
                for (int j = 1; j <= i; j++)
                    Console.Write("*");
                Console.WriteLine();
            }

            //Pattern 3
            Console.WriteLine();
            Console.WriteLine("Pattern 3");
            var space = 4;
            for(int i=1;i<=5;i++)
            {
                for (int j = 1; j <= space; j++)
                    Console.Write(" ");
                for (int k = 1; k <= i; k++)
                    Console.Write("* ");
                Console.WriteLine();
                space--;
            }

            //Pattern 4
            Console.WriteLine();
            Console.WriteLine("Pattern 4");
            var space2 = 0;
            for (int i = 5; i >= 1; i--)
            {
                for (int j = 0; j <= space2; j++)
                    Console.Write(" ");
                for (int k = 1; k <= i; k++)
                    Console.Write("* ");
                Console.WriteLine();
                space2++;
            }
        }
    }
}
