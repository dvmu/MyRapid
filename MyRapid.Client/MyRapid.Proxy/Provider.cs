/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyRapid.Proxy
{
    public static class Provider
    {
        private static Dictionary<string, object> Session = new Dictionary<string, object>();
        public static object Get(string key)
        {
            if (Session.ContainsKey(key))
                return Session[key];
            return null;
        }
        public static void Remove(string key)
        {
            Session.Remove(key);
        }
        public static void Set(string key, object value)
        {
            Session[key] = value;
        }
        public static string StartupPath
        {
            get
            {
                string startupPath = (string)Get("StartupPath");
                if (string.IsNullOrEmpty(startupPath))
                {
                    startupPath = "";
                    return startupPath;
                }
                if (!startupPath.EndsWith(@"\") && !startupPath.EndsWith(@"/"))
                {
                    if (startupPath.StartsWith("http") || startupPath.StartsWith("ftp") || startupPath.StartsWith("file"))
                    {
                        startupPath = startupPath + @"/";
                    }
                    else
                    {
                        startupPath = startupPath + @"\";
                    }
                }
                return startupPath;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Set("StartupPath", "");
                    return;
                }
                if (!value.EndsWith(@"\") && !value.EndsWith(@"/"))
                {
                    if (value.StartsWith("http") || value.StartsWith("ftp") || value.StartsWith("file"))
                    {
                        value = value + @"/";
                    }
                    else
                    {
                        value = value + @"\";
                    }
                }
                Set("StartupPath", value);
            }
        }
        public static Sys_User SysUser
        {
            get
            {
                return (Sys_User)Get("SysUser");
            }
            set
            {
                Set("SysUser", value);
            }
        }
        public static Sys_Page SysPage
        {
            get
            {
                return (Sys_Page)Get("SysPage");
            }
            set
            {
                Set("LastPage", SysPage);
                Set("SysPage", value);
            }
        }
        public static Sys_Menu SysMenu
        {
            get
            {
                return (Sys_Menu)Get("SysMenu");
            }
            set
            {
                Set("LastMenu", SysMenu);
                Set("SysMenu", value);
            }
        }
        public static List<Sys_Menu> UserMenus
        {
            get
            {
                return (List<Sys_Menu>)Get("UserMenus");
            }
            set
            {
                Set("UserMenus", value);
            }
        }
        public static Sys_Menu LastMenu
        {
            get
            {
                return (Sys_Menu)Get("LastMenu");
            }
        }
        public static Sys_Page LastPage
        {
            get
            {
                return (Sys_Page)Get("LastPage");
            }
        }
        public static object LastForm
        {
            get
            {
                return Get("LastForm");
            }
        }
        public static object CurrForm
        {
            get
            {
                return Get("CurrForm");
            }
            set
            {
                Set("LastForm", CurrForm);
                Set("CurrForm", value);

            }
        }
    }
}