using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_6
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type Casting
            //Implicit Casting

            Console.WriteLine("Implicit Type Casting");
            int val_int = 23;
            Console.WriteLine("This is a integer value before type casting " +val_int);
            double val_double = val_int;
            Console.WriteLine("This is a Double value after type casting " + val_double);
            Console.WriteLine();

            //Explicit Type Casting
            Console.WriteLine("Explicit Type Casting");
            double val_double2 = 17.965;
            Console.WriteLine("This is a double value before type casting " + val_double2);
            int val_int2 = (int) val_double2;
            Console.WriteLine("This is a integer value after type casting " + val_int2);
            Console.ReadLine();
        }
    }
}
