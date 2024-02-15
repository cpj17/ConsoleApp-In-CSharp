using System;
using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EncryptionDecryption;

namespace Test_67
{
    public class Program
    {
        //Check Username Exist or not
        static Int32 checkUsername(DataSet objDataSetUser, string stringUsername)
        {
            objDataSetUser.ReadXml("userData.xml", XmlReadMode.Auto);
            DataRow[] dataRow = objDataSetUser.Tables[0].Select("Username='" + stringUsername + "'");
            Int32 int32Count = dataRow.Count();
            objDataSetUser.Clear();
            return int32Count;
        }
        //Create Account Method
        static void createAcc(DataSet objDataSetUser)
        {
            Console.WriteLine("\nEnter Your Name");
            var name = Console.ReadLine();
            string stringUsername = "";
            while (true)
            {
                Console.WriteLine("Enter Username");
                stringUsername = Console.ReadLine();
                if (checkUsername(objDataSetUser, stringUsername) > 0)
                    Console.WriteLine("Username Exists Choose new one....");
                else
                    break;
            }

            Console.WriteLine("Enter Your Password");
            string StringPassword = Console.ReadLine();
            objDataSetUser.ReadXml("userData.xml", XmlReadMode.Auto);

            //Object Creation From clsEncryptionDecryption.cs File
            clsEncryptionDecryption objEncryptDecrypt = new clsEncryptionDecryption();

            objDataSetUser.Tables[0].Rows.Add(name, stringUsername, objEncryptDecrypt.Encrypt(StringPassword));

            objDataSetUser.Tables[0].WriteXml("userData.xml", XmlWriteMode.WriteSchema);
            Console.WriteLine("Account Created Successfully");
            objDataSetUser.Clear();

        }

        //Login Method
        static void login(DataSet objDataSetUser)
        {
            var stringUsername = "";
            while (true)
            {
                Console.WriteLine("Enter Username");
                stringUsername = Console.ReadLine();

                if (checkUsername(objDataSetUser, stringUsername) == 0)
                    Console.WriteLine("Username does not exist....");
                else
                    break;
            }

            objDataSetUser.ReadXml("userData.xml", XmlReadMode.Auto);

            //Object Creation From clsEncryptionDecryption.cs File
            clsEncryptionDecryption objEncryptDecrypt = new clsEncryptionDecryption();
            while (true)
            {
                Console.WriteLine("\nEnter Your Password");
                string StringPassword = Console.ReadLine();

                DataRow[] objDataRowUsers = objDataSetUser.Tables[0].Select("Username='" + stringUsername + "'");
                if (objEncryptDecrypt.Decrypt((objDataRowUsers[0]["Password"].ToString())) == StringPassword)
                {
                    Console.WriteLine("Welcome " + objDataRowUsers[0]["Name"]);
                    Console.WriteLine("You're Logged In");
                    break;
                }
                else
                    Console.WriteLine("Invalid Password");
            }
            objDataSetUser.Clear();
        }
        //Password Reset Method
        static void passwordReset(DataSet objDataSetUser)
        {
            var stringUsername = "";
            while (true)
            {
                Console.WriteLine("Enter Username");
                stringUsername = Console.ReadLine();

                if (checkUsername(objDataSetUser, stringUsername) == 0)
                    Console.WriteLine("Invalid Username....\n");
                else
                    break;
            }

            objDataSetUser.ReadXml("userData.xml", XmlReadMode.Auto);

            //Object Creation For Decryption From clsEncryptionDecryption.cs File
            clsEncryptionDecryption objEncryptDecrypt = new clsEncryptionDecryption();

            while (true)
            {
                Console.WriteLine("Enter Your Old Password");
                string StringPassword = Console.ReadLine();

                DataRow[] objDataRowUsers = objDataSetUser.Tables[0].Select("Username='" + stringUsername + "'");
                if (objEncryptDecrypt.Decrypt((objDataRowUsers[0]["Password"].ToString())) == StringPassword)
                {
                    //To check old password and new password are same or not
                    while (true)
                    {
                        Console.WriteLine("Enter New Password : ");
                        string StringNewPassword = Console.ReadLine();
                        if (objEncryptDecrypt.Decrypt((objDataRowUsers[0]["Password"].ToString())) == StringNewPassword)
                        {
                            Console.WriteLine("\nOld Password and new password can not be same... So enter different password");
                        }
                        else
                        {
                            while (true)
                            {
                                Console.WriteLine("Confirm New Password : ");
                                string StringConfirmPassword = Console.ReadLine();

                                if (StringNewPassword == StringConfirmPassword)
                                {
                                    objDataRowUsers[0]["Password"] = objEncryptDecrypt.Encrypt(StringConfirmPassword);
                                    objDataSetUser.Tables[0].WriteXml("userData.xml", XmlWriteMode.WriteSchema);
                                    Console.WriteLine("Password Changed Succesfully");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("New password and confirm password must be same");
                                }
                            }
                            break;
                        }
                    }
                    break;
                }
                else
                    Console.WriteLine("Invalid Password\n");
            }
            objDataSetUser.Clear();
        }

        static void Main(string[] args)
        {
            DataSet objDataSetUser = new DataSet("User_DataSet");
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
                objDataTableUser.WriteXml("userData.xml", XmlWriteMode.WriteSchema);
            }

            var Int32Choice = 0;
            do
            {
                try
                {
                    Console.WriteLine("\n1. Create Account");
                    Console.WriteLine("2. Login");
                    Console.WriteLine("3. Password Reset");
                    Console.WriteLine("4. Exit");
                    Console.WriteLine("Enter your chioce");
                    Int32Choice = Convert.ToInt32(Console.ReadLine());

                    switch (Int32Choice)
                    {
                        case 1:
                            createAcc(objDataSetUser);
                            break;
                        case 2:
                            login(objDataSetUser);
                            break;
                        case 3:
                            passwordReset(objDataSetUser);
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
                finally
                {
                    objDataSetUser.Clear();
                }
            } while (Int32Choice != 4);
        }
    }
}