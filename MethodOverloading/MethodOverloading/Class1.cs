using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MethodOverloading
{
    public class clsMethodOverloading
    {
        public int myMethod(int int32Value1, int int32Value2)
        {
            return int32Value1 + int32Value2;
        }
        public double myMethod(double doubleValue1, double doubleValue2)
        {
            return doubleValue1 + doubleValue2;
        }
        public string myMethod(string stringValue1, string stringValue2)
        {
            return stringValue1 + stringValue2;
        }

        public bool isNumber(string stringValue)
        {
            bool flag = true;
            for (int i = 0; i < stringValue.Length; i++)
            {
                if (char.IsNumber(stringValue[i]) == false)
                    flag = false;
            }
            return flag;
        }
    }
}
