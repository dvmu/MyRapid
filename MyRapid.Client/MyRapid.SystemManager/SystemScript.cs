/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraTreeList.Nodes;
using MyRapid.Base;
using MyRapid.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyRapid.SystemManager
{
    public partial class SystemScript : ChildPage
    {
        public SystemScript()
        {
            InitializeComponent();
            gvb.OptionsBehavior.AutoPopulateColumns = true;
        }
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider err = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
        private void BuidConnection()
        {
            string conn1 = "Data Source={0};Integrated Security=True;";
            string conn2 = "Data Source={0};User ID={1};Password={2}";
            if (string.IsNullOrEmpty(fServer.Text))
            {
                err.SetError(fServer, "IsNullOrEmpty");
            }
            if (string.IsNullOrEmpty(fUser.Text))
            {
                SqlHelper.connectionString = string.Format(conn1, fServer.Text);
            }
            else
            {
                SqlHelper.connectionString = string.Format(conn2, fServer.Text, fUser.Text, fPass.Text);
            }
        }
        public void Run()
        {
            try
            {
                BuidConnection();
                string sql = string.Format(fSql.Script, fPara.Text.Split(';'));
                gvb.Columns.Clear();
                gdb.DataSource = SqlHelper.GetDataTable(sql, null);
                gvb.BestFitColumns();
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        public void Connect()
        {
            try
            {
                BuidConnection();
                SqlHelper.GetDataTable("SELECT 0", null);
                //SharedFunc.RaiseError("Succeed");
                DataTable dt = SqlHelper.GetDataTable("SELECT NAME ,NEWID() PID ,NEWID() KID FROM MASTER..SYSDATABASES ORDER BY NAME", null);
                trr.DataSource = dt;
                trr.ForceInitialize();
                foreach (TreeListNode item in trr.Nodes)
                {
                    item.Nodes.Add("Null");
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void trr_BeforeExpand(object sender, DevExpress.XtraTreeList.BeforeExpandEventArgs e)
        {
            e.Node.Nodes.Clear();
            if (e.Node.Level == 0)
            {
                DataTable dt = SqlHelper.GetDataTable(string.Format("SELECT NAME FROM {0}..SYSOBJECTS WHERE XTYPE='U' ORDER BY NAME", e.Node.GetValue("NAME")), null);
                foreach (DataRow dr in dt.Rows)
                {
                    e.Node.Nodes.Add(dr);
                }
                foreach (TreeListNode item in e.Node.Nodes)
                {
                    item.Nodes.Add("Null");
                }
            }
            if (e.Node.Level == 1)
            {
                DataTable dt = SqlHelper.GetDataTable(string.Format("USE {0}\r\nSELECT NAME FROM SYSCOLUMNS WHERE ID=OBJECT_ID('{1}') ORDER BY NAME", e.Node.ParentNode.GetValue("NAME"), e.Node.GetValue("NAME")), null);
                foreach (DataRow dr in dt.Rows)
                {
                    e.Node.Nodes.Add(dr);
                }
            }
        }
        private void trr_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node.Level == 1)
            {
                gvb.Columns.Clear();
                gdb.DataSource = SqlHelper.GetDataTable(string.Format("USE {0}\r\nSELECT TOP 5 * FROM {1}", e.Node.ParentNode.GetValue("NAME"), e.Node.GetValue("NAME")), null);
                gvb.BestFitColumns();
            }
        }
        private void fServer_EditValueChanged(object sender, EventArgs e)
        {
            err.ClearErrors();
        }
    }
}