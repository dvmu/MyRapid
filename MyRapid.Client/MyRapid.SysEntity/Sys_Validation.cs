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
    ///表Sys_Validation的实体类
    ///</summary>
    public class Sys_Validation
    {
        ///<summary> 
        ///
        ///</summary>
        public string Validation_Id { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Validation_Name { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Validation_Nick { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Validation_FieldName { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Validation_WorkSet { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Validation_Expression { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Validation_Formula { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Validation_Confirm { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Validation_SetError { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Validation_Ruler { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Validation_ErrorText { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Validation_ToolTip { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Validation_Negate { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Validation_Cancel { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public int Validation_Sort { get; set; }
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