using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_19
{
    public class iface
    {
        public void fun1()
        {
            Console.WriteLine("Inside Function 1");
        }
        public void fun2()
        {
            Console.WriteLine("Inside Function 2");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            iface obj = new iface();
            obj.fun1();
            obj.fun2();
        }
    }
}
