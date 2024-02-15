using System;
using System.IO;
using System.IO.Compression;

namespace ZipArcive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = @"C:\Users\GSIAD-031\Desktop\testFold"; // Directory to be archived
            string archivePath = @"C:\Users\GSIAD-031\Desktop\Archive.zip"; // Path to save the archive

            // Create a new archive file
            using (ZipArchive archive = ZipFile.Open(archivePath, ZipArchiveMode.Create))
            {
                // Add all files and directories in the source directory to the archive
                foreach (string file in Directory.GetFiles(sourceDirectory))
                {
                    archive.CreateEntryFromFile(file, Path.GetFileName(file));
                }

                //foreach (string dir in Directory.GetDirectories(sourceDirectory))
                //{
                //    archive.CreateEntryFromDirectory(dir, Path.GetFileName(dir));
                //}
            }

            Console.WriteLine("Archive created successfully.");
            Console.ReadKey();
        }
    }
}
