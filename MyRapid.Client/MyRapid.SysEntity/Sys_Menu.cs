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
    ///表Sys_Menu的实体类
    ///</summary>
    public class Sys_Menu
    {
        ///<summary> 
        ///自增代码
        ///</summary>
        public string Menu_Id { get; set; }
        ///<summary> 
        ///父级
        ///</summary>
        public string Menu_Parent { get; set; }
        ///<summary> 
        ///代码
        ///</summary>
        public string Menu_Name { get; set; }
        ///<summary> 
        ///序号
        ///</summary>
        public string Menu_Nick { get; set; }
        ///<summary> 
        ///提示
        ///</summary>
        public string Menu_Hint { get; set; }
        ///<summary> 
        ///图像
        ///</summary>
        public string Menu_Icon { get; set; }
        /// <summary>
        /// 帮助文档
        /// </summary>
        public string Menu_Help { get; set; }
        /// <summary>
        /// 图标序号
        /// </summary>
        public int Menu_IconIndex { get; set; }
        ///<summary> 
        ///大小
        ///</summary>
        public string Menu_Page { get; set; }
        ///<summary> 
        ///模块
        ///</summary>
        public string Menu_Module { get; set; }
        ///<summary> 
        ///功能
        ///</summary>
        public string Menu_Function { get; set; }
        public string Menu_Path { get; set; }
        public string Menu_Class { get; set; }
        public byte Menu_Type { get; set; }
        public byte Menu_Show { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Menu_Sort { get; set; }
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
        ///<summary> 
        ///
        ///</summary>
        public byte[] Row_Version { get; set; }
    }
}
