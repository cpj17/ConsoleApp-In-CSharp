using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Test_56
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt1 = new DataTable("Table 1");
            dt1.Columns.Add("Id", typeof(Int32));
            dt1.Columns.Add("Name", typeof(string));
            dt1.TableName = "Table";

            //Add rows
            DataRow dr = dt1.NewRow();
            dr["Id"] = 30;
            dr["Name"] = "cpj";
            dt1.Rows.Add(dr);

            DataTable dt2 = new DataTable("Table 2");
            dt2.Columns.Add("Id", typeof(Int32));
            dt2.Columns.Add("ClgName", typeof(string));

            //dt2.Rows.Add(6222,"PCT");

            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            //dt1.PrimaryKey = new DataColumn[] { dt1.Columns[0] };
            DataRelation objDr = new DataRelation("new r",dt1.Columns[0],dt2.Columns[0]);
            
            ds.Relations.Add(objDr);
            //Console.WriteLine(ds.GetXml());

            //Add rows
            dr = dt1.NewRow();
            dr["Id"] = 310;
            dr["Name"] = "cpj";
            dt1.Rows.Add(dr);
            
        }
    }
}
