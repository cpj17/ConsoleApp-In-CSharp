using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_39
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "D:/WorkFolder/PRAVEEN JEEVA/Test/textFile.txt";
            string txt = File.ReadAllText(path);
            string[] arr = txt.Split(',');
            ArrayList list = new ArrayList();
            foreach (string item in arr)
                list.Add(item);
            list.Remove("test4");
            //File.WriteAllText(path, "");
            string data = "";
            foreach (string item2 in list)
                data += item2 +",";
            File.WriteAllText(path,data.Remove(data.Length-1,1));
        }
    }
}
