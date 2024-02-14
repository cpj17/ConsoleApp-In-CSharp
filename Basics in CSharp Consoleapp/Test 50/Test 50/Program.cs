using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Threading.Tasks;

namespace Test_50
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt1.Columns.Add("ID",typeof(Int32));
            dt1.Columns.Add("Name", typeof(string));
            dt1.Columns.Add("Dept", typeof(string));

            dt2.Columns.Add("ID", typeof(Int32));
            dt2.Columns.Add("Clg", typeof(string));

            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            ds1.Tables.Add(dt1);
            ds2.Tables.Add(dt2);

            ds1.Tables[0].Rows.Add(11,"ds1 name 1","ds1 dept 1");
            ds1.Tables[0].Rows.Add(12, "ds1 name 2", "ds1 dept 2");
            ds1.Tables[0].Rows.Add(13, "ds1 name 3", "ds1 dept 3");

            ds2.Tables[0].Rows.Add(11,"ds2 clg 1");
            ds2.Tables[0].Rows.Add(22, "ds2 clg 2");

            // primary keys must be set in order for the merge to work
            ds1.Tables[0].PrimaryKey = new DataColumn[] { ds1.Tables[0].Columns["ID"] };
            ds2.Tables[0].PrimaryKey = new DataColumn[] { ds2.Tables[0].Columns["ID"] };

            //Dateset display

            Console.WriteLine("Before Merger DS1");
            string ds1Str = ds1.GetXml();
            Console.WriteLine(ds1Str+"\n");

            Console.WriteLine("Before Merger DS2");
            string ds2Str = ds2.GetXml();
            Console.WriteLine(ds2Str + "\n");

            ds1.Merge(ds2);
            ds2.Merge(ds1);

            Console.WriteLine("DS1 Merge with DS2");
            ds1Str = ds1.GetXml();
            Console.WriteLine(ds1Str + "\n");

            Console.WriteLine("DS2 Merge with DS2");
            ds2Str = ds2.GetXml();
            Console.WriteLine(ds2Str + "\n");
        }
    }
}
