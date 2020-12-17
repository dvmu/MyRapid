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
    ///表Sys_FileInput的实体类
    ///</summary>
    public class Sys_FileInput
    {
        public string FileInput_Id { get; set; }
        public string FileInput_Name { get; set; }
        public string FileInput_Nick { get; set; }
        public string FileInput_FromPage { get; set; }
        public string FileInput_Extension { get; set; }
        public string FileInput_Content { get; set; }
        public byte[] FileInput_Bytes { get; set; }
        public string FileInput_Path { get; set; }
        public string FileInput_Relative { get; set; }
        public byte FileInput_Type { get; set; }
        public byte FileInput_SaveType { get; set; }
        public string FileInput_Sign { get; set; }
        public string FileInput_Version { get; set; }
        public bool IsEnabled { get; set; }
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