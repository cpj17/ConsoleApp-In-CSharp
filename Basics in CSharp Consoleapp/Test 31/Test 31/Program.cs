using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_31
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type casting int to double
            Console.WriteLine("Type casting int to double");
            var valInt = 17;
            Console.WriteLine("Before conversion...");
            Console.WriteLine("valInt = "+valInt+"  "+valInt.GetType());
            Console.WriteLine("After conversion...");
            double valDouble = valInt;
            Console.WriteLine("valDouble = "+valDouble+"  "+valDouble.GetType());

            //Type Casting double to int
            Console.WriteLine("\nType Casting double to int");
            var valDouble3 = 17.45;
            Console.WriteLine("Before Conversion\nvalDouble = "+valDouble3+"  "+valDouble3.GetType());
            var valInt2 = Convert.ToInt32(valDouble3);
            Console.WriteLine("After Conversion\nvalint = " + valInt2 + "  " + valInt2.GetType());

            //Type casting float to double
            Console.WriteLine("\nType casting float to double");
            var n = 17.6;
            var valFloat = Convert.ToDecimal(n);
            Console.WriteLine("Before Conversion");
            Console.WriteLine("valFloat = " + valFloat + "  " + valFloat.GetType());
            Console.WriteLine("After Conversion");
            var valDouble2 = (double) valFloat;
            Console.WriteLine("valDouble = " + valDouble2 + "  " + valDouble2.GetType());
            Console.WriteLine();

            //Type Casting int to string
            Console.WriteLine("\nType casting int to string");
            var valInt3 = 35;
            Console.WriteLine("Before Conversion\nvalInt = " + valInt3 + "  " + valInt3.GetType());
            var str = Convert.ToString(valInt3);
            Console.WriteLine("After Conversion\nstr = " + str + "  " + str.GetType());

            //Date Time Conversion
            Console.WriteLine("\nDateTime Conversion");
            var dateString = "Sat Apr 17, 2021";
            var convertedDate = Convert.ToDateTime(DateTime.Parse(dateString));
            Console.WriteLine(convertedDate+"  "+convertedDate.GetType());
        }
    }
}