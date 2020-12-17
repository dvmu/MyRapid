/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemDocument
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
            this.trl = new DevExpress.XtraTreeList.TreeList();
            this._Document_Nick = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gdl = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcf = new DevExpress.XtraEditors.GroupControl();
            this.gdf = new DevExpress.XtraRichEdit.RichEditControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barCount = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.qry = new DevExpress.XtraEditors.GroupControl();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).BeginInit();
            this.gcl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).BeginInit();
            this.gcf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(167, 117);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 360);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // gcl
            // 
            this.gcl.Controls.Add(this.trl);
            this.gcl.Controls.Add(this.gdl);
            this.gcl.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcl.Location = new System.Drawing.Point(0, 117);
            this.gcl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcl.Name = "gcl";
            this.gcl.Size = new System.Drawing.Size(167, 360);
            this.gcl.TabIndex = 5;
            this.gcl.Text = "目录";
            this.gcl.DoubleClick += new System.EventHandler(this.gcl_DoubleClick);
            // 
            // trl
            // 
            this.trl.AllowDrop = true;
            this.trl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.trl.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this._Document_Nick});
            this.trl.Cursor = System.Windows.Forms.Cursors.Default;
            this.trl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trl.KeyFieldName = "Document_Id";
            this.trl.Location = new System.Drawing.Point(2, 21);
            this.trl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trl.Name = "trl";
            this.trl.OptionsBehavior.Editable = false;
            this.trl.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            this.trl.OptionsView.ShowColumns = false;
            this.trl.OptionsView.ShowHorzLines = false;
            this.trl.OptionsView.ShowIndicator = false;
            this.trl.OptionsView.ShowVertLines = false;
            this.trl.ParentFieldName = "Document_Pid";
            this.trl.Size = new System.Drawing.Size(163, 337);
            this.trl.TabIndex = 2;
            // 
            // _Document_Nick
            // 
            this._Document_Nick.Caption = "文档";
            this._Document_Nick.FieldName = "Document_Nick";
            this._Document_Nick.MinWidth = 34;
            this._Document_Nick.Name = "_Document_Nick";
            this._Document_Nick.Visible = true;
            this._Document_Nick.VisibleIndex = 0;
            // 
            // gdl
            // 
            this.gdl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdl.Location = new System.Drawing.Point(2, 21);
            this.gdl.MainView = this.advBandedGridView1;
            this.gdl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdl.Name = "gdl";
            this.gdl.Size = new System.Drawing.Size(163, 337);
            this.gdl.TabIndex = 0;
            this.gdl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1});
            this.gdl.DataSourceChanged += new System.EventHandler(this.gdl_DataSourceChanged);
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.GridControl = this.gdl;
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.OptionsSelection.MultiSelect = true;
            this.advBandedGridView1.OptionsView.ShowFooter = true;
            this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gcf
            // 
            this.gcf.Controls.Add(this.gdf);
            this.gcf.Controls.Add(this.barDockControl3);
            this.gcf.Controls.Add(this.barDockControl4);
            this.gcf.Controls.Add(this.barDockControl2);
            this.gcf.Controls.Add(this.barDockControl1);
            this.gcf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcf.Location = new System.Drawing.Point(172, 117);
            this.gcf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcf.Name = "gcf";
            this.gcf.Size = new System.Drawing.Size(408, 360);
            this.gcf.TabIndex = 8;
            this.gcf.Text = "内容";
            // 
            // gdf
            // 
            this.gdf.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.gdf.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdf.Location = new System.Drawing.Point(2, 21);
            this.gdf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdf.MenuManager = this.barManager1;
            this.gdf.Name = "gdf";
            this.gdf.Size = new System.Drawing.Size(404, 310);
            this.gdf.TabIndex = 0;
            this.gdf.TextChanged += new System.EventHandler(this.gdf_TextChanged);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControl1);
            this.barManager1.DockControls.Add(this.barDockControl2);
            this.barManager1.DockControls.Add(this.barDockControl3);
            this.barManager1.DockControls.Add(this.barDockControl4);
            this.barManager1.Form = this.gcf;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barCount});
            this.barManager1.MaxItemId = 1;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCount)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barCount
            // 
            this.barCount.Caption = "0";
            this.barCount.Id = 0;
            this.barCount.Name = "barCount";
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(2, 21);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(404, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(2, 331);
            this.barDockControl2.Manager = this.barManager1;
            this.barDockControl2.Size = new System.Drawing.Size(404, 27);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(2, 21);
            this.barDockControl3.Manager = this.barManager1;
            this.barDockControl3.Size = new System.Drawing.Size(0, 310);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(406, 21);
            this.barDockControl4.Manager = this.barManager1;
            this.barDockControl4.Size = new System.Drawing.Size(0, 310);
            // 
            // qry
            // 
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 31);
            this.qry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(580, 81);
            this.qry.TabIndex = 9;
            this.qry.Text = "查询";
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Location = new System.Drawing.Point(0, 112);
            this.splitterControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(580, 5);
            this.splitterControl2.TabIndex = 10;
            this.splitterControl2.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SystemDocument
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 504);
            this.Controls.Add(this.gcf);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gcl);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.qry);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SystemDocument";
            this.QueryControl = this.qry;
            this.Text = "SystemDocument";
            this.Controls.SetChildIndex(this.qry, 0);
            this.Controls.SetChildIndex(this.splitterControl2, 0);
            this.Controls.SetChildIndex(this.gcl, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.gcf, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).EndInit();
            this.gcl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).EndInit();
            this.gcf.ResumeLayout(false);
            this.gcf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private Base.Layout layout1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl gcl;
        private DevExpress.XtraGrid.GridControl gdl;
        private DevExpress.XtraGrid.Views.Grid.GridView advBandedGridView1;
        private DevExpress.XtraEditors.GroupControl gcf;
        private DevExpress.XtraRichEdit.RichEditControl gdf;
        private DevExpress.XtraTreeList.TreeList trl;
        private DevExpress.XtraTreeList.Columns.TreeListColumn _Document_Nick;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem barCount;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
    }
}