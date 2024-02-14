using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_37
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sorting elements using iterative method
            int[] arrInt = new int[] { 2, 5, 7, 3, 1, 5 };
            Console.WriteLine("Given Elements");
            foreach (int item in arrInt)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
            Console.WriteLine("\nAssending Order Sort in integer");
            int temp;
            for(int i=0;i<arrInt.Length;i++)
            {
                for (int j = i+1; j < arrInt.Length; j++)
                {
                    if(arrInt[i] > arrInt[j])
                    {
                        temp = arrInt[j];
                        arrInt[j] = arrInt[i];
                        arrInt[i] = temp;
                    }
                }
            }
            foreach (int item in arrInt)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();

            Console.WriteLine("\nDesending Order Sort in integer");
            int temp2;
            for (int i = 0; i < arrInt.Length; i++)
            {
                for (int j = i + 1; j < arrInt.Length; j++)
                {
                    if (arrInt[i] < arrInt[j])
                    {
                        temp2 = arrInt[j];
                        arrInt[j] = arrInt[i];
                        arrInt[i] = temp2;
                    }
                }
            }
            foreach (int item in arrInt)
            {
                Console.Write(item + "  ");
            }
            Console.WriteLine();
        }
    }
}
