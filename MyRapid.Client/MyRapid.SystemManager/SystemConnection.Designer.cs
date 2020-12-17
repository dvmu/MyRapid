/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemConnection
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gcl = new DevExpress.XtraEditors.GroupControl();
            this.lyc = new DevExpress.XtraLayout.LayoutControl();
            this.fConnection_Name = new DevExpress.XtraEditors.TextEdit();
            this.fConnection_Server = new DevExpress.XtraEditors.TextEdit();
            this.fConnection_Port = new DevExpress.XtraEditors.TextEdit();
            this.fConnection_DataBase = new DevExpress.XtraEditors.TextEdit();
            this.fConnection_UserName = new DevExpress.XtraEditors.TextEdit();
            this.fConnection_Password = new DevExpress.XtraEditors.TextEdit();
            this.fConnection_Connection = new DevExpress.XtraEditors.MemoEdit();
            this.fConnection_Type = new DevExpress.XtraEditors.LookUpEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.oli_Connection_Name = new DevExpress.XtraLayout.LayoutControlItem();
            this.oli_Connection_Server = new DevExpress.XtraLayout.LayoutControlItem();
            this.oli_Connection_Connection = new DevExpress.XtraLayout.LayoutControlItem();
            this.oli_Connection_DataBase = new DevExpress.XtraLayout.LayoutControlItem();
            this.oli_Connection_UserName = new DevExpress.XtraLayout.LayoutControlItem();
            this.oli_Connection_Type = new DevExpress.XtraLayout.LayoutControlItem();
            this.oli_Connection_Port = new DevExpress.XtraLayout.LayoutControlItem();
            this.oli_Connection_Password = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.qry = new DevExpress.XtraEditors.GroupControl();
            this.gdf = new DevExpress.XtraGrid.GridControl();
            this.gvf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcf = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).BeginInit();
            this.gcl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lyc)).BeginInit();
            this.lyc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Server.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Port.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_DataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_UserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Connection.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Type.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Name)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Server)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Connection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_DataBase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_UserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).BeginInit();
            this.gcf.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(500, 116);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 349);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // gcl
            // 
            this.gcl.Controls.Add(this.lyc);
            this.gcl.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcl.Location = new System.Drawing.Point(0, 116);
            this.gcl.Name = "gcl";
            this.gcl.Size = new System.Drawing.Size(500, 349);
            this.gcl.TabIndex = 5;
            this.gcl.Text = "信息";
            // 
            // lyc
            // 
            this.lyc.Controls.Add(this.fConnection_Name);
            this.lyc.Controls.Add(this.fConnection_Server);
            this.lyc.Controls.Add(this.fConnection_Port);
            this.lyc.Controls.Add(this.fConnection_DataBase);
            this.lyc.Controls.Add(this.fConnection_UserName);
            this.lyc.Controls.Add(this.fConnection_Password);
            this.lyc.Controls.Add(this.fConnection_Connection);
            this.lyc.Controls.Add(this.fConnection_Type);
            this.lyc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lyc.Location = new System.Drawing.Point(2, 21);
            this.lyc.Name = "lyc";
            this.lyc.OptionsView.UseDefaultDragAndDropRendering = false;
            this.lyc.Root = this.layoutControlGroup1;
            this.lyc.Size = new System.Drawing.Size(496, 326);
            this.lyc.TabIndex = 0;
            this.lyc.Text = "QueryLayout";
            // 
            // fConnection_Name
            // 
            this.fConnection_Name.Location = new System.Drawing.Point(75, 12);
            this.fConnection_Name.Name = "fConnection_Name";
            this.fConnection_Name.Properties.Appearance.Options.UseTextOptions = true;
            this.fConnection_Name.Size = new System.Drawing.Size(160, 20);
            this.fConnection_Name.StyleController = this.lyc;
            this.fConnection_Name.TabIndex = 2;
            // 
            // fConnection_Server
            // 
            this.fConnection_Server.Location = new System.Drawing.Point(75, 36);
            this.fConnection_Server.Name = "fConnection_Server";
            this.fConnection_Server.Properties.Appearance.Options.UseTextOptions = true;
            this.fConnection_Server.Size = new System.Drawing.Size(160, 20);
            this.fConnection_Server.StyleController = this.lyc;
            this.fConnection_Server.TabIndex = 5;
            // 
            // fConnection_Port
            // 
            this.fConnection_Port.Location = new System.Drawing.Point(302, 36);
            this.fConnection_Port.Name = "fConnection_Port";
            this.fConnection_Port.Properties.Appearance.Options.UseTextOptions = true;
            this.fConnection_Port.Size = new System.Drawing.Size(182, 20);
            this.fConnection_Port.StyleController = this.lyc;
            this.fConnection_Port.TabIndex = 6;
            // 
            // fConnection_DataBase
            // 
            this.fConnection_DataBase.Location = new System.Drawing.Point(75, 60);
            this.fConnection_DataBase.Name = "fConnection_DataBase";
            this.fConnection_DataBase.Properties.Appearance.Options.UseTextOptions = true;
            this.fConnection_DataBase.Size = new System.Drawing.Size(160, 20);
            this.fConnection_DataBase.StyleController = this.lyc;
            this.fConnection_DataBase.TabIndex = 7;
            // 
            // fConnection_UserName
            // 
            this.fConnection_UserName.Location = new System.Drawing.Point(75, 84);
            this.fConnection_UserName.Name = "fConnection_UserName";
            this.fConnection_UserName.Properties.Appearance.Options.UseTextOptions = true;
            this.fConnection_UserName.Size = new System.Drawing.Size(160, 20);
            this.fConnection_UserName.StyleController = this.lyc;
            this.fConnection_UserName.TabIndex = 8;
            // 
            // fConnection_Password
            // 
            this.fConnection_Password.Location = new System.Drawing.Point(302, 84);
            this.fConnection_Password.Name = "fConnection_Password";
            this.fConnection_Password.Properties.Appearance.Options.UseTextOptions = true;
            this.fConnection_Password.Properties.UseSystemPasswordChar = true;
            this.fConnection_Password.Size = new System.Drawing.Size(182, 20);
            this.fConnection_Password.StyleController = this.lyc;
            this.fConnection_Password.TabIndex = 9;
            // 
            // fConnection_Connection
            // 
            this.fConnection_Connection.Location = new System.Drawing.Point(12, 125);
            this.fConnection_Connection.Name = "fConnection_Connection";
            this.fConnection_Connection.Properties.Appearance.Options.UseTextOptions = true;
            this.fConnection_Connection.Size = new System.Drawing.Size(472, 43);
            this.fConnection_Connection.StyleController = this.lyc;
            this.fConnection_Connection.TabIndex = 10;
            this.fConnection_Connection.Click += new System.EventHandler(this.fConnection_Connection_Click);
            // 
            // fConnection_Type
            // 
            this.fConnection_Type.Location = new System.Drawing.Point(302, 12);
            this.fConnection_Type.Name = "fConnection_Type";
            this.fConnection_Type.Properties.Appearance.Options.UseTextOptions = true;
            this.fConnection_Type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fConnection_Type.Properties.NullText = "";
            this.fConnection_Type.Size = new System.Drawing.Size(182, 20);
            this.fConnection_Type.StyleController = this.lyc;
            this.fConnection_Type.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.oli_Connection_Name,
            this.oli_Connection_Server,
            this.oli_Connection_Connection,
            this.oli_Connection_DataBase,
            this.oli_Connection_UserName,
            this.oli_Connection_Type,
            this.oli_Connection_Port,
            this.oli_Connection_Password,
            this.emptySpaceItem2,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "eLayoutControlGroup";
            this.layoutControlGroup1.Size = new System.Drawing.Size(496, 326);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // oli_Connection_Name
            // 
            this.oli_Connection_Name.Control = this.fConnection_Name;
            this.oli_Connection_Name.Location = new System.Drawing.Point(0, 0);
            this.oli_Connection_Name.Name = "oli_Connection_Name";
            this.oli_Connection_Name.Size = new System.Drawing.Size(227, 24);
            this.oli_Connection_Name.Text = "名称";
            this.oli_Connection_Name.TextSize = new System.Drawing.Size(60, 14);
            // 
            // oli_Connection_Server
            // 
            this.oli_Connection_Server.Control = this.fConnection_Server;
            this.oli_Connection_Server.Location = new System.Drawing.Point(0, 24);
            this.oli_Connection_Server.Name = "oli_Connection_Server";
            this.oli_Connection_Server.Size = new System.Drawing.Size(227, 24);
            this.oli_Connection_Server.Text = "服务器";
            this.oli_Connection_Server.TextSize = new System.Drawing.Size(60, 14);
            // 
            // oli_Connection_Connection
            // 
            this.oli_Connection_Connection.Control = this.fConnection_Connection;
            this.oli_Connection_Connection.Location = new System.Drawing.Point(0, 96);
            this.oli_Connection_Connection.Name = "oli_Connection_Connection";
            this.oli_Connection_Connection.Size = new System.Drawing.Size(476, 64);
            this.oli_Connection_Connection.Text = "连接字符串";
            this.oli_Connection_Connection.TextLocation = DevExpress.Utils.Locations.Top;
            this.oli_Connection_Connection.TextSize = new System.Drawing.Size(60, 14);
            // 
            // oli_Connection_DataBase
            // 
            this.oli_Connection_DataBase.Control = this.fConnection_DataBase;
            this.oli_Connection_DataBase.Location = new System.Drawing.Point(0, 48);
            this.oli_Connection_DataBase.Name = "oli_Connection_DataBase";
            this.oli_Connection_DataBase.Size = new System.Drawing.Size(227, 24);
            this.oli_Connection_DataBase.Text = "数据库";
            this.oli_Connection_DataBase.TextSize = new System.Drawing.Size(60, 14);
            // 
            // oli_Connection_UserName
            // 
            this.oli_Connection_UserName.Control = this.fConnection_UserName;
            this.oli_Connection_UserName.Location = new System.Drawing.Point(0, 72);
            this.oli_Connection_UserName.Name = "oli_Connection_UserName";
            this.oli_Connection_UserName.Size = new System.Drawing.Size(227, 24);
            this.oli_Connection_UserName.Text = "帐号";
            this.oli_Connection_UserName.TextSize = new System.Drawing.Size(60, 14);
            // 
            // oli_Connection_Type
            // 
            this.oli_Connection_Type.Control = this.fConnection_Type;
            this.oli_Connection_Type.Location = new System.Drawing.Point(227, 0);
            this.oli_Connection_Type.Name = "oli_Connection_Type";
            this.oli_Connection_Type.Size = new System.Drawing.Size(249, 24);
            this.oli_Connection_Type.Text = "类型";
            this.oli_Connection_Type.TextSize = new System.Drawing.Size(60, 14);
            // 
            // oli_Connection_Port
            // 
            this.oli_Connection_Port.Control = this.fConnection_Port;
            this.oli_Connection_Port.Location = new System.Drawing.Point(227, 24);
            this.oli_Connection_Port.Name = "oli_Connection_Port";
            this.oli_Connection_Port.Size = new System.Drawing.Size(249, 24);
            this.oli_Connection_Port.Text = "端口";
            this.oli_Connection_Port.TextSize = new System.Drawing.Size(60, 14);
            // 
            // oli_Connection_Password
            // 
            this.oli_Connection_Password.Control = this.fConnection_Password;
            this.oli_Connection_Password.Location = new System.Drawing.Point(227, 72);
            this.oli_Connection_Password.Name = "oli_Connection_Password";
            this.oli_Connection_Password.Size = new System.Drawing.Size(249, 24);
            this.oli_Connection_Password.Text = "密码";
            this.oli_Connection_Password.TextSize = new System.Drawing.Size(60, 14);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(0, 160);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(476, 146);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(227, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(249, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Location = new System.Drawing.Point(0, 111);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(710, 5);
            this.splitterControl2.TabIndex = 6;
            this.splitterControl2.TabStop = false;
            // 
            // qry
            // 
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 31);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(710, 80);
            this.qry.TabIndex = 7;
            this.qry.Text = "查询";
            // 
            // gdf
            // 
            this.gdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdf.Location = new System.Drawing.Point(2, 21);
            this.gdf.MainView = this.gvf;
            this.gdf.Name = "gdf";
            this.gdf.Size = new System.Drawing.Size(201, 326);
            this.gdf.TabIndex = 0;
            this.gdf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvf,
            this.gridView1});
            // 
            // gvf
            // 
            this.gvf.GridControl = this.gdf;
            this.gvf.Name = "gvf";
            this.gvf.OptionsSelection.MultiSelect = true;
            this.gvf.OptionsView.ColumnAutoWidth = false;
            this.gvf.OptionsView.ShowFooter = true;
            this.gvf.OptionsView.ShowGroupPanel = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gdf;
            this.gridView1.Name = "gridView1";
            // 
            // gcf
            // 
            this.gcf.Controls.Add(this.gdf);
            this.gcf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcf.Location = new System.Drawing.Point(505, 116);
            this.gcf.Name = "gcf";
            this.gcf.Size = new System.Drawing.Size(205, 349);
            this.gcf.TabIndex = 8;
            this.gcf.Text = "信息";
            // 
            // SystemConnection
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 492);
            this.Controls.Add(this.gcf);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gcl);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.qry);
            this.Name = "SystemConnection";
            this.QueryControl = this.qry;
            this.Text = "SystemConnection";
            this.Controls.SetChildIndex(this.qry, 0);
            this.Controls.SetChildIndex(this.splitterControl2, 0);
            this.Controls.SetChildIndex(this.gcl, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.gcf, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).EndInit();
            this.gcl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lyc)).EndInit();
            this.lyc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Server.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Port.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_DataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_UserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Connection.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fConnection_Type.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Name)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Server)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Connection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_DataBase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_UserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oli_Connection_Password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).EndInit();
            this.gcf.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl gcl;
        private DevExpress.XtraLayout.LayoutControl lyc;
        private DevExpress.XtraEditors.TextEdit fConnection_Name;
        private DevExpress.XtraEditors.TextEdit fConnection_Server;
        private DevExpress.XtraEditors.TextEdit fConnection_Port;
        private DevExpress.XtraEditors.TextEdit fConnection_DataBase;
        private DevExpress.XtraEditors.TextEdit fConnection_UserName;
        private DevExpress.XtraEditors.TextEdit fConnection_Password;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem oli_Connection_Name;
        private DevExpress.XtraLayout.LayoutControlItem oli_Connection_Server;
        private DevExpress.XtraLayout.LayoutControlItem oli_Connection_Port;
        private DevExpress.XtraLayout.LayoutControlItem oli_Connection_DataBase;
        private DevExpress.XtraLayout.LayoutControlItem oli_Connection_UserName;
        private DevExpress.XtraLayout.LayoutControlItem oli_Connection_Password;
        private DevExpress.XtraLayout.LayoutControlItem oli_Connection_Connection;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem oli_Connection_Type;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraGrid.GridControl gdf;
        private DevExpress.XtraGrid.Views.Grid.GridView gvf;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl gcf;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraEditors.MemoEdit fConnection_Connection;
        private DevExpress.XtraEditors.LookUpEdit fConnection_Type;
    }
}