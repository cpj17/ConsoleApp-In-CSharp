using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Test_43
{
    class Program
    {
        static void viewData(DataRow objRow)
        {
            Console.WriteLine(objRow["ID"]);
        }
        static void addData(DataRow objRow)
        {
            //DataRow row = objDataSetEmp.Tables[0].Rows[1];
            //Console.WriteLine(row["ID"]);
        }
        static void deleteData(DataRow objRow)
        {
           // DataRow row = objDataSetEmp.Tables[0].Rows[1];
            //Console.WriteLine(row["ID"]);
        }
        static void Main(string[] args)
        {
            //Create DataTable
            DataTable objDataTableEmp = new DataTable("objDataTableEmp");

            //Create Schema
            DataColumn objDataColumnEmpID = new DataColumn("ID", typeof(Int32));
            DataColumn objDataColumnEmpName = new DataColumn("Name", typeof(string));
            DataColumn objDataColumnEmpAge = new DataColumn("Age", typeof(Int32));

            //Add Column to data table
            objDataTableEmp.Columns.Add(objDataColumnEmpID);
            objDataTableEmp.Columns.Add(objDataColumnEmpName);
            objDataTableEmp.Columns.Add(objDataColumnEmpAge);

            //Add Data's to Data Table
            objDataTableEmp.Rows.Add(111,"Raja",20);
            objDataTableEmp.Rows.Add(112, "Ram", 22);
            objDataTableEmp.Rows.Add(113, "Ravi", 25);

            //Create DataSet
            DataSet objDataSetEmp = new DataSet();

            //Add table to dataset
            objDataSetEmp.Tables.Add(objDataTableEmp);
            
            //View Data's
            DataRow row = objDataSetEmp.Tables[0].Rows[1];
            
            var choice = 0;
            do
            {
                Console.WriteLine("1. View Data's");
                Console.WriteLine("2. Add Data");
                Console.WriteLine("3. Delete Data");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice....");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        viewData(row);
                        break;
                    case 2:
                        addData(row);
                        break;
                    case 3:
                        deleteData(row);
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter Valid Choice...");
                        break;
                }
            } while (choice != 3);
        }
    }
}
