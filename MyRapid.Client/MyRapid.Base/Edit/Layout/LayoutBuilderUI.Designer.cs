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
    partial class LayoutBuilderUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutBuilderUI));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_tlbf = new DevExpress.XtraEditors.SimpleButton();
            this.btn_tf = new DevExpress.XtraEditors.SimpleButton();
            this.btn_tlf = new DevExpress.XtraEditors.SimpleButton();
            this.btn_tbf = new DevExpress.XtraEditors.SimpleButton();
            this.btn_tlrf = new DevExpress.XtraEditors.SimpleButton();
            this.btn_tblf = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(0, 0);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            // 
            // btn_tlbf
            // 
            this.btn_tlbf.Image = ((System.Drawing.Image)(resources.GetObject("btn_tlbf.Image")));
            this.btn_tlbf.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_tlbf.Location = new System.Drawing.Point(120, 66);
            this.btn_tlbf.Name = "btn_tlbf";
            this.btn_tlbf.Size = new System.Drawing.Size(48, 48);
            this.btn_tlbf.TabIndex = 24;
            this.btn_tlbf.Click += new System.EventHandler(this.btn_tlbf_Click);
            // 
            // btn_tf
            // 
            this.btn_tf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_tf.Image = ((System.Drawing.Image)(resources.GetObject("btn_tf.Image")));
            this.btn_tf.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_tf.Location = new System.Drawing.Point(12, 12);
            this.btn_tf.Name = "btn_tf";
            this.btn_tf.Size = new System.Drawing.Size(48, 48);
            this.btn_tf.TabIndex = 25;
            this.btn_tf.Click += new System.EventHandler(this.btn_tf_Click);
            // 
            // btn_tlf
            // 
            this.btn_tlf.Image = ((System.Drawing.Image)(resources.GetObject("btn_tlf.Image")));
            this.btn_tlf.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_tlf.Location = new System.Drawing.Point(66, 12);
            this.btn_tlf.Name = "btn_tlf";
            this.btn_tlf.Size = new System.Drawing.Size(48, 48);
            this.btn_tlf.TabIndex = 27;
            this.btn_tlf.Click += new System.EventHandler(this.btn_tlf_Click);
            // 
            // btn_tbf
            // 
            this.btn_tbf.Image = ((System.Drawing.Image)(resources.GetObject("btn_tbf.Image")));
            this.btn_tbf.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_tbf.Location = new System.Drawing.Point(120, 12);
            this.btn_tbf.Name = "btn_tbf";
            this.btn_tbf.Size = new System.Drawing.Size(48, 48);
            this.btn_tbf.TabIndex = 26;
            this.btn_tbf.Click += new System.EventHandler(this.btn_tbf_Click);
            // 
            // btn_tlrf
            // 
            this.btn_tlrf.Image = ((System.Drawing.Image)(resources.GetObject("btn_tlrf.Image")));
            this.btn_tlrf.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_tlrf.Location = new System.Drawing.Point(66, 66);
            this.btn_tlrf.Name = "btn_tlrf";
            this.btn_tlrf.Size = new System.Drawing.Size(48, 48);
            this.btn_tlrf.TabIndex = 29;
            this.btn_tlrf.Click += new System.EventHandler(this.btn_tlrf_Click);
            // 
            // btn_tblf
            // 
            this.btn_tblf.Image = ((System.Drawing.Image)(resources.GetObject("btn_tblf.Image")));
            this.btn_tblf.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btn_tblf.Location = new System.Drawing.Point(12, 66);
            this.btn_tblf.Name = "btn_tblf";
            this.btn_tblf.Size = new System.Drawing.Size(48, 48);
            this.btn_tblf.TabIndex = 28;
            this.btn_tblf.Click += new System.EventHandler(this.btn_tblf_Click);
            // 
            // LayoutBuilderUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 127);
            this.Controls.Add(this.btn_tf);
            this.Controls.Add(this.btn_tlf);
            this.Controls.Add(this.btn_tbf);
            this.Controls.Add(this.btn_tlrf);
            this.Controls.Add(this.btn_tblf);
            this.Controls.Add(this.btn_tlbf);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LayoutBuilderUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
        #endregion
        private SimpleButton simpleButton1;
        internal SimpleButton btn_tlbf;
        internal SimpleButton btn_tf;
        internal SimpleButton btn_tlf;
        internal SimpleButton btn_tbf;
        internal SimpleButton btn_tlrf;
        internal SimpleButton btn_tblf;
    }
}