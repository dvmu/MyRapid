/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.Utils;
using DevExpress.XtraBars.Localization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraLayout.Localization;
using DevExpress.XtraNavBar;
using DevExpress.XtraPrinting.Localization;
using DevExpress.XtraReports.Localization;
using DevExpress.XtraRichEdit.Localization;
using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraSpreadsheet.Localization;
using DevExpress.Diagram.Core.Localization;
using DevExpress.XtraTabbedMdi;
using DevExpress.XtraTreeList.Localization;
using MyRapid.Base;
using MyRapid.Code;
using MyRapid.GlobalLocalizer;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static MyRapid.SysEntity.Sys_Enum;
using System.Text;
using System.IO;
using DevExpress.LookAndFeel;
using MyRapid.Images;
using System.Diagnostics;
using DevExpress.UserSkins;
using DevExpress.Skins;
namespace MyRapid.Base
{
    public partial class MainPage : XtraForm
    {
        public MainPage()
        {
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            InitializeComponent();
            //ThreadHelper.Start(PostUserInfo);
        }
        protected void PostUserInfo()
        {

            try
            {
                WebHelper.IpInfo ip = WebHelper.GetWanIp(Encoding.UTF8);
                if (ip != null)
                {
                    string info = "INFO={0}|{1}|{2}";
                    info = string.Format(info, WebHelper.HideIp(ip.ip), ip.address, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    WebHelper.PostRequest("http://www.rapidcoder.cn/wp-page/myPost.php", info);
                }
            }
            catch
            {
                throw;
            }
        }

        #region InitializeAppearance
        /// <summary>
        /// 设置配置字体
        /// </summary>
        protected void InitializeAppearance()
        {

            Sys_User sys_User = (Sys_User)Provider.SysUser;
            if (!string.IsNullOrEmpty(sys_User.User_Skin))
                UserLookAndFeel.Default.SetSkinStyle(sys_User.User_Skin);
            sys_User.User_FontSize = sys_User.User_FontSize > 0 ? sys_User.User_FontSize : 9;
            if (!string.IsNullOrEmpty(sys_User.User_FontName))
            {
                DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font(sys_User.User_FontName, sys_User.User_FontSize);
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new System.Drawing.Font(sys_User.User_FontName, sys_User.User_FontSize);
                // Specifies the default font of controls (except menus and toolbars).
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultMenuFont = new System.Drawing.Font(sys_User.User_FontName, sys_User.User_FontSize);
                //Specifies the default font used by menus and toolbars.
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultPrintFont = new System.Drawing.Font(sys_User.User_FontName, sys_User.User_FontSize);
            }
        }
        private void MainMenu_ControlAdded(object sender, ControlEventArgs e)
        {

            Sys_User sys_User = (Sys_User)Provider.SysUser;
            if (!string.IsNullOrEmpty(sys_User.User_FontName))
                e.Control.Font = new System.Drawing.Font(sys_User.User_FontName, sys_User.User_FontSize);
        }
        #endregion
        /// <summary>
        /// 加载全局配置文件
        /// </summary>
        protected void InitializeGlobalConfiguration()
        {

            try
            {
                DataTable dt = BaseService.Open("SystemConfiguration_Global", null);
                List<Sys_Configuration> sys_Configurations = EntityHelper.GetEntities<Sys_Configuration>(dt);
                CacheHelper.SetAsync(sys_Configurations, "SysConfiguration");
                Provider.Set("SysConfiguration", sys_Configurations);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected void InitializeLocalCache()
        {

            #region 缓存中读取配置
            try
            {
                //缓存中读取配置
                List<Sys_Configuration> SysConfiguration = CacheHelper.Get<List<Sys_Configuration>>("SysConfiguration");
                if (SysConfiguration != null)
                    Provider.Set("SysConfiguration", SysConfiguration);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
            #region 缓存中读取语言
            try
            {
                //缓存中读取语言
                //List<Sys_Globalization> SysGlobalization = CacheHelper.Get<List<Sys_Globalization>>("SysGlobalization");
                //if (SysGlobalization != null)
                //    Provider.Set("SysGlobalization", SysGlobalization);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion
        }
        protected void InitializeService()
        {

            try
            {
                DataTable dt = BaseService.Open("SystemService_All", null);
                List<Sys_Service> sys_Services = EntityHelper.GetEntities<Sys_Service>(dt);
                foreach (Sys_Service svr in sys_Services)
                {
                    Timer timer = new Timer();
                    int ti = 1000 * svr.Service_Unit * svr.Service_Interval;
                    timer.Interval = ti > 0 ? ti : 1000;
                    timer.Tick += delegate
                    {
                        //加载页面
                        if (!string.IsNullOrEmpty(svr.Service_Page))
                        {
                            ChildPage cp = SharedFunc.LoadPage(svr.Service_Page);
                            if (cp == null || cp.SysPage == null) return;
                            switch ((Sys_Menu_Show)cp.SysPage.Menu_Show)
                            {
                                case Sys_Menu_Show.MdiChild:
                                    cp.MdiParent = this;
                                    cp.Show();
                                    break;
                                case Sys_Menu_Show.Dialog:
                                    cp.ShowDialog();
                                    break;
                                case Sys_Menu_Show.NewForm:
                                    cp.Show();
                                    break;
                                default:
                                    break;
                            }
                        }
                        //执行WorkSet
                        if (!string.IsNullOrEmpty(svr.Service_WorkSet))
                        {
                            BaseService.Execute(svr.Service_WorkSet, null);
                        }
                        //执行文件
                        if (!string.IsNullOrEmpty(svr.Service_File))
                        {
                            Process.Start(svr.Service_File, svr.Service_Parameter);
                        }
                        if (svr.Service_Once)
                        {
                            timer.Enabled = false;
                        }
                    };
                    timer.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 加载多国语言
        /// </summary>
        protected void InitializeGlobalLocalizer()
        {

            try
            {
                //DataTable dt = BaseService.Open("SystemGlobalization_All", null);
                //List<Sys_Globalization> sys_Globalizations = EntityHelper.GetEntities<Sys_Globalization>(dt);
                //CacheHelper.SetAsync(sys_Globalizations, "SysGlobalization");
                //Provider.Set("SysGlobalization", sys_Globalizations);
                Localizer.Active = new MyLocalizer();
                BarLocalizer.Active = new MyBarLocalizer();
                GridLocalizer.Active = new MyGridLocalizer();
                LayoutLocalizer.Active = new MyLayoutLocalizer();
                NavBarLocalizer.Active = new MyNavBarLocalizer();
                ReportLocalizer.Active = new MyReportLocalizer();
                PreviewLocalizer.Active = new MyPreviewLocalizer();
                TreeListLocalizer.Active = new MyTreeListLocalizer();
                SchedulerLocalizer.Active = new MySchedulerLocalizer();
                XtraRichEditLocalizer.Active = new MyXtraRichEditLocalizer();
                DiagramControlLocalizer.Active = new MyDiagramControlLocalizer();
                //XtraRichEditResLocalizer.Active = new MyXtraRichEditResLocalizer();
                XtraSpreadsheetLocalizer.Active = new MyXtraSpreadsheetLocalizer();
                //XtraSpreadsheetResLocalizer.Active = new MyXtraSpreadsheetResLocalizer();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 加载单个多国语言
        /// </summary>
        /// <param name="localizer">定位器</param>
        protected void InitializeGlobalLocalizer2(string localizer)
        {

            try
            {
                List<MyParameter> myParameters = new List<MyParameter>();
                myParameters.Add("@Globalization_Localizer", DbType.String, localizer, null);
                DataTable dt = BaseService.Open("SystemGlobalization_All", myParameters);
                List<Sys_Globalization> sys_Globalizations = EntityHelper.GetEntities<Sys_Globalization>(dt);
                Provider.Set("Sys_Globalization", sys_Globalizations);
                //Localizer.Active = new MyLocalizer();
                //BarLocalizer.Active = new MyBarLocalizer();
                //GridLocalizer.Active = new MyGridLocalizer();
                //LayoutLocalizer.Active = new MyLayoutLocalizer();
                //NavBarLocalizer.Active = new MyNavBarLocalizer();
                //ReportLocalizer.Active = new MyReportLocalizer();
                //PreviewLocalizer.Active = new MyPreviewLocalizer();
                //TreeListLocalizer.Active = new MyTreeListLocalizer();
                //SchedulerLocalizer.Active = new MySchedulerLocalizer();
                //XtraRichEditLocalizer.Active = new MyXtraRichEditLocalizer();
                //DiagramControlLocalizer.Active = new MyDiagramControlLocalizer();
                ////XtraRichEditResLocalizer.Active = new MyXtraRichEditResLocalizer();
                //XtraSpreadsheetLocalizer.Active = new MyXtraSpreadsheetLocalizer();
                //XtraSpreadsheetResLocalizer.Active = new MyXtraSpreadsheetResLocalizer();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //private Assembly IconAssembly;
        /// <summary>
        /// 加载图标
        /// </summary>
        protected void InitializeImage()
        {

            try
            {
                //FirstImage();
                //这句没有任何意义，只是为了让程序加载这个dll
                IconList ic = new IconList();
                Assembly[] assemblys = AppDomain.CurrentDomain.GetAssemblies();
                foreach (Assembly IconAssembly in assemblys)
                {
                    AssemblyName aName = IconAssembly.GetName();
                    if (aName.Name == "MyRapid.Images")
                    {
                        DataTable dt = BaseService.Open("SystemMenu_Icon", null);
                        //List<string> names = ImageCollectionUtils.GetImageResourceNames(IconAssembly);
                        if (dt == null) return;
                        foreach (DataRow dr in dt.Rows)
                        {
                            string name = dr[0].ToStringEx();
                            Image img = ImageCollectionUtils.GetImage(IconAssembly, name + "_32x32.png");
                            if (img == null)
                                img = ImageHelper.DrawIcon(32, Color.SkyBlue, "空", new Font("楷体", 16), Color.Black);
                            LargeIconList.Images.Add(img, name);
                            Image img2 = ImageCollectionUtils.GetImage(IconAssembly, name + "_16x16.png");
                            if (img2 == null)
                                img2 = ImageHelper.DrawIcon(16, Color.SkyBlue, "空", new Font("楷体", 8), Color.Black);
                            SmallIconList.Images.Add(img2, name);
                        }
                        Provider.Set("SmallIconList", SmallIconList);
                        Provider.Set("LargeIconList", LargeIconList);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //private void FirstImage()
        //{
        //    
        //    
        //    
        //    //--iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAuIgAALiIBquLdkgAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAANbSURBVDhPhZN7TBR3EMdnn7cnC3gkJw/rQQWqgWI5MFbB1kgfGuMjRO0h10issYnV1ESNtf5RTdOmJSmtBe2xh9YUHxD01HjA7er5wmhpTc1RnyQUH6mc8VV8lRy3+5vub0Fp/+psdnbzm/l+diazA4gI4XAYPB4PVCzxMHOmz4e5M+dB+aLF8Mn6JSl6bMN237aVRe8tXgRVSz32qqUVIs2NRCKW1nJ+vx+o2QQJChfmluXPyilxjBLZjmb7scHbE/XeyJyrTmeibCUBBwwDoKrqvwA7/SyYV/Za+aO3nslY0u0wljennxmMJOCDcw6MdZdiYEdGY+te2Ost5+dRjKapzAtAw48KTw+za5ldRb1gFByH2KthDoPh0cbjUxJGO9IMcl1GvGPDWI/0NDEBHMHWENUy1LH12xRwuhMKS5pSD005LxjTgqP0lxsZfdVuO7kfTid3f3Phvd/tsSc9wmD3z/x1SYSk9raRFph9Z3ZOyOvkHk+7ymPxSc4oDSVhcWA0vtNkxwtaBvaeSifd+/Pi/YE3yVbvpBpabbvWPtJCU5dSlvsr4JSzHHFrQIqOmHcAcHqLQNQPS0hXcSW5kLGKXJTWxh9Knw/4YK4vFApxppanAE7x+bnk96Fmchs8KDzA6nkNacT5xWzMXP4lOS9vIdeEj/GcZELAS24L6zAOmzGqdhW8qKC+fmiML322S7X98AvCN5d0qfoWlipXUHNX45/8euwrqMEe16f6I9iEHfDBpbOhEw5Ty1KA4Pv+W2DGv/Z6soYE9gwMMPv/1t2BKM44/YjsKN9NoswacqegNh5fGDDqsrx1MggpQbWNaocASt1WgLQJbttxsxwNUTxoYObhp4brhI7ezZ16VNyEfVlfG1jWjNuLVtTSasPqUZ5Wb7Xgb2iwWkiYUVkpL6v5zra6sdHehii1xPXUPffxp5QFf/0hb+zvy/yq/93E/FlmKqOp2sgU/IpiATjLA/CpWa7JLTduvtFJ9KkVW1qrATrHssk5qSC7hlPAnIKltZwyvAucIHKms/5KW3LKmKTsvHxzAeyXeeHZ2xzMpOciy1nf+e8uPAcMxUyj6/LcGAiOGxc+nZN7xYyaKZwV+x+AaQzLMhwv0DenILziFsUqesyyLH0MAxD+AVP7vHlMludtAAAAAElFTkSuQmCC
        //    //--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
        //    string s32 = "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";
        //    Image f32 = s32.ToImage();
        //    LargeIconList.Images.Add(f32, "default");
        //    string s16 = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAuIgAALiIBquLdkgAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAANbSURBVDhPhZN7TBR3EMdnn7cnC3gkJw/rQQWqgWI5MFbB1kgfGuMjRO0h10issYnV1ESNtf5RTdOmJSmtBe2xh9YUHxD01HjA7er5wmhpTc1RnyQUH6mc8VV8lRy3+5vub0Fp/+psdnbzm/l+diazA4gI4XAYPB4PVCzxMHOmz4e5M+dB+aLF8Mn6JSl6bMN237aVRe8tXgRVSz32qqUVIs2NRCKW1nJ+vx+o2QQJChfmluXPyilxjBLZjmb7scHbE/XeyJyrTmeibCUBBwwDoKrqvwA7/SyYV/Za+aO3nslY0u0wljennxmMJOCDcw6MdZdiYEdGY+te2Ost5+dRjKapzAtAw48KTw+za5ldRb1gFByH2KthDoPh0cbjUxJGO9IMcl1GvGPDWI/0NDEBHMHWENUy1LH12xRwuhMKS5pSD005LxjTgqP0lxsZfdVuO7kfTid3f3Phvd/tsSc9wmD3z/x1SYSk9raRFph9Z3ZOyOvkHk+7ymPxSc4oDSVhcWA0vtNkxwtaBvaeSifd+/Pi/YE3yVbvpBpabbvWPtJCU5dSlvsr4JSzHHFrQIqOmHcAcHqLQNQPS0hXcSW5kLGKXJTWxh9Knw/4YK4vFApxppanAE7x+bnk96Fmchs8KDzA6nkNacT5xWzMXP4lOS9vIdeEj/GcZELAS24L6zAOmzGqdhW8qKC+fmiML322S7X98AvCN5d0qfoWlipXUHNX45/8euwrqMEe16f6I9iEHfDBpbOhEw5Ty1KA4Pv+W2DGv/Z6soYE9gwMMPv/1t2BKM44/YjsKN9NoswacqegNh5fGDDqsrx1MggpQbWNaocASt1WgLQJbttxsxwNUTxoYObhp4brhI7ezZ16VNyEfVlfG1jWjNuLVtTSasPqUZ5Wb7Xgb2iwWkiYUVkpL6v5zra6sdHehii1xPXUPffxp5QFf/0hb+zvy/yq/93E/FlmKqOp2sgU/IpiATjLA/CpWa7JLTduvtFJ9KkVW1qrATrHssk5qSC7hlPAnIKltZwyvAucIHKms/5KW3LKmKTsvHxzAeyXeeHZ2xzMpOciy1nf+e8uPAcMxUyj6/LcGAiOGxc+nZN7xYyaKZwV+x+AaQzLMhwv0DenILziFsUqesyyLH0MAxD+AVP7vHlMludtAAAAAElFTkSuQmCC";
        //    Image f16 = s16.ToImage();
        //    SmallIconList.Images.Add(f16, "default");
        //    
        //}
        /// <summary>
        /// 加载菜单
        /// </summary>
        protected void InitializeMenu()
        {

            try
            {
                Dictionary<string, int> iconDictionary = new Dictionary<string, int>();
                List<Sys_Menu> MenuData;
                DataTable dt = BaseService.Open("SystemUser_Menu", null);
                MenuData = EntityHelper.GetEntities<Sys_Menu>(dt);
                foreach (Sys_Menu sys_Menu in MenuData)
                {
                    if (SmallIconList.Images.Keys.Contains(sys_Menu.Menu_Icon))
                        sys_Menu.Menu_IconIndex = SmallIconList.Images.Keys.IndexOf(sys_Menu.Menu_Icon);
                }
                Provider.UserMenus = MenuData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 自动更新
        /// </summary>
        protected void InitializeAutoUpdate()
        {

            try
            {
                if (!BaseService.CheckConfiguration("Global_MainUI_AllowAutoUpdate").ToBoolEx()) return;
                string version = ConfigurationHelper.ReadSetting("version");
                List<MyParameter> myParameters = new List<MyParameter>();
                myParameters.Add("@FileInput_Version", DbType.String, version, null);
                List<Sys_FileInput> sys_FileInputs = BaseService.Open<Sys_FileInput>("SystemUpdate_Files", myParameters);
                foreach (Sys_FileInput sys_FileInput in sys_FileInputs.OrderBy(f => f.Create_Time))
                {
                    if (sys_FileInput.FileInput_Bytes != null)
                    {
                        File.WriteAllBytes(sys_FileInput.FileInput_Relative, sys_FileInput.FileInput_Bytes);
                    }
                }
                ConfigurationHelper.SaveSetting("version", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 加载页面
        /// </summary>
        /// <param name="sys_Menu"></param>
        /// <returns></returns>
        protected Sys_Menu InitializePage(Sys_Menu sys_Menu)
        {

            try
            {
                List<MyParameter> myParameters = new List<MyParameter>();
                myParameters.Add("@Menu_Id", DbType.String, sys_Menu.Menu_Page, null);
                DataTable dt = BaseService.Open("SystemMenu_Single", myParameters);
                Sys_Menu sys_Page = EntityHelper.GetEntity<Sys_Menu>(dt);
                return sys_Page;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
    }
}