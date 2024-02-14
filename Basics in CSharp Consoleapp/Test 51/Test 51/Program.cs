using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Threading.Tasks;

namespace Test_51
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
            dt1.Columns.Add("Dept2", typeof(string));
            dt1.Columns.Add("Dept3", typeof(string));
            dt1.Columns.Add("Dept4", typeof(string));
            dt1.Columns.Add("Dept5", typeof(string));
            dt1.Columns.Add("Dept6", typeof(string));
            dt1.Columns.Add("Dept7", typeof(string));
            dt1.Columns.Add("Dept8", typeof(string));
            dt1.Columns.Add("Dept9", typeof(string));
            dt1.Columns.Add("Dept10", typeof(string));

            dt2.Columns.Add("ID", typeof(Int32));
            dt2.Columns.Add("Clg", typeof(string));

            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();

            ds1.Tables.Add(dt1);
            ds2.Tables.Add(dt2);

            ds1.Tables[0].Rows.Add(11, "ds1 name 1", "ds1 dept 1", "added 1", "added 2", "added 3", "added 4", "added 5", "added 6", "added 7", "added 8");
            ds1.Tables[0].Rows.Add(12, "ds1 name 2", "ds1 dept 2", "added 1", "added 2", "added 3", "added 4", "added 5", "added 6", "added 7", "added 8");
            ds1.Tables[0].Rows.Add(13, "ds1 name 3", "ds1 dept 3", "added 1", "added 2", "added 3", "added 4", "added 5", "added 6", "added 7", "added 8");

            ds2.Tables[0].Rows.Add(11, "ds2 clg 1");
            ds2.Tables[0].Rows.Add(22, "ds2 clg 2");

            // primary keys must be set in order for the merge to work
            //ds1.Tables[0].PrimaryKey = new DataColumn[] { ds1.Tables[0].Columns["ID"] };
            //ds2.Tables[0].PrimaryKey = new DataColumn[] { ds2.Tables[0].Columns["ID"] };

            //Console.WriteLine(ds1.Tables[0].Rows.Count);
            DataRow row = ds1.Tables[0].NewRow();
            row["Name"] = 2;
            ds1.Tables[0].Rows.Add(row);
            //Console.WriteLine(ds1.Tables[0].Rows.Count);
            string ds1Str = ds1.GetXml();
            Console.WriteLine(ds1Str);
        }
    }
}
