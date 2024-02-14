using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Xml;
using System.Collections;
using System.Web.Script.Serialization;

namespace DataSet_To_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet objDataSetConfig = new DataSet();
            objDataSetConfig.ReadXml("assist/config_XML.xml");

            DataRow[] objDataRow;
            objDataRow = objDataSetConfig.Tables[0].Select("");
            int intTableCount = Convert.ToInt32(objDataRow[0]["source_tbl_count"]);

            objDataRow = objDataSetConfig.Tables[0].Select("source_data_type = 'ARRAY'");
            string stringSubArrayName = objDataRow[0]["source_col"].ToString();

            DataSet objDataSetOut = new DataSet();
            objDataSetOut.ReadXml("assist/out.xml");

            //Rename Target To Source
            for (int i = 0; i < objDataSetConfig.Tables[0].Rows.Count; i++)
            {
                string tableName = objDataSetConfig.Tables[0].Rows[i]["source_table_name"].ToString();
                string sourceColumnName = objDataSetConfig.Tables[0].Rows[i]["source_col"].ToString();
                string targetColumnName = objDataSetConfig.Tables[0].Rows[i]["target_col_name"].ToString();

                if (objDataSetOut.Tables.Contains(tableName))
                {
                    if (objDataSetOut.Tables[tableName].Columns.Contains(targetColumnName))
                    {
                        objDataSetOut.Tables[tableName].Columns[targetColumnName].ColumnName = sourceColumnName;
                    }
                }
            }

            string quote = "\"";
            string stringLastColNameWithValue = quote + objDataSetOut.Tables[0].Columns[objDataSetOut.Tables[0].Columns.Count - 1].ColumnName + quote + ":" + quote + objDataSetOut.Tables[0].Rows[0][objDataSetOut.Tables[0].Columns[objDataSetOut.Tables[0].Columns.Count - 1].ColumnName] + quote;

            string stringJsonResult = string.Empty;
            string stringMain = "";
            string stringSubArray = "@";
            string stringSubArray_ = string.Empty;
            string stringBrforeFinalOut = "";

            stringMain = JsonConvert.SerializeObject(objDataSetOut.Tables[0]);
            if (objDataSetOut.Tables.Count > 1)
            {
                stringMain = "@" + JsonConvert.SerializeObject(objDataSetOut.Tables[0]);

                stringSubArray += JsonConvert.SerializeObject(objDataSetOut.Tables[1]);
                stringSubArray_ = stringSubArray.Split('@')[1];
                
                stringMain = Remove_Braces(stringMain.Split('@')[1]).Replace(stringLastColNameWithValue, stringLastColNameWithValue + "," + stringSubArrayName + ":" + stringSubArray_);
                string stringJsonFormat = "[{HERE}]";
                
                stringBrforeFinalOut += stringJsonFormat.Replace("HERE", stringMain);
            }
            else
            {
                stringBrforeFinalOut = stringMain;
            }

            #region cmoments
            //stringJsonResult = stringJsonResult.Split(new string[] { "\"t1\":"}, StringSplitOptions.None)[1].Replace("t2", "tttt");

            //File.WriteAllText("assist/out/result.txt", stringJsonResult);

            //dynamic obj;
            //obj = dataSetToJSON(objDataSetOut);
            //File.WriteAllText("assist/out/result.txt", obj);
            #endregion
        }

        public static string Remove_Braces(string stringInput)
        {
            stringInput = stringInput.Trim('[').Trim(']').Trim('{').Trim('}');
            return stringInput;
        }

        //Following Functions are not used

        //Working
        public static string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }

        public static object dataSetToJSON(DataSet ds)
        {
            ArrayList root = new ArrayList();
            List<Dictionary<string, object>> table;
            Dictionary<string, object> data;

            foreach (DataTable dt in ds.Tables)
            {
                table = new List<Dictionary<string, object>>();
                foreach (DataRow dr in dt.Rows)
                {
                    data = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        data.Add(col.ColumnName, dr[col]);
                    }
                    table.Add(data);
                }
                root.Add(table);
            }
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(root);
        }

        //Working 1st priority
        public static string DataTableToJsonWithJsonNet(DataTable table)
        {
            string jsonString = string.Empty;
            jsonString = JsonConvert.SerializeObject(table);
            return jsonString;
        }

        public static string DataTable_To_Json(DataSet objDataSet)
        {
            string stringReturnJson = string.Empty;
            stringReturnJson = "[{\n";

            for (int i = 0; i < objDataSet.Tables.Count; i++)
            {
                for (int j = 0; j < objDataSet.Tables[i].Columns.Count; j++)
                {
                    for (int k = 0; k < objDataSet.Tables[i].Rows.Count; k++)
                    {
                        if (!stringReturnJson.Contains(objDataSet.Tables[i].Columns[j].ColumnName))
                        {

                        }
                        stringReturnJson += "\"" + objDataSet.Tables[i].Columns[j].ColumnName + "\": ";
                    }
                }
            }
            
            return stringReturnJson;
        }
    }
}
