/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
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
    public partial class FieldEdit : DevExpress.XtraEditors.XtraForm
    {
        public FieldEdit(params GridColumn[] gridColumns)
        {
            //Start
            InitializeComponent();
            CancelButton = new BarItemEx(barCancel, DialogResult.Cancel);
            AcceptButton = new BarItemEx(barOk, DialogResult.OK);
            //
            lyc.BeginUpdate();
            List<BaseLayoutItem> baseLayoutItems = new List<BaseLayoutItem>();
            foreach (GridColumn gridColumn in gridColumns)
            {
                LayoutControlItem eLayoutControlItem = new LayoutControlItem();
                eLayoutControlItem.Location = new System.Drawing.Point(0, baseLayoutItems.Count * 23);
                eLayoutControlItem.Name = "oli_" + gridColumn.Name;
                eLayoutControlItem.Text = gridColumn.Caption;
                eLayoutControlItem.Size = new Size(this.Width, 23);
                BaseEdit baseEdit = new TextEdit();
                eLayoutControlItem.Control = baseEdit;
                baseLayoutItems.Add(eLayoutControlItem);
            }
            lyg.AddRange(baseLayoutItems.ToArray());
            lyc.EndUpdate();
        }
    }
}