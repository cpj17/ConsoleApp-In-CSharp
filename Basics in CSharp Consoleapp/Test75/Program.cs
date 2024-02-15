using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Threading;

namespace Test75
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime dt1;
            DateTime dt2;
            DateTime dt3;
            string str;

            dt1 = DateTime.Now;
            Thread.Sleep(1030);
            dt2 = DateTime.Now;
            
            str = dt2.Subtract(dt1).ToString();
            
            //DataSet objDataSetStringInfo = new DataSet();

            //objDataSetStringInfo.ReadXml("D:/Logs/objDataSetStringInfo2.xml");
            
            //List<dynamic> objDynamicList = new List<dynamic>();
            //objDynamicList.Add(objDataSetStringInfo);
            //objDynamicList.Add("hgjhg");

            //TestFun(objDynamicList);
        }

        private static void TestFun(List<dynamic> objDynamicList)
        {
            DataSet ds = new DataSet();
            ds = objDynamicList[0];

            string str = objDynamicList[1];
        }
    }
}
