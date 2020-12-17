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
    ///表Sys_StepEntry的实体类
    ///</summary>
    public class Sys_StepEntry
    {
        ///<summary> 
        ///主键
        ///</summary>
        public string StepEntry_Id { get; set; }
        ///<summary> 
        ///步骤编码
        ///</summary>
        public string StepEntry_Name { get; set; }
        ///<summary> 
        ///步骤名称
        ///</summary>
        public string StepEntry_Nick { get; set; }
        ///<summary> 
        ///操作人
        ///</summary>
        public string StepEntry_Biller { get; set; }
        ///<summary> 
        ///抄送人
        ///</summary>
        public string StepEntry_Reference { get; set; }
        ///<summary> 
        ///可以关闭
        ///</summary>
        public bool StepEntry_Close { get; set; }
        ///<summary> 
        ///可以跳过
        ///</summary>
        public bool StepEntry_Skip { get; set; }
        ///<summary> 
        ///序号
        ///</summary>
        public int StepEntry_Sort { get; set; }
        ///<summary> 
        ///触发条件
        ///</summary>
        public string StepEntry_Trigger { get; set; }
        ///<summary> 
        ///流程
        ///</summary>
        public string StepEntry_Step { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public DateTime Create_Time { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsDelete { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsEnabled { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Modify_User { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public DateTime Delete_Time { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Remark { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Delete_User { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public DateTime Modify_Time { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Create_User { get; set; }
    }
}