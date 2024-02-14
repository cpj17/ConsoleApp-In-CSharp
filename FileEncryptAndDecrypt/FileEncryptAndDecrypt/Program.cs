using System;
using System.IO;
using System.Security.Cryptography;

namespace FileEncryptAndDecrypt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //EncryptFile(@"C:\Users\GSIAD-031\Desktop\a.txt", @"C:\Users\GSIAD-031\Desktop\encrypted.bin", "password123");
            DecryptFile(@"C:\Users\GSIAD-031\Desktop\encrypted.bin", @"C:\Users\GSIAD-031\Desktop\decrypted.txt", "password123");
        }

        private static byte[] GenerateRandomKey()
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateKey();
                return aes.Key;
            }
        }

        public static void EncryptFile(string inputFile, string outputFile, string password)
        {
            byte[] salt = GenerateRandomKey();

            using (var aes = Aes.Create())
            using (var keyDerivationFunction = new Rfc2898DeriveBytes(password, salt))
            {
                aes.Key = keyDerivationFunction.GetBytes(32); // 256-bit key
                aes.IV = keyDerivationFunction.GetBytes(16); // 128-bit IV

                using (var inputFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                using (var outputFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
                using (var cryptoStream = new CryptoStream(outputFileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    outputFileStream.Write(salt, 0, salt.Length);

                    inputFileStream.CopyTo(cryptoStream);
                }
            }
        }

        public static void DecryptFile(string inputFile, string outputFile, string password)
        {
            using (var inputFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (var outputFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            {
                byte[] salt = new byte[32];
                inputFileStream.Read(salt, 0, salt.Length);

                using (var aes = Aes.Create())
                using (var keyDerivationFunction = new Rfc2898DeriveBytes(password, salt))
                {
                    aes.Key = keyDerivationFunction.GetBytes(32);
                    aes.IV = keyDerivationFunction.GetBytes(16);

                    using (var cryptoStream = new CryptoStream(inputFileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        cryptoStream.CopyTo(outputFileStream);
                    }
                }
            }
        }
    }
}
