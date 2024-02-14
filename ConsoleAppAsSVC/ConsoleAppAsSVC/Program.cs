using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace ConsoleAppAsSVC
{
    internal class Program
    {
        static string LogPath = "C:/Users/GSIAD-031/CPJ/Logs/";
        static string FileName = DateTime.Now.ToString("ddMMyyyy") + "_Log.txt";

        static void Main(string[] args)
        {
            File.AppendAllText(LogPath + FileName, DateTime.Now.ToString("ddMMyyyy HH:mm:ss") + "  SVC Started" + Environment.NewLine);

            while (true)
            {
                Thread.Sleep(3000);
                BackgroundCheckFunction();
            }

        }

        private static void BackgroundCheckFunction()
        {
            try
            {
                Process[] pname = Process.GetProcessesByName("wscript");

                if (pname.Length == 0)
                {
                    if (CheckInternetConnection())
                    {
                        File.AppendAllText(LogPath + FileName, DateTime.Now.ToString("ddMMyyyy HH:mm:ss") + "  Support Script is not running right now. It will start now" + Environment.NewLine);

                        Process.Start("C:/Users/GSIAD-031/CPJ/Scripts/Support.vbe");

                        File.AppendAllText(LogPath + FileName, DateTime.Now.ToString("ddMMyyyy HH:mm:ss") + "  Support Script is now running" + Environment.NewLine);
                    }
                    else
                    {
                        File.AppendAllText(LogPath + FileName, DateTime.Now.ToString("ddMMyyyy HH:mm:ss") + "  Internet is not there" + Environment.NewLine);
                    }
                }

                //Check VBScript shows error msg bcuz it starts in startup but htere is no internet, so now we automatically kill the process then only the above process works well
                if (!CheckInternetConnection() && pname.Length > 0)
                {
                    Thread.Sleep(1000);
                    Process.Start("C:/Users/GSIAD-031/CPJ/Scripts/KillVBScript.cmd");
                }
            }
            catch (Exception objException)
            {
                File.AppendAllText(LogPath + FileName, DateTime.Now.ToString("ddMMyyyy HH:mm:ss") + "  " + objException.ToString() + Environment.NewLine);
            }
        }

        public static bool CheckInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
