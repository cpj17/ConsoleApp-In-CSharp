using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Security.Cryptography;

namespace Test_65
{
    class clsEncryptionDecryption
    {
        public string Encrypt(string stringPlainText)
        {
            string stringEncryptionKey = "abc123";
            byte[] stringPlainTextBytes = Encoding.Unicode.GetBytes(stringPlainText);
            using (Aes objAes = Aes.Create())
            {
                Rfc2898DeriveBytes objRfc2898DeriveBytesPdb = new Rfc2898DeriveBytes(stringEncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                objAes.Key = objRfc2898DeriveBytesPdb.GetBytes(32);
                objAes.IV = objRfc2898DeriveBytesPdb.GetBytes(16);    //Intialization Vector
                using (MemoryStream objMemoryStream = new MemoryStream())
                {
                    using (CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objAes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        objCryptoStream.Write(stringPlainTextBytes, 0, stringPlainTextBytes.Length);
                        objCryptoStream.Close();
                    }
                    stringPlainText = Convert.ToBase64String(objMemoryStream.ToArray());
                }
            }
            return stringPlainText;
        }

        public string Decrypt(string stringCipherText)
        {
            string stringEncryptionKey = "abc123";
            stringCipherText = stringCipherText.Replace(" ", "+");
            byte[] bytesArrayCipher = Convert.FromBase64String(stringCipherText);
            using (Aes objAes = Aes.Create())
            {
                Rfc2898DeriveBytes objRfc2898DeriveBytesPdb = new Rfc2898DeriveBytes(stringEncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                objAes.Key = objRfc2898DeriveBytesPdb.GetBytes(32);
                objAes.IV = objRfc2898DeriveBytesPdb.GetBytes(16);
                using (MemoryStream objMemoryStream = new MemoryStream())
                {
                    using (CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objAes.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        objCryptoStream.Write(bytesArrayCipher, 0, bytesArrayCipher.Length);
                        objCryptoStream.Close();
                    }
                    stringCipherText = Encoding.Unicode.GetString(objMemoryStream.ToArray());
                }
            }
            return stringCipherText;
        }

    }
}
