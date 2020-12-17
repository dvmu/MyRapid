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
    ///表Sys_Popup的实体类
    ///</summary>
    public class Sys_Popup
    {
        public string Popup_Id { get; set; }
        public string Popup_Name { get; set; }
        public string Popup_Nick { get; set; }
        public byte Popup_Type { get; set; }
        public bool Popup_MultiSelect { get; set; }
        public string Popup_Field { get; set; }
        public string Popup_ParentField { get; set; }
        public string Popup_KeyField { get; set; }
        public string Popup_WorkSet { get; set; }
        public string Popup_Target { get; set; }
        public string Popup_DisplayMember { get; set; }
        public string Popup_ValueMember { get; set; }
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