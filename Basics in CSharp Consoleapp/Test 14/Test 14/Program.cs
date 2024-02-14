using System;

namespace Test_14
{
    class test14
    {
        static void Main(string[] args)
        {
            //String Functions
            string str = "This is string";
            Console.WriteLine("Uppercase : " + str.ToUpper());
            Console.WriteLine("Lowercase : " + str.ToLower());
            Console.WriteLine("Index of string position " + str.IndexOf("string"));
            Console.WriteLine("String Concatination " + string.Concat("string 1","string 2"));
        }
    }
}