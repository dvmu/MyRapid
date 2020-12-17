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
        #region InitializeQuery InitializeLayout
        #region InitializeQuery
        private void InitializeQuery()
        {

            try
            {
                if (this.QueryControl == null) { return; }
                this.QueryControl.DoubleClick += QueryAutoClear;
                this.QueryControl.Controls.Clear();
                this.Width = 1024;
                this.QueryControl.Width = 1024;
                LayoutControl eLayoutControl = new LayoutControl();
                eLayoutControl.BeginUpdate();
                eLayoutControl.AllowCustomization = false;
                LayoutControlGroup eLayoutControlGroup = new LayoutControlGroup();
                eLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
                eLayoutControl.Location = new System.Drawing.Point(2, 21);
                eLayoutControl.Name = "eLayoutControl";
                eLayoutControl.Root = eLayoutControlGroup;
                eLayoutControl.Size = new System.Drawing.Size(1000, 90);
                eLayoutControl.TabIndex = 0;
                eLayoutControl.Text = "QueryLayout";
                eLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
                eLayoutControlGroup.GroupBordersVisible = false;
                eLayoutControlGroup.Location = new Point(0, 0);
                eLayoutControlGroup.Name = "eLayoutControlGroup";
                eLayoutControlGroup.Size = new Size(1000, 90);
                eLayoutControlGroup.TextVisible = false;
                this.QueryControl.Controls.Add(eLayoutControl);
                List<BaseLayoutItem> baseLayoutItems = new List<BaseLayoutItem>();
                List<string> baseControls = new List<string>();
                int curLeft = 0;
                int curTop = 0;
                foreach (Sys_Bind sys_Bind in BindList.Where(b => b.Bind_Name.StartsWith("@") &&
                !string.IsNullOrEmpty(b.Bind_Field) &&
                !b.Bind_Field.Contains(".") &&
                WorkSetList.Find(w => w.WorkSet_Id == b.Bind_WorkSet &&
                (w.WorkSet_Type == (int)Sys_WorkSet_Type.Submit ||
                w.WorkSet_Type == (int)Sys_WorkSet_Type.Grid ||
                w.WorkSet_Type == (int)Sys_WorkSet_Type.Tree)) != null).OrderBy(b => b.Bind_Sort))
                {
                    if (baseControls.Contains(sys_Bind.Bind_Field)) continue;
                    baseControls.Add(sys_Bind.Bind_Field);
                    sys_Bind.Bind_Type = 0; //查询字段
                    //界面已有控件不再生成
                    Control[] Controls = this.Controls.Find(sys_Bind.Bind_Field, true);
                    if (Controls.Length > 0)
                    {
                        if (!string.IsNullOrEmpty(sys_Bind.Bind_Popup))
                        {
                            BaseEdit cBaseEdit = (BaseEdit)Controls[0];
                            InitializeBaseEdit(sys_Bind, cBaseEdit);
                        }
                        continue;
                    }
                    BaseEdit baseEdit = InitializeBaseEdit(sys_Bind, null);
                    baseEdit.Name = sys_Bind.Bind_Field;
                    if (!string.IsNullOrEmpty(sys_Bind.Bind_Default))
                    {
                        object obj = sys_Bind.Bind_Default;
                        if (obj.ToString().StartsWith("wk:"))
                            obj = BaseService.Get(obj.ToString().Replace("wk:", ""), null);
                        ReflectionHelper.SetProperty(baseEdit, string.IsNullOrEmpty(sys_Bind.Bind_Property) ? "EditValue" : sys_Bind.Bind_Property, obj);
                        //baseEdit.EditValue = sys_Bind.Bind_Default;
                        if (baseEdit.GetType().Equals(typeof(CheckEdit)))
                        {
                            CheckEdit chkEdit = (CheckEdit)baseEdit;
                            chkEdit.Text = string.Empty;
                            chkEdit.Checked = obj.ToBoolEx();
                        }
                    }


                    if (baseEdit.GetType().Equals(typeof(CheckedComboBoxEdit)))
                    {
                        CheckedComboBoxEdit chkComboBox = (CheckedComboBoxEdit)baseEdit;
                        chkComboBox.RefreshEditValue();
                    }
                    baseEdit.EnterMoveNextControl = true;
                    baseEdit.Width = (int)Math.Round(eLayoutControlGroup.Width * (sys_Bind.Bind_Width / 100.00));
                    baseEdit.Properties.Appearance.Options.UseTextOptions = true;
                    baseEdit.Properties.Appearance.TextOptions.HAlignment = (DevExpress.Utils.HorzAlignment)sys_Bind.Bind_TextAlignment;
                    if (sys_Bind.Bind_ForeColor < 0)
                        baseEdit.ForeColor = Color.FromArgb(sys_Bind.Bind_ForeColor);
                    if (sys_Bind.Bind_BackColor < 0)
                        baseEdit.BackColor = Color.FromArgb(sys_Bind.Bind_BackColor);
                    if (sys_Bind.Bind_BorderColor < 0)
                    {
                        baseEdit.Properties.Appearance.Options.UseBorderColor = true;
                        baseEdit.Properties.Appearance.BorderColor = Color.FromArgb(sys_Bind.Bind_BorderColor);
                        baseEdit.BorderStyle = BorderStyles.Simple;
                    }
                    baseEdit.ToolTip = sys_Bind.Bind_ToolTip;
                    baseEdit.ReadOnly = sys_Bind.Bind_ReadOnly;
                    baseEdit.Visible = sys_Bind.Bind_Visible;
                    baseEdit.GotFocus += Control_GotFocus;
                    eLayoutControl.GotFocus += Control_GotFocus;
                    LayoutControlItem eLayoutControlItem = new LayoutControlItem();
                    eLayoutControlItem.Location = new System.Drawing.Point(curLeft, curTop);
                    curLeft += baseEdit.Width;
                    if (curLeft >= eLayoutControlGroup.Width)
                    {
                        curLeft = 0;
                        curTop += baseEdit.Height;
                    }
                    //eLayoutControlItem.Width = (int)Math.Round(eLayoutControl.Width * (sys_Bind.Bind_Width / 100.00));
                    eLayoutControlItem.AppearanceItemCaption.TextOptions.HAlignment = (DevExpress.Utils.HorzAlignment)sys_Bind.Bind_TitleAlignment;
                    eLayoutControlItem.Name = "oli_" + sys_Bind.Bind_Name;
                    eLayoutControlItem.Text = sys_Bind.Bind_Nick;
                    eLayoutControlItem.Size = new Size(baseEdit.Width, baseEdit.Height);
                    eLayoutControlItem.Control = baseEdit;
                    eLayoutControlItem.Visibility = sys_Bind.Bind_Visible ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    baseLayoutItems.Add(eLayoutControlItem);
                }
                if (curLeft < eLayoutControlGroup.Width && curLeft > 0)
                {
                    EmptySpaceItem emptySpaceItem = new EmptySpaceItem();
                    emptySpaceItem.AllowHotTrack = false;
                    emptySpaceItem.Location = new System.Drawing.Point(curLeft, curTop);
                    emptySpaceItem.Name = "oli_Space";
                    emptySpaceItem.Size = new System.Drawing.Size(eLayoutControlGroup.Width - curLeft, 24);
                    baseLayoutItems.Add(emptySpaceItem);
                }
                eLayoutControlGroup.Items.AddRange(baseLayoutItems.ToArray());
                eLayoutControl.EndUpdate();
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        protected void InitializeLayoutCustomization(LayoutControl layoutControl)
        {

            try
            {
                layoutControl.HideCustomization += delegate
                {
                    try
                    {
                        MemoryStream ms = new MemoryStream();
                        layoutControl.SaveLayoutToStream(ms);
                        Dictionary<string, byte[]> dic = CacheHelper.Get<Dictionary<string, byte[]>>("layout_" + SysPage.Menu_Id);
                        if (dic == null) dic = new Dictionary<string, byte[]>();
                        dic[layoutControl.Name] = ms.ToBytes();
                        CacheHelper.Set(dic, "layout_" + SysPage.Menu_Id);
                    }
                    catch (Exception ex)
                    {
                        SharedFunc.RaiseError(ex);
                    }
                };
                this.Shown += delegate
                {
                    try
                    {
                        Dictionary<string, byte[]> dic = CacheHelper.Get<Dictionary<string, byte[]>>("layout_" + SysPage.Menu_Id);
                        if (dic == null || !dic.ContainsKey(layoutControl.Name)) return;
                        Stream ms = ((byte[])dic[layoutControl.Name]).ToStream();
                        layoutControl.RestoreLayoutFromStream(ms);
                    }
                    catch (Exception ex)
                    {
                        SharedFunc.RaiseError(ex);
                    }
                };
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void QueryAutoClear(object sender, EventArgs e)
        {
            this.Clear();
            //
        }
        DXErrorProvider dep = new DXErrorProvider();

        #endregion
        #region InitializeLayout
        private void InitializeLayout()
        {

            try
            {
                if (this.GetType() != typeof(ChildPage)) return;
                if (this.QueryControl != null) { return; }
                List<MyParameter> myParameter = new List<MyParameter>();
                myParameter.Add("@Menu_Id", DbType.String, SysPage.Menu_Id, null);
                DataTable dt = BaseService.Open("SystemMenu_Layout", myParameter);
                List<Sys_Layout> sys_Layouts = EntityHelper.GetEntities<Sys_Layout>(dt);
                if (sys_Layouts.Count.Equals(0)) return;
                Control parentControl = this;
                foreach (Sys_Layout sys_Layout in sys_Layouts.OrderBy(s => s.Layout_Sort))
                {
                    Control contain = parentControl;
                    if (!string.IsNullOrEmpty(sys_Layout.Layout_Parent))
                    {
                        Control[] cks = parentControl.Controls.Find(sys_Layout.Layout_Parent, true);
                        if (cks.Length > 0)
                            contain = cks[0];
                    }
                    switch (sys_Layout.Layout_Type)
                    {
                        case 0: //Query
                            GroupControl qry = new GroupControl();
                            InitializeControl(qry, sys_Layout);
                            contain.Controls.Add(qry);
                            qry.BringToFront();
                            this.QueryControl = qry;
                            break;
                        case 12: //GroupControl
                            GroupControl grp = new GroupControl();
                            InitializeControl(grp, sys_Layout);
                            contain.Controls.Add(grp);
                            grp.BringToFront();
                            break;
                        case 13:
                            SplitterControl OneSpli = new SplitterControl();
                            OneSpli.Dock = (DockStyle)sys_Layout.Layout_Dock;
                            OneSpli.Name = sys_Layout.Layout_Name;
                            contain.Controls.Add(OneSpli);
                            OneSpli.BringToFront();
                            break;
                        case 14: //PanelControl
                            PanelControl panel = new PanelControl();
                            InitializeControl(panel, sys_Layout);
                            contain.Controls.Add(panel);
                            panel.BorderStyle = BorderStyles.NoBorder;
                            panel.BringToFront();
                            break;
                        case 1: //Grid
                        case 6: //Submit
                        case 7: //Tree    这三个都只有Grid 是在Grid上覆盖控件实现 Submit  和  Tree 效果
                            GridControl gd = new GridControl();
                            InitializeControl(gd, sys_Layout);
                            GridView gv = (GridView)gd.CreateView("GridView");
                            gv.BorderStyle = BorderStyles.NoBorder;
                            gv.Name = gd.Name.Replace("d", "v");
                            gv.OptionsView.ShowGroupPanel = false;
                            gv.OptionsView.ShowFooter = true;
                            gv.OptionsSelection.MultiSelect = true;
                            gd.MainView = gv;
                            contain.Controls.Add(gd);
                            gd.BringToFront();
                            break;
                        case 9: //TabPage  窗体验证时候devexpress原装的XtraTabControl 不支持验证需要自行继承扩展
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
        #endregion
        #endregion
    }
}