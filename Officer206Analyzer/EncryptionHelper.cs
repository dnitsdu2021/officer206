﻿using System.IO;
using System.Text;
using System.Security.Cryptography;
using System;

public  class EncryptionHelper
{
    
         private static string encryptionKey = "1234567890123451";
        
        public  string Decrypt(string CipherText) {
            return Decrypt(CipherText, encryptionKey);
        }

        protected static string Decrypt(string CipherText, string EncryptionPrivateKey) {
            if (String.IsNullOrEmpty(CipherText))
                return CipherText;

            TripleDESCryptoServiceProvider tDESalg = new TripleDESCryptoServiceProvider();
            tDESalg.Key = new ASCIIEncoding().GetBytes(EncryptionPrivateKey.Substring(0, 16));
            tDESalg.IV = new ASCIIEncoding().GetBytes(EncryptionPrivateKey.Substring(8, 8));

            byte[] buffer = Convert.FromBase64String(CipherText);
            string result = DecryptTextFromMemory(buffer, tDESalg.Key, tDESalg.IV);
            return result;
        }

        public  string Encrypt(string PlainText) {
            return Encrypt(PlainText, encryptionKey);
        }

        protected static string Encrypt(string PlainText, string EncryptionPrivateKey)
        {
            if (String.IsNullOrEmpty(PlainText))
                return PlainText;

            TripleDESCryptoServiceProvider tDESalg = new TripleDESCryptoServiceProvider();
            tDESalg.Key = new ASCIIEncoding().GetBytes(EncryptionPrivateKey.Substring(0, 16));
            tDESalg.IV = new ASCIIEncoding().GetBytes(EncryptionPrivateKey.Substring(8, 8));

            byte[] encryptedBinary = EncryptTextToMemory(PlainText, tDESalg.Key, tDESalg.IV);
            string result = Convert.ToBase64String(encryptedBinary);
            return result;
        }

        private static byte[] EncryptTextToMemory(string Data, byte[] Key, byte[] IV)
        {
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, new TripleDESCryptoServiceProvider().CreateEncryptor(Key, IV), CryptoStreamMode.Write);
            byte[] toEncrypt = new UnicodeEncoding().GetBytes(Data);
            cStream.Write(toEncrypt, 0, toEncrypt.Length);
            cStream.FlushFinalBlock();
            byte[] ret = mStream.ToArray();
            cStream.Close();
            mStream.Close();
            return ret;
        }

        private static string DecryptTextFromMemory(byte[] Data, byte[] Key, byte[] IV) {
            MemoryStream msDecrypt = new MemoryStream(Data);
            CryptoStream csDecrypt = new CryptoStream(msDecrypt, new TripleDESCryptoServiceProvider().CreateDecryptor(Key, IV), CryptoStreamMode.Read);
            StreamReader sReader = new StreamReader(csDecrypt, new UnicodeEncoding());
            return sReader.ReadLine();
        }
    }

