/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.Data;
using DevExpress.Spreadsheet;
using DevExpress.Spreadsheet.Export;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Designer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraRichEdit;
using DevExpress.XtraSpreadsheet;
using MyRapid.Base;
using MyRapid.Code;
using MyRapid.GlobalLocalizer;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static MyRapid.SysEntity.Sys_Enum;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Base;
namespace MyRapid.Base
{
    public partial class ChildPage : DevExpress.XtraEditors.XtraForm
    {
        #region InitializeGroupPanel
        private void InitializeGroupPanel()
        {

            foreach (Control control in this.Controls)
            {
                if (control.GetType().Equals(typeof(GroupControl)))
                {
                    if (!ReflectionHelper.IsBindEvent(control, "DoubleClick"))
                    {
                        control.DoubleClick += new EventHandler(this.groupControl_DoubleClick);
                    }
                }
            }
        }
        private DockStyle groupDock;
        private Dictionary<Control, bool> groupVisible = new Dictionary<Control, bool>();
        private void groupControl_DoubleClick(object sender, EventArgs e)
        {

            Control current = (Control)sender;
            if (groupVisible.Count.Equals(0))
            {
                foreach (Control control in current.Parent.Controls)
                {
                    if (control.GetType() != typeof(BarDockControl))
                    {
                        groupVisible[control] = control.Visible;
                        if (control != current)
                        {
                            control.Visible = false;
                        }
                        else
                        {
                            groupDock = current.Dock;
                            current.Dock = DockStyle.Fill;
                        }
                    }
                }
            }
            else
            {
                foreach (var g in groupVisible)
                {
                    g.Key.Visible = g.Value;
                }
                current.Dock = groupDock;
                groupVisible.Clear();
            }
        }
        #endregion

    }
}