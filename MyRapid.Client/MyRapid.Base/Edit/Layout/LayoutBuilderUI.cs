/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyRapid.Base
{
    public partial class LayoutBuilderUI : Form
    {
        public IDesignerHost iDesignerHost;
        public LayoutBuilderUI(IDesignerHost host)
        {
            InitializeComponent();
            iDesignerHost = host;
        }
        List<Sys_Layout> sys_Layouts = new List<Sys_Layout>();
        private void AddPanel(string Layout_Name, string Layout_Nick, string Layout_Grid, byte Layout_Type, byte Layout_Dock)
        {
            Sys_Layout sys_Layout = new Sys_Layout();
            sys_Layout.Layout_Name = Layout_Name;
            sys_Layout.Layout_Nick = Layout_Nick;
            sys_Layout.Layout_Grid = Layout_Grid;
            sys_Layout.Layout_Type = Layout_Type;
            sys_Layout.Layout_Dock = Layout_Dock;
            sys_Layout.Layout_Sort = sys_Layouts.Count;
            sys_Layouts.Add(sys_Layout);
        }
        private void InitializeLayout(List<Sys_Layout> sys_Layouts, Control parentControl)
        {
            Control OneCtrl = new Control();
            foreach (Sys_Layout sys_Layout in sys_Layouts.OrderBy(s => s.Layout_Sort))
            {
                if ((DockStyle)sys_Layout.Layout_Dock != DockStyle.Fill)
                {
                    SplitterControl OneSpli = (SplitterControl)iDesignerHost.CreateComponent(typeof(SplitterControl));
                    OneSpli.Dock = (DockStyle)sys_Layout.Layout_Dock;
                    parentControl.Controls.Add(OneSpli);
                }
                GroupControl newPanel = null;
                switch (sys_Layout.Layout_Type)
                {
                    case 0:
                        newPanel = (GroupControl)iDesignerHost.CreateComponent(typeof(GroupControl), sys_Layout.Layout_Name);
                        break;
                    case 1:
                        newPanel = (GroupControl)iDesignerHost.CreateComponent(typeof(GroupControl), sys_Layout.Layout_Name);
                        GridControl gd = (GridControl)iDesignerHost.CreateComponent(typeof(GridControl), sys_Layout.Layout_Grid);
                        gd.Dock = DockStyle.Fill;
                        gd.Name = sys_Layout.Layout_Grid;
                        GridView abv = (GridView)gd.CreateView("GridView");
                        abv.OptionsView.ColumnAutoWidth = false;
                        abv.Name = gd.Name.Replace("d", "v");
                        abv.OptionsView.ShowGroupPanel = false;
                        abv.OptionsView.ShowFooter = true;
                        //abv.OptionsView.ShowBands = false;
                        abv.OptionsSelection.MultiSelect = true;
                        //iDesignerHost.DestroyComponent(abv.Bands[0]);
                        gd.MainView = abv;
                        newPanel.Controls.Add(gd);
                        break;
                    default:
                        break;
                }
                if (newPanel == null) return;
                newPanel.Dock = (DockStyle)sys_Layout.Layout_Dock;
                newPanel.Top = 80;
                newPanel.Left = 80;
                newPanel.Width = 80;
                newPanel.Height = 80;
                newPanel.Name = sys_Layout.Layout_Name;
                newPanel.Text = sys_Layout.Layout_Nick;
                if (((DockStyle)sys_Layout.Layout_Dock).Equals(DockStyle.Fill))
                {
                    OneCtrl = newPanel;
                }
                parentControl.Controls.Add(newPanel);
            }
            OneCtrl.Dock = DockStyle.Fill;
            OneCtrl.BringToFront();
            sys_Layouts.Clear();
        }
        private void btn_tf_Click(object sender, EventArgs e)
        {
            AddPanel("qry", "查询", "qry", 0, (int)DockStyle.Top);
            AddPanel("gc", "信息", "gd", 1, (int)DockStyle.Fill);
            InitializeLayout(sys_Layouts, (Control)iDesignerHost.RootComponent);
        }

        private void btn_tbf_Click(object sender, EventArgs e)
        {
            AddPanel("qry", "查询", "qry", 0, (int)DockStyle.Top);
            AddPanel("gcb", "信息", "gdb", 1, (int)DockStyle.Bottom);
            AddPanel("gcf", "信息", "gdf", 1, (int)DockStyle.Fill);
            InitializeLayout(sys_Layouts, (Control)iDesignerHost.RootComponent);
        }
        private void btn_tlf_Click(object sender, EventArgs e)
        {
            AddPanel("gcl", "信息", "gdl", 1, (int)DockStyle.Left);
            AddPanel("qry", "查询", "qry", 0, (int)DockStyle.Top);
            AddPanel("gcf", "信息", "gdf", 1, (int)DockStyle.Fill);
            InitializeLayout(sys_Layouts, (Control)iDesignerHost.RootComponent);
        }
        private void btn_tblf_Click(object sender, EventArgs e)
        {
            AddPanel("gcb", "信息", "gdb", 1, (int)DockStyle.Bottom);
            AddPanel("gcl", "信息", "gdl", 1, (int)DockStyle.Left);
            AddPanel("qry", "查询", "qry", 0, (int)DockStyle.Top);
            AddPanel("gcf", "信息", "gdf", 1, (int)DockStyle.Fill);
            InitializeLayout(sys_Layouts, (Control)iDesignerHost.RootComponent);
        }
        private void btn_tlrf_Click(object sender, EventArgs e)
        {
            AddPanel("gcr", "信息", "gdr", 1, (int)DockStyle.Right);
            AddPanel("gcl", "信息", "gdl", 1, (int)DockStyle.Left);
            AddPanel("qry", "查询", "qry", 0, (int)DockStyle.Top);
            AddPanel("gcf", "信息", "gdf", 1, (int)DockStyle.Fill);
            InitializeLayout(sys_Layouts, (Control)iDesignerHost.RootComponent);
        }
        private void btn_tlbf_Click(object sender, EventArgs e)
        {
            AddPanel("gcr", "信息", "gdr", 1, (int)DockStyle.Right);
            AddPanel("gcb", "信息", "gdb", 1, (int)DockStyle.Bottom);
            AddPanel("qry", "查询", "qry", 0, (int)DockStyle.Top);
            AddPanel("gcf", "信息", "gdf", 1, (int)DockStyle.Fill);
            InitializeLayout(sys_Layouts, (Control)iDesignerHost.RootComponent);
        }

    }
}