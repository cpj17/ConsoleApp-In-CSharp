using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_68
{
    class Program
    {
        static void Main(string[] args)
        {
            //Method Overloading
            try
            {
                clsMethodOverloading objMethodOverloading = new clsMethodOverloading();
                Console.WriteLine("Method Overloading\n");
                Console.WriteLine("Enter Value 1 : ");
                string stringValue1 = Console.ReadLine();
                Console.WriteLine("Enter Value 2 : ");
                string stringValue2 = Console.ReadLine();

                bool boolValue1Flag, boolValue2Flag;

                //To check input having dot or not
                if (stringValue1.Contains("."))
                {
                    //Here remove dot and check the input numeric or not
                    string stringValue1DotRemoved = stringValue1.Remove(stringValue1.IndexOf("."), 1);
                    boolValue1Flag = objMethodOverloading.isNumber(stringValue1DotRemoved);
                }
                else
                    boolValue1Flag = objMethodOverloading.isNumber(stringValue1);

                if (stringValue2.Contains("."))
                {
                    string stringValue2DotRemoved = stringValue2.Remove(stringValue2.IndexOf("."), 1);
                    boolValue2Flag = objMethodOverloading.isNumber(stringValue2DotRemoved);
                }
                else
                    boolValue2Flag = objMethodOverloading.isNumber(stringValue2);


                if (boolValue1Flag == true && boolValue2Flag == true)
                {
                    Console.WriteLine(objMethodOverloading.myMethod(Convert.ToDouble(stringValue1), Convert.ToDouble(stringValue2)));
                }
                else
                    Console.WriteLine(objMethodOverloading.myMethod(stringValue1, stringValue2));
            }
            catch (Exception objException)
            {
                Console.WriteLine("Error : " + objException.Message);
            }
        }
    }
}
