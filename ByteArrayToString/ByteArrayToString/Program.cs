using System;
using System.IO;

namespace ByteArrayToString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "";
            path = "C:\\Users\\GSIAD-031\\Desktop\\a.txt";
            
            byte[] bytes = File.ReadAllBytes(path);
            string byteArrayString = Convert.ToBase64String(bytes);

            //Console.WriteLine(byteArrayString);
            //Console.ReadLine();

            File.WriteAllText("D:/byte.txt", byteArrayString);
        }
    }
}
