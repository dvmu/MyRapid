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
    ///表Sys_Schema的实体类
    ///</summary>
    public class Sys_Schema
    {
        ///<summary> 
        ///
        ///</summary>
        public string FieldName { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string FieldNameOld { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsIdentity { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public int SortOrder { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsPrimary { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsUnique { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsNullable { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsIndex { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string SqlDbType { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string TableName { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string DefaultValue { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Description { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Detail { get; set; }
    }
}