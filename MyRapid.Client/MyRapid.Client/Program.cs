/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using MyRapid.Proxy;
using static MyRapid.SysEntity.Sys_Enum;
using MyRapid.Code;
using System.IO;
namespace MyRapid.Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            InitializeException();
#pragma warning disable CS0618 // 类型或成员已过时
            AppDomain.CurrentDomain.SetShadowCopyFiles();
#pragma warning restore CS0618 // 类型或成员已过时
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-Hans");
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //Application.UseWaitCursor = true;
            Application.Run(new MainUI());
        }

        #region Debug

        #endregion
        #region InitializeException
        private static void InitializeException()
        {
            //处理未捕获的异常   
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常   
            Application.ThreadException += Application_ThreadException;
            //处理非UI线程异常   
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception error = e.ExceptionObject as Exception;
            if (error != null)
            {
                File.AppendAllText("MyRapid.log", e.ToJson());
                //BaseService.SaveLog(error.Message, error.StackTrace, (byte)Sys_Log_Type.Fatal, string.Empty, "UnhandledException");
            }
        }
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            File.AppendAllText("MyRapid.log", e.ToJson());
            //BaseService.SaveLog(e.Exception.Message, e.Exception.StackTrace, (byte)Sys_Log_Type.Fatal, string.Empty, "ThreadException");
        }
        #endregion
    }
}
