using System;
using System.IO;

namespace ChangeAttributesEXE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path");
            string stringPath = Console.ReadLine();

            Console.WriteLine("Enter date time in below format");
            Console.WriteLine();
            Console.WriteLine("2022-03-30 10:30:00. yyyy, MM, dd, hh, mm, ss. hour is 24h format");
            Console.WriteLine();
            Console.WriteLine();

            string dateString = Console.ReadLine().Trim();
            DateTime date = DateTime.Parse(dateString);
            Console.WriteLine(date);

            if (File.Exists(stringPath))
            {
                File.SetLastWriteTime(stringPath, date);
                Console.WriteLine("File last modified time changed");
            }
            else if (Directory.Exists(stringPath))
            {
                Directory.SetLastWriteTime(stringPath, date);  //last modified
                Console.WriteLine("Directory last modified time changed");
            }

            Console.ReadKey();
        }
    }
}
