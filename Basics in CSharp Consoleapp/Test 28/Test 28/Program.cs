using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_28
{
    class Program
    {
        static void Main(string[] args)
        {
            int i=1;
            do
            {
                Console.WriteLine("Outer Loop\n");
                i++;
                int j=1;
                do
                {
                    Console.WriteLine("Inner Loop");
                    j++;
                }while(j<=2);
                Console.WriteLine();
            }while(i<5);
        }
    }
}
