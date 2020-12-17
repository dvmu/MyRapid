/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace MyRapid.Code
{
    public static class JsonHelper
    {
        public static JsonSerializerSettings JsonSet()
        {
            JsonSerializerSettings setting = new JsonSerializerSettings();
            setting.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;
            setting.DateFormatString = "yyyy/MM/dd HH:mm:ss";
            //空值处理  
            setting.NullValueHandling = NullValueHandling.Ignore;
            //高级用法九中的Bool类型转换 设置  
            //setting.Converters.Add(new BoolConvert("是,否"));
            return setting;
        }
        public static object ToObject(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject(Json, JsonSet());
        }
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, JsonSet());
        }
        public static T ToObject<T>(this string Json)
        {
            return Json == null ? default(T) : JsonConvert.DeserializeObject<T>(Json, JsonSet());
        }
        public static List<T> ToList<T>(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<List<T>>(Json, JsonSet());
        }
        public static DataTable ToTable(this string Json)
        {
            return Json == null ? null : JsonConvert.DeserializeObject<DataTable>(Json, JsonSet());
        }
        public static JObject ToJObject(this string Json)
        {
            return Json == null ? JObject.Parse("{}") : JObject.Parse(Json.Replace("&nbsp;", ""));
        }
    }
}