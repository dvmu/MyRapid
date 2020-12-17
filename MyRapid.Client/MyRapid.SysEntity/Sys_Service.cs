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
    ///表Sys_Service的实体类
    ///</summary>
    public class Sys_Service
    {
        ///<summary> 
        ///主键
        ///</summary>
        public string Service_Id { get; set; }
        ///<summary> 
        ///名称
        ///</summary>
        public string Service_Name { get; set; }
        ///<summary> 
        ///昵称
        ///</summary>
        public string Service_Nick { get; set; }
        ///<summary> 
        ///页面
        ///</summary>
        public string Service_Page { get; set; }
        ///<summary> 
        ///WorkSet
        ///</summary>
        public string Service_WorkSet { get; set; }
        ///<summary> 
        ///路径
        ///</summary>
        public string Service_File { get; set; }
        ///<summary> 
        ///路径
        ///</summary>
        public string Service_Parameter { get; set; }
        ///<summary> 
        ///执行一次
        ///</summary>
        public bool Service_Once { get; set; }
        ///<summary> 
        ///循环周期
        ///</summary>
        public int Service_Interval { get; set; }
        ///<summary> 
        ///单位
        ///</summary>
        public int Service_Unit { get; set; }
        ///<summary> 
        ///最后执行
        ///</summary>
        public DateTime Service_LastRun { get; set; }
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