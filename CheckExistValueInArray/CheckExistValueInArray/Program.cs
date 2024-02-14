using System;
using System.Linq;
using System.IO;

namespace CheckExistValueInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sourceList = File.ReadAllLines(@"C:\Users\GSIAD-023\Desktop\source.txt");
            string[] destList = File.ReadAllLines(@"C:\Users\GSIAD-023\Desktop\dest.txt");

            string containNumb = "";

            for (int i = 0; i < destList.Length; i++)
            {
                if (sourceList.Contains(destList[i]))
                {
                    containNumb += destList[i] + Environment.NewLine;
                }
            }
            if (containNumb.Length > 0)
                Console.WriteLine(containNumb);
            else
                Console.WriteLine("No Match Found");
            Console.ReadLine();
        }
    }
}
