using System;
using System.Data;
using System.Linq;

namespace Split_DT_By_tRowCount
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds = new DataSet();
            DataSet ds2 = new DataSet();

            ds.ReadXml("input.xml");
            Split_DT_By_Row_Count(ds.Tables[0]);
        }

        static void Split_DT_By_Row_Count(DataTable dt)
        {
            DataSet ds = new DataSet();
            //Need using System.Linq;
            DataTable[] splittedtables = dt.AsEnumerable()
            .Select((row, index) => new { row, index })
            .GroupBy(x => x.index / 2)  // integer division, the fractional part is truncated
            .Select(g => g.Select(x => x.row).CopyToDataTable())
            .ToArray();

            for (int i = 0; i < splittedtables.Length; i++)
            {
                ds.Tables.Add(splittedtables[i]);
            }
        }
    }
}
