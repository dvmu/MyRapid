/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MyRapid.SysEntity.Sys_Enum;
namespace MyRapid.Base
{
    public static class SharedFunc
    {
        #region Error
        /// <summary>
        /// 显示自动消失提示消息
        /// </summary>
        /// <param name="Error">提示文本</param>
        /// <param name="Detail">提示详情信息</param>
        public static void Toast(string Error, string Detail)
        {
            if (Provider.Get("MyToast") != null)
            {
                DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager myToast = (DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager)Provider.Get("MyToast");
                DevExpress.XtraBars.ToastNotifications.ToastNotification tn = new DevExpress.XtraBars.ToastNotifications.ToastNotification(Guid.NewGuid(), null, Error, Detail, null, DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText02);
                myToast.Notifications.Clear();
                myToast.Notifications.Add(tn);
                myToast.ShowNotification(tn);
            }
        }
        /// <summary>
        /// 显示自动消失提示消息
        /// </summary>
        /// <param name="Error">提示文本</param>
        /// <param name="Detail">提示详情信息</param>
        /// <param name="icon">提示的图标</param>
        public static void Toast(string Error, string Detail, Image icon)
        {
            if (Provider.Get("MyToast") != null)
            {
                DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager myToast = (DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager)Provider.Get("MyToast");
                DevExpress.XtraBars.ToastNotifications.ToastNotification tn = new DevExpress.XtraBars.ToastNotifications.ToastNotification(Guid.NewGuid(), icon, Error, Detail, null, DevExpress.XtraBars.ToastNotifications.ToastNotificationTemplate.ImageAndText02);
                myToast.Notifications.Clear();
                myToast.Notifications.Add(tn);
                myToast.ShowNotification(tn);
            }
        }
        /// <summary>
        /// 在状态栏显示提示信息
        /// </summary>
        /// <param name="Error">提示文本</param>
        public static void TipError(string Error)
        {
            BarButtonItem BarTip;
            string ChildMenu_Error = "页面错误";
            if (Provider.Get("BarTip") != null)
            {
                BarTip = (BarButtonItem)Provider.Get("BarTip");
                if (BaseService.CheckConfiguration("Global_ChildMenu_ShowErrorDetail").ToBoolEx())
                {
                    BarTip.Caption = Error;
                }
                else
                {
                    ChildMenu_Error = Provider.Get("ChildMenu_Error").ToStringEx();
                    BarTip.Caption = ChildMenu_Error;
                    BarTip.Hint = Error;
                }
                BarTip.Visibility = BarItemVisibility.Always;
                Sys_Page sys_Page = new Sys_Page();
                if (Provider.SysPage != null)
                {
                    sys_Page = Provider.SysPage;
                }
                //BaseService.SaveLog(ChildMenu_Error, Error, (byte)Sys_Log_Type.Information, sys_Page.Menu_Id);
            }
        }
        /// <summary>
        /// 在状态栏显示提示信息
        /// </summary>
        /// <param name="Error">提示文本</param>
        /// <param name="Detail">提示详情</param>
        public static void TipError(string Error, string Detail)
        {
            BarButtonItem BarTip;
            if (Provider.Get("BarTip") != null)
            {
                BarTip = (BarButtonItem)Provider.Get("BarTip");
                if (BaseService.CheckConfiguration("Global_ChildMenu_ShowErrorDetail").ToBoolEx())
                {
                    BarTip.Caption = Error;
                    BarTip.Hint = Detail;
                }
                else
                {
                    string ChildMenu_Error = Provider.Get("ChildMenu_Error").ToStringEx();
                    BarTip.Caption = ChildMenu_Error;
                    BarTip.Hint = Error;
                }
                BarTip.Visibility = BarItemVisibility.Always;
                Sys_Page sys_Page = new Sys_Page();
                if (Provider.SysPage != null)
                {
                    sys_Page = Provider.SysPage;
                }
                //BaseService.SaveLog(Error, Detail, (byte)Sys_Log_Type.Information, sys_Page.Menu_Id);
            }
        }
        /// <summary>
        /// 显示错误消息框
        /// </summary>
        /// <param name="Error">提示文本</param>
        /// <param name="type">错误类型</param>
        public static void ShowError(string Error, MessageBoxIcon type = MessageBoxIcon.Error)
        {
            string ChildMenu_Error = "页面错误";
            if (!string.IsNullOrEmpty(Provider.Get("ChildMenu_Error").ToStringEx()))
                ChildMenu_Error = Provider.Get("ChildMenu_Error").ToStringEx();
            XtraMessageBox.Show(Error, ChildMenu_Error, MessageBoxButtons.OK, type);
            Sys_Page sys_Page = new Sys_Page();
            if (Provider.SysPage != null)
            {
                sys_Page = Provider.SysPage;
            }
            //BaseService.SaveLog(ChildMenu_Error, Error, (byte)Sys_Log_Type.Information, sys_Page.Menu_Id);
        }
        /// <summary>
        /// 显示错误消息框
        /// </summary>
        /// <param name="Error">提示文本</param>
        /// <param name="Detail">错误明细详情</param>
        /// <param name="type">错误类型</param>
        public static void ShowError(string Error, string Detail, MessageBoxIcon type = MessageBoxIcon.Error)
        {
            if (BaseService.CheckConfiguration("Global_ChildMenu_ShowErrorDetail").ToBoolEx())
            {
                XtraMessageBox.Show(Detail, Error, MessageBoxButtons.OK, type);
            }
            else
            {
                string ChildMenu_Error = "页面错误";
                if (!string.IsNullOrEmpty(Provider.Get("ChildMenu_Error").ToStringEx()))
                    ChildMenu_Error = Provider.Get("ChildMenu_Error").ToStringEx();
                XtraMessageBox.Show(Error, ChildMenu_Error, MessageBoxButtons.OK, type);
            }
            Sys_Page sys_Page = new Sys_Page();
            if (Provider.SysPage != null)
            {
                sys_Page = Provider.SysPage;
            }
            //BaseService.SaveLog(Error, Detail, (byte)Sys_Log_Type.Information, sys_Page.Menu_Id);
        }
        /// <summary>
        /// 确认窗口true:确认|false:取消
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool RaiseConfirm(string text)
        {
            try
            {
                bool flag = XtraMessageBox.Show(text, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                return flag;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }
        /// <summary>
        /// 显示错误信息，根据系统配置显示错误信息
        /// </summary>
        /// <param name="Error">Exception</param>
        public static void RaiseError(Exception Error)
        {
            if (BaseService.CheckConfiguration("Global_ChildMenu_ThrowException").ToBoolEx())
            {
                throw Error;
            }
            if (BaseService.CheckConfiguration("Global_ChildMenu_ShowErrorDetail").ToBoolEx())
            {
                if (BaseService.CheckConfiguration("Global_ChildMenu_ShowErrorMessageBox").ToBoolEx())
                {
                    ShowError(Error.Message, Error.ToJson());
                }
                else
                {
                    TipError(Error.Message, Error.ToJson());
                }
            }
            else
            {
                if (BaseService.CheckConfiguration("Global_ChildMenu_ShowErrorMessageBox").ToBoolEx())
                {
                    ShowError(Error.Message);
                }
                else
                {
                    TipError(Error.Message);
                }
            }
        }
        /// <summary>
        /// 显示错误信息，根据系统配置显示错误信息
        /// </summary>
        /// <param name="Error">提示文本</param>
        public static void RaiseError(string Error)
        {
            if (BaseService.CheckConfiguration("Global_ChildMenu_ShowErrorMessageBox").ToBoolEx())
            {
                ShowError(Error);
            }
            else
            {
                TipError(Error);
            }
        }
        /// <summary>
        /// 显示错误信息，根据系统配置显示错误信息
        /// </summary>
        /// <param name="Error">提示文本</param>
        /// <param name="Detail">错误详情</param>
        public static void RaiseError(string Error, string Detail)
        {
            if (BaseService.CheckConfiguration("Global_ChildMenu_ShowErrorMessageBox").ToBoolEx())
            {
                ShowError(Error, Detail);
            }
            else
            {
                TipError(Error, Detail);
            }
        }
        #endregion

        public static void TryLogin()
        {


            #region 用户尝试登录系统
            try
            {
                if (Provider.SysUser != null && BaseService.IsFaulted)
                    Provider.Remove("SysUser");
                if (Provider.SysUser == null)
                {
                    LoginPage login = new LoginPage();
                    login.TopMost = true;
                    login.ShowDialog();
                }
                if (Provider.SysUser == null)
                {
                    Process.GetCurrentProcess().Kill();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.StackTrace);
                Process.GetCurrentProcess().Kill();
            }
            #endregion

        }
        #region ShowProcess
        public static ProgressWindow progressWindow;
        public static void ShowProcess(Form parent, int process, int max = 100)
        {


            try
            {
                if (progressWindow == null || progressWindow.IsDisposed)
                {
                    progressWindow = new ProgressWindow();
                    progressWindow.ShowMdiChildCaptionInParentTitle = true;
                    progressWindow.DisableCancel();
                    progressWindow.reProgress.Properties.Maximum = max;
                    progressWindow.reProgress.EditValue = process;
                    progressWindow.ShowCenter(parent);
                }
                if (process < progressWindow.reProgress.Properties.Maximum)
                {
                    progressWindow.Text = string.Format("{0}/{1}", process, progressWindow.reProgress.Properties.Maximum);
                    progressWindow.reProgress.EditValue = process;
                    progressWindow.Refresh();
                }
                else
                {
                    progressWindow.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void ShowProcess(int step)
        {


            try
            {
                if (progressWindow != null)
                {
                    if ((int)progressWindow.reProgress.EditValue + step < progressWindow.reProgress.Properties.Maximum)
                    {
                        progressWindow.Text = string.Format("{0}/{1}", progressWindow.reProgress.EditValue, progressWindow.reProgress.Properties.Maximum);
                        progressWindow.reProgress.EditValue = (int)progressWindow.reProgress.EditValue + step;
                        progressWindow.Refresh();
                    }
                    else
                    {
                        progressWindow.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region LoadPage
        public static string SearchFile(string filePath, string fileName)
        {
            try
            {
                if (Directory.Exists(filePath))
                {
                    foreach (string fs in Directory.GetFiles(filePath, fileName))
                    {
                        return fs;
                    }
                    foreach (string ds in Directory.GetDirectories(filePath))
                    {
                        string sFile = SearchFile(ds, fileName);
                        if (!string.IsNullOrEmpty(sFile))
                        {
                            return sFile;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return null;
        }
        public static ChildPage LoadPage(Sys_Page sys_Page)
        {


            try
            {
                if (sys_Page != null)
                {
                    ChildPage myPage = null;
                    if (!string.IsNullOrEmpty(sys_Page.Menu_Path) && !string.IsNullOrEmpty(sys_Page.Menu_Class))
                    {
                        string sFile = Provider.StartupPath + sys_Page.Menu_Path;
                        //本地文件自动查找文件
                        if (!sFile.Contains("://") && !File.Exists(sFile))
                        {
                            sFile = SearchFile(Application.StartupPath, sys_Page.Menu_Path);
                        }

                        if (!File.Exists(sFile))
                        {
                            throw new Exception($"未能找到菜单文件：{sys_Page.Menu_Path}");
                        }
                        myPage = (ChildPage)ReflectionHelper.LoadForm(sFile, sys_Page.Menu_Class);
                    }
                    if (myPage == null)
                    {
                        myPage = new ChildPage();
                    }
                    myPage.Name = sys_Page.Menu_Name;
                    myPage.Text = sys_Page.Menu_Nick;
                    myPage.SysPage = sys_Page;
                    myPage.SysMenu = null;
                    return myPage;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public static ChildPage LoadPage(string menuId)
        {


            try
            {
                List<Sys_Menu> MenuData = Provider.UserMenus;
                Sys_Menu sys_Menu = MenuData.Find(m => m.Menu_Id == menuId);
                if (sys_Menu == null) return null;
                List<MyParameter> myParameters = new List<MyParameter>();
                myParameters.Add("@Menu_Id", DbType.String, sys_Menu.Menu_Page, null);
                DataTable dt = BaseService.Open("SystemMenu_Single", myParameters);
                Sys_Page sys_Page = EntityHelper.GetEntity<Sys_Page>(dt);
                ChildPage childPage = LoadPage(sys_Page);
                childPage.Text = sys_Menu.Menu_Nick;
                childPage.SysMenu = sys_Menu;
                return childPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public static ChildPage LoadPage(Sys_Menu sys_Menu)
        {
            try
            {
                ChildPage page = LoadPage(sys_Menu.Menu_Id);
                return page;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }

        }
        #endregion
        #region EasyColumn
        public static string NodePath(this TreeListNode tln, string fieldName, string spliter = @"\")
        {
            try
            {
                string path = tln.GetDisplayText(fieldName);
                while (tln.ParentNode != null)
                {
                    tln = tln.ParentNode;
                    path = tln.GetDisplayText(fieldName) + spliter + path;
                }
                return path;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        /// <summary>
        /// 将GridView列复制到TreeList
        /// </summary>
        /// <param name="sourceGrid">源表格</param>
        /// <param name="targetTree">目标树</param>
        public static void CopyColumn(GridView sourceGrid, TreeList targetTree)
        {
            foreach (GridColumn item in sourceGrid.Columns.OrderBy(c => c.VisibleIndex))
            {
                if (targetTree.Columns[item.FieldName] == null)
                {
                    TreeListColumn tc = new TreeListColumn();
                    tc.FieldName = item.FieldName;
                    tc.Caption = item.Caption;
                    tc.ColumnEdit = item.ColumnEdit;
                    tc.VisibleIndex = item.VisibleIndex;
                    tc.Visible = item.Visible;
                    tc.Width = item.Width;
                    tc.OptionsColumn.AllowEdit = item.OptionsColumn.AllowEdit;
                    tc.OptionsColumn.ReadOnly = item.OptionsColumn.ReadOnly;
                    targetTree.Columns.Add(tc);
                }
            }
        }
        /// <summary>
        /// 将GridView列复制到GridView
        /// </summary>
        /// <param name="sourceGrid">源表格</param>
        /// <param name="targetGrid">目标表格</param>
        public static void CopyColumn(GridView sourceGrid, GridView targetGrid)
        {
            foreach (GridColumn item in sourceGrid.Columns)
            {
                if (targetGrid.Columns[item.FieldName] == null)
                {
                    GridColumn tc = ReflectionHelper.CopyProperty<GridColumn, GridColumn>(item);
                    targetGrid.Columns.Add(tc);
                }
            }
        }

        #endregion
        public static void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；
        {
            try
            {
                DateTime current = DateTime.Now;
                while (current.AddMilliseconds(Millisecond) > DateTime.Now)
                {
                    Application.DoEvents();//转让控制权            
                }
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public static void CallWithTimeout(Action action, int timeoutMilliseconds, Form mForm)
        {
            Action wrappedAction = () =>
            {
                action();
            };
            IAsyncResult result = wrappedAction.BeginInvoke(null, null);
            if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds))
            {
                wrappedAction.EndInvoke(result);
            }
            else
            {
                mForm.Cursor = Cursors.WaitCursor;
            }
        }
        public static void FunctionStart()
        {
            //
        }
        public static void FunctionEnd()
        {
            //
        }
    }
}