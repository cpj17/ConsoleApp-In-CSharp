using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Operators
            //Arithmetic
            Console.WriteLine("Enter Number 1 ");
            int num1 =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Number 2 ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Addition of "+num1+" + "+num2+" is : "+(num1+num2));
            Console.WriteLine("Subtraction of " + num1 + " - " + num2 + " is : " + (num1 - num2));
            Console.WriteLine("Multiplication of " + num1 + " * " + num2 + " is : " + (num1 * num2));
            Console.WriteLine("Division of " + num1 + " / " + num2 + " is : " + (num1 / num2));
        }
    }
}
