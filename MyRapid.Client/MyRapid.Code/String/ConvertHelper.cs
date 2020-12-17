/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
namespace MyRapid.Code
{
    public static class ConvertHelper
    {
        public static Guid ToGuidEx(this object str)
        {
            try
            {
                if (str.GetType().Equals(typeof(Guid)))
                    return (Guid)str;
                return Guid.Parse(str.ToStringEx());
            }
            catch
            {
                return Guid.Empty;
            }
        }
        public static string ToHexStringEx(this byte[] str)
        {
            try
            {
                return BitConverter.ToString(str);
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string ToStringEx(this object str)
        {
            try
            {
                if (str == null)
                    return string.Empty;
                return str.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string ToStringEx(this byte[] str)
        {
            try
            {
                if (str == null)
                    return string.Empty;
                return Encoding.UTF8.GetString(str);
            }
            catch
            {
                return string.Empty;
            }
        }
        public static string ToStringEx(this Stream str)
        {
            try
            {
                return str.ToBytes().ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
        public static bool ToBoolEx(this object str)
        {
            try
            {
                //public static string[] ConvertTrueString = new string[] { "true", "1", "真", "checked", "yes", "real","correct","right", "positive" };
                if (string.IsNullOrEmpty(str.ToStringEx())) return
                        false;
                if (ReservedHelper.ConvertTrueString.Contains(str.ToStringEx().ToLower()))
                    return true;
                else if (ReservedHelper.ConvertFalseString.Contains(str.ToStringEx().ToLower()))
                    return false;
                else return Convert.ToBoolean(str);
            }
            catch
            {
                return false;
            }
        }
        public static bool ToBoolEx(this int str)
        {
            try
            {
                return (str >= 1);
            }
            catch
            {
                return false;
            }
        }
        public static int ToIntEx(this object str)
        {
            try
            {
                return Convert.ToInt32(str);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal ToDecimalEx(this object str)
        {
            try
            {
                return Convert.ToDecimal(str);
            }
            catch
            {
                return 0;
            }
        }
        public static DateTime ToDateTimeEx(this object str)
        {
            try
            {
                return Convert.ToDateTime(str);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        public static SqlDateTime ToSqlDateTimeEx(this object str)
        {
            try
            {
                if (str.GetType().Equals(typeof(SqlDateTime)))
                    return (SqlDateTime)str;
                return SqlDateTime.Parse(str.ToStringEx());
            }
            catch
            {
                return SqlDateTime.MinValue;
            }
        }
        public static byte[] ToBytes(this string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            return bytes;
        }
        public static byte[] ToBytes(this Stream stream)
        {
            //网上多数把seek放在read后面，测试中发现不行，需要放在前面
            stream.Seek(0, SeekOrigin.Begin);
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            return buffer;
        }
        /// 将 byte[] 转成 Stream
        public static Stream ToStream(this byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
        public static Stream ToStream(this string str)
        {
            try
            {
                return str.ToBytes().ToStream();
            }
            catch
            {
                return null;
            }
        }
        #region Function Convert
        /// <summary>
        /// 将Net类型转换为SqlDbType
        /// </summary>
        /// <param name="theType">待转换类型</param>
        /// <returns></returns>
        public static SqlDbType GetSqlType(Type theType)
        {
            if (theType.Equals(typeof(byte[]))) return SqlDbType.VarBinary;
            //if (theType.Equals(typeof(string))) return SqlDbType.UniqueIdentifier;
            switch (Type.GetTypeCode(theType))
            {
                case TypeCode.Boolean:
                    return SqlDbType.Bit;
                case TypeCode.Byte:
                    return SqlDbType.TinyInt;
                case TypeCode.DateTime:
                    return SqlDbType.DateTime;
                case TypeCode.Decimal:
                    return SqlDbType.Decimal;
                case TypeCode.Double:
                    return SqlDbType.Float;
                case TypeCode.Int16:
                    return SqlDbType.SmallInt;
                case TypeCode.Int32:
                    return SqlDbType.Int;
                case TypeCode.Int64:
                    return SqlDbType.BigInt;
                case TypeCode.SByte:
                    return SqlDbType.TinyInt;
                case TypeCode.Single:
                    return SqlDbType.Real;
                case TypeCode.String:
                    return SqlDbType.NVarChar;
                case TypeCode.UInt16:
                    return SqlDbType.SmallInt;
                case TypeCode.UInt32:
                    return SqlDbType.Int;
                case TypeCode.UInt64:
                    return SqlDbType.BigInt;
                case TypeCode.Object:
                    return SqlDbType.Variant;
                default:
                    return SqlDbType.NVarChar;
            }

            //if (theType .Equals ( typeof(byte[]))) return SqlDbType.VarBinary;
            //SqlParameter p1;
            //System.ComponentModel.TypeConverter tc;
            //p1 = new SqlParameter();
            //tc = System.ComponentModel.TypeDescriptor.GetConverter(p1.DbType);
            //if (tc.CanConvertFrom(theType))
            //{
            //    p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
            //}
            //else
            //{        //Try brute force
            //    try
            //    {
            //        p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
            //    }
            //    catch
            //    {
            //        p1.DbType = DbType.String;
            //    }
            //}
            //return p1.SqlDbType;
        }
        public static SqlDbType GetSqlType(DbType pSourceType)
        {
            SqlParameter paraConver = new SqlParameter();
            paraConver.DbType = pSourceType;
            return paraConver.SqlDbType;
        }

        /// <summary>
        /// 将Net类型转换为SqlDbType
        /// </summary>
        /// <param name="theType">待转换类型</param>
        /// <returns></returns>
        public static DbType GetDbType(Type theType)
        {
            if (theType.Equals(typeof(byte[]))) return DbType.Binary;
            if (theType.Equals(typeof(Guid))) return DbType.Guid;
            switch (Type.GetTypeCode(theType))
            {
                case TypeCode.Boolean:
                    return DbType.Boolean;
                case TypeCode.Byte:
                    return DbType.Byte;
                case TypeCode.DateTime:
                    return DbType.DateTime;
                case TypeCode.Decimal:
                    return DbType.Decimal;
                case TypeCode.Double:
                    return DbType.Double;
                case TypeCode.Int16:
                    return DbType.Int16;
                case TypeCode.Int32:
                    return DbType.Int32;
                case TypeCode.Int64:
                    return DbType.Int64;
                case TypeCode.SByte:
                    return DbType.SByte;
                case TypeCode.Single:
                    return DbType.Single;
                case TypeCode.String:
                    return DbType.String;
                case TypeCode.UInt16:
                    return DbType.Int16;
                case TypeCode.UInt32:
                    return DbType.Int32;
                case TypeCode.UInt64:
                    return DbType.Int64;
                case TypeCode.Object:
                    return DbType.Object;
                default:
                    return DbType.String;
            }

            //if (theType .Equals ( typeof(byte[]))) return SqlDbType.VarBinary;
            //SqlParameter p1;
            //System.ComponentModel.TypeConverter tc;
            //p1 = new SqlParameter();
            //tc = System.ComponentModel.TypeDescriptor.GetConverter(p1.DbType);
            //if (tc.CanConvertFrom(theType))
            //{
            //    p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
            //}
            //else
            //{        //Try brute force
            //    try
            //    {
            //        p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
            //    }
            //    catch
            //    {
            //        p1.DbType = DbType.String;
            //    }
            //}
            //return p1.SqlDbType;
        }
        public static DbType GetDbType(SqlDbType pSourceType)
        {
            SqlParameter paraConver = new SqlParameter();
            paraConver.SqlDbType = pSourceType;
            return paraConver.DbType;
        }
        /// <summary>
        /// 将SqlDbType类型转换为Net
        /// </summary>
        /// <param name="theType">待转换类型</param>
        /// <returns></returns>
        public static Type GetNetType(SqlDbType theType)
        {
            if (theType.Equals(SqlDbType.VarBinary)) return typeof(byte[]);
            if (theType.Equals(SqlDbType.UniqueIdentifier)) return typeof(Guid);
            switch (theType)
            {
                case SqlDbType.Bit:
                    return typeof(bool);
                case SqlDbType.TinyInt:
                    return typeof(byte);
                case SqlDbType.DateTime:
                    return typeof(DateTime);
                case SqlDbType.DateTime2:
                    return typeof(DateTime);
                case SqlDbType.DateTimeOffset:
                    return typeof(DateTime);
                case SqlDbType.SmallDateTime:
                    return typeof(DateTime);
                case SqlDbType.Money:
                    return typeof(decimal);
                case SqlDbType.Decimal:
                    return typeof(decimal);
                case SqlDbType.Float:
                    return typeof(double);
                case SqlDbType.SmallInt:
                    return typeof(short);
                case SqlDbType.Int:
                    return typeof(int);
                case SqlDbType.BigInt:
                    return typeof(long);
                case SqlDbType.Real:
                    return typeof(float);
                case SqlDbType.NVarChar:
                    return typeof(string);
                default:
                    return typeof(string);
            }
        }
        /// <summary>
        /// 将SqlDbType类型转换为Net
        /// </summary>
        /// <param name="theType">待转换类型</param>
        /// <returns></returns>
        public static Type GetNetType(DbType theType)
        {
            if (theType.Equals(DbType.Binary)) return typeof(byte[]);
            switch (theType)
            {
                case DbType.Boolean:
                    return typeof(bool);
                case DbType.Byte:
                    return typeof(byte);
                case DbType.DateTime:
                    return typeof(DateTime);
                case DbType.DateTime2:
                    return typeof(DateTime);
                case DbType.DateTimeOffset:
                    return typeof(DateTime);
                case DbType.Decimal:
                    return typeof(decimal);
                case DbType.Double:
                    return typeof(double);
                case DbType.Int32:
                    return typeof(int);
                case DbType.Int64:
                    return typeof(long);
                case DbType.Single:
                    return typeof(float);
                case DbType.String:
                    return typeof(string);
                default:
                    return typeof(string);
            }
        }


        #endregion
        /// <summary>
        /// 如果为空返回默认值
        /// </summary>
        /// <param name="obj">源</param>
        /// <param name="def">默认值</param>
        /// <returns></returns>
        public static object IsNull(this object obj, object def)
        {
            if (obj == null)
            {
                return def;
            }
            return obj;
        }
        /// <summary>
        /// 如果为空设置默认值
        /// </summary>
        /// <param name="obj">源</param>
        /// <param name="def">默认值</param>
        /// <returns></returns>
        public static object IfNull(this object obj, object def)
        {
            if (obj == null)
            {
                obj = def;
            }
            return obj;
        }
        public static bool IsBaseOn(object obj, Type tgt)
        {
            Type sty = obj.GetType();
            while (sty != typeof(object) && sty != tgt)
            {
                sty = sty.BaseType;
            }
            return sty == tgt;
        }
    }
}