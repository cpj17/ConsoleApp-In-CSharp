using System;
using System.IO;

namespace ChangeFileAttributes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string filePath = @"C:\Users\GSIAD-031\Desktop\testFol\1d.txt";
            DateTime newModifiedTime = new DateTime(2022, 03, 15, 10, 30, 0); // set the new modified time yyyy, MM, dd, hh, mm, ss. hour is 24h format

            // set the last write time of the file to the new modified time
            File.SetLastWriteTime(filePath, newModifiedTime);  //last modified
            File.SetCreationTime(filePath, newModifiedTime);   //creation time
            File.SetLastAccessTime(filePath, newModifiedTime); //last access time

            //folder
            string folderPath = @"C:\Users\GSIAD-031\Desktop\testFol\1d old 1";
            DateTime newModifiedTime2 = new DateTime(2020, 04, 15, 13, 30, 0); // set the new modified time

            // set the last write time of the folder to the new modified time
            Directory.SetLastWriteTime(folderPath, newModifiedTime2);  //last modified
            Directory.SetCreationTime(folderPath, newModifiedTime2);   //creation time
            Directory.SetLastAccessTime(folderPath, newModifiedTime2); //last access time
        }
    }
}
