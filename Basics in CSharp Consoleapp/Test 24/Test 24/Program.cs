using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_24
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "New Text Writted From File Operation";
            File.WriteAllText("newFile.txt",str);
            Console.WriteLine("OK");
            string word = File.ReadAllText("newFile.txt");
            string[] arr = word.Split(' ');
            foreach (string i in arr)
            {
                Console.WriteLine(i);
            }
        }
    }
}
