/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyRapid.Code
{
    public static class CacheHelper
    {
        private static Dictionary<string, string> Storage = new Dictionary<string, string>();
        #region T
        public static void Set(object obj, string name)
        {
            SaveSql(obj, name);
        }
        public static void SetAsync(object obj, string name)
        {
            Task task = new Task(() => SaveSql(obj, name));
            task.Start();
            //SaveSql(obj, name);
        }
        #endregion
        public static T Get<T>(string name)
        {
            return ReadSql<T>(name);
        }
        private static string cFile = "MyRapid.db";
        private static void SaveSql<T>(T obj, string name)
        {
            try
            {
                if (File.Exists(cFile))
                {
                    string json = GZipHelper.Decompress(File.ReadAllText(cFile));
                    if (!string.IsNullOrEmpty(json))
                        Storage = json.ToObject<Dictionary<string, string>>();
                }
                Storage[name] = obj.ToJson();
                File.WriteAllText(cFile, GZipHelper.Compress(Storage.ToJson()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private static T ReadSql<T>(string name)
        {
            try
            {
                if (Storage.Count == 0)
                {
                    if (!File.Exists(cFile)) return default(T);
                    string json = GZipHelper.Decompress(File.ReadAllText(cFile));
                    if (string.IsNullOrEmpty(json)) return default(T);
                    Storage = json.ToObject<Dictionary<string, string>>();
                }
                if (!Storage.ContainsKey(name)) return default(T);
                if (typeof(Newtonsoft.Json.Linq.JArray) == Storage[name].GetType())
                {
                    Newtonsoft.Json.Linq.JArray ja = (Newtonsoft.Json.Linq.JArray)Storage[name];
                    return ja.ToObject<T>();
                }
                else
                {
                    return Storage[name].ToObject<T>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}