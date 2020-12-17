/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemConfiguration
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
            this.gd1 = new DevExpress.XtraGrid.GridControl();
            this.gv1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.gc1 = new DevExpress.XtraEditors.GroupControl();
            this.txt1 = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gd2 = new DevExpress.XtraGrid.GridControl();
            this.gv2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            this.gc2 = new DevExpress.XtraEditors.GroupControl();
            this.txt2 = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            this.gd3 = new DevExpress.XtraGrid.GridControl();
            this.gv3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl4 = new DevExpress.XtraEditors.SplitterControl();
            this.gc3 = new DevExpress.XtraEditors.GroupControl();
            this.txt3 = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.gd4 = new DevExpress.XtraGrid.GridControl();
            this.gv4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl5 = new DevExpress.XtraEditors.SplitterControl();
            this.gc4 = new DevExpress.XtraEditors.GroupControl();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).BeginInit();
            this.gc1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt1.Properties)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gd2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc2)).BeginInit();
            this.gc2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt2.Properties)).BeginInit();
            this.xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gd3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc3)).BeginInit();
            this.gc3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt3.Properties)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gd4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc4)).BeginInit();
            this.gc4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 112);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(640, 5);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // qry
            // 
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 31);
            this.qry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(640, 81);
            this.qry.TabIndex = 5;
            this.qry.Text = "查询";
            // 
            // gd1
            // 
            this.gd1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gd1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gd1.Location = new System.Drawing.Point(0, 0);
            this.gd1.MainView = this.gv1;
            this.gd1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gd1.Name = "gd1";
            this.gd1.Size = new System.Drawing.Size(294, 331);
            this.gd1.TabIndex = 0;
            this.gd1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv1});
            // 
            // gv1
            // 
            this.gv1.GridControl = this.gd1;
            this.gv1.Name = "gv1";
            this.gv1.OptionsSelection.MultiSelect = true;
            this.gv1.OptionsView.ShowFooter = true;
            this.gv1.OptionsView.ShowGroupPanel = false;
            this.gv1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_FocusedRowChanged);
            this.gv1.DataSourceChanged += new System.EventHandler(this.gv1_DataSourceChanged);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 117);
            this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(640, 360);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3,
            this.xtraTabPage4});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gd1);
            this.xtraTabPage1.Controls.Add(this.splitterControl2);
            this.xtraTabPage1.Controls.Add(this.gc1);
            this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(634, 331);
            this.xtraTabPage1.Text = "全局";
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl2.Location = new System.Drawing.Point(294, 0);
            this.splitterControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(5, 331);
            this.splitterControl2.TabIndex = 7;
            this.splitterControl2.TabStop = false;
            // 
            // gc1
            // 
            this.gc1.Controls.Add(this.txt1);
            this.gc1.Dock = System.Windows.Forms.DockStyle.Right;
            this.gc1.Location = new System.Drawing.Point(299, 0);
            this.gc1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gc1.Name = "gc1";
            this.gc1.Size = new System.Drawing.Size(335, 331);
            this.gc1.TabIndex = 6;
            this.gc1.Text = "说明";
            // 
            // txt1
            // 
            this.txt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt1.Location = new System.Drawing.Point(2, 21);
            this.txt1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(331, 308);
            this.txt1.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gd2);
            this.xtraTabPage2.Controls.Add(this.splitterControl3);
            this.xtraTabPage2.Controls.Add(this.gc2);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(634, 331);
            this.xtraTabPage2.Text = "查询";
            // 
            // gd2
            // 
            this.gd2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gd2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gd2.Location = new System.Drawing.Point(0, 0);
            this.gd2.MainView = this.gv2;
            this.gd2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gd2.Name = "gd2";
            this.gd2.Size = new System.Drawing.Size(294, 331);
            this.gd2.TabIndex = 1;
            this.gd2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv2});
            // 
            // gv2
            // 
            this.gv2.GridControl = this.gd2;
            this.gv2.Name = "gv2";
            this.gv2.OptionsSelection.MultiSelect = true;
            this.gv2.OptionsView.ShowFooter = true;
            this.gv2.OptionsView.ShowGroupPanel = false;
            this.gv2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_FocusedRowChanged);
            this.gv2.DataSourceChanged += new System.EventHandler(this.gv1_DataSourceChanged);
            // 
            // splitterControl3
            // 
            this.splitterControl3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl3.Location = new System.Drawing.Point(294, 0);
            this.splitterControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.Size = new System.Drawing.Size(5, 331);
            this.splitterControl3.TabIndex = 9;
            this.splitterControl3.TabStop = false;
            // 
            // gc2
            // 
            this.gc2.Controls.Add(this.txt2);
            this.gc2.Dock = System.Windows.Forms.DockStyle.Right;
            this.gc2.Location = new System.Drawing.Point(299, 0);
            this.gc2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gc2.Name = "gc2";
            this.gc2.Size = new System.Drawing.Size(335, 331);
            this.gc2.TabIndex = 8;
            this.gc2.Text = "说明";
            // 
            // txt2
            // 
            this.txt2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt2.Location = new System.Drawing.Point(2, 21);
            this.txt2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(331, 308);
            this.txt2.TabIndex = 0;
            // 
            // xtraTabPage3
            // 
            this.xtraTabPage3.Controls.Add(this.gd3);
            this.xtraTabPage3.Controls.Add(this.splitterControl4);
            this.xtraTabPage3.Controls.Add(this.gc3);
            this.xtraTabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage3.Name = "xtraTabPage3";
            this.xtraTabPage3.Size = new System.Drawing.Size(634, 331);
            this.xtraTabPage3.Text = "表格";
            // 
            // gd3
            // 
            this.gd3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gd3.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gd3.Location = new System.Drawing.Point(0, 0);
            this.gd3.MainView = this.gv3;
            this.gd3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gd3.Name = "gd3";
            this.gd3.Size = new System.Drawing.Size(294, 331);
            this.gd3.TabIndex = 1;
            this.gd3.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv3});
            // 
            // gv3
            // 
            this.gv3.GridControl = this.gd3;
            this.gv3.Name = "gv3";
            this.gv3.OptionsSelection.MultiSelect = true;
            this.gv3.OptionsView.ShowFooter = true;
            this.gv3.OptionsView.ShowGroupPanel = false;
            this.gv3.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_FocusedRowChanged);
            this.gv3.DataSourceChanged += new System.EventHandler(this.gv1_DataSourceChanged);
            // 
            // splitterControl4
            // 
            this.splitterControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl4.Location = new System.Drawing.Point(294, 0);
            this.splitterControl4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl4.Name = "splitterControl4";
            this.splitterControl4.Size = new System.Drawing.Size(5, 331);
            this.splitterControl4.TabIndex = 9;
            this.splitterControl4.TabStop = false;
            // 
            // gc3
            // 
            this.gc3.Controls.Add(this.txt3);
            this.gc3.Dock = System.Windows.Forms.DockStyle.Right;
            this.gc3.Location = new System.Drawing.Point(299, 0);
            this.gc3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gc3.Name = "gc3";
            this.gc3.Size = new System.Drawing.Size(335, 331);
            this.gc3.TabIndex = 8;
            this.gc3.Text = "说明";
            // 
            // txt3
            // 
            this.txt3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt3.Location = new System.Drawing.Point(2, 21);
            this.txt3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt3.Name = "txt3";
            this.txt3.Size = new System.Drawing.Size(331, 308);
            this.txt3.TabIndex = 0;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.gd4);
            this.xtraTabPage4.Controls.Add(this.splitterControl5);
            this.xtraTabPage4.Controls.Add(this.gc4);
            this.xtraTabPage4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(634, 331);
            this.xtraTabPage4.Text = "用户";
            // 
            // gd4
            // 
            this.gd4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gd4.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gd4.Location = new System.Drawing.Point(0, 0);
            this.gd4.MainView = this.gv4;
            this.gd4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gd4.Name = "gd4";
            this.gd4.Size = new System.Drawing.Size(294, 331);
            this.gd4.TabIndex = 2;
            this.gd4.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv4});
            // 
            // gv4
            // 
            this.gv4.GridControl = this.gd4;
            this.gv4.Name = "gv4";
            this.gv4.OptionsSelection.MultiSelect = true;
            this.gv4.OptionsView.ShowFooter = true;
            this.gv4.OptionsView.ShowGroupPanel = false;
            this.gv4.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_FocusedRowChanged);
            this.gv4.DataSourceChanged += new System.EventHandler(this.gv1_DataSourceChanged);
            // 
            // splitterControl5
            // 
            this.splitterControl5.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl5.Location = new System.Drawing.Point(294, 0);
            this.splitterControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl5.Name = "splitterControl5";
            this.splitterControl5.Size = new System.Drawing.Size(5, 331);
            this.splitterControl5.TabIndex = 9;
            this.splitterControl5.TabStop = false;
            // 
            // gc4
            // 
            this.gc4.Controls.Add(this.memoEdit1);
            this.gc4.Dock = System.Windows.Forms.DockStyle.Right;
            this.gc4.Location = new System.Drawing.Point(299, 0);
            this.gc4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gc4.Name = "gc4";
            this.gc4.Size = new System.Drawing.Size(335, 331);
            this.gc4.TabIndex = 8;
            this.gc4.Text = "说明";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.Location = new System.Drawing.Point(2, 21);
            this.memoEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(331, 308);
            this.memoEdit1.TabIndex = 1;
            // 
            // SystemConfiguration
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 504);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.qry);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SystemConfiguration";
            this.QueryControl = this.qry;
            this.Text = "Configuration";
            this.Shown += new System.EventHandler(this.SystemConfiguration_Shown);
            this.Controls.SetChildIndex(this.qry, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gd1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gc1)).EndInit();
            this.gc1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt1.Properties)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gd2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc2)).EndInit();
            this.gc2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt2.Properties)).EndInit();
            this.xtraTabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gd3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc3)).EndInit();
            this.gc3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt3.Properties)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gd4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc4)).EndInit();
            this.gc4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private Base.Layout layout1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraGrid.GridControl gd1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gd2;
        private DevExpress.XtraGrid.Views.Grid.GridView gv2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl gd3;
        private DevExpress.XtraGrid.Views.Grid.GridView gv3;
        private DevExpress.XtraEditors.GroupControl gc1;
        private DevExpress.XtraEditors.MemoEdit txt1;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private DevExpress.XtraEditors.GroupControl gc2;
        private DevExpress.XtraEditors.MemoEdit txt2;
        private DevExpress.XtraEditors.SplitterControl splitterControl4;
        private DevExpress.XtraEditors.GroupControl gc3;
        private DevExpress.XtraEditors.MemoEdit txt3;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraGrid.GridControl gd4;
        private DevExpress.XtraGrid.Views.Grid.GridView gv4;
        private DevExpress.XtraEditors.SplitterControl splitterControl5;
        private DevExpress.XtraEditors.GroupControl gc4;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
    }
}