/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyRapid.Base
{
    public class ButtonItem : Button
    {
        public void BaseButtonItem()
        {
            this.BackColor = System.Drawing.Color.White;
            this.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Image = null;
            this.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BackgroundImageLayout = ImageLayout.Zoom;
            this.Location = new System.Drawing.Point(3, 3);
            this.Name = "ButtonItem";
            this.Size = new System.Drawing.Size(80, 80);
            this.TabIndex = 3;
            this.Text = "ButtonItem";
            this.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.UseVisualStyleBackColor = false;
        }
        public ButtonItem()
        {
            BaseButtonItem();
        }
        public ButtonItem(string buttonName)
        {
            BaseButtonItem();
            this.Name = buttonName;
            this.Text = buttonName;
        }
        public ButtonItem(string buttonName, Image buttonImage)
        {
            BaseButtonItem();
            this.Name = buttonName;
            this.Text = buttonName;
            this.Image = buttonImage;
        }
        public ButtonItem(string buttonName, Image buttonImage, Point buttonLocation)
        {
            BaseButtonItem();
            this.Name = buttonName;
            this.Text = buttonName;
            this.Image = buttonImage;
            this.Location = buttonLocation;
        }
        public ButtonItem(string buttonName, Image buttonImage, int buttonLeft, int buttonTop)
        {
            BaseButtonItem();
            this.Name = buttonName;
            this.Text = buttonName;
            this.Image = buttonImage;
            this.Left = buttonLeft;
            this.Top = buttonTop;
        }
        public ButtonItem(string buttonName, Image buttonImage, Image buttonBackgroundImage)
        {
            BaseButtonItem();
            this.Name = buttonName;
            this.Text = buttonName;
            this.Image = buttonImage;
            this.BackgroundImage = buttonBackgroundImage;
        }
        public ButtonItem(string buttonName, Image buttonImage, Image buttonBackgroundImage, Point buttonLocation)
        {
            BaseButtonItem();
            this.Name = buttonName;
            this.Text = buttonName;
            this.Image = buttonImage;
            this.BackgroundImage = buttonBackgroundImage;
            this.Location = buttonLocation;
        }
        public ButtonItem(string buttonName, Image buttonImage, Image buttonBackgroundImage, int buttonLeft, int buttonTop)
        {
            BaseButtonItem();
            this.Name = buttonName;
            this.Text = buttonName;
            this.Image = buttonImage;
            this.BackgroundImage = buttonBackgroundImage;
            this.Left = buttonLeft;
            this.Top = buttonTop;
        }
    }
}