using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortInDT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("col1");
            dt.Columns.Add("col2");
            dt.Columns.Add("col3");

            dt.Rows.Add("11", "12", "13");
            dt.Rows.Add("21", "22", "23");
            dt.Rows.Add("31", "32", "33");
            dt.Rows.Add("41", "42", "43");

            DataView dv = new DataView();
            dv = dt.DefaultView;
            dv.Sort = "col1 DESC";
            dt = dv.ToTable();

        }
    }
}
