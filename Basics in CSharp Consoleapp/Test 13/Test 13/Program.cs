using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_13
{
    class Program
    {
        //Enum Concepts
        enum days
        {
            sunday,
            monday,
            tuesday,
            wednesday,
            thursday,
            friday,
            saturday
        }
        static void Main(string[] args)
        {
            Console.WriteLine((int) days.monday);
        }
    }
}
