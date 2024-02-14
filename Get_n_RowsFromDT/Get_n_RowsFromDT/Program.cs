using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_n_RowsFromDT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();

            dt.Columns.Add("col1");
            dt.Columns.Add("col2");
            dt.Columns.Add("col3");

            dt.Rows.Add("11", "12", "13");
            dt.Rows.Add("21", "22", "23");
            dt.Rows.Add("31", "32", "33");
            dt.Rows.Add("41", "42", "43");
            dt.Rows.Add("51", "52", "53");

            //dt2 = dt.Rows.Cast<System.Data.DataRow>().Take(2).CopyToDataTable();

            int pageNum = 3;
            int pageSize = 2;

            DataTable dtPage = dt.Rows.Cast<System.Data.DataRow>().Skip((pageNum - 1) * pageSize).Take(pageSize).CopyToDataTable();
        }
    }
}
