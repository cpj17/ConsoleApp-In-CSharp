using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Test_57
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Id", typeof(Int32));
            dt1.Columns.Add("Name", typeof(string));
            dt1.TableName = "Table";

            //Add rows
            DataRow dr = dt1.NewRow();
            dr["Id"] = 30;
            dr["Name"] = "cpj";
            dt1.Rows.Add(dr);

            dr = dt1.NewRow();
            dr["Id"] = 12;
            dr["Name"] = "cpj 2";
            dt1.Rows.Add(dr);

            DataTable dt2 = new DataTable("Table 2");
            dt2.Columns.Add("Id", typeof(Int32));
            dt2.Columns.Add("ClgName", typeof(string));

            dt2.Rows.Add(30,"PCT");
            dt2.Rows.Add(12, "PCT2");

            DataSet ds = new DataSet();
            ds.Tables.Add(dt1);
            ds.Tables.Add(dt2);
            
            DataRelation objDr = new DataRelation("new r",dt1.Columns[0],dt2.Columns[0]);
            
            ds.Relations.Add(objDr);
            DataRow parentRow;
            foreach (DataRow row in dt2.Rows)
            {
                parentRow = row.GetParentRow(objDr);
                Console.WriteLine("table child row: " + row[1]);
                //Console.WriteLine("table parent row: " + parentRow[1]);
                Console.Write("table parent row: " + parentRow[1] + "\n");
            }
            //Console.WriteLine(ds.GetXml());
        }
    }
}
