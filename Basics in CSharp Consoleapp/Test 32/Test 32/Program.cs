using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_32
{
    class Program
    {
        static int myMethod(int val1, int val2)
        {
            return val1 + val2;
        }
        static double myMethod(double val1, double val2)
        {
            return val1 + val2;
        }
        static string myMethod(string val1, string val2)
        {
            return val1 + val2;
        }

        static bool isNumber(string str)
        {
            bool flag = true;
            for (int i = 0; i < str.Length; i++)
            {
                if(char.IsNumber(str[i]) == false)
                    flag = false;
            }
            return flag;
        }

        static void Main(string[] args)
        {
            //Method Overloading
            Console.WriteLine("Method Overloading\n");
            Console.WriteLine("Enter Value 1 : ");
            var val1 = Console.ReadLine();
            Console.WriteLine("Enter Value 2 : ");
            var val2 = Console.ReadLine();

            bool v1Flag, v2Flag;
            //To check input having dot or not
            if (val1.Contains("."))
            {
                //Here remove dot and check the input numeric or not
                var val1DotRemoved = val1.Remove(val1.IndexOf("."), 1);
                v1Flag = isNumber(val1DotRemoved);
            }
            else
                v1Flag = isNumber(val1);

            if(val2.Contains("."))
            {
                var val2DotRemoved = val2.Remove(val2.IndexOf("."), 1);
                v2Flag = isNumber(val2DotRemoved);
            }
            else
                v2Flag = isNumber(val2);
            
            
            if (v1Flag == true && v2Flag == true)
            {
                Console.WriteLine(myMethod(Convert.ToDouble(val1),Convert.ToDouble(val2)));
            }
            else
               Console.WriteLine(myMethod(val1, val2));
        }
    }
}
