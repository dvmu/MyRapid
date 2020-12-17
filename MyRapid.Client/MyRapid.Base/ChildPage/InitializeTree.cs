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
        #region InitializeTree
        private void InitializeTree()
        {

            List<MyParameter> para = new List<MyParameter>();
            para.Add("@Menu_Id", DbType.String, SysPage.Menu_Id, null);
            DataTable dt_Sys_WorkSet = BaseService.Open("SystemMenu_Tree", para);
            List<Sys_Tree> sys_Trees = EntityHelper.GetEntities<Sys_Tree>(dt_Sys_WorkSet);
            foreach (Sys_Tree sys_Tree in sys_Trees)
            {
                Control[] controls = this.Controls.Find(sys_Tree.Tree_Grid, true);
                if (controls.Length > 0)
                {
                    if (controls[0].GetType().Equals(typeof(GridControl)))
                    {
                        GridControl grid = (GridControl)controls[0];
                        DevExpress.XtraTreeList.TreeList tree = new DevExpress.XtraTreeList.TreeList();
                        tree.BeginUpdate();
                        tree.ParentFieldName = sys_Tree.Tree_Parent;
                        tree.KeyFieldName = sys_Tree.Tree_Key;
                        //tree.PreviewFieldName
                        tree.CheckBoxFieldName = sys_Tree.Tree_Check;
                        DevExpress.XtraTreeList.Columns.TreeListColumn col = new DevExpress.XtraTreeList.Columns.TreeListColumn();
                        col.FieldName = sys_Tree.Tree_Display;
                        col.Name = "t_" + sys_Tree.Tree_Display;
                        col.Visible = true;
                        col.VisibleIndex = 1;
                        tree.OptionsBehavior.Editable = false;
                        if (!sys_Tree.Tree_ReadOnly)
                        {
                            tree.DoubleClick += BindTreeEditor;
                            tree.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
                        }
                        else
                        {
                            GridView abv = (GridView)grid.MainView;
                            abv.OptionsBehavior.Editable = false;
                            abv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                            abv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                            tree.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.None;
                        }
                        tree.Columns.Add(col);
                        tree.OptionsView.ShowIndicator = false;
                        tree.OptionsView.ShowColumns = false;
                        tree.OptionsView.ShowHorzLines = false;
                        tree.OptionsView.ShowVertLines = false;
                        tree.OptionsView.ShowCheckBoxes = !string.IsNullOrEmpty(sys_Tree.Tree_Check);
                        tree.Name = "tree_" + grid.Name;
                        tree.BorderStyle = BorderStyles.NoBorder;
                        grid.Controls.Add(tree);
                        //tree.PopulateColumns();
                        tree.BringToFront();
                        tree.Dock = DockStyle.Fill;
                        tree.GotFocus += Control_GotFocus;
                        grid.DataSourceChanged += BindTreeDataSource;
                        tree.Visible = !sys_Tree.Tree_Hide;
                        tree.EndUpdate();
                        //切换视图
                        Control grp = grid.Parent;
                        if (grp.GetType() == typeof(GroupControl))
                        {
                            //grp.DoubleClick += DoNothing;
                            grp.DoubleClick += delegate
                            {
                                tree.Visible = !tree.Visible;
                            };
                        }
                    }
                }
            }
        }
        private void BindTreeEditor(object sender, EventArgs e)
        {

            DevExpress.XtraTreeList.TreeList tree = (DevExpress.XtraTreeList.TreeList)sender;
            tree.OptionsBehavior.Editable = true;

        }
        private void BindTreeDataSource(object sender, EventArgs e)
        {

            GridControl grid = (GridControl)sender;
            Control[] controls = this.Controls.Find("tree_" + grid.Name, true);
            if (controls.Length > 0)
            {
                if (controls[0].GetType().Equals(typeof(DevExpress.XtraTreeList.TreeList)))
                {
                    DevExpress.XtraTreeList.TreeList tree = (DevExpress.XtraTreeList.TreeList)controls[0];
                    tree.DataSource = grid.DataSource;
                    tree.OptionsBehavior.Editable = false;
                }
            }

        }
        #endregion
    }
}