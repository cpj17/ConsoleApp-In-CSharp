using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheckInternetConnection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (CheckInternetConnection())
                Console.WriteLine("Internet var");
            else Console.WriteLine("Internet yok");


            Console.ReadLine();
        }

        public static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
