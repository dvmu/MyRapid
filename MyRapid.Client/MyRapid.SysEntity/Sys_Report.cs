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
    ///表Sys_Report的实体类
    ///</summary>
    public class Sys_Report
    {
        ///<summary> 
        ///
        ///</summary>
        public string Report_Id { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Report_Name { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Report_Nick { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public byte[] Report_Bytes { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Report_Xml { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Report_WorkSet { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Report_Parameter { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsEnabled { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsDelete { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Remark { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Create_User { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public DateTime Create_Time { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Modify_User { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public DateTime Modify_Time { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Delete_User { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public DateTime Delete_Time { get; set; }
    }
}