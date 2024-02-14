using System;

namespace String_Split
{
    class Program
    {
        static void Main(string[] args)
        {
            string msg;
            string url = "https://white.nlb.gov.sg/wms/prdnlbsg/wmsoa_callback?result=0&error_msg=&sub=1b420cb0d60252880e779d9479f516d3&name=nlbtsgtp&email=Parry_TENG_from.GURUSOFT@nlb.gov.sg";
            string[] arr = url.Split('&');
            if (url.Contains("result=") && url.Contains("error_msg=") && url.Contains("sub=") && url.Contains("name=") && url.Contains("email="))
            {
                //msg = "ok";
                //string name = arr[3].ToString();
                //string str = arr[3].ToString().Split('=')[1];
                ////string str = arr[3].ToString().Substring(0, 1);
                //Console.WriteLine(str);

                string Sub = arr[2].ToString().Split('=')[1];
                string Name = arr[3].ToString().Split('=')[1];
                string Email = arr[4].ToString().Split('=')[1];
                string Error_Result = arr[0].ToString().Split('=')[1];
                string Error_Msg = arr[1].ToString().Split('=')[1];
            }
            else
                msg = "no";
        }
    }
}
