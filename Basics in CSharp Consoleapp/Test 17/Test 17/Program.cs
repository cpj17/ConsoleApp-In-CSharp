using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_17
{
    class test
    {
        static void Main(string[] args)
        {
            string str = "CPJ";
            int len = str.Length - 1;
            for (int i = len; i >= 0; i--)
            {
                Console.WriteLine(str[i]);
            }
        }
    }
}
