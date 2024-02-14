using System;
using System.Linq;

namespace test_ns
{
    class test
    {
        static void Main(string[] args)
        {
            int target = 17;
            int ip;
            do
            {
                Console.WriteLine("Enter a number");
                ip = Convert.ToInt32(Console.ReadLine());
                if (ip == target)
                    Console.WriteLine("crt");
                else if (ip > target)
                    Console.WriteLine("greater");
                else
                    Console.WriteLine("smaller");
            } while (ip != target);
            
        }
    }
}