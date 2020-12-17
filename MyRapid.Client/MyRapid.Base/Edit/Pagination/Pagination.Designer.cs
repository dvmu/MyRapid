/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.Base
{
    partial class Pagination
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region 组件设计器生成的代码
        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pagination));
            this.barManagerPage = new DevExpress.XtraBars.BarManager(this.components);
            this.barPage = new DevExpress.XtraBars.Bar();
            this.btnPageText = new DevExpress.XtraBars.BarButtonItem();
            this.btnPageSize = new DevExpress.XtraBars.BarEditItem();
            this.cbxPageSize = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnPageFirst = new DevExpress.XtraBars.BarButtonItem();
            this.btnPagePrevious = new DevExpress.XtraBars.BarButtonItem();
            this.btnPageIndex = new DevExpress.XtraBars.BarEditItem();
            this.txtPageIndex = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.btnPageCount = new DevExpress.XtraBars.BarButtonItem();
            this.btnPageNext = new DevExpress.XtraBars.BarButtonItem();
            this.btnPageLast = new DevExpress.XtraBars.BarButtonItem();
            this.btnPageRight = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManagerPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxPageSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // barManagerPage
            // 
            this.barManagerPage.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.barPage});
            this.barManagerPage.DockControls.Add(this.barDockControl1);
            this.barManagerPage.DockControls.Add(this.barDockControl2);
            this.barManagerPage.DockControls.Add(this.barDockControl3);
            this.barManagerPage.DockControls.Add(this.barDockControl4);
            this.barManagerPage.Form = this;
            this.barManagerPage.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnPageCount,
            this.btnPageFirst,
            this.btnPagePrevious,
            this.btnPageNext,
            this.btnPageLast,
            this.btnPageSize,
            this.btnPageText,
            this.btnPageIndex,
            this.btnPageRight});
            this.barManagerPage.MaxItemId = 14;
            this.barManagerPage.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.cbxPageSize,
            this.txtPageIndex});
            this.barManagerPage.StatusBar = this.barPage;
            // 
            // barPage
            // 
            this.barPage.BarName = "Status bar";
            this.barPage.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.barPage.DockCol = 0;
            this.barPage.DockRow = 0;
            this.barPage.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.barPage.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPageText),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.btnPageSize, "", false, true, true, 66),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPageFirst),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPagePrevious),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.Width, this.btnPageIndex, "", false, true, true, 69),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPageCount),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPageNext),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPageLast),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPageRight)});
            this.barPage.OptionsBar.AllowQuickCustomization = false;
            this.barPage.OptionsBar.DrawDragBorder = false;
            this.barPage.OptionsBar.UseWholeRow = true;
            this.barPage.Text = "Status bar";
            // 
            // btnPageText
            // 
            this.btnPageText.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPageText.Id = 6;
            this.btnPageText.Name = "btnPageText";
            // 
            // btnPageSize
            // 
            this.btnPageSize.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPageSize.Edit = this.cbxPageSize;
            this.btnPageSize.EditValue = ((short)(50));
            this.btnPageSize.Id = 5;
            this.btnPageSize.Name = "btnPageSize";
            // 
            // cbxPageSize
            // 
            this.cbxPageSize.AutoHeight = false;
            this.cbxPageSize.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbxPageSize.Items.AddRange(new object[] {
            "50",
            "100",
            "300",
            "500",
            "1000",
            "2000",
            "3000",
            "5000"});
            this.cbxPageSize.Name = "cbxPageSize";
            this.cbxPageSize.EditValueChanged += new System.EventHandler(this.cbxPageSize_EditValueChanged);
            // 
            // btnPageFirst
            // 
            this.btnPageFirst.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPageFirst.Id = 1;
            this.btnPageFirst.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPageFirst.ImageOptions.Image")));
            this.btnPageFirst.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPageFirst.ImageOptions.LargeImage")));
            this.btnPageFirst.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Home);
            this.btnPageFirst.Name = "btnPageFirst";
            this.btnPageFirst.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPageFirst_ItemClick);
            // 
            // btnPagePrevious
            // 
            this.btnPagePrevious.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPagePrevious.Id = 2;
            this.btnPagePrevious.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPagePrevious.ImageOptions.Image")));
            this.btnPagePrevious.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPagePrevious.ImageOptions.LargeImage")));
            this.btnPagePrevious.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.PageUp);
            this.btnPagePrevious.Name = "btnPagePrevious";
            this.btnPagePrevious.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPagePrevious_ItemClick);
            // 
            // btnPageIndex
            // 
            this.btnPageIndex.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPageIndex.Edit = this.txtPageIndex;
            this.btnPageIndex.EditValue = 0;
            this.btnPageIndex.Id = 12;
            this.btnPageIndex.Name = "btnPageIndex";
            // 
            // txtPageIndex
            // 
            this.txtPageIndex.AutoHeight = false;
            this.txtPageIndex.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtPageIndex.IsFloatValue = false;
            this.txtPageIndex.Mask.EditMask = "N00";
            this.txtPageIndex.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPageIndex.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtPageIndex.Name = "txtPageIndex";
            this.txtPageIndex.EditValueChanged += new System.EventHandler(this.txtPageIndex_EditValueChanged);
            // 
            // btnPageCount
            // 
            this.btnPageCount.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPageCount.Caption = "/5";
            this.btnPageCount.Id = 0;
            this.btnPageCount.Name = "btnPageCount";
            // 
            // btnPageNext
            // 
            this.btnPageNext.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPageNext.Id = 3;
            this.btnPageNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPageNext.ImageOptions.Image")));
            this.btnPageNext.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPageNext.ImageOptions.LargeImage")));
            this.btnPageNext.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.PageDown);
            this.btnPageNext.Name = "btnPageNext";
            this.btnPageNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPageNext_ItemClick);
            // 
            // btnPageLast
            // 
            this.btnPageLast.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPageLast.Id = 4;
            this.btnPageLast.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPageLast.ImageOptions.Image")));
            this.btnPageLast.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPageLast.ImageOptions.LargeImage")));
            this.btnPageLast.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.End);
            this.btnPageLast.Name = "btnPageLast";
            this.btnPageLast.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPageLast_ItemClick);
            // 
            // btnPageRight
            // 
            this.btnPageRight.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnPageRight.Border = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnPageRight.Id = 13;
            this.btnPageRight.Name = "btnPageRight";
            this.btnPageRight.RightIndent = 24;
            this.btnPageRight.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl1.Location = new System.Drawing.Point(0, 0);
            this.barDockControl1.Manager = this.barManagerPage;
            this.barDockControl1.Size = new System.Drawing.Size(759, 0);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl2.Location = new System.Drawing.Point(0, 0);
            this.barDockControl2.Manager = this.barManagerPage;
            this.barDockControl2.Size = new System.Drawing.Size(759, 27);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl3.Location = new System.Drawing.Point(0, 0);
            this.barDockControl3.Manager = this.barManagerPage;
            this.barDockControl3.Size = new System.Drawing.Size(0, 0);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl4.Location = new System.Drawing.Point(759, 0);
            this.barDockControl4.Manager = this.barManagerPage;
            this.barDockControl4.Size = new System.Drawing.Size(0, 0);
            // 
            // Pagination
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl1);
            this.Name = "Pagination";
            this.Size = new System.Drawing.Size(759, 27);
            this.Resize += new System.EventHandler(this.Pagination_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.barManagerPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxPageSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPageIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private DevExpress.XtraBars.BarManager barManagerPage;
        private DevExpress.XtraBars.Bar barPage;
        private DevExpress.XtraBars.BarButtonItem btnPageText;
        private DevExpress.XtraBars.BarEditItem btnPageSize;
        private DevExpress.XtraBars.BarButtonItem btnPageFirst;
        private DevExpress.XtraBars.BarButtonItem btnPagePrevious;
        private DevExpress.XtraBars.BarButtonItem btnPageCount;
        private DevExpress.XtraBars.BarButtonItem btnPageNext;
        private DevExpress.XtraBars.BarButtonItem btnPageLast;
        private DevExpress.XtraBars.BarEditItem btnPageIndex;
        private DevExpress.XtraBars.BarStaticItem btnPageRight;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox cbxPageSize;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit txtPageIndex;
    }
}