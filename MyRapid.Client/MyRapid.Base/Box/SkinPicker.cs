/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraBars.Helpers;
using DevExpress.XtraBars.Ribbon;
using MyRapid.Code;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyRapid.Base
{
    public partial class SkinPicker : DevExpress.XtraEditors.XtraForm
    {
        public SkinPicker()
        {

            InitializeComponent();
            CancelButton = new BarItemEx(barCancel, DialogResult.Cancel);
            //效果不好  当焦点在接受Enter的控件上无效
            AcceptButton = new BarItemEx(barOk, DialogResult.OK);
            SkinHelper.InitSkinGallery(sg, false, false, false);
        }
        public GalleryItem ReturnItem;
        private void SkinPicker_FormClosing(object sender, FormClosingEventArgs e)
        {

            //ReturnItem = sg.Gallery.GetCheckedItem();
        }
        private void sg_Gallery_ItemDoubleClick(object sender, GalleryItemClickEventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void sg_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {

            //sg.Gallery.ItemCheckMode = DevExpress.XtraBars.Ribbon.Gallery.ItemCheckMode.SingleCheck
            ReturnItem = e.Item;
            e.Item.Checked = true;
        }
        private void barOk_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void barCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}