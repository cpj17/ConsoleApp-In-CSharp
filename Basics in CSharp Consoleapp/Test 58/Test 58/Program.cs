using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Test_58
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataTable Creation
            DataTable dtStudData1 = new DataTable("Student Data 1");

            //Data Column Creation And Added
            dtStudData1.Columns.Add("Id",typeof(Int32));
            dtStudData1.Columns.Add("Name", typeof(string));
            dtStudData1.Columns.Add("Dept", typeof(string));

            //Data Row And Values Added to Data Table
            dtStudData1.Rows.Add(101,"Praveen","CSE");
            dtStudData1.Rows.Add(102, "Jeeva", "ECE");
            dtStudData1.Rows.Add(103, "CPJ", "IT");

            //Data Table 2 For Other Student Details
            DataTable dtStudData2 = new DataTable("Student Data Others");

            //DataTable 2 Columns
            dtStudData2.Columns.Add("Id",typeof(Int32));
            dtStudData2.Columns.Add("Place", typeof(string));
            dtStudData2.Columns.Add("District", typeof(string));

            //DataTable 2 Rows
            dtStudData2.Rows.Add(101,"Valai","NKL");
            dtStudData2.Rows.Add(102, "Rasipuram", "KAR");
            dtStudData2.Rows.Add(103, "Pachal", "CHE");
            //dtStudData2.Rows.Add(104, "Chathiram", "SLM");

            //DataSet Creation
            DataSet dsStud = new DataSet();
            dsStud.Tables.Add(dtStudData1);
            dsStud.Tables.Add(dtStudData2);

            //Relation
            DataRelation drStud = new DataRelation("", dtStudData1.Columns[0], dtStudData2.Columns[0]);
            dsStud.Relations.Add(drStud);

            DataRow parentRow;
            foreach (DataRow childRow in dtStudData2.Rows)
            {
                parentRow = childRow.GetParentRow(drStud);
                Console.WriteLine("Parent Row = "+parentRow[1]);
                Console.WriteLine("Child Row = " + childRow[1]);
            }

        }
    }
}
