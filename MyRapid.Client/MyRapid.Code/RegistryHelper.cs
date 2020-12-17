/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyRapid.Code
{
    public static class RegistryHelper
    {
        private static string FormRegKey(string sApp, string sSect)
        {
            if (string.IsNullOrEmpty(sApp))
                return @"Software\RegistryHelper";
            if (string.IsNullOrEmpty(sSect))
                return (@"Software\RegistryHelper\" + sApp);
            return (@"Software\RegistryHelper\" + sApp + @"\" + sSect);
        }
        /// <summary>
        /// 保存信息到注册表
        /// </summary>
        /// <param name="AppName">应用名称</param>
        /// <param name="Section">模块</param>
        /// <param name="Key">键名</param>
        /// <param name="Setting">键值</param>
        public static void SaveSetting(string AppName, string Section, string Key, string Setting)
        {
            if (string.IsNullOrEmpty(AppName))
                throw new ArgumentException("Invalid Parameter:AppName");
            if (string.IsNullOrEmpty(Section))
                throw new ArgumentException("Invalid Parameter:Section");
            if (string.IsNullOrEmpty(Key))
                throw new ArgumentException("Invalid Parameter:Key");
            string subkey = FormRegKey(AppName, Section);
            using (RegistryKey key = Registry.LocalMachine.CreateSubKey(subkey))
            {
                if (key == null)
                {
                    throw new ArgumentException("Can't Create SubKey!");
                }
                try
                {
                    key.SetValue(Key, Setting);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 从注册表读取信息
        /// </summary>
        /// <param name="AppName">应用名称</param>
        /// <param name="Section">模块</param>
        /// <param name="Key">键名</param>
        /// <param name="Default">默认值</param>
        /// <returns></returns>
        public static string GetSetting(string AppName, string Section, string Key, string Default = "")
        {
            try
            {
                string name = FormRegKey(AppName, Section);
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(name))
                {
                    if (key != null)
                        return key.GetValue(Key, Default).ToStringEx();
                }
            }
            catch
            {
                return Default;
            }
            return Default;
        }
        /// <summary>
        /// 保存控件所有子控件信息
        /// </summary>
        /// <param name="AppName">程序名称</param>
        /// <param name="Section">所属部分</param>
        /// <param name="AppCtrl">控件名称</param>
        public static void SaveForm(string AppName, string Section, Control AppCtrl)
        {
            foreach (Control c in AppCtrl.Controls)
            {
                SaveSetting(AppName, Section, c.Name, c.Text);
                SaveForm(AppName, Section, c);
            }
        }
        /// <summary>
        /// 保存控件所有子控件信息
        /// </summary>
        /// <param name="AppName">程序名称</param>
        /// <param name="Section">所属部分</param>
        /// <param name="AppCtrl">控件名称</param>
        public static void GetForm(string AppName, string Section, Control AppCtrl)
        {
            foreach (Control c in AppCtrl.Controls)
            {
                GetSetting(AppName, Section, c.Name, c.Text);
                GetForm(AppName, Section, c);
            }
        }
    }
}