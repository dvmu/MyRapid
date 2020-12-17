/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemDataBase
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
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.gcl = new DevExpress.XtraEditors.GroupControl();
            this.gdl = new DevExpress.XtraGrid.GridControl();
            this.gvl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            this.qry = new DevExpress.XtraEditors.GroupControl();
            this.gcf = new DevExpress.XtraEditors.GroupControl();
            this.gdf = new DevExpress.XtraGrid.GridControl();
            this.gvf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gdr = new DevExpress.XtraGrid.GridControl();
            this.gvr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).BeginInit();
            this.gcl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).BeginInit();
            this.gcf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl2
            // 
            this.splitterControl2.Location = new System.Drawing.Point(280, 117);
            this.splitterControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(5, 360);
            this.splitterControl2.TabIndex = 6;
            this.splitterControl2.TabStop = false;
            // 
            // gcl
            // 
            this.gcl.Controls.Add(this.gdl);
            this.gcl.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcl.Location = new System.Drawing.Point(0, 117);
            this.gcl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcl.Name = "gcl";
            this.gcl.Size = new System.Drawing.Size(280, 360);
            this.gcl.TabIndex = 7;
            this.gcl.Text = "表";
            // 
            // gdl
            // 
            this.gdl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdl.Location = new System.Drawing.Point(2, 21);
            this.gdl.MainView = this.gvl;
            this.gdl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdl.Name = "gdl";
            this.gdl.Size = new System.Drawing.Size(276, 337);
            this.gdl.TabIndex = 0;
            this.gdl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvl});
            // 
            // gvl
            // 
            this.gvl.GridControl = this.gdl;
            this.gvl.Name = "gvl";
            this.gvl.OptionsSelection.MultiSelect = true;
            this.gvl.OptionsView.ShowFooter = true;
            this.gvl.OptionsView.ShowGroupPanel = false;
            // 
            // splitterControl3
            // 
            this.splitterControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl3.Location = new System.Drawing.Point(0, 112);
            this.splitterControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.Size = new System.Drawing.Size(891, 5);
            this.splitterControl3.TabIndex = 8;
            this.splitterControl3.TabStop = false;
            // 
            // qry
            // 
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 31);
            this.qry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(891, 81);
            this.qry.TabIndex = 9;
            this.qry.Text = "查询";
            // 
            // gcf
            // 
            this.gcf.Controls.Add(this.gdf);
            this.gcf.Controls.Add(this.memoEdit1);
            this.gcf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcf.Location = new System.Drawing.Point(285, 117);
            this.gcf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcf.Name = "gcf";
            this.gcf.Size = new System.Drawing.Size(321, 360);
            this.gcf.TabIndex = 10;
            this.gcf.Text = "设计";
            this.gcf.DoubleClick += new System.EventHandler(this.gcf_DoubleClick);
            // 
            // gdf
            // 
            this.gdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdf.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdf.Location = new System.Drawing.Point(2, 21);
            this.gdf.MainView = this.gvf;
            this.gdf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdf.Name = "gdf";
            this.gdf.Size = new System.Drawing.Size(317, 337);
            this.gdf.TabIndex = 0;
            this.gdf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvf});
            // 
            // gvf
            // 
            this.gvf.GridControl = this.gdf;
            this.gvf.Name = "gvf";
            this.gvf.OptionsSelection.MultiSelect = true;
            this.gvf.OptionsView.ShowFooter = true;
            this.gvf.OptionsView.ShowGroupPanel = false;
            this.gvf.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvf_CellValueChanged);
            this.gvf.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gv_MouseDown);
            this.gvf.DoubleClick += new System.EventHandler(this.gvf_DoubleClick);
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.Location = new System.Drawing.Point(2, 21);
            this.memoEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(317, 337);
            this.memoEdit1.TabIndex = 1;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gdr);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupControl1.Location = new System.Drawing.Point(611, 117);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(280, 360);
            this.groupControl1.TabIndex = 11;
            this.groupControl1.Text = "常用";
            // 
            // gdr
            // 
            this.gdr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdr.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdr.Location = new System.Drawing.Point(2, 21);
            this.gdr.MainView = this.gvr;
            this.gdr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdr.Name = "gdr";
            this.gdr.Size = new System.Drawing.Size(276, 337);
            this.gdr.TabIndex = 1;
            this.gdr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvr});
            // 
            // gvr
            // 
            this.gvr.GridControl = this.gdr;
            this.gvr.Name = "gvr";
            this.gvr.OptionsSelection.MultiSelect = true;
            this.gvr.OptionsView.ShowFooter = true;
            this.gvr.OptionsView.ShowGroupPanel = false;
            this.gvr.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gvr_MouseDown);
            this.gvr.DoubleClick += new System.EventHandler(this.gvr_DoubleClick);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl1.Location = new System.Drawing.Point(606, 117);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 360);
            this.splitterControl1.TabIndex = 12;
            this.splitterControl1.TabStop = false;
            // 
            // SystemDataBase
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 504);
            this.Controls.Add(this.gcf);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.gcl);
            this.Controls.Add(this.splitterControl3);
            this.Controls.Add(this.qry);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SystemDataBase";
            this.QueryControl = this.qry;
            this.Text = "SystemDataBase";
            this.Shown += new System.EventHandler(this.SystemDataBase_Shown);
            this.Controls.SetChildIndex(this.qry, 0);
            this.Controls.SetChildIndex(this.splitterControl3, 0);
            this.Controls.SetChildIndex(this.gcl, 0);
            this.Controls.SetChildIndex(this.splitterControl2, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.gcf, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).EndInit();
            this.gcl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).EndInit();
            this.gcf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private Base.Layout layout1;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.GroupControl gcl;
        private DevExpress.XtraGrid.GridControl gdl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvl;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraEditors.GroupControl gcf;
        private DevExpress.XtraGrid.GridControl gdf;
        private DevExpress.XtraGrid.Views.Grid.GridView gvf;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gdr;
        private DevExpress.XtraGrid.Views.Grid.GridView gvr;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
    }
}