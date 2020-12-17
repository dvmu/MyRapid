/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.Base
{
    partial class ChildPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChildPage));
            this.BaseBar = new DevExpress.XtraBars.BarManager(this.components);
            this.BaseTool = new DevExpress.XtraBars.Bar();
            this.BaseStatus = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.BaseBar)).BeginInit();
            this.SuspendLayout();
            // 
            // BaseBar
            // 
            this.BaseBar.AllowQuickCustomization = false;
            this.BaseBar.AllowShowToolbarsPopup = false;
            this.BaseBar.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.BaseTool,
            this.BaseStatus});
            this.BaseBar.DockControls.Add(this.barDockControlTop);
            this.BaseBar.DockControls.Add(this.barDockControlBottom);
            this.BaseBar.DockControls.Add(this.barDockControlLeft);
            this.BaseBar.DockControls.Add(this.barDockControlRight);
            this.BaseBar.Form = this;
            this.BaseBar.MaxItemId = 6;
            this.BaseBar.OptionsLayout.AllowAddNewItems = false;
            this.BaseBar.OptionsLayout.AllowRemoveOldItems = true;
            this.BaseBar.StatusBar = this.BaseStatus;
            // 
            // BaseTool
            // 
            this.BaseTool.BarName = "Tools";
            this.BaseTool.DockCol = 0;
            this.BaseTool.DockRow = 0;
            this.BaseTool.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.BaseTool.OptionsBar.AllowQuickCustomization = false;
            this.BaseTool.OptionsBar.DisableCustomization = true;
            this.BaseTool.OptionsBar.DrawDragBorder = false;
            this.BaseTool.OptionsBar.UseWholeRow = true;
            this.BaseTool.Text = "Tools";
            // 
            // BaseStatus
            // 
            this.BaseStatus.BarName = "Status bar";
            this.BaseStatus.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.BaseStatus.DockCol = 0;
            this.BaseStatus.DockRow = 0;
            this.BaseStatus.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.BaseStatus.OptionsBar.AllowQuickCustomization = false;
            this.BaseStatus.OptionsBar.DrawDragBorder = false;
            this.BaseStatus.OptionsBar.UseWholeRow = true;
            this.BaseStatus.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.BaseBar;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(669, 29);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 490);
            this.barDockControlBottom.Manager = this.BaseBar;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(669, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 29);
            this.barDockControlLeft.Manager = this.BaseBar;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 461);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(669, 29);
            this.barDockControlRight.Manager = this.BaseBar;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 461);
            // 
            // ChildPage
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 513);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChildPage";
            this.Shown += new System.EventHandler(this.ChildMenu_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.BaseBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            
        }
        #endregion
        private DevExpress.XtraBars.BarManager BaseBar;
        private DevExpress.XtraBars.Bar BaseTool;
        private DevExpress.XtraBars.Bar BaseStatus;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
    }
}