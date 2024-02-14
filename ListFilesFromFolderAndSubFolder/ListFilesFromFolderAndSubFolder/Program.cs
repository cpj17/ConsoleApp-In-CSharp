using System;
using System.IO;

namespace ListFilesFromFolderAndSubFolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Method 1
            //string rootDirectory = @"C:\Users\GSIAD-031\Desktop\testFol"; // replace with the root directory you want to search in

            //Console.WriteLine(rootDirectory);

            //ListSubdirectories(rootDirectory, 1);

            //Method 2
            Console.WriteLine("Enter path");
            string folderPath = Console.ReadLine();
            //string folderPath = @"C:\Users\GSIAD-031\Desktop\testFol";
            int indentSize = 4;

            Console.WriteLine();
            Console.WriteLine(folderPath);
            Console.WriteLine();
            PrintDirectoryTree(new DirectoryInfo(folderPath), indentSize);

            Console.ReadLine();
        }

        static void ListSubdirectories(string path, int depth)
        {
            int count = 1;
            int subdirectoryCount = 0;
            int fileCount = 0;

            foreach (string subdirectory in Directory.GetDirectories(path))
            {
                Console.WriteLine($"{new string(' ', depth * 4)}{count}. {new DirectoryInfo(subdirectory).Name}");
                ListSubdirectories(subdirectory, depth + 1);
                count++;
                subdirectoryCount++;
            }

            foreach (string file in Directory.GetFiles(path))
            {
                Console.WriteLine($"{new string(' ', depth * 4)}{new FileInfo(file).Name}");
                fileCount++;
            }

            if (subdirectoryCount > 0)
            {
                Console.WriteLine($"{new string(' ', depth * 4)}[ {subdirectoryCount} subdirectories, {fileCount} files ]");
            }
            else if (fileCount > 0)
            {
                Console.WriteLine($"{new string(' ', depth * 4)}[ {fileCount} files ]");
            }
        }

        private static void PrintDirectoryTree(DirectoryInfo directory, int indentSize)
        {
            int fileCount = 1;

            foreach (var subdirectory in directory.GetDirectories())
            {
                Console.WriteLine("{0}{1}. {2}", new string(' ', indentSize), fileCount++, subdirectory.Name);
                PrintDirectoryTree(subdirectory, indentSize + 4);
            }

            foreach (var file in directory.GetFiles())
            {
                Console.WriteLine("{0}{1}. {2}", new string(' ', indentSize), fileCount++, file.Name);
            }
        }
    }
}
