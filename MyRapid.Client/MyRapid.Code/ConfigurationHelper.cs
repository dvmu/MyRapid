/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyRapid.Code
{
    public static class ConfigurationHelper 
    {
        public static string ReadSetting(string key, string def = "")
        {
            try
            {
                string rtn = ConfigurationManager.AppSettings.Get(key);
                if (string.IsNullOrEmpty(rtn))
                    return def;
                else
                    return rtn;
            }
            catch
            {
                throw;
            }
        }
        public static void SaveSetting(string key, string value)
        {
            try
            {
                Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                if (!configuration.AppSettings.Settings.AllKeys.Contains(key))
                    configuration.AppSettings.Settings.Add(key, value);
                else
                    configuration.AppSettings.Settings[key].Value = value;
                configuration.Save(ConfigurationSaveMode.Modified);
            }
            catch
            {
                throw;
            }
        }
    }
}