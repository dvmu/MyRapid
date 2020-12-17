/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList.Columns;
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
    public partial class SystemDictionary : ChildPage
    {
        public SystemDictionary()
        {
            InitializeComponent();
        }
        private void gdb_DataSourceChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gdb.DataSource;
            if (dt == null) return;
            //规避键值重复导致Tree报错
            if (dt.DistinctTable("DictionaryItem_Value").Rows.Count == dt.Rows.Count)
            {
                trb.DataSource = gdb.DataSource;
                trb.Columns.Clear();
                SharedFunc.CopyColumn(gvb, trb);
                trb.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
                trb.OptionsBehavior.Editable = false;
            }
        }
        private void gvb_DataSourceChanged(object sender, EventArgs e)
        {
        }
        private void SystemDictionary_Shown(object sender, EventArgs e)
        {
        }
    }
}