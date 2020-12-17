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
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace MyRapid.Code
{
    public static class XmlHelper
    {
        /// <summary>
        /// XML字符串反序列化为对象
        /// </summary>
        /// <typeparam name="T">返回对象类型<peparam>
        /// <param name="xmlStr">XML字符串</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>反序列化得到的对象</returns>
        public static T ToObject<T>(this string xmlStr, Encoding encoding = null)
        {
            if (string.IsNullOrEmpty(xmlStr)) return default(T);
            if (encoding == null) encoding = Encoding.UTF8;
            XmlSerializer mySerializer = new XmlSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(encoding.GetBytes(xmlStr));
            StreamReader sr = new StreamReader(ms, encoding);
            return (T)mySerializer.Deserialize(sr);
        }
        /// <summary>
        /// 对象系列化为xml
        /// </summary>
        /// <typeparam name="T">输入对象类型</typeparam>
        /// <param name="obj">对象</param>
        /// <param name="encoding">编码方式</param> 
        /// <returns>序列化后的字符串</returns>
        public static string ToXml<T>(this T obj, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            MemoryStream mem = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mem, encoding);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            serializer.Serialize(writer, obj, ns);
            writer.Close();
            return Encoding.UTF8.GetString(mem.ToArray());
        }
    }
}