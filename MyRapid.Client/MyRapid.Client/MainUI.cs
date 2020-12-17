/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.Diagram.Core.Localization;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Localization;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraTabbedMdi;
using MyRapid.Base;
using MyRapid.Code;
using MyRapid.GlobalLocalizer;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static MyRapid.SysEntity.Sys_Enum;
using System.Drawing;
using DevExpress.UserSkins;
using DevExpress.Skins;
namespace MyRapid.Client
{
    public partial class MainUI : MainPage
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        private Sys_User sys_User;
        /// <summary>
        /// 当前语言定位器
        /// </summary>
        private MyCommonLocalizer myCommonLocalizer = new MyCommonLocalizer();
        public MainUI()
        {


            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            //UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            InitializeLocalCache();
            #region 用户尝试登录系统
            SharedFunc.TryLogin();
            sys_User = Provider.SysUser;
            sw.Restart();
            #endregion
            #region 加载系统主界面
            try
            {
                #region InitializeComponent
                Provider.StartupPath = ConfigurationHelper.ReadSetting("StartupPath");
                SplashScreenManager.ShowForm(this, typeof(MyWait), false, false, false);
                InitializeAppearance();
                SendSpalsh(10, myCommonLocalizer.GetLocalizedString(MyCommonStringId.Initialize_GlobalLocalizer));
                //InitializeGlobalConfiguration();
                InitializeGlobalLocalizer();
                SendSpalsh(20, myCommonLocalizer.GetLocalizedString(MyCommonStringId.Initialize_Component));
                InitializeComponent();
                SkinHelper.InitSkinGalleryDropDown(mySkin);
                barUserNick.Caption = sys_User.User_Nick;
                SendSpalsh(50, myCommonLocalizer.GetLocalizedString(MyCommonStringId.Initialize_CommonLocalizer));
                InitializeCommonLocalizer();
                SendSpalsh(60, myCommonLocalizer.GetLocalizedString(MyCommonStringId.Initialize_Image));
                InitializeImage();
                SendSpalsh(80, myCommonLocalizer.GetLocalizedString(MyCommonStringId.Initialize_Menu));
                InitializeMenu();
                SendSpalsh(90, myCommonLocalizer.GetLocalizedString(MyCommonStringId.Initialize_Configuration));
                InitializeConfiguration();
                SendSpalsh(95, myCommonLocalizer.GetLocalizedString(MyCommonStringId.Initialize_AutoUpdate));
                //InitializeAutoUpdate();
                SendSpalsh(100, myCommonLocalizer.GetLocalizedString(MyCommonStringId.Initialize_Finish));
                //写日志
                SharedFunc.TipError(myCommonLocalizer.GetLocalizedString(MyCommonStringId.Login_Succeed), myCommonLocalizer.GetLocalizedString(MyCommonStringId.Login_SucceedDetail));
                //GC.Collect();
                #endregion
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
                Process.GetCurrentProcess().Kill();
                //Application.Exit();
                //Environment.Exit(0);
            }
            #endregion

        }
        /// <summary>
        /// 加载配置信息
        /// </summary>
        private void InitializeConfiguration()
        {

            //Global_MainUI_AllowUserSkinMenu
            if (BaseService.CheckConfiguration("Global_MainUI_AllowUserSkinMenu").ToBoolEx())
            {
                barSkin.Visibility = BarItemVisibility.Always;
            }
            else
            {
                barSkin.Visibility = BarItemVisibility.Never;
            }

        }
        /// <summary>
        /// 无意义  备用未删除临时函数
        /// </summary>
        private void InitializeTempLocalizer()
        {

            XtraLocalizer<DiagramControlStringId> diagramControlLocalizer = DiagramControlLocalizer.Active;
            for (int i = 0; i <= 588; i++)
            {
                string enumName = Enum.GetName(typeof(DiagramControlStringId), i);
                List<MyParameter> myParameters = new List<MyParameter>();
                myParameters.Add("@Globalization_Cultural", DbType.Int32, Provider.SysUser.User_Cultural, null);
                myParameters.Add("@Globalization_Partition", DbType.String, "Devexpress", null);
                myParameters.Add("@Globalization_Localizer", DbType.String, "MyDiagramControlLocalizer", null);
                myParameters.Add("@Globalization_Name", DbType.String, enumName, null);
                myParameters.Add("@Globalization_Nick", DbType.String, diagramControlLocalizer.GetLocalizedString((DiagramControlStringId)i), null);
                myParameters.Add("@Globalization_StringId", DbType.Int32, i, null);
                BaseService.Open("SystemGlobalization_Save", myParameters);
            }

        }
        /// <summary>
        /// 加载窗体控件语言
        /// </summary>
        private void InitializeCommonLocalizer()
        {

            this.Text = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MainUI_Text);
            barMenu.Hint = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_ShowHideMenuHint);
            barMenu.Caption = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_ShowHideMenu);
            barHelp.Hint = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_HelpHint);
            barHelp.Caption = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_Help);
            barUserNick.Hint = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_UserNickHint);
            barPageName.Hint = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_PageNameHint);
            barAuther.Hint = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_AuthorHint);
            barVersion.Hint = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_VersionHint);
            barPageName.Caption = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_PageNameHint);
            barAuther.Caption = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_AuthorHint);
            barVersion.Caption = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_VersionHint);
            barSkin.Caption = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_UserSkin);
            barSkin.Hint = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MenuCmd_UserSkinHint);
            barCloseThis.Caption = myCommonLocalizer.GetLocalizedString(MyCommonStringId.CloseMenu_This);
            barCloseOther.Caption = myCommonLocalizer.GetLocalizedString(MyCommonStringId.CloseMenu_Other);
            barCloseLeft.Caption = myCommonLocalizer.GetLocalizedString(MyCommonStringId.CloseMenu_Left);
            barCloseRight.Caption = myCommonLocalizer.GetLocalizedString(MyCommonStringId.CloseMenu_Right);
            barCloseAll.Caption = myCommonLocalizer.GetLocalizedString(MyCommonStringId.CloseMenu_All);
            Provider.Set("MainUI_Error", myCommonLocalizer.GetLocalizedString(MyCommonStringId.MainUI_Error));
            Provider.Set("ChildMenu_Error", myCommonLocalizer.GetLocalizedString(MyCommonStringId.ChildMenu_Error));
            Provider.Set("ChildPage_ConfirmCaption", myCommonLocalizer.GetLocalizedString(MyCommonStringId.ChildPage_ConfirmCaption));
            Provider.Set("ChildPage_ConfirmText", myCommonLocalizer.GetLocalizedString(MyCommonStringId.ChildPage_ConfirmText));

        }
        /// <summary>
        /// 向进度窗口发命令
        /// </summary>
        /// <param name="Int"></param>
        /// <param name="Text"></param>
        private void SendSpalsh(int Int, string Text)
        {

            MyWaitInfo myWaitInfo = new MyWaitInfo();
            myWaitInfo.ProgressInt = Int;
            myWaitInfo.ProgressText = Text;
            SplashScreenManager.Default.SendCommand(MyWait.SplashScreenCommand.Setinfo, myWaitInfo);

        }
        /// <summary>
        /// 窗体加载结束
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainUI_Shown(object sender, EventArgs e)
        {

            try
            {
                barTip.Caption = TimeDiff(sw);
                SplashScreenManager.CloseForm(false);
                this.Activate();
                Provider.Set("BarTip", barTip);
                Provider.Set("MyToast", myToast);
                Provider.Set("MyAlert", myAlert);
                //InitializeService();
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        Stopwatch sw = new Stopwatch();
        /// <summary>
        /// 计算时间差
        /// </summary>
        /// <param name="sw">计时器</param>
        /// <returns></returns>
        private string TimeDiff(Stopwatch sw)
        {

            try
            {
                sw.Stop();
                int M = sw.Elapsed.Milliseconds;
                int S = sw.Elapsed.Seconds;
                string sc = "{0}.{1}s";
                sc = String.Format(sc, S, M);
                return sc;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
                return string.Empty;
            }
            finally
            {

            }
        }
        private void MainUI_Load(object sender, EventArgs e)
        {

            try
            {
                MyTree.SelectImageList = (ImageCollection)Provider.Get("SmallIconList");
                MyTree.ImageIndexFieldName = "Menu_IconIndex";
                myMdi.Images = (ImageCollection)Provider.Get("SmallIconList");
                MyTree.DataSource = Provider.UserMenus;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        /// <summary>
        /// 判断菜单是否已经打开
        /// </summary>
        /// <param name="sys_Menu">系统菜单</param>
        /// <returns>返回布尔值</returns>
        private bool IsMenuOpen(Sys_Menu sys_Menu)
        {

            try
            {
                if (!BaseService.CheckConfiguration("Global_MainUI_MdiTabMenu_CheckDuplicate").ToBoolEx())
                {
                    return false;
                }
                foreach (Form tabPage in this.OwnedForms)
                {
                    ChildPage myPage = (ChildPage)tabPage;
                    Sys_Menu cys_Menu = myPage.SysMenu;
                    if (cys_Menu != null && cys_Menu.Menu_Id.Equals(sys_Menu.Menu_Id))
                    {
                        tabPage.Show();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
                return false;
            }
            finally
            {

            }
        }
        private void MyTree_DoubleClick(object sender, EventArgs e)
        {

            try
            {
                this.Cursor = Cursors.WaitCursor;
                sw.Restart();
                List<Sys_Menu> MenuData = (List<Sys_Menu>)Provider.UserMenus;
                Sys_Menu sys_Menu = MenuData[MyTree.FocusedNode.Id];

                if (string.IsNullOrEmpty(sys_Menu.Menu_Page)) return;
                if (!IsMenuOpen(sys_Menu))
                {
                    ImageCollection ims = (ImageCollection)MyTree.SelectImageList;
                    if (ims != null)
                        barTip.ImageOptions.Image = ims.Images[sys_Menu.Menu_IconIndex];// MyTree.FocusedNode.ImageIndex sys_Menu.Menu_IconIndex;
                    Sys_Menu sys_Page = InitializePage(sys_Menu);
                    if (sys_Page != null)
                    {
                        ChildPage myPage = SharedFunc.LoadPage(sys_Page);
                        if (myPage == null)
                        {
                            myPage = new ChildPage();
                        }
                        myPage.SysMenu = sys_Menu;
                        switch ((Sys_Menu_Show)sys_Page.Menu_Show)
                        {
                            case Sys_Menu_Show.MdiChild:
                                myPage.MdiParent = this;
                                myPage.Show();
                                break;
                            case Sys_Menu_Show.Dialog:
                                myPage.ShowDialog();
                                break;
                            case Sys_Menu_Show.NewForm:
                                myPage.Show();
                                break;
                            default:
                                break;
                        }
                    }
                }
                barTip.Caption = TimeDiff(sw);
                barTip.Hint = string.Empty;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }
        private void barHelp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {


            TextPage richPage = new TextPage();
            richPage.StartPosition = FormStartPosition.Manual;
            richPage.Top = this.Top;
            richPage.Height = this.Height;
            if (this.WindowState == FormWindowState.Maximized)
            {
                richPage.Left = this.Left + this.Width - richPage.Width;
            }
            else
            {
                richPage.Left = this.Left + this.Width;
            }
            richPage.FormClosing += delegate
            {
                CurMenu.Menu_Help = richPage.EditValue;
                List<MyParameter> mps = new List<MyParameter>();
                mps.Add("@Help_Rtf", DbType.String, CurMenu.Menu_Help, null);
                mps.Add("@Help_Menu", DbType.String, CurMenu.Menu_Id, null);
                BaseService.ExecuteAsync("SystemMenu_Help", mps, "U");
            };
            richPage.EditValue = CurMenu.Menu_Help;
            richPage.Show();


        }
        private void barMenu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            try
            {
                MyLeftPanel.Visible = !MyLeftPanel.Visible;
                splitterControl1.Visible = !splitterControl1.Visible;
                if (BaseService.CheckConfiguration("Global_MainUI_ShowHideMenu_ReloadData").ToBoolEx())
                {
                    if (MyLeftPanel.Visible)
                    {
                        InitializeMenu();
                        MyTree.DataSource = Provider.UserMenus;
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
            }

        }
        private Sys_Menu CurMenu;
        private void MyMdi_SelectedPageChanged(object sender, EventArgs e)
        {

            try
            {
                GC.Collect();
                if (myMdi.SelectedPage != null)
                {
                    //Read_Sys_Help_ForMenu
                    ChildPage myPage = (ChildPage)myMdi.SelectedPage.MdiChild;
                    PushSession(myPage);
                    Sys_Page sys_Page = myPage.SysPage;
                    if (sys_Page != null)
                    {
                        barPageName.Caption = sys_Page.Menu_Nick;
                        barVersion.Caption = sys_Page.Menu_Version;
                        barAuther.Caption = sys_Page.Menu_Author;
                        myMdi.SelectedPage.ImageIndex = 0;
                    }
                    Sys_Menu sys_Menu = myPage.SysMenu;
                    if (sys_Menu != null)
                    {
                        CurMenu = sys_Menu;
                        myMdi.SelectedPage.ImageIndex = (int)sys_Menu.Menu_IconIndex;
                        barPageName.Caption = sys_Menu.Menu_Nick;
                    }
                }
                else
                {
                    barPageName.Caption = string.Empty;
                    barVersion.Caption = string.Empty;
                    barAuther.Caption = string.Empty;
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        /// <summary>
        /// 存入Session
        /// </summary>
        /// <param name="myPage"></param>
        /// <returns></returns>
        protected void PushSession(ChildPage myPage)
        {

            try
            {
                Provider.SysPage = myPage.SysPage;
                Provider.CurrForm = myPage;
                Provider.Set(myPage.Name, myPage);
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (Provider.SysUser == null)
                return;
            string exitDetail = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MainUI_Exit);
            string exitText = myCommonLocalizer.GetLocalizedString(MyCommonStringId.MainUI_ExitDetail);
            if (XtraMessageBox.Show(exitText, exitDetail, MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }
            try
            {
                //SaveSkin to Database
                SharedFunc.TipError(myCommonLocalizer.GetLocalizedString(MyCommonStringId.MainUI_Exit_Succeed), myCommonLocalizer.GetLocalizedString(MyCommonStringId.MainUI_Exit_SucceedDetail));
                sys_User.User_Skin = UserLookAndFeel.Default.ActiveSkinName;
                BaseService.ExecuteAsync("SystemUser_Skin", sys_User);
            }
            catch //(Exception ex)
            {
                //SharedFunc.RaiseError(ex);
            }
            try
            {
                //SaveSkin to Cache
                List<Sys_Login> LoginInfos = CacheHelper.Get<List<Sys_Login>>("SysLogin");
                Sys_Login loginInfo = LoginInfos.Find(l => l.UserName.Equals(sys_User.User_Name));
                if (loginInfo != null)
                {
                    loginInfo.SkinName = UserLookAndFeel.Default.ActiveSkinName;
                    CacheHelper.SetAsync(LoginInfos, "SysLogin");
                }
            }
            catch //(Exception ex)
            {
                //SharedFunc.RaiseError(ex);
            }

        }
        private void MyLeftPanel_DoubleClick(object sender, EventArgs e)
        {

            if (!MyTree.Nodes.FirstNode.Expanded)
                MyTree.ExpandAll();
            else
                MyTree.CollapseAll();

        }

        #region closeMenu
        private void MyMdi_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right && ActiveMdiChild != null)
            {
                DevExpress.XtraTab.ViewInfo.BaseTabHitInfo hInfo = myMdi.CalcHitInfo(e.Location);
                //右键点击位置：在Page上且不在关闭按钮内
                if (hInfo.IsValid && hInfo.Page != null && !hInfo.InPageControlBox)
                {
                    this.closeMenu.ShowPopup(Control.MousePosition);//在鼠标位置弹出，而不是e.Location
                }
            }

        }
        //关闭当前
        private void barCloseThis_ItemClick(object sender, ItemClickEventArgs e)
        {

            this.myMdi.SelectedPage.MdiChild.Close();
            //this.ActiveMdiChild.Close();

        }
        //关闭其他
        private void barCloseOther_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraMdiTabPage xmp = this.myMdi.SelectedPage;
            while (this.myMdi.Pages[0] != xmp)
            {
                this.myMdi.Pages[0].MdiChild.Close();
            }
            while (this.myMdi.Pages[this.myMdi.Pages.Count - 1] != xmp)
            {
                this.myMdi.Pages[this.myMdi.Pages.Count - 1].MdiChild.Close();
            }

        }
        //关闭左边
        private void barCloseLeft_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraMdiTabPage xmp = this.myMdi.SelectedPage;
            while (this.myMdi.Pages[0] != xmp)
            {
                this.myMdi.Pages[0].MdiChild.Close();
            }

        }
        //关闭右边
        private void barCloseRight_ItemClick(object sender, ItemClickEventArgs e)
        {

            XtraMdiTabPage xmp = this.myMdi.SelectedPage;
            while (this.myMdi.Pages[this.myMdi.Pages.Count - 1] != xmp)
            {
                this.myMdi.Pages[this.myMdi.Pages.Count - 1].MdiChild.Close();
            }

        }
        //关闭所有
        private void barCloseAll_ItemClick(object sender, ItemClickEventArgs e)
        {

            while (this.myMdi.Pages.Count > 0)
            {
                this.myMdi.Pages[0].MdiChild.Close();
            }

        }
        #endregion

        /// <summary>
        /// 刷新当前登录用户
        /// </summary>
        private void MainUI_Activated(object sender, EventArgs e)
        {

            if (BaseService.IsFaulted)
            {
                Provider.SysUser = null;
            }
            sys_User = Provider.SysUser;
            if (sys_User != null)
            {
                barUserNick.Caption = Provider.SysUser.User_Nick;
            }
            else
            {
                SharedFunc.TryLogin();
            }
            if (Provider.SysUser == null)
            {
                Process.GetCurrentProcess().Kill();
            }
            sys_User = (Sys_User)Provider.SysUser;

        }


    }
}