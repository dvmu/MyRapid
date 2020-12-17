/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemStep
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
            this.gcb = new DevExpress.XtraEditors.GroupControl();
            this.gdb = new DevExpress.XtraGrid.GridControl();
            this.gvb = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.reButtonEdit = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            this.qry = new DevExpress.XtraEditors.GroupControl();
            this.gcr = new DevExpress.XtraEditors.GroupControl();
            this.gdr = new DevExpress.XtraGrid.GridControl();
            this.gvr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gc = new DevExpress.XtraEditors.GroupControl();
            this.gdc = new DevExpress.XtraGrid.GridControl();
            this.gvc = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcb)).BeginInit();
            this.gcb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reButtonEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcr)).BeginInit();
            this.gcr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            this.gc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvc)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(483, 116);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 509);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // gcb
            // 
            this.gcb.Controls.Add(this.gdb);
            this.gcb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcb.Location = new System.Drawing.Point(0, 0);
            this.gcb.Name = "gcb";
            this.gcb.Size = new System.Drawing.Size(380, 324);
            this.gcb.TabIndex = 5;
            this.gcb.Text = "步骤";
            // 
            // gdb
            // 
            this.gdb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdb.Location = new System.Drawing.Point(2, 21);
            this.gdb.MainView = this.gvb;
            this.gdb.Name = "gdb";
            this.gdb.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.reButtonEdit});
            this.gdb.Size = new System.Drawing.Size(376, 301);
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
            // reButtonEdit
            // 
            this.reButtonEdit.AutoHeight = false;
            this.reButtonEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.reButtonEdit.Name = "reButtonEdit";
            // 
            // splitterControl3
            // 
            this.splitterControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl3.Location = new System.Drawing.Point(0, 111);
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.Size = new System.Drawing.Size(868, 5);
            this.splitterControl3.TabIndex = 8;
            this.splitterControl3.TabStop = false;
            // 
            // qry
            // 
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 31);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(868, 80);
            this.qry.TabIndex = 9;
            this.qry.Text = "查询";
            // 
            // gcr
            // 
            this.gcr.Controls.Add(this.gdr);
            this.gcr.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcr.Location = new System.Drawing.Point(0, 116);
            this.gcr.Name = "gcr";
            this.gcr.Size = new System.Drawing.Size(483, 509);
            this.gcr.TabIndex = 11;
            this.gcr.Text = "应用单据";
            // 
            // gdr
            // 
            this.gdr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdr.Location = new System.Drawing.Point(2, 21);
            this.gdr.MainView = this.gvr;
            this.gdr.Name = "gdr";
            this.gdr.Size = new System.Drawing.Size(479, 486);
            this.gdr.TabIndex = 1;
            this.gdr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvr});
            // 
            // gvr
            // 
            this.gvr.GridControl = this.gdr;
            this.gvr.Name = "gvr";
            this.gvr.OptionsSelection.MultiSelect = true;
            this.gvr.OptionsView.ColumnAutoWidth = false;
            this.gvr.OptionsView.ShowFooter = true;
            this.gvr.OptionsView.ShowGroupPanel = false;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(488, 116);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcb);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gc);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(380, 509);
            this.splitContainerControl1.SplitterPosition = 180;
            this.splitContainerControl1.TabIndex = 13;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gc
            // 
            this.gc.Controls.Add(this.gdc);
            this.gc.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("标准按钮", null)});
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 0);
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(380, 180);
            this.gc.TabIndex = 7;
            this.gc.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.gc_CustomButtonClick);
            // 
            // gdc
            // 
            this.gdc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdc.Location = new System.Drawing.Point(2, 27);
            this.gdc.MainView = this.gvc;
            this.gdc.Name = "gdc";
            this.gdc.Size = new System.Drawing.Size(376, 151);
            this.gdc.TabIndex = 0;
            this.gdc.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvc});
            // 
            // gvc
            // 
            this.gvc.GridControl = this.gdc;
            this.gvc.Name = "gvc";
            this.gvc.OptionsSelection.MultiSelect = true;
            this.gvc.OptionsView.ColumnAutoWidth = false;
            this.gvc.OptionsView.ShowFooter = true;
            this.gvc.OptionsView.ShowGroupPanel = false;
            // 
            // SystemStep
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 652);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gcr);
            this.Controls.Add(this.splitterControl3);
            this.Controls.Add(this.qry);
            this.Name = "SystemStep";
            this.QueryControl = this.qry;
            this.Text = "Step";
            this.Controls.SetChildIndex(this.qry, 0);
            this.Controls.SetChildIndex(this.splitterControl3, 0);
            this.Controls.SetChildIndex(this.gcr, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcb)).EndInit();
            this.gcb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reButtonEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcr)).EndInit();
            this.gcr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            this.gc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private Base.Layout layout1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl gcb;
        private DevExpress.XtraGrid.GridControl gdb;
        private DevExpress.XtraGrid.Views.Grid.GridView gvb;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit reButtonEdit;
        private DevExpress.XtraEditors.GroupControl gcr;
        private DevExpress.XtraGrid.GridControl gdr;
        private DevExpress.XtraGrid.Views.Grid.GridView gvr;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.GroupControl gc;
        private DevExpress.XtraGrid.GridControl gdc;
        private DevExpress.XtraGrid.Views.Grid.GridView gvc;
    }
}