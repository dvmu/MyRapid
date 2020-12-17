/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using MyRapid.Base;
using MyRapid.Proxy;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraGrid.Views.Base;
using MyRapid.SysEntity;
using MyRapid.Code;
using MyRapid.Proxy.MainService;
using DevExpress.XtraRichEdit.Services;
using System.Text.RegularExpressions;
using System.Reflection;
using DevExpress.XtraEditors.Controls;
namespace MyRapid.SystemManager
{
    public partial class SystemWorkSet : ChildPage
    {
        object last;
        public SystemWorkSet()
        {
            InitializeComponent();
            last = Provider.CurrForm;
        }

        private void SystemWorkSet_Shown(object sender, EventArgs e)
        {
            Control[] ctrls = this.Controls.Find("cMenu_Id", true);
            LookUpEdit lue = null;
            if (ctrls.Length > 0 && ctrls[0].GetType() == typeof(LookUpEdit))
            {
                lue = (LookUpEdit)ctrls[0];
            }
            if (lue == null) return;
            if (last == null)
            {
                lue.EditValue = "7ccab1c0-4d0a-451b-9859-c47992ac636e";
            }
            else
            {
                lastPage = (ChildPage)last;
                curPage = lastPage.SysPage;
                if (!string.IsNullOrEmpty(lastPage.Text))
                    this.Text = this.Text + " - " + lastPage.Text;
                lue.EditValue = curPage.Menu_Id.ToString();
                loadCtrl(lastPage);
                //loadSub(lastPage);
                tl.DataSource = psis;
                tl.ExpandAll();
                //tl.BestFitColumns();
                InitializeDragEvent();
            }
            Open();
        }
        private ChildPage lastPage;
        public class PageSetInfo
        {
            public string id { get; set; }
            public string pid { get; set; }
            public string name { get; set; }
            public string text { get; set; }
            public string type { get; set; }
        }
        private void loadCtrl(Control ParentCtrl)
        {
            try
            {
                foreach (Control control in ParentCtrl.Controls)
                {
                    if (control.HasChildren)
                    {
                        loadCtrl(control);
                    }
                    if (control.GetType() != typeof(SplitterControl)
                        && !string.IsNullOrEmpty(control.Name))
                    {
                        if (psis.Find(p => p.name.Equals(control.Name)) == null)
                        {
                            PageSetInfo psi = new PageSetInfo();
                            psi.id = control.Name;
                            psi.pid = control.Parent.Name;
                            psi.name = control.Name;
                            psi.text = control.Text;
                            psi.type = control.GetType().Name;
                            psis.Add(psi);
                            if (control.GetType().Equals(typeof(GridControl)))
                            {
                                GridControl gd = (GridControl)control;
                                GridView abgv = (GridView)gd.MainView;
                                foreach (GridColumn gc in abgv.Columns)
                                {
                                    if (psis.Find(p => p.name.Equals(gd.Name + "." + gc.FieldName)) == null)
                                    {
                                        PageSetInfo col = new PageSetInfo();
                                        col.id = gd.Name + "." + gc.FieldName;
                                        col.pid = gd.Name;
                                        col.name = gd.Name + "." + gc.FieldName;
                                        col.text = gc.Caption;
                                        col.type = gc.GetType().Name;
                                        psis.Add(col);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private Sys_Page curPage;
        #region Button & Sub
        private List<PageSetInfo> psis = new List<PageSetInfo>();
        private void loadSub(ChildPage lastPage)
        {
            try
            {
                if (lastPage == null) return;
                DataTable dt = (DataTable)gdf_b.DataSource;
                if (dt == null) return;
                //为空时加载通用按钮
                if (dt.Rows.Count == 0) defMethodInfo(dt);
                //取当前类的新方法
                Type type = lastPage.GetType();
                loadBaseSub(type, dt);
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        private void loadBaseSub(Type type, DataTable dt)
        {
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.InvokeMethod);
            loadSubRow(methodInfos, dt);
            //取基类的继承方法
            if (type != typeof(ChildPage))
            {
                loadBaseSub(type.BaseType, dt);
            }
        }
        private void loadSubRow(MethodInfo[] methodInfos, DataTable dt)
        {
            foreach (MethodInfo methodInfo in methodInfos)
            {
                string flit = "Button_Sub='{0}'";
                flit = string.Format(flit, methodInfo.Name);
                if (methodInfo.IsSpecialName.Equals(false) &&
                    methodInfo.IsPublic && dt.Select(flit).Length.Equals(0))
                {
                    AddMethodInfo(methodInfo, dt);
                }
            }
        }
        //c46c7bdf-ec61-4e6f-9d7d-a35608bc5576
        //通用按钮
        private void defMethodInfo(DataTable dt)
        {
            List<MyParameter> mps = new List<MyParameter>();
            mps.Add("@Menu_Id", DbType.String, "c46c7bdf-ec61-4e6f-9d7d-a35608bc5576", null);
            DataTable sdt = BaseService.Open("SystemMenu_Button", mps);
            foreach (DataRow dr in sdt.Rows)
            {
                dr.SetAdded();
                dr["Button_Name"] = curPage.Menu_Name + "_" + dr["Button_Sub"].ToStringEx();
            }
            dt.Merge(sdt);
        }
        private void AddMethodInfo(MethodInfo methodInfo, DataTable dt)
        {
            DataRow dr = dt.NewRow();
            dr["Button_Nick"] = methodInfo.Name;
            dr["Button_Name"] = curPage.Menu_Name + "_" + methodInfo.Name;
            dr["Button_Page"] = curPage.Menu_Id;
            dr["Button_Hint"] = methodInfo.Name;
            dr["Button_Sub"] = methodInfo.Name;
            dr["Button_Icon"] = "bar_" + methodInfo.Name;
            dr["Button_Sort"] = dt.Rows.Count * 100 + 20000;
            dr["Button_Key"] = 131072;
            Array ints = Enum.GetValues(typeof(Keys));
            foreach (int i in ints)
            {
                if (methodInfo.Name.StartsWith(Enum.GetName(typeof(Keys), i)))
                {
                    dr["Button_SecondKey"] = i;
                    continue;
                }
            }
            dr["Button_Alignment"] = 0;
            dr["Button_CaptionAlignment"] = 2;
            dr["Button_Confirm"] = false;
            dr["Button_Open"] = true;
            dr["Button_Validation"] = false;
            dr["Button_BeginGroup"] = false;
            dr["Button_IsLarge"] = false;
            dr["Button_Visible"] = true;
            dr["Button_Enabled"] = true;
            dr["IsDelete"] = false;
            dt.Rows.Add(dr);
        }
        #endregion
        #region Drag 
        private void InitializeDragEvent()
        {
            tl.DragOver += tl_DragOver;
            gdf.DragDrop += gd_DragDrop;
            gdt.DragDrop += gd_DragDrop;
            gdtr.DragDrop += gd_DragDrop;
            gdf.DragOver += gd_DragOver;
            gdt.DragOver += gd_DragOver;
            gdtr.DragOver += gd_DragOver;
            gdf.MouseMove += gd_MouseMove;
            gdt.MouseMove += gd_MouseMove;
            gdtr.MouseMove += gd_MouseMove;
            tl.MouseMove += tl_MouseMove;
            tl.MouseDown += tl_MouseDown;
        }
        string CtrlName;
        GridHitInfo hitInfo;
        TreeListHitInfo thitInfo;
        private void tl_DragOver(object sender, DragEventArgs e) //Handles tr_CtrlList.DragOver
        {
            TreeListNode dragNode = (TreeListNode)e.Data.GetData(typeof(TreeListNode));
            CtrlName = dragNode.GetValue("name").ToString();
            e.Effect = DragDropEffects.Move;
        }
        private void gd_DragDrop(object sender, DragEventArgs e) //Handles gf.DragDrop, gws.DragDrop
        {
            GridControl grid = (GridControl)sender;
            Point pt = grid.PointToClient(new Point(e.X, e.Y));
            GridView view = (GridView)grid.GetViewAt(pt);
            if (view == null) return;
            hitInfo = view.CalcHitInfo(pt);
            if (hitInfo.InDataRow)
            {
                if (hitInfo.Column.FieldName.Equals("Bind_Push"))
                {
                    view.SetRowCellValue(hitInfo.RowHandle, "Bind_Push", CtrlName);
                }
                if (hitInfo.Column.FieldName.Equals("WorkSet_Pagination"))
                {
                    view.SetRowCellValue(hitInfo.RowHandle, "WorkSet_Pagination", CtrlName);
                }
                if (hitInfo.Column.FieldName.Equals("Bind_Default"))
                {
                    view.SetRowCellValue(hitInfo.RowHandle, "Bind_Default", "rf:" + CtrlName);
                }
                if (hitInfo.Column.FieldName.Equals("Bind_Field"))
                {
                    view.SetRowCellValue(hitInfo.RowHandle, "Bind_Field", CtrlName);
                }
                if (hitInfo.Column.FieldName.Equals("WorkSet_Grid"))
                {
                    view.SetRowCellValue(hitInfo.RowHandle, "WorkSet_Grid", CtrlName);
                }
                if (hitInfo.Column.FieldName.Equals("Tree_Bind"))
                {
                    view.SetRowCellValue(hitInfo.RowHandle, "Tree_Bind", CtrlName);
                }
                if (hitInfo.Column.FieldName.Equals("Tree_Grid"))
                {
                    view.SetRowCellValue(hitInfo.RowHandle, "Tree_Grid", CtrlName);
                }
            }
        }
        private void gd_DragOver(object sender, DragEventArgs e)// Handles gf.DragOver, gws.DragOver
        {
            GridControl control = (GridControl)sender;
            Point pt = control.PointToClient(new Point(e.X, e.Y));
            GridView view = (GridView)control.GetViewAt(pt);
            if (view == null) return;
            hitInfo = view.CalcHitInfo(pt);
            if (hitInfo.InDataRow)
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void gd_MouseMove(object sender, MouseEventArgs e) //Handles gf.MouseMove, gws.MouseMove
        {
            GridControl grid = (GridControl)sender;
            GridView view = (GridView)grid.MainView;
            hitInfo = view.CalcHitInfo(new Point(e.X, e.Y));
        }
        private void tl_MouseDown(object sender, MouseEventArgs e) // Handles tr_CtrlList.MouseDown
        {
            thitInfo = tl.CalcHitInfo(new Point(e.X, e.Y));
        }
        private void tl_MouseMove(object sender, MouseEventArgs e) // Handles tr_CtrlList.MouseMove
        {
            if (thitInfo != null && e.Button.Equals(MouseButtons.Left))
            {
                Rectangle rectangle = new Rectangle(new Point((thitInfo.MousePoint.X - (SystemInformation.DragSize.Width / 2)), (thitInfo.MousePoint.Y - (SystemInformation.DragSize.Height / 2))), SystemInformation.DragSize);
                if (thitInfo.Node != null && !rectangle.Contains(new Point(e.X, e.Y)))
                {
                    object row = thitInfo.Node;
                    gdt.DoDragDrop(row, DragDropEffects.Move);
                    gdf.DoDragDrop(row, DragDropEffects.Move);
                }
            }
        }
        #endregion
        private string CurBtn = "Select";
        private SqlEdit TopSql;
        private void ChkBtn(string curBtn)
        {
            CurBtn = curBtn;
            if (!curBtn.Equals("Insert"))
            {
                gpb.CustomHeaderButtons["Insert"].Properties.Checked = false;
            }
            if (!curBtn.Equals("Update"))
            {
                gpb.CustomHeaderButtons["Update"].Properties.Checked = false;
            }
            if (!curBtn.Equals("Delete"))
            {
                gpb.CustomHeaderButtons["Delete"].Properties.Checked = false;
            }
            if (!curBtn.Equals("Select"))
            {
                gpb.CustomHeaderButtons["Select"].Properties.Checked = false;
            }
        }
        private void gpb_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            try
            {
                switch (e.Button.Properties.Caption)
                {
                    case "Insert":
                        ChkBtn(e.Button.Properties.Caption);
                        rtfSql_Insert.BringToFront();
                        TopSql = rtfSql_Insert;
                        break;
                    case "Update":
                        ChkBtn(e.Button.Properties.Caption);
                        rtfSql_Update.BringToFront();
                        TopSql = rtfSql_Update;
                        break;
                    case "Delete":
                        ChkBtn(e.Button.Properties.Caption);
                        rtfSql_Delete.BringToFront();
                        TopSql = rtfSql_Delete;
                        break;
                    case "Select":
                        ChkBtn(e.Button.Properties.Caption);
                        rtfSql_Select.BringToFront();
                        TopSql = rtfSql_Select;
                        break;
                    case "Generate":
                        e.Button.Properties.Checked = false;
                        TopSql = TopSql == null ? rtfSql_Select : TopSql;
                        if (gvt.FocusedRowHandle >= 0)
                        {
                            string conn = gvt.GetFocusedRowCellValue("WorkSet_Connection").ToStringEx();
                            List<MyParameter> connPara = new List<MyParameter>();
                            //切换到当前连接
                            try
                            {
                                connPara.Add("@WorkSet_Name", DbType.String, "SystemWorkSet_Schema", null);
                                connPara.Add("@WorkSet_Connection", DbType.String, conn, null);
                                BaseService.Execute("SystemWorkSet_SchemaClear", connPara);
                            }
                            catch (Exception ex)
                            {
                                SharedFunc.RaiseError(ex);
                            }
                            List<Sys_Schema> sys_Schemas = new List<Sys_Schema>();
                            string TableName = gvt.GetFocusedRowCellValue("WorkSet_Table").ToStringEx();
                            try
                            {
                                //执行生成语句                                
                                List<MyParameter> myParameters = new List<MyParameter>();
                                myParameters.Add("@TableName", DbType.String, TableName, null);
                                DataTable dt = BaseService.Open("SystemWorkSet_Schema", myParameters);
                                sys_Schemas = EntityHelper.GetEntities<Sys_Schema>(dt);
                            }
                            catch (Exception ex)
                            {
                                SharedFunc.RaiseError(ex);
                            }
                            //切换到默认连接
                            connPara.Clear();
                            try
                            {
                                connPara.Add("@WorkSet_Name", DbType.String, "SystemWorkSet_Schema", null);
                                connPara.Add("@WorkSet_Connection", DbType.String, null, null);
                                BaseService.Execute("SystemWorkSet_SchemaClear", connPara);
                            }
                            catch (Exception ex)
                            {
                                SharedFunc.RaiseError(ex);
                            }
                            if (sys_Schemas != null)
                            {
                                if (!string.IsNullOrEmpty(TableName))
                                {
                                    string IsPagination = gvt.GetFocusedRowCellValue("WorkSet_Pagination").ToStringEx();
                                    if (!string.IsNullOrEmpty(IsPagination) && CurBtn.Equals("Select"))
                                    {
                                        TopSql.Text = ScriptHelper.GenerateSql(TableName, sys_Schemas, "SelectPage");
                                    }
                                    else
                                    {
                                        TopSql.Text = ScriptHelper.GenerateSql(TableName, sys_Schemas, CurBtn);
                                    }
                                }
                            }
                        }
                        break;
                    case "Parameter":
                        e.Button.Properties.Checked = false;
                        try
                        {
                            if (gvt.FocusedRowHandle >= 0)
                            {
                                string WorkSet_Name = gvt.GetFocusedRowCellValue("WorkSet_Name").ToStringEx();
                                if (string.IsNullOrEmpty(WorkSet_Name.Trim()))
                                {
                                    return;
                                }
                                DataTable fdt = (DataTable)gdf.DataSource;
                                List<MyParameter> myParameter = new List<MyParameter>();
                                if (string.IsNullOrEmpty(rtfSql_Select.Text)) return;
                                string tmpSql = rtfSql_Select.Text;
                                Regex decRgx = new Regex("DECLARE( )*@(([A-Za-z0-9_])* )( )*([A-Za-z0-9_,])*( )*(,|\r)", RegexOptions.IgnoreCase);
                                foreach (Match m in decRgx.Matches(tmpSql))
                                {
                                    Regex eRgx = new Regex("@(([A-Za-z0-9_])*)", RegexOptions.IgnoreCase);
                                    foreach (Match em in eRgx.Matches(m.Value))
                                    {
                                        tmpSql = tmpSql.Replace(em.Value, "");
                                    }
                                }
                                //tmpSql = decRgx.Replace(tmpSql, "");
                                Regex rgxOne = new Regex("@(([A-Za-z0-9_])*)", RegexOptions.IgnoreCase);
                                foreach (Match OneMth in rgxOne.Matches(tmpSql))
                                {
                                    if (myParameter.Find(p => p.Name.Equals(OneMth.Value)) == null)
                                    {
                                        string Bind_Name = "Bind_Name='{0}'";
                                        Bind_Name = string.Format(Bind_Name, OneMth.Value);
                                        if (fdt.Select(Bind_Name).Length.Equals(0))
                                        {
                                            DataRow dr = fdt.NewRow();
                                            dr["Bind_WorkSet"] = gvt.GetFocusedRowCellValue("WorkSet_Id").ToStringEx();
                                            dr["Bind_Name"] = OneMth.Value;
                                            dr["Bind_Nick"] = OneMth.Value;
                                            dr["Bind_Field"] = OneMth.Value.Trim('@');
                                            dr["Bind_Width"] = 25;
                                            dr["Bind_ToolTip"] = OneMth.Value;
                                            dr["Bind_Sort"] = fdt.Rows.Count * 10 + 100;
                                            dr["Bind_Visible"] = true;
                                            dr["Bind_ReadOnly"] = false;
                                            dr["Bind_SqlDbType"] = (int)DbType.String;
                                            dr["Bind_Summary"] = 6;
                                            dr["IsDelete"] = 0;
                                            //分页
                                            if (OneMth.Value == "@PageSize" || OneMth.Value == "@PageIndex")
                                            {
                                                dr["Bind_Sort"] = 999999;
                                                dr["Bind_SqlDbType"] = DbType.Int32;
                                                dr["Bind_Field"] = gvt.GetFocusedRowCellValue("WorkSet_Pagination").ToStringEx();
                                                dr["Bind_Property"] = OneMth.Value.Trim('@');
                                            }
                                            fdt.Rows.Add(dr);
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            SharedFunc.RaiseError(ex);
                        }
                        break;
                    case "Debug":
                        e.Button.Properties.Checked = false;
                        try
                        {
                            if (gvt.FocusedRowHandle >= 0)
                            {
                                string WorkSet_Name = gvt.GetFocusedRowCellValue("WorkSet_Name").ToStringEx();
                                if (string.IsNullOrEmpty(WorkSet_Name.Trim()))
                                {
                                    return;
                                }
                                DataTable fdt = (DataTable)gdf.DataSource;
                                List<MyParameter> myParameter = new List<MyParameter>();
                                if (string.IsNullOrEmpty(rtfSql_Select.Text)) return;
                                List<Sys_Bind> sys_Binds = EntityHelper.GetEntities<Sys_Bind>(fdt);
                                foreach (Sys_Bind sys_Bind in sys_Binds)
                                {
                                    myParameter.Add(sys_Bind.Bind_Name, (DbType)sys_Bind.Bind_SqlDbType, null, null);
                                }
                                DataTable dt = BaseService.Open(WorkSet_Name, myParameter);
                                if (dt == null) throw new ArgumentNullException(WorkSet_Name);
                                string TableName = gvt.GetFocusedRowCellValue("WorkSet_Table").ToStringEx();
                                List<MyParameter> SchemaPara = new List<MyParameter>();
                                SchemaPara.Add("@TableName", DbType.String, TableName, null);
                                List<Sys_Schema> sys_Schemas = EntityHelper.GetEntities<Sys_Schema>(BaseService.Open("SystemWorkSet_Schema", SchemaPara));
                                foreach (DataColumn col in dt.Columns)
                                {
                                    string Bind_Name = "Bind_Name='{0}'";
                                    Bind_Name = string.Format(Bind_Name, col.ColumnName);
                                    if (fdt.Select(Bind_Name).Length.Equals(0))
                                    {
                                        DataRow dr = fdt.NewRow();
                                        dr["Bind_WorkSet"] = gvt.GetFocusedRowCellValue("WorkSet_Id").ToStringEx();
                                        dr["Bind_Name"] = col.ColumnName;
                                        Sys_Schema sys_Schema = sys_Schemas.Find(s => s.FieldName == col.ColumnName);
                                        dr["Bind_Nick"] = sys_Schema != null && !string.IsNullOrEmpty(sys_Schema.Description) ? sys_Schema.Description : col.ColumnName;
                                        dr["Bind_Field"] = col.ColumnName;
                                        dr["Bind_ToolTip"] = col.ColumnName;
                                        dr["Bind_Sort"] = (col.Ordinal + 10) * 10 + 1000;
                                        dr["Bind_Visible"] = true;
                                        dr["Bind_ReadOnly"] = false;
                                        if (ReservedHelper.GridAutoField.Contains(col.ColumnName))
                                            dr["Bind_Visible"] = false;
                                        dr["Bind_SqlDbType"] = (int)ConvertHelper.GetDbType(col.DataType);
                                        dr["Bind_Summary"] = 6;
                                        dr["IsDelete"] = 0;
                                        if (col.DataType.Equals(typeof(DateTime)))
                                        {
                                            dr["Bind_Width"] = 128;
                                        }
                                        else if (col.DataType.Equals(typeof(bool)))
                                        {
                                            dr["Bind_Width"] = 40;
                                        }
                                        else if (col.DataType.Equals(typeof(int)))
                                        {
                                            dr["Bind_Width"] = 60;
                                        }
                                        else
                                        {
                                            dr["Bind_Width"] = 100;
                                        }
                                        string submit = gvt.GetFocusedRowCellValue("WorkSet_Type").ToStringEx();
                                        if (submit.Equals("7"))
                                        {
                                            dr["Bind_FormWidth"] = 25;
                                            dr["Bind_FormSort"] = (col.Ordinal + 10) * 10 + 1000;
                                            dr["Bind_Push"] = "edit_" + col.ColumnName;
                                            dr["Bind_Property"] = "EditValue";
                                        }
                                        //IsEditable
                                        if (col.ColumnName == "IsEditable")
                                        {
                                            dr["Bind_Default"] = "True";
                                        }
                                        //IsEditable
                                        if (col.ColumnName == "IsEnabled")
                                        {
                                            dr["Bind_Default"] = "True";
                                        }
                                        if (col.ColumnName == "PageCount")
                                        {
                                            dr["Bind_Property"] = col.ColumnName;
                                            dr["Bind_Push"] = gvt.GetFocusedRowCellValue("WorkSet_Pagination").ToStringEx();
                                            dr["Bind_Sort"] = 999999;
                                        }
                                        fdt.Rows.Add(dr);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            SharedFunc.RaiseError(ex);
                        }
                        break;
                    case "Design":
                        e.Button.Properties.Checked = false;
                        break;
                    case "Subversion":
                        e.Button.Properties.Checked = false;
                        List<MyParameter> mps = new List<MyParameter>();
                        mps.Add("@cSubversion_Table", DbType.String, "Sys_WorkSet", null);
                        mps.Add("@cSubversion_Field", DbType.String, "WorkSet_" + CurBtn, null);
                        mps.Add("@cSubversion_Key", DbType.String, gvt.GetFocusedRowCellValue("WorkSet_Id").ToStringEx(), null);
                        lstVer.Manager.Items.Clear();
                        DataTable sdt = BaseService.Open("SystemWorkSet_Subversion", mps);
                        List<Sys_Subversion> sys_Subversions = EntityHelper.GetEntities<Sys_Subversion>(sdt);
                        foreach (Sys_Subversion sys_Subversion in sys_Subversions)
                        {
                            string cat = sys_Subversion.Subversion_Version.ToString("yyyy-MM-dd");
                            DevExpress.XtraBars.BarSubItem subItem;
                            if (lstVer.Manager.Items[cat] == null)
                            {
                                subItem = new DevExpress.XtraBars.BarSubItem();
                                subItem.Name = cat;
                                subItem.Caption = cat;
                                lstVer.AddItem(subItem);
                            }
                            subItem = (DevExpress.XtraBars.BarSubItem)lstVer.Manager.Items[cat];
                            DevExpress.XtraBars.BarButtonItem bsi = new DevExpress.XtraBars.BarButtonItem();
                            bsi.Name = sys_Subversion.Subversion_Id.ToString();
                            bsi.Hint = sys_Subversion.Subversion_Value;
                            bsi.Description = sys_Subversion.Subversion_Value;
                            bsi.Caption = sys_Subversion.Subversion_Version.ToString("HH:mm:ss");
                            bsi.Tag = sys_Subversion.Subversion_Value;
                            bsi.ItemClick += Bsi_ItemClick;
                            subItem.AddItem(bsi);
                        }
                        lstVer.ShowPopup(Control.MousePosition);
                        break;
                    case "Reset":
                        e.Button.Properties.Checked = false;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
        #region subversion 
        private void Bsi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraBars.BarButtonItem bsi = (DevExpress.XtraBars.BarButtonItem)e.Item;
            if (TopSql == null) TopSql = rtfSql_Select;
            TopSql.Script = bsi.Tag.ToStringEx();
            lstVer.HidePopup();
        }
        #endregion

        #region Snippet
        private void gccd_DoubleClick(object sender, EventArgs e)
        {
            tcd.Visible = !tcd.Visible;
        }
        private void gdcd_DataSourceChanged(object sender, EventArgs e)
        {
            tcd.DataSource = gdcd.DataSource;
            _Snippet_Nick.Caption = gvcd.Columns["Snippet_Nick"].Caption;
        }
        private void tcd_DoubleClick(object sender, EventArgs e)
        {
            DataRowView dr = (DataRowView)tcd.GetDataRecordByNode(tcd.FocusedNode);
            if (TopSql == null) TopSql = rtfSql_Select;
            TopSql.Insert(dr.Row["Snippet_Script"].ToStringEx());
        }

        #endregion

        private void gvp_DataSourceChanged(object sender, EventArgs e)
        {
            int cnt = gvp.RowCount;
            if (cnt > 0)
            {
                if (gvf.FocusedColumn.FieldName == "Popup_Nick")
                {
                    spp.Visible = true;
                    spp.SendToBack();
                    gdp.Visible = true;
                    gdp.SendToBack();
                }
            }
            else
            {
                spp.Visible = false;
                gdp.Visible = false;
            }
        }
        private void gcf_CustomButtonChecked(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            try
            {
                e.Button.Properties.Checked = true;
                foreach (DevExpress.XtraEditors.ButtonPanel.BaseButton btn in gcf.CustomHeaderButtons)
                {
                    if (btn.Caption != e.Button.Properties.Caption)
                    {
                        btn.Checked = false;
                    }
                }
                switch (e.Button.Properties.Caption)
                {
                    case "Field":
                        tabs.SelectedTabPage = tField;
                        break;
                    case "Tree":
                        tabs.SelectedTabPage = tTree;
                        break;
                    case "Validation":
                        tabs.SelectedTabPage = tValidation;
                        break;
                    case "Button":
                        loadSub(lastPage);
                        tabs.SelectedTabPage = tButton;
                        break;
                    case "Format":
                        tabs.SelectedTabPage = tFormat;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
            }
        }
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
        private void gvt_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //if (gvt.GetFocusedRowCellValue("WorkSet_Type").ToStringEx() == "7")
            //{
            //    gvf.Columns["Bind_FormSort"].Visible = true;
            //    gvf.Columns["Bind_FormWidth"].Visible = true;
            //}
            //else
            //{
            //    gvf.Columns["Bind_FormSort"].Visible = false;
            //    gvf.Columns["Bind_FormWidth"].Visible = false;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var bing = rtfSql_Select.DataBindings;
        }
    }

}