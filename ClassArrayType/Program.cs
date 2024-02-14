using System;

namespace ClassArrayType
{
    class Program
    {
        static void Main(string[] args)
        {
            test[] obj = new test[2];
            obj[0] = new test();
            obj[0].str1 = "fgjhjgfn";
            
            string msg = "string fdhhg";
            Console.WriteLine(msg.GetType());
            Console.WriteLine(obj.GetType());
        }
    }
    class test
    {
        public string str1 { get; set; }
        public string str2 { get; set; }
    }
}
