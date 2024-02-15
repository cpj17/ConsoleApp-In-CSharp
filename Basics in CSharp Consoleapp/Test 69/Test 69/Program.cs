using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_69
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Type objType = typeof(char);
            Console.WriteLine("Class : "+objType.Name+"\n");

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
            }
        }
    }
}
