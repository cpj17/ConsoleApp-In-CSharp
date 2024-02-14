using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Xml;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Test_59
{
    class Program
    {
        static Int32 checkUsername(DataSet objDataSetUser, string username)
        {
            DataRow[] dataRow = objDataSetUser.Tables[0].Select("Username='" + username + "'");
            Int32 count = dataRow.Count();
            objDataSetUser.Clear();
            return count;
        }
        static void createAcc(DataSet objDataSetUser)
        {
            objDataSetUser.ReadXml("userData.xml",XmlReadMode.Auto);

            Console.WriteLine("\nEnter Your Name");
            var name = Console.ReadLine();
            var username = "";
            bool usernameFlag = true;
            while (usernameFlag)
            {
                Console.WriteLine("Enter UserName");
                username = Console.ReadLine();
                if (checkUsername(objDataSetUser, username) > 0)
                    Console.WriteLine("Username Exists Choose new one....");
                else
                    usernameFlag = false;
            }
            
            Console.WriteLine("Enter Your Password");
            var password = Console.ReadLine();
            objDataSetUser.ReadXml("userData.xml", XmlReadMode.Auto);
            objDataSetUser.Tables[0].Rows.Add(name, username, password);

            objDataSetUser.Tables[0].WriteXml("userData.xml",XmlWriteMode.WriteSchema);
            Console.WriteLine("Account Created Successfully");
            objDataSetUser.Clear();

        }
        static void login(DataSet objDataSetUser)
        {
            var username = "";
            bool usernameFlag = true;
            while (usernameFlag)
            {
                Console.WriteLine("Enter UserName");
                username = Console.ReadLine();
                
                if (checkUsername(objDataSetUser, username) == 0)
                    Console.WriteLine("Invalid Username....");
                else
                    usernameFlag = false;
            }

            Console.WriteLine("Enter Your Password");
            var password = Console.ReadLine();

            objDataSetUser.ReadXml("userData.xml",XmlReadMode.Auto);
            DataRow[] objDataRowUser = objDataSetUser.Tables[0].Select("Username='"+ username +"'");
            if (objDataRowUser[0]["Password"].ToString() == password)
            {
                objDataSetUser.ReadXml("userLog.xml");
                DateTime currentTime = DateTime.Now;
                objDataSetUser.Tables[1].Rows.Add(username, currentTime);

                //Console.WriteLine(objDataSetUser.Tables.Count);
                objDataSetUser.Tables[1].WriteXml("userLog.xml", XmlWriteMode.WriteSchema);

                Console.WriteLine("Welcome " + objDataRowUser[0]["Name"]);
                Console.WriteLine("You're Logged In");
                objDataSetUser.Clear();
            }
            else
                Console.WriteLine("Invalid Password");
        }
        static void loginHistory(DataSet objDataSetUser)
        {
            //DataRow[] dataRow = objDataSetUser.Tables[1].Select("Username='" + username + "'");
            //Console.WriteLine(dataRow.Count());

            var username = "";
            bool usernameFlag = true;
            while (usernameFlag)
            {
                Console.WriteLine("Enter UserName");
                username = Console.ReadLine();

                if (checkUsername(objDataSetUser, username) == 0)
                    Console.WriteLine("Invalid Username....");
                else
                    usernameFlag = false;
            }

            Console.WriteLine("Enter Your Password");
            var password = Console.ReadLine();

            objDataSetUser.ReadXml("userData.xml", XmlReadMode.Auto);
            objDataSetUser.ReadXml("userLog.xml", XmlReadMode.Auto);

            DataRow[] objDataRowUser = objDataSetUser.Tables[0].Select("Username='" + username + "'");
            if (objDataRowUser[0]["Password"].ToString() == password)
            {
                DataRow[] objDataRowUserLog = objDataSetUser.Tables[1].Select("Username='" + username + "'");
                Console.WriteLine("\nTotal Logins : "+objDataRowUserLog.Count());

                DataRelation objDataRelation = new DataRelation("User_DataRelation", objDataSetUser.Tables[0].Columns[1], objDataSetUser.Tables[1].Columns[0]);
                
                objDataSetUser.Relations.Add(objDataRelation);
                
                DataRow parentRow;
                foreach (DataRow childRow in objDataSetUser.Tables[1].Rows)
                {
                    parentRow = childRow.GetParentRow(objDataRelation);
                    //Console.WriteLine(childRow[1]);
                    if (childRow[0].ToString() == username)
                        Console.WriteLine("Time Stamp = "+childRow[1]);
                }
            }
            else
                Console.WriteLine("Invalid Password");
            objDataSetUser.Relations.Clear();
            objDataSetUser.Clear();
        }
        static void Main(string[] args)
        {
            DataSet objDataSetUser = new DataSet("User_DataSet");

            //Add Table To DataSet
            objDataSetUser.ReadXml("userData.xml");

            var choice = 0;
            do
            {
                try
                {
                    Console.WriteLine("\n1. Create Account");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. View LogIn History");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("Enter your chioce");
                    choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
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
                catch(Exception e)
                {
                   Console.WriteLine("Error : "+e.Message);
                }
            } while (choice != 4);
        }
    }
}
