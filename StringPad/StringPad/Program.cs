using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringPad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str  ="12";
            string padleft = str.PadLeft(3, '0');
            string padright = str.PadRight(3, '0');
        }
    }
}
