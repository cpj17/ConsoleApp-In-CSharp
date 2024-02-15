using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Test_62
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable objDataTableMarks = new DataTable();
            objDataTableMarks.Columns.Add("Mark1", typeof(Int32));
            objDataTableMarks.Columns.Add("Mark2", typeof(Int32));
            objDataTableMarks.TableName = "Table";

            //Detached
            DataRow objDataRow = objDataTableMarks.NewRow();
            Console.WriteLine(objDataRow.RowState);
            
            //Added
            objDataTableMarks.Rows.Add(objDataRow);
            Console.WriteLine(objDataRow.RowState);
            objDataTableMarks.AcceptChanges();

            //UnChange
            Console.WriteLine(objDataRow.RowState);

            //Add Values
            objDataRow[0] = 100;
            Console.WriteLine(objDataRow.RowState);

            //objDataTableMarks.AcceptChanges();
            objDataTableMarks.ImportRow(objDataRow);
            Console.WriteLine(objDataTableMarks.Rows[0].RowState);

            //Deleted
            objDataRow.Delete();
            Console.WriteLine(objDataRow.RowState);
        }
    }
}
