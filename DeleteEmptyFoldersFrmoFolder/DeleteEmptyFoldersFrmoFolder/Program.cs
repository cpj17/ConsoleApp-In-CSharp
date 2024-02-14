using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteEmptyFoldersFrmoFolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path");
            //string path = @"C:\Users\GSIAD-031\Desktop\fol - Copy";
            string path = Console.ReadLine();

            // Delete empty directories
            int deletedCount = DeleteEmptyDirectories(path);
            Console.WriteLine($"Deleted {deletedCount} empty directories.");
            Console.ReadLine();
        }

        static int DeleteEmptyDirectories(string path)
        {
            int deletedFolders = 0;

            // Check if directory exists
            if (Directory.Exists(path))
            {
                // Delete empty subdirectories
                foreach (string directory in Directory.GetDirectories(path))
                {
                    deletedFolders += DeleteEmptyDirectories(directory);
                }

                // Check if directory is empty
                if (Directory.GetFiles(path).Length == 0 && Directory.GetDirectories(path).Length == 0)
                {
                    Directory.Delete(path);
                    deletedFolders++;
                }
            }

            return deletedFolders;
        }
    }
}
