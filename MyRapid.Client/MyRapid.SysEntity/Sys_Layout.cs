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
    ///表Sys_Layout的实体类
    ///</summary>
    public class Sys_Layout
    {
        public string Layout_Id { get; set; }
        public string Layout_Page { get; set; }
        public string Layout_Name { get; set; }
        public string Layout_Nick { get; set; }
        public string Layout_Parent { get; set; }
        public int Layout_Sort { get; set; }
        public byte Layout_Type { get; set; }
        public string Layout_Grid { get; set; }
        public bool Layout_Pagination { get; set; }
        public int Layout_Left { get; set; }
        public int Layout_Top { get; set; }
        public int Layout_Width { get; set; }
        public int Layout_Height { get; set; }
        public byte Layout_Dock { get; set; }
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