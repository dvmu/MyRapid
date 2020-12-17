/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemHelp
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
            this._Menu_Nick = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.gdl = new DevExpress.XtraGrid.GridControl();
            this.gvl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.qry = new DevExpress.XtraEditors.GroupControl();
            this.gcf = new DevExpress.XtraEditors.GroupControl();
            this.gdf = new DevExpress.XtraRichEdit.RichEditControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).BeginInit();
            this.gcl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).BeginInit();
            this.gcf.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(232, 103);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 285);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // gcl
            // 
            this.gcl.Controls.Add(this.trl);
            this.gcl.Controls.Add(this.gdl);
            this.gcl.Dock = System.Windows.Forms.DockStyle.Left;
            this.gcl.Location = new System.Drawing.Point(0, 103);
            this.gcl.Name = "gcl";
            this.gcl.Size = new System.Drawing.Size(232, 285);
            this.gcl.TabIndex = 5;
            this.gcl.Text = "信息";
            this.gcl.DoubleClick += new System.EventHandler(this.gcl_DoubleClick);
            // 
            // trl
            // 
            this.trl.AllowDrop = true;
            this.trl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.trl.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this._Menu_Nick});
            this.trl.Cursor = System.Windows.Forms.Cursors.Default;
            this.trl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trl.KeyFieldName = "Menu_Id";
            this.trl.Location = new System.Drawing.Point(2, 21);
            this.trl.Name = "trl";
            this.trl.OptionsBehavior.Editable = false;
            this.trl.OptionsDragAndDrop.DragNodesMode = DevExpress.XtraTreeList.DragNodesMode.Single;
            this.trl.OptionsView.ShowColumns = false;
            this.trl.OptionsView.ShowHorzLines = false;
            this.trl.OptionsView.ShowIndicator = false;
            this.trl.OptionsView.ShowVertLines = false;
            this.trl.ParentFieldName = "Menu_Pid";
            this.trl.Size = new System.Drawing.Size(228, 262);
            this.trl.TabIndex = 1;
            // 
            // _Menu_Nick
            // 
            this._Menu_Nick.Caption = "菜单";
            this._Menu_Nick.FieldName = "Menu_Nick";
            this._Menu_Nick.MinWidth = 34;
            this._Menu_Nick.Name = "_Menu_Nick";
            this._Menu_Nick.Visible = true;
            this._Menu_Nick.VisibleIndex = 0;
            // 
            // gdl
            // 
            this.gdl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdl.Location = new System.Drawing.Point(2, 21);
            this.gdl.MainView = this.gvl;
            this.gdl.Name = "gdl";
            this.gdl.Size = new System.Drawing.Size(228, 262);
            this.gdl.TabIndex = 0;
            this.gdl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvl});
            this.gdl.DataSourceChanged += new System.EventHandler(this.gdf_DataSourceChanged);
            // 
            // gvl
            // 
            this.gvl.GridControl = this.gdl;
            this.gvl.Name = "gvl";
            this.gvl.OptionsSelection.MultiSelect = true;
            //this.gvl.OptionsView.ShowBands = false;
            this.gvl.OptionsView.ShowFooter = true;
            this.gvl.OptionsView.ShowGroupPanel = false;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Location = new System.Drawing.Point(0, 98);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(580, 5);
            this.splitterControl2.TabIndex = 6;
            this.splitterControl2.TabStop = false;
            // 
            // qry
            // 
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 31);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(580, 67);
            this.qry.TabIndex = 7;
            this.qry.Text = "查询";
            // 
            // gcf
            // 
            this.gcf.Controls.Add(this.gdf);
            this.gcf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcf.Location = new System.Drawing.Point(237, 103);
            this.gcf.Name = "gcf";
            this.gcf.Size = new System.Drawing.Size(343, 285);
            this.gcf.TabIndex = 8;
            this.gcf.Text = "信息";
            // 
            // gdf
            // 
            this.gdf.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.gdf.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdf.Location = new System.Drawing.Point(2, 21);
            this.gdf.Name = "gdf";
            this.gdf.Size = new System.Drawing.Size(339, 262);
            this.gdf.TabIndex = 0;
            // 
            // SystemHelp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 415);
            this.Controls.Add(this.gcf);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.gcl);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.qry);
            this.Name = "SystemHelp";
            this.QueryControl = this.qry;
            this.Text = "SystemHelp";
            this.Controls.SetChildIndex(this.qry, 0);
            this.Controls.SetChildIndex(this.splitterControl2, 0);
            this.Controls.SetChildIndex(this.gcl, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.gcf, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).EndInit();
            this.gcl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).EndInit();
            this.gcf.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private Base.Layout layout1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl gcl;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraEditors.GroupControl gcf;
        private DevExpress.XtraGrid.GridControl gdl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvl;
        private DevExpress.XtraTreeList.TreeList trl;
        private DevExpress.XtraTreeList.Columns.TreeListColumn _Menu_Nick;
        private DevExpress.XtraRichEdit.RichEditControl gdf;
    }
}