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
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyRapid.Code
{
    /// <summary>
    /// GZip压缩
    /// </summary>
    public class GZipHelper
    {
        public static string CompressFile(string sourceFilePath, string destinationFile = "")
        {
            try
            {
                if (!File.Exists(sourceFilePath)) throw new FileNotFoundException();
                if (string.IsNullOrEmpty(destinationFile))
                    destinationFile = sourceFilePath + ".gz";
                using (FileStream fileStream = new FileInfo(sourceFilePath).OpenRead())
                {
                    using (FileStream fileStream2 = File.Create(destinationFile))
                    {
                        using (GZipStream gzipStream = new GZipStream(fileStream2, CompressionMode.Compress))
                        {
                            fileStream.CopyTo(gzipStream);
                            gzipStream.Close();
                        }
                        fileStream2.Close();
                    }
                    fileStream.Close();
                }
                return destinationFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //System.IO.Compression.ZipFile.CreateFromDirectory(@"e:\test", @"e:\test\test.zip"); //压缩
            //System.IO.Compression.ZipFile.ExtractToDirectory(@"e:\test\test.zip", @"e:\test"); //解压
        }
        public static string DecompressFile(string sourceFilePath, string destinationFile = "")
        {
            try
            {
                if (!File.Exists(sourceFilePath)) throw new FileNotFoundException();
                if (string.IsNullOrEmpty(destinationFile))
                    destinationFile = Path.GetFileNameWithoutExtension(sourceFilePath);
                using (FileStream fileStream = new FileInfo(sourceFilePath).OpenRead())
                {
                    using (FileStream fileStream2 = File.Create(destinationFile))
                    {
                        using (GZipStream gzipStream = new GZipStream(fileStream2, CompressionMode.Decompress))
                        {
                            fileStream.CopyTo(gzipStream);
                            gzipStream.Close();
                        }
                        fileStream2.Close();
                    }
                    fileStream.Close();
                }
                return destinationFile;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="text">文本</param>
        public static string Compress(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(Compress(buffer));
        }
        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="text">文本</param>
        public static string Decompress(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            byte[] buffer = Convert.FromBase64String(text);
            using (var ms = new MemoryStream(buffer))
            {
                using (var zip = new GZipStream(ms, CompressionMode.Decompress))
                {
                    using (var reader = new StreamReader(zip))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="buffer">字节流</param>
        public static byte[] Compress(byte[] buffer)
        {
            if (buffer == null)
                return null;
            using (var ms = new MemoryStream())
            {
                using (var zip = new GZipStream(ms, CompressionMode.Compress, true))
                {
                    zip.Write(buffer, 0, buffer.Length);
                }
                return ms.ToArray();
            }
        }
        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="buffer">字节流</param>
        public static byte[] Decompress(byte[] buffer)
        {
            if (buffer == null)
                return null;
            return Decompress(new MemoryStream(buffer));
        }
        /// <summary>
        /// 压缩
        /// </summary>
        /// <param name="stream">流</param>
        public static byte[] Compress(Stream stream)
        {
            if (stream == null || stream.Length == 0)
                return null;
            return Compress(StreamToBytes(stream));
        }
        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="stream">流</param>
        public static byte[] Decompress(Stream stream)
        {
            if (stream == null || stream.Length == 0)
                return null;
            using (var zip = new GZipStream(stream, CompressionMode.Decompress))
            {
                using (var reader = new StreamReader(zip))
                {
                    return Encoding.UTF8.GetBytes(reader.ReadToEnd());
                }
            }
        }
        /// <summary>
        /// 流转换为字节流
        /// </summary>
        /// <param name="stream">流</param>
        public static byte[] StreamToBytes(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
    }
}