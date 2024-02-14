using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Test_55
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

            //dt.RejectChanges();
            Console.WriteLine(dt.Rows[0].RowState);
            dt.AcceptChanges();
            Console.WriteLine(dt.Rows[0].RowState);
            DataRow[] row = dt.Select("Mark1=30");
            row[0]["Mark1"] = 100;
            dt.Rows.Add(55,66);
            Console.WriteLine(dt.Rows[0].RowState);
            
        }
    }
}
