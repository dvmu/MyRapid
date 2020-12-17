/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.Client
{
    partial class MainUI 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainUI));
            this.MyLeftPanel = new DevExpress.XtraEditors.GroupControl();
            this.MyTree = new DevExpress.XtraTreeList.TreeList();
            this._Menu_Nick = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.myBar = new DevExpress.XtraBars.BarManager(this.components);
            this.MyQuickMenu = new DevExpress.XtraBars.Bar();
            this.barMenu = new DevExpress.XtraBars.BarButtonItem();
            this.barSkin = new DevExpress.XtraBars.BarButtonItem();
            this.mySkin = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
            this.barHelp = new DevExpress.XtraBars.BarButtonItem();
            this.MyStatus = new DevExpress.XtraBars.Bar();
            this.barUserNick = new DevExpress.XtraBars.BarButtonItem();
            this.barPageName = new DevExpress.XtraBars.BarButtonItem();
            this.barAuther = new DevExpress.XtraBars.BarButtonItem();
            this.barVersion = new DevExpress.XtraBars.BarButtonItem();
            this.barTip = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barCloseThis = new DevExpress.XtraBars.BarButtonItem();
            this.barCloseOther = new DevExpress.XtraBars.BarButtonItem();
            this.barCloseLeft = new DevExpress.XtraBars.BarButtonItem();
            this.barCloseRight = new DevExpress.XtraBars.BarButtonItem();
            this.barCloseAll = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemPopupGalleryEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPopupGalleryEdit();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.myMdi = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.closeMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.myToast = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            this.myAlert = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.MyLeftPanel)).BeginInit();
            this.MyLeftPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MyTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mySkin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupGalleryEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myMdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myToast)).BeginInit();
            this.SuspendLayout();
            // 
            // MyLeftPanel
            // 
            this.MyLeftPanel.Controls.Add(this.MyTree);
            this.MyLeftPanel.CustomHeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.MyLeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MyLeftPanel.Location = new System.Drawing.Point(0, 31);
            this.MyLeftPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MyLeftPanel.Name = "MyLeftPanel";
            this.MyLeftPanel.Size = new System.Drawing.Size(256, 442);
            this.MyLeftPanel.TabIndex = 4;
            this.MyLeftPanel.DoubleClick += new System.EventHandler(this.MyLeftPanel_DoubleClick);
            // 
            // MyTree
            // 
            this.MyTree.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.MyTree.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this._Menu_Nick});
            this.MyTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyTree.KeyFieldName = "Menu_Id";
            this.MyTree.Location = new System.Drawing.Point(2, 21);
            this.MyTree.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MyTree.Name = "MyTree";
            this.MyTree.OptionsBehavior.Editable = false;
            this.MyTree.OptionsView.ShowColumns = false;
            this.MyTree.OptionsView.ShowHorzLines = false;
            this.MyTree.OptionsView.ShowIndicator = false;
            this.MyTree.OptionsView.ShowVertLines = false;
            this.MyTree.ParentFieldName = "Menu_Parent";
            this.MyTree.Size = new System.Drawing.Size(252, 419);
            this.MyTree.TabIndex = 0;
            this.MyTree.DoubleClick += new System.EventHandler(this.MyTree_DoubleClick);
            // 
            // _Menu_Nick
            // 
            this._Menu_Nick.Caption = "菜单";
            this._Menu_Nick.FieldName = "Menu_Nick";
            this._Menu_Nick.MinWidth = 106;
            this._Menu_Nick.Name = "_Menu_Nick";
            this._Menu_Nick.Visible = true;
            this._Menu_Nick.VisibleIndex = 0;
            this._Menu_Nick.Width = 106;
            // 
            // myBar
            // 
            this.myBar.AllowQuickCustomization = false;
            this.myBar.AllowShowToolbarsPopup = false;
            this.myBar.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.MyQuickMenu,
            this.MyStatus});
            this.myBar.DockControls.Add(this.barDockControlTop);
            this.myBar.DockControls.Add(this.barDockControlBottom);
            this.myBar.DockControls.Add(this.barDockControlLeft);
            this.myBar.DockControls.Add(this.barDockControlRight);
            this.myBar.Form = this;
            this.myBar.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barMenu,
            this.barHelp,
            this.barUserNick,
            this.barPageName,
            this.barAuther,
            this.barVersion,
            this.barTip,
            this.barSkin,
            this.barCloseThis,
            this.barCloseOther,
            this.barCloseLeft,
            this.barCloseRight,
            this.barCloseAll});
            this.myBar.MaxItemId = 18;
            this.myBar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPopupGalleryEdit1});
            this.myBar.StatusBar = this.MyStatus;
            // 
            // MyQuickMenu
            // 
            this.MyQuickMenu.BarName = "Tools";
            this.MyQuickMenu.DockCol = 0;
            this.MyQuickMenu.DockRow = 0;
            this.MyQuickMenu.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.MyQuickMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barMenu),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSkin),
            new DevExpress.XtraBars.LinkPersistInfo(this.barHelp)});
            this.MyQuickMenu.OptionsBar.AllowQuickCustomization = false;
            this.MyQuickMenu.OptionsBar.DisableCustomization = true;
            this.MyQuickMenu.OptionsBar.DrawDragBorder = false;
            this.MyQuickMenu.OptionsBar.UseWholeRow = true;
            this.MyQuickMenu.Text = "Tools";
            // 
            // barMenu
            // 
            this.barMenu.Caption = "菜单";
            this.barMenu.Id = 0;
            this.barMenu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barMenu.ImageOptions.Image")));
            this.barMenu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barMenu.ImageOptions.LargeImage")));
            this.barMenu.Name = "barMenu";
            this.barMenu.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barMenu_ItemClick);
            // 
            // barSkin
            // 
            this.barSkin.ActAsDropDown = true;
            this.barSkin.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barSkin.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barSkin.Caption = "皮肤";
            this.barSkin.DropDownControl = this.mySkin;
            this.barSkin.Id = 11;
            this.barSkin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSkin.ImageOptions.Image")));
            this.barSkin.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSkin.ImageOptions.LargeImage")));
            this.barSkin.Name = "barSkin";
            // 
            // mySkin
            // 
            this.mySkin.Manager = this.myBar;
            this.mySkin.Name = "mySkin";
            // 
            // barHelp
            // 
            this.barHelp.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barHelp.Caption = "帮助文档";
            this.barHelp.Id = 3;
            this.barHelp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barHelp.ImageOptions.Image")));
            this.barHelp.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barHelp.ImageOptions.LargeImage")));
            this.barHelp.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F1);
            this.barHelp.Name = "barHelp";
            this.barHelp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barHelp_ItemClick);
            // 
            // MyStatus
            // 
            this.MyStatus.BarName = "Status bar";
            this.MyStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.MyStatus.DockCol = 0;
            this.MyStatus.DockRow = 0;
            this.MyStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.MyStatus.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barUserNick, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barPageName, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barAuther, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barVersion, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barTip, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.MyStatus.OptionsBar.AllowQuickCustomization = false;
            this.MyStatus.OptionsBar.DisableCustomization = true;
            this.MyStatus.OptionsBar.DrawDragBorder = false;
            this.MyStatus.OptionsBar.UseWholeRow = true;
            this.MyStatus.Text = "Status bar";
            // 
            // barUserNick
            // 
            this.barUserNick.Caption = "Admin";
            this.barUserNick.Id = 4;
            this.barUserNick.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barUserNick.ImageOptions.Image")));
            this.barUserNick.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barUserNick.ImageOptions.LargeImage")));
            this.barUserNick.Name = "barUserNick";
            // 
            // barPageName
            // 
            this.barPageName.Caption = "CBest";
            this.barPageName.Id = 5;
            this.barPageName.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barPageName.ImageOptions.Image")));
            this.barPageName.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barPageName.ImageOptions.LargeImage")));
            this.barPageName.Name = "barPageName";
            // 
            // barAuther
            // 
            this.barAuther.Caption = "Auther";
            this.barAuther.Id = 6;
            this.barAuther.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barAuther.ImageOptions.Image")));
            this.barAuther.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barAuther.ImageOptions.LargeImage")));
            this.barAuther.Name = "barAuther";
            // 
            // barVersion
            // 
            this.barVersion.Caption = "Version";
            this.barVersion.Id = 7;
            this.barVersion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barVersion.ImageOptions.Image")));
            this.barVersion.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barVersion.ImageOptions.LargeImage")));
            this.barVersion.Name = "barVersion";
            // 
            // barTip
            // 
            this.barTip.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barTip.Caption = "12:00";
            this.barTip.Id = 9;
            this.barTip.Name = "barTip";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.myBar;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(691, 31);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 473);
            this.barDockControlBottom.Manager = this.myBar;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(691, 27);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 31);
            this.barDockControlLeft.Manager = this.myBar;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 442);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(691, 31);
            this.barDockControlRight.Manager = this.myBar;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 442);
            // 
            // barCloseThis
            // 
            this.barCloseThis.Caption = "关闭当前";
            this.barCloseThis.Id = 12;
            this.barCloseThis.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCloseThis.ImageOptions.Image")));
            this.barCloseThis.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barCloseThis.ImageOptions.LargeImage")));
            this.barCloseThis.Name = "barCloseThis";
            this.barCloseThis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCloseThis_ItemClick);
            // 
            // barCloseOther
            // 
            this.barCloseOther.Caption = "关闭其他";
            this.barCloseOther.Id = 13;
            this.barCloseOther.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCloseOther.ImageOptions.Image")));
            this.barCloseOther.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barCloseOther.ImageOptions.LargeImage")));
            this.barCloseOther.Name = "barCloseOther";
            this.barCloseOther.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCloseOther_ItemClick);
            // 
            // barCloseLeft
            // 
            this.barCloseLeft.Caption = "关闭左侧";
            this.barCloseLeft.Id = 14;
            this.barCloseLeft.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCloseLeft.ImageOptions.Image")));
            this.barCloseLeft.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barCloseLeft.ImageOptions.LargeImage")));
            this.barCloseLeft.Name = "barCloseLeft";
            this.barCloseLeft.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCloseLeft_ItemClick);
            // 
            // barCloseRight
            // 
            this.barCloseRight.Caption = "关闭右侧";
            this.barCloseRight.Id = 15;
            this.barCloseRight.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCloseRight.ImageOptions.Image")));
            this.barCloseRight.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barCloseRight.ImageOptions.LargeImage")));
            this.barCloseRight.Name = "barCloseRight";
            this.barCloseRight.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCloseRight_ItemClick);
            // 
            // barCloseAll
            // 
            this.barCloseAll.Caption = "关闭全部";
            this.barCloseAll.Id = 16;
            this.barCloseAll.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barCloseAll.ImageOptions.Image")));
            this.barCloseAll.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barCloseAll.ImageOptions.LargeImage")));
            this.barCloseAll.Name = "barCloseAll";
            this.barCloseAll.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barCloseAll_ItemClick);
            // 
            // repositoryItemPopupGalleryEdit1
            // 
            this.repositoryItemPopupGalleryEdit1.AutoHeight = false;
            this.repositoryItemPopupGalleryEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemPopupGalleryEdit1.Name = "repositoryItemPopupGalleryEdit1";
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(256, 31);
            this.splitterControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 442);
            this.splitterControl1.TabIndex = 11;
            this.splitterControl1.TabStop = false;
            // 
            // myMdi
            // 
            this.myMdi.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPagesAndTabControlHeader;
            this.myMdi.FloatOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.myMdi.FloatOnDrag = DevExpress.Utils.DefaultBoolean.True;
            this.myMdi.MdiParent = this;
            this.myMdi.SelectedPageChanged += new System.EventHandler(this.MyMdi_SelectedPageChanged);
            this.myMdi.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MyMdi_MouseUp);
            // 
            // closeMenu
            // 
            this.closeMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCloseThis),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCloseOther),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCloseLeft),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCloseRight),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCloseAll)});
            this.closeMenu.Manager = this.myBar;
            this.closeMenu.Name = "closeMenu";
            // 
            // myToast
            // 
            this.myToast.ApplicationId = "100df395-5cd2-4825-bef4-5a7111541e6c";
            this.myToast.ApplicationName = "MyRapid.Client";
            this.myToast.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.True;
            // 
            // MainUI
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 500);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.MyLeftPanel);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "MainUI";
            this.Activated += new System.EventHandler(this.MainUI_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUI_FormClosing);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.Shown += new System.EventHandler(this.MainUI_Shown);
            this.Controls.SetChildIndex(this.barDockControlTop, 0);
            this.Controls.SetChildIndex(this.barDockControlBottom, 0);
            this.Controls.SetChildIndex(this.barDockControlRight, 0);
            this.Controls.SetChildIndex(this.barDockControlLeft, 0);
            this.Controls.SetChildIndex(this.MyLeftPanel, 0);
            this.Controls.SetChildIndex(this.splitterControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.MyLeftPanel)).EndInit();
            this.MyLeftPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MyTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mySkin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPopupGalleryEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myMdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closeMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myToast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion
        private DevExpress.XtraEditors.GroupControl MyLeftPanel;
        private DevExpress.XtraTreeList.TreeList MyTree;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraBars.BarManager myBar;
        private DevExpress.XtraBars.Bar MyQuickMenu;
        private DevExpress.XtraBars.Bar MyStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barMenu;
        private DevExpress.XtraBars.BarButtonItem barHelp;
        private DevExpress.XtraBars.BarButtonItem barUserNick;
        private DevExpress.XtraBars.BarButtonItem barPageName;
        private DevExpress.XtraBars.BarButtonItem barAuther;
        private DevExpress.XtraBars.BarButtonItem barVersion;
        private DevExpress.XtraBars.BarButtonItem barTip;
        private DevExpress.XtraTreeList.Columns.TreeListColumn _Menu_Nick;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager myMdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemPopupGalleryEdit repositoryItemPopupGalleryEdit1;
        private DevExpress.XtraBars.BarButtonItem barSkin;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown mySkin;
        private DevExpress.XtraBars.PopupMenu closeMenu;
        private DevExpress.XtraBars.BarButtonItem barCloseThis;
        private DevExpress.XtraBars.BarButtonItem barCloseOther;
        private DevExpress.XtraBars.BarButtonItem barCloseLeft;
        private DevExpress.XtraBars.BarButtonItem barCloseRight;
        private DevExpress.XtraBars.BarButtonItem barCloseAll;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager myToast;
        private DevExpress.XtraBars.Alerter.AlertControl myAlert;
    }
}