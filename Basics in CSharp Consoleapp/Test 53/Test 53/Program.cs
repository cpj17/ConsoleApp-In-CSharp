using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Threading.Tasks;

namespace Test_53
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID",typeof(Int32));
            dt.Columns.Add("Name",typeof(string));

            dt.Rows.Add(11,"cpj1");
            dt.Rows.Add(22,"cpj2");
            dt.TableName = "Original Table";

            DataTable dt2 = new DataTable();
            dt2 = dt.Copy();
            dt2.TableName = "After Copy";

            DataTable d3 = new DataTable();
            d3 = dt.Clone();
            d3.TableName = "After Clone";
        }
    }
}
