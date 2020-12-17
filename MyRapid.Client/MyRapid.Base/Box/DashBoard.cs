/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.Spreadsheet;
using MyRapid.Proxy;
using MyRapid.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyRapid.Base
{
    public partial class DashBoard : DevExpress.XtraEditors.XtraForm
    {
        public DashBoard()
        {
            
            
            
            InitializeComponent();
            
        }
        public string Workset;
        public string Parameter;
        public byte[] fileByte;
        public int intval
        {
            get { return timer1.Interval; }
            set
            {
                timer1.Interval = value;
                if (value > 0) timer1.Enabled = true;
            }
        }
        private void ShowDashBoard()
        {
            
            
            
            try
            {
                if (string.IsNullOrEmpty(Workset)) return;
                DataTable dt = BaseService.Open(Workset, null);
                Dictionary<string, object> dic = new Dictionary<string, object>();
                if (!string.IsNullOrEmpty(Workset))
                {
                    DataTable pt = BaseService.Open(Parameter, null);
                    if (pt.Rows.Count > 0)
                    {
                        foreach (DataColumn col in pt.Columns)
                        {
                            dic[col.ColumnName] = pt.Rows[0][col.ColumnName];
                        }
                    }
                }
                Workbook wb = new Workbook();
                if (fileByte != null)
                {
                    wb.LoadDocument(fileByte, DocumentFormat.Xlsx);
                }
                wb.MailMergeDataSource = dt;
                foreach (var p in dic)
                {
                    wb.MailMergeParameters.AddParameter(p.Key, p.Value);
                }
                IList<IWorkbook> lwb = wb.GenerateMailMergeDocuments();
                MemoryStream ms = new MemoryStream();
                lwb[0].SaveDocument(ms, DocumentFormat.Xlsx);
                spreadsheetControl1.LoadDocument(ms.ToArray(), DocumentFormat.Xlsx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        private string rptName = Guid.NewGuid().ToString();
        private void DashBoard_KeyDown(object sender, KeyEventArgs e)
        {
            
            
            
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            
        }
        private void spreadsheetControl1_KeyDown(object sender, KeyEventArgs e)
        {
            
            
            
            if (e.KeyCode == Keys.Escape)
            {
                timer1.Enabled = false;
                this.Dispose();
            }
            
        }
        private void spreadsheetControl1_DoubleClick(object sender, EventArgs e)
        {
            
            
            
            this.WindowState = FormWindowState.Maximized;
            
        }
        private void DashBoard_Load(object sender, EventArgs e)
        {
            
            
            
            ShowDashBoard();
            
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            
            
            ShowDashBoard();
            //timer1.Dispose();
            
        }
        int x; int y;
        bool flag;
        private void spreadsheetControl1_MouseDown(object sender, MouseEventArgs e)
        {
            
            
            
            x = e.X;
            y = e.Y;
            flag = true;
            
        }
        private void spreadsheetControl1_MouseMove(object sender, MouseEventArgs e)
        {
            
            
            
            if (flag)
            {
                this.Top = this.Top + (e.Y - y);
                this.Left = this.Left + (e.X - x);
            }
            
        }
        private void spreadsheetControl1_MouseUp(object sender, MouseEventArgs e)
        {
            
            
            
            flag = false;
            
        }
    }
}