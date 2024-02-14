using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitLargerFileIntoSmallPieces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string str = @"C:\Users\GSIAD-031\Desktop\b.mp4";
            Console.WriteLine("input path");
            string str = Console.ReadLine();
            int chunkSizeInBytes = 0;
            int OneMBInBytes = 1048576;
            
            chunkSizeInBytes = 5 * OneMBInBytes;

            //string des = @"C:\Users\GSIAD-031\Desktop\out";
            Console.WriteLine("des path");
            string des = Console.ReadLine();
            SplitFile(str, des, chunkSizeInBytes);

            Console.WriteLine("file splitted now merge started");

            //string[] arr = Directory.GetFiles(@"C:\Users\GSIAD-031\Desktop\out");
            string[] arr = Directory.GetFiles(des);

            //string output = @"C:\Users\GSIAD-031\Desktop\res2.mp4";
            Console.WriteLine("res path");
            string output = Console.ReadLine();
            CombineFiles(arr, output);

            Console.WriteLine("done");
            Console.ReadKey();
        }

        public static void SplitFile(string sourceFilePath, string destinationDirectory, int chunkSizeInBytes)
        {
            using (FileStream sourceFile = File.OpenRead(sourceFilePath))
            {
                byte[] buffer = new byte[chunkSizeInBytes];
                int bytesRead;
                int fileCount = 0;

                while ((bytesRead = sourceFile.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string chunkFilePath = Path.Combine(destinationDirectory, $"Chunk{(fileCount + 1).ToString("d8")}.dat");

                    using (FileStream chunkFile = File.Create(chunkFilePath))
                    {
                        chunkFile.Write(buffer, 0, bytesRead);
                    }

                    fileCount++;
                }
            }
        }

        public static void CombineFiles(string[] splitFilePaths, string destinationFilePath)
        {
            using (FileStream destinationFile = File.Create(destinationFilePath))
            {
                byte[] buffer = new byte[8192];
                int bytesRead;

                foreach (string splitFilePath in splitFilePaths)
                {
                    using (FileStream splitFile = File.OpenRead(splitFilePath))
                    {
                        while ((bytesRead = splitFile.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            destinationFile.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }
    }
}
