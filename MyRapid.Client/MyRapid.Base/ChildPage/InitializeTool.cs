/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Designer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSpreadsheet;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace MyRapid.Base
{
    public partial class ChildPage : DevExpress.XtraEditors.XtraForm
    {
        #region Enabled Disabled Tool
        private Dictionary<string, int> iconDictionary = new Dictionary<string, int>();
        protected void RefreshTool()
        {


            BaseBar.BeginUpdate();
            BaseTool.BeginUpdate();
            BaseTool.ItemLinks.Clear();
            BaseStatus.BeginUpdate();
            BaseStatus.ItemLinks.Clear();
            BaseBar.Items.Clear();
            foreach (Sys_Button sys_Button in ButtonList.OrderBy(b => b.Button_Parent).ThenBy(b => b.Button_Sort))
            {
                BarLargeButtonItem barButtonItem = null;
                if (barButtonItem == null)
                {
                    barButtonItem = new BarLargeButtonItem();
                    barButtonItem.Name = sys_Button.Button_Id;
                    sys_Button.Button_BarItem = barButtonItem;
                    RefreshTool(sys_Button);
                    //按钮存在父级
                    if (!string.IsNullOrEmpty(sys_Button.Button_Parent))
                    {
                        BarLargeButtonItem parentBarItem = (BarLargeButtonItem)BaseBar.Items[sys_Button.Button_Parent];
                        if (parentBarItem != null)
                        {
                            PopupMenu popupMenu = (PopupMenu)parentBarItem.DropDownControl;
                            if (popupMenu == null)
                            {
                                popupMenu = new PopupMenu();
                                parentBarItem.DropDownControl = popupMenu;
                                popupMenu.Manager = BaseBar;  //没有这一行会导致按钮Enabled=false时候出错
                                parentBarItem.ActAsDropDown = true;
                                parentBarItem.ButtonStyle = BarButtonStyle.DropDown;
                            }
                            BarItemLink itemLink = popupMenu.AddItem(barButtonItem);
                            itemLink.BeginGroup = sys_Button.Button_BeginGroup;
                        }
                    }
                    else
                    {
                        if (sys_Button.Button_Assign.Equals(0))
                        {
                            BarItemLink itemLink = BaseTool.AddItem(barButtonItem);
                            itemLink.BeginGroup = sys_Button.Button_BeginGroup;
                        }
                        else
                        {
                            BarItemLink itemLink = BaseStatus.AddItem(barButtonItem);
                            itemLink.BeginGroup = sys_Button.Button_BeginGroup;
                        }
                    }
                    barButtonItem.ItemClick += new ItemClickEventHandler(this.InitializeToolClick);
                }
            }
            if (BaseTool.ItemLinks.Count.Equals(0))
            {
                BaseTool.Visible = false;
            }
            else
            {
                BaseTool.Visible = true;
            }
            if (BaseStatus.ItemLinks.Count.Equals(0))
            {
                BaseStatus.Visible = false;
            }
            else
            {
                BaseStatus.Visible = true;
            }
            BaseTool.EndUpdate();
            BaseStatus.EndUpdate();
            BaseBar.EndUpdate();

        }

        protected void RefreshTool(Sys_Button sys_Button)
        {


            BarLargeButtonItem barButtonItem = (BarLargeButtonItem)sys_Button.Button_BarItem;
            if (barButtonItem != null)
            {
                barButtonItem.Enabled = sys_Button.Button_Enabled;
                barButtonItem.Visibility = (BarItemVisibility)((!sys_Button.Button_Visible).ToIntEx());
                BarShortcut barShortcut = new BarShortcut((Keys)sys_Button.Button_Key | (Keys)sys_Button.Button_SecondKey);
                barButtonItem.ItemShortcut = barShortcut;
                barButtonItem.ShowItemShortcut = DevExpress.Utils.DefaultBoolean.True;
                barButtonItem.Caption = sys_Button.Button_Nick;
                barButtonItem.Hint = sys_Button.Button_Hint ?? sys_Button.Button_Nick;
                if (SmallIconList != null && SmallIconList.Images[sys_Button.Button_Icon] != null)
                {
                    barButtonItem.ImageOptions.Image = SmallIconList.Images[sys_Button.Button_Icon];
                }
                if (sys_Button.Button_IsLarge)
                {
                    barButtonItem.ImageOptions.LargeImage = LargeIconList.Images[sys_Button.Button_Icon];
                }
                barButtonItem.Alignment = (BarItemLinkAlignment)sys_Button.Button_Alignment;
                barButtonItem.CaptionAlignment = (BarItemCaptionAlignment)sys_Button.Button_CaptionAlignment;
                barButtonItem.PaintStyle = BarItemPaintStyle.CaptionGlyph;
            }

        }
        private void HidePopupMenu()
        {
            foreach (BarLargeButtonItem barItem in BaseBar.Items)
            {
                PopupMenu popupMenu = (PopupMenu)barItem.DropDownControl;
                if (popupMenu != null)
                {
                    if (popupMenu.ItemLinks.Where(i => i.Enabled == true).Count() == 0)
                    {
                        barItem.Visibility = BarItemVisibility.Never;
                    }
                    else
                    {
                        barItem.Visibility = BarItemVisibility.Always;
                    }
                }
            }
        }
        private void ToggleTool()
        {


            if (!AutoToggleTool) return;
            if (this.IsInitializing) return;
            GridControl grid = FocusedGrid();
            if (grid != null && grid.DataSource != null)
            {
                GridView view = (GridView)grid.MainView;
                if (view.OptionsBehavior.Editable)
                {
                    ToggleToolByName("Edit", true);
                }
                else
                {
                    ToggleToolByName("Edit", false);
                }
                if (view.OptionsBehavior.AllowAddRows != DevExpress.Utils.DefaultBoolean.False)
                {
                    ToggleToolByName("Add", true);
                    ToggleToolByName("Import", true);
                }
                else
                {
                    ToggleToolByName("Add", false);
                    ToggleToolByName("Import", false);
                }
                if (view.OptionsBehavior.AllowDeleteRows != DevExpress.Utils.DefaultBoolean.False)
                {
                    ToggleToolByName("Remove", true);
                }
                else
                {
                    ToggleToolByName("Remove", false);
                }
                ToggleToolByName("Export", true);
            }
            else
            {
                ToggleToolByName("Remove", false);
                ToggleToolByName("Add", false);
                ToggleToolByName("Import", false);
                ToggleToolByName("Export", false);
            }
            if (FocusedChart() != null)
            {
                ToggleToolByName("Design", true);
            }
            else
            {
                ToggleToolByName("Design", false);
            }

        }
        private bool autoToggleTool = true;
        /// <summary>
        /// 自动切换工具按钮状态
        /// </summary>
        [Browsable(false)]
        public bool AutoToggleTool
        {
            get
            {
                return autoToggleTool;
            }
            set
            {
                autoToggleTool = value;
            }
        }
        protected void ToggleToolByName(string toolName, bool enabled)
        {
            try
            {

                Sys_Button sys_Button = ButtonList.Find(b => b.Button_Sub != null && b.Button_Sub.Equals(toolName));
                if (sys_Button != null)
                {
                    BaseBar.BeginUpdate();
                    sys_Button.Button_Enabled = enabled;
                    BarLargeButtonItem barButtonItem = (BarLargeButtonItem)sys_Button.Button_BarItem;
                    barButtonItem.Enabled = enabled;
                    BaseBar.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void Control_GotFocus(object sender, EventArgs e)
        {


            ToggleTool();

        }
        private void InitializeHandler(Control ParentControl)
        {


            foreach (Control control in ParentControl.Controls)
            {
                control.GotFocus += Control_GotFocus;
                InitializeHandler(control);
            }

        }
        #endregion
        #region InitializeTool
        private List<Sys_Button> InitializeTool()
        {


            try
            {
                if (SysPage == null) return null;
                BaseTool.ItemLinks.Clear();
                List<MyParameter> myParameters = new List<MyParameter>();
                myParameters.Add("@Menu_Id", DbType.String, SysPage.Menu_Id, null);
                //DataTable dt = BaseService.Open_Sys_WorkSet("Read_Sys_Button", myParameters);
                DataTable dt = BaseService.Open("SystemUser_Button", myParameters);
                List<Sys_Button> sys_Buttons = EntityHelper.GetEntities<Sys_Button>(dt);
                ButtonList = sys_Buttons;
                RefreshTool();
                return ButtonList;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
            }
            return null;
        }
        //protected bool ValidateChildrenEx()
        //{
        //}
        //private bool ValidateChildrenSub(Control pctrl)
        //{
        //    foreach (Control ctrl  in pctrl.Controls )
        //    {
        //        CancelEventArgs cancelEventArgs = new CancelEventArgs();
        //        ctrl.ev
        //        //    new CancelEventHandler(ctrl, cal) 
        //        //{
        //        //};
        //    }
        //}
        [Browsable(false)]
        public bool ToolPress { get; set; }
        #region 按钮点击过程
        // 点击之前将状态图标设置为当前图标并且清除颜色
        // 点击成功将颜色设为绿色
        // 点击出错将颜色设为红色
        // 不论成功与否都会执行AfterToolClick
        // 最后一次点击按钮延时3秒后清除颜色
        protected virtual void BeforeToolClick(BarItem barItem)
        {
            try
            {
                BarButtonItem barTip = (BarButtonItem)Provider.Get("BarTip");
                if (barTip != null)
                {
                    barTip.ImageOptions.Image = barItem.ImageOptions.Image;
                    barTip.Caption = barItem.Caption;
                    barTip.ItemAppearance.Normal.Options.UseBackColor = false;
                    lastTime = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected virtual void AfterToolClick(BarItem barItem)
        {
            try
            {
                ThreadHelper.Start(ResetBarTip);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private DateTime lastTime;
        private void ResetBarTip()
        {
            try
            {
                BarButtonItem barTip = (BarButtonItem)Provider.Get("BarTip");
                while (DateTime.Now.AddMilliseconds(-3000) < lastTime)
                {
                    SharedFunc.Delay(100);
                }
                barTip.ItemAppearance.Normal.Options.UseBackColor = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        protected virtual void SucceedToolClick(BarItem barItem)
        {
            try
            {
                BarButtonItem barTip = (BarButtonItem)Provider.Get("BarTip");
                barTip.ItemAppearance.Normal.Options.UseBackColor = true;
                barTip.ItemAppearance.Normal.BackColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected virtual void CatchToolClick(BarItem barItem, Exception ex)
        {
            try
            {
                BarButtonItem barTip = (BarButtonItem)Provider.Get("BarTip");
                barTip.ItemAppearance.Normal.Options.UseBackColor = true;
                barTip.ItemAppearance.Normal.BackColor = System.Drawing.Color.Red;
                barTip.Caption = ex.Message;
                barTip.Hint = ex.StackTrace;
            }
            catch (Exception iex)
            {
                throw iex;
            }
        }
        #endregion
        public BarItem LastButton = null;
        private void InitializeToolClick(object sender, ItemClickEventArgs e)
        {


            //this.UseWaitCursor = Cursors.WaitCursor;
            LastButton = e.Item;
            BeforeToolClick(e.Item);
            try
            {
                ToolPress = true;
                sw.Restart();
                Sys_Button sys_Button = ButtonList.Find(b => !string.IsNullOrEmpty(b.Button_Sub) && b.Button_Id != null && b.Button_Id.Equals(e.Item.Name));
                if (sys_Button != null)
                {
                    if (sys_Button.Button_Validation)
                    {
                        //只验证可见控件
                        if (!this.ValidateChildren(ValidationConstraints.Visible)) return; //throw new Exception("Validate Field");
                    }
                    //BaseService.SaveLog(sys_Button.Button_Nick, sys_Button.Button_Hint, (byte)Sys_Enum.Sys_Log_Type.Operation, sys_Button.Button_Page);
                    if (sys_Button.Button_Confirm)
                    {
                        string cTxt = Provider.Get("ChildPage_ConfirmCaption").ToStringEx();
                        string tTxt = Provider.Get("ChildPage_ConfirmText").ToStringEx();
                        if (XtraMessageBox.Show(tTxt, cTxt, MessageBoxButtons.YesNo) != DialogResult.Yes)
                        {
                            sw.Stop();
                            return;
                        }
                    }
                    string parameter = sys_Button.Button_Parameter;
                    if (!string.IsNullOrEmpty(parameter))
                    {
                        ReflectionHelper.LoadMethod(this, sys_Button.Button_Sub, new object[] { parameter });
                    }
                    else
                    {
                        ReflectionHelper.LoadMethod(this, sys_Button.Button_Sub, new object[] { });
                    }
                    if (sys_Button.Button_Open)
                    {
                        Sys_Button Open_Button = ButtonList.Find(b => b.Button_Sub == "Open" && b.Button_Visible && b.Button_Enabled);
                        if (Open_Button != null)
                        {
                            this.Open();
                        }
                    }
                }
                BarTip.Caption = string.Format("{0}：{1}", e.Item.Caption, TimeDiff(sw));
                SucceedToolClick(e.Item);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ex = ex.InnerException;
                SharedFunc.RaiseError(ex);
                CatchToolClick(e.Item, ex);
            }
            finally
            {
                //this.Cursor = Cursors.Default;
                ToolPress = false;
                AfterToolClick(e.Item);
            }

        }

        #endregion
        #region virtual void

        protected void SetSource(GridControl gridControl, object dataSource)
        {
            GridView gv = (GridView)gridControl.MainView;

            var focusedRowHandle = gv.FocusedRowHandle;
            gv.BeginUpdate();
            gridControl.DataSource = dataSource;
            gv.ClearSelection();
            gv.FocusedRowHandle = focusedRowHandle;
            gv.SelectRow(focusedRowHandle);
            gv.EndUpdate();
            gv.MakeRowVisible(focusedRowHandle);
        }


        private Stopwatch sw = new Stopwatch();
        public virtual void Open()
        {


            try
            {
                //清除文件列表
                FileDictionary.Clear();
                foreach (var sys_WorkSet in WorkSetList.OrderBy(w => w.WorkSet_ReadSort))
                {
                    if (string.IsNullOrEmpty(sys_WorkSet.WorkSet_Trigger))
                    {
                        if (sys_WorkSet.WorkSet_Control != null && sys_WorkSet.WorkSet_Control.GetType().Equals(typeof(GridControl)))
                        {
                            GridControl gd = (GridControl)sys_WorkSet.WorkSet_Control;
                            if (gd != null)
                            {
                                List<MyParameter> QueryParameters = InitializeBind(sys_WorkSet.WorkSet_Id, true);

                                SetSource(gd, BaseService.Open(sys_WorkSet.WorkSet_Name, QueryParameters));

                            }
                        }
                        if (sys_WorkSet.WorkSet_Control != null && sys_WorkSet.WorkSet_Control.GetType().Equals(typeof(ChartControl)))
                        {
                            ChartControl chart = (ChartControl)sys_WorkSet.WorkSet_Control;
                            if (chart != null)
                            {
                                List<MyParameter> QueryParameters = InitializeBind(sys_WorkSet.WorkSet_Id, true);
                                chart.DataSource = BaseService.Open(sys_WorkSet.WorkSet_Name, QueryParameters);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public virtual void Open(string workSetName)
        {


            try
            {
                var sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Name == workSetName);
                if (sys_WorkSet != null)
                {
                    if (string.IsNullOrEmpty(sys_WorkSet.WorkSet_Trigger))
                    {
                        if (sys_WorkSet.WorkSet_Control != null && sys_WorkSet.WorkSet_Control.GetType().Equals(typeof(GridControl)))
                        {
                            GridControl gd = (GridControl)sys_WorkSet.WorkSet_Control;
                            if (gd != null)
                            {
                                List<MyParameter> QueryParameters = InitializeBind(sys_WorkSet.WorkSet_Id, true);
                                SetSource(gd, BaseService.Open(sys_WorkSet.WorkSet_Name, QueryParameters));
                            }
                        }
                        if (sys_WorkSet.WorkSet_Control != null && sys_WorkSet.WorkSet_Control.GetType().Equals(typeof(ChartControl)))
                        {
                            ChartControl chart = (ChartControl)sys_WorkSet.WorkSet_Control;
                            if (chart != null)
                            {
                                List<MyParameter> QueryParameters = InitializeBind(sys_WorkSet.WorkSet_Id, true);
                                chart.DataSource = BaseService.Open(sys_WorkSet.WorkSet_Name, QueryParameters);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private string TimeDiff(Stopwatch sw)
        {
            try
            {
                sw.Stop();
                int M = sw.Elapsed.Milliseconds;
                int S = sw.Elapsed.Seconds;
                string sc = "{0}.{1}";
                sc = String.Format(sc, S, M);
                //barTip.Caption = sc;           
                return sc;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
            }
        }
        public virtual void Edit()
        {


            GridControl targetControl = FocusedGrid();
            if (targetControl != null)
            {
                GridControl gd = (GridControl)targetControl;
                GridView abv = (GridView)gd.MainView;
                if (abv.OptionsBehavior.Editable == false)
                {
                    abv.OptionsBehavior.Editable = true;
                    abv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
                    abv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
                }
                else
                {
                    GridEditingMode gem = abv.OptionsBehavior.EditingMode;
                    abv.OptionsBehavior.EditingMode = GridEditingMode.EditForm;
                    abv.ShowEditForm();
                    abv.OptionsBehavior.EditingMode = gem;
                }
            }

        }
        private ChartControl FocusedChart()
        {


            try
            {
                Control targetControl = this.ActiveControl;
                if (targetControl == null) return null;
                if (targetControl.GetType() != typeof(ChartControl) && ConvertHelper.IsBaseOn(targetControl, typeof(ContainerControl)))
                {
                    targetControl = ((ContainerControl)targetControl).ActiveControl;
                }
                if (targetControl == null) return null;
                while (targetControl.GetType() != typeof(ChartControl) && targetControl.Parent != null)
                {
                    targetControl = targetControl.Parent;
                }
                if (targetControl != null && targetControl.GetType().Equals(typeof(ChartControl)))
                    return (ChartControl)targetControl;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
            }
            return null;
        }
        private GridControl FocusedGrid()
        {


            try
            {
                Control targetControl = this.ActiveControl;
                //LayoutControl lyc = (LayoutControl)targetControl;
                if (targetControl == null) return null;
                if (targetControl.GetType() != typeof(GridControl) && ConvertHelper.IsBaseOn(targetControl, typeof(ContainerControl)))
                {
                    targetControl = ((ContainerControl)targetControl).ActiveControl;
                }
                if (targetControl == null) return null;
                while (targetControl.GetType() != typeof(GridControl) && targetControl.Parent != null)
                {
                    targetControl = targetControl.Parent;
                }
                if (targetControl != null && targetControl.GetType().Equals(typeof(GridControl)))
                    return (GridControl)targetControl;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
            }
            return null;
        }
        public virtual void Add()
        {


            GridControl targetControl = FocusedGrid();
            if (targetControl != null)
            {
                GridControl gd = (GridControl)targetControl;
                GridView abv = (GridView)gd.MainView;
                if (abv.OptionsBehavior.AllowAddRows != DevExpress.Utils.DefaultBoolean.False)
                {
                    abv.AddNewRow();
                    abv.CloseEditor();
                    abv.UpdateCurrentRow();
                }
            }

        }
        public virtual void Insert()
        {


            GridControl targetControl = FocusedGrid();
            if (targetControl != null)
            {
                GridControl gd = (GridControl)targetControl;
                GridView abv = (GridView)gd.MainView;
                if (abv.OptionsBehavior.AllowAddRows != DevExpress.Utils.DefaultBoolean.False)
                {
                    abv.CloseEditor();
                    abv.UpdateCurrentRow();
                    //abv.AddNewRow();
                    abv.BeginDataUpdate();
                    DataTable dt = (DataTable)abv.GridControl.DataSource;
                    int lastHandle = abv.GetFocusedDataSourceRowIndex();
                    dt.Rows.InsertAt(dt.NewRow(), lastHandle);
                    abv.EndDataUpdate();
                    InitializeNewRow(abv, new InitNewRowEventArgs(abv.GetRowHandle(lastHandle)));
                }
            }

        }
        public virtual void Copy()
        {


            GridControl targetControl = FocusedGrid();
            if (targetControl != null)
            {
                GridControl gd = (GridControl)targetControl;
                GridView abv = (GridView)gd.MainView;
                abv.CopyToClipboard();
            }

        }
        public virtual void Paste()
        {


            GridControl targetControl = FocusedGrid();
            GridView abv = null;
            if (targetControl != null)
            {
                GridControl gd = (GridControl)targetControl;
                abv = (GridView)gd.MainView;
            }
            if (abv != null)
            {
                if (string.IsNullOrEmpty(abv.ActiveFilterString))
                {
                    DataTable dt = (DataTable)abv.GridControl.DataSource;
                    string sourceData = Clipboard.GetText().Trim();
                    foreach (string row in sourceData.Split('\r'))
                    {
                        if (!string.IsNullOrEmpty(row.Trim()))
                        {
                            int cellIndex = abv.FocusedRowHandle;
                            DataRow dr = dt.NewRow();
                            foreach (string cell in row.Trim().Split('\r'))
                            {
                                dr[cellIndex] = cell;
                                cellIndex += 1;
                            }
                            dt.Rows.InsertAt(dr, abv.GetDataSourceRowIndex(abv.FocusedRowHandle));
                        }
                    }
                }
            }

        }
        public virtual void Remove()
        {


            GridControl targetControl = FocusedGrid();
            if (targetControl != null)
            {
                GridControl gd = (GridControl)targetControl;
                GridView abv = (GridView)gd.MainView;
                if (abv.OptionsBehavior.AllowDeleteRows != DevExpress.Utils.DefaultBoolean.False)
                    abv.DeleteSelectedRows();
            }

        }
        [Browsable(false)]
        public bool IsSave { get; set; }
        public virtual void Save()
        {


            try
            {
                IsSave = true;
                //循环保存WorkSet
                foreach (var sys_WorkSet in WorkSetList.Where(w => w.WorkSet_Type.Equals((byte)Sys_Enum.Sys_WorkSet_Type.Grid) ||
                w.WorkSet_Type.Equals((byte)Sys_Enum.Sys_WorkSet_Type.Submit) ||
                w.WorkSet_Type.Equals((byte)Sys_Enum.Sys_WorkSet_Type.Tree)).OrderBy(w => w.WorkSet_SaveSort))
                {
                    //如果表格绑定的Grid不存在则提示错误
                    if (sys_WorkSet.WorkSet_Control == null)
                    {
                        throw new ArgumentNullException(sys_WorkSet.WorkSet_Grid);
                    }
                    GridControl gd = (GridControl)sys_WorkSet.WorkSet_Control;
                    DataTable dt = (DataTable)gd.DataSource;
                    if (dt != null)
                    {
                        gd.MainView.CloseEditor();
                        gd.MainView.UpdateCurrentRow();
                        //只传输变更行 减少传输数据量
                        DataTable cdt = dt.GetChanges();
                        if (cdt != null && cdt.Rows.Count > 0)
                        {
                            List<MyParameter> SaveParameters = InitializeBind(sys_WorkSet.WorkSet_Id, false);
                            var edt = BaseService.Save(sys_WorkSet.WorkSet_Name, cdt, SaveParameters);
                            if (edt != null && edt.HasErrors)
                            {
                                //有错误为了捕获错误行 再保存一次
                                edt = BaseService.Save(sys_WorkSet.WorkSet_Name, dt, SaveParameters);
                                gd.DataSource = edt;
                                throw new Exception(edt.GetErrors()[0].RowError);
                            }
                            SaveParameters = InitializeBind(sys_WorkSet.WorkSet_Id, true);
                            SetSource(gd, BaseService.Open(sys_WorkSet.WorkSet_Name, SaveParameters));
                        }
                    }
                }
                SaveFile();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IsSave = false;
            }

        }
        private void SaveFile()
        {
            try
            {
                foreach (var item in FileDictionary)
                {
                    BaseService.SaveFile(System.IO.File.ReadAllBytes(item.Value), item.Key);
                }
                FileDictionary.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
        public virtual void Clear()
        {


            try
            {
                if (this.QueryControl != null)
                {
                    foreach (Sys_Bind sys_Bind in BindList.Where(b => b.Bind_Type == 0).OrderBy(b => b.Bind_Sort))
                    {
                        Control[] Controls = this.QueryControl.Controls.Find(sys_Bind.Bind_Field, true);
                        if (Controls.Length > 0)
                        {
                            BaseEdit baseEdit = (BaseEdit)Controls[0];
                            baseEdit.Text = string.Empty;
                            baseEdit.EditValue = sys_Bind.Bind_Default;
                            if (baseEdit.GetType().Equals(typeof(CheckEdit)))
                            {
                                CheckEdit chkEdit = (CheckEdit)baseEdit;
                                chkEdit.Text = string.Empty;
                                chkEdit.Checked = sys_Bind.Bind_Default.ToBoolEx();
                            }
                            //RefreshEditValue
                            if (baseEdit.GetType().Equals(typeof(CheckedComboBoxEdit)))
                            {
                                CheckedComboBoxEdit chkComboBox = (CheckedComboBoxEdit)baseEdit;
                                chkComboBox.RefreshEditValue();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //if (this.QueryControl != null)
            //{
            //    InitializeQuery();
            //    //ClearControl(this.QueryControl);
            //}
            finally
            {
            }
        }
        private void ClearControl(Control ParentControl)
        {


            //    foreach (Control control in ParentControl.Controls)
            //{
            //    if (!ReflectionHelper.SetProperty(control, "EditValue", string.Empty))
            //    {
            //        ReflectionHelper.SetProperty(control, "Text", string.Empty);
            //    }
            //    if (control.HasChildren)
            //    {
            //        ClearControl(control);
            //    }
            //}

        }
        public virtual void Import()
        {


            Control targetControl = FocusedGrid();
            if (targetControl == null) return;
            if (targetControl.GetType().Equals(typeof(GridControl)))
            {
                try
                {
                    GridControl gd = (GridControl)targetControl;
                    GridView abv = (GridView)gd.MainView;
                    DataTable sdt = (DataTable)gd.DataSource;
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Excel|*.xls;*.xlsx";
                    if (openFileDialog.ShowDialog() != DialogResult.Cancel)
                    {
                        SharedFunc.ShowProcess(this, 0, 5);
                        SpreadsheetControl spreadsheetControl = new SpreadsheetControl();
                        spreadsheetControl.LoadDocument(openFileDialog.FileName);
                        SharedFunc.ShowProcess(1);
                        Worksheet worksheet = spreadsheetControl.Document.Worksheets.ActiveWorksheet;
                        CellCollection cellCollection = worksheet.Cells;
                        DataTable idt = worksheet.CreateDataTable(cellCollection.CurrentRegion, true);
                        //务必添加引用DevExpress.Docs.v16.2.dll
                        DataTableExporter exporter = worksheet.CreateDataTableExporter(cellCollection.CurrentRegion, idt, true);
                        exporter.Export();
                        SharedFunc.ShowProcess(1);
                        foreach (DataColumn dc in idt.Columns)
                        {
                            foreach (GridColumn bgc in abv.Columns)
                            {
                                if (bgc.Caption.Trim().Equals(dc.ColumnName.Trim()))
                                {
                                    dc.ColumnName = bgc.FieldName;
                                    break;
                                }
                            }
                        }
                        //克隆结构 变更数据类型
                        DataTable ndt = idt.Clone();
                        foreach (DataColumn dc in ndt.Columns)
                        {
                            foreach (DataColumn bgc in sdt.Columns)
                            {
                                if (bgc.Caption.Trim().Equals(dc.ColumnName.Trim()))
                                {
                                    dc.ColumnName = bgc.ColumnName;
                                    dc.DataType = bgc.DataType;
                                    break;
                                }
                            }
                        }
                        foreach (DataRow dr in idt.Rows)
                        {
                            DataRow ndr = ndt.NewRow();
                            foreach (DataColumn dc in idt.Columns)
                            {
                                ndr[dc.ColumnName] = dr[dc.ColumnName];
                            }
                            ndt.Rows.Add(ndr);
                        }
                        SharedFunc.ShowProcess(1);
                        sdt.Merge(ndt, true);
                        SharedFunc.ShowProcess(5);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    SharedFunc.ShowProcess(int.MaxValue);
                }
            }

        }
        public virtual void Export()
        {


            try
            {
                Control targetControl = FocusedGrid();
                if (targetControl == null) return;
                if (targetControl.GetType().Equals(typeof(GridControl)))
                {
                    GridControl gd = (GridControl)targetControl;
                    GridView abv = (GridView)gd.MainView;
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = this.Text;
                    saveFileDialog.Filter = "Excel|*.xlsx|Excel(2003)|*.xls|Docx|*.rtf|Pdf|*.pdf|Html|*.html|CSV|*.csv";
                    if (saveFileDialog.ShowDialog().Equals(DialogResult.OK))
                    {
                        switch (Path.GetExtension(saveFileDialog.FileName).ToLower())
                        {
                            case ".xls":
                                abv.ExportToXls(saveFileDialog.FileName);
                                break;
                            case ".xlsx":
                                abv.ExportToXlsx(saveFileDialog.FileName);
                                break;
                            case ".rtf":
                                abv.ExportToRtf(saveFileDialog.FileName);
                                break;
                            case ".pdf":
                                abv.ExportToPdf(saveFileDialog.FileName);
                                break;
                            case ".html":
                                abv.ExportToHtml(saveFileDialog.FileName);
                                break;
                            case ".cvs":
                                abv.ExportToCsv(saveFileDialog.FileName);
                                break;
                            default:
                                abv.ExportToXlsx(saveFileDialog.FileName);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public virtual void Print()
        {


            Control targetControl = FocusedGrid();
            if (targetControl == null) return;
            if (targetControl.GetType().Equals(typeof(GridControl)))
            {
                GridControl gd = (GridControl)this.ActiveControl;
                gd.Print();
            }

        }
        public virtual void Print(string doc)
        {


            if (!string.IsNullOrEmpty(doc))
            {
                XtraReport rpt = InitializeReport(doc);
                if (rpt != null)
                    rpt.Print();
            }

        }
        public virtual void Preview()
        {


            Control targetControl = FocusedGrid();
            if (targetControl == null) return;
            if (targetControl.GetType().Equals(typeof(GridControl)))
            {
                GridControl gd = (GridControl)this.ActiveControl;
                gd.ShowPrintPreview();
            }

        }
        public virtual void Preview(string doc)
        {


            if (!string.IsNullOrEmpty(doc))
            {
                XtraReport rpt = InitializeReport(doc);
                if (rpt != null)
                    rpt.ShowPreview();
            }

        }
        public virtual void Design()
        {


            try
            {
                if (FocusedChart() != null)
                {
                    ChartControl chartControl = FocusedChart();
                    Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Grid == chartControl.Name);
                    if (sys_WorkSet == null) return;
                    List<MyParameter> mps = new List<MyParameter>();
                    mps = InitializeBind(sys_WorkSet.WorkSet_Id, true);
                    DataTable dt = BaseService.Open(sys_WorkSet.WorkSet_Id, mps);
                    chartControl.DataSource = dt;
                    ChartDesigner chartDesigner = new ChartDesigner(chartControl);
                    if (chartDesigner.ShowDialog().Equals(DialogResult.OK))
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        chartControl.SaveToStream(memoryStream);
                        Sys_Chart sys_Chart = new Sys_Chart();
                        sys_Chart.Chart_Name = chartControl.Name;
                        sys_Chart.Chart_Nick = chartControl.Name;
                        sys_Chart.Chart_Bytes = memoryStream.ToArray();
                        sys_Chart.Chart_WorkSet = sys_WorkSet.WorkSet_Id;
                        sys_Chart.IsEnabled = true;
                        sys_Chart.IsDelete = false;
                        BaseService.Execute("SystemChart_Save", sys_Chart);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public virtual void Execute(string workSetName)
        {
            GridControl gd = this.FocusedGrid();
            if (gd != null)
            {
                GridView gv = (GridView)gd.MainView;
                foreach (var item in gv.GetSelectedRows())
                {
                    gv.FocusedRowHandle = item;

                    List<MyParameter> mps = new List<MyParameter>();
                    mps = InitializeBind(workSetName, true);
                    BaseService.Execute(workSetName, mps);
                    //this.Open();
                }
            }
            else
            {

                List<MyParameter> mps = new List<MyParameter>();
                mps = InitializeBind(workSetName, true);
                BaseService.Execute(workSetName, mps);
                //this.Open();
            }

        }
        #endregion
    }
}