using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_15
{
    class Program
    {
        static void Main(string[] args)
        {
            //String Split
            string str = "This is a string";
            int len = str.Length;
            for (int i = 0; i < len; i++)
            {
                Console.WriteLine(str.Substring(i,1));
            }
        }
    }
}
