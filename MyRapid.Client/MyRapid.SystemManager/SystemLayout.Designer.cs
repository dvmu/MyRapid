/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.SystemManager
{
    partial class SystemLayout
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
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions1 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemLayout));
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions2 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions3 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions4 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions5 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions6 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions7 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions8 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions9 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions10 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions11 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions12 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions13 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions14 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions buttonImageOptions15 = new DevExpress.XtraEditors.ButtonsPanelControl.ButtonImageOptions();
            this.layout1 = new MyRapid.Base.Layout(this.components);
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.gcb = new DevExpress.XtraEditors.GroupControl();
            this.gdb = new DevExpress.XtraGrid.GridControl();
            this.gvb = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qry = new DevExpress.XtraEditors.GroupControl();
            this.cMenu_Id = new DevExpress.XtraEditors.LookUpEdit();
            this.gcf = new DevExpress.XtraEditors.GroupControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.splitterControl5 = new DevExpress.XtraEditors.SplitterControl();
            ((System.ComponentModel.ISupportInitialize)(this.gcb)).BeginInit();
            this.gcb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            this.qry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cMenu_Id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterControl2.Location = new System.Drawing.Point(488, 21);
            this.splitterControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(10, 512);
            this.splitterControl2.TabIndex = 6;
            this.splitterControl2.TabStop = false;
            // 
            // gcb
            // 
            this.gcb.Controls.Add(this.gdb);
            this.gcb.Dock = System.Windows.Forms.DockStyle.Right;
            this.gcb.Location = new System.Drawing.Point(498, 21);
            this.gcb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcb.Name = "gcb";
            this.gcb.Size = new System.Drawing.Size(500, 512);
            this.gcb.TabIndex = 7;
            this.gcb.Text = "信息";
            // 
            // gdb
            // 
            this.gdb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdb.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdb.Location = new System.Drawing.Point(2, 23);
            this.gdb.MainView = this.gvb;
            this.gdb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gdb.Name = "gdb";
            this.gdb.Size = new System.Drawing.Size(496, 487);
            this.gdb.TabIndex = 0;
            this.gdb.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvb});
            // 
            // gvb
            // 
            this.gvb.GridControl = this.gdb;
            this.gvb.Name = "gvb";
            this.gvb.OptionsSelection.MultiSelect = true;
            this.gvb.OptionsView.ShowFooter = true;
            this.gvb.OptionsView.ShowGroupPanel = false;
            // 
            // qry
            // 
            this.qry.Controls.Add(this.cMenu_Id);
            this.qry.Dock = System.Windows.Forms.DockStyle.Top;
            this.qry.Location = new System.Drawing.Point(0, 0);
            this.qry.Name = "qry";
            this.qry.Size = new System.Drawing.Size(488, 80);
            this.qry.TabIndex = 0;
            this.qry.Text = "布局页面";
            // 
            // cMenu_Id
            // 
            this.cMenu_Id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cMenu_Id.Location = new System.Drawing.Point(2, 23);
            this.cMenu_Id.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cMenu_Id.Name = "cMenu_Id";
            this.cMenu_Id.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cMenu_Id.Properties.NullText = "";
            this.cMenu_Id.Size = new System.Drawing.Size(484, 20);
            this.cMenu_Id.TabIndex = 0;
            // 
            // gcf
            // 
            buttonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions1.Image")));
            buttonImageOptions2.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions2.Image")));
            buttonImageOptions3.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions3.Image")));
            buttonImageOptions4.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions4.Image")));
            buttonImageOptions5.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions5.Image")));
            buttonImageOptions6.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions6.Image")));
            buttonImageOptions7.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions7.Image")));
            buttonImageOptions8.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions8.Image")));
            buttonImageOptions9.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions9.Image")));
            buttonImageOptions10.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions10.Image")));
            buttonImageOptions11.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions11.Image")));
            buttonImageOptions12.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions12.Image")));
            buttonImageOptions13.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions13.Image")));
            buttonImageOptions14.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions14.Image")));
            buttonImageOptions15.Image = ((System.Drawing.Image)(resources.GetObject("buttonImageOptions15.Image")));
            this.gcf.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("tf", false, buttonImageOptions1, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("tbf", false, buttonImageOptions2, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("ttf", false, buttonImageOptions3, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("tlf", false, buttonImageOptions4, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("trf", false, buttonImageOptions5, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("tlrf", false, buttonImageOptions6, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("tllf", false, buttonImageOptions7, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("trrf", false, buttonImageOptions8, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("tblf", false, buttonImageOptions9, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("tbrf", false, buttonImageOptions10, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("tltf", false, buttonImageOptions11, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("tlfb", false, buttonImageOptions12, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("trfb", false, buttonImageOptions13, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("trtf", false, buttonImageOptions14, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("prv", false, buttonImageOptions15, DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton, "", -1, true, null, true, false, true, null, -1)});
            this.gcf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcf.Location = new System.Drawing.Point(0, 90);
            this.gcf.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gcf.Name = "gcf";
            this.gcf.Size = new System.Drawing.Size(488, 422);
            this.gcf.TabIndex = 10;
            this.gcf.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.gcf_CustomButtonClick);
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.gcf);
            this.panelControl1.Controls.Add(this.splitterControl5);
            this.panelControl1.Controls.Add(this.qry);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 21);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(488, 512);
            this.panelControl1.TabIndex = 1;
            // 
            // splitterControl5
            // 
            this.splitterControl5.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl5.Location = new System.Drawing.Point(0, 80);
            this.splitterControl5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl5.Name = "splitterControl5";
            this.splitterControl5.Size = new System.Drawing.Size(488, 10);
            this.splitterControl5.TabIndex = 24;
            this.splitterControl5.TabStop = false;
            // 
            // SystemLayout
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 556);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.gcb);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("SystemLayout.IconOptions.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "SystemLayout";
            this.QueryControl = this.qry;
            this.Text = "SystemLayout";
            this.Shown += new System.EventHandler(this.SystemLayout_Shown);
            this.Controls.SetChildIndex(this.gcb, 0);
            this.Controls.SetChildIndex(this.splitterControl2, 0);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.gcb)).EndInit();
            this.gcb.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            this.qry.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cMenu_Id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private Base.Layout layout1;
        private DevExpress.XtraEditors.SplitterControl splitterControl2;
        private DevExpress.XtraEditors.GroupControl gcb;
        private DevExpress.XtraGrid.GridControl gdb;
        private DevExpress.XtraGrid.Views.Grid.GridView gvb;
        private DevExpress.XtraEditors.GroupControl qry;
        private DevExpress.XtraEditors.LookUpEdit cMenu_Id;
        private DevExpress.XtraEditors.GroupControl gcf;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SplitterControl splitterControl5;
    }
}