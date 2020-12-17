/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit;
using MyRapid.Base;
using MyRapid.Code;
using MyRapid.Proxy;
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
    public partial class SystemLayout : ChildPage
    {
        private Sys_Page curPage;
        private ChildPage lastPage;
        public SystemLayout()
        {
            InitializeComponent();
            last = Provider.CurrForm;
        }
        object last;
        private void SystemLayout_Shown(object sender, EventArgs e)
        {
            if (last != null)
            {
                lastPage = (ChildPage)last;
                curPage = lastPage.SysPage;
                Control[] ctrls = this.Controls.Find("cMenu_Id", true);
                if (ctrls.Length > 0 && ctrls[0].GetType() == typeof(LookUpEdit))
                {
                    LookUpEdit lue = (LookUpEdit)ctrls[0];
                    lue.EditValue = curPage.Menu_Id.ToString();
                    Open();
                }
            }
        }
        //public override void Open()
        //{
        //    Guid guid = new Guid();
        //    if (Guid.TryParse(cMenu_Id.Text, out guid))
        //    {
        //        base.Open();
        //    }
        //}
        private void AddPanel(string name, string nick, string parent, byte type, byte dock)
        {
            DataTable dt = (DataTable)gdb.DataSource;
            if (dt == null) return;
            DataRow dr = dt.NewRow();
            dr["Layout_Name"] = name;
            dr["Layout_Nick"] = nick;
            dr["Layout_Parent"] = parent;
            dr["Layout_Type"] = type;
            dr["Layout_Dock"] = dock;
            dr["Layout_Sort"] = dt.Rows.Count;
            dr["Layout_Width"] = 80;
            dr["Layout_Height"] = 80;
            dt.Rows.Add(dr);
        }
        private void InitializeLayout(List<Sys_Layout> sys_Layouts, Control parentControl)
        {
            try
            {
                DataTable dt = (DataTable)gdb.DataSource;
                parentControl.Visible = false;
                parentControl.Controls.Clear();
                foreach (Sys_Layout sys_Layout in sys_Layouts.OrderBy(s => s.Layout_Sort))
                {
                    Control contain = parentControl;
                    if (!string.IsNullOrEmpty(sys_Layout.Layout_Parent))
                    {
                        Control[] cks = parentControl.Controls.Find(sys_Layout.Layout_Parent, true);
                        if (cks.Length > 0)
                            contain = cks[0];
                    }
                    contain.ControlAdded += delegate (object sender, ControlEventArgs e)
                    {
                        e.Control.Paint += Layout_SizeChanged;
                        e.Control.Click += Layout_Select;
                    };
                    switch (sys_Layout.Layout_Type)
                    {
                        case 0: //Query
                            GroupControl qry = new GroupControl();
                            InitializeControl(qry, sys_Layout);
                            contain.Controls.Add(qry);
                            qry.BringToFront();
                            //this.QueryControl = qry;
                            break;
                        case 12: //GroupControl
                            GroupControl grp = new GroupControl();
                            InitializeControl(grp, sys_Layout);
                            contain.Controls.Add(grp);
                            grp.BringToFront();
                            break;
                        case 14: //PanelControl
                            PanelControl panel = new PanelControl();
                            InitializeControl(panel, sys_Layout);
                            contain.Controls.Add(panel);
                            panel.BorderStyle = BorderStyles.NoBorder;
                            panel.BringToFront();
                            break;
                        case 13:
                            SplitterControl OneSpli = new SplitterControl();
                            OneSpli.Dock = (DockStyle)sys_Layout.Layout_Dock;
                            OneSpli.Name = sys_Layout.Layout_Name;
                            contain.Controls.Add(OneSpli);
                            OneSpli.BringToFront();
                            break;
                        case 1: //Grid
                        case 6: //Submit
                        case 7: //Tree    这三个都只有Grid 是在Grid上覆盖控件实现 Submit  和  Tree 效果
                            GridControl gd = new GridControl();
                            InitializeControl(gd, sys_Layout);
                            GridView gv = (GridView)gd.CreateView("GridView");
                            gv.Name = gd.Name.Replace("d", "v");
                            gv.OptionsView.ShowGroupPanel = false;
                            gv.OptionsView.ShowFooter = true;
                            gv.OptionsSelection.MultiSelect = true;
                            gd.MainView = gv;
                            contain.Controls.Add(gd);
                            gd.BringToFront();
                            break;
                        case 9: //TabPage
                            TabEx ntabs = new TabEx();
                            InitializeControl(ntabs, sys_Layout);
                            ntabs.BorderStyle = BorderStyles.NoBorder;
                            ntabs.BorderStylePage = BorderStyles.NoBorder;
                            contain.Controls.Add(ntabs);
                            ntabs.BringToFront();
                            break;
                        case 10:
                            DevExpress.XtraTab.XtraTabPage tab = new DevExpress.XtraTab.XtraTabPage();
                            tab.Name = sys_Layout.Layout_Name;
                            tab.Text = sys_Layout.Layout_Nick;
                            if (contain.GetType() == typeof(TabEx))
                            {
                                TabEx tabs = (TabEx)contain;
                                tabs.TabPages.Add(tab);
                            }
                            break;
                        case 11:
                            Pagination pagination = new Pagination();
                            pagination.Name = sys_Layout.Layout_Name;
                            pagination.Dock = (DockStyle)sys_Layout.Layout_Dock;
                            contain.Controls.Add(pagination);
                            pagination.BringToFront();
                            break;
                        case 2: //Chart
                            ChartControl chart = new ChartControl();
                            InitializeControl(chart, sys_Layout);
                            chart.BorderOptions.Visibility = DevExpress.Utils.DefaultBoolean.False;
                            contain.Controls.Add(chart);
                            chart.BringToFront();
                            break;
                        case 3://text
                            MemoEdit memoEdit = new MemoEdit();
                            InitializeControl(memoEdit, sys_Layout);
                            memoEdit.BorderStyle = BorderStyles.NoBorder;
                            contain.Controls.Add(memoEdit);
                            memoEdit.BringToFront();
                            break;
                        case 4://RichText
                            RichEditControl rtf = new RichEditControl();
                            InitializeControl(rtf, sys_Layout);
                            rtf.BorderStyle = BorderStyles.NoBorder;
                            rtf.ActiveViewType = RichEditViewType.Simple;
                            contain.Controls.Add(rtf);
                            rtf.BringToFront();
                            break;
                        case 5: //image
                            PictureEdit pictureEdit = new PictureEdit();
                            InitializeControl(pictureEdit, sys_Layout);
                            pictureEdit.BorderStyle = BorderStyles.NoBorder;
                            pictureEdit.Properties.PictureStoreMode = PictureStoreMode.ByteArray;
                            pictureEdit.Properties.SizeMode = PictureSizeMode.Squeeze;
                            contain.Controls.Add(pictureEdit);
                            pictureEdit.BringToFront();
                            break;
                        case 8: //BarCode
                            BarCodeControl barCodeControl = new BarCodeControl();
                            InitializeControl(barCodeControl, sys_Layout);
                            barCodeControl.BorderStyle = BorderStyles.NoBorder;
                            barCodeControl.BackColor = Color.White;
                            barCodeControl.AutoModule = true;
                            barCodeControl.ShowText = false;
                            //QRCodeGenerator
                            DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
                            qrCodeGenerator1.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.Byte;
                            qrCodeGenerator1.ErrorCorrectionLevel = DevExpress.XtraPrinting.BarCode.QRCodeErrorCorrectionLevel.H;
                            qrCodeGenerator1.Version = DevExpress.XtraPrinting.BarCode.QRCodeVersion.Version1;
                            //Code128Generator
                            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
                            //根据长宽比切换二维码 条码显示
                            if (barCodeControl.Width > barCodeControl.Height * 2)
                            {
                                barCodeControl.Symbology = code128Generator1;
                            }
                            else
                            {
                                barCodeControl.Symbology = qrCodeGenerator1;
                            }
                            contain.Controls.Add(barCodeControl);
                            barCodeControl.BringToFront();
                            break;
                        default:
                            break;
                    }
                }
                parentControl.Visible = true;
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void InitializeControl(Control c, Sys_Layout sys_Layout)
        {
            c.Dock = (DockStyle)sys_Layout.Layout_Dock;
            c.Top = sys_Layout.Layout_Top;
            c.Left = sys_Layout.Layout_Left;
            c.Width = sys_Layout.Layout_Width;
            c.Height = sys_Layout.Layout_Height;
            c.Name = sys_Layout.Layout_Name;
            c.Text = sys_Layout.Layout_Nick;
        }
        public void AddTabControl()
        {
            if (gvb.FocusedRowHandle < 0) return;
            string parent = gvb.GetFocusedRowCellValue("Layout_Name").ToStringEx();
            AddPanel("ntcb", "信息", parent, 9, (int)DockStyle.Fill);
            AddPanel("tpb1", "信息", "ntcb", 10, (int)DockStyle.Fill);
            AddPanel(parent + "1_pagi", "分页", "tpb1", 11, (int)DockStyle.Bottom);
            AddPanel(parent.Replace("c", "d") + "1", "信息", "tpb1", 1, (int)DockStyle.Fill);
            AddPanel("tpb2", "信息", "ntcb", 10, (int)DockStyle.Fill);
            AddPanel(parent + "2_pagi", "分页", "tpb2", 11, (int)DockStyle.Bottom);
            AddPanel(parent.Replace("c", "d") + "2", "信息", "tpb2", 1, (int)DockStyle.Fill);
            AddPanel("spb", "", "", 13, (int)DockStyle.Bottom);
        }
        public void AddGridControl()
        {
            if (gvb.FocusedRowHandle < 0) return;
            string parent = gvb.GetFocusedRowCellValue("Layout_Name").ToStringEx();
            AddPanel(parent + "_pagi", "分页", parent, 11, (int)DockStyle.Bottom);
            AddPanel(parent.Replace("c", "d"), "信息", parent, 1, (int)DockStyle.Fill);
        }
        private void gcf_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            try
            {
                gvb.CloseEditor();
                gvb.UpdateCurrentRow();
                DataTable dt = (DataTable)gdb.DataSource;
                if (dt == null) return;
                List<Sys_Layout> sys_Layouts = EntityHelper.GetEntities<Sys_Layout>(dt);
                if (e.Button.Properties.Caption != "prv")
                {
                    while (dt.Rows.Count > 0)
                    {
                        dt.Rows[0].Delete();
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        dr.Delete();
                    }
                }
                base.Save();
                switch (e.Button.Properties.Caption)
                {
                    case "tf":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gc", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gd_pagi", "分页", "gc", 11, (int)DockStyle.Bottom);
                        AddPanel("gd", "信息", "gc", 1, (int)DockStyle.Fill);
                        break;
                    case "tbf":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcb", "信息", "", 12, (int)DockStyle.Bottom);
                        AddPanel("gdb_pagi", "分页", "gcb", 11, (int)DockStyle.Bottom);
                        AddPanel("gdb", "信息", "gcb", 1, (int)DockStyle.Fill);
                        AddPanel("spb", "", "", 13, (int)DockStyle.Bottom);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "信息", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "ttf":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gct", "信息", "", 12, (int)DockStyle.Top);
                        AddPanel("gdt_pagi", "分页", "gct", 11, (int)DockStyle.Bottom);
                        AddPanel("gdt", "信息", "gct", 1, (int)DockStyle.Fill);
                        AddPanel("spm", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "信息", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "tlf":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcl", "信息", "", 12, (int)DockStyle.Left);
                        AddPanel("gdl_pagi", "分页", "gcl", 11, (int)DockStyle.Bottom);
                        AddPanel("gdl", "信息", "gcl", 1, (int)DockStyle.Fill);
                        AddPanel("spl", "", "", 13, (int)DockStyle.Left);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "信息", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "trf":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcr", "信息", "", 12, (int)DockStyle.Right);
                        AddPanel("gdr_pagi", "分页", "gcr", 11, (int)DockStyle.Bottom);
                        AddPanel("gdr", "信息", "gcr", 1, (int)DockStyle.Fill);
                        AddPanel("spr", "", "", 13, (int)DockStyle.Right);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "信息", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "tblf":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcb", "信息", "", 12, (int)DockStyle.Bottom);
                        AddPanel("gdb_pagi", "分页", "gcb", 11, (int)DockStyle.Bottom);
                        AddPanel("gdb", "", "gcb", 1, (int)DockStyle.Fill);
                        AddPanel("spb", "", "", 13, (int)DockStyle.Bottom);
                        AddPanel("gcl", "信息", "", 12, (int)DockStyle.Left);
                        AddPanel("gdl_pagi", "分页", "gcl", 11, (int)DockStyle.Bottom);
                        AddPanel("gdl", "", "gcl", 1, (int)DockStyle.Fill);
                        AddPanel("spl", "", "", 13, (int)DockStyle.Left);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "tbrf":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcb", "信息", "", 12, (int)DockStyle.Bottom);
                        AddPanel("gdb_pagi", "分页", "gcb", 11, (int)DockStyle.Bottom);
                        AddPanel("gdb", "", "gcb", 1, (int)DockStyle.Fill);
                        AddPanel("spb", "", "", 13, (int)DockStyle.Bottom);
                        AddPanel("gcr", "信息", "", 12, (int)DockStyle.Right);
                        AddPanel("gdr_pagi", "分页", "gcr", 11, (int)DockStyle.Bottom);
                        AddPanel("gdr", "", "gcr", 1, (int)DockStyle.Fill);
                        AddPanel("spr", "", "", 13, (int)DockStyle.Right);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "tlrf":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcl", "信息", "", 12, (int)DockStyle.Left);
                        AddPanel("gdl_pagi", "分页", "gcl", 11, (int)DockStyle.Bottom);
                        AddPanel("gdl", "", "gcl", 1, (int)DockStyle.Fill);
                        AddPanel("spl", "", "", 13, (int)DockStyle.Left);
                        AddPanel("gcr", "信息", "", 12, (int)DockStyle.Right);
                        AddPanel("gdr_pagi", "分页", "gcr", 11, (int)DockStyle.Bottom);
                        AddPanel("gdr", "", "gcr", 1, (int)DockStyle.Fill);
                        AddPanel("spr", "", "", 13, (int)DockStyle.Right);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "tllf":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcl", "信息", "", 12, (int)DockStyle.Left);
                        AddPanel("gdl_pagi", "分页", "gcl", 11, (int)DockStyle.Bottom);
                        AddPanel("gdl", "", "gcl", 1, (int)DockStyle.Fill);
                        AddPanel("spl", "", "", 13, (int)DockStyle.Left);
                        AddPanel("gcm", "信息", "", 12, (int)DockStyle.Left);
                        AddPanel("gdm_pagi", "分页", "gcm", 11, (int)DockStyle.Bottom);
                        AddPanel("gdm", "", "gcm", 1, (int)DockStyle.Fill);
                        AddPanel("spm", "", "", 13, (int)DockStyle.Left);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "trrf":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcr", "信息", "", 12, (int)DockStyle.Right);
                        AddPanel("gdr_pagi", "分页", "gcr", 11, (int)DockStyle.Bottom);
                        AddPanel("gdr", "", "gcr", 1, (int)DockStyle.Fill);
                        AddPanel("spr", "", "", 13, (int)DockStyle.Right);
                        AddPanel("gcm", "信息", "", 12, (int)DockStyle.Right);
                        AddPanel("gdm_pagi", "分页", "gcm", 11, (int)DockStyle.Bottom);
                        AddPanel("gdm", "", "gcm", 1, (int)DockStyle.Fill);
                        AddPanel("spm", "", "", 13, (int)DockStyle.Right);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "tltf":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcl", "信息", "", 12, (int)DockStyle.Left);
                        AddPanel("gdl_pagi", "分页", "gcl", 11, (int)DockStyle.Bottom);
                        AddPanel("gdl", "", "gcl", 1, (int)DockStyle.Fill);
                        AddPanel("spl", "", "", 13, (int)DockStyle.Left);
                        AddPanel("gcm", "信息", "", 12, (int)DockStyle.Top);
                        AddPanel("gdm_pagi", "分页", "gcm", 11, (int)DockStyle.Bottom);
                        AddPanel("gdm", "", "gcm", 1, (int)DockStyle.Fill);
                        AddPanel("spm", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "tlfb":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcl", "信息", "", 12, (int)DockStyle.Left);
                        AddPanel("gdl_pagi", "分页", "gcl", 11, (int)DockStyle.Bottom);
                        AddPanel("gdl", "", "gcl", 1, (int)DockStyle.Fill);
                        AddPanel("spl", "", "", 13, (int)DockStyle.Left);
                        AddPanel("gcb", "信息", "", 12, (int)DockStyle.Bottom);
                        AddPanel("gdb_pagi", "分页", "gcb", 11, (int)DockStyle.Bottom);
                        AddPanel("gdb", "", "gcb", 1, (int)DockStyle.Fill);
                        AddPanel("spb", "", "", 13, (int)DockStyle.Bottom);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "trfb":
                        AddPanel("qry", "查询", "", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcr", "信息", "", 12, (int)DockStyle.Right);
                        AddPanel("gdr_pagi", "分页", "gcr", 11, (int)DockStyle.Bottom);
                        AddPanel("gdr", "", "gcr", 1, (int)DockStyle.Fill);
                        AddPanel("spr", "", "", 13, (int)DockStyle.Right);
                        AddPanel("gcb", "信息", "", 12, (int)DockStyle.Bottom);
                        AddPanel("gdb_pagi", "分页", "gcb", 11, (int)DockStyle.Bottom);
                        AddPanel("gdb", "", "gcb", 1, (int)DockStyle.Fill);
                        AddPanel("spb", "", "", 13, (int)DockStyle.Bottom);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "trtf":
                        AddPanel("qry", "查询", "qry", 0, (int)DockStyle.Top);
                        AddPanel("spt", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcr", "信息", "", 12, (int)DockStyle.Right);
                        AddPanel("gdr_pagi", "分页", "gcr", 11, (int)DockStyle.Bottom);
                        AddPanel("gdr", "", "gcr", 1, (int)DockStyle.Fill);
                        AddPanel("spr", "", "", 13, (int)DockStyle.Right);
                        AddPanel("gct", "信息", "", 12, (int)DockStyle.Top);
                        AddPanel("gdt_pagi", "分页", "gct", 11, (int)DockStyle.Bottom);
                        AddPanel("gdt", "", "gct", 1, (int)DockStyle.Fill);
                        AddPanel("spm", "", "", 13, (int)DockStyle.Top);
                        AddPanel("gcf", "信息", "", 12, (int)DockStyle.Fill);
                        AddPanel("gdf_pagi", "分页", "gcf", 11, (int)DockStyle.Bottom);
                        AddPanel("gdf", "", "gcf", 1, (int)DockStyle.Fill);
                        break;
                    case "prv"://sys_Layouts.Clear();
                        InitializeLayout(sys_Layouts, gcf);
                        return;
                    default:
                        break;
                }
                sys_Layouts = EntityHelper.GetEntities<Sys_Layout>(dt);
                InitializeLayout(sys_Layouts, gcf);
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        #region AutoSize
        private void Layout_SizeChanged(object sender, PaintEventArgs e)
        {
            Control ctrl = (Control)sender;
            DataTable dt = (DataTable)gdb.DataSource;
            GridView gv = (GridView)gdb.MainView;
            gv.BeginUpdate();
            string f = string.Format("Layout_Name = '{0}'", ctrl.Name);
            foreach (DataRow dr in dt.Select(f))
            {
                dr["Layout_Width"] = ctrl.Width;
                dr["Layout_Height"] = ctrl.Height;
                dr["Layout_Top"] = ctrl.Top;
                dr["Layout_Left"] = ctrl.Left;
            }
            gv.EndUpdate();
        }
        private void Layout_Select(object sender, EventArgs e)
        {
            Control ctrl = (Control)sender;
            for (int i = 0; i < gvb.RowCount; i++)
            {
                gvb.ClearSelection();
                gvb.FocusedRowHandle = i;
                gvb.SelectRow(i);
                if (gvb.GetFocusedRowCellValue("Layout_Name").ToStringEx() == ctrl.Name)
                    return;
            }
        }
        #endregion
        public void RefeshPage()
        {
            if (lastPage != null)
            {
                Save();
                ChildPage childPage = SharedFunc.LoadPage(lastPage.SysMenu);
                childPage.MdiParent = this.MdiParent;
                childPage.Show();
            }
        }

    }
}