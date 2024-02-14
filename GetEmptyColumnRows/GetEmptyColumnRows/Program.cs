using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetEmptyColumnRows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("Search2result.xml");

            DataRow[] emptyRows = ds.Tables[0].AsEnumerable()
                        .Where(row => string.IsNullOrEmpty(row.Field<string>("InvoiceNo")))
                        .Select(row => row)
                        .ToArray();

            DataTable dt = emptyRows.CopyToDataTable();
        }
    }
}
