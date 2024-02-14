using System;
using System.IO;

namespace Delete_Files_SubFolder_FromFolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DeleteFunction();

            string filePath = "C:\\Users\\GSIAD-031\\Desktop\\New Text Document.txt";

            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    // The file is not in use, so it can be safely deleted
                    File.Delete(filePath);
                }
            }
            catch (IOException ex)
            {
                // The file is in use, so it cannot be deleted
                // Handle the exception here, such as logging it or displaying a message to the user
            }
        }

        private static void DeleteFunction()
        {
            try
            {
                string directoryPath = "C:\\Users\\GSIAD-031\\Desktop\\delfolder - Copy";

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
            catch (System.Exception objException)
            {
                //Delete();
                Console.WriteLine(objException.Message);
                Console.WriteLine(objException.StackTrace);
                Console.ReadKey();
            }
        }
    }
}
