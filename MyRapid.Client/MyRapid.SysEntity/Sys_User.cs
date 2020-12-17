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
    ///表Sys_User的实体类
    ///</summary>
    public class Sys_User
    {
        public string User_Id { get; set; }
        public byte[] User_Icon { get; set; }
        public string User_Name { get; set; }
        public string User_Nick { get; set; }
        public string User_Password { get; set; }
        public string User_Department { get; set; }
        public string User_Authorization { get; set; }
        public string User_Token { get; set; }
        public int User_Location { get; set; }
        public string User_Page { get; set; }
        public string User_Skin { get; set; }
        public string User_FontName { get; set; }
        public int User_FontSize { get; set; }
        public byte User_Cultural { get; set; }
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