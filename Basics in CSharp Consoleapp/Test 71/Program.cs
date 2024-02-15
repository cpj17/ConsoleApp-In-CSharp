using System;
using System.Data;

namespace Test_71
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("userData.xml");
            //var str = ds.GetXml();
            //Console.WriteLine(str);

            //string[] arr = { "Name","Password"};

            foreach (DataColumn column in ds.Tables[0].Columns)
            {
                Console.Write(column.ColumnName + "\t");
            }
            Console.WriteLine();
            DataRow[] dr = ds.Tables[0].Select("Username like '%cpj%'");
            foreach (DataRow row in dr)
            {
                Console.WriteLine(row[0] + "\t" + row[1] + "\t\t" + row[2]);
            }
        }
    }
}
