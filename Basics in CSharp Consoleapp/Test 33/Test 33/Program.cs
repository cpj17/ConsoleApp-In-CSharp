using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_33
{
    class Program
    {
        static void Main(string[] args)
        {
            //String Split Methods
            Console.WriteLine("Method 1 char split w/o count");
            string str = "This is, a string, for testing, string split method";
            Console.WriteLine("String : "+str+"\n");
            string[] txt = str.Split(',');

            foreach (string item in txt)
            {
                Console.WriteLine(item);
            }
            
            Console.WriteLine("\nMethod 2 char split w/ count");
            string str2 = "This is, a string, for testing, string, split method";
            Console.WriteLine("String : " + str2 + "\n");
            char[] sep2 = { ',',',' };
            string[] txt2 = str2.Split(sep2,3, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in txt2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nMethod 3 string split");
            string str3 = "This is, a string, for testing, string split method";
            Console.WriteLine("String : " + str3 + "\n");
            string[] sep3 = {"g,","for"};
            string[] txt3 = str.Split(sep3, 3, StringSplitOptions.RemoveEmptyEntries);

            foreach (string item in txt3)
            {
                Console.WriteLine(item);
            }
        }
    }
}
