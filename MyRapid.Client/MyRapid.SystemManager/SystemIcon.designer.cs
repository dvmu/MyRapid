/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemIcon
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
            this.qry = new DevExpress.XtraEditors.GroupControl();
            this.gc = new DevExpress.XtraEditors.GroupControl();
            this.gd = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gd_pagi = new MyRapid.Base.Pagination();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            this.gc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 111);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(893, 5);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // qry
            // 
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 31);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(893, 80);
            this.qry.TabIndex = 5;
            this.qry.Text = "查询";
            // 
            // gc
            // 
            this.gc.Controls.Add(this.gd);
            this.gc.Controls.Add(this.gd_pagi);
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 116);
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(893, 540);
            this.gc.TabIndex = 6;
            this.gc.Text = "信息";
            // 
            // gd
            // 
            this.gd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gd.Location = new System.Drawing.Point(2, 21);
            this.gd.MainView = this.gridView1;
            this.gd.Name = "gd";
            this.gd.Size = new System.Drawing.Size(889, 490);
            this.gd.TabIndex = 0;
            this.gd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gd;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gd_pagi
            // 
            this.gd_pagi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gd_pagi.Location = new System.Drawing.Point(2, 511);
            this.gd_pagi.Name = "gd_pagi";
            this.gd_pagi.PageAlign = DevExpress.XtraEditors.Alignment.Default;
            this.gd_pagi.PageCount = 1;
            this.gd_pagi.PageIndex = 1;
            this.gd_pagi.PageOption = new int[] {
        50,
        100,
        200,
        500,
        1000,
        2000,
        5000,
        10000,
        20000,
        50000,
        100000,
        200000};
            this.gd_pagi.PageRecord = 1;
            this.gd_pagi.PageSize = 50;
            this.gd_pagi.PageText = "";
            this.gd_pagi.Size = new System.Drawing.Size(889, 27);
            this.gd_pagi.TabIndex = 1;
            // 
            // SystemIcon
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 683);
            this.Controls.Add(this.gc);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.qry);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SystemIcon";
            this.QueryControl = this.qry;
            this.Text = "SystemIcon";
            this.Controls.SetChildIndex(this.qry, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.gc, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            this.gc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private Base.Layout layout1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraEditors.GroupControl gc;
        private DevExpress.XtraGrid.GridControl gd;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Base.Pagination gd_pagi;
    }
}