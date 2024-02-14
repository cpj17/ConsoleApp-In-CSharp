using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunScript
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Open File
            var p = new Process();

            Process.Start("C:/Users/GSIAD-031/Desktop/a.txt");

            //p.StartInfo = new ProcessStartInfo("C:/Users/GSIAD-031/Desktop/a.vbs")
            //{
            //    //UseShellExecute = true
            //    UseShellExecute = false
            //};
            //p.Start();
        }
    }
}
