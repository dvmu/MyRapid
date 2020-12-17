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
    ///表Sys_StepResult的实体类
    ///</summary>
    public class Sys_StepResult
    {
        ///<summary> 
        ///主键
        ///</summary>
        public string StepResult_Id { get; set; }
        ///<summary> 
        ///名称
        ///</summary>
        public string StepResult_Name { get; set; }
        ///<summary> 
        ///昵称
        ///</summary>
        public string StepResult_Nick { get; set; }
        ///<summary> 
        ///页面
        ///</summary>
        public string StepResult_Menu { get; set; }
        ///<summary> 
        ///单据
        ///</summary>
        public string StepResult_Bill { get; set; }
        ///<summary> 
        ///流程
        ///</summary>
        public string StepResult_Step { get; set; }
        ///<summary> 
        ///步骤
        ///</summary>
        public string StepResult_StepEntry { get; set; }
        ///<summary> 
        ///操作
        ///</summary>
        public string StepResult_Operate { get; set; }
        ///<summary> 
        ///状态
        ///</summary>
        public string StepResult_Status { get; set; }
        ///<summary> 
        ///结果
        ///</summary>
        public string StepResult_Result { get; set; }
        ///<summary> 
        ///操作人
        ///</summary>
        public string StepResult_Biller { get; set; }
        ///<summary> 
        ///说明
        ///</summary>
        public string StepResult_Reason { get; set; }
        ///<summary> 
        ///历史
        ///</summary>
        public string StepResult_History { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsEnabled { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public DateTime Modify_Time { get; set; }
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
        public bool IsDelete { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Delete_User { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Remark { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public DateTime Delete_Time { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Modify_User { get; set; }
    }
}