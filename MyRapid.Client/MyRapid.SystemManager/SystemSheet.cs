/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using MyRapid.Base;
using MyRapid.Proxy;
using MyRapid.Code;
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
    public partial class SystemSheet : ChildPage
    {
        public SystemSheet()
        {
            InitializeComponent();
        }
        public void DesignSheet()
        {
            //string wk = gv.GetFocusedRowCellValue("Sheet_Workset").ToStringEx();
            //int intval = gv.GetFocusedRowCellValue("Sheet_Interval").ToIntEx();
            //if (string.IsNullOrEmpty(wk)) return;
            //DataTable dt = BaseService.Open(wk, null);
            //wk = gv.GetFocusedRowCellValue("Sheet_Parameter").ToStringEx();
            //Dictionary<string, object> dic = new Dictionary<string, object>();
            //if (!string.IsNullOrEmpty(wk))
            //{
            //    DataTable pt = BaseService.Open(wk, null);
            //    if (pt.Rows.Count > 0)
            //    {
            //        foreach (DataColumn col in pt.Columns)
            //        {
            //            dic[col.ColumnName] = pt.Rows[0][col.ColumnName];
            //        }
            //    }
            //}
            //SpreadsheetDesigner sd;
            //object obj = gv.GetFocusedRowCellValue("Sheet_Bytes");
            //byte[] bytes;
            //if (obj != DBNull.Value)
            //{
            //    bytes = (byte[])obj;
            //    sd = new SpreadsheetDesigner(bytes, dt, dic);
            //}
            //else
            //{
            //    sd = new SpreadsheetDesigner(dt, dic);
            //}
            //sd.ShowDialog();
            //gv.SetFocusedRowCellValue("Sheet_Bytes", sd.ByteContent);
        }
        public override void Preview()
        {
            string wk = gv.GetFocusedRowCellValue("Sheet_Workset").ToStringEx();
            int intval = gv.GetFocusedRowCellValue("Sheet_Interval").ToIntEx();
            string p = gv.GetFocusedRowCellValue("Sheet_Parameter").ToStringEx();
            object obj = gv.GetFocusedRowCellValue("Sheet_Bytes");
            if (obj == DBNull.Value) return;
            byte[] bytes = (byte[])obj;
            DashBoard db = new DashBoard();
            db.intval = intval;
            db.fileByte = bytes;
            db.Workset = wk;
            db.Parameter = p;
            int wint = gv.GetFocusedRowCellValue("Sheet_Width").ToIntEx();
            int hint = gv.GetFocusedRowCellValue("Sheet_Height").ToIntEx();
            if (wint > 0) db.Width = Math.Max(wint, 80);
            if (hint > 0) db.Height = Math.Max(hint, 60);
            db.Show();
        }
    }
}