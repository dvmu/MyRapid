/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemSheet
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
            this.qry = new DevExpress.XtraEditors.GroupControl();
            this.gc = new DevExpress.XtraEditors.GroupControl();
            this.gd = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).BeginInit();
            this.gc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 111);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(617, 5);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // qry
            // 
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 31);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(617, 80);
            this.qry.TabIndex = 5;
            this.qry.Text = "查询";
            // 
            // gc
            // 
            this.gc.Controls.Add(this.gd);
            this.gc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gc.Location = new System.Drawing.Point(0, 116);
            this.gc.Name = "gc";
            this.gc.Size = new System.Drawing.Size(617, 240);
            this.gc.TabIndex = 6;
            this.gc.Text = "信息";
            // 
            // gd
            // 
            this.gd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gd.Location = new System.Drawing.Point(2, 21);
            this.gd.MainView = this.gv;
            this.gd.Name = "gd";
            this.gd.Size = new System.Drawing.Size(613, 217);
            this.gd.TabIndex = 0;
            this.gd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.GridControl = this.gd;
            this.gv.Name = "gv";
            this.gv.OptionsSelection.MultiSelect = true;
            this.gv.OptionsView.ColumnAutoWidth = false;
            this.gv.OptionsView.ShowGroupPanel = false;
            // 
            // SystemSheet
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 383);
            this.Controls.Add(this.gc);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.qry);
            this.Name = "SystemSheet";
            this.QueryControl = this.qry;
            this.Text = "SystemDashBoard";
            this.Controls.SetChildIndex(this.qry, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.gc, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gc)).EndInit();
            this.gc.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraEditors.GroupControl gc;
        private DevExpress.XtraGrid.GridControl gd;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
    }
}