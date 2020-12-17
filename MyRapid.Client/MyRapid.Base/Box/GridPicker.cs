/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyRapid.Base
{
    public partial class GridPicker : DevExpress.XtraEditors.XtraForm
    {
        public GridPicker()
        {
            //Start
            InitializeComponent();
            CancelButton = new BarItemEx(barCancel, DialogResult.Cancel);
            //效果不好  当焦点在接受Enter的控件上无效
            AcceptButton = new BarItemEx(barOk, DialogResult.OK);
            //
            gv.OptionsSelection.CheckBoxSelectorColumnWidth = 40;
        }
        public int BestFitMaxRowCount
        {
            get { return gv.BestFitMaxRowCount; }
            set { gv.BestFitMaxRowCount = value; }
        }
        public bool MultiSelect
        {
            get { return gv.OptionsSelection.MultiSelect; }
            set { gv.OptionsSelection.MultiSelect = value; }
        }
        public GridMultiSelectMode MultiSelectMode
        {
            get { return gv.OptionsSelection.MultiSelectMode; }
            set
            {
                gv.OptionsSelection.MultiSelectMode = value;
            }
        }
        public object DataSource
        {
            get { return gd.DataSource; }
            set
            {
                gd.DataSource = value;
                //DataTable dt = (DataTable)gv.GridControl.DataSource;
                //dt.Rows.InsertAt(dt.NewRow(), 0);
                gv.BestFitColumns();
            }
        }
        public DataTable ReturnTable
        {
            get
            {
                DataTable SourceTable = (DataTable)gd.DataSource;
                DataTable ResultTable = SourceTable.Clone();
                if (gv.FocusedRowHandle >= 0)
                {
                    foreach (int i in gv.GetSelectedRows())
                    {
                        ResultTable.Rows.Add(gv.GetDataRow(i).ItemArray);
                    }
                }
                else
                {
                    ResultTable.Rows.Add(ResultTable.NewRow());
                }
                return ResultTable;
            }
        }
        public List<Sys_PopupBind> PopupBindList { get; set; }
        private void GridPicker_Load(object sender, EventArgs e)
        {

            foreach (Sys_PopupBind sys_PopupBind in PopupBindList.OrderBy(p => p.PopupBind_Sort))
            {
                GridColumn gc = new GridColumn();
                gc.FieldName = sys_PopupBind.PopupBind_Field;
                gc.VisibleIndex = sys_PopupBind.PopupBind_Sort;
                gc.Visible = sys_PopupBind.PopupBind_Visible;
                gc.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                gc.Caption = sys_PopupBind.PopupBind_Nick;
                gv.Columns.Add(gc);
            }
            gv.BestFitMaxRowCount = 100;
            gv.BestFitColumns();
            gv.CustomDrawRowIndicator += InitializeRowIndicator;
            gv.IndicatorWidth = 48;
        }
        private bool flag;
        private void gv_DoubleClick(object sender, EventArgs e)
        {

            if (flag)
            {
                if (flag)
                {
                    GridColumn gc = hInfo.Column;
                    if (gc != null && gc.FieldName != "DX$CheckboxSelectorColumn")
                        gv.SelectRow(hInfo.RowHandle);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo;
        private void gv_MouseDown(object sender, MouseEventArgs e)
        {

            hInfo = gv.CalcHitInfo(new Point(e.X, e.Y));
            flag = hInfo.InRow;

        }
        private void InitializeRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
        private void barCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void barOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}