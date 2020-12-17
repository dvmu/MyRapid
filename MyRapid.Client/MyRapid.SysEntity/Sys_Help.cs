/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
namespace MyRapid.SysEntity
{
    ///<summary>
    ///表Sys_Help的实体类
    ///</summary>
    public class Sys_Help
    {
        public string Help_Id { get; set; }
        public string Help_Menu { get; set; }
        public string Help_Name { get; set; }
        public string Help_Nick { get; set; }
        public string Help_Rtf { get; set; }
        public int Help_Width { get; set; }
        public byte Help_Cultural { get; set; }
        public bool IsDelete { get; set; }
        public string Remark { get; set; }
        public string Create_User { get; set; }
        public System.DateTime Create_Time { get; set; }
        public string Modify_User { get; set; }
        public System.DateTime Modify_Time { get; set; }
        public string Delete_User { get; set; }
        public System.DateTime Delete_Time { get; set; }
    }
}