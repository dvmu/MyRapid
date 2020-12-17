/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
namespace MyRapid.Base
{
    partial class DashBoard
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
            this.spreadsheetControl1 = new DevExpress.XtraSpreadsheet.SpreadsheetControl();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // spreadsheetControl1
            // 
            this.spreadsheetControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spreadsheetControl1.Location = new System.Drawing.Point(0, 0);
            this.spreadsheetControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.spreadsheetControl1.Name = "spreadsheetControl1";
            this.spreadsheetControl1.Options.HorizontalScrollbar.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetScrollbarVisibility.Hidden;
            this.spreadsheetControl1.Options.TabSelector.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetElementVisibility.Hidden;
            this.spreadsheetControl1.Options.VerticalScrollbar.Visibility = DevExpress.XtraSpreadsheet.SpreadsheetScrollbarVisibility.Hidden;
            this.spreadsheetControl1.Options.View.ShowColumnHeaders = false;
            this.spreadsheetControl1.Options.View.ShowRowHeaders = false;
            this.spreadsheetControl1.ReadOnly = true;
            this.spreadsheetControl1.Size = new System.Drawing.Size(480, 360);
            this.spreadsheetControl1.TabIndex = 0;
            this.spreadsheetControl1.Text = "spreadsheetControl1";
            this.spreadsheetControl1.Unit = DevExpress.Office.DocumentUnit.Point;
            this.spreadsheetControl1.DoubleClick += new System.EventHandler(this.spreadsheetControl1_DoubleClick);
            this.spreadsheetControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.spreadsheetControl1_KeyDown);
            this.spreadsheetControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.spreadsheetControl1_MouseDown);
            this.spreadsheetControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.spreadsheetControl1_MouseMove);
            this.spreadsheetControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.spreadsheetControl1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // DashBoard
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 360);
            this.Controls.Add(this.spreadsheetControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DashBoard";
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DashBoard_KeyDown);
            this.ResumeLayout(false);
}
        #endregion
        private DevExpress.XtraSpreadsheet.SpreadsheetControl spreadsheetControl1;
        private System.Windows.Forms.Timer timer1;
    }
}