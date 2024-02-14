using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace Dynamic_Class_At_Runtime
{
    class Program
    {
        static void Main(string[] args)
        {
            #region final code 20-01 Working V1
            //try
            //{
            //    string json_str = File.ReadAllText("assist/json_str.txt");

            //    DataSet objDataSet = new DataSet();
            //    objDataSet.ReadXml("assist/config_XML.xml");

            //    DataRow[] objDataRow = objDataSet.Tables[0].Select("source_col <> ''");
            //    int propArrLength = objDataRow.Length;

            //    string[] propertyArr = new string[propArrLength];
            //    for (int i = 0; i < propArrLength; i++)
            //    {
            //        propertyArr[i] = objDataRow[i]["source_col"].ToString();
            //    }

            //    Type[] propertyTypeArr = new Type[propArrLength];
            //    for (int i = 0; i < propArrLength; i++)
            //    {
            //        if (objDataRow[i]["source_data_type"].ToString().ToLower() == "string")
            //        {
            //            propertyTypeArr[i] = typeof(string);
            //        }
            //        else if (objDataRow[i]["source_data_type"].ToString().ToLower() == "datetime")
            //        {
            //            propertyTypeArr[i] = typeof(DateTime);
            //        }
            //        else if (objDataRow[i]["source_data_type"].ToString().ToLower() == "int")
            //        {
            //            propertyTypeArr[i] = typeof(int);
            //        }
            //        else if (objDataRow[i]["source_data_type"].ToString().ToLower() == "double")
            //        {
            //            propertyTypeArr[i] = typeof(double);
            //        }
            //        else
            //        {
            //            propertyTypeArr[i] = typeof(string);
            //        }
            //    }

            //    MyClassBuilder MCB = new MyClassBuilder("test");

            //    //Create class and add Properties at runtime
            //    var myclass = MCB.CreateObject(propertyArr, propertyTypeArr);

            //    myclass = JsonConvert.DeserializeObject<dynamic>(json_str);
            //    string str = myclass.ToString();

            //    Type TP = myclass.GetType();
            //    foreach (PropertyInfo PI in TP.GetProperties())
            //    {
            //        Console.WriteLine(PI.Name);
            //    }
            //    Console.ReadLine();
            //}
            //catch (Exception objException)
            //{
            //    Console.WriteLine(objException.ToString());
            //}
            #endregion

            #region Test Code Working V2
            //string json_str = File.ReadAllText("assist/json_str.txt");

            //DataSet objDataSet = new DataSet();
            //objDataSet.ReadXml("assist/config_XML.xml");

            //DataRow[] objDataRow = objDataSet.Tables[0].Select("source_col <> ''");
            //int propArrLength = objDataRow.Length;

            //dynamic myclass = new ExpandoObject();

            //myclass = JsonConvert.DeserializeObject<dynamic>(json_str);
            //string str = myclass.ToString();

            //Type TP = myclass.GetType();
            ////var msg = TP.GetProperty("Root").GetValue(myclass)["INTERFACEDOCID"];

            //for (int i = 0; i < propArrLength; i++)
            //{
            //    //For Non Array
            //    //Console.WriteLine(TP.GetProperty("Root").GetValue(myclass)[objDataRow[i]["source_col"].ToString()]);

            //    //For Array
            //    Console.WriteLine(TP.GetProperty("Root").GetValue(myclass)[0][objDataRow[i]["source_col"].ToString()]);
            //}
            ////Console.WriteLine(msg);
            //Console.ReadLine();
            #endregion

            #region Test Code 21-01 Working V3 
            //string json_str = File.ReadAllText("assist/json_str.txt");

            //DataSet objDataSet = new DataSet();
            //objDataSet.ReadXml("assist/config_XML.xml");

            //DataRow[] objDataRow = objDataSet.Tables[0].Select("");
            //int propArrLength = objDataRow.Length;

            //dynamic myclass = new ExpandoObject();

            //myclass = JsonConvert.DeserializeObject<dynamic>(json_str);

            //Type TP = myclass.GetType();
            //int intLength = TP.GetProperty("Root").GetValue(myclass).Count;

            //for (int j = 0; j < intLength; j++)
            //{
            //    for (int i = 0; i < propArrLength; i++)
            //    {
            //        if (myclass.ToString().Contains(objDataRow[i]["source_col"].ToString()))
            //        {
            //            Console.WriteLine(TP.GetProperty("Root").GetValue(myclass)[j][objDataRow[i]["source_col"].ToString()]);
            //        }
            //    }
            //    Console.WriteLine("-----------------\n\n");
            //}

            //Console.ReadLine();
            #endregion

            #region Test Code 22-01
            try
            {
                string json_str = File.ReadAllText("assist/json_str.txt");

                DataSet objDataSet = new DataSet();
                objDataSet.ReadXml("assist/config_XML.xml");

                DataRow[] objDataRow = objDataSet.Tables[0].Select("");
                int propArrLength = objDataRow.Length;

                dynamic myclass = new ExpandoObject();

                myclass = JsonConvert.DeserializeObject<dynamic>(json_str);

                Type TP = myclass.GetType();

                //Get AsnDetails
                //string str = TP.GetProperty("Root").GetValue(myclass)[0]["AsnItemDetail"][0]["itemNumber"].ToString();

                int intLength = TP.GetProperty("Root").GetValue(myclass).Count;

                for (int j = 0; j < intLength; j++)
                {
                    for (int i = 0; i < propArrLength; i++)
                    {
                        if (myclass.ToString().Contains(objDataRow[i]["source_col"].ToString()))
                        {
                            Console.WriteLine(TP.GetProperty("Root").GetValue(myclass)[j][objDataRow[i]["source_col"].ToString()]);
                        }
                    }
                    Console.WriteLine("-----------------\n\n");
                }

                Console.ReadLine();
            }
            catch (Exception objException)
            {
                Console.WriteLine(objException.ToString());
                Console.ReadLine();
            }
            #endregion
        }
    }
}
