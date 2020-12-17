/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyRapid.Base
{
    public class BarItemEx : IButtonControl
    {
        private BarItem _barItem;
        public BarItemEx(BarItem barItem, DialogResult dialogResult)
        {
            _barItem = barItem;
            this.DialogResult = dialogResult;
        }
        public DialogResult DialogResult { get; set; }
        public void NotifyDefault(bool value)
        {
        }
        public void PerformClick()
        {
            _barItem.PerformClick();
        }
    }
}