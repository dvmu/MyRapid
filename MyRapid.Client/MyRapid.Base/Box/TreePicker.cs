/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
namespace MyRapid.Base
{
    public partial class TreePicker : DevExpress.XtraEditors.XtraForm
    {
        public TreePicker()
        {

            InitializeComponent();
            CancelButton = new BarItemEx(barCancel, DialogResult.Cancel);
            //效果不好  当焦点在接受Enter的控件上无效
            AcceptButton = new BarItemEx(barOk, DialogResult.OK);
        }
        public string ParentFieldName
        {
            get
            {
                return tr.ParentFieldName;
            }
            set
            {
                tr.ParentFieldName = value;
            }
        }
        public string KeyFieldName
        {
            get
            {
                return tr.KeyFieldName;
            }
            set
            {
                tr.KeyFieldName = value;
            }
        }
        public bool MultiSelect
        {
            get { return tr.OptionsSelection.MultiSelect; }
            set { tr.OptionsSelection.MultiSelect = value; }
        }
        public TreeListMultiSelectMode MultiSelectMode
        {
            get { return tr.OptionsSelection.MultiSelectMode; }
            set { tr.OptionsSelection.MultiSelectMode = value; }
        }
        public object DataSource
        {
            get { return tr.DataSource; }
            set
            {
                tr.DataSource = value;
            }
        }
        public DataTable ReturnItem
        {
            get
            {
                DataTable SourceTable = (DataTable)tr.DataSource;
                DataTable ResultTable = SourceTable.Clone();
                if (tr.FocusedNode != null)
                {
                    DataRowView dr = (DataRowView)tr.GetDataRecordByNode(tr.FocusedNode);
                    ResultTable.Rows.Add(dr.Row.ItemArray);
                }
                else
                {
                    ResultTable.Rows.Add(ResultTable.NewRow());
                }
                return ResultTable;
            }
        }
        public List<Sys_PopupBind> PopupBindList { get; set; }
        private void TreePicker_Load(object sender, EventArgs e)
        {

            //tr.Columns.Clear();
            tr.OptionsBehavior.Editable = false;
            foreach (Sys_PopupBind sys_PopupBind in PopupBindList.OrderBy(p => p.PopupBind_Sort))
            {
                TreeListColumn gc = new TreeListColumn();
                gc.FieldName = sys_PopupBind.PopupBind_Field;
                gc.VisibleIndex = sys_PopupBind.PopupBind_Sort;
                gc.Visible = sys_PopupBind.PopupBind_Visible;
                gc.Caption = sys_PopupBind.PopupBind_Nick;
                gc.OptionsFilter.AutoFilterCondition = AutoFilterCondition.Contains;
                tr.Columns.Add(gc);
            }
            tr.ForceInitialize();
            tr.ExpandAll();
            tr.BestFitColumns();
        }
        private void tr_DoubleClick(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void TreePicker_Shown(object sender, EventArgs e)
        {
        }
        private void barOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void barCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}