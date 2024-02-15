using System;
using System.Data;
using System.Collections;
using System.Globalization;

namespace Test_77
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateValue;
            string dateString = "2021-05-25T18:36:32+05:30";

            try
            {
                dateValue = DateTime.Parse(dateString, new CultureInfo("fr-FR", true));
                Console.WriteLine("'{0}' converted to {1}.", dateString, dateValue);
            }
            catch (FormatException)
            {
                Console.WriteLine("Unable to convert '{0}'.", dateString);
            }
        }
    }
}
