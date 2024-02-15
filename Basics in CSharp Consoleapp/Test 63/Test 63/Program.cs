using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_63
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter any number");
                Int32 objInt32Number = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("You Entered : "+objInt32Number);
            }
            catch (Exception objException)
            {
                Console.WriteLine("Error : "+objException.Message);
            }
            finally
            {
                Console.WriteLine("In Finally Block");
            }
        }
    }
}
