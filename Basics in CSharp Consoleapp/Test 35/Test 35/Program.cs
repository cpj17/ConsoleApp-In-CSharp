using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_35
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "This is a string";
            Console.WriteLine("Given String : "+str+"\nWhich Letters do you want to remove....");
            string key = Console.ReadLine();
            string[] sep = { key };
            string[] txt = str.Split(sep,StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in txt)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}
