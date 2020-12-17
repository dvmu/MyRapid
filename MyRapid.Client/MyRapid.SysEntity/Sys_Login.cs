/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyRapid.SysEntity
{
    public class Sys_Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RemUserName { get; set; }
        public bool RemPassword { get; set; }
        public DateTime LastLogin { get; set; }
        public string SkinName { get; set; }
    }
}