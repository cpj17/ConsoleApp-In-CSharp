using System;
using System.IO;
using System.Threading;

namespace DeleteTempFolderFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Made By CPJ";
            string tempFolderPath = Path.GetTempPath(); // Get the path of the temp folder
            //Console.WriteLine("Temp Folder Path: " + tempFolderPath);

            int totalFiles = Directory.GetFiles(tempFolderPath).Length;
            int totalFolders = Directory.GetDirectories(tempFolderPath).Length;
            int deletedFiles = 0;
            int deletedFolders = 0;
            DateTime start = DateTime.Now;
            UpdateTimer(start);
            // Delete all files in the temp folder
            foreach (string filePath in Directory.GetFiles(tempFolderPath))
            {
                try
                {
                    UpdateTimer(start);
                    File.Delete(filePath);
                    deletedFiles++;
                    UpdateProgress(totalFiles, totalFolders, deletedFiles, deletedFolders, start);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error deleting file: " + ex.Message);
                }
            }

            // Delete all folders in the temp folder
            foreach (string folderPath in Directory.GetDirectories(tempFolderPath))
            {
                try
                {
                    UpdateTimer(start);
                    Directory.Delete(folderPath, true); // Recursively delete all files and subfolders
                    deletedFolders++;
                    UpdateProgress(totalFiles, totalFolders, deletedFiles, deletedFolders, start);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine("Error deleting folder: " + ex.Message);
                }
            }
            UpdateTimer(start);
            UpdateProgress(totalFiles, totalFolders, totalFiles, totalFolders, start);
            Console.WriteLine();
            Console.WriteLine("Process Done.");
            Console.WriteLine();
            Console.WriteLine("This application is created by CPJ. Thanks for using this app");
            Console.Write("Press enter key to exit.");
            Console.ReadLine();
        }

        static void UpdateProgress(int totalFiles, int totalFolders, int deletedFiles, int deletedFolders, DateTime start)
        {
            double totalItems = totalFiles + totalFolders;
            double deletedItems = deletedFiles + deletedFolders;
            int progressPercentage = (int)Math.Round((deletedItems / totalItems) * 100);

            Console.SetCursorPosition(0, 0);
            Console.Write("Progress \t\t: {0}%", progressPercentage);

            //Console.SetCursorPosition(0, 1);
            //Console.Write("Time elapsed \t\t: {0}", DateTime.Now - start);
            UpdateTimer(start);
        }

        private static void UpdateTimer(DateTime start)
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("Time elapsed \t\t: {0}", DateTime.Now - start);
        }
    }
}
