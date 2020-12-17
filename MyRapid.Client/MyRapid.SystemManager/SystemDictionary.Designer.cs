/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemDictionary
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
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.gdb = new DevExpress.XtraGrid.GridControl();
            this.gvb = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.splitterControl3 = new DevExpress.XtraEditors.SplitterControl();
            this.qry = new DevExpress.XtraEditors.GroupControl();
            this.gdr = new DevExpress.XtraGrid.GridControl();
            this.gvr = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcr = new DevExpress.XtraEditors.GroupControl();
            this.gcb = new DevExpress.XtraEditors.GroupControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.trb = new DevExpress.XtraTreeList.TreeList();
            ((System.ComponentModel.ISupportInitialize)(this.gdb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcr)).BeginInit();
            this.gcr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcb)).BeginInit();
            this.gcb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trb)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitterControl2.Location = new System.Drawing.Point(0, 330);
            this.splitterControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(741, 5);
            this.splitterControl2.TabIndex = 6;
            this.splitterControl2.TabStop = false;
            // 
            // gdb
            // 
            this.gdb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdb.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdb.Location = new System.Drawing.Point(0, 0);
            this.gdb.MainView = this.gvb;
            this.gdb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdb.Name = "gdb";
            this.gdb.Size = new System.Drawing.Size(346, 270);
            this.gdb.TabIndex = 0;
            this.gdb.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvb});
            this.gdb.DataSourceChanged += new System.EventHandler(this.gdb_DataSourceChanged);
            // 
            // gvb
            // 
            this.gvb.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gvb.GridControl = this.gdb;
            this.gvb.Name = "gvb";
            this.gvb.OptionsSelection.MultiSelect = true;
            this.gvb.OptionsView.ShowFooter = true;
            this.gvb.OptionsView.ShowGroupPanel = false;
            this.gvb.DataSourceChanged += new System.EventHandler(this.gvb_DataSourceChanged);
            // 
            // splitterControl3
            // 
            this.splitterControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl3.Location = new System.Drawing.Point(0, 112);
            this.splitterControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl3.Name = "splitterControl3";
            this.splitterControl3.Size = new System.Drawing.Size(741, 5);
            this.splitterControl3.TabIndex = 8;
            this.splitterControl3.TabStop = false;
            // 
            // qry
            // 
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 31);
            this.qry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(741, 81);
            this.qry.TabIndex = 9;
            this.qry.Text = "查询";
            // 
            // gdr
            // 
            this.gdr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdr.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdr.Location = new System.Drawing.Point(2, 21);
            this.gdr.MainView = this.gvr;
            this.gdr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdr.Name = "gdr";
            this.gdr.Size = new System.Drawing.Size(737, 190);
            this.gdr.TabIndex = 0;
            this.gdr.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvr,
            this.gridView1});
            // 
            // gvr
            // 
            this.gvr.GridControl = this.gdr;
            this.gvr.Name = "gvr";
            this.gvr.OptionsSelection.MultiSelect = true;
            this.gvr.OptionsView.ShowFooter = true;
            this.gvr.OptionsView.ShowGroupPanel = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gdr;
            this.gridView1.Name = "gridView1";
            // 
            // gcr
            // 
            this.gcr.Controls.Add(this.gdr);
            this.gcr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcr.Location = new System.Drawing.Point(0, 117);
            this.gcr.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcr.Name = "gcr";
            this.gcr.Size = new System.Drawing.Size(741, 213);
            this.gcr.TabIndex = 5;
            this.gcr.Text = "信息";
            // 
            // gcb
            // 
            this.gcb.Controls.Add(this.splitContainerControl1);
            this.gcb.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gcb.Location = new System.Drawing.Point(0, 335);
            this.gcb.Name = "gcb";
            this.gcb.Size = new System.Drawing.Size(741, 293);
            this.gcb.TabIndex = 10;
            this.gcb.Text = "信息";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.None;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 21);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gdb);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.trb);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(737, 270);
            this.splitContainerControl1.SplitterPosition = 345;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // trb
            // 
            this.trb.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.trb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trb.KeyFieldName = "DictionaryItem_Value";
            this.trb.Location = new System.Drawing.Point(0, 0);
            this.trb.Name = "trb";
            this.trb.ParentFieldName = "DictionaryItem_Parent";
            this.trb.Size = new System.Drawing.Size(386, 270);
            this.trb.TabIndex = 0;
            // 
            // SystemDictionary
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 655);
            this.Controls.Add(this.gcr);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.splitterControl3);
            this.Controls.Add(this.qry);
            this.Controls.Add(this.gcb);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SystemDictionary";
            this.QueryControl = this.qry;
            this.Text = "SystemDictionary";
            this.Controls.SetChildIndex(this.gcb, 0);
            this.Controls.SetChildIndex(this.qry, 0);
            this.Controls.SetChildIndex(this.splitterControl3, 0);
            this.Controls.SetChildIndex(this.splitterControl2, 0);
            this.Controls.SetChildIndex(this.gcr, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gdb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcr)).EndInit();
            this.gcr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcb)).EndInit();
            this.gcb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraGrid.GridControl gdb;
        private DevExpress.XtraGrid.Views.Grid.GridView gvb;
        private DevExpress.XtraEditors.SplitterControl splitterControl3;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraGrid.GridControl gdr;
        private DevExpress.XtraGrid.Views.Grid.GridView gvr;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl gcr;
        private DevExpress.XtraEditors.GroupControl gcb;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTreeList.TreeList trb;
    }
}