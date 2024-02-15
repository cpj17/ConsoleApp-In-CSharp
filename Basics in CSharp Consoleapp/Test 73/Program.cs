using System;
using System.Data;

namespace Test_73
{
    class Program
    {
        static void Main(string[] args)
        {
            string url;
            url = "UserId,1,UserName,Satinder Singh,Education,Bsc Com Sci,Location,Mumbai";

            DataTable dt = new DataTable();
            dt.Columns.Add("UserId", typeof(Int32));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Education", typeof(string));
            dt.Columns.Add("Location", typeof(string));

            string[] datalist = url.Split(",");
            //Console.WriteLine(datalist.Length);
            
            for(int i=0;i< datalist.Length; i+=2)
            {
                //Console.WriteLine(datalist[i]);
                //Console.WriteLine(datalist[i+1]);
            }
            
            //Console.WriteLine(datalist[1]);
            //Console.WriteLine(datalist[3]);
            //Console.WriteLine(datalist[5]);
            //Console.WriteLine(datalist[7]);

            dt.Rows.Add(datalist[1], datalist[3], datalist[5], datalist[7]);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.Tables[0].WriteXml("test.xml");
        }
    }
}
