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
    public partial class SystemRoleMenu : ChildPage
    {
        public SystemRoleMenu()
        {
            InitializeComponent();
        }
        private void gdf_DataSourceChanged(object sender, EventArgs e)
        {
            trl.DataSource = gdf.DataSource;
        }
        public override void Save()
        {
            trl.CloseEditor();
            base.Save();
        }
        private void chkChildrenNode(TreeListNode pNode, bool chk)
        {
            foreach (TreeListNode node in pNode.Nodes)
            {
                node.Checked = chk;
                chkChildrenNode(node, chk);
            }
        }
        private void chkParentNode(TreeListNode cNode, bool chk)
        {
            if (cNode.ParentNode != null)
            {
                TreeListNode node = cNode.ParentNode;
                node.Checked = chk;
                chkParentNode(node, chk);
            }
        }
        private void trl_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            if (e.Node.Checked)
            {
                chkChildrenNode(e.Node, true);
                chkParentNode(e.Node, true);
            }
            else
            {
                chkChildrenNode(e.Node, false);
            }
        }
    }
}