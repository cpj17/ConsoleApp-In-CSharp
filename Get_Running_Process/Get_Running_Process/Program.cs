using System;
using System.Diagnostics;

namespace Get_Running_Process
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] processCollection = Process.GetProcesses();
            //Get All Running Process Name
            //foreach (Process p in processCollection)
            //{
            //    Console.WriteLine(p.ProcessName);
            //}

            //Check Particular Process Are Running Or Not
            Process[] pname = Process.GetProcessesByName("notepad");
            if (pname.Length == 0)
                Console.WriteLine(0);
            else
                Console.WriteLine(1);

            Console.Read();
        }
    }
}
