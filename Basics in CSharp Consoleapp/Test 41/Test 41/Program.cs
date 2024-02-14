using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Test_41
{
    class Program
    {
        static void Main(string[] args)
        {
            //DataTable Creation
            DataTable objDataTableStudent = new DataTable("objDataTableStudent");
            //Adding Columns
            DataColumn objDataColumnStudentID = new DataColumn("ID", typeof(Int32));
            objDataTableStudent.Columns.Add(objDataColumnStudentID);
            DataColumn objDataColumnStudentName = new DataColumn("Name", typeof(string));
            objDataTableStudent.Columns.Add(objDataColumnStudentName);
            DataColumn objDataColumnStudentDept = new DataColumn("Department", typeof(string));
            objDataTableStudent.Columns.Add(objDataColumnStudentDept);

            //Adding Rows
            objDataTableStudent.Rows.Add(101, "Praveen", "CSE");
            objDataTableStudent.Rows.Add(102, "Jeeva", "ECE");

            //Create Student DataSEt
            DataSet objDataSetStudent = new DataSet();

            //Add DataTables To DataSet
            objDataSetStudent.Tables.Add(objDataTableStudent);

            //View DataSet
            foreach (DataRow row in objDataSetStudent.Tables["objDataTableStudent"].Rows)
            {
                Console.WriteLine(row["ID"]+"\t"+row["Name"]+"\t\t"+row["Department"]);
            }
        }
    }
}
