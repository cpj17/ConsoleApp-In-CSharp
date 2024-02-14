using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_9
{
    class Program
    {
        static void addition(int num1, int num2)
        {
            Console.WriteLine("Addition");
            Console.WriteLine("Addition of "+num1+" and "+num2+" is : "+(num1+num2));
        }
        static void subtraction(int num1, int num2)
        {
            Console.WriteLine("Subtraction");
            Console.WriteLine("Subtraction of " + num1 + " and " + num2 + " is : " + (num1 - num2));
        }
        static void multiplication(int num1, int num2)
        {
            Console.WriteLine("Multiplication");
            Console.WriteLine("Multiplication of " + num1 + " and " + num2 + " is : " + (num1 * num2));
        }
        static void division(int num1, int num2)
        {
            Console.WriteLine("Division");
            Console.WriteLine("Division of " + num1 + " and " + num2 + " is : " + (num1 / num2));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number 1");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number 2");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int choice = 0;
            do{
                Console.WriteLine("\n1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter you choice");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addition(num1,num2);
                        break;
                    case 2:
                        subtraction(num1, num2);
                        break;
                    case 3:
                        multiplication(num1, num2);
                        break;
                    case 4:
                        division(num1, num2);
                        break;
                    default:
                        Console.WriteLine("Pls Enter valid choice");
                        break; 
                }
            }while(choice != 5);
        }
    }
}
