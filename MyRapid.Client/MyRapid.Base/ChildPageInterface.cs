/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * Author: 陈恩点
 * First Create: 2012/8/21 11:49:53
 * Contact: 18115503914
 * Description: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraBars;
using MyERP.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MyERP.Base.Page
{
    public abstract class ChildPageInterface
    {
        private Sys_User Current_User { get; set; }
        private BarButtonItem BarTip { get; set; }
        [Browsable(false)]
        public Sys_Page fromPage { get; set; }
        [Browsable(false)]
        public Sys_Menu fromMenu { get; set; }
    }
}