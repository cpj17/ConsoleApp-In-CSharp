using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr={"val 1","val 2","val 3"};
            Console.WriteLine(arr[0]);
            Console.WriteLine(Array.IndexOf(arr, "val 1"));
        }
    }
}
