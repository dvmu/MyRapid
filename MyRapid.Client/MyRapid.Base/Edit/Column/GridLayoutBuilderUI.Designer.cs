/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraEditors;
namespace MyRapid.Base
{
    partial class GridLayoutBuilderUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridLayoutBuilderUI));
            this.txtConn = new DevExpress.XtraEditors.MemoEdit();
            this.gdl = new DevExpress.XtraGrid.GridControl();
            this.gvl = new DevExpress.XtraGrid.Views.Grid.GridView();
            this._Table_Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this._Table_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this._Table_Description = new DevExpress.XtraGrid.Columns.GridColumn();
            this._Create_Time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcl = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.splitterControl2 = new DevExpress.XtraEditors.SplitterControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.gds = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.txtConn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gds.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConn
            // 
            this.txtConn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConn.Location = new System.Drawing.Point(2, 21);
            this.txtConn.Name = "txtConn";
            this.txtConn.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtConn.Size = new System.Drawing.Size(620, 77);
            this.txtConn.TabIndex = 0;
            this.txtConn.EditValueChanged += new System.EventHandler(this.txtConn_EditValueChanged);
            // 
            // gdl
            // 
            this.gdl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdl.Location = new System.Drawing.Point(2, 29);
            this.gdl.MainView = this.gvl;
            this.gdl.Name = "gdl";
            this.gdl.Size = new System.Drawing.Size(620, 257);
            this.gdl.TabIndex = 1;
            this.gdl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvl});
            this.gdl.DoubleClick += new System.EventHandler(this.gdl_DoubleClick);
            // 
            // gvl
            // 
            this.gvl.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this._Table_Id,
            this._Table_Name,
            this._Table_Description,
            this._Create_Time});
            this.gvl.GridControl = this.gdl;
            this.gvl.Name = "gvl";
            this.gvl.OptionsView.ColumnAutoWidth = false;
            this.gvl.OptionsView.ShowGroupPanel = false;
            // 
            // _Table_Id
            // 
            this._Table_Id.Caption = "Table_Id";
            this._Table_Id.FieldName = "Table_Id";
            this._Table_Id.Name = "_Table_Id";
            // 
            // _Table_Name
            // 
            this._Table_Name.Caption = "Table_Name";
            this._Table_Name.FieldName = "Table_Name";
            this._Table_Name.Name = "_Table_Name";
            this._Table_Name.Visible = true;
            this._Table_Name.VisibleIndex = 0;
            this._Table_Name.Width = 180;
            // 
            // _Table_Description
            // 
            this._Table_Description.Caption = "Table_Description";
            this._Table_Description.FieldName = "Table_Description";
            this._Table_Description.Name = "_Table_Description";
            this._Table_Description.Visible = true;
            this._Table_Description.VisibleIndex = 1;
            this._Table_Description.Width = 280;
            // 
            // _Create_Time
            // 
            this._Create_Time.Caption = "Create_Time";
            this._Create_Time.FieldName = "Create_Time";
            this._Create_Time.Name = "_Create_Time";
            this._Create_Time.Visible = true;
            this._Create_Time.VisibleIndex = 2;
            this._Create_Time.Width = 128;
            // 
            // gcl
            // 
            this.gcl.Location = new System.Drawing.Point(0, 0);
            this.gcl.Name = "gcl";
            this.gcl.Size = new System.Drawing.Size(200, 100);
            this.gcl.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtConn);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(624, 100);
            this.groupControl1.TabIndex = 3;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gdl);
            this.groupControl2.CustomHeaderButtons.AddRange(new DevExpress.XtraEditors.ButtonPanel.IBaseButton[] {
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Refresh", ((System.Drawing.Image)(resources.GetObject("groupControl2.CustomHeaderButtons"))), false, true, ""),
            new DevExpress.XtraEditors.ButtonsPanelControl.GroupBoxButton("Submit", ((System.Drawing.Image)(resources.GetObject("groupControl2.CustomHeaderButtons1"))), false, true, "")});
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 167);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(624, 288);
            this.groupControl2.TabIndex = 4;
            this.groupControl2.CustomButtonClick += new DevExpress.XtraBars.Docking2010.BaseButtonEventHandler(this.groupControl2_CustomButtonClick);
            // 
            // splitterControl1
            // 
            this.splitterControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl1.Location = new System.Drawing.Point(0, 100);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(624, 5);
            this.splitterControl1.TabIndex = 6;
            this.splitterControl1.TabStop = false;
            // 
            // splitterControl2
            // 
            this.splitterControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitterControl2.Location = new System.Drawing.Point(0, 162);
            this.splitterControl2.Name = "splitterControl2";
            this.splitterControl2.Size = new System.Drawing.Size(624, 5);
            this.splitterControl2.TabIndex = 8;
            this.splitterControl2.TabStop = false;
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.gds);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(0, 105);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(624, 57);
            this.groupControl3.TabIndex = 7;
            // 
            // gds
            // 
            this.gds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gds.Location = new System.Drawing.Point(2, 21);
            this.gds.Name = "gds";
            this.gds.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gds.Size = new System.Drawing.Size(620, 34);
            this.gds.TabIndex = 0;
            // 
            // GridLayoutBuilderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 455);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.splitterControl2);
            this.Controls.Add(this.groupControl3);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GridLayoutBuilderUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.txtConn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gds.Properties)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private MemoEdit txtConn;
        private DevExpress.XtraGrid.GridControl gdl;
        private DevExpress.XtraGrid.Views.Grid.GridView gvl;
        private DevExpress.XtraGrid.Columns.GridColumn _Table_Id;
        private DevExpress.XtraGrid.Columns.GridColumn _Table_Name;
        private DevExpress.XtraGrid.Columns.GridColumn _Table_Description;
        private DevExpress.XtraGrid.Columns.GridColumn _Create_Time;
        private GroupControl gcl;
        private GroupControl groupControl1;
        private GroupControl groupControl2;
        private SplitterControl splitterControl1;
        private SplitterControl splitterControl2;
        private GroupControl groupControl3;
        private RadioGroup gds;
    }
}