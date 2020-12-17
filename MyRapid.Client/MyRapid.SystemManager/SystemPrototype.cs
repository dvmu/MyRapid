/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.Base;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyRapid.SystemManager
{
    public partial class SystemPrototype : ChildPage
    {
        public SystemPrototype()
        {
            InitializeComponent();
        }
        public override void Save()
        {
            base.Save();
        }
        private void ssc_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < gvr.RowCount; i++)
                {
                    gvr.SetRowCellValue(i, "PrototypeItem_Sheet", ssc.ActiveWorksheet.Name);
                }
                DataTable dt = (DataTable)gdr.DataSource;
                string fliter = string.Format("PrototypeItem_Sheet = '{0}' AND PrototypeItem_Cell = '{1}'", ssc.ActiveWorksheet.Name, spreadsheetNameBoxControl1.Text);
                if (dt.Select(fliter).Length == 0)
                {
                    DataRow dr = dt.NewRow();
                    dr["PrototypeItem_Sheet"] = ssc.ActiveWorksheet.Name;
                    dr["PrototypeItem_Cell"] = spreadsheetNameBoxControl1.Text;
                    dt.Rows.Add(dr);
                }
                for (int i = 0; i < gvr.RowCount; i++)
                {
                    string prototypeItem_Sheet = gvr.GetRowCellValue(i, "PrototypeItem_Sheet").ToStringEx();
                    string prototypeItem_Cell = gvr.GetRowCellValue(i, "PrototypeItem_Cell").ToStringEx();
                    if (prototypeItem_Sheet == ssc.ActiveWorksheet.Name && prototypeItem_Cell == spreadsheetNameBoxControl1.Text)
                    {
                        gvr.FocusedRowHandle = i;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void ssc_SheetRenamed(object sender, DevExpress.Spreadsheet.SheetRenamedEventArgs e)
        {
            try
            {
                for (int i = 0; i < gvr.RowCount; i++)
                {
                    gvr.SetRowCellValue(i, "PrototypeItem_Sheet", ssc.ActiveWorksheet.Name);
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void gvl_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gvl.IsNewItemRow(gvl.FocusedRowHandle)) ssc.CreateNewDocument();
                if (gvl.FocusedRowHandle < 0) return;
                object obj = gvl.GetFocusedRowCellValue("Prototype_Sheet");
                if (obj != DBNull.Value)
                {
                    byte[] bytes = (byte[])obj;
                    ssc.LoadDocument(bytes, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                }
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
        private void gvl_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                MemoryStream ms = new MemoryStream();
                ssc.SaveDocument(ms, DevExpress.Spreadsheet.DocumentFormat.Xlsx);
                byte[] bytes = ms.ToArray();
                gvl.SetFocusedRowCellValue("Prototype_Sheet", bytes);
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
    }
}