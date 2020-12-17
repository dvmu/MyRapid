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
    ///表Sys_Chart的实体类
    ///</summary>
    public class Sys_Chart
    {
        ///<summary> 
        ///
        ///</summary>
        public string Chart_Id { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Chart_Name { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Chart_Nick { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Chart_Remark { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public byte[] Chart_Bytes { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Chart_Xml { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Chart_WorkSet { get; set; }
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