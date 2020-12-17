/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemScript
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
            this.layout1 = new MyRapid.Base.Layout();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gcr = new DevExpress.XtraEditors.GroupControl();
            this.trr = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.gcl = new DevExpress.XtraEditors.GroupControl();
            this.gdl = new DevExpress.XtraGrid.GridControl();
            this.gvl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcf = new DevExpress.XtraEditors.GroupControl();
            this.fSql = new MyRapid.Base.SqlEdit();
            this.gct = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.fPass = new DevExpress.XtraEditors.TextEdit();
            this.fUser = new DevExpress.XtraEditors.TextEdit();
            this.fServer = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.splitterControl4 = new DevExpress.XtraEditors.SplitterControl();
            this.gcb = new DevExpress.XtraEditors.GroupControl();
            this.gdb = new DevExpress.XtraGrid.GridControl();
            this.gvb = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.fPara = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcr)).BeginInit();
            this.gcr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).BeginInit();
            this.gcl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).BeginInit();
            this.gcf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gct)).BeginInit();
            this.gct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcb)).BeginInit();
            this.gcb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fPara.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl1.Location = new System.Drawing.Point(868, 31);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 725);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // gcr
            // 
            this.gcr.Controls.Add(this.trr);
            this.gcr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcr.Location = new System.Drawing.Point(0, 0);
            this.gcr.Name = "gcr";
            this.gcr.Size = new System.Drawing.Size(350, 325);
            this.gcr.TabIndex = 5;
            this.gcr.Text = "信息";
            // 
            // trr
            // 
            this.trr.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.trr.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1});
            this.trr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trr.KeyFieldName = "KID";
            this.trr.Location = new System.Drawing.Point(2, 21);
            this.trr.Name = "trr";
            this.trr.OptionsView.ShowColumns = false;
            this.trr.OptionsView.ShowHorzLines = false;
            this.trr.OptionsView.ShowIndicator = false;
            this.trr.OptionsView.ShowVertLines = false;
            this.trr.ParentFieldName = "PID";
            this.trr.Size = new System.Drawing.Size(346, 302);
            this.trr.TabIndex = 0;
            this.trr.BeforeExpand += new DevExpress.XtraTreeList.BeforeExpandEventHandler(this.trr_BeforeExpand);
            this.trr.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.trr_FocusedNodeChanged);
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "数据对象";
            this.treeListColumn1.FieldName = "NAME";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Location = new System.Drawing.Point(350, 31);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(5, 725);
            this.splitterControl2.TabIndex = 6;
            this.splitterControl2.TabStop = false;
            // 
            // gcl
            // 
            this.gcl.Controls.Add(this.gdl);
            this.gcl.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcl.Location = new System.Drawing.Point(0, 31);
            this.gcl.Name = "gcl";
            this.gcl.Size = new System.Drawing.Size(350, 725);
            this.gcl.TabIndex = 7;
            this.gcl.Text = "信息";
            // 
            // gdl
            // 
            this.gdl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdl.Location = new System.Drawing.Point(2, 21);
            this.gdl.MainView = this.gvl;
            this.gdl.Name = "gdl";
            this.gdl.Size = new System.Drawing.Size(346, 702);
            this.gdl.TabIndex = 0;
            this.gdl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvl});
            // 
            // gvl
            // 
            this.gvl.GridControl = this.gdl;
            this.gvl.Name = "gvl";
            this.gvl.OptionsSelection.MultiSelect = true;
            this.gvl.OptionsView.ColumnAutoWidth = false;
            this.gvl.OptionsView.ShowFooter = true;
            this.gvl.OptionsView.ShowGroupPanel = false;
            // 
            // gcf
            // 
            this.gcf.Controls.Add(this.fSql);
            this.gcf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcf.Location = new System.Drawing.Point(355, 31);
            this.gcf.Name = "gcf";
            this.gcf.Size = new System.Drawing.Size(513, 640);
            this.gcf.TabIndex = 10;
            this.gcf.Text = "信息";
            // 
            // fSql
            // 
            this.fSql.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fSql.Location = new System.Drawing.Point(2, 21);
            this.fSql.Name = "fSql";
            this.fSql.Script = "";
            this.fSql.Size = new System.Drawing.Size(509, 617);
            this.fSql.TabIndex = 0;
            // 
            // gct
            // 
            this.gct.Controls.Add(this.layoutControl1);
            this.gct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gct.Location = new System.Drawing.Point(0, 0);
            this.gct.Name = "gct";
            this.gct.Size = new System.Drawing.Size(350, 149);
            this.gct.TabIndex = 11;
            this.gct.Text = "连接";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.fPass);
            this.layoutControl1.Controls.Add(this.fUser);
            this.layoutControl1.Controls.Add(this.fServer);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(2, 21);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(346, 126);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // fPass
            // 
            this.fPass.Location = new System.Drawing.Point(51, 60);
            this.fPass.Name = "fPass";
            this.fPass.Properties.UseSystemPasswordChar = true;
            this.fPass.Size = new System.Drawing.Size(283, 20);
            this.fPass.StyleController = this.layoutControl1;
            this.fPass.TabIndex = 6;
            // 
            // fUser
            // 
            this.fUser.Location = new System.Drawing.Point(51, 36);
            this.fUser.Name = "fUser";
            this.fUser.Size = new System.Drawing.Size(283, 20);
            this.fUser.StyleController = this.layoutControl1;
            this.fUser.TabIndex = 5;
            // 
            // fServer
            // 
            this.fServer.Location = new System.Drawing.Point(51, 12);
            this.fServer.Name = "fServer";
            this.fServer.Size = new System.Drawing.Size(283, 20);
            this.fServer.StyleController = this.layoutControl1;
            this.fServer.TabIndex = 4;
            this.fServer.EditValueChanged += new System.EventHandler(this.fServer_EditValueChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem1});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(346, 126);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.fServer;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(326, 24);
            this.layoutControlItem1.Text = "服务器";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(36, 14);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.fUser;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(326, 24);
            this.layoutControlItem2.Text = "账号";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(36, 14);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.fPass;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(326, 24);
            this.layoutControlItem3.Text = "密码";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(36, 14);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 72);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(326, 34);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.IsSplitterFixed = true;
            this.splitContainerControl1.Location = new System.Drawing.Point(873, 31);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gct);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gcr);
            this.splitContainerControl1.Panel2.Controls.Add(this.splitterControl4);
            this.splitContainerControl1.Panel2.Controls.Add(this.gcb);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(350, 725);
            this.splitContainerControl1.SplitterPosition = 149;
            this.splitContainerControl1.TabIndex = 13;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // splitterControl4
            // 
            this.splitterControl4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl4.Location = new System.Drawing.Point(0, 325);
            this.splitterControl4.Name = "splitterControl4";
            this.splitterControl4.Size = new System.Drawing.Size(350, 5);
            this.splitterControl4.TabIndex = 9;
            this.splitterControl4.TabStop = false;
            // 
            // gcb
            // 
            this.gcb.Controls.Add(this.gdb);
            this.gcb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gcb.Location = new System.Drawing.Point(0, 330);
            this.gcb.Name = "gcb";
            this.gcb.Size = new System.Drawing.Size(350, 241);
            this.gcb.TabIndex = 8;
            this.gcb.Text = "信息";
            // 
            // gdb
            // 
            this.gdb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdb.Location = new System.Drawing.Point(2, 21);
            this.gdb.MainView = this.gvb;
            this.gdb.Name = "gdb";
            this.gdb.Size = new System.Drawing.Size(346, 218);
            this.gdb.TabIndex = 0;
            this.gdb.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvb});
            // 
            // gvb
            // 
            this.gvb.GridControl = this.gdb;
            this.gvb.Name = "gvb";
            this.gvb.OptionsSelection.MultiSelect = true;
            this.gvb.OptionsView.ColumnAutoWidth = false;
            this.gvb.OptionsView.ShowFooter = true;
            this.gvb.OptionsView.ShowGroupPanel = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(355, 676);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(513, 80);
            this.groupControl1.TabIndex = 14;
            this.groupControl1.Text = "参数";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.fPara);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 21);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.OptionsView.UseDefaultDragAndDropRendering = false;
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(509, 57);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // fPara
            // 
            this.fPara.Location = new System.Drawing.Point(39, 12);
            this.fPara.Name = "fPara";
            this.fPara.Size = new System.Drawing.Size(458, 20);
            this.fPara.StyleController = this.layoutControl2;
            this.fPara.TabIndex = 4;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(509, 57);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.fPara;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(489, 37);
            this.layoutControlItem4.Text = "参数";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(24, 14);
            // 
            // splitterControl3
            // 
            this.splitterControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl3.Location = new System.Drawing.Point(355, 671);
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.Size = new System.Drawing.Size(513, 5);
            this.splitterControl3.TabIndex = 15;
            this.splitterControl3.TabStop = false;
            // 
            // SystemScript
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 783);
            this.Controls.Add(this.gcf);
            this.Controls.Add(this.splitterControl3);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.gcl);
            this.Controls.Add(this.splitContainerControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "SystemScript";
            this.Text = "SystemScript";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            this.Controls.SetChildIndex(this.gcl, 0);
            this.Controls.SetChildIndex(this.splitterControl2, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.splitterControl3, 0);
            this.Controls.SetChildIndex(this.gcf, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcr)).EndInit();
            this.gcr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).EndInit();
            this.gcl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).EndInit();
            this.gcf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gct)).EndInit();
            this.gct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcb)).EndInit();
            this.gcb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fPara.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private Base.Layout layout1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl gcr;
        private DevExpress.XtraTreeList.TreeList trr;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.GroupControl gcl;
        private DevExpress.XtraGrid.GridControl gdl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvl;
        private DevExpress.XtraEditors.GroupControl gcf;
        private Base.SqlEdit fSql;
        private DevExpress.XtraEditors.GroupControl gct;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit fPass;
        private DevExpress.XtraEditors.TextEdit fUser;
        private DevExpress.XtraEditors.TextEdit fServer;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private DevExpress.XtraEditors.TextEdit fPara;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraEditors.SplitterControl splitterControl4;
        private DevExpress.XtraEditors.GroupControl gcb;
        private DevExpress.XtraGrid.GridControl gdb;
        private DevExpress.XtraGrid.Views.Grid.GridView gvb;
    }
}