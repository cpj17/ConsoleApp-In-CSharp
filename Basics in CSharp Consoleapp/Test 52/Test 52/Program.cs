using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Threading.Tasks;

namespace Test_52
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt1.Columns.Add("ID", typeof(Int32));
            dt1.Columns.Add("Name", typeof(string));
            dt1.Columns.Add("Dept", typeof(string));


            //DS2 Create Column
            dt2.Columns.Add("ID", typeof(Int32));
            dt2.Columns.Add("Name", typeof(string));
            dt2.Columns.Add("Dept", typeof(string));

            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            ds1.Tables.Add(dt1);
            ds2.Tables.Add(dt2);

            ds1.Tables[0].Rows.Add(11, "ds1 name 1", "ds1 dept 1");
            ds1.Tables[0].Rows.Add(12, "ds1 name 2", "ds1 dept 2");
            ds1.Tables[0].Rows.Add(13, "ds1 name 3", "ds1 dept 3");

            ds2.Tables[0].Rows.Add(11, "ds2 clg 1","new");
            ds2.Tables[0].Rows.Add(222, "ds2 clg 2", "new 22");

            // primary keys must be set in order for the merge to work
            //ds1.Tables[0].PrimaryKey = new DataColumn[] { ds1.Tables[0].Columns["ID"] };
            //ds2.Tables[0].PrimaryKey = new DataColumn[] { ds2.Tables[0].Columns["ID"] };

            //Console.WriteLine(ds1.Tables[0].Rows.Count);
            //DataRow row = ds1.Tables[0].NewRow();
            //row["Name"] = 2;
            //ds1.Tables[0].Rows.Add(row);

            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                ds1.Tables[0].ImportRow(dr);
            }

            //Console.WriteLine(ds1.Tables[0].Rows.Count);
            string ds1Str = ds1.GetXml();
            Console.WriteLine(ds1Str);
        }
    }
}
