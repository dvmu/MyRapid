/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyRapid.Base
{
    public partial class GridLayoutBuilderUI : Form
    {
        public IDesignerHost iDesignerHost;
        public GridLayoutBuilderUI(IDesignerHost host)
        {
            InitializeComponent();
            iDesignerHost = host;
            txtConn.Text = CacheHelper.Get<string>("ConnectionString");
            if (string.IsNullOrEmpty(txtConn.Text))
                txtConn.Text = "Data Source=.;database=myrapid;user id=sa;password=sa1234";
            Control root = (Control)iDesignerHost.RootComponent;
            FindGrid(root);
        }
        private void FindGrid(Control parentControl)
        {
            foreach (Control grid in parentControl.Controls)
            {
                if (grid.GetType() == typeof(GridControl))
                {
                    gridList[grid.Name] = grid;
                    RadioGroupItem tgi = new RadioGroupItem();
                    tgi.Description = grid.Name;
                    tgi.Value = grid;
                    gds.Properties.Items.Add(tgi);
                }
                if (grid.GetType() == typeof(GroupControl))
                {
                    gridList[grid.Name] = grid;
                    RadioGroupItem tgi = new RadioGroupItem();
                    tgi.Description = grid.Name;
                    tgi.Value = grid;
                    gds.Properties.Items.Add(tgi);
                }
                FindGrid(grid);
            }
        }
        private Dictionary<string, Control> gridList = new Dictionary<string, Control>();
        private void InitializeTable()
        {
            string sql = @"
            SELECT A.ID Table_Id,A.NAME Table_Name , CONVERT(NVARCHAR(MAX),B.VALUE) Table_Description , A.CRDATE Create_Time
            FROM  SYSOBJECTS A
            LEFT JOIN SYS.EXTENDED_PROPERTIES B ON A.ID=B.MAJOR_ID AND B.MINOR_ID=0
            WHERE A.XTYPE='U' 
            ORDER BY A.NAME";
            DataTable dt = SqlHelper.GetDataTable(sql);
            gdl.DataSource = dt;
        }
        private List<Sys_Schema> InitializeField()
        {
            string sql = @"
            SELECT A.NAME FieldName, A.NAME FieldNameOld,CONVERT(BIT,A.is_identity) IsIdentity,A.column_id SortOrder,
            ISNULL(I.is_primary_key,0) IsPrimary, ISNULL(I.is_unique,0) IsUnique, CONVERT(BIT,A.is_nullable) IsNullable,
            CASE WHEN I.object_id IS NULL THEN CONVERT(BIT,0) ELSE CONVERT(BIT,1) END IsIndex,
            CASE B.NAME WHEN 'binary' THEN B.NAME + '(' + CASE CONVERT(VARCHAR,ISNULL(D.PREC,'')) WHEN '' THEN '' WHEN '-1' THEN 'MAX)' ELSE CONVERT(VARCHAR,ISNULL(D.PREC,''))+')' END
            WHEN 'char' THEN B.NAME + '(' + CASE CONVERT(VARCHAR,ISNULL(D.PREC,'')) WHEN '' THEN '' WHEN '-1' THEN 'MAX)' ELSE CONVERT(VARCHAR,ISNULL(D.PREC,''))+')' END
            WHEN 'datetime2' THEN B.NAME + '(' + CASE CONVERT(VARCHAR,ISNULL(D.PREC,'')) WHEN '' THEN '' WHEN '-1' THEN 'MAX)' ELSE CONVERT(VARCHAR,ISNULL(D.PREC,''))+')' END
            WHEN 'datetimeoffset' THEN B.NAME + '(' + CASE CONVERT(VARCHAR,ISNULL(D.PREC,'')) WHEN '' THEN '' WHEN '-1' THEN 'MAX)' ELSE CONVERT(VARCHAR,ISNULL(D.PREC,'')) +')'END
            WHEN 'nchar' THEN B.NAME + '(' + CASE CONVERT(VARCHAR,ISNULL(D.PREC,'')) WHEN '' THEN '' WHEN '-1' THEN 'MAX)' ELSE CONVERT(VARCHAR,ISNULL(D.PREC,''))+')' END
            WHEN 'nvarchar' THEN B.NAME + '(' + CASE CONVERT(VARCHAR,ISNULL(D.PREC,'')) WHEN '' THEN '' WHEN '-1' THEN 'MAX)' ELSE CONVERT(VARCHAR,ISNULL(D.PREC,''))+')' END
            WHEN 'time' THEN B.NAME + '(' + CASE CONVERT(VARCHAR,ISNULL(D.PREC,'')) WHEN '' THEN '' WHEN '-1' THEN 'MAX)' ELSE CONVERT(VARCHAR,ISNULL(D.PREC,''))+')' END
            WHEN 'varbinary' THEN B.NAME + '(' + CASE CONVERT(VARCHAR,ISNULL(D.PREC,'')) WHEN '' THEN '' WHEN '-1' THEN 'MAX)' ELSE CONVERT(VARCHAR,ISNULL(D.PREC,''))+')' END
            WHEN 'varchar' THEN B.NAME + '(' + CASE CONVERT(VARCHAR,ISNULL(D.PREC,'')) WHEN '' THEN '' WHEN '-1' THEN 'MAX)' ELSE CONVERT(VARCHAR,ISNULL(D.PREC,''))+')' END
            WHEN 'decimal' THEN B.NAME + '(' + CASE CONVERT(VARCHAR,ISNULL(D.PREC,'')) WHEN '' THEN '' WHEN '-1' THEN 'MAX)' ELSE CONVERT(VARCHAR,ISNULL(D.PREC,'')) END
            + CASE ISNULL(A.SCALE,0) WHEN 0 THEN '' ELSE ','+CONVERT(VARCHAR,A.SCALE)+')'  END 
            WHEN 'numeric' THEN B.NAME + '(' + CASE CONVERT(VARCHAR,ISNULL(D.PREC,'')) WHEN '' THEN '' WHEN '-1' THEN 'MAX)' ELSE CONVERT(VARCHAR,ISNULL(D.PREC,''))+')' END
            + CASE ISNULL(A.SCALE,0) WHEN 0 THEN '' ELSE ','+CONVERT(VARCHAR,A.SCALE)+')'  END ELSE B.NAME END SqlDbType,
            O.NAME  TableName,
             F.TEXT DefaultValue,CAST(ISNULL(E.VALUE,'') AS NVARCHAR(256)) Description
            FROM SYS.COLUMNS A
            LEFT JOIN SYSCOLUMNS D ON A.OBJECT_ID = D.ID AND A.COLUMN_ID = D.COLID
            LEFT JOIN SYS.OBJECTS O ON A.OBJECT_ID = O.OBJECT_ID
            LEFT JOIN SYS.TYPES B ON A.SYSTEM_TYPE_ID =B.SYSTEM_TYPE_ID AND B.USER_TYPE_ID = A.USER_TYPE_ID
            LEFT JOIN SYS.INDEX_COLUMNS AS C ON A.OBJECT_ID = C.OBJECT_ID AND A.COLUMN_ID = C.COLUMN_ID
            LEFT JOIN SYS.INDEXES I ON A.OBJECT_ID = I.OBJECT_ID AND C.INDEX_ID = I.INDEX_ID
            LEFT OUTER JOIN  SYS.EXTENDED_PROPERTIES E ON  E.MAJOR_ID =  A.OBJECT_ID AND   E.MINOR_ID =A.COLUMN_ID AND E.NAME = 'MS_DESCRIPTION'
            LEFT JOIN SYSCOMMENTS F ON A.DEFAULT_OBJECT_ID =F.ID
            WHERE A.OBJECT_ID = @Table_Id";
            string tid = gvl.GetFocusedRowCellValue("Table_Id").ToStringEx();
            List<DbParameter> sps = new List<DbParameter>();
            SqlParameter sp = new SqlParameter("@Table_Id", tid);
            sps.Add(sp);
            DataTable dt = SqlHelper.GetDataTable(sql, sps);
            List<Sys_Schema> sys_Schemas = EntityHelper.GetEntities<Sys_Schema>(dt);
            return sys_Schemas;
        }
        private void InitializeControl()
        {
            if (gds.SelectedIndex < 0) return;
            if (gds.EditValue != null && gds.EditValue.GetType() == typeof(GridControl))
            {
                InitializeColumn();
            }
            if (gds.EditValue != null && gds.EditValue.GetType() == typeof(GroupControl))
            {
                InitializeQuery();
            }
        }
        private void InitializeQuery()
        {
            List<Sys_Schema> sys_Schemas = InitializeField();
            if (gds.SelectedIndex < 0) return;
            GroupControl grid;
            if (gds.EditValue != null && gds.EditValue.GetType() == typeof(GroupControl))
            {
                grid = (GroupControl)gds.EditValue;
                LayoutControl eLayoutControl = (LayoutControl)iDesignerHost.CreateComponent(typeof(LayoutControl), "lyc");
                grid.Controls.Add(eLayoutControl);
                eLayoutControl.BeginUpdate();
                LayoutControlGroup eLayoutControlGroup = new LayoutControlGroup();
                eLayoutControlGroup.BeginUpdate();
                eLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
                eLayoutControl.Location = new System.Drawing.Point(2, 21);
                eLayoutControl.Name = "eLayoutControl";
                eLayoutControl.Root = eLayoutControlGroup;
                eLayoutControl.Size = new System.Drawing.Size(1000, 500);
                eLayoutControl.TabIndex = 0;
                eLayoutControl.Text = "QueryLayout";
                eLayoutControlGroup.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
                eLayoutControlGroup.GroupBordersVisible = false;
                eLayoutControlGroup.Size = new Size(1000, 500);
                eLayoutControlGroup.Location = new Point(0, 0);
                eLayoutControlGroup.Name = "eLayoutControlGroup";
                eLayoutControlGroup.TextVisible = false;
                List<BaseLayoutItem> baseLayoutItems = new List<BaseLayoutItem>();
                int curLeft = 0;
                int curTop = 0;
                foreach (Sys_Schema sys_Schema in sys_Schemas)
                {
                    try
                    {
                        string gn = string.Format("f{0}", sys_Schema.FieldName);
                        BaseEdit baseEdit = null;
                        if (sys_Schema.SqlDbType.Equals("bit"))
                        {
                            baseEdit = (CheckEdit)iDesignerHost.CreateComponent(typeof(CheckEdit), gn);
                            baseEdit.Text = string.Empty;
                        }
                        else if (sys_Schema.SqlDbType.Equals("datetime"))
                        {
                            baseEdit = (DateEdit)iDesignerHost.CreateComponent(typeof(DateEdit), gn);
                        }
                        else
                        {
                            baseEdit = (TextEdit)iDesignerHost.CreateComponent(typeof(TextEdit), gn);
                        }
                        baseEdit.Width = 250;
                        baseEdit.Properties.Appearance.Options.UseTextOptions = true;
                        LayoutControlItem eLayoutControlItem = new LayoutControlItem();
                        eLayoutControlItem.Location = new System.Drawing.Point(curLeft, curTop);
                        eLayoutControlItem.Name = "oli_" + sys_Schema.FieldName;
                        eLayoutControlItem.Text = sys_Schema.Description;
                        eLayoutControlItem.Size = new Size(baseEdit.Width, baseEdit.Height);
                        eLayoutControlItem.Control = baseEdit;
                        baseLayoutItems.Add(eLayoutControlItem);
                        curLeft += baseEdit.Width;
                        if (curLeft >= eLayoutControlGroup.Width)
                        {
                            curLeft = 0;
                            curTop += baseEdit.Height;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
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
                EmptySpaceItem emptyBottom = new EmptySpaceItem();
                emptyBottom.AllowHotTrack = false;
                emptyBottom.Location = new System.Drawing.Point(0, curTop + 24);
                emptyBottom.Name = "oli_Space";
                emptyBottom.Size = new System.Drawing.Size(eLayoutControlGroup.Width, 24);
                baseLayoutItems.Add(emptyBottom);
                eLayoutControlGroup.Items.AddRange(baseLayoutItems.ToArray());
                eLayoutControlGroup.EndUpdate();
                eLayoutControl.EndUpdate();
            }
        }
        private void InitializeColumn()
        {
            List<Sys_Schema> sys_Schemas = InitializeField();
            if (gds.SelectedIndex < 0) return;
            string gridName = "_";
            if (gds.EditValue != null && gds.EditValue.GetType() == typeof(GridControl))
            {
                GridControl grid = (GridControl)gds.EditValue;
                gridName = grid.Name;
            }
            foreach (Sys_Schema sys_Schema in sys_Schemas)
            {
                string gn = string.Format("{0}_{1}", gridName, sys_Schema.FieldName);
                GridColumn gc = (GridColumn)iDesignerHost.CreateComponent(typeof(GridColumn), gn);
                gc.FieldName = sys_Schema.FieldName;
                switch (sys_Schema.SqlDbType)
                {
                    case "bit":
                        gc.Width = 40;
                        break;
                    case "datetime":
                        gc.Width = 128;
                        break;
                    default:
                        gc.Width = 100;
                        break;
                }
                gc.VisibleIndex = sys_Schema.SortOrder;
                gc.Caption = string.IsNullOrEmpty(sys_Schema.Description) ? sys_Schema.FieldName : sys_Schema.Description;
                if (gds.EditValue != null && gds.EditValue.GetType() == typeof(GridControl))
                {
                    GridControl grid = (GridControl)gds.EditValue;
                    GridView gv = (GridView)grid.MainView;
                    gv.OptionsView.ColumnAutoWidth = false;
                    gv.Columns.Add(gc);
                }
            }
        }
        private void txtConn_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlHelper.connectionString = txtConn.Text;
                CacheHelper.Set("ConnectionString", txtConn.Text);
            }
            catch (Exception ex)
            {
                txtConn.Text += ex.Message;
            }
        }
        private void gdl_DoubleClick(object sender, EventArgs e)
        {
            InitializeControl();
        }
        private void groupControl2_CustomButtonClick(object sender, DevExpress.XtraBars.Docking2010.BaseButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Refresh":
                    InitializeTable();
                    break;
                case "Submit":
                    InitializeControl();
                    break;
                default:
                    break;
            }
        }
    }
}