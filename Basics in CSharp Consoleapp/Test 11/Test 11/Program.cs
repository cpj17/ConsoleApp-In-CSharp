using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Continue
            Console.WriteLine("Continue");
            for (int i = 0; i < 6; i++)
            {
                if (i == 2)
                {
                    continue;
                }
                Console.WriteLine(i);
            }
            //Break
            Console.WriteLine();
            Console.WriteLine("Break");
            for (int i = 0; i < 6; i++)
            {
                if (i == 2)
                {
                    break;
                }
                Console.WriteLine(i);
            }
        }
    }
}
