/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraEditors;
using MyRapid.Base;
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyRapid.SystemManager
{
    public partial class SystemConnection : ChildPage
    {
        public SystemConnection()
        {
            InitializeComponent();
            foreach (Sys_Bind bind in BindList)
            {
                if (!string.IsNullOrEmpty(bind.Bind_Popup))
                {
                    Control[] ctrls = this.Controls.Find(bind.Bind_Field, true);
                    if (ctrls.Length > 0)
                    {
                        Control ctrl = ctrls[0];
                        InitializeBaseEdit(bind, (BaseEdit)ctrl);
                        if (ctrl.GetType() == typeof(LookUpEdit))
                        {
                            ((LookUpEdit)ctrl).ItemIndex = 0;
                        }
                    }
                }
            }
        }
        private void fConnection_Connection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(fConnection_Connection.Text))
            {
                string seed = "";
                switch (fConnection_Type.Text.ToLower())
                {
                    case "mssql":
                        seed = "Data Source={0},{1}; Initial Catalog={2}; User Id={3}; Password={4};";
                        seed = string.Format(seed, fConnection_Server.Text, fConnection_Port.Text, fConnection_DataBase.Text, fConnection_UserName.Text, fConnection_Password.Text);
                        break;
                    case "mysql":
                        seed = "Server={0};Port={1};Database={2};Uid={3};Pwd={4};";
                        seed = string.Format(seed, fConnection_Server.Text, fConnection_Port.Text, fConnection_DataBase.Text, fConnection_UserName.Text, fConnection_Password.Text);
                        break;
                    case "sqlite":
                        seed = "Data Source={0};Password={1};";
                        seed = string.Format(seed, fConnection_DataBase.Text, fConnection_Password.Text);
                        break;
                    case "access":
                        seed = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Jet OLEDB:Database Password={1};";
                        seed = string.Format(seed, fConnection_DataBase.Text, fConnection_Password.Text);
                        break;
                    case "oracle":
                        seed = "Data Source={0};User Id={1};Password={2};";
                        seed = string.Format(seed, fConnection_DataBase.Text, fConnection_UserName.Text, fConnection_Password.Text);
                        break;
                    default:
                        break;
                }
                fConnection_Connection.Text = seed;
            }
        }
        public void Test()
        {
            try
            {
                SqlHelper.connectionString = fConnection_Connection.Text;
                SqlHelper.GetDataTable("SELECT 0");
                SharedFunc.ShowError("Succeed", MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                SharedFunc.ShowError(ex.Message);
            }
        }
    }
}