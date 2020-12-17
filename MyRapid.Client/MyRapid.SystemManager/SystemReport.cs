/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using MyRapid.Base;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
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
    public partial class SystemReport : ChildPage
    {
        public SystemReport()
        {
            InitializeComponent();
        }

        public void DesignReport()
        {
            try
            {
                if (gridView1.FocusedRowHandle < 0) return;
                this.Cursor = Cursors.WaitCursor;
                string rptName = gridView1.GetFocusedRowCellValue("Report_Name").ToStringEx();
                string rptId = gridView1.GetFocusedRowCellValue("Report_Id").ToStringEx();
                var list = new List<MyParameter>();
                list.Add("cReport_Id", DbType.String, rptId, null);
                object obj = BaseService.Get("SystemReport_Data", list);

                string wk = gridView1.GetFocusedRowCellValue("Report_WorkSet").ToStringEx();
                DataTable dt = new DataTable();

                if (!string.IsNullOrEmpty(wk))
                {
                    var mps = InitializeBind(wk);
                    dt = BaseService.Open(wk, mps);
                }
                dt.TableName = "DataSource";                
                string rptFile = Guid.NewGuid().ToString();
                XRDesignForm designForm = new XRDesignForm();
                XtraReport xtraReport = new XtraReport();
                xtraReport.Name = rptName;
                if (obj != DBNull.Value)
                {
                    byte[] bs = (byte[])obj;
                    File.WriteAllBytes(rptFile, bs);
                    xtraReport.LoadLayout(bs.ToStream());
                }
                //xtraReport.RequestParameters = false;
                xtraReport.DataSource = dt;
                //xtraReport.Parameters.Clear();
                //xtraReport.Parameters.AddRange(ps.ToArray());
                designForm.OpenReport(xtraReport);
                designForm.Shown += delegate
                {
                    if (designForm.ActiveDesignPanel != null)
                    {
                        designForm.ActiveDesignPanel.Text = rptName;
                        designForm.ActiveDesignPanel.FileName = rptFile;
                    }
                };
                designForm.FormClosing += delegate
                {
                    MemoryStream ms = new MemoryStream();
                    designForm.ActiveDesignPanel.Report.SaveLayout(ms);
                    list.Add("Report_Bytes", DbType.Binary, ms.ToBytes(), null);
                    BaseService.Execute("SystemReport_Data", list, "U");
                    //gridView1.SetFocusedRowCellValue("Report_Bytes", ms.ToBytes());
                    File.Delete(rptFile);
                };
                designForm.Show();
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

        public override void Print()
        {
            string wk = gridView1.GetFocusedRowCellValue("Report_Name").ToString();
            base.Print(wk);
        }
        public override void Preview()
        {
            string wk = gridView1.GetFocusedRowCellValue("Report_Name").ToString();
            base.Preview(wk);
        }
    }
}