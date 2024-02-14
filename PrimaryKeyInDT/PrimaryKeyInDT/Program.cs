using System;
using System.Data;

namespace PrimaryKeyInDT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("name");

            dt.Rows.Add("1", "aa");
            dt.Rows.Add("2", "bb");

            dt2.Columns.Add("id");
            dt2.Columns.Add("dept");

            dt2.Rows.Add("1", "xx");
            dt2.Rows.Add("2", "yy");

            dt2.PrimaryKey = new DataColumn[] { dt2.Columns["id"] };

            dt.Merge(dt2);
        }
    }
}
