/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
namespace MyRapid.Code
{
    public static class EncryptHelper
    {
        /// <summary>
        /// MD5不可逆加密
        /// </summary>
        /// <param name="strData">源字符串</param>
        /// <returns></returns>
        public static string MD5Encrypt(string strData)
        {
            try
            {
                MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
                //return Convert.ToBase64String(mD5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(strData.Trim())));
                //和Sql一致
                byte[] bytes = mD5CryptoServiceProvider.ComputeHash(Encoding.Default.GetBytes(strData.Trim().ToCharArray()));
                string[] chars = BitConverter.ToString(bytes).Split('-');
                string rtn = string.Concat(chars);
                return rtn;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Des加密字符串
        /// </summary>
        /// <param name="SourceStr">源字符串</param>
        /// <param name="myKey">8位密码</param>
        /// <returns></returns>
        public static string DESEncrypt(string SourceStr, string myKey = "")
        {
            string result;
            try
            {
                string key = "{0}!@#$%^&*";
                myKey = string.Format(key, myKey).Substring(0, 8);
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                byte[] bytes = Encoding.Default.GetBytes(SourceStr);
                dESCryptoServiceProvider.Key = Encoding.UTF8.GetBytes(myKey);
                dESCryptoServiceProvider.IV = Encoding.UTF8.GetBytes(myKey);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
                StreamWriter streamWriter = new StreamWriter(cryptoStream);
                streamWriter.Write(SourceStr);
                streamWriter.Flush();
                cryptoStream.FlushFinalBlock();
                memoryStream.Flush();
                result = Convert.ToBase64String(memoryStream.GetBuffer(), 0, checked((int)memoryStream.Length));
            }
            catch
            {
                throw;
            }
            return result;
        }
        /// <summary>
        /// Des解密字符串
        /// </summary>
        /// <param name="SourceStr">源字符串</param>
        /// <param name="myKey">8位密码</param>
        /// <returns></returns>
        public static string DESDecrypt(string SourceStr, string myKey = "")
        {
            try
            {
                string key = "{0}!@#$%^&*";
                key = string.Format(key, myKey).Substring(0, 8);
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                dESCryptoServiceProvider.Key = Encoding.UTF8.GetBytes(myKey);
                dESCryptoServiceProvider.IV = Encoding.UTF8.GetBytes(myKey);
                byte[] buffer = Convert.FromBase64String(SourceStr);
                MemoryStream memoryStream = new MemoryStream(buffer);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Read);
                StreamReader streamReader = new StreamReader(cryptoStream);
                return streamReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// TripleDes加密字符串
        /// </summary>
        /// <param name="SourceStr">源字符串</param>
        /// <param name="myKey">8位密码</param>
        /// <returns></returns>
        public static string TriDESEncrypt(string SourceStr, string myKey)
        {
            string result;
            try
            {
                string key = "{0}!@#$%^&*~`qwertyuiopasdfghjklzxcvbnm";
                myKey = string.Format(key, myKey).Substring(0, 24);
                TripleDESCryptoServiceProvider dESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                byte[] bytes = Encoding.Default.GetBytes(SourceStr);
                dESCryptoServiceProvider.Key = Encoding.UTF8.GetBytes(myKey);
                dESCryptoServiceProvider.IV = Encoding.UTF8.GetBytes(myKey.Substring(0, 8));
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
                StreamWriter streamWriter = new StreamWriter(cryptoStream);
                streamWriter.Write(SourceStr);
                streamWriter.Flush();
                cryptoStream.FlushFinalBlock();
                memoryStream.Flush();
                result = Convert.ToBase64String(memoryStream.GetBuffer(), 0, checked((int)memoryStream.Length));
            }
            catch
            {
                throw;
            }
            return result;
        }
        /// <summary>
        /// TripleDes解密字符串
        /// </summary>
        /// <param name="SourceStr">源字符串</param>
        /// <param name="myKey">8位密码</param>
        /// <returns></returns>
        public static string TriDESDecrypt(string SourceStr, string myKey)
        {
            try
            {
                string key = "{0}!@#$%^&*~`qwertyuiopasdfghjklzxcvbnm";
                myKey = string.Format(key, myKey).Substring(0, 24);
                TripleDESCryptoServiceProvider dESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
                dESCryptoServiceProvider.Key = Encoding.UTF8.GetBytes(myKey);
                dESCryptoServiceProvider.IV = Encoding.UTF8.GetBytes(myKey.Substring(0, 8));
                byte[] buffer = Convert.FromBase64String(SourceStr);
                MemoryStream memoryStream = new MemoryStream(buffer);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Read);
                StreamReader streamReader = new StreamReader(cryptoStream);
                return streamReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// RSA加密字符串
        /// </summary>
        /// <param name="SourceStr">源字符串</param>
        /// <param name="myKey">密码</param>
        /// <returns></returns>
        public static string RSAEncrypt(string SourceStr, string myKey)
        {
            try
            {
                CspParameters param = new CspParameters();
                param.KeyContainerName = myKey;//密匙容器的名称，保持加密解密一致才能解密成功
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param);
                byte[] plaindata = Encoding.Default.GetBytes(SourceStr);//将要加密的字符串转换为字节数组
                byte[] encryptdata = rsa.Encrypt(plaindata, false);//将加密后的字节数据转换为新的加密字节数组
                return Convert.ToBase64String(encryptdata);//将加密后的字节数组转换为字符串
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// RSA解密字符串
        /// </summary>
        /// <param name="SourceStr">源字符串</param>
        /// <param name="myKey">密码</param>
        /// <returns></returns>
        public static string RSADecrypt(string SourceStr, string myKey)
        {
            try
            {
                CspParameters param = new CspParameters();
                param.KeyContainerName = myKey;
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param);
                byte[] encryptdata = Convert.FromBase64String(SourceStr);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                return Encoding.Default.GetString(decryptdata);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>  
        /// AES加密  
        /// </summary>  
        /// <param name="SourceStr">被加密的明文</param>  
        /// <param name="myKey">密钥</param>  
        /// <param name="Vector">向量</param>  
        /// <returns>密文</returns>  
        public static string AESEncrypt(string SourceStr, string myKey, string Vector)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(SourceStr);
            byte[] bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(myKey.PadRight(bKey.Length)), bKey, bKey.Length);
            byte[] bVector = new byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(Vector.PadRight(bVector.Length)), bVector, bVector.Length);
            byte[] Cryptograph = null; // 加密后的密文  
            Rijndael Aes = Rijndael.Create();
            try
            {
                // 开辟一块内存流  
                using (MemoryStream Memory = new MemoryStream())
                {
                    // 把内存流对象包装成加密流对象  
                    using (CryptoStream Encryptor = new CryptoStream(Memory,
                     Aes.CreateEncryptor(bKey, bVector),
                     CryptoStreamMode.Write))
                    {
                        // 明文数据写入加密流  
                        Encryptor.Write(plainBytes, 0, plainBytes.Length);
                        Encryptor.FlushFinalBlock();
                        Cryptograph = Memory.ToArray();
                    }
                }
            }
            catch
            {
                Cryptograph = null;
            }
            return Convert.ToBase64String(Cryptograph);
        }
        /// <summary>  
        /// AES解密  
        /// </summary>  
        /// <param name="SourceStr">被解密的密文</param>  
        /// <param name="myKey">密钥</param>  
        /// <param name="Vector">向量</param>  
        /// <returns>明文</returns>  
        public static string AESDecrypt(string SourceStr, string myKey, string Vector)
        {
            byte[] encryptedBytes = Convert.FromBase64String(SourceStr);
            byte[] bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(myKey.PadRight(bKey.Length)), bKey, bKey.Length);
            byte[] bVector = new byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(Vector.PadRight(bVector.Length)), bVector, bVector.Length);
            byte[] original = null; // 解密后的明文  
            Rijndael Aes = Rijndael.Create();
            try
            {
                // 开辟一块内存流，存储密文  
                using (MemoryStream Memory = new MemoryStream(encryptedBytes))
                {
                    // 把内存流对象包装成加密流对象  
                    using (CryptoStream Decryptor = new CryptoStream(Memory,
                    Aes.CreateDecryptor(bKey, bVector),
                    CryptoStreamMode.Read))
                    {
                        // 明文存储区  
                        using (MemoryStream originalMemory = new MemoryStream())
                        {
                            byte[] Buffer = new byte[1024];
                            int readBytes = 0;
                            while ((readBytes = Decryptor.Read(Buffer, 0, Buffer.Length)) > 0)
                            {
                                originalMemory.Write(Buffer, 0, readBytes);
                            }
                            original = originalMemory.ToArray();
                        }
                    }
                }
            }
            catch
            {
                original = null;
            }
            return Encoding.UTF8.GetString(original);
        }
        /// <summary>  
        /// AES加密
        /// </summary>  
        /// <param name="SourceStr">被加密的明文</param>  
        /// <param name="myKey">密钥</param>  
        /// <returns>密文</returns>  
        public static string AESEncrypt(string SourceStr, string myKey)
        {
            MemoryStream mStream = new MemoryStream();
            RijndaelManaged aes = new RijndaelManaged();
            byte[] plainBytes = Encoding.UTF8.GetBytes(SourceStr);
            byte[] bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(myKey.PadRight(bKey.Length)), bKey, bKey.Length);
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            //aes.Key = _key;
            aes.Key = bKey;
            //aes.IV = _iV;  
            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
            try
            {
                cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                cryptoStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                throw;
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }
        }
        /// <summary>  
        /// AES解密
        /// </summary>  
        /// <param name="SourceStr">被加密的明文</param>  
        /// <param name="myKey">密钥</param>  
        /// <returns>明文</returns>  
        public static string AESDecrypt(string SourceStr, string myKey)
        {
            byte[] encryptedBytes = Convert.FromBase64String(SourceStr);
            byte[] bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(myKey.PadRight(bKey.Length)), bKey, bKey.Length);
            MemoryStream mStream = new MemoryStream(encryptedBytes);
            //mStream.Write( encryptedBytes, 0, encryptedBytes.Length );  
            //mStream.Seek( 0, SeekOrigin.Begin );  
            RijndaelManaged aes = new RijndaelManaged();
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;
            aes.Key = bKey;
            //aes.IV = _iV;  
            CryptoStream cryptoStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Read);
            try
            {
                byte[] tmp = new byte[encryptedBytes.Length + 32];
                int len = cryptoStream.Read(tmp, 0, encryptedBytes.Length + 32);
                byte[] ret = new byte[len];
                Array.Copy(tmp, 0, ret, 0, len);
                return Encoding.UTF8.GetString(ret);
            }
            catch
            {
                throw;
            }
            finally
            {
                cryptoStream.Close();
                mStream.Close();
                aes.Clear();
            }
        }
    }
}