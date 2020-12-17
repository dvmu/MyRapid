/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.Utils;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors.Controls;
using Microsoft.CSharp;
using MyRapid.Code;
using MyRapid.Images;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MyRapid.Proxy;
namespace MyRapid.Base
{
    partial class ImagePicker : DevExpress.XtraEditors.XtraForm
    {
        public ImagePicker()
        {

            InitializeComponent();
            CancelButton = new BarItemEx(barCancel, DialogResult.Cancel);
            //效果不好  当焦点在接受Enter的控件上无效
            AcceptButton = new BarItemEx(barOk, DialogResult.OK);
            InitializeGallery();
        }
        public GalleryItem ReturnItem;
        private Assembly smallAsm;
        private string iconPath = Application.StartupPath + @"\tmp\";
        private bool exIcon(string dllPath)
        {

            if (!File.Exists(dllPath)) return false;
            byte[] bytes = File.ReadAllBytes(dllPath);
            smallAsm = Assembly.Load(bytes);
            List<string> MyImages = ImageCollectionUtils.GetImageResourceNames(smallAsm);
            foreach (object s in MyImages)
            {
                ThreadHelper.Start(SaveFile, s);
            }

            return true;
        }
        private void SaveFile(object imgName)
        {

            Image img = ImageCollectionUtils.GetImage(smallAsm, (string)imgName);
            img.Save(iconPath + imgName, ImageFormat.Png);
        }
        private bool imIcon(string iconPath, string dllPath)
        {

            CSharpCodeProvider ccp = new CSharpCodeProvider();
            CompilerParameters OnePara = new CompilerParameters();
            foreach (string file in Directory.GetFiles(iconPath, "*.png"))
            {
                OnePara.EmbeddedResources.Add(file);
            }
            OnePara.GenerateInMemory = false;
            OnePara.OutputAssembly = dllPath;
            CompilerResults cr;
            cr = ccp.CompileAssemblyFromSource(OnePara, "");
            return true;
        }

        private void InitializeGallery()
        {

            Assembly SmallAsm = null;
            IconList ic = new IconList();
            Assembly[] assemblys = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly IconAssembly in assemblys)
            {
                AssemblyName aName = IconAssembly.GetName();
                if (aName.Name == "MyRapid.Images")
                {
                    SmallAsm = IconAssembly;
                    break;
                }
            }
            if (SmallAsm == null) return;
            List<string> MyImages = ImageCollectionUtils.GetImageResourceNames(SmallAsm);
            int IconSize = radioGroup1.EditValue.ToIntEx();
            CheckedListBoxItem sel = new CheckedListBoxItem();
            sel.Description = "SelectAll";
            sel.Value = "SelectAll";
            sel.CheckState = CheckState.Checked;
            checkedListBoxControl1.Items.Add(sel);
            galleryControl1.Gallery.BeginUpdate();
            Dictionary<string, int> dir = new Dictionary<string, int>();
            foreach (string s in MyImages)
            {
                if (s.IndexOf("_") < 0) return;
                string h = s.Substring(0, s.IndexOf("_"));
                h = h.Substring(0, 1).ToUpper() + h.Remove(0, 1);
                if (dir.Keys.Contains(h))
                {
                    dir[h] += 1;
                }
                else
                {
                    dir.Add(h, 1);
                }
            }
            foreach (string s in MyImages)
            {
                if (s.IndexOf("_") < 0) return;
                GalleryItemGroup eg = null;
                string h = s.Substring(0, s.IndexOf("_"));
                h = h.Substring(0, 1).ToUpper() + h.Remove(0, 1);
                if (dir[h].Equals(2))
                {
                    h = "UnGroup";
                }
                else if (dir[h].Equals(4))
                {
                    h = "SmallGroup";
                }
                foreach (GalleryItemGroup gig in galleryControl1.Gallery.Groups)
                {
                    if (gig.Caption.ToLower().Equals(h.ToLower()))
                    {
                        eg = gig;
                        break;
                    }
                }
                if (eg == null)
                {
                    eg = new GalleryItemGroup();
                    eg.Caption = h;
                    galleryControl1.Gallery.Groups.Add(eg);
                    CheckedListBoxItem chk = new CheckedListBoxItem();
                    chk.Description = h;
                    chk.Value = h;
                    chk.CheckState = CheckState.Checked;
                    checkedListBoxControl1.Items.Add(chk);
                }
                GalleryItem item = new GalleryItem();
                item.Image = ImageCollectionUtils.GetImage(SmallAsm, s);
                //item.Visible = false;
                if (s.EndsWith("16x16.png"))
                {
                    item.Tag = 16;
                    if (IconSize.Equals(16))
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }
                else if (s.EndsWith("32x32.png"))
                {
                    item.Tag = 32;
                    if (IconSize.Equals(32))
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = false;
                    }
                }
                item.Caption = s.Replace("_32x32.png", "").Replace("_16x16.png", "");
                item.Hint = item.Caption;
                eg.Items.Add(item);
            }
            galleryControl1.Gallery.EndUpdate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            //InitializeGallery();
        }
        bool flag = false;
        private void checkedListBoxControl1_ItemCheck(object sender, DevExpress.XtraEditors.Controls.ItemCheckEventArgs e)
        {

            if (flag) return;
            string eg = checkedListBoxControl1.Items[e.Index].Value.ToString();
            if (eg.Equals("SelectAll"))
            {
                flag = true;
                checkedListBoxControl1.BeginUpdate();
                foreach (CheckedListBoxItem chk in checkedListBoxControl1.Items)
                {
                    if (!chk.Value.ToString().Equals("SelectAll"))
                    {
                        chk.CheckState = checkedListBoxControl1.Items[e.Index].CheckState;
                    }
                }
                flag = false;
                checkedListBoxControl1.EndUpdate();
                galleryControl1.Gallery.BeginUpdate();
                foreach (GalleryItemGroup gig in galleryControl1.Gallery.Groups)
                {
                    gig.Visible = (checkedListBoxControl1.Items[e.Index].CheckState.Equals(CheckState.Checked));
                }
                galleryControl1.Gallery.EndUpdate();
                return;
            }
            foreach (GalleryItemGroup gig in galleryControl1.Gallery.Groups)
            {
                if (gig.Caption.Equals(eg))
                {
                    galleryControl1.Gallery.BeginUpdate();
                    gig.Visible = (checkedListBoxControl1.Items[e.Index].CheckState.Equals(CheckState.Checked));
                    galleryControl1.Gallery.EndUpdate();
                    break;
                }
            }

        }
        private void radioGroup1_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                galleryControl1.Gallery.BeginUpdate();
                foreach (GalleryItem gi in galleryControl1.Gallery.GetAllItems())
                {
                    if (gi.Tag == null)
                    {
                        string t = gi.Caption;
                    }
                    if (gi.Tag != null && gi.Tag.ToString().Equals(radioGroup1.EditValue.ToString()) && gi.GalleryGroup.Visible.Equals(true))
                    {
                        gi.Visible = true;
                    }
                    else
                    {
                        gi.Visible = false;
                    }
                }
                galleryControl1.Gallery.EndUpdate();
            }
            catch
            {
                throw;
            }

        }
        private void searchControl1_TextChanged(object sender, EventArgs e)
        {

            galleryControl1.Gallery.BeginUpdate();
            foreach (GalleryItem gi in galleryControl1.Gallery.GetAllItems())
            {
                if (gi.Tag.ToString().Equals(radioGroup1.EditValue.ToString()))
                {
                    if (gi.Caption.Contains(searchControl1.Text))
                    {
                        gi.Visible = true;
                    }
                    else
                    {
                        gi.Visible = false;
                    }
                }
                else
                {
                    gi.Visible = false;
                }
                if (gi.GalleryGroup.HasVisibleItems())
                {
                    gi.GalleryGroup.Visible = true;
                }
                else
                {
                    gi.GalleryGroup.Visible = false;
                }
            }
            galleryControl1.Gallery.EndUpdate();
        }
        private void galleryControl1_DragEnter(object sender, DragEventArgs e)
        {

            //string iconPath = Application.StartupPath + @"\tmp\";
            Array files = (Array)e.Data.GetData(DataFormats.FileDrop);
            if (!Directory.Exists(iconPath))
            {
                Directory.CreateDirectory(iconPath);
            }
            foreach (string file in files)
            {
                if (File.Exists(file))
                {
                    File.Copy(file, iconPath + Path.GetFileName(file), true);
                }
                if (Directory.Exists(file))
                {
                    foreach (string f in Directory.GetFiles(file))
                    {
                        File.Copy(f, iconPath + Path.GetFileName(f), true);
                    }
                }
            }
            exIcon(@"MyIcon.dll");
            File.Copy(@"MyIcon.dll", @"MyIcon.bak", true);
            imIcon(iconPath, @"MyIcon.dll");
            //Directory.Delete(tmpDir, true);
        }
        private void checkedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string eg = checkedListBoxControl1.SelectedValue.ToString();
            foreach (GalleryItemGroup gig in galleryControl1.Gallery.Groups)
            {
                if (gig.Caption.Equals(eg))
                {
                    galleryControl1.Gallery.BeginUpdate();
                    if (gig.Visible)
                    {
                        if (gig.HasVisibleItems())
                        {
                            gig.Items[0].MakeVisible();
                        }
                    }
                    galleryControl1.Gallery.EndUpdate();
                    break;
                }
            }
        }
        private void galleryControl1_Gallery_ItemDoubleClick(object sender, GalleryItemClickEventArgs e)
        {

            ReturnItem = e.Item;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void galleryControl1_Gallery_ItemClick(object sender, GalleryItemClickEventArgs e)
        {

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