/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.Data;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Designer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSpreadsheet;
using MyRapid.Base;
using MyRapid.Code;
using MyRapid.GlobalLocalizer;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static MyRapid.SysEntity.Sys_Enum;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.UserSkins;
using DevExpress.Skins;
namespace MyRapid.Base
{
    public partial class ChildPage : DevExpress.XtraEditors.XtraForm
    {
        public ChildPage()
        {
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            InitializeComponent();
            this.HandleCreated += delegate
            {
                //Form 和 Control 类公开一组与应用程序启动和关闭相关的事件。 Windows 窗体应用程序启动时，主窗体的启动事件将按照以下顺序引发：
                //Control.HandleCreated
                //Control.BindingContextChanged
                //Form.Load
                //Control.VisibleChanged
                //Form.Activated
                //Form.Shown
                InitializePage();
            };
        }

        #region Region Public
        private Dictionary<string, DataTable> dSet = new Dictionary<string, DataTable>();
        private GroupControl _QueryControl;
        public GroupControl QueryControl
        {
            get
            {
                return _QueryControl;
            }
            set
            {
                _QueryControl = value;
            }
        }
        public List<Sys_Bind> BindList = new List<Sys_Bind>();
        public List<Sys_WorkSet> WorkSetList = new List<Sys_WorkSet>();
        public List<Sys_Button> ButtonList = new List<Sys_Button>();
        public List<MyParameter> ParameterList = new List<MyParameter>();
        [Browsable(false)]
        public string ObjectId
        {
            get; set;
        }
        private BarItem _InfoTip;
        [Browsable(false)]
        public BarItem InfoTip
        {
            get
            {
                if (_InfoTip == null)
                {
                    _InfoTip = new BarLargeButtonItem();
                    _InfoTip.Name = Guid.NewGuid().ToString();
                    BarItemLink itemLink = BaseStatus.AddItem(_InfoTip);
                }
                return _InfoTip;
            }
            set
            {
                _InfoTip = value;
            }
        }
        [Browsable(false)]
        public DevExpress.Utils.ImageCollection LargeIconList
        {
            get
            {
                return (DevExpress.Utils.ImageCollection)Provider.Get("LargeIconList");
            }
        }
        [Browsable(false)]
        public DevExpress.Utils.ImageCollection SmallIconList
        {
            get
            {
                return (DevExpress.Utils.ImageCollection)Provider.Get("SmallIconList");
            }
        }
        #endregion
        #region Initialize 
        public Sys_Page SysPage = null;
        public Sys_Menu SysMenu = null;

        private void InitializePage()
        {
            try
            {
                if (!this.DesignMode && SysPage != null)
                {
                    //
                    InitializeForeign();
                    InitializeIcon();
                    InitializeLayout();
                    //初始按钮
                    InitializeTool();
                    //自动变更按钮状态
                    InitializeHandler(this);
                    //初始WorkSet
                    InitializeWorkSet();
                    //初始查询框
                    InitializeQuery();
                    //初始验证数据
                    InitializeValidation();
                    InitializeGridControl();
                    InitializeSubmitControl();
                    InitializeFormat();
                    InitializeChart();
                    InitializeTree();
                    InitializeGroupPanel();
                    InitializeValidationBaseEdit();
                    //
                    //Global_Query_PageLoad_Open
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }

        #region InitializePageConfiguration
        private void InitializePageConfiguration()
        {
            if (BaseService.CheckConfiguration("Global_Query_PageLoad_Open").ToBoolEx())
            {
                Sys_Button sys_Button = ButtonList.Find(b => b.Button_Sub == "Open" && b.Button_Visible && b.Button_Enabled);
                if (sys_Button != null && sys_Button.Button_BarItem != null)
                {
                    //BarItem barItem = (BarItem)sys_Button.Button_BarItem;
                    //barItem.PerformClick();
                    this.Open();
                }
            }

        }
        #endregion
        #region InitializeChart
        private void InitializeChart()
        {


            try
            {
                if (SysPage != null)
                {
                    foreach (Sys_WorkSet sys_WorkSet in WorkSetList.Where(w => w.WorkSet_Type == (byte)Sys_WorkSet_Type.Chart))
                    {
                        Control[] controls = this.Controls.Find(sys_WorkSet.WorkSet_Grid, true);
                        if (controls.Length > 0)
                        {
                            Control control = controls[0];
                            if (control.GetType().Equals(typeof(ChartControl)))
                            {
                                //加载布局
                                List<MyParameter> myParameters = new List<MyParameter>();
                                myParameters.Add("@Chart_WorkSet", DbType.String, sys_WorkSet.WorkSet_Id, null);
                                DataTable dt = BaseService.Open("SystemWorkSet_Chart", myParameters);
                                Sys_Chart sys_Chart = EntityHelper.GetEntity<Sys_Chart>(dt);
                                if (sys_Chart == null) return;
                                ChartControl chartControl = (ChartControl)control;
                                chartControl.LoadFromStream(new MemoryStream(sys_Chart.Chart_Bytes, true));
                                //脚在数据源
                                myParameters.Clear();
                                myParameters = InitializeBind(sys_WorkSet.WorkSet_Id, true);
                                chartControl.DataSource = BaseService.Open(sys_WorkSet.WorkSet_Id, myParameters);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        #endregion
        #region InitializeForeign
        private Sys_User Current_User = new Sys_User();
        private BarButtonItem BarTip;
        private void InitializeForeign()
        {


            BarTip = (BarButtonItem)Provider.Get("BarTip");
            if (BarTip == null)
            {
                BarTip = new BarButtonItem();
            }
            Current_User = Provider.SysUser;

        }
        #endregion
        #region InitializeReport
        protected XtraReport InitializeReport(string rptName)
        {
            try
            {
                List<MyParameter> mps = new List<MyParameter>();
                mps.Add("@Report_Id", DbType.String, rptName, null);
                List<Sys_Report> rpts = BaseService.Open<Sys_Report>("SystemMenu_Report", mps);
                if (rpts.Count > 0)
                {
                    Sys_Report rpt = rpts[0];
                    string wk = rpt.Report_WorkSet;
                    if (string.IsNullOrEmpty(wk)) return null;
                    mps = InitializeBind(wk, true);
                    DataTable dt = BaseService.Open(wk, mps);
                    byte[] bytes = rpt.Report_Bytes;
                    if (bytes == null) return null;
                    XtraReport xtraReport = new XtraReport();
                    xtraReport.DataSource = dt;
                    xtraReport.LoadLayout(bytes.ToStream());
                    File.Delete(rptName);                 
                    return xtraReport;
             
                }
                return null;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
                return null;
            }
            finally
            {
            }

        }
        #endregion
        #region InitializeIcon
        private void InitializeIcon()
        {


            BaseBar.Images = SmallIconList;
            BaseBar.LargeImages = LargeIconList;

        }
        #endregion        
        #region InitializeWorkSet
        private void InitializeWorkSet()
        {


            try
            {
                if (SysPage == null) return;
                //绑定WorkSet
                #region 绑定WorkSet
                List<MyParameter> para_Sys_WorkSet = new List<MyParameter>();
                para_Sys_WorkSet.Add("@Menu_Id", DbType.String, SysPage.Menu_Id, null);
                DataTable dt_Sys_WorkSet = BaseService.Open("SystemMenu_WorkSet", para_Sys_WorkSet);
                List<Sys_WorkSet> sys_WorkSets = EntityHelper.GetEntities<Sys_WorkSet>(dt_Sys_WorkSet);
                WorkSetList.Clear();
                foreach (Sys_WorkSet sys_WorkSet in sys_WorkSets.OrderBy(w => w.WorkSet_ReadSort))
                {
                    dSet[sys_WorkSet.WorkSet_Name] = new DataTable();
                    if (!string.IsNullOrEmpty(sys_WorkSet.WorkSet_Grid))
                    {
                        Control[] controls = this.Controls.Find(sys_WorkSet.WorkSet_Grid, true);
                        if (controls.Length > 0)
                        {
                            foreach (Control control in controls)
                            {
                                if (control.GetType().Equals(typeof(GridControl)))
                                {
                                    sys_WorkSet.WorkSet_Control = control;
                                    break;
                                }
                                if (control.GetType().Equals(typeof(ChartControl)))
                                {
                                    sys_WorkSet.WorkSet_Control = control;
                                    break;
                                }
                            }
                        }
                    }
                    WorkSetList.Add(sys_WorkSet);
                }
                #endregion
                #region 绑定Bind
                List<MyParameter> para_Sys_Bind = new List<MyParameter>();
                para_Sys_Bind.Add("@Menu_Id", DbType.String, SysPage.Menu_Id, null);
                DataTable dt_Sys_Bind = BaseService.Open("SystemUser_Bind", para_Sys_Bind);
                List<Sys_Bind> sys_Binds = EntityHelper.GetEntities<Sys_Bind>(dt_Sys_Bind);
                BindList.AddRange(sys_Binds);
                #endregion
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        #endregion
        #endregion
        private void ChildMenu_Shown(object sender, EventArgs e)
        {
            if (!this.DesignMode && SysPage != null)
            {
                InitializePageConfiguration();
            }
        }
        #region SetControl
        /// <summary>
        /// 根据控件名称获取控件
        /// </summary>
        /// <param name="controlName">控件名称</param>
        /// <returns></returns>
        protected Control GetControl(string controlName)
        {
            try
            {
                if (string.IsNullOrEmpty(controlName)) return null;
                Control[] pushControls = this.Controls.Find(controlName, true);
                if (pushControls.Length > 0)
                {
                    return pushControls[0];
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
        /// <summary>
        /// 根据控件名称获取父控件的子控件
        /// </summary>
        /// <param name="parentControl">父控件</param>
        /// <param name="controlName">控件名称</param>
        /// <returns></returns>
        protected Control GetControl(Control parentControl, string controlName)
        {
            try
            {
                if (string.IsNullOrEmpty(controlName)) return null;
                Control[] pushControls = parentControl.Controls.Find(controlName, true);
                if (pushControls.Length > 0)
                {
                    return pushControls[0];
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
        /// <summary>
        /// 根据控件名称获取控件
        /// </summary>
        /// <param name="controlName">控件名称</param>
        /// <returns></returns>
        protected Control GetControl(string controlName, Type type)
        {
            try
            {
                if (string.IsNullOrEmpty(controlName)) return null;
                Control[] pushControls = this.Controls.Find(controlName, true);
                if (pushControls.Length > 0)
                {
                    foreach (Control item in pushControls)
                    {
                        if (ConvertHelper.IsBaseOn(item, type))
                            return item;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
            return null;
        }
        /// <summary>
        /// 根据控件名称获取父控件的子控件
        /// </summary>
        /// <param name="parentControl">父控件</param>
        /// <param name="controlName">控件名称</param>
        /// <returns></returns>
        protected Control GetControl(Control parentControl, string controlName, Type type)
        {
            try
            {
                if (string.IsNullOrEmpty(controlName)) return null;
                Control[] pushControls = parentControl.Controls.Find(controlName, true);
                if (pushControls.Length > 0)
                {
                    foreach (Control item in pushControls)
                    {
                        if (ConvertHelper.IsBaseOn(item, type))
                            return item;
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
        /// <summary>
        /// 设置控件属性
        /// </summary>
        /// <param name="parentControl">父控件</param>
        /// <param name="controlName">控件名称</param>
        /// <param name="value">值</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        protected bool SetValue(Control parentControl, string controlName, object value, string propertyName = "Text")
        {
            try
            {
                if (string.IsNullOrEmpty(controlName)) return false;
                bool rtn = true;
                Control[] bindControls = parentControl.Controls.Find(controlName, true);
                if (bindControls.Length > 0)
                {
                    foreach (Control item in bindControls)
                    {
                        if (!ReflectionHelper.SetProperty(item, propertyName, value))
                        {
                            rtn = false;
                        }
                    }
                }
                return rtn;
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
        /// 设置控件属性
        /// </summary>
        /// <param name="controlName">控件名称</param>
        /// <param name="value">值</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        protected bool SetValue(string controlName, object value, string propertyName = "Text")
        {
            try
            {
                if (string.IsNullOrEmpty(controlName)) return false;
                bool rtn = true;
                Control[] bindControls = this.Controls.Find(controlName, true);
                if (bindControls.Length > 0)
                {
                    foreach (Control item in bindControls)
                    {
                        if (!ReflectionHelper.SetProperty(item, propertyName, value))
                        {
                            rtn = false;
                        }
                    }
                }
                return rtn;
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
        /// 设置控件属性
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="value">值</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        protected bool SetValue(Control control, object value, string propertyName = "Text")
        {
            try
            {
                return ReflectionHelper.SetProperty(control, propertyName, value);
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
        /// 获取控件属性
        /// </summary>
        /// <param name="parentControl">父控件</param>
        /// <param name="controlName">控件名称</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        protected object GetValue(Control parentControl, string controlName, string propertyName = "Text")
        {
            try
            {
                if (string.IsNullOrEmpty(controlName)) return null;
                bool rtn = true;
                Control[] bindControls = parentControl.Controls.Find(controlName, true);
                if (bindControls.Length > 0)
                {
                    foreach (Control item in bindControls)
                    {
                        return ReflectionHelper.GetProperty(item, propertyName);
                    }
                }
                return rtn;
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
        /// 获取控件属性
        /// </summary>
        /// <param name="controlName">控件名称</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        protected object GetValue(string controlName, string propertyName = "Text")
        {
            try
            {
                if (string.IsNullOrEmpty(controlName)) return null;
                if (controlName.IndexOf(".") > 0)
                {
                    string gd = controlName.Substring(0, controlName.IndexOf("."));
                    Control[] gds = this.Controls.Find(gd, true);
                    if (gds.Length > 0)
                    {
                        if (gds[0].GetType().Equals(typeof(GridControl)))
                        {
                            GridControl tgd = (GridControl)gds[0];
                            GridView tabv = (GridView)tgd.MainView;
                            string col = controlName.Substring(controlName.IndexOf(".") + 1);
                            return tabv.GetFocusedRowCellValue(col);
                        }
                    }
                }
                Control[] bindControls = this.Controls.Find(controlName, true);
                if (bindControls.Length > 0)
                {
                    foreach (Control item in bindControls)
                    {
                        return ReflectionHelper.GetProperty(item, propertyName);
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
        /// <summary>
        /// 获取控件属性
        /// </summary>
        /// <param name="control">控件</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns></returns>
        protected object GetValue(Control control, string propertyName = "Text")
        {
            try
            {
                return ReflectionHelper.GetProperty(control, propertyName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        private void LockControl(Control control, bool isLock)
        {
            try
            {
                foreach (var item in control.Controls)
                {
                    if (ConvertHelper.IsBaseOn(item, typeof(BaseEdit)))
                    {
                        BaseEdit baseEdit = (BaseEdit)item;
                        baseEdit.ReadOnly = isLock;
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
        }
        #endregion
    }
}