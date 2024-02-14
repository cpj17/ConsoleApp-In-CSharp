using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_26
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            ArrayList list = new ArrayList();
            do
            {
                //list.Add(1);
                var rnd_num = rnd.Next(1, 9);
                var flag = list.Contains(rnd_num);
                if (flag == false)
                {
                    list.Add(rnd_num);
                }
            } while (list.Count != 6);
            foreach(var j in list)
              Console.Write(j+"\t");
        }
    }
}
