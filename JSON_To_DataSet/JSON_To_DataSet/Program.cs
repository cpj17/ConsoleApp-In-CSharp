using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.IO;
using Newtonsoft.Json;

namespace JSON_To_DataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            string stringJSON;
            string path;

            DataSet objDataSetConfig = new DataSet();
            DataSet objDataSet = new DataSet();
            DataSet objDataSetOut = new DataSet();
            DataTable objDataTableTemp1 = new DataTable();
            try
            {
                stringJSON = File.ReadAllText("assist/json_str.txt");
                path = "assist/out/out.xml";

                objDataSetConfig.ReadXml("assist/config_XML.xml");

                objDataTableTemp1 = JsonConvert.DeserializeObject<DataTable>(stringJSON);
                objDataTableTemp1 = objDataTableTemp1.Copy();
                objDataTableTemp1.Columns.RemoveAt(objDataTableTemp1.Columns.Count - 1);
                objDataSet.Tables.Add(objDataTableTemp1);
                objDataSet.Tables[0].TableName = "t1";

                DataRow[] objDataRow = objDataSetConfig.Tables[0].Select("source_data_type = 'ARRAY'");
                if (objDataRow.Length > 0)
                {
                    string stringArrayName = objDataRow[0]["source_col"].ToString();

                    dynamic dynCls;
                    dynCls = JsonConvert.DeserializeObject<dynamic>(stringJSON);

                    Type TP = dynCls.GetType();
                    if (stringJSON.Contains(stringArrayName))
                    {
                        string stringproductArray = TP.GetProperty("Root").GetValue(dynCls)[0][stringArrayName].ToString();
                        objDataSet.Tables.Add(JsonConvert.DeserializeObject<DataTable>(stringproductArray));
                        //objDataSet.Tables[1].TableName = objDataRow[0]["target_col_name"].ToString();
                        objDataSet.Tables[1].TableName = "t2";
                        stringArrayName = null;
                    }
                }
                objDataSetOut = objDataSet.Copy();
                //objDataSet.WriteXml(path, XmlWriteMode.WriteSchema);

                int intTableCount = Convert.ToInt32(objDataSetConfig.Tables[0].Rows[0]["source_tbl_count"].ToString());
                DataSet objDataSetTemp = new DataSet("Temp");
                for (int i = 0; i < intTableCount; i++)
                {
                    DataTable objDataTableTemp = new DataTable();
                    objDataTableTemp = objDataSetConfig.Tables[0].Clone();
                    objDataTableTemp.TableName = "t" + (i + 1).ToString();

                    foreach (var item in objDataSetConfig.Tables[0].Select("source_table_name = 't" + (i + 1) + "'"))
                    {
                        objDataTableTemp.ImportRow(item);
                    }
                    objDataSetTemp.Tables.Add(objDataTableTemp);
                }
                //objDataSetTemp.WriteXml("assist/out/objDataSetTemp.xml", XmlWriteMode.WriteSchema);

                Dictionary<string, string> objDictionaryColumnName = new Dictionary<string, string>();

                for (int i = 0; i < objDataSetTemp.Tables.Count; i++)
                {
                    for (int j = 0; j < objDataSetTemp.Tables[i].Rows.Count; j++)
                    {
                        string sourceName = objDataSetTemp.Tables[i].Rows[j]["source_col"].ToString();
                        string targetName = objDataSetTemp.Tables[i].Rows[j]["target_col_name"].ToString();

                        objDictionaryColumnName.Add(sourceName, targetName);
                    }
                }

                for (int i = 0; i < objDataSetTemp.Tables.Count; i++)
                {
                    string tableName = objDataSetTemp.Tables[i].TableName;
                    if (objDataSetOut.Tables.Contains(tableName))
                    {
                        for (int j = 0; j < objDataSet.Tables[tableName].Columns.Count; j++)
                        {
                            string sourceName = objDataSet.Tables[tableName].Columns[j].ColumnName;
                            if (objDictionaryColumnName.Keys.Contains(sourceName))
                            {
                                objDataSetOut.Tables[tableName].Columns[sourceName].ColumnName = objDictionaryColumnName[sourceName];
                            }
                            else
                            {
                                objDataSetOut.Tables[tableName].Columns.Remove(sourceName);
                            }
                        }
                    }
                }
                objDictionaryColumnName = null;
                objDataSetOut.WriteXml(path, XmlWriteMode.WriteSchema);
            }
            catch (Exception objException)
            {
                Console.WriteLine(objException.ToString());
            }
            finally
            {
                stringJSON = null;
                path = null;

                objDataSetConfig = null;
                objDataSet = null;
                objDataSetOut = null;
                objDataTableTemp1 = null;
            }
            Console.Read();
        }
    }
}
