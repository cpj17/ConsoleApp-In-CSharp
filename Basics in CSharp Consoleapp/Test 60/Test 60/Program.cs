using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Test_60
{
    class Program
    {
        
        //Check Username Exist or not
        static Int32 checkUsername(DataSet objDataSetUser, string username)
        {
            objDataSetUser.ReadXml("userData.xml",XmlReadMode.Auto);
            DataRow[] dataRow = objDataSetUser.Tables[0].Select("Username='" + username + "'");
            Int32 count = dataRow.Count();
            objDataSetUser.Clear();
            return count;
        }
        //Create Account Method
        static void createAcc(DataSet objDataSetUser)
        {
            Console.WriteLine("\nEnter Your Name");
            var name = Console.ReadLine();
            var username = "";
            while (true)
            {
                Console.WriteLine("Enter UserName");
                username = Console.ReadLine();
                if (checkUsername(objDataSetUser, username) > 0)
                    Console.WriteLine("Username Exists Choose new one....");
                else
                    break;
            }

            Console.WriteLine("Enter Your Password");
            var password = Console.ReadLine();
            objDataSetUser.ReadXml("userData.xml", XmlReadMode.Auto);
            objDataSetUser.Tables[0].Rows.Add(name, username, password);

            objDataSetUser.Tables[0].WriteXml("userData.xml", XmlWriteMode.WriteSchema);
            Console.WriteLine("Account Created Successfully");
            objDataSetUser.Clear();

        }
        //Login Method
        static void login(DataSet objDataSetUser)
        {
            var username = "";
            while (true)
            {
                Console.WriteLine("Enter UserName");
                username = Console.ReadLine();

                if (checkUsername(objDataSetUser, username) == 0)
                    Console.WriteLine("Username does not exist....");
                else
                    break;
            }

            Console.WriteLine("Enter Your Password");
            var password = Console.ReadLine();

            objDataSetUser.ReadXml("userData.xml", XmlReadMode.Auto);
            DataRow[] objDataRowUsers = objDataSetUser.Tables[0].Select("Username='" + username + "'");
            if (objDataRowUsers[0]["Password"].ToString() == password)
            {
                //To check user log file is there or not
                if(File.Exists("userLog.xml"))
                    objDataSetUser.ReadXml("userLog.xml");
                else  //If user doesnt exist
                {
                    //Create DataTable and coluumn for user log
                    DataTable objDataTableUserLog = new DataTable("UserLog_DataTable");
                    objDataTableUserLog.Columns.Add("Username",typeof(string));
                    objDataTableUserLog.Columns.Add("TimeStamp", typeof(DateTime));
                    objDataTableUserLog.Columns.Add("SessionId", typeof(Int64));

                    //Add table to dataset and write xml
                    objDataSetUser.Tables.Add(objDataTableUserLog);
                    objDataSetUser.Tables[1].WriteXml("userLog.xml");
                }
                DateTime objDateTime = DateTime.Now;
                Int64 objIntSessionId = Convert.ToInt64(objDateTime.Day.ToString() + objDateTime.Month.ToString() + objDateTime.Year.ToString() + objDateTime.Hour.ToString() + objDateTime.Minute.ToString() + objDateTime.Second.ToString());
                //Console.WriteLine(objIntSessionId);

                objDataSetUser.Tables[1].Rows.Add(username, objDateTime, objIntSessionId);
                //If userlog exist then xml code appended
                objDataSetUser.Tables[1].WriteXml("userLog.xml", XmlWriteMode.WriteSchema);

                Console.WriteLine("Welcome " + objDataRowUsers[0]["Name"]);
                Console.WriteLine("You're Logged In");

                //User Comments Portion
                if (File.Exists("userComments.xml"))
                    objDataSetUser.ReadXml("userComments.xml");
                else
                {
                    //DataTable for User Comments
                    DataTable objDataTableUserComments = new DataTable("UserComments_DataTable");
                    objDataTableUserComments.Columns.Add("SessionId",typeof(Int64));
                    objDataTableUserComments.Columns.Add("Comments",typeof(string));

                    //Add UserComments DataTable To UserDataSet
                    objDataSetUser.Tables.Add(objDataTableUserComments);

                    //Write UserComments Schema in XML File
                    objDataSetUser.Tables[2].WriteXml("userComments.xml",XmlWriteMode.WriteSchema);
                }

                //Getting comments from user
                ArrayList objArrayListUserComments = new ArrayList();
                while (true)
                {
                    Console.WriteLine("\nenter your comment");
                    objArrayListUserComments.Add(Console.ReadLine());
                    Console.WriteLine("\nIf your comments over pls enter 9 to exit comments or press 0 to again enter comment");
                    Int32 objIntExitValue = Convert.ToInt32(Console.ReadLine());
                    if (objIntExitValue == 9)
                        break;
                }
                
                for (int i = 0; i < objArrayListUserComments.Count; i++)
                {
                    objDataSetUser.Tables[2].Rows.Add(objIntSessionId,objArrayListUserComments[i]);
                    //Console.WriteLine(objArrayListUserComments[i]);
                }
                objDataSetUser.Tables[2].WriteXml("userComments.xml",XmlWriteMode.WriteSchema);
            }
            else
                Console.WriteLine("Invalid Password");
            objDataSetUser.Clear();
        }
        //Login History Method
        static void loginHistory(DataSet objDataSetUser)
        {
            var username = "";
            while (true)
            {
                Console.WriteLine("Enter UserName");
                username = Console.ReadLine();

                if (checkUsername(objDataSetUser, username) == 0)
                    Console.WriteLine("Invalid Username....");
                else
                    break;
            }

            Console.WriteLine("Enter Your Password");
            var password = Console.ReadLine();

            objDataSetUser.ReadXml("userData.xml", XmlReadMode.Auto);
            objDataSetUser.ReadXml("userLog.xml", XmlReadMode.Auto);
            objDataSetUser.ReadXml("userComments.xml", XmlReadMode.Auto);

            DataRow[] objDataRowUser = objDataSetUser.Tables[0].Select("Username='" + username + "'");
            if (objDataRowUser[0]["Password"].ToString() == password)
            {
                DataRow[] objDataRowUserLog = objDataSetUser.Tables[1].Select("Username='" + username + "'");
                Console.WriteLine("\nTotal Logins : " + objDataRowUserLog.Count());

                DataRelation objDataRelation1 = new DataRelation("User_DataRelation1", objDataSetUser.Tables[0].Columns[1], objDataSetUser.Tables[1].Columns[0]);
                DataRelation objDataRelation2 = new DataRelation("User_DataRelation2", objDataSetUser.Tables[1].Columns[2], objDataSetUser.Tables[2].Columns[0]);
                
                //Add DataRelation to the datatable
                objDataSetUser.Relations.Add(objDataRelation1);
                objDataSetUser.Relations.Add(objDataRelation2);

                //DataTable Relations
                //Table 1
                //Parent of Table 2

                //Table 2
                //Parent of Table 3
                //Child of Table 1

                //Table 3
                //Child of Table 2

                DataRow parentRowForTable2, parentRowForTable3;
                foreach (DataRow childRowForTable1 in objDataSetUser.Tables[1].Rows)
                {
                    parentRowForTable2 = childRowForTable1.GetParentRow(objDataRelation1);
                    if (childRowForTable1[0].ToString() == username)
                    {
                        Console.WriteLine("\nTime Stamp = " + childRowForTable1[1]);
                        Int64 objIntSessionId = Convert.ToInt64(childRowForTable1[2]);
                        //Console.WriteLine(objIntSessionId);

                        foreach (DataRow childRowForTable2 in objDataSetUser.Tables[2].Rows)
                        {
                            parentRowForTable3 = childRowForTable2.GetParentRow(objDataRelation2);
                            if (Convert.ToInt64(childRowForTable2[0]) == objIntSessionId)
                                Console.WriteLine("SessionId = " + childRowForTable2[0] + "\t" + childRowForTable2[1]);
                        }
                    }
                }
            }
            else
                Console.WriteLine("Invalid Password");
            objDataSetUser.Relations.Clear();
            objDataSetUser.Clear();
        }

        static void Main(string[] args)
        {
            DataSet objDataSetUser = new DataSet("STudent_DataSet");
            if (File.Exists("userData.xml"))
                objDataSetUser.ReadXml("userData.xml");
            else
            {
                //Data Table And Column Creation, If The File Doesn't Exist
                DataTable objDataTableUser = new DataTable("User_DataTable");
                objDataTableUser.Columns.Add("Name", typeof(string));
                objDataTableUser.Columns.Add("Username", typeof(string));
                objDataTableUser.Columns.Add("Password", typeof(string));

                //Add DataTable To DataSet And Write XML
                objDataSetUser.Tables.Add(objDataTableUser);
                objDataTableUser.WriteXml("userData.xml",XmlWriteMode.WriteSchema);
            }

            var objIntChoice = 0;
            do
            {
                try
                {
                    Console.WriteLine("\n1. Create Account");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. View LogIn History");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("Enter your chioce");
                    objIntChoice = Convert.ToInt32(Console.ReadLine());

                    switch (objIntChoice)
                    {
                        case 1:
                            createAcc(objDataSetUser);
                            break;
                        case 2:
                            login(objDataSetUser);
                            break;
                        case 3:
                            loginHistory(objDataSetUser);
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Enter Valid Choice");
                            break;
                    }
                }
                catch (Exception objException)
                {
                    Console.WriteLine("Error : " + objException.Message);
                }
            } while (objIntChoice != 4);
        }
    }
}
