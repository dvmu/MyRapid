/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemRoleMenu
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
            this.components = new System.ComponentModel.Container();
            this.layout1 = new MyRapid.Base.Layout(this.components);
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.gcl = new DevExpress.XtraEditors.GroupControl();
            this.gdl = new DevExpress.XtraGrid.GridControl();
            this.gvl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.qry = new DevExpress.XtraEditors.GroupControl();
            this.gcf = new DevExpress.XtraEditors.GroupControl();
            this.trl = new DevExpress.XtraTreeList.TreeList();
            this._HasMenu = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this._Menu_Nick = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gdf = new DevExpress.XtraGrid.GridControl();
            this.gvf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcr = new DevExpress.XtraEditors.GroupControl();
            this.gdr = new DevExpress.XtraGrid.GridControl();
            this.gvr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gcrb = new DevExpress.XtraEditors.GroupControl();
            this.gdrb = new DevExpress.XtraGrid.GridControl();
            this.gvrb = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl5 = new DevExpress.XtraEditors.SplitterControl();
            this.gcrf = new DevExpress.XtraEditors.GroupControl();
            this.gdrf = new DevExpress.XtraGrid.GridControl();
            this.gvrf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl4 = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).BeginInit();
            this.gcl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).BeginInit();
            this.gcf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcr)).BeginInit();
            this.gcr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcrb)).BeginInit();
            this.gcrb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvrb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcrf)).BeginInit();
            this.gcrf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdrf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvrf)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(359, 117);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 491);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // gcl
            // 
            this.gcl.Controls.Add(this.gdl);
            this.gcl.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcl.Location = new System.Drawing.Point(0, 117);
            this.gcl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcl.Name = "gcl";
            this.gcl.Size = new System.Drawing.Size(359, 491);
            this.gcl.TabIndex = 5;
            this.gcl.Text = "角色";
            // 
            // gdl
            // 
            this.gdl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdl.Location = new System.Drawing.Point(2, 21);
            this.gdl.MainView = this.gvl;
            this.gdl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdl.Name = "gdl";
            this.gdl.Size = new System.Drawing.Size(355, 468);
            this.gdl.TabIndex = 0;
            this.gdl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvl});
            // 
            // gvl
            // 
            this.gvl.GridControl = this.gdl;
            this.gvl.Name = "gvl";
            this.gvl.OptionsSelection.MultiSelect = true;
            this.gvl.OptionsView.ShowGroupPanel = false;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Location = new System.Drawing.Point(0, 112);
            this.splitterControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(1059, 5);
            this.splitterControl2.TabIndex = 6;
            this.splitterControl2.TabStop = false;
            // 
            // qry
            // 
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 31);
            this.qry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(1059, 81);
            this.qry.TabIndex = 7;
            this.qry.Text = "查询";
            // 
            // gcf
            // 
            this.gcf.Controls.Add(this.trl);
            this.gcf.Controls.Add(this.gdf);
            this.gcf.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcf.Location = new System.Drawing.Point(364, 117);
            this.gcf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcf.Name = "gcf";
            this.gcf.Size = new System.Drawing.Size(255, 491);
            this.gcf.TabIndex = 8;
            this.gcf.Text = "菜单";
            // 
            // trl
            // 
            this.trl.AllowDrop = true;
            this.trl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.trl.CheckBoxFieldName = "HasMenu";
            this.trl.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this._HasMenu,
            this._Menu_Nick});
            this.trl.Cursor = System.Windows.Forms.Cursors.Default;
            this.trl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trl.KeyFieldName = "Menu_Id";
            this.trl.Location = new System.Drawing.Point(2, 21);
            this.trl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trl.Name = "trl";
            this.trl.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            this.trl.OptionsView.ShowCheckBoxes = true;
            this.trl.OptionsView.ShowColumns = false;
            this.trl.OptionsView.ShowHorzLines = false;
            this.trl.OptionsView.ShowIndicator = false;
            this.trl.OptionsView.ShowVertLines = false;
            this.trl.ParentFieldName = "Menu_Parent";
            this.trl.Size = new System.Drawing.Size(251, 468);
            this.trl.TabIndex = 2;
            this.trl.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.trl_AfterCheckNode);
            // 
            // _HasMenu
            // 
            this._HasMenu.Caption = "选择";
            this._HasMenu.FieldName = "HasMenu";
            this._HasMenu.MinWidth = 34;
            this._HasMenu.Name = "_HasMenu";
            this._HasMenu.Width = 40;
            // 
            // _Menu_Nick
            // 
            this._Menu_Nick.Caption = "菜单";
            this._Menu_Nick.FieldName = "Menu_Nick";
            this._Menu_Nick.MinWidth = 34;
            this._Menu_Nick.Name = "_Menu_Nick";
            this._Menu_Nick.OptionsColumn.AllowEdit = false;
            this._Menu_Nick.Visible = true;
            this._Menu_Nick.VisibleIndex = 0;
            this._Menu_Nick.Width = 180;
            // 
            // gdf
            // 
            this.gdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdf.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdf.Location = new System.Drawing.Point(2, 21);
            this.gdf.MainView = this.gvf;
            this.gdf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdf.Name = "gdf";
            this.gdf.Size = new System.Drawing.Size(251, 468);
            this.gdf.TabIndex = 0;
            this.gdf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvf});
            this.gdf.DataSourceChanged += new System.EventHandler(this.gdf_DataSourceChanged);
            // 
            // gvf
            // 
            this.gvf.GridControl = this.gdf;
            this.gvf.Name = "gvf";
            this.gvf.OptionsSelection.MultiSelect = true;
            this.gvf.OptionsView.ShowFooter = true;
            this.gvf.OptionsView.ShowGroupPanel = false;
            // 
            // gcr
            // 
            this.gcr.Controls.Add(this.gdr);
            this.gcr.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcr.Location = new System.Drawing.Point(0, 0);
            this.gcr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcr.Name = "gcr";
            this.gcr.Size = new System.Drawing.Size(435, 196);
            this.gcr.TabIndex = 9;
            this.gcr.Text = "按钮";
            // 
            // gdr
            // 
            this.gdr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdr.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdr.Location = new System.Drawing.Point(2, 21);
            this.gdr.MainView = this.gvr;
            this.gdr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdr.Name = "gdr";
            this.gdr.Size = new System.Drawing.Size(431, 173);
            this.gdr.TabIndex = 0;
            this.gdr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvr});
            // 
            // gvr
            // 
            this.gvr.GridControl = this.gdr;
            this.gvr.Name = "gvr";
            this.gvr.OptionsSelection.MultiSelect = true;
            this.gvr.OptionsView.ShowGroupPanel = false;
            // 
            // splitterControl3
            // 
            this.splitterControl3.Location = new System.Drawing.Point(619, 117);
            this.splitterControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.Size = new System.Drawing.Size(5, 491);
            this.splitterControl3.TabIndex = 10;
            this.splitterControl3.TabStop = false;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gcrb);
            this.panelControl1.Controls.Add(this.splitterControl5);
            this.panelControl1.Controls.Add(this.gcrf);
            this.panelControl1.Controls.Add(this.splitterControl4);
            this.panelControl1.Controls.Add(this.gcr);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(624, 117);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(435, 491);
            this.panelControl1.TabIndex = 11;
            // 
            // gcrb
            // 
            this.gcrb.Controls.Add(this.gdrb);
            this.gcrb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcrb.Location = new System.Drawing.Point(0, 351);
            this.gcrb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcrb.Name = "gcrb";
            this.gcrb.Size = new System.Drawing.Size(435, 140);
            this.gcrb.TabIndex = 13;
            this.gcrb.Text = "字段";
            // 
            // gdrb
            // 
            this.gdrb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdrb.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdrb.Location = new System.Drawing.Point(2, 21);
            this.gdrb.MainView = this.gvrb;
            this.gdrb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdrb.Name = "gdrb";
            this.gdrb.Size = new System.Drawing.Size(431, 117);
            this.gdrb.TabIndex = 0;
            this.gdrb.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvrb});
            // 
            // gvrb
            // 
            this.gvrb.GridControl = this.gdrb;
            this.gvrb.Name = "gvrb";
            this.gvrb.OptionsSelection.MultiSelect = true;
            this.gvrb.OptionsView.ShowGroupPanel = false;
            // 
            // splitterControl5
            // 
            this.splitterControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl5.Location = new System.Drawing.Point(0, 346);
            this.splitterControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl5.Name = "splitterControl5";
            this.splitterControl5.Size = new System.Drawing.Size(435, 5);
            this.splitterControl5.TabIndex = 12;
            this.splitterControl5.TabStop = false;
            // 
            // gcrf
            // 
            this.gcrf.Controls.Add(this.gdrf);
            this.gcrf.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcrf.Location = new System.Drawing.Point(0, 201);
            this.gcrf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcrf.Name = "gcrf";
            this.gcrf.Size = new System.Drawing.Size(435, 145);
            this.gcrf.TabIndex = 11;
            this.gcrf.Text = "WorkSet";
            // 
            // gdrf
            // 
            this.gdrf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdrf.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdrf.Location = new System.Drawing.Point(2, 21);
            this.gdrf.MainView = this.gvrf;
            this.gdrf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdrf.Name = "gdrf";
            this.gdrf.Size = new System.Drawing.Size(431, 122);
            this.gdrf.TabIndex = 0;
            this.gdrf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvrf});
            // 
            // gvrf
            // 
            this.gvrf.GridControl = this.gdrf;
            this.gvrf.Name = "gvrf";
            this.gvrf.OptionsSelection.MultiSelect = true;
            this.gvrf.OptionsView.ShowGroupPanel = false;
            // 
            // splitterControl4
            // 
            this.splitterControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl4.Location = new System.Drawing.Point(0, 196);
            this.splitterControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl4.Name = "splitterControl4";
            this.splitterControl4.Size = new System.Drawing.Size(435, 5);
            this.splitterControl4.TabIndex = 10;
            this.splitterControl4.TabStop = false;
            // 
            // SystemRoleMenu
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 635);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.splitterControl3);
            this.Controls.Add(this.gcf);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gcl);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.qry);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SystemRoleMenu";
            this.QueryControl = this.qry;
            this.Text = "SystemRoleMenu";
            this.Controls.SetChildIndex(this.qry, 0);
            this.Controls.SetChildIndex(this.splitterControl2, 0);
            this.Controls.SetChildIndex(this.gcl, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.gcf, 0);
            this.Controls.SetChildIndex(this.splitterControl3, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).EndInit();
            this.gcl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).EndInit();
            this.gcf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcr)).EndInit();
            this.gcr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcrb)).EndInit();
            this.gcrb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvrb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcrf)).EndInit();
            this.gcrf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdrf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvrf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private Base.Layout layout1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl gcl;
        private DevExpress.XtraGrid.GridControl gdl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvl;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraEditors.GroupControl gcf;
        private DevExpress.XtraGrid.GridControl gdf;
        private DevExpress.XtraGrid.Views.Grid.GridView gvf;
        private DevExpress.XtraTreeList.TreeList trl;
        private DevExpress.XtraTreeList.Columns.TreeListColumn _HasMenu;
        private DevExpress.XtraTreeList.Columns.TreeListColumn _Menu_Nick;
        private DevExpress.XtraEditors.GroupControl gcr;
        private DevExpress.XtraGrid.GridControl gdr;
        private DevExpress.XtraGrid.Views.Grid.GridView gvr;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.GroupControl gcrf;
        private DevExpress.XtraGrid.GridControl gdrf;
        private DevExpress.XtraGrid.Views.Grid.GridView gvrf;
        private DevExpress.XtraEditors.SplitterControl splitterControl4;
        private DevExpress.XtraEditors.GroupControl gcrb;
        private DevExpress.XtraGrid.GridControl gdrb;
        private DevExpress.XtraGrid.Views.Grid.GridView gvrb;
        private DevExpress.XtraEditors.SplitterControl splitterControl5;
    }
}