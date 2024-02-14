using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = GetSeries(111);
        }

        private static string GetSeries(int intCurrentSequence)
        {
            string stringNewSequence = "0001";
            string stringSeries = "d4";
            try
            {
                if (intCurrentSequence.ToString() != null && intCurrentSequence > 0)
                {
                    stringNewSequence = (intCurrentSequence + 1).ToString(stringSeries);
                }
                return stringNewSequence;
            }
            catch (Exception objException)
            {
                Console.WriteLine(objException);
            }
            return stringNewSequence;
        }
    }
}
