/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.Base
{
    partial class MainPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.SmallIconList = new DevExpress.Utils.ImageCollection();
            this.LargeIconList = new DevExpress.Utils.ImageCollection();
            ((System.ComponentModel.ISupportInitialize)(this.SmallIconList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LargeIconList)).BeginInit();
            this.SuspendLayout();
            // 
            // SmallIconList
            // 
            this.SmallIconList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("SmallIconList.ImageStream")));
            this.SmallIconList.Images.SetKeyName(0, "myerp_16x16.png");
            // 
            // LargeIconList
            // 
            this.LargeIconList.ImageSize = new System.Drawing.Size(32, 32);
            this.LargeIconList.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("LargeIconList.ImageStream")));
            this.LargeIconList.Images.SetKeyName(0, "myerp_32x32.png");
            // 
            // MainPage
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 366);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "快速开发";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.SmallIconList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LargeIconList)).EndInit();
            this.ResumeLayout(false);
}
        #endregion
        private DevExpress.Utils.ImageCollection SmallIconList;
        private DevExpress.Utils.ImageCollection LargeIconList;
    }
}