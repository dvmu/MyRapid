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
    public partial class SystemMenu : ChildPage
    {
        public SystemMenu()
        {
            InitializeComponent();
        }
        private void gdf_DataSourceChanged(object sender, EventArgs e)
        {
            trl.DataSource = gdf.DataSource;
        }
        public override void Save()
        {
            SortNode(trl.Nodes);
            base.Save();
        }
        private void SortNode(TreeListNodes trNodes)
        {
            int nodeIndex = 0;
            foreach (TreeListNode item in trNodes)
            {
                nodeIndex += 1;
                TreeListNode parentNode = item.ParentNode;
                if (parentNode != null)
                {
                    string parentSort = parentNode.GetValue("Menu_Sort").ToStringEx();
                    item.SetValue("Menu_Sort", parentSort + "-" + (nodeIndex * 100 + 10000).ToStringEx());
                }
                else
                {
                    item.SetValue("Menu_Sort", (nodeIndex * 100 + 10000).ToStringEx());
                }
                SortNode(item.Nodes);
            }
        }
    }
}