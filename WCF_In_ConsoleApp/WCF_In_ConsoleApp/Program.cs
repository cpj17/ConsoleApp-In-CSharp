using System;
using System.Data;
using System.Net;
using System.ServiceModel;
using System.Xml;

namespace WCF_In_ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test();
            //Test2();
        }

        private static void Test()
        {
            DataSet objDataSet = new DataSet();
            DataSet objDatasetAppsVariables = new DataSet();
            string stringUsername = "abc";
            string stringPassword = "abc";

            objDatasetAppsVariables.ReadXml("D:/Logs/selsvcstrinfo.xml");
            using (G11EOSSelectionService.SelectionServiceClient objSelectionServiceClient = new G11EOSSelectionService.SelectionServiceClient(CreateServiceBasicHttpBinding(), GetEndPoint()))
            {

                objDataSet = objSelectionServiceClient.ValidateUserLoginFromDB(stringUsername, stringPassword, objDatasetAppsVariables, out int interrorcount, out string[] stringOutputResult);
                if (objSelectionServiceClient != null)
                    objSelectionServiceClient.Close();
            }
        }

        public static BasicHttpsBinding CreateServiceBasicHttpBinding()
        {
            BasicHttpsBinding objBasicHttpsBinding;
            try
            {
                objBasicHttpsBinding = new BasicHttpsBinding
                {
                    Name = "basicHttpBinding",
                    MaxBufferSize = 2147483647,
                    MaxReceivedMessageSize = 2147483647,
                    MaxBufferPoolSize = 2147483647,
                    AllowCookies = false,
                    BypassProxyOnLocal = false,
                    UseDefaultWebProxy = true

                };

                TimeSpan timeout = new TimeSpan(00, 01, 01);
                objBasicHttpsBinding.SendTimeout = timeout;
                objBasicHttpsBinding.OpenTimeout = timeout;
                objBasicHttpsBinding.ReceiveTimeout = timeout;
                objBasicHttpsBinding.CloseTimeout = timeout;

                XmlDictionaryReaderQuotas objquotas = new XmlDictionaryReaderQuotas();
                objquotas.MaxArrayLength = int.MaxValue;
                objquotas.MaxBytesPerRead = int.MaxValue;
                objquotas.MaxDepth = int.MaxValue;
                objquotas.MaxNameTableCharCount = int.MaxValue;
                objquotas.MaxStringContentLength = int.MaxValue;
                objBasicHttpsBinding.ReaderQuotas = objquotas;

                BasicHttpsSecurity objBasicHttpsSecurity = new BasicHttpsSecurity();
                objBasicHttpsSecurity.Mode = BasicHttpsSecurityMode.Transport;
                objBasicHttpsBinding.Security = objBasicHttpsSecurity;
            }
            catch (Exception objException)
            {
                objException = null;
                return null;
            }

            return objBasicHttpsBinding;
        }

        private static EndpointAddress GetEndPoint()
        {
            EndpointAddress objEndpointAddressSelectionService = new EndpointAddress("https://gsivm-svr-devscm.gurusoft.dev:9403/PRDG11EOSMWSelectionService/Service.svc/basic");

            return objEndpointAddressSelectionService;
        }

        private static void Test2()
        {
            DataSet objDataSetReturn = new DataSet();
            DataSet objDataSetStringInfo = new DataSet();

            objDataSetStringInfo.ReadXml("D:/Logs/objDataSetStringInfo.xml");

            ServicePointManager.Expect100Continue = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback += new System.Net.Security.RemoteCertificateValidationCallback(ValidateRemoteCertificate);

            using (GSSMSService.SMSSERVICEClient objSMSSERVICEClient = new GSSMSService.SMSSERVICEClient())
            {
                objDataSetReturn = objSMSSERVICEClient.ListSMSDetailsR1V1("SEND", "", "", 0, int.MaxValue, objDataSetStringInfo, out int intRecordcount, out int intErrorCount, out string[] stringOutputResult);
                if (objSMSSERVICEClient != null)
                {
                    objSMSSERVICEClient.Close();
                }
            }
        }
        public static bool ValidateRemoteCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate cert, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors policyErrors)
        {
            bool result = false;
            string stringCertificate = "GSIVM-SVR-DEVSCM.GURUSOFT.DEV";
            string[] stringCertArray = stringCertificate.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            if (stringCertArray != null && stringCertArray.Length > 0)
            {
                foreach (string stringValue in stringCertArray)
                {
                    if (cert.Subject.ToUpper().Contains(stringValue.ToUpper()))
                    {
                        result = true;
                        break;
                    }
                }
            }
            return true;
        }
    }
}
