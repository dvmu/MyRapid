/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
namespace MyRapid.GlobalLocalizer
{
    public static class BaseLocalizer
    {
        public static string GetLocalizedString<T>(int ID, string def, string Localizer)
        { 
            string enumName = Enum.GetName(typeof(T), ID);
            //if (CacheHelper.Get<string>("SysGlobalization") == null) return def;
            //List<Sys_Globalization> sys_Globalizations = (List<Sys_Globalization>)Provider.Get("SysGlobalization");
            //Sys_Globalization sys_Globalization = sys_Globalizations.Find(l => l.Globalization_Partition.Equals("devexpress", StringComparison.OrdinalIgnoreCase)
            //                                 && l.Globalization_Localizer.Equals(Localizer, StringComparison.OrdinalIgnoreCase)
            //                                 && l.Globalization_Name.Equals(enumName, StringComparison.OrdinalIgnoreCase));
            int uCultural = Provider.SysUser == null ? 1 : Provider.SysUser.User_Cultural;
            string lns = CacheHelper.Get<string>(string.Format("{0}_{1}_{2}_{3}", "Devexpress", Localizer, enumName, uCultural));
            if (!string.IsNullOrEmpty(lns))
            {
                return lns;
            }
            if (Provider.SysUser == null) return def;
            try
            {
                List<MyParameter> myParameters = new List<MyParameter>();
                //int uCultural = 0;
                myParameters.Add("@Globalization_Cultural", DbType.Int32, Provider.SysUser.User_Cultural, null);
                myParameters.Add("@Globalization_Partition", DbType.String, "Devexpress", null);
                myParameters.Add("@Globalization_Localizer", DbType.String, Localizer, null);
                myParameters.Add("@Globalization_Name", DbType.String, enumName, null);
                myParameters.Add("@Globalization_Nick", DbType.String, def, null);
                myParameters.Add("@Globalization_StringId", DbType.Int32, (int)ID, null);
                lns = BaseService.Get("SystemGlobalization_Save", myParameters).ToStringEx();
            }
            catch
            {
            }
            try
            {
                CacheHelper.Set(lns, string.Format("{0}_{1}_{2}_{3}", "Devexpress", Localizer, enumName, Provider.SysUser.User_Cultural));
                return lns;
            }
            catch
            {
            }
            return string.IsNullOrEmpty(lns) ? def : lns;
        }
    }
}