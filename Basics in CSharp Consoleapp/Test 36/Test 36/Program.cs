using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_36
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sorting
            int[] arrInt = new int[] { 2, 5, 7, 3, 1,5 };
            Console.WriteLine("Given Elements");
            foreach (int item in arrInt)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
            Console.WriteLine("\nAssending Order Sort in integer");
            Array.Sort(arrInt);
            foreach (int item in arrInt)
            {
                Console.Write(item+"  ");
            }
            Console.WriteLine();

            Console.WriteLine("Desending Order Sort in integer");
            Array.Reverse(arrInt);
            foreach (int item in arrInt)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine("\n");
            
            Console.WriteLine("Given Elements");
            string[] arrStr = new string[] { "C", "F", "B", "E", "A", "D" };
            foreach (string item in arrStr)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
            Console.WriteLine("Assending Order Sort in alphabets");
            Array.Sort(arrStr);
            foreach (string item in arrStr)
            {
                Console.Write(item+"  ");
            }
            Console.WriteLine();
            Console.WriteLine("Desending Order Sort in alphabets");
            Array.Reverse(arrStr);
            foreach (string item in arrStr)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
        }
    }
}
