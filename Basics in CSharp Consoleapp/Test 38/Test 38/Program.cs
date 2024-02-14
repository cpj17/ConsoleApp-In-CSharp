using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_38
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:/WorkFolder/PRAVEEN JEEVA/Test/textFile.txt";
            if (File.Exists(path))
                File.Delete(path);
            File.WriteAllText(path,"test");
        }
    }
}
