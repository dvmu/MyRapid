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
using MyRapid.Code;
namespace MyRapid.Base
{
    public partial class ButtonLayout : UserControl
    {
        public ButtonLayout()
        {
            InitializeComponent();
        }
        public bool ReadOnly { get; set; }
        public ControlCollection Items
        {
            get
            {
                return this.Controls;
            }
        }
        private void ButtonLayout_ControlAdded(object sender, ControlEventArgs e)
        {
            if (ReadOnly) return;
            if (e.Control.GetType() == typeof(ButtonItem))
            {
                ButtonItem btn = (ButtonItem)e.Control;
                MoveHandle(btn);
                btn.BackColor = this.BackColor;
                btn.FlatAppearance.BorderColor = this.BackColor;
            }
        }
        private void MoveHandle(Control ctrl)
        {
            Point sourcePoint = new Point(0, 0);
            bool isMove = false;
            ctrl.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.Controls.Remove(ctrl);
                    return;
                }
                sourcePoint = e.Location;
                isMove = true;
                ShowBoder(true);
            };
            ctrl.MouseMove += delegate (object sender, MouseEventArgs e)
            {
                int tx = Math.Max(ctrl.Location.X + e.X - sourcePoint.X, 0);
                int ty = Math.Max(ctrl.Location.Y + e.Y - sourcePoint.Y, 0);
                tx = Math.Min(tx, this.Width - ctrl.Width);
                ty = Math.Min(ty, this.Height - ctrl.Height);
                tx = (int)Math.Round(tx / 5.0) * 5;
                ty = (int)Math.Round(ty / 5.0) * 5;
                if (isMove)
                {
                    ctrl.Location = new Point(tx, ty);
                    ctrl.BringToFront();
                }
            };
            ctrl.MouseUp += delegate (object sender, MouseEventArgs e)
            {
                ShowBoder(false);
                isMove = false;
                //对齐到网格
                ctrl.Left = (int)Math.Round(ctrl.Location.X / 5.0) * 5;
                ctrl.Top = (int)Math.Round(ctrl.Location.Y / 5.0) * 5;
            };
        }
        private void ShowBoder(bool flag)
        {
            if (flag)
            {
                foreach (var item in this.Items)
                {
                    if (item.GetType() == typeof(ButtonItem))
                    {
                        ButtonItem btn = (ButtonItem)item;
                        btn.FlatAppearance.BorderColor = ImageHelper.Invert(this.BackColor);
                    }
                }
            }
            else
            {
                foreach (var item in this.Items)
                {
                    if (item.GetType() == typeof(ButtonItem))
                    {
                        ButtonItem btn = (ButtonItem)item;
                        btn.FlatAppearance.BorderColor = btn.BackColor;
                    }
                }
            }
        }
        private void ButtonLayout_BackColorChanged(object sender, EventArgs e)
        {
            foreach (Control item in this.Controls)
            {
                if (item.GetType() == typeof(ButtonItem))
                {
                    ButtonItem btn = (ButtonItem)item;
                    MoveHandle(btn);
                    btn.BackColor = this.BackColor;
                    btn.FlatAppearance.BorderColor = this.BackColor;
                }
            }
        }
    }

}