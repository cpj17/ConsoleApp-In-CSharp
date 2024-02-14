
using System;

namespace Goto_Statement
{
    class Program
    {
        static void Main(string[] args)
        {
            int val = 0;
        Loop:
            val += 1;
            Console.WriteLine("In Loop Statement " + val);

            if (val <= 10)
            {
                goto Loop;
            }
            Console.ReadKey();
        }
    }
}
