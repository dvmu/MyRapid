/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraEditors;
using MyRapid.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace MyRapid.Base
{
    public partial class ScriptPage : XtraForm
    {
        public ScriptPage(string script)
        {

            InitializeComponent();
            CancelButton = new BarItemEx(barCancel, DialogResult.Cancel);
            //效果不好  当焦点在接受Enter的控件上无效
            AcceptButton = new BarItemEx(barOk, DialogResult.OK);
            sqlEdit1.Script = script;
        }
        public string Script
        {
            get
            {
                return sqlEdit1.Script;
            }
            set
            {
                sqlEdit1.Script = value;
            }
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