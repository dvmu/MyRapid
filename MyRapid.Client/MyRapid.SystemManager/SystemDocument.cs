/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraBars;
using MyRapid.Base;
using MyRapid.SysEntity;
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
    public partial class SystemDocument : ChildPage
    {
        public SystemDocument()
        {
            InitializeComponent();
        }
        private void gdl_DataSourceChanged(object sender, EventArgs e)
        {
            trl.DataSource = gdl.DataSource;
        }
        private void gcl_DoubleClick(object sender, EventArgs e)
        {
            trl.Visible = !trl.Visible;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Sys_Button sys_Button = ButtonList.Find(b => b.Button_Sub == "Save");
            if (sys_Button != null)
            {
                BarItem barItem = (BarItem)sys_Button.Button_BarItem;
                if (barItem != null)
                {
                    barItem.PerformClick();
                    timer1.Enabled = false;
                }
            }
        }
        private void gdf_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gdf.Text))
            {
                timer1.Enabled = true;
                barCount.Caption = gdf.Text.Length.ToString();
            }
        }
    }
}