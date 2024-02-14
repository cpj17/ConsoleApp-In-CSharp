using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Threading.Tasks;

namespace Test_54
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mark1", typeof(Int32));
            dt.Columns.Add("Mark2", typeof(Int32));
            dt.TableName = "Table";

            //Add rows
            DataRow dr = dt.NewRow();
            dr["Mark1"] = 30;
            dr["Mark2"] = 50;
            dt.Rows.Add(dr);

            DataColumn col = new DataColumn();
            col.DataType = typeof(Int32);
            col.Expression = "Mark1 + Mark2";
            col.ColumnName = "Total";
            dt.Columns.Add(col);
            dt.Compute("Sum(Total)","");
        }
    }
}
