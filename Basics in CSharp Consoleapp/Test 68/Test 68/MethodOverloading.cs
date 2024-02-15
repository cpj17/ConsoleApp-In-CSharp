using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Test_68
{
    class clsMethodOverloading
    {
        public int myMethod(int int32Value1, int int32Value2)
        {
            return int32Value1 + int32Value2;
        }
        public double myMethod(double int32Value1, double int32Value2)
        {
            return int32Value1 + int32Value2;
        }
        public string myMethod(string int32Value1, string int32Value2)
        {
            return int32Value1 + int32Value2;
        }

        public bool isNumber(string str)
        {
            bool flag = true;
            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsNumber(str[i]) == false)
                    flag = false;
            }
            return flag;
        }
    }
}
