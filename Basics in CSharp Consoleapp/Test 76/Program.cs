using System;
using System.Data;

namespace Test_76
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            DataSet ds3 = new DataSet();

            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();

            dt1.Columns.Add("id", typeof(string));
            dt1.Columns.Add("name", typeof(string));
            dt1.Columns.Add("dept", typeof(string));

            dt1.Rows.Add("101","aa","cse");
            dt1.Rows.Add("103","bb","ece");
            dt1.Rows.Add("103","cc","eee");

            dt2.Columns.Add("id", typeof(string));
            dt2.Columns.Add("district", typeof(string));
            dt2.Columns.Add("state", typeof(string));

            dt2.Rows.Add("101", "nkl", "tn");
            dt2.Rows.Add("103", "slm", "tn");
            dt2.Rows.Add("103", "kur", "tn");

            ds1.Tables.Add(dt1);
            ds2.Tables.Add(dt2);

            ds1.Merge(ds2);
        }
    }
}
