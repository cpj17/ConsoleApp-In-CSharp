using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DeleteFolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = "C:\\Users\\GSIAD-031\\Desktop\\delfolder";

            // Delete all files in the directory
            string[] filePaths = Directory.GetFiles(directoryPath);
            foreach (string filePath in filePaths)
            {
                File.Delete(filePath);
            }

            // Delete all subdirectories and their contents
            string[] subdirectoryPaths = Directory.GetDirectories(directoryPath);
            foreach (string subdirectoryPath in subdirectoryPaths)
            {
                Directory.Delete(subdirectoryPath, true);
            }
        }
    }
}
