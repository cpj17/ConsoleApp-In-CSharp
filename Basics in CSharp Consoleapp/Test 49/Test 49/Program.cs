using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Threading.Tasks;

namespace Test_49
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable objDataTableStud = new DataTable("Student Table");

            DataColumn objDataColumnStudId = new DataColumn("ID",typeof(Int32));
            DataColumn objDataColumnStudName = new DataColumn("Name", typeof(string));

            objDataTableStud.Columns.Add(objDataColumnStudId);
            objDataTableStud.Columns.Add(objDataColumnStudName);

            objDataTableStud.Rows.Add(11, "cpj1");
            objDataTableStud.Rows.Add(12, "cpj2");

            Console.WriteLine(objDataTableStud.Rows[1].RowState);
            DataRow[] row = objDataTableStud.Select("ID='11'");
            row[0]["ID"] = "101";
            Console.WriteLine(objDataTableStud.Rows[1].RowState);

            //Console.WriteLine(objDataSet.Tables[0].Rows[2].RowState);
            /*for (int i = 0; i < objDataSet.Tables[0].Rows.Count; i++)
            {
                Console.WriteLine("Row {0} State : {1}",(i),(objDataSet.Tables[0].Rows[i].RowState));
            }*/
        }
    }
}
