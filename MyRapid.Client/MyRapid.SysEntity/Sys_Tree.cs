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
    ///表Sys_Tree的实体类
    ///</summary>
    public class Sys_Tree
    {
        ///<summary> 
        ///
        ///</summary>
        public string Tree_Id { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Tree_Name { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Tree_Nick { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Tree_Page { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Tree_Grid { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Tree_Parent { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Tree_Key { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Tree_Display { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Tree_Value { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Tree_Check { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Tree_ReadOnly { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Tree_Hide { get; set; }
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