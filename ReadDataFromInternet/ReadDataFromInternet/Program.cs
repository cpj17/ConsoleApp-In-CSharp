using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace ReadDataFromInternet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string str = File.ReadAllText("http://cpj.epizy.com/text.txt");

            WebClient client = new WebClient();
            Stream stream = client.OpenRead("https://docs.google.com/spreadsheets/d/1Rcy4f3zcb1L7dmuZ-daUj7jEY1k0pDf4Ngh3kdM9cxw/gviz/tq?tqx=out:json&tq&gid=+gid");
            StreamReader reader = new StreamReader(stream);
            string content = reader.ReadToEnd();


            String[] spearator = { "rows"};
            Int32 count = 2;

            String[] strlist = content.Split(spearator, count, StringSplitOptions.RemoveEmptyEntries);
            string[] list = strlist[1].Split(',');
            string str = list[1];
            string[] l2 = str.Split('[');
            string s2 = l2[1].Remove(l2[1].Length - 3, 3);

            //Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(str);
            #region cmts
            //var webRequest = WebRequest.Create(@"http://cpj.epizy.com/index.html");

            //using (var response = webRequest.GetResponse())
            //using (var content = response.GetResponseStream())
            //using (var reader = new StreamReader(content))
            //{
            //    var strContent = reader.ReadToEnd();
            //}

            //WebClient webClient = new WebClient();
            //webClient.DownloadFile("https://docs.google.com/spreadsheets/d/1Rcy4f3zcb1L7dmuZ-daUj7jEY1k0pDf4Ngh3kdM9cxw/gviz/tq?tqx=out:json&tq&gid=+gid", @"D:\myfile.txt");
            #endregion

        }
    }

    public class C
    {
        public string v { get; set; }
    }

    public class Root
    {
        public List<C> c { get; set; }
    }
}
