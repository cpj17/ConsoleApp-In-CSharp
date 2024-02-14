using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number : ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= n; i++)
                Console.WriteLine(i);
            Console.ReadLine();
        }
    }
}
