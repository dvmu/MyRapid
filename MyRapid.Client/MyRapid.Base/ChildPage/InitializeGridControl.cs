/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.Data;
using DevExpress.Utils.Menu;
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraLayout;
using MyRapid.Base;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.Code;
using MyRapid.GlobalLocalizer;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using DevExpress.XtraEditors.Design;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.Data.Filtering;
namespace MyRapid.Base
{
    public partial class ChildPage : DevExpress.XtraEditors.XtraForm
    {
        #region InitializeGridControl
        Dictionary<GridColumn, Control> PushDic = new Dictionary<GridColumn, Control>();
        private void InitializeGridControl()
        {
            try
            {
                foreach (Sys_WorkSet sys_WorkSet in WorkSetList.Where(s => s.WorkSet_Type.Equals((byte)Sys_Enum.Sys_WorkSet_Type.Grid) ||
                s.WorkSet_Type.Equals((byte)Sys_Enum.Sys_WorkSet_Type.Submit) ||
                s.WorkSet_Type.Equals((byte)Sys_Enum.Sys_WorkSet_Type.Tree)))
                {
                    #region Initial Column
                    List<Sys_Bind> sys_Binds = BindList.Where(b => b.Bind_WorkSet == sys_WorkSet.WorkSet_Id).ToList();
                    GridControl grid = null;
                    if (sys_WorkSet.WorkSet_Control != null && sys_WorkSet.WorkSet_Control.GetType().Equals(typeof(GridControl)))
                        grid = (GridControl)sys_WorkSet.WorkSet_Control;
                    if (grid != null)
                    {
                        GridView abv = (GridView)grid.MainView;
                        abv.BeginUpdate();
                        //基本设置
                        abv.OptionsView.ColumnAutoWidth = false;
                        abv.OptionsView.BestFitMaxRowCount = 128;
                        abv.OptionsView.ShowFooter = false;
                        abv.OptionsView.ShowGroupPanel = false;
                        abv.OptionsBehavior.ImmediateUpdateRowPosition = false;
                        abv.OptionsBehavior.AutoExpandAllGroups = true;
                        abv.IndicatorWidth = 48;
                        abv.OptionsNavigation.AutoFocusNewRow = true;
                        abv.OptionsNavigation.EnterMoveNextColumn = true;
                        abv.OptionsSelection.MultiSelect = true;
                        //abv.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                        //页面初始时候是否允许编辑
                        if (BaseService.CheckConfiguration("GLOBAL_QUERY_PAGELOAD_LOCK").ToBoolEx())
                        {
                            abv.OptionsBehavior.Editable = false;
                            abv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                            abv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                        }
                        //没有插入的Sql 不可以添加
                        if (string.IsNullOrEmpty(sys_WorkSet.WorkSet_Insert))
                        {
                            abv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                        }
                        //没有删除的Sql 不可以删除
                        if (string.IsNullOrEmpty(sys_WorkSet.WorkSet_Delete))
                        {
                            abv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                        }
                        //没有更新的Sql 不可以编辑
                        if (string.IsNullOrEmpty(sys_WorkSet.WorkSet_Update))
                        {
                            abv.FocusedRowChanged += InitializeNewRowEditor;
                            abv.OptionsBehavior.Editable = false;
                        }
                        IsDeletable[abv.Name] = abv.OptionsBehavior.AllowDeleteRows;
                        IsAddable[abv.Name] = abv.OptionsBehavior.AllowDeleteRows;
                        IsEditable[abv.Name] = abv.OptionsBehavior.Editable;
                        //显示行号
                        abv.CustomDrawRowIndicator += InitializeRowIndicator;
                        //自动转CheckEdit
                        abv.DataSourceChanged += BindCheckEdit;
                        //行触发Trigger
                        abv.FocusedRowChanged += Abv_FocusedRowChanged;
                        //行触发Trigger
                        abv.DataSourceChanged += Abv_DataSourceChanged;
                        abv.InitNewRow += InitializeNewRow;
                        //行验证
                        grid.Validating += Grid_Validating;
                        //菜单控制
                        abv.PopupMenuShowing += Abv_PopupMenuShowing;
                        //单元格是否可编辑
                        abv.CellValueChanged += Abv_CellEditable;
                        //行是否可编辑
                        abv.FocusedRowChanged += Abv_FocusedRowEditable;
                        abv.DataSourceChanged += Abv_FocusedRowEditable;
                        abv.SelectionChanged += Abv_SelectionChanged;
                        //触发Push
                        grid.DataSourceChanged += PushData;
                        //自动调整列宽
                        abv.DataSourceChanged += delegate
                        {
                            if (BaseService.CheckConfiguration("GLOBAL_GRID_COLUMNS_BESTFIT").ToBoolEx())
                            {
                                abv.BestFitColumns();
                            }
                        };
                        //新行位置
                        //根据系统配置决定
                        abv.DataSourceChanged += Abv_NewItemRowPosition;
                        //分页变更自动执行查询 即翻页
                        if (!string.IsNullOrEmpty(sys_WorkSet.WorkSet_Pagination))
                        {
                            PageChanaged(grid);
                        }
                        //行拖拽
                        InitializeRowMove(grid);
                        #region GridColumn
                        foreach (Sys_Bind sys_Bind in sys_Binds.Where(b => !b.Bind_Name.StartsWith("@")).OrderBy(b => b.Bind_Sort))
                        {
                            GridColumn bgc = abv.Columns[sys_Bind.Bind_Field];
                            if (bgc == null)
                            {
                                bgc = new GridColumn();
                                bgc.Width = sys_Bind.Bind_Width;
                                if (sys_Bind.Bind_Width.Equals(0))
                                {
                                    bgc.Width = 80;
                                    abv.DataSourceChanged += delegate
                                      {
                                          bgc.MaxWidth = 350;
                                          bgc.MinWidth = 80;
                                          bgc.BestFit();
                                          bgc.MaxWidth = 0;
                                          bgc.MinWidth = 0;
                                      };
                                }
                                abv.Columns.Add(bgc);
                            }
                            bgc.Caption = sys_Bind.Bind_Nick;
                            if (!string.IsNullOrEmpty(sys_Bind.Bind_Popup))
                            {
                                string s = sys_Bind.Bind_Popup.ToStringEx();
                                RepositoryItem repositoryItem = InitializeRepositoryItem(sys_Bind);
                                if (repositoryItem != null)
                                {
                                    grid.RepositoryItems.Add(repositoryItem);
                                    bgc.ColumnEdit = repositoryItem;
                                }
                            }
                            if (bgc.ColumnEdit != null)
                            {
                                bgc.ColumnEdit.EditFormat.FormatString = sys_Bind.Bind_Format;
                                bgc.ColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            }
                            bgc.DisplayFormat.FormatString = sys_Bind.Bind_Format;
                            bgc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
                            bgc.FieldName = sys_Bind.Bind_Field;
                            bgc.Fixed = (FixedStyle)sys_Bind.Bind_Fix;
                            bgc.Name = "c_" + sys_Bind.Bind_Name;
                            //bgc.OwnerBand
                            bgc.AppearanceHeader.Options.UseTextOptions = true;
                            bgc.AppearanceHeader.TextOptions.HAlignment = (DevExpress.Utils.HorzAlignment)sys_Bind.Bind_TitleAlignment;
                            if (sys_Bind.Bind_ForeColor < 0)
                            {
                                bgc.AppearanceHeader.Options.UseForeColor = true;
                                bgc.AppearanceHeader.ForeColor = Color.FromArgb(sys_Bind.Bind_ForeColor);
                            }
                            bgc.AppearanceCell.Options.UseTextOptions = true;
                            bgc.AppearanceCell.TextOptions.HAlignment = (DevExpress.Utils.HorzAlignment)sys_Bind.Bind_TextAlignment;
                            bgc.OptionsColumn.AllowEdit = !sys_Bind.Bind_ReadOnly;
                            bgc.OptionsColumn.ReadOnly = sys_Bind.Bind_ReadOnly;
                            //bgc.OptionsColumn.AllowFocus = !sys_Bind.Bind_ReadOnly;
                            //bgc.Summary.Add((SummaryItemType)sys_Bind.Bind_Summary, sys_Bind.Bind_Field);
                            if (SummaryItemType.None != (SummaryItemType)sys_Bind.Bind_Summary)
                            {
                                abv.OptionsView.ShowFooter = true;
                                if (bgc.Summary.Count == 0)
                                {
                                    //统计
                                    GridColumnSummaryItem g = bgc.Summary.Add();
                                    g.SummaryType = (SummaryItemType)sys_Bind.Bind_Summary;
                                    g.FieldName = sys_Bind.Bind_Field; ;
                                    //g.DisplayFormat = g.GetDisplayFormatByType(g.SummaryType, true);
                                    //分组统计
                                    GridGroupSummaryItem gsi = new GridGroupSummaryItem();
                                    gsi.FieldName = sys_Bind.Bind_Field;
                                    gsi.SummaryType = (SummaryItemType)sys_Bind.Bind_Summary;
                                    gsi.DisplayFormat = gsi.GetDisplayFormatByType(gsi.SummaryType, true);
                                    gsi.ShowInGroupColumnFooter = bgc;
                                    abv.GroupSummary.Add(gsi);
                                }
                            }
                            bgc.ToolTip = sys_Bind.Bind_ToolTip;
                            bgc.VisibleIndex = sys_Bind.Bind_Sort;
                            bgc.Visible = sys_Bind.Bind_Visible;
                            bgc.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                            bgc.OptionsColumn.AllowMerge = sys_Bind.Bind_Merge ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
                            if (!abv.OptionsView.AllowCellMerge)
                                abv.OptionsView.AllowCellMerge = sys_Bind.Bind_Merge;
                            abv.HiddenEditor += delegate
                            {
                                abv.UpdateCurrentRow();
                            };
                            //计算公式
                            if (!string.IsNullOrEmpty(sys_Bind.Bind_Formula))
                            {
                                GridColumn ubgc = new GridColumn();
                                abv.Columns.Add(ubgc);
                                ubgc.FieldName = "Unbound_" + sys_Bind.Bind_Field;
                                ubgc.UnboundExpression = sys_Bind.Bind_Formula;
                                switch (sys_Bind.Bind_SqlDbType)
                                {
                                    case 10:
                                    case 11:
                                    case 12:
                                        ubgc.UnboundType = UnboundColumnType.Integer;
                                        break;
                                    case 7:
                                        ubgc.UnboundType = UnboundColumnType.Decimal;
                                        break;
                                    case 16:
                                        ubgc.UnboundType = UnboundColumnType.String;
                                        break;
                                    case 5:
                                    case 6:
                                    case 17:
                                    case 26:
                                        ubgc.UnboundType = UnboundColumnType.DateTime;
                                        break;
                                    case 3:
                                        ubgc.UnboundType = UnboundColumnType.Boolean;
                                        break;
                                    default:
                                        ubgc.UnboundType = UnboundColumnType.String;
                                        break;
                                }
                                abv.CellValueChanged += Abv_UnboundColumnValue;
                            }
                            //新行函数 默认值fn:开头的是函数  只有新行才会生效
                            if (!string.IsNullOrEmpty(sys_Bind.Bind_Default) && sys_Bind.Bind_Default.StartsWith("fn:"))
                            {
                                GridColumn ubgc = new GridColumn();
                                abv.Columns.Add(ubgc);
                                ubgc.FieldName = "NewRowUnbound_" + sys_Bind.Bind_Field;
                                ubgc.UnboundExpression = sys_Bind.Bind_Default.Remove(0, 3);
                                switch (sys_Bind.Bind_SqlDbType)
                                {
                                    case 10:
                                    case 11:
                                    case 12:
                                        ubgc.UnboundType = UnboundColumnType.Integer;
                                        break;
                                    case 7:
                                        ubgc.UnboundType = UnboundColumnType.Decimal;
                                        break;
                                    case 16:
                                        ubgc.UnboundType = UnboundColumnType.String;
                                        break;
                                    case 5:
                                    case 6:
                                    case 17:
                                    case 26:
                                        ubgc.UnboundType = UnboundColumnType.DateTime;
                                        break;
                                    case 3:
                                        ubgc.UnboundType = UnboundColumnType.Boolean;
                                        break;
                                    default:
                                        ubgc.UnboundType = UnboundColumnType.String;
                                        break;
                                }
                                abv.CellValueChanged += Abv_NewRowUnboundColumnValue;
                            }
                            //公式验证
                            foreach (Sys_Validation sys_Validation in ValidationList.Where(v => v.Validation_WorkSet == sys_WorkSet.WorkSet_Id && !string.IsNullOrEmpty(v.Validation_Formula) && v.Validation_FieldName == sys_Bind.Bind_Field))
                            {
                                GridColumn ubgc = new GridColumn();
                                abv.Columns.Add(ubgc);
                                ubgc.UnboundType = UnboundColumnType.Boolean;
                                ubgc.Caption = sys_Validation.Validation_ErrorText;
                                ubgc.ToolTip = sys_Validation.Validation_ErrorText;
                                ubgc.FieldName = sys_Validation.Validation_Id;
                                ubgc.UnboundExpression = sys_Validation.Validation_Formula;
                                //ubgc.Visible = true;
                                //abv.CellValueChanged += Abv_CellValueValidation;
                            }
                        }
                        //是否分组统计
                        foreach (Sys_Bind sys_Bind in sys_Binds.Where(b => !b.Bind_Name.StartsWith("@") && b.Bind_Group > 0).OrderBy(b => b.Bind_Group))
                        {
                            GridColumn gc = abv.Columns[sys_Bind.Bind_Field];
                            if (gc != null)
                            {
                                gc.GroupIndex = sys_Bind.Bind_Group;
                                abv.OptionsView.ShowGroupPanel = true;
                            }
                        }
                        #endregion
                        abv.EndUpdate();
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }

        #region 新行的位置控制
        private void Abv_NewItemRowPosition(object sender, EventArgs e)
        {
            GridView abv = (GridView)sender;
            string lyt = BaseService.CheckConfiguration("GLOBAL_GRID_NEWITEMROWPOSITION");
            if (lyt.ToUpper() == "BOTTOM" && abv.OptionsBehavior.AllowAddRows != DevExpress.Utils.DefaultBoolean.False)
            {
                abv.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            }
            else if (lyt.ToUpper() == "TOP" && abv.OptionsBehavior.AllowAddRows != DevExpress.Utils.DefaultBoolean.False)
            {
                abv.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            }
            else
            {
                abv.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }
        }
        #endregion
        #region 行拖拽
        //GridHitInfo根据鼠标点击的x、y坐标获取该点的相关信息
        private GridHitInfo downHitInfo;
        private GridHitInfo upHitInfo;
        private void InitializeRowMove(GridControl grid)
        {
            grid.AllowDrop = true; // 确保能够拖拽
            GridView gvf = (GridView)grid.MainView;
            //gvf.OptionsSelection.MultiSelect = true;     //确保能够多选
            //gvf.OptionsSelection.EnableAppearanceFocusedCell = false; //确保选定行的背景色一样。
            //gvf.OptionsBehavior.Editable = false;
            //gvf.OptionsBehavior.ReadOnly = true;
            //上述初始化最好放在赋数据源之前。否则数据一开始显示的时候没有选中行。
            GridView gv = (GridView)grid.MainView;
            gv.MouseUp += abv_MouseUp;
            gv.MouseDown += abv_MouseDown;
            grid.DragDrop += grid_DragDrop;
            grid.DragEnter += grid_DragEnter;
        }
        //鼠标按下事件    
        private void abv_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridView gvf = (GridView)sender;
                downHitInfo = gvf.CalcHitInfo(new Point(e.X, e.Y));
            }
        }
        //鼠标抬起事件
        private void abv_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridView gvf = (GridView)sender;
                if (!gvf.Editable) return;
                upHitInfo = gvf.CalcHitInfo(new Point(e.X, e.Y));
                gvf.SelectRow(gvf.FocusedRowHandle);
                int[] rows = gvf.GetSelectedRows();
                List<DataRow> drs = new List<DataRow>();
                foreach (int r in rows)   // 获取gridview 数据源中对应的信息。
                {
                    //根据 gridview 中的行索引获取数据源中对应的是行索引
                    int dataSourcerows = gvf.GetDataSourceRowIndex(r);
                    drs.Add(gvf.GetDataRow(r));
                }
                gvf.GridControl.DoDragDrop(drs, DragDropEffects.Move);//开始拖放操作。     
            }
        }
        private void grid_DragDrop(object sender, DragEventArgs e)
        {
            GridControl gd = (GridControl)sender;
            GridView gvf = (GridView)gd.MainView;
            if (!gvf.Editable) return;
            if (downHitInfo == null || downHitInfo.RowHandle < 0) return;
            if (upHitInfo == null || upHitInfo.RowHandle < 0) return;
            if (downHitInfo.RowHandle == upHitInfo.RowHandle) return;
            //获取释放的位置列索引 
            int endRow = gvf.GetDataSourceRowIndex(upHitInfo.RowHandle);
            List<DataRow> drs = (List<DataRow>)e.Data.GetData(typeof(List<DataRow>));
            DataTable dt = (DataTable)gd.DataSource;
            if (drs == null) return;
            foreach (DataRow item in drs)
            {
                if (item.RowState != DataRowState.Detached)
                {
                    DataRow dr = dt.NewRow();
                    dr.ItemArray = item.ItemArray;
                    dt.Rows.InsertAt(dr, endRow);
                    dr.AcceptChanges();
                    if (item.RowState == DataRowState.Added)
                        dr.SetAdded();
                    if (item.RowState == DataRowState.Modified)
                        dr.SetModified();
                    endRow += 1;
                }
            }
            //需要分开  否则会导致索引乱掉
            foreach (DataRow item in drs)
            {
                dt.Rows.Remove(item);
            }
            drs.Clear();
        }
        private void grid_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }
        #endregion
        private Dictionary<string, DevExpress.Utils.DefaultBoolean> IsDeletable = new Dictionary<string, DevExpress.Utils.DefaultBoolean>();
        private Dictionary<string, DevExpress.Utils.DefaultBoolean> IsAddable = new Dictionary<string, DevExpress.Utils.DefaultBoolean>();
        private Dictionary<string, bool> IsEditable = new Dictionary<string, bool>();
        private void Abv_CellEditable(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                GridView abv = (GridView)sender;
                if (e.Column.FieldName.ToUpper() == "ISEDITABLE")
                {
                    bool editable = e.Value.ToBoolEx();
                    DisableView(abv, editable);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void Abv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GridView abv = (GridView)sender;
            if (abv.Columns["IsEditable"] != null)
            {
                bool? chk = null;
                foreach (var item in abv.GetSelectedRows())
                {
                    bool eb = abv.GetRowCellValue(item, "IsEditable").ToBoolEx();
                    if (chk == null)
                        chk = eb;
                    if (eb != chk)
                    {
                        abv.OptionsSelection.MultiSelect = false;
                    }
                }
                abv.OptionsSelection.MultiSelect = true;
            }
        }
        //数据源变更时选中行是否可以编辑
        private void Abv_FocusedRowEditable(object sender, EventArgs e)
        {
            try
            {
                //列不可编辑 绑定的控件也不可编辑
                GridView abv = (GridView)sender;
                if (abv.Columns["IsEditable"] != null)
                {
                    bool editable = abv.GetFocusedRowCellValue("IsEditable").ToBoolEx() || abv.IsNewItemRow(abv.FocusedRowHandle);
                    DisableView(abv, editable);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            try
            {
                //列不可编辑 绑定的控件也不可编辑
                GridView abv = (GridView)sender;
                foreach (var push in BindList.Where(b => !string.IsNullOrEmpty(b.Bind_Push)))
                {
                    Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Id == push.Bind_WorkSet);
                    if (sys_WorkSet.WorkSet_Grid != abv.GridControl.Name) continue;
                    Control pushControl = GetControl(push.Bind_Push);
                    if (pushControl == null) continue;
                    ReflectionHelper.SetProperty(pushControl, "ReadOnly", !abv.Columns[push.Bind_Field].OptionsColumn.AllowEdit || !abv.Editable);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        //数据源变更时选中行是否可以编辑
        private void Abv_FocusedRowEditable(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                //列不可编辑 绑定的控件也不可编辑
                GridView abv = (GridView)sender;
                if (abv.Columns["IsEditable"] != null)
                {
                    bool editable = abv.GetFocusedRowCellValue("IsEditable").ToBoolEx() || abv.IsNewItemRow(e.FocusedRowHandle);
                    DisableView(abv, editable);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            try
            {
                //列不可编辑 绑定的控件也不可编辑
                GridView abv = (GridView)sender;
                foreach (var push in BindList.Where(b => !string.IsNullOrEmpty(b.Bind_Push)))
                {
                    Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Id == push.Bind_WorkSet);
                    if (sys_WorkSet.WorkSet_Grid != abv.GridControl.Name) continue;
                    Control pushControl = GetControl(push.Bind_Push);
                    if (pushControl == null) continue;
                    ReflectionHelper.SetProperty(pushControl, "ReadOnly", !abv.Columns[push.Bind_Field].OptionsColumn.AllowEdit || !abv.Editable);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void DisableView(GridView abv, bool editable)
        {
            //abv.OptionsSelection.MultiSelect = false;
            abv.OptionsBehavior.Editable = editable;
            if (!editable)
            {
                abv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                //主表 不可编辑 子表也就不可不编辑
                foreach (var sys_WorkSet in WorkSetList.Where(w => w.WorkSet_Trigger == abv.GridControl.Name))
                {
                    GridControl grid = (GridControl)sys_WorkSet.WorkSet_Control;
                    if (grid != null)
                    {
                        GridView gv = (GridView)grid.MainView;
                        gv.OptionsBehavior.Editable = false;
                        gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                        gv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                        //递归子表的子表
                        DisableView(gv, editable);
                    }
                }
            }
            else
            {
                ResetView(abv);
                foreach (var sys_WorkSet in WorkSetList.Where(w => w.WorkSet_Trigger == abv.GridControl.Name))
                {
                    GridControl grid = (GridControl)sys_WorkSet.WorkSet_Control;
                    if (grid != null)
                    {
                        GridView gv = (GridView)grid.MainView;
                        ResetView(gv);
                        //子表的子表
                        DisableView(gv, editable);
                    }
                }
            }
            ToggleTool();
        }
        private void Abv_UnboundColumnValue(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                GridView abv = (GridView)sender;
                abv.BeginUpdate();
                //修改可以避免只有选中行有效的问题
                DataRow dr = abv.GetDataRow(e.RowHandle);// abv.GetFocusedDataRow();
                foreach (GridColumn gc in abv.Columns.Where(c => c.UnboundType != UnboundColumnType.Bound && c.FieldName.StartsWith("Unbound_")))
                {
                    //如果修改的是具有函数的字段本身则不作任何操作 
                    //即修改的字段只能作为参数，而不作为计算结果
                    //可以实现功能：数量 单价 总价
                    //修改单价自动算总价，修改总价自动算单价
                    if ("Unbound_" + e.Column.FieldName != gc.FieldName && abv.GetRowCellValue(e.RowHandle, gc) != null)
                    {
                        dr[gc.FieldName.Replace("Unbound_", "")] = abv.GetRowCellValue(e.RowHandle, gc);
                    }
                }
                abv.EndUpdate();
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void Abv_NewRowUnboundColumnValue(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                GridView abv = (GridView)sender;
                if (!abv.IsNewItemRow(e.RowHandle)) return;
                abv.BeginUpdate();
                //修改可以避免只有选中行有效的问题
                DataRow dr = abv.GetDataRow(e.RowHandle);// abv.GetFocusedDataRow();
                foreach (GridColumn gc in abv.Columns.Where(c => c.UnboundType != UnboundColumnType.Bound && c.FieldName.StartsWith("NewRowUnbound_")))
                {
                    //如果修改的是具有函数的字段本身则不作任何操作 
                    //即修改的字段只能作为参数，而不作为计算结果
                    //可以实现功能：数量 单价 总价
                    //修改单价自动算总价，修改总价自动算单价
                    if ("NewRowUnbound_" + e.Column.FieldName != gc.FieldName && abv.GetRowCellValue(e.RowHandle, gc) != null)
                    {
                        dr[gc.FieldName.Replace("NewRowUnbound_", "")] = abv.GetRowCellValue(e.RowHandle, gc);
                    }
                }
                abv.EndUpdate();
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void InitializeNewRowEditor(object sender, FocusedRowChangedEventArgs e)
        {
            try
            {
                //可以添加却不可以更新时  需要判断是否是新行  如果是新行才能编辑  否则不能编辑
                GridView abv = (GridView)sender;
                DataRow dr = abv.GetDataRow(e.FocusedRowHandle);
                if ((dr != null && dr.RowState == DataRowState.Added) || abv.IsNewItemRow(e.FocusedRowHandle))
                {
                    abv.OptionsBehavior.Editable = true;
                }
                else
                {
                    Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Control == abv.GridControl);
                    if (sys_WorkSet != null)
                    {
                        if (string.IsNullOrEmpty(sys_WorkSet.WorkSet_Update))
                        {
                            abv.OptionsBehavior.Editable = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void Grid_Validating(object sender, CancelEventArgs e)
        {
            //数据验证
            GridControl grid = (GridControl)sender;
            GridView abv = (GridView)grid.MainView;
            try
            {
                //DXErrorProvider dxp = new DXErrorProvider();
                Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Control == grid);
                if (sys_WorkSet != null)
                {
                    if (ToolPress)
                        abv.ActiveFilter.Clear();
                    foreach (Sys_Validation sys_Validation in ValidationList.Where(v => v.Validation_WorkSet == sys_WorkSet.WorkSet_Id && !string.IsNullOrEmpty(v.Validation_Expression)).OrderBy(v => v.Validation_Sort))
                    {
                        for (int i = 0; i < abv.DataRowCount; i++)
                        {
                            Sys_Bind sys_Bind = BindList.Find(b => b.Bind_Field == sys_Validation.Validation_FieldName && b.Bind_WorkSet == sys_Validation.Validation_WorkSet);
                            DbType sdType = sys_Bind == null ? DbType.String : (DbType)sys_Bind.Bind_SqlDbType;
                            object val = abv.GetRowCellValue(i, sys_Validation.Validation_FieldName);
                            object rul = sys_Validation.Validation_Ruler;
                            if (abv.Columns[sys_Validation.Validation_Ruler] != null)
                            {
                                rul = abv.GetRowCellValue(i, sys_Validation.Validation_Ruler);
                                if (rul == DBNull.Value) rul = null;
                            }
                            else
                            {
                                rul = sys_Validation.Validation_Ruler;
                            }
                            List<MyParameter> mps = InitializeBind(sys_WorkSet.WorkSet_Id, true);
                            if (val == DBNull.Value) val = null;
                            mps.Add("@Value", sdType, val, null);
                            mps.Add("@Ruler", sdType, rul, null);
                            object obj = BaseService.Get(sys_Validation.Validation_Expression, mps);
                            bool chk = obj.ToBoolEx();
                            if (sys_Validation.Validation_Negate) chk = !chk;
                            //判断错误行是否可以编辑
                            bool canEdit = true;
                            //错误列是否可以编辑
                            if (!abv.Columns[sys_Validation.Validation_FieldName].OptionsColumn.AllowEdit)
                                canEdit = false;
                            //使用了 IsEditable 的情况下 错误行是否可以编辑
                            if (abv.Columns["IsEditable"] != null && !abv.GetRowCellValue(i, "IsEditable").ToBoolEx())
                                canEdit = false;
                            //没有使用 IsEditable 的情况下 表格是否可以编辑
                            if (abv.Columns["IsEditable"] == null && !abv.Editable)
                                canEdit = false;
                            if (!chk && canEdit)
                            {
                                abv.FocusedRowHandle = i;
                                if (sys_Validation.Validation_Confirm)
                                {
                                    SharedFunc.RaiseError(sys_Validation.Validation_ErrorText);
                                }
                                if (sys_Validation.Validation_SetError || sys_Validation.Validation_ToolTip)
                                {
                                    if (abv.Columns[sys_Validation.Validation_FieldName].Visible)
                                    {
                                        abv.SetColumnError(abv.Columns[sys_Validation.Validation_FieldName], sys_Validation.Validation_ErrorText);
                                        abv.MakeColumnVisible(abv.Columns[sys_Validation.Validation_FieldName]);
                                        abv.MakeRowVisible(i);
                                    }
                                }
                                if (sys_Validation.Validation_Cancel || ToolPress)
                                {
                                    e.Cancel = true;
                                }
                                return;
                            }
                            //dxp.ClearErrors();
                            abv.ClearColumnErrors();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
                grid.CausesValidation = true;
            }
            //公式验证
            try
            {
                //DXErrorProvider dxp = new DXErrorProvider();
                Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Control == grid);
                if (sys_WorkSet != null)
                {
                    if (ToolPress)
                        abv.ActiveFilter.Clear();
                    for (int i = 0; i < abv.DataRowCount; i++)
                    {
                        foreach (Sys_Validation sys_Validation in ValidationList.Where(v => v.Validation_WorkSet == sys_WorkSet.WorkSet_Id && !string.IsNullOrEmpty(v.Validation_Formula)).OrderBy(v => v.Validation_Sort))
                        {
                            foreach (GridColumn gc in abv.Columns.Where(c => c.UnboundType != UnboundColumnType.Bound && c.FieldName == sys_Validation.Validation_Id))
                            {
                                object obj = abv.GetRowCellValue(i, gc);
                                bool chk = obj.ToBoolEx();
                                if (sys_Validation.Validation_Negate) chk = !chk;
                                //判断错误行是否可以编辑
                                bool canEdit = true;
                                //错误列是否可以编辑
                                if (!abv.Columns[sys_Validation.Validation_FieldName].OptionsColumn.AllowEdit)
                                    canEdit = false;
                                //使用了 IsEditable 的情况下 错误行是否可以编辑
                                if (abv.Columns["IsEditable"] != null && !abv.GetRowCellValue(i, "IsEditable").ToBoolEx())
                                    canEdit = false;
                                //没有使用 IsEditable 的情况下 表格是否可以编辑
                                if (abv.Columns["IsEditable"] == null && !abv.Editable)
                                    canEdit = false;
                                if (!chk && canEdit)
                                {
                                    abv.FocusedRowHandle = i;
                                    if (sys_Validation.Validation_Confirm)
                                    {
                                        SharedFunc.RaiseError(sys_Validation.Validation_ErrorText);
                                    }
                                    if (sys_Validation.Validation_SetError || sys_Validation.Validation_ToolTip)
                                    {
                                        abv.SetColumnError(abv.Columns[sys_Validation.Validation_FieldName], sys_Validation.Validation_ErrorText);
                                        abv.MakeColumnVisible(abv.Columns[sys_Validation.Validation_FieldName]);
                                        abv.MakeRowVisible(i);
                                    }
                                    if (sys_Validation.Validation_Cancel || ToolPress)
                                    {
                                        e.Cancel = true;
                                    }
                                    return;
                                }
                                //dxp.ClearErrors();
                                abv.ClearColumnErrors();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
            finally
            {
                grid.CausesValidation = true;
            }
        }
        private void InitializeSubmitControl()
        {
            //布局Layout
            try
            {
                foreach (Sys_WorkSet sys_WorkSet in WorkSetList.Where(s => s.WorkSet_Type.Equals((byte)Sys_Enum.Sys_WorkSet_Type.Submit)))
                {
                    #region Initial Column
                    List<Sys_Bind> sys_Binds = BindList.Where(b => b.Bind_WorkSet == sys_WorkSet.WorkSet_Id).ToList();
                    //BindList.AddRange(sys_Binds);
                    GridControl submit = null;
                    if (sys_WorkSet.WorkSet_Control != null && sys_WorkSet.WorkSet_Control.GetType().Equals(typeof(GridControl)))
                        submit = (GridControl)sys_WorkSet.WorkSet_Control;
                    if (submit == null) return;
                    #region SubmitForm
                    this.Width = 1024;
                    submit.Width = 1024;
                    LayoutControl eLayoutControl = new LayoutControl();
                    eLayoutControl.BeginUpdate();
                    LayoutControlGroup eLayoutControlGroup = new LayoutControlGroup();
                    eLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
                    eLayoutControl.Location = new System.Drawing.Point(2, 21);
                    eLayoutControl.Name = "eLayoutControl";
                    eLayoutControl.Root = eLayoutControlGroup;
                    eLayoutControl.Size = new System.Drawing.Size(1000, 90);
                    eLayoutControl.TabIndex = 0;
                    eLayoutControl.Text = "QueryLayout";
                    eLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
                    eLayoutControlGroup.GroupBordersVisible = false;
                    eLayoutControlGroup.Location = new Point(0, 0);
                    eLayoutControlGroup.Name = "eLayoutControlGroup";
                    eLayoutControlGroup.Size = new Size(1000, 90);
                    eLayoutControlGroup.TextVisible = false;
                    submit.Parent.Controls.Add(eLayoutControl);
                    GridView abv = (GridView)submit.MainView;
                    if (submit.Parent != null && submit.Parent.GetType() == typeof(GroupControl))
                    {
                        submit.Parent.DoubleClick += delegate
                        {
                            eLayoutControl.Visible = !eLayoutControl.Visible;
                            //if (!eLayoutControl.Visible)
                            //{
                            //    GridView gv = (GridView)submit.MainView;
                            //    gv.BestFitColumns();
                            //}
                        };
                        abv.DoubleClick += delegate
                        {
                            bool editable = abv.GetFocusedRowCellValue("IsEditable").ToBoolEx();
                            if (!editable)
                                LockControl(eLayoutControl, !editable);
                            eLayoutControl.Visible = !eLayoutControl.Visible;
                        };
                    }
                    abv.FocusedRowChanged += delegate
                    {
                        if (abv.Columns["IsEditable"] != null)
                        {
                            bool editable = abv.GetFocusedRowCellValue("IsEditable").ToBoolEx();
                            if (!editable)
                                LockControl(eLayoutControl, !editable);
                            //eLayoutControl.Enabled = editable;
                        }
                    };
                    abv.DataSourceChanged += delegate
                    {
                        if (abv.Columns["IsEditable"] != null)
                        {
                            bool editable = abv.GetFocusedRowCellValue("IsEditable").ToBoolEx();
                            if (!editable)
                                LockControl(eLayoutControl, !editable);
                        }
                    };
                    abv.CellValueChanged += delegate (object sender, CellValueChangedEventArgs e)
                    {
                        if (e.Column.FieldName == "IsEditable")
                        {
                            bool editable = e.Value.ToBoolEx();
                            if (!editable)
                                LockControl(eLayoutControl, !editable);
                        }
                    };
                    List<BaseLayoutItem> baseLayoutItems = new List<BaseLayoutItem>();
                    List<string> baseControls = new List<string>();
                    int curLeft = 0;
                    int curTop = 64;
                    //表头文本
                    LabelControl label = new LabelControl();
                    label.Name = "label";
                    label.Font = new Font(this.Font.Name, 24);
                    label.Text = sys_WorkSet.WorkSet_Nick;
                    label.Appearance.Options.UseFont = true;
                    label.Appearance.Options.UseTextOptions = true;
                    label.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    label.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
                    label.LineVisible = true;
                    LayoutControlItem eTitle = new LayoutControlItem();
                    eTitle.TextVisible = false;
                    eTitle.Location = new Point(0, 0);
                    eTitle.Control = label;
                    baseLayoutItems.Add(eTitle);
                    EmptySpaceItem emptyTitle = new EmptySpaceItem();
                    emptyTitle.AllowHotTrack = false;
                    emptyTitle.Location = new System.Drawing.Point(0, 0);
                    emptyTitle.Name = "oli_Space";
                    emptyTitle.Size = new System.Drawing.Size(1000, 24);
                    emptyTitle.MaxSize = new System.Drawing.Size(0, 24);
                    emptyTitle.SizeConstraintsType = SizeConstraintsType.Custom;
                    baseLayoutItems.Add(emptyTitle);
                    foreach (Sys_Bind sys_Bind in sys_Binds.Where(b => !b.Bind_Name.StartsWith("@") && b.Bind_Visible).OrderBy(b => b.Bind_FormSort))
                    {
                        if (baseControls.Contains(sys_Bind.Bind_Field)) continue;
                        baseControls.Add(sys_Bind.Bind_Field);
                        //界面已有控件不再生成
                        BaseEdit baseEdit = InitializeBaseEdit(sys_Bind, null);
                        baseEdit.Name = sys_Bind.Bind_Push;
                        baseEdit.Text = sys_Bind.Bind_Default;
                        baseEdit.EditValue = sys_Bind.Bind_Default;
                        if (baseEdit.GetType().Equals(typeof(CheckEdit)))
                        {
                            CheckEdit chkEdit = (CheckEdit)baseEdit;
                            chkEdit.Text = string.Empty;
                            chkEdit.Checked = sys_Bind.Bind_Default.ToBoolEx();
                            chkEdit.EditValueChanged += BindCheckEdit_EditValueChanged;
                        }
                        baseEdit.EnterMoveNextControl = true;
                        baseEdit.Width = (int)Math.Round(eLayoutControlGroup.Width * ((sys_Bind.Bind_FormWidth == 0 ? 25 : sys_Bind.Bind_FormWidth) / 100.00));
                        baseEdit.Properties.Appearance.Options.UseTextOptions = true;
                        baseEdit.Properties.Appearance.TextOptions.HAlignment = (DevExpress.Utils.HorzAlignment)sys_Bind.Bind_TextAlignment;
                        if (sys_Bind.Bind_ForeColor < 0)
                            baseEdit.ForeColor = Color.FromArgb(sys_Bind.Bind_ForeColor);
                        if (sys_Bind.Bind_BackColor < 0)
                            baseEdit.BackColor = Color.FromArgb(sys_Bind.Bind_BackColor);
                        if (sys_Bind.Bind_BorderColor < 0)
                        {
                            baseEdit.Properties.Appearance.Options.UseBorderColor = true;
                            baseEdit.Properties.Appearance.BorderColor = Color.FromArgb(sys_Bind.Bind_BorderColor);
                            baseEdit.BorderStyle = BorderStyles.Simple;
                        }
                        baseEdit.ToolTip = sys_Bind.Bind_ToolTip;
                        baseEdit.ReadOnly = sys_Bind.Bind_ReadOnly;
                        baseEdit.Visible = sys_Bind.Bind_Visible;
                        baseEdit.GotFocus += Control_GotFocus;
                        eLayoutControl.GotFocus += Control_GotFocus;
                        LayoutControlItem eLayoutControlItem = new LayoutControlItem();
                        eLayoutControlItem.Location = new System.Drawing.Point(curLeft, curTop);
                        if (sys_Bind.Bind_Visible)
                        {
                            eLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                            curLeft += baseEdit.Width;
                            if (curLeft >= eLayoutControlGroup.Width)
                            {
                                curLeft = 0;
                                curTop += baseEdit.Height;
                            }
                        }
                        else
                        {
                            eLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                        }
                        //eLayoutControlItem.Width = (int)Math.Round(eLayoutControl.Width * (sys_Bind.Bind_Width / 100.00));
                        eLayoutControlItem.AppearanceItemCaption.TextOptions.HAlignment = (DevExpress.Utils.HorzAlignment)sys_Bind.Bind_TitleAlignment;
                        eLayoutControlItem.Name = "oli_" + sys_Bind.Bind_Name;
                        eLayoutControlItem.Text = sys_Bind.Bind_Nick;
                        eLayoutControlItem.Size = new Size(baseEdit.Width, baseEdit.Height);
                        eLayoutControlItem.Control = baseEdit;
                        baseLayoutItems.Add(eLayoutControlItem);
                    }
                    if (curLeft < eLayoutControlGroup.Width && curLeft > 0)
                    {
                        EmptySpaceItem emptySpaceItem = new EmptySpaceItem();
                        emptySpaceItem.AllowHotTrack = false;
                        emptySpaceItem.Location = new System.Drawing.Point(curLeft, curTop);
                        emptySpaceItem.Name = "oli_Space";
                        emptySpaceItem.Size = new System.Drawing.Size(eLayoutControlGroup.Width - curLeft, 24);
                        baseLayoutItems.Add(emptySpaceItem);
                    }
                    EmptySpaceItem emptyFoot = new EmptySpaceItem();
                    emptyFoot.AllowHotTrack = false;
                    emptyFoot.Location = new System.Drawing.Point(curLeft, curTop + 24);
                    emptyFoot.Name = "oli_Space";
                    emptyFoot.Size = new System.Drawing.Size(1000 - curLeft, 24);
                    baseLayoutItems.Add(emptyFoot);
                    eLayoutControlGroup.Items.AddRange(baseLayoutItems.ToArray());
                    eLayoutControl.BringToFront();
                    eLayoutControl.EndUpdate();
                    eLayoutControl.Visible = !string.IsNullOrEmpty(sys_WorkSet.WorkSet_Trigger);
                    #endregion
                }
                #endregion
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void BindCheckEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                CheckEdit chkEdit = (CheckEdit)sender;
                if (chkEdit.EditValue == null) return;
                if (chkEdit.EditValue.GetType().Equals(typeof(bool)))
                {
                    chkEdit.Properties.ValueChecked = Convert.ToBoolean(1);
                    chkEdit.Properties.ValueUnchecked = Convert.ToBoolean(0);
                    chkEdit.Properties.ValueGrayed = null;
                }
                if (chkEdit.EditValue.GetType().Equals(typeof(Int16)))
                {
                    chkEdit.Properties.ValueChecked = Convert.ToInt16(1);
                    chkEdit.Properties.ValueUnchecked = Convert.ToInt16(0);
                    chkEdit.Properties.ValueGrayed = null;
                }
                if (chkEdit.EditValue.GetType().Equals(typeof(int)))
                {
                    chkEdit.Properties.ValueChecked = Convert.ToInt32(1);
                    chkEdit.Properties.ValueUnchecked = Convert.ToInt32(0);
                    chkEdit.Properties.ValueGrayed = null;
                }
                if (chkEdit.EditValue.GetType().Equals(typeof(Int64)))
                {
                    chkEdit.Properties.ValueChecked = Convert.ToInt64(1);
                    chkEdit.Properties.ValueUnchecked = Convert.ToInt64(0);
                    chkEdit.Properties.ValueGrayed = null;
                }
                if (chkEdit.EditValue.GetType().Equals(typeof(byte)))
                {
                    chkEdit.Properties.ValueChecked = Convert.ToByte(1);
                    chkEdit.Properties.ValueUnchecked = Convert.ToByte(0);
                    chkEdit.Properties.ValueGrayed = null;
                }
                if (chkEdit.EditValue.GetType().Equals(typeof(string)))
                {
                    chkEdit.Properties.ValueChecked = Convert.ToString(true);
                    chkEdit.Properties.ValueUnchecked = Convert.ToString(false);
                    chkEdit.Properties.ValueGrayed = null;
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        #region 扩展右键菜单
        private void Abv_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            try
            {
                MyCommonLocalizer myCommonLocalizer = new MyCommonLocalizer();
                string GridColumnMenuCheckAll = myCommonLocalizer.GetLocalizedString(MyCommonStringId.GridColumnMenuCheckAll);
                string GridColumnMenuUnCheckAll = myCommonLocalizer.GetLocalizedString(MyCommonStringId.GridColumnMenuUnCheckAll);
                string GridColumnMenuAutoNumber = myCommonLocalizer.GetLocalizedString(MyCommonStringId.GridColumnMenuAutoNumber);
                string GridColumnMenuAutoFill = myCommonLocalizer.GetLocalizedString(MyCommonStringId.GridColumnMenuAutoFill);
                string GridColumnMenuExpression = myCommonLocalizer.GetLocalizedString(MyCommonStringId.GridColumnMenuExpression);
                string GridColumnMenuFieldEdit = myCommonLocalizer.GetLocalizedString(MyCommonStringId.GridColumnMenuFieldEdit);
                string GridColumnMenuFieldClear = myCommonLocalizer.GetLocalizedString(MyCommonStringId.GridColumnMenuFieldClear);
                if (e.HitInfo.InColumn && e.HitInfo.Column.OptionsColumn.AllowEdit)
                {
                    //DevExpress.XtraGrid.Localization.GridStringId.MenuColumnColumnCustomization
                    //不允许用户前台修改表格字段
                    e.Menu.Items[5].Visible = false;
                    //全选 取消全选
                    if (e.HitInfo.Column.ColumnType == typeof(bool))
                    {
                        DXMenuItem MenuItem_CheckAll = new DXMenuItem();
                        MenuItem_CheckAll.Caption = GridColumnMenuCheckAll;
                        MenuItem_CheckAll.Tag = "CheckAll";
                        MenuItem_CheckAll.BeginGroup = true;
                        e.Menu.Items.Add(MenuItem_CheckAll);
                        MenuItem_CheckAll.Click += MenuItem_CheckAll_Click;
                        DXMenuItem MenuItem_UnCheckAll = new DXMenuItem();
                        MenuItem_UnCheckAll.Caption = GridColumnMenuUnCheckAll;
                        MenuItem_UnCheckAll.Tag = "UnCheckAll";
                        e.Menu.Items.Add(MenuItem_UnCheckAll);
                        MenuItem_UnCheckAll.Click += MenuItem_UnCheckAll_Click;
                    }
                    //自动排序
                    if (e.HitInfo.Column.ColumnType == typeof(int))
                    {
                        DXMenuItem MenuItem_AutoNumber = new DXMenuItem();
                        MenuItem_AutoNumber.Caption = GridColumnMenuAutoNumber;
                        MenuItem_AutoNumber.Tag = "AutoNumber";
                        MenuItem_AutoNumber.BeginGroup = true;
                        e.Menu.Items.Add(MenuItem_AutoNumber);
                        MenuItem_AutoNumber.Click += MenuItem_AutoNumber_Click;
                    }
                    //自动填充
                    DXMenuItem MenuItem_AutoFill = new DXMenuItem();
                    MenuItem_AutoFill.Caption = GridColumnMenuAutoFill;
                    MenuItem_AutoFill.Tag = "AutoFill";
                    MenuItem_AutoFill.BeginGroup = true;
                    e.Menu.Items.Add(MenuItem_AutoFill);
                    MenuItem_AutoFill.Click += MenuItem_AutoFill_Click;
                    //计算公式
                    DXMenuItem MenuItem_Expression = new DXMenuItem();
                    MenuItem_Expression.Caption = GridColumnMenuExpression;
                    MenuItem_Expression.Tag = "Expression";
                    //MenuItem_Expression.BeginGroup = true;
                    e.Menu.Items.Add(MenuItem_Expression);
                    MenuItem_Expression.Click += MenuItem_Expression_Click;
                    //清除数据
                    DXMenuItem MenuItem_FieldClear = new DXMenuItem();
                    MenuItem_FieldClear.Caption = GridColumnMenuFieldClear;
                    MenuItem_FieldClear.Tag = "FieldClear";
                    e.Menu.Items.Add(MenuItem_FieldClear);
                    MenuItem_FieldClear.Click += MenuItem_FieldClear_Click;
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void MenuItem_UnCheckAll_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewColumnMenu OneMenu = (GridViewColumnMenu)((DXMenuItem)sender).Collection.Owner;
                for (int i = 0; i < OneMenu.Column.View.DataRowCount; i++)
                {
                    OneMenu.Column.View.SetRowCellValue(i, OneMenu.Column, false);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void MenuItem_CheckAll_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewColumnMenu OneMenu = (GridViewColumnMenu)((DXMenuItem)sender).Collection.Owner;
                for (int i = 0; i < OneMenu.Column.View.DataRowCount; i++)
                {
                    OneMenu.Column.View.SetRowCellValue(i, OneMenu.Column, true);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void MenuItem_AutoNumber_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewColumnMenu OneMenu = (GridViewColumnMenu)((DXMenuItem)sender).Collection.Owner;
                for (int i = 0; i < OneMenu.Column.View.DataRowCount; i++)
                {
                    OneMenu.Column.View.SetRowCellValue(i, OneMenu.Column, 11000 + i * 100);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void MenuItem_AutoFill_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewColumnMenu OneMenu = (GridViewColumnMenu)((DXMenuItem)sender).Collection.Owner;
                object obj = null;
                for (int i = 0; i < OneMenu.Column.View.DataRowCount; i++)
                {
                    object tmp = OneMenu.Column.View.GetRowCellValue(i, OneMenu.Column);
                    if (tmp != null && tmp != DBNull.Value && !string.IsNullOrEmpty(tmp.ToStringEx()))
                        obj = tmp;
                    OneMenu.Column.View.SetRowCellValue(i, OneMenu.Column, obj);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void MenuItem_Expression_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewColumnMenu OneMenu = (GridViewColumnMenu)((DXMenuItem)sender).Collection.Owner;
                GridColumn gc = OneMenu.Column;
                //添加公式计算列
                GridColumn ugc = gc.View.Columns.ColumnByFieldName("Unbound_" + gc.FieldName);
                if (ugc == null)
                {
                    ugc = new GridColumn();
                    ugc.Name = "Unbound_" + gc.FieldName;
                    ugc.UnboundType = UnboundColumnType.String;
                    if (gc.ColumnType == typeof(decimal))
                        ugc.UnboundType = UnboundColumnType.Decimal;
                    if (gc.ColumnType == typeof(bool))
                        ugc.UnboundType = UnboundColumnType.Boolean;
                    if (gc.ColumnType == typeof(DateTime))
                        ugc.UnboundType = UnboundColumnType.DateTime;
                    if (gc.ColumnType == typeof(Int16))
                        ugc.UnboundType = UnboundColumnType.Integer;
                    if (gc.ColumnType == typeof(int))
                        ugc.UnboundType = UnboundColumnType.Integer;
                    if (gc.ColumnType == typeof(Int64))
                        ugc.UnboundType = UnboundColumnType.Integer;
                    if (gc.ColumnType == typeof(string))
                        ugc.UnboundType = UnboundColumnType.String;
                    ugc.Visible = false;
                    ugc.FieldName = ugc.Name;
                    string tt = ugc.UnboundExpression;
                    //if (!ReflectionHelper.IsBindEvent(gc.View, "CellValueChanged"))
                    gc.View.CellValueChanged += Abv_UnboundColumnValue;
                    gc.View.Columns.Add(ugc);
                }
                //DevExpress.Data.ExpressionEditor.ExpressionEditorLogicEx
                ExpressionEditorFormEx expressionEditorControl = new ExpressionEditorFormEx(ugc, null);
                //expressionEditorControl.
                if (expressionEditorControl.ShowDialog() == DialogResult.OK)
                    ugc.UnboundExpression = expressionEditorControl.Expression.Trim();
                if (!string.IsNullOrEmpty(ugc.UnboundExpression))
                {
                    gc.View.BeginUpdate();
                    for (int i = 0; i < gc.View.DataRowCount; i++)
                    {
                        gc.View.SetRowCellValue(i, gc, gc.View.GetRowCellValue(i, ugc));
                    }
                    gc.View.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }

        }
        private void MenuItem_FieldEdit_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewColumnMenu OneMenu = (GridViewColumnMenu)((DXMenuItem)sender).Collection.Owner;
                FieldEdit fe = new FieldEdit(new GridColumn[] { OneMenu.Column, OneMenu.Column.View.Columns[0] });
                fe.ShowDialog();
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void MenuItem_FieldClear_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewColumnMenu OneMenu = (GridViewColumnMenu)((DXMenuItem)sender).Collection.Owner;
                for (int i = 0; i < OneMenu.Column.View.DataRowCount; i++)
                {
                    OneMenu.Column.View.SetRowCellValue(i, OneMenu.Column, null);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        #endregion
        private void InitializeNewRow(object sender, InitNewRowEventArgs e)
        {
            try
            {
                GridView abv = (GridView)sender;
                abv.FocusedRowHandle = e.RowHandle;
                //abv.SetRowCellValue(e.RowHandle, abv.Columns[0], null);
                foreach (Sys_Bind sys_Bind in BindList.Where(b => b.Bind_Control == null))
                {
                    if (!string.IsNullOrEmpty(sys_Bind.Bind_Default))
                    {
                        if (WorkSetList.Find(w => w.WorkSet_Control != null && w.WorkSet_Control.Equals(abv.GridControl) && sys_Bind.Bind_WorkSet.Equals(w.WorkSet_Id)) != null)
                        {
                            //取Workset
                            if (sys_Bind.Bind_Default.StartsWith("wk:"))
                            {
                                string wk = sys_Bind.Bind_Default.Replace("wk:", "");
                                List<MyParameter> mps = InitializeBind(wk, true);
                                object obj = BaseService.Get(wk, mps);
                                abv.SetRowCellValue(e.RowHandle, sys_Bind.Bind_Field, obj);
                            }
                            //取控件值
                            else if (sys_Bind.Bind_Default.StartsWith("rf:"))
                            {
                                string rf = sys_Bind.Bind_Default.Replace("rf:", "");
                                abv.SetRowCellValue(e.RowHandle, sys_Bind.Bind_Field, GetValue(rf));
                            }
                            //取控件值
                            else if (sys_Bind.Bind_Default.StartsWith("fn:"))
                            {
                                string fn = sys_Bind.Bind_Default.Replace("fn:", "");
                                //这种情况用 公式处理
                                //Abv_NewRowUnboundColumnValue
                            }
                            else
                            {
                                abv.SetRowCellValue(e.RowHandle, sys_Bind.Bind_Field, sys_Bind.Bind_Default);
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
        private void InitializeRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        #region 分页控制 切换分页自动查询
        private void PageChanaged(GridControl grid)
        {
            try
            {
                foreach (var push in WorkSetList.Where(b => !string.IsNullOrEmpty(b.WorkSet_Pagination)))
                {
                    Control[] findControls = this.Controls.Find(push.WorkSet_Pagination, true);
                    if (findControls.Length > 0)
                    {
                        Control findControl = findControls[0];
                        if (findControl.GetType().Equals(typeof(Pagination)))
                        {
                            Pagination paginationControl = (Pagination)findControl;
                            //paginationControl.BeginUpdate();
                            if (paginationControl.Tag == null)
                            {
                                paginationControl.Tag = push.WorkSet_Name;
                                paginationControl.PropertyChanged += PaginationControl_PropertyChanged;
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
        private void PaginationControl_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            try
            {
                Pagination paginationControl = (Pagination)sender;
                string workSet_Name = paginationControl.Tag.ToStringEx();
                if (!string.IsNullOrEmpty(workSet_Name))
                {
                    OpenWorkSet(workSet_Name);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        #endregion
        protected void OpenWorkSet(string WorksetName)
        {

            try
            {
                Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Id.Equals(WorksetName) || w.WorkSet_Name.Equals(WorksetName));
                if (sys_WorkSet.WorkSet_Control != null && sys_WorkSet.WorkSet_Control.GetType().Equals(typeof(GridControl)))
                {
                    GridControl tgd = (GridControl)sys_WorkSet.WorkSet_Control;
                    List<MyParameter> QueryParameters = InitializeBind(sys_WorkSet.WorkSet_Id, true);
                    DataTable dt = BaseService.Open(sys_WorkSet.WorkSet_Name, QueryParameters);
                    tgd.DataSource = dt;
                }
                if (sys_WorkSet.WorkSet_Control != null && sys_WorkSet.WorkSet_Control.GetType().Equals(typeof(ChartControl)))
                {
                    ChartControl tgd = (ChartControl)sys_WorkSet.WorkSet_Control;
                    List<MyParameter> QueryParameters = InitializeBind(sys_WorkSet.WorkSet_Id, true);
                    tgd.DataSource = BaseService.Open(sys_WorkSet.WorkSet_Name, QueryParameters);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void PushData(object sender, EventArgs e)
        {
            try
            {
                GridControl grid = (GridControl)sender;
                foreach (var push in BindList.Where(b => !string.IsNullOrEmpty(b.Bind_Push)))
                {
                    Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Grid != null && w.WorkSet_Id.Equals(push.Bind_WorkSet) && w.WorkSet_Grid.Equals(grid.Name));
                    if (sys_WorkSet != null)
                    {
                        if (string.IsNullOrEmpty(push.Bind_Property))
                            push.Bind_Property = "Text";
                        GridView abv = (GridView)grid.MainView;
                        Control[] pushControls = this.Controls.Find(push.Bind_Push, true);
                        if (pushControls.Length > 0 && grid.DataSource != null)
                        {
                            Control pushControl = pushControls[0];
                            pushControl.DataBindings.Clear();
                            pushControl.DataBindings.Add(push.Bind_Property, grid.DataSource, push.Bind_Field, true, DataSourceUpdateMode.OnPropertyChanged, null);
                            //AddDataBinding(push.Bind_Property, grid.DataSource, push.Bind_Field, pushControl);
                            //ReflectionHelper.SetProperty(pushControl, "ReadOnly", !abv.Columns[push.Bind_Field].OptionsColumn.AllowEdit);
                        }
                        DataTable dt = (DataTable)grid.DataSource;
                        if ((dt == null || dt.Rows.Count == 0) && pushControls.Length > 0)
                        {
                            Control pushControl = pushControls[0];
                            ReflectionHelper.SetProperty(pushControl, push.Bind_Property, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        #region WorkSet_Trigger
        private void Abv_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                GridView abv = (GridView)sender;
                TrigGrid(abv);
                
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }

        private void Abv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                GridView abv = (GridView)sender;                 
                TrigGrid(abv);
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void ResetView(GridView gv)
        {
            if (IsEditable.ContainsKey(gv.Name))
                gv.OptionsBehavior.Editable = IsEditable[gv.Name];
            if (IsAddable.ContainsKey(gv.Name))
                gv.OptionsBehavior.AllowAddRows = IsAddable[gv.Name];
            if (IsDeletable.ContainsKey(gv.Name))
                gv.OptionsBehavior.AllowDeleteRows = IsDeletable[gv.Name];
        }

        private void TrigGrid(GridView abv)
        {
            try
            {
                if (IsSave) return;
                GridControl gd = abv.GridControl;
                if (gd.Tag == null)
                {
                    gd.Tag = Guid.NewGuid().ToString();
                }
                ThreadHelper.DelayRun(() =>
                {
                    foreach (var sys_WorkSet in WorkSetList.Where(w => w.WorkSet_Trigger == gd.Name))
                    {
                        //主表没有数据 子表 也就没有数据  不是数据行也不触发
                        if (abv.DataSource == null || abv.DataRowCount == 0 || !abv.IsDataRow(abv.FocusedRowHandle))
                        {
                            GridControl tgd = (GridControl)sys_WorkSet.WorkSet_Control;
                            if (tgd != null)
                            {
                                tgd.DataSource = null;
                            }
                        }
                        else
                        {
                            OpenWorkSet(sys_WorkSet.WorkSet_Id);
                        }
                    }
                }, gd.Tag.ToStringEx());
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }

        #endregion
        #endregion
        #region InitializeFormat
        private void InitializeFormat()
        {
            try
            {
                if (SysPage == null) return;
                List<MyParameter> myParameters = new List<MyParameter>();
                myParameters.Add("@Menu_Id", DbType.String, SysPage.Menu_Id, null);
                DataTable dt = BaseService.Open("SystemMenu_Format", myParameters);
                List<Sys_Format> sys_Formats = EntityHelper.GetEntities<Sys_Format>(dt);
                foreach (Sys_Format sys_Format in sys_Formats)
                {
                    Sys_WorkSet sys_WorkSet = WorkSetList.Find(w => w.WorkSet_Id.Equals(sys_Format.Format_WorkSet));
                    if (sys_WorkSet != null)
                    {
                        if (sys_WorkSet.WorkSet_Control != null && sys_WorkSet.WorkSet_Control.GetType().Equals(typeof(GridControl)))
                        {
                            GridControl grid = (GridControl)sys_WorkSet.WorkSet_Control;
                            GridView abv = (GridView)grid.MainView;
                            StyleFormatCondition styleFormatCondition = new StyleFormatCondition();
                            styleFormatCondition.ApplyToRow = sys_Format.Format_WholeRow;
                            styleFormatCondition.Expression = sys_Format.Format_Expression;
                            styleFormatCondition.Column = abv.Columns[sys_Format.Format_FieldName];
                            styleFormatCondition.Condition = FormatConditionEnum.Expression;
                            styleFormatCondition.Appearance.BackColor = Color.FromArgb(sys_Format.Format_BackColor);
                            styleFormatCondition.Appearance.BackColor2 = Color.FromArgb(sys_Format.Format_BackColor2);
                            styleFormatCondition.Appearance.ForeColor = Color.FromArgb(sys_Format.Format_ForeColor);
                            styleFormatCondition.Appearance.BorderColor = Color.FromArgb(sys_Format.Format_BorderColor);
                            styleFormatCondition.Appearance.Options.UseBackColor = true;
                            styleFormatCondition.Appearance.Options.UseForeColor = true;
                            styleFormatCondition.Appearance.Options.UseBorderColor = true;
                            abv.FormatConditions.Add(styleFormatCondition);
                            //GridFormatRule gridFormatRule = new GridFormatRule();
                            //FormatConditionRuleValue formatConditionRuleValue = new FormatConditionRuleValue();
                            //gridFormatRule.Column = abv.Columns[sys_Format.Format_FieldName];
                            //gridFormatRule.ApplyToRow = sys_Format.Format_WholeRow;
                            //gridFormatRule.ColumnApplyTo = abv.Columns[sys_Format.Format_FieldName];
                            //gridFormatRule.Name = sys_Format.Format_Name;
                            //formatConditionRuleValue.Appearance.BackColor = Color.FromArgb(sys_Format.Format_BackColor);
                            //formatConditionRuleValue.Appearance.BackColor2 = Color.FromArgb(sys_Format.Format_BackColor2);
                            //formatConditionRuleValue.Appearance.ForeColor = Color.FromArgb(sys_Format.Format_ForeColor);
                            //formatConditionRuleValue.Appearance.BorderColor = Color.FromArgb(sys_Format.Format_BorderColor);
                            //formatConditionRuleValue.Appearance.Options.UseBackColor = true;
                            //formatConditionRuleValue.Appearance.Options.UseForeColor = true;
                            //formatConditionRuleValue.Appearance.Options.UseBorderColor = true;
                            //formatConditionRuleValue.Condition = DevExpress.XtraEditors.FormatCondition.Expression;
                            //formatConditionRuleValue.Expression = sys_Format.Format_Expression;
                            //gridFormatRule.Rule = formatConditionRuleValue;
                            //abv.FormatRules.Add(gridFormatRule);
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
        #region InitializeValidation
        private List<Sys_Validation> ValidationList = new List<Sys_Validation>();
        private void InitializeValidation()
        {
            try
            {
                ValidationList.Clear();
                if (SysPage == null) return;
                List<MyParameter> myParameters = new List<MyParameter>();
                myParameters.Add("@Menu_Id", DbType.String, SysPage.Menu_Id, null);
                DataTable dt = BaseService.Open("SystemMenu_Validation", myParameters);
                List<Sys_Validation> sys_Validations = EntityHelper.GetEntities<Sys_Validation>(dt);
                ValidationList.AddRange(sys_Validations);
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        //输入限制 即简单验证
        //private string InitializeRestrict(string restrict, object editValue)
        //{
        //    switch (restrict)
        //    {
        //        case "0": //必填
        //            if (string.IsNullOrEmpty(editValue.ToStringEx()))
        //                return "Not Null";
        //            else
        //                return string.Empty;
        //        case "1": //大于0
        //            if (editValue.ToIntEx() <= 0)
        //                return "Greater Than Zero";
        //            else
        //                return string.Empty;
        //        case "2": //非负数
        //            if (editValue.ToIntEx() < 0)
        //                return "Greater Or Equal Zero";
        //            else
        //                return string.Empty;
        //        case "3":
        //            if (editValue.ToIntEx() > 100 || editValue.ToIntEx() < 0)
        //                return "0~100";
        //            else
        //                return string.Empty;
        //        case "4":
        //            if (editValue.ToIntEx() > 100 || editValue.ToIntEx() < 0)
        //                return "0~100";
        //            else
        //                return string.Empty;
        //        case "5":
        //            break;
        //        case "6":
        //            break;
        //        case "7":
        //            break;
        //        case "8":
        //            break;
        //        case "9":
        //            break;
        //        default:
        //            break;
        //    }
        //    return string.Empty;
        //}
        private void InitializeValidationBaseEdit()
        {
            try
            {
                DXErrorProvider dxp = new DXErrorProvider();
                foreach (Sys_Validation sys_Validation in ValidationList.OrderBy(v => v.Validation_Sort))
                {
                    Sys_Bind sys_Bind = BindList.Find(b => b.Bind_Name == sys_Validation.Validation_FieldName && b.Bind_WorkSet == sys_Validation.Validation_WorkSet);
                    if (sys_Bind != null)
                    {
                        BaseEdit baseEdit = (BaseEdit)GetControl(sys_Bind.Bind_Field, typeof(BaseEdit));
                        if (baseEdit == null) baseEdit = (BaseEdit)GetControl(sys_Bind.Bind_Push, typeof(BaseEdit));
                        if (baseEdit == null) continue;
                        //this.ValidateChildren(); 验证顺序是按照Controls.Add的先后
                        baseEdit.Validating += delegate (object sender, CancelEventArgs e)
                            {
                                if (dxp.GetControlsWithError().Count > 0 && !dxp.GetControlsWithError().Contains(baseEdit)) return;
                                if (this.IsInitializing) return;
                                List<MyParameter> mps = InitializeBind(sys_Bind.Bind_WorkSet, true);
                                object val = null;
                                Sys_Bind field = BindList.Find(b => b.Bind_Name == sys_Validation.Validation_FieldName);
                                if (field != null)
                                {
                                    if (string.IsNullOrEmpty(field.Bind_Property))
                                        field.Bind_Property = "EditValue";
                                    val = GetValue(field.Bind_Field, field.Bind_Property);
                                    if (val == null)
                                        val = GetValue(field.Bind_Field, field.Bind_Property);
                                    if (val == DBNull.Value) val = null;
                                    mps.Add("@Value", (DbType)field.Bind_SqlDbType, val, null);
                                }
                                object rul = sys_Validation.Validation_Ruler;
                                mps.Add("@Ruler", (DbType)field.Bind_SqlDbType, rul, null);
                                Sys_Bind ruler = BindList.Find(b => b.Bind_Name == sys_Validation.Validation_Ruler);
                                if (ruler != null)
                                {
                                    Control[] rulers = this.Controls.Find(ruler.Bind_Field, true);
                                    if (rulers.Length > 0)
                                    {
                                        rul = ReflectionHelper.GetProperty(rulers[0], "EditValue");
                                        if (rul == null || rul == DBNull.Value)
                                            rul = ReflectionHelper.GetProperty(rulers[0], "Text");
                                        if (rul == DBNull.Value) rul = null;
                                        mps.Add("@Ruler", (DbType)field.Bind_SqlDbType, rul, null);
                                    }
                                }
                                bool chk = false;
                                if (!string.IsNullOrEmpty(sys_Validation.Validation_Formula))
                                {
                                    DataTable dt = new DataTable();
                                    foreach (Sys_Bind sBind in BindList.Where(b => b.Bind_WorkSet == sys_Validation.Validation_WorkSet))
                                    {
                                        if (dt.Columns[sBind.Bind_Name] == null)
                                            dt.Columns.Add(sBind.Bind_Name, ConvertHelper.GetNetType((DbType)field.Bind_SqlDbType));
                                    }
                                    DataRow dr = dt.NewRow();
                                    foreach (Sys_Bind sBind in BindList.Where(b => b.Bind_WorkSet == sys_Validation.Validation_WorkSet))
                                    {
                                        if (string.IsNullOrEmpty(field.Bind_Property))
                                            field.Bind_Property = "EditValue";
                                        object fval = GetValue(sBind.Bind_Field, field.Bind_Property);
                                        dr[sBind.Bind_Name] = fval;
                                        if (!string.IsNullOrEmpty(sBind.Bind_Push) && fval == null)
                                            dr[sBind.Bind_Name] = GetValue(sBind.Bind_Push, field.Bind_Property);
                                    }
                                    dt.Rows.Add(dr);
                                    DataView dv = dt.DefaultView;
                                    DataRowView drv = dv[0];
                                    ExpressionEvaluator ev = new ExpressionEvaluator(((ITypedList)dv).GetItemProperties(null), CriteriaOperator.Parse(sys_Validation.Validation_Formula));
                                    object obj = ev.Evaluate(drv);
                                    chk = obj.ToBoolEx();
                                }
                                else if (!string.IsNullOrEmpty(sys_Validation.Validation_Expression))
                                {
                                    chk = BaseService.Get(sys_Validation.Validation_Expression, mps).ToBoolEx();
                                }
                                if (sys_Validation.Validation_Negate) chk = !chk;
                                if (!chk)
                                {
                                    baseEdit.BorderStyle = BorderStyles.Simple;
                                    baseEdit.Properties.Appearance.BorderColor = Color.Red;
                                    if (sys_Validation.Validation_ToolTip)
                                    {
                                        baseEdit.ToolTip = sys_Validation.Validation_ErrorText;
                                    }
                                    if (sys_Validation.Validation_Confirm)
                                    {
                                        SharedFunc.RaiseError(sys_Bind.Bind_Nick + ":" + sys_Validation.Validation_ErrorText);
                                    }
                                    if (sys_Validation.Validation_SetError)
                                    {
                                        dxp.SetError(baseEdit, sys_Validation.Validation_ErrorText);
                                        dxp.SetIconAlignment(baseEdit, ErrorIconAlignment.MiddleLeft);
                                    }
                                    e.Cancel = sys_Validation.Validation_Cancel;
                                    if (ToolPress)
                                    {
                                        e.Cancel = true;
                                    }
                                    if (e.Cancel)
                                    {
                                        dxp.SetError(baseEdit, sys_Validation.Validation_ErrorText);
                                        dxp.SetIconAlignment(baseEdit, ErrorIconAlignment.MiddleLeft);
                                    }
                                }
                                else
                                {
                                    dxp.ClearErrors();
                                    baseEdit.BorderStyle = BorderStyles.Default;
                                    baseEdit.ToolTip = null;
                                }
                            };
                    }
                }
                ////foreach (var item in BindList.Where(b => !string.IsNullOrEmpty(b.Bind_Restrict)))
                //{
                //    Control[] ctrls = this.Controls.Find(item.Bind_Field, true);
                //    if (ctrls.Length > 0)
                //    {
                //        BaseEdit baseEdit = (BaseEdit)ctrls[0];
                //        //this.ValidateChildren(); 验证顺序是按照Controls.Add的先后
                //        baseEdit.Validating += delegate (object sender, CancelEventArgs e)
                //        {
                //            string error = InitializeRestrict(item.Bind_Restrict, baseEdit.EditValue);
                //            if (!string.IsNullOrEmpty(error))
                //            {
                //                baseEdit.BorderStyle = BorderStyles.Simple;
                //                baseEdit.Properties.Appearance.BorderColor = Color.Red;
                //                dxp.SetError(baseEdit, error);
                //                dxp.SetIconAlignment(baseEdit, ErrorIconAlignment.MiddleLeft);
                //            }
                //            else
                //            {
                //                dxp.ClearErrors();
                //                baseEdit.BorderStyle = BorderStyles.Default;
                //                baseEdit.ToolTip = null;
                //            }
                //        };
                //    }
                //}
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        #endregion
    }
}