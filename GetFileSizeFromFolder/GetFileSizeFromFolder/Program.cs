using System;
using System.IO;

namespace GetFileSizeFromFolder
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

        //private static void PrintDirectoryTree(DirectoryInfo directory, int indentSize)
        //{
        //    int fileCount = 1;

        //    foreach (var subdirectory in directory.GetDirectories())
        //    {
        //        Console.WriteLine("{0}{1}. {2} (Folder)", new string(' ', indentSize), fileCount++, subdirectory.Name);
        //        PrintDirectoryTree(subdirectory, indentSize + 4);
        //    }

        //    foreach (var file in directory.GetFiles())
        //    {
        //        Console.WriteLine("{0}{1}. {2} (File) - {3} bytes", new string(' ', indentSize), fileCount++, file.Name, file.Length);
        //    }
        //}

        //private static void PrintDirectoryTree(DirectoryInfo directory, int indentSize)
        //{
        //    int fileCount = 1;

        //    foreach (var subdirectory in directory.GetDirectories())
        //    {
        //        Console.WriteLine("{0}{1}. {2} (Folder)", new string(' ', indentSize), fileCount++, subdirectory.Name);
        //        PrintDirectoryTree(subdirectory, indentSize + 4);
        //    }

        //    foreach (var file in directory.GetFiles())
        //    {
        //        string fileSize;
        //        long bytes = file.Length;

        //        if (bytes >= 1024 * 1024 * 1024) // Convert to GB if the size is larger than or equal to 1GB
        //        {
        //            double sizeInGB = (double)bytes / (1024 * 1024 * 1024);
        //            fileSize = string.Format("{0:0.00} GB", sizeInGB);
        //        }
        //        else if (bytes >= 1024 * 1024) // Convert to MB if the size is larger than or equal to 1MB
        //        {
        //            double sizeInMB = (double)bytes / (1024 * 1024);
        //            fileSize = string.Format("{0:0.00} MB", sizeInMB);
        //        }
        //        else // Display the size in bytes
        //        {
        //            fileSize = string.Format("{0} bytes", bytes);
        //        }

        //        Console.WriteLine("{0}{1}. {2} (File) - {3}", new string(' ', indentSize), fileCount++, file.Name, fileSize);
        //    }
        //}

        private static long PrintDirectoryTree(DirectoryInfo directory, int indentSize)
        {
            int fileCount = 1;
            long folderSize = 0;

            foreach (var subdirectory in directory.GetDirectories())
            {
                Console.WriteLine("{0}{1}. {2} (Folder)", new string(' ', indentSize), fileCount++, subdirectory.Name);
                long subdirectorySize = PrintDirectoryTree(subdirectory, indentSize + 4);
                folderSize += subdirectorySize;
            }

            foreach (var file in directory.GetFiles())
            {
                Console.WriteLine("{0}{1}. {2} (File) - {3}", new string(' ', indentSize), fileCount++, file.Name, FormatSize(file.Length));
                folderSize += file.Length;
            }

            Console.WriteLine("{0}Total Size of {1}: {2}", new string(' ', indentSize), directory.Name, FormatSize(folderSize));
            Console.WriteLine();
            return folderSize;
        }

        private static string FormatSize(long bytes)
        {
            string[] sizes = { "bytes", "KB", "MB", "GB", "TB" };
            int i = 0;
            double size = bytes;

            while (size >= 1024 && i < sizes.Length - 1)
            {
                size /= 1024;
                i++;
            }

            return string.Format("{0:0.00} {1}", size, sizes[i]);
        }
    }
}
