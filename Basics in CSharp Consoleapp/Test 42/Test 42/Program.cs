using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Test_42
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create DataTable
            DataTable objDataTableStaff = new DataTable("objDataTableStaff");

            //Create DataColumns
            DataColumn objDataColumnStaffID = new DataColumn("ID", typeof(Int32));
            DataColumn objDataColumnStaffName = new DataColumn("Name", typeof(string));
            DataColumn objDataColumnStaffDept = new DataColumn("Dept", typeof(string));

            //Adding Columns To DataTable
            objDataTableStaff.Columns.Add(objDataColumnStaffID);
            objDataTableStaff.Columns.Add(objDataColumnStaffName);
            objDataTableStaff.Columns.Add(objDataColumnStaffDept);

            //Adding Rows To DataTable
            objDataTableStaff.Rows.Add(501, "Jeeva", "CSE");
            objDataTableStaff.Rows.Add(502, "Praveen", "ECE");

            //Create DataSet
            DataSet objDataSetStaff = new DataSet();

            //Add DataTable to DataSet
            objDataSetStaff.Tables.Add(objDataTableStaff);

            //View Data's
            foreach (DataColumn column in objDataSetStaff.Tables[0].Columns)
            {
                Console.Write(column.ColumnName+"\t");
            }
            Console.WriteLine();
            foreach (DataRow row in objDataSetStaff.Tables["objDataTableStaff"].Rows)
            {
                Console.WriteLine(row["ID"]+"\t"+row["name"]+"\t"+row["Dept"]);
            }
            objDataSetStaff.WriteXml("newFil.xml",XmlWriteMode.WriteSchema);
            //objDataSetStaff = null;
            //objDataSetStaff = new DataSet();
            //objDataSetStaff.ReadXml("newFil.xml", XmlReadMode.Auto);
            //objDataSetStaff.Tables[0].Rows.Add(503, "Praveen22", "ECE22");
            
            //DataRow[] objDataRow = objDataSetStaff.Tables[0].Select("ID='502'");
            //Console.WriteLine(objDataRow[0][2]);
            ////objDataSetStaff.Tables[0].Rows[1].Delete();
            //objDataSetStaff.WriteXml("newFil.xml", XmlWriteMode.WriteSchema);
        }
    }
}
