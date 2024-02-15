using System;
using System.Data;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Test_72
{
    class Program
    {
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
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserId", typeof(Int32));
            dt.Columns.Add("UserName", typeof(string));
            dt.Columns.Add("Education", typeof(string));
            dt.Columns.Add("Location", typeof(string));
            dt.Rows.Add(1, "Satinder Singh", "Bsc Com Sci", "Mumbai");
            //dt.Rows.Add(2, "Amit Sarna", "Mstr Com Sci", "Mumbai");
            //dt.Rows.Add(3, "Andrea Ely", "Bsc Bio-Chemistry", "Queensland");
            //dt.Rows.Add(4, "Leslie Mac", "MSC", "Town-ville");
            //dt.Rows.Add(5, "Vaibhav Adhyapak", "MBA", "New Delhi");

            Console.WriteLine(DataTableToJSONWithStringBuilder(dt));
        }
    }
}
