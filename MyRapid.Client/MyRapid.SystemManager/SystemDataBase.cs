/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.Base;
using MyRapid.Code;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraBars;
namespace MyRapid.SystemManager
{
    public partial class SystemDataBase : ChildPage
    {
        public SystemDataBase()
        {
            InitializeComponent();
            gvl.ActiveFilterString = "NOT StartsWith([Table_Name], 'Sys_')";

        }
        private void SystemDataBase_Shown(object sender, EventArgs e)
        {
            InitializeButtons();
        }
        private void InitializeButtons()
        {
            Sys_Button sys_Button = ButtonList.Find(b => b.Button_Name.EndsWith("Extra"));
            if (sys_Button != null)
            {
                DataTable dt = BaseService.Open("SystemConnection_All", null);
                List<Sys_Connection> Conns = EntityHelper.GetEntities<Sys_Connection>(dt);
                foreach (Sys_Connection conn in Conns)
                {
                    if (!string.IsNullOrEmpty(conn.Connection_Id))
                    {
                        Sys_Button nButton = new Sys_Button();
                        nButton.Button_Id = conn.Connection_Id;
                        nButton.Button_Name = conn.Connection_Name;
                        nButton.Button_Nick = conn.Connection_Name;
                        nButton.Button_Sub = "SwitchConn";
                        nButton.Button_Parent = sys_Button.Button_Id;
                        nButton.Button_Assign = 0;
                        nButton.Button_Visible = true;
                        nButton.Button_Enabled = true;
                        ButtonList.Add(nButton);
                    }
                }
                RefreshTool();
            }
        }
        public void SwitchConn()
        {
            if (LastButton != null)
            {
                List<MyParameter> mps = new List<MyParameter>();
                mps.Add("@WorkSet_Connection", DbType.String, LastButton.Name, null);
                BaseService.Execute("SystemDataBase_Switch", mps, "U");
                base.Open();
            }
        }
        public override void Save()
        {
            gvf.CloseEditor();
            gvf.UpdateCurrentRow();
            DataTable dt = (DataTable)gdf.DataSource;
            if (dt.GetChanges() != null)
            {
                List<Sys_Schema> Sys_Schemas = EntityHelper.GetEntities<Sys_Schema>(dt);
                if (Sys_Schemas.Where(s => s.IsIdentity.Equals(true)).Count() > 1)
                {
                    SharedFunc.ShowError("To Much Identities", "Please Check Input");
                    return;
                }
                string tableName = gvl.GetFocusedRowCellValue("Table_Name").ToStringEx();
                if (!string.IsNullOrEmpty(tableName))
                {
                    string script = ScriptHelper.GenerateTable(tableName, Sys_Schemas);
                    memoEdit1.Text = script;
                    //return;
                    if (!string.IsNullOrEmpty(script))
                    {
                        List<MyParameter> myParameters = new List<MyParameter>();
                        myParameters.Add("@Script", DbType.String, script, null);
                        BaseService.Execute("SystemDataBase_Script", myParameters);
                        dt.AcceptChanges();
                        string tableNick = gvl.GetFocusedRowCellValue("Table_Description").ToStringEx();
                        if (!string.IsNullOrEmpty(tableNick))
                        {
                            gvl.SetFocusedRowCellValue("Table_Description", tableNick);
                            gvl.CloseEditor();
                            gvl.UpdateCurrentRow();
                        }
                    }
                }
            }
            base.Save();
            base.Open();
        }
        #region 快捷添加
        private void gcf_DoubleClick(object sender, EventArgs e)
        {
            gdf.Visible = !gdf.Visible;
        }
        private void gvf_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName.Equals("IsIdentity"))
            {
                if (e.Value.ToBoolEx())
                {
                    gvf.SetFocusedRowCellValue("SqlDbType", "int");
                    gvf.SetFocusedRowCellValue("IsUnique", true);
                    gvf.SetFocusedRowCellValue("IsIndex", true);
                    gvf.SetFocusedRowCellValue("IsNullable", false);
                    for (int i = 0; i < gvf.RowCount - 1; i++)
                    {
                        if (i != e.RowHandle)
                            gvf.SetRowCellValue(i, e.Column, false);
                    }
                }
            }
            if (e.Column.FieldName.Equals("IsPrimary"))
            {
                if (e.Value.ToBoolEx())
                {
                    gvf.SetFocusedRowCellValue("IsUnique", true);
                    gvf.SetFocusedRowCellValue("IsIndex", true);
                    gvf.SetFocusedRowCellValue("IsNullable", false);
                }
            }
            if (e.Column.FieldName.Equals("IsUnique"))
            {
                if (e.Value.ToBoolEx())
                {
                    gvf.SetFocusedRowCellValue("IsIndex", true);
                }
            }
        }

        private void Favorite()
        {
            try
            {
                DataRow dr = gvf.GetFocusedDataRow();
                if (dr == null) return;
                DataTable dt = (DataTable)gdf.DataSource;
                if (dt == null) return;
                DataTable sdt = dt.Clone();
                sdt.Rows.Add(dr.ItemArray);
                DataTable tdt = (DataTable)gdr.DataSource;
                if (tdt == null) return;
                tdt.Merge(sdt);
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void UseFavorite()
        {
            try
            {
                DataRow dr = gvr.GetFocusedDataRow();
                if (dr == null) return;
                DataTable dt = (DataTable)gdr.DataSource;
                if (dt == null) return;
                DataTable tdt = (DataTable)gdf.DataSource;
                if (tdt == null) return;
                DataRow tdr = tdt.NewRow();
                foreach (DataColumn item in tdr.Table.Columns)
                {
                    if (dt.Columns[item.ColumnName] != null)
                    {
                        tdr[item.ColumnName] = dr[item.ColumnName];
                    }
                }
                int lastHandle = gvf.GetFocusedDataSourceRowIndex();
                tdt.Rows.InsertAt(tdr, lastHandle);
                gvf.FocusedRowHandle += 1;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private bool flag;
        private void gv_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gvf.CalcHitInfo(new Point(e.X, e.Y));
            flag = hInfo.InDataRow;
        }
        private void gvf_DoubleClick(object sender, EventArgs e)
        {
            if (flag)
                Favorite();
        }
        private void gvr_MouseDown(object sender, MouseEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo hInfo = gvr.CalcHitInfo(new Point(e.X, e.Y));
            flag = hInfo.InDataRow;
        }
        private void gvr_DoubleClick(object sender, EventArgs e)
        {
            if (flag)
                UseFavorite();
        }

        #endregion

    }
}