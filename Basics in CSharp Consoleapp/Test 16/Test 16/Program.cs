using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_16
{
    class Program
    {
        static void Main(string[] args)
        {
            //Remove a particular letter in the string
            string str = "This is string";
            Console.WriteLine("String : " + str);
            Console.WriteLine("Which letter do you want to remove....");
            string letter = Console.ReadLine();
            int pos = str.IndexOf(letter);
            Console.WriteLine("After removed : " + str.Remove(1, pos));
        }
    }
}
