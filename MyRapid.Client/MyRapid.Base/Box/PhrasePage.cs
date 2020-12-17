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
    public partial class PhrasePage : DevExpress.XtraEditors.XtraForm
    {
        public PhrasePage(string returnText)
        {
            //Start
            InitializeComponent();
            CancelButton = new BarItemEx(barCancel, DialogResult.Cancel);
            //效果不好  当焦点在接受Enter的控件上无效
            AcceptButton = new BarItemEx(barOk, DialogResult.OK);
            //
            Spliter = ", ";
            editBox.Text = returnText;
        }
        public object DataSource
        {
            get { return listBoxControl1.DataSource; }
            set
            {
                listBoxControl1.DataSource = value;
            }
        }
        public string DisplayMember
        {
            get
            {
                return listBoxControl1.DisplayMember;
            }
            set
            {
                listBoxControl1.DisplayMember = value;
            }
        }
        [DefaultValue(", ")]
        public string Spliter { get; set; }
        public string ValueMember
        {
            get
            {
                return listBoxControl1.ValueMember;
            }
            set
            {
                listBoxControl1.ValueMember = value;
            }
        }
        public string ReturnText
        {
            get
            {
                return editBox.Text;
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
        private void listBoxControl1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(editBox.Text))
            {
                editBox.Text += listBoxControl1.SelectedValue.ToStringEx();
            }
            else
            {
                editBox.Text += Spliter + listBoxControl1.SelectedValue.ToStringEx();
            }
        }
    }
}