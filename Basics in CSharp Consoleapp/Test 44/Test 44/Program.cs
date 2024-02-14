using System;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Test_44
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("ROOT");
            xmlDoc.AppendChild(rootNode);

            XmlNode userNode = xmlDoc.CreateElement("User");
            rootNode.AppendChild(userNode);
            XmlNode userNodeName = xmlDoc.CreateElement("Name");
            userNodeName.InnerText = "Praveen";
            userNode.AppendChild(userNodeName);
            XmlNode userNodeDept = xmlDoc.CreateElement("Department");
            userNodeDept.InnerText = "CSE";
            userNode.AppendChild(userNodeDept);

            xmlDoc.Save("userData.xml");
            //Console.WriteLine();
        }
    }
}
