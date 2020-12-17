/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemPopup
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
            this.qry = new DevExpress.XtraEditors.GroupControl();
            this.gcf = new DevExpress.XtraEditors.GroupControl();
            this.gdf = new DevExpress.XtraGrid.GridControl();
            this.gvf = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).BeginInit();
            this.gcf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvf)).BeginInit();
            this.SuspendLayout();
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 112);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(719, 5);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // qry
            // 
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 31);
            this.qry.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(719, 81);
            this.qry.TabIndex = 5;
            this.qry.Text = "查询";
            // 
            // gcf
            // 
            this.gcf.Controls.Add(this.gdf);
            this.gcf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcf.Location = new System.Drawing.Point(0, 117);
            this.gcf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcf.Name = "gcf";
            this.gcf.Size = new System.Drawing.Size(719, 487);
            this.gcf.TabIndex = 8;
            this.gcf.Text = "信息";
            // 
            // gdf
            // 
            this.gdf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdf.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdf.Location = new System.Drawing.Point(2, 21);
            this.gdf.MainView = this.gvf;
            this.gdf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdf.Name = "gdf";
            this.gdf.Size = new System.Drawing.Size(715, 464);
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
            // 
            // SystemPopup
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 631);
            this.Controls.Add(this.gcf);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.qry);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SystemPopup";
            this.QueryControl = this.qry;
            this.Text = "SystemPopup";
            this.Controls.SetChildIndex(this.qry, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            this.Controls.SetChildIndex(this.gcf, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).EndInit();
            this.gcf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvf)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private Base.Layout layout1;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraEditors.GroupControl gcf;
        private DevExpress.XtraGrid.GridControl gdf;
        private DevExpress.XtraGrid.Views.Grid.GridView gvf;
    }
}