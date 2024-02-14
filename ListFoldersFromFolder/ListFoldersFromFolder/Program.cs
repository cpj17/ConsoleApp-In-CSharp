using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFoldersFromFolder
{
    //method 1
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Enter Main Folder");
    //        string folderPath = Console.ReadLine();

    //        void ListSubdirectories(string directoryPath, int indentLevel)
    //        {
    //            try
    //            {
    //                Console.WriteLine($"{new string(' ', indentLevel * 2)}{Path.GetFileName(directoryPath)}");
    //                string[] subdirectories = Directory.GetDirectories(directoryPath);
    //                foreach (string subdirectory in subdirectories)
    //                {
    //                    ListSubdirectories(subdirectory, indentLevel + 1);
    //                }
    //            }
    //            catch (UnauthorizedAccessException)
    //            {
    //                // Ignore directories that we don't have permission to access
    //            }
    //        }

    //        ListSubdirectories(folderPath, 0);

    //        Console.ReadKey();
    //    }
    //}

    //Method 2

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Folder Path");
            string rootDirectory = Console.ReadLine();
            //string rootDirectory = @"C:\Users\GSIAD-031\Desktop\testFol"; // replace with the root directory you want to search in

            //Console.WriteLine(rootDirectory);
            Console.WriteLine();
            Console.WriteLine();
            ListSubdirectories(rootDirectory, 1);

            Console.ReadKey();
        }

        static void ListSubdirectories(string path, int depth)
        {
            int count = 1;

            foreach (string subdirectory in Directory.GetDirectories(path))
            {
                Console.WriteLine($"{new string(' ', depth * 4)}{count++}. {new DirectoryInfo(subdirectory).Name}");
                ListSubdirectories(subdirectory, depth + 1);
            }
        }
    }
}
