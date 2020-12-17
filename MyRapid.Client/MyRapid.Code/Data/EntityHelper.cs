/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
namespace MyRapid.Code
{
    public static class EntityHelper
    {
        #region Function Entity

        /// <summary>
        /// 实体类列表转换成DataTable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entityList">实体类列表</param>
        /// <returns></returns>
        public static DataTable GetDataTable<T>(List<T> entityList)
        {
            try
            {
                if (entityList == null || entityList.Count.Equals(0))
                {
                    return null;
                }
                DataTable dt = new DataTable(typeof(T).Name);
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    dt.Columns.Add(new DataColumn(propertyInfo.Name, propertyInfo.PropertyType));
                }
                foreach (T entity in entityList)
                {
                    DataRow dr = dt.NewRow();
                    foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                    {
                        dr[propertyInfo.Name] = propertyInfo.GetValue(entity, null);
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 实体类转换成DataTable
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="entity">实体类</param>
        /// <returns></returns>
        public static DataTable GetDataTable<T>(T entity)
        {
            try
            {
                if (entity == null)
                {
                    return null;
                }
                DataTable dt = new DataTable(typeof(T).Name);
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    dt.Columns.Add(new DataColumn(propertyInfo.Name, propertyInfo.PropertyType));
                }
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                {
                    dr[propertyInfo.Name] = propertyInfo.GetValue(entity, null);
                }
                dt.Rows.Add(dr);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// datarow转为实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="dr">DataRow</param>
        /// <returns></returns>
        public static T GetEntity<T>(DataTable dt) where T : new()
        {
            try
            {
                if (TableHelper.IsNull(dt)) return default(T);
                DataTable ndt = dt.Copy();
                ndt.AcceptChanges();
                T entity = new T();
                foreach (DataColumn col in ndt.Columns)
                {
                    foreach (var item in entity.GetType().GetProperties())
                    {
                        if (ndt.Columns.Contains(item.Name))
                        {
                            if (DBNull.Value != ndt.Rows[0][item.Name])
                            {
                                item.SetValue(entity, dt.Rows[0][item.Name], null);
                            }
                        }
                    }
                }
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// datatable转为实体
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="dt">DataTable</param>
        /// <returns></returns>
        public static List<T> GetEntities<T>(DataTable dt) where T : new()
        {
            try
            {
                if (dt == null) return new List<T>();
                DataTable ndt = dt.Copy();
                ndt.AcceptChanges();
                List<T> entities = new List<T>();
                foreach (DataRow row in ndt.Rows)
                {
                    T entity = new T();
                    foreach (var item in entity.GetType().GetProperties())
                    {
                        if (ndt.Columns.Contains(item.Name))
                        {
                            if (DBNull.Value != row[item.Name])
                            {
                                item.SetValue(entity, row[item.Name], null);
                            }
                        }
                    }
                    entities.Add(entity);
                }
                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region List
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
            //try
            //{
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        #endregion
        /// <summary>
        /// 克隆类对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="RealObject"></param>
        /// <returns></returns>
        public static T Clone<T>(T RealObject)
        {
            using (Stream objStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objStream, RealObject);
                objStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objStream);
            }
        }
        /// <summary>
        /// 克隆对象列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="RealObject"></param>
        /// <returns></returns>
        public static IList<T> Clone<T>(IList<T> RealObject)
        {
            using (Stream objStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objStream, RealObject);
                objStream.Seek(0, SeekOrigin.Begin);
                return (IList<T>)formatter.Deserialize(objStream);
            }
        }

    }
}