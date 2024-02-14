using System;
using System.Data;

namespace DistinctRowFromDT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("col1");
            dt.Columns.Add("col2");
            dt.Columns.Add("col3");

            dt.Rows.Add("c11", "c12", "c13");
            dt.Rows.Add("c21", "c22", "c23");
            dt.Rows.Add("c11", "c42", "c13");
            dt.Rows.Add("c31", "c32", "c33");

            DataView objView = new DataView(dt);
            DataTable dt2 = new DataTable();
            //dt2 = objView.ToTable("nt", true, new string[] { "col1", "col3" });
            dt2 = objView.ToTable("nt", true, "col1", "col3");

            DataSet ds = new DataSet();
            ds.Tables.Add(dt2);

        }
    }
}
