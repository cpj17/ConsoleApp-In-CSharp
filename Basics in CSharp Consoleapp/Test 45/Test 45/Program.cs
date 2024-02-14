using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace Test_45
{
    class Program
    {
        static void viewData(string username, string password)
        {
            ArrayList list = new ArrayList();
            XmlReader xr = XmlReader.Create("userData.xml");
            while (xr.Read())
            {
                if (xr.NodeType == XmlNodeType.Text)
                    list.Add(xr.Value);
            }
            int pos = list.IndexOf(username);
            if (password == Convert.ToString(list[pos + 1]))
                Console.WriteLine("Welcome " + list[pos + 2]);
            else
                Console.WriteLine("Invalid Username/Password");
        }
        static void addData(string username, string password, string name)
        {
            var lines = System.IO.File.ReadAllLines("userData.xml");
            System.IO.File.WriteAllLines("userData.xml", lines.Take(lines.Length - 1).ToArray());
            string xmlCode = "<user>\n<username>"+username+"</username>\n<password>"+password+"</password>\n"+"<name>"+name+"</name>\n";
            xmlCode += "</user>\n</users>";
            File.AppendAllText("userData.xml",xmlCode);
            Console.WriteLine("Account created successfully\n");
            //string xmlCodeLastLine = "</users>";
        }

        static void Main(string[] args)
        {
            /*XmlDocument xmlDoc = new XmlDocument();
            XmlNode userNode = xmlDoc.CreateElement("user");
            XmlAttribute userId = xmlDoc.CreateAttribute("username");
            XmlAttribute userPsw = xmlDoc.CreateAttribute("password");
            userId.Value = "aa";
            userPsw.Value = "aa";
            userNode.Attributes.Append(userId);
            userNode.Attributes.Append(userPsw);
            userNode.InnerText = "Praveen";
            xmlDoc.AppendChild(userNode);

            xmlDoc.Save("userData.xml"); */
            var choice = 0;
            do
            {
                Console.WriteLine("1. Add Data");
                Console.WriteLine("2. View Data");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter username");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        string password = Console.ReadLine();
                        Console.WriteLine("Enter name");
                        string name = Console.ReadLine();
                        addData(username, password, name);
                        break;
                    case 2:
                        Console.WriteLine("Enter username");
                        username = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        password = Console.ReadLine();
                        viewData(username, password);
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Enter Valid Choice\n");
                        break;
                }
            } while (choice != 3);
        }
    }
}
