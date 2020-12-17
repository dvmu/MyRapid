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
    ///表Sys_StepOperate的实体类
    ///</summary>
    public class Sys_StepOperate
    {
        ///<summary> 
        ///主键
        ///</summary>
        public string StepOperate_Id { get; set; }
        ///<summary> 
        ///名称
        ///</summary>
        public string StepOperate_Name { get; set; }
        ///<summary> 
        ///昵称
        ///</summary>
        public string StepOperate_Nick { get; set; }
        ///<summary> 
        ///输入
        ///</summary>
        public string StepOperate_Status { get; set; }
        ///<summary> 
        ///输出
        ///</summary>
        public string StepOperate_Result { get; set; }
        ///<summary> 
        ///步骤
        ///</summary>
        public string StepOperate_StepEntry { get; set; }
        ///<summary> 
        ///图标
        ///</summary>
        public string StepOperate_Icon { get; set; }
        ///<summary> 
        ///排序
        ///</summary>
        public int StepOperate_Sort { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsDelete { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public DateTime Create_Time { get; set; }
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
        ///<summary> 
        ///
        ///</summary>
        public DateTime Modify_Time { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool IsEnabled { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Create_User { get; set; }
    }
}