using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_34
{
    class Program
    {
        static void Main(string[] args)
        {
            //Remove a Particular From a String
            string str = "This is a string";
            Console.WriteLine("String : "+str);
            Console.WriteLine("Enter which letter do you want to remove...");
            var key = Console.ReadLine();
            Console.WriteLine(str.Remove(str.IndexOf(key),1));
        }
    }
}
