using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileToByteString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            path = @"C:\Users\GSIAD-031\Desktop\";
            byte[] bytes = File.ReadAllBytes(path + "a.mp4");

            //string byteString = Convert.ToBase64String(bytes);
            //string byteString = Encoding.UTF8.GetString(bytes);

            //int count = 10500000; //10MB
            ////int count = 110500000; //

            //List<string> stringList = new List<string>();
            //for (int i = 0; i < byteString.Length; i += count)
            //{
            //    int length = Math.Min(count, byteString.Length - i);
            //    string substring = byteString.Substring(i, length);
            //    stringList.Add(substring);
            //}

            //for (int i = 0; i < stringList.Count; i++)
            //{
            //    File.WriteAllText(path + "/out/" + i + ".txt", stringList[i]);
            //}

            //test codes (begins)
            string str = @"C:\Users\GSIAD-031\Desktop\a.mp4";
            int chunkSizeInBytes = 0;
            int OneMBInBytes = 1048576;

            chunkSizeInBytes = 3 * OneMBInBytes;

            string des = @"C:\Users\GSIAD-031\Desktop\out";
            //SplitFile(str, des, chunkSizeInBytes);

            string[] arr = Directory.GetFiles(@"C:\Users\GSIAD-031\Desktop\out");
            string output = @"C:\Users\GSIAD-031\Desktop\res2.mp4";
            CombineFiles(arr, output);
            //test codes (ends)
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
                    //string chunkFilePath = Path.Combine(destinationDirectory, $"Chunk{(fileCount + 1).ToString("d8")}.dat");

                    //using (FileStream chunkFile = File.Create(chunkFilePath))
                    //{
                    //    chunkFile.Write(buffer, 0, bytesRead);
                    //}

                    string str = Convert.ToBase64String(buffer);
                    File.WriteAllText(destinationDirectory + "/file_" + fileCount.ToString("d8") + ".txt", str);

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
