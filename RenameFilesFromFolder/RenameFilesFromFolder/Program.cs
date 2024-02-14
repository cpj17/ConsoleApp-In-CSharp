using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameFilesFromFolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string folder = "C:\\Users\\GSIAD-031\\Desktop\\test\\";
            Console.WriteLine("Enter Root Folder");
            string folder = Console.ReadLine();

            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();

            string[] list = Directory.GetFiles(folder);

            string stringDestination = "";
            string stringFileFoilderName = "";
            string stringExtension = "";

            for (int i = 1; i <= list.Length; i++)
            {
                stringFileFoilderName = Path.GetDirectoryName(list[i - 1]) + "/";
                stringExtension = Path.GetExtension(list[i - 1]);
                stringDestination = stringFileFoilderName + name + i.ToString() + stringExtension;
                File.Move(list[i - 1], stringDestination);
            }

            Console.WriteLine("Batch Rename Successfully");
            Console.ReadKey();
        }
    }
}
