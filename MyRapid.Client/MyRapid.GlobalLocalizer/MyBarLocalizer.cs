/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.XtraBars.Localization;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
namespace MyRapid.GlobalLocalizer
{
    public class MyBarLocalizer: BarLocalizer
    {
        public override string GetLocalizedString(BarString ID)
        {
          return  BaseLocalizer.GetLocalizedString<BarString>((int)ID, base.GetLocalizedString(ID), base.GetType().Name);
        }
    }
}