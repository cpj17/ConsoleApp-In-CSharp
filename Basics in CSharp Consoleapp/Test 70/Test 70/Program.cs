using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MethodOverloading;
using EncryptionDecryption;
using System.Reflection;

namespace Test_70
{
    class Program
    {
        static void Main(string[] args)
        {
            //Method Overloading
            try
            {

                /*Type objType = typeof(clsMethodOverloading);
                Console.WriteLine("Class : " + objType.Name + "\n");

                PropertyInfo[] objProperties = objType.GetProperties();
                foreach (PropertyInfo objProperty in objProperties)
                {
                    Console.WriteLine("Property : " + objProperty.Name);
                }

                MethodInfo[] objMethods = objType.GetMethods();
                foreach (MethodInfo objMethod in objMethods)
                {
                    Console.WriteLine("Method : " + objMethod.Name);
                    ParameterInfo[] objParameters = objMethod.GetParameters();

                    foreach (ParameterInfo objParameter in objParameters)
                    {
                        Console.WriteLine("     Parameter : " + objParameter.Name);
                    }
                } */

                var stringValue1 = 3.3 ;
                var stringValue2 = 12 ;

                clsMethodOverloading objMethodOverloading = new clsMethodOverloading();
                //Console.WriteLine(objMethodOverloading.myMethod(12, 23.4));
                Console.WriteLine("Result is : " + objMethodOverloading.myMethod(stringValue1, stringValue2));
                Console.WriteLine("Result Type is : " + objMethodOverloading.myMethod(stringValue1, stringValue2).GetType());
            }
            catch (Exception objException)
            {
                Console.WriteLine("Error : " + objException.Message);
            }
        }
    }
}
