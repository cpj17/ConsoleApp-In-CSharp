using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Xml;

namespace Test_2
{
    class Program
    {
        
        static Int32 checkDob(string dob)
        {
            try
            {
                DateTime today = DateTime.Now;
                DateTime dobMod = Convert.ToDateTime(dob);
                if (dobMod.Year <= today.Year - 17)
                    return 1;
                else
                    return 0;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        static Int32 checkID(DataSet objDataSetStud, Int32 id)
        {
            objDataSetStud.ReadXml("userData.xml", XmlReadMode.Auto);
            DataRow[] dataRow = objDataSetStud.Tables[0].Select("ID='" + id + "'");
            Int32 count = dataRow.Count();
            objDataSetStud.Clear();
            return count;
        }
        static void addData(DataSet objDataSetStud, string name, Int32 id, string dept, string email, Int32 ph, Int32 yop, string dob, string gender)
        {
            //addData(objDataSetStud, id, name, dept, email, ph, yop, dob, gender);
            objDataSetStud.ReadXml("userData.xml", XmlReadMode.Auto);
            objDataSetStud.Tables[0].Rows.Add(name, id, dept, email, ph, yop, dob, gender);
            objDataSetStud.WriteXml("userData.xml", XmlWriteMode.WriteSchema);
            objDataSetStud.Clear();
            Console.WriteLine("Data added successfully\n");
        }

        static void viewData(DataSet objDataSetStud)
        {
            objDataSetStud.ReadXml("userData.xml", XmlReadMode.Auto);
            foreach (DataColumn col in objDataSetStud.Tables[0].Columns)
            {
                Console.Write(col + "\t");
            }
            Console.WriteLine();
            foreach (DataRow row in objDataSetStud.Tables[0].Rows)
            {
                Console.WriteLine(row["Name"] + "\t" + row["Id"] + "\t" + row["Dept"] + "\t" + row["Email"] + "\t" + row["Ph"] + "\t" + row["Yop"] + "\t" + row["Dob"] + "\t" + row["Gender"]);
            }
            Console.WriteLine();
            objDataSetStud.Clear();
        }
        static void deleteData(DataSet objDataSetStud, Int32 id)
        {
            objDataSetStud.ReadXml("userData.xml", XmlReadMode.Auto);
            DataRow[] dataRow = objDataSetStud.Tables[0].Select("ID='" + id + "'");
            dataRow[0].Delete();
            objDataSetStud.WriteXml("userData.xml", XmlWriteMode.WriteSchema);
            objDataSetStud.Clear();
            Console.WriteLine("Data deleted successfully...\n");
        }
        static void updateData(DataSet objDataSetStud, Int32 id)
        {
            objDataSetStud.ReadXml("userData.xml", XmlReadMode.Auto);
            DataRow[] dataRow = objDataSetStud.Tables[0].Select("ID='" + id + "'");
            Console.WriteLine("Hello " + dataRow[0]["Name"]);
            Console.WriteLine("Your old data's");
            foreach (DataColumn col in objDataSetStud.Tables[0].Columns)
            {
                Console.Write(col + "\t");
            }
            Console.WriteLine();
            foreach (DataRow row in dataRow)
            {
                Console.WriteLine(row["Name"] + "\t" + row["Id"] + "\t" + row["Dept"] + "\t" + row["Email"] + "\t" + row["Ph"] + "\t" + row["Yop"] + "\t" + row["Dob"] + "\t" + row["Gender"]);
            }
            Console.WriteLine();
            Console.WriteLine("Enter your new data\n");
            Console.WriteLine("Enter Name");
            var name = Console.ReadLine();
            id = 0;
            bool idFlag = true;
            while (idFlag)
            {
                Console.WriteLine("Enter Id");
                id = Convert.ToInt32(Console.ReadLine());
                int idVal = checkID(objDataSetStud, id);
                if (idVal == 0)
                    idFlag = false;
                else
                    Console.WriteLine("ID Exists");
            }
            Console.WriteLine("Enter Department");
            var dept = Console.ReadLine();
            var email = "";
            bool emailFlag = true;
            while (emailFlag)
            {
                Console.WriteLine("Enter email");
                email = Console.ReadLine();
                if (emailValidation(email))
                    emailFlag = false;
                else
                    Console.WriteLine("Please enter valid email");
            }
            Console.WriteLine("Enter ph");
            var ph = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter yop");
            var yop = Convert.ToInt32(Console.ReadLine());
            string dob = "00/00/0000";
            bool dobFlag = true;
            while (dobFlag)
            {
                Console.WriteLine("Enter dob like mm/dd/yyyy");
                dob = Console.ReadLine();
                if (checkDob(dob) == 0)
                    Console.WriteLine("You are not eligible / Enter Valid DOB");
                else
                    dobFlag = false;
            }
            Console.WriteLine("Enter gender M / F");
            var gender = Console.ReadLine();

            dataRow[0]["ID"] = id;
            dataRow[0]["Name"] = name;
            dataRow[0]["Dept"] = dept;
            dataRow[0]["Email"] = email;
            dataRow[0]["Ph"] = ph;
            dataRow[0]["Dob"] = dob;
            dataRow[0]["Yop"] = yop;
            dataRow[0]["Gender"] = gender;
            objDataSetStud.WriteXml("userData.xml", XmlWriteMode.WriteSchema);
            Console.WriteLine("Data updated successfully.....\n");
            objDataSetStud.Clear();
        }
        static bool emailValidation(string email)
        {
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            if (Regex.IsMatch(email, pattern))
            {
                //if email is valid
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            //Create DataTabl
            DataTable objDataTableStud = new DataTable("objDataTableStud");

            //Create DataColumn
            DataColumn objDataColumnStudId = new DataColumn("ID", typeof(Int32));
            DataColumn objDataColumnStudName = new DataColumn("Name", typeof(string));
            DataColumn objDataColumnStudPh = new DataColumn("Ph", typeof(Int32));
            DataColumn objDataColumnStudEmail = new DataColumn("Email", typeof(string));
            DataColumn objDataColumnStudDept = new DataColumn("Dept", typeof(string));
            DataColumn objDataColumnStudDob = new DataColumn("Dob", typeof(string));
            DataColumn objDataColumnStudYop = new DataColumn("Yop", typeof(Int32));
            DataColumn objDataColumnStudGender = new DataColumn("Gender", typeof(string));

            //Add Columns To DataTable
            objDataTableStud.Columns.Add(objDataColumnStudName);
            objDataTableStud.Columns.Add(objDataColumnStudId);
            objDataTableStud.Columns.Add(objDataColumnStudDept);
            objDataTableStud.Columns.Add(objDataColumnStudEmail);
            objDataTableStud.Columns.Add(objDataColumnStudPh);
            objDataTableStud.Columns.Add(objDataColumnStudYop);
            objDataTableStud.Columns.Add(objDataColumnStudDob);
            objDataTableStud.Columns.Add(objDataColumnStudGender);

            //Create DataSet
            DataSet objDataSetStud = new DataSet();

            //Add TAble To DataSet
            objDataSetStud.Tables.Add(objDataTableStud);

            var choice = 0;
            do
            {
                Console.WriteLine("1. Add Data");
                Console.WriteLine("2. View Data");
                Console.WriteLine("3. Update Data");
                Console.WriteLine("4. Delete Data");
                Console.WriteLine("5. Exit");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:  //Add Data
                        Console.WriteLine("Enter Name");
                        var name = Console.ReadLine();
                        var id = 0;
                        bool idFlag = true;
                        while (idFlag)
                        {
                            Console.WriteLine("Enter Id");
                            id = Convert.ToInt32(Console.ReadLine());
                            int idVal = checkID(objDataSetStud, id);
                            if (idVal == 0)
                                idFlag = false;
                            else
                                Console.WriteLine("ID Exists");
                        }
                        Console.WriteLine("Enter Department");
                        var dept = Console.ReadLine();
                        var email = "";
                        bool emailFlag = true;
                        while (emailFlag)
                        {
                            Console.WriteLine("Enter email");
                            email = Console.ReadLine();
                            if (emailValidation(email))
                                emailFlag = false;
                            else
                                Console.WriteLine("Please enter valid email");
                        }
                        Console.WriteLine("Enter ph");
                        var ph = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter yop");
                        var yop = Convert.ToInt32(Console.ReadLine());
                        string dob = "00/00/0000";
                        bool dobFlag = true;
                        while (dobFlag)
                        {
                            Console.WriteLine("Enter dob like mm/dd/yyyy");
                            dob = Console.ReadLine();
                            if (checkDob(dob) == 0)
                                Console.WriteLine("You are not eligible / Enter Valid DOB");
                            else
                                dobFlag = false;
                        }
                        Console.WriteLine("Enter gender M / F");
                        var gender = Console.ReadLine();
                        addData(objDataSetStud, name, id, dept, email, ph, yop, dob, gender);
                        break;
                    case 2:  //View Data
                        viewData(objDataSetStud);
                        break;
                    case 3:
                        Console.WriteLine("Enter Id");
                        id = Convert.ToInt32(Console.ReadLine());
                        updateData(objDataSetStud, id);
                        break;
                    case 4:
                        Console.WriteLine("Enter Id");
                        id = Convert.ToInt32(Console.ReadLine());
                        deleteData(objDataSetStud, id);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Enter valid choice");
                        break;
                }
            } while (choice != 5);
        }
    }
}
