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
    ///表Sys_Page的实体类
    ///</summary>
    public class Sys_Page
    {
        public string Menu_Id { get; set; }
        public string Menu_Name { get; set; }
        public string Menu_Nick { get; set; }
        public bool Menu_IsAdmin { get; set; }
        public string Menu_Module { get; set; }
        public string Menu_Function { get; set; }
        public string Menu_Author { get; set; }
        public string Menu_Version { get; set; }
        public string Menu_Path { get; set; }
        public string Menu_Class { get; set; }
        public byte Menu_Type { get; set; }
        public byte Menu_Show { get; set; }
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