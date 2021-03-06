/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.ComponentModel;
namespace MyRapid.SysEntity
{
    ///<summary>
    ///表Sys_Route的实体类
    ///</summary>
    public class Sys_Route
    {
        [Browsable(false)]
        public string Route_Id { get; set; }
        [Category("Designer")]
        public string Route_Name { get; set; }
        [Category("Designer")]
        public string Route_Nick { get; set; }
        [Browsable(false)]
        public string Route_From { get; set; }
        [Browsable(false)]
        public string Route_To { get; set; }
        [Category("Designer")]
        public int Route_Status { get; set; }
        [Browsable(false)]
        public string Route_Flow { get; set; }
        [Category("Extension")]
        public bool IsEnabled { get; set; }
        [Browsable(false)]
        public bool IsDelete { get; set; }
        [Category("Extension")]
        public string Remark { get; set; }
        [Browsable(false)]
        public string Create_User { get; set; }
        [Browsable(false)]
        public System.DateTime Create_Time { get; set; }
        [Browsable(false)]
        public string Modify_User { get; set; }
        [Browsable(false)]
        public System.DateTime Modify_Time { get; set; }
        [Browsable(false)]
        public string Delete_User { get; set; }
        [Browsable(false)]
        public System.DateTime Delete_Time { get; set; }
    }
}