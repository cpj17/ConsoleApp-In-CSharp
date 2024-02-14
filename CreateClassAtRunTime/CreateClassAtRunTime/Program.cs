using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CreateClassAtRunTime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("b.xml");

            dynamic objDynamic;
            string str = JsonConvert.SerializeObject(dataSet.Tables["t1"]);
        }

    }
}
