using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_12
{
    class Sports
    {
        string sp_name = "cricket";
        int max_payer = 11;
        int wkts = 10;
        static void Main(string[] args)
        {
            //Accessing Class Object
            Sports obj = new Sports();
            Console.WriteLine(obj.sp_name);
            Console.WriteLine(obj.wkts);
        }
    }
}
