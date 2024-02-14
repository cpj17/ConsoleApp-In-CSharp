using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_27
{
    class Program
    {
        static void Main(string[] args)
        {
            //Nested While Loops
            int i = 1;
            while(i <= 5)
            {
                int j = 1;
                while(j <= 3)
                {
                    Console.WriteLine(j);
                    j++;
                }
                i++;
                Console.WriteLine();
            }
        }
    }
}
