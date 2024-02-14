using System;
using System.Diagnostics;

namespace Run_CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            //Open File/EXE
            //var p = new Process();
            //p.StartInfo = new ProcessStartInfo("cmd.exe")
            //{
            //    UseShellExecute = true
            //};
            //p.Start();

            //Open File
            //var p = new Process();
            //p.StartInfo = new ProcessStartInfo("a.txt")
            //{
            //    UseShellExecute = true
            //};
            //p.Start();

            //Run cmd cmmand in here
            Process objProcess = new Process();
            objProcess.StartInfo.FileName = "cmd.exe";
            objProcess.StartInfo.RedirectStandardInput = true;
            //objProcess.StartInfo.CreateNoWindow = true;
            objProcess.Start();
            objProcess.StandardInput.WriteLine("start mspaint.exe");
            objProcess.WaitForExit();
        }
    }
}
