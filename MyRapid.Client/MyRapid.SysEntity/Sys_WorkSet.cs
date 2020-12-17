/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Windows.Forms;
namespace MyRapid.SysEntity
{
    ///<summary>
    ///表Sys_WorkSet的实体类
    ///</summary>
    public class Sys_WorkSet
    {
        public string WorkSet_Id { get; set; }
        public string WorkSet_Page { get; set; }
        public string WorkSet_Name { get; set; }
        public string WorkSet_Nick { get; set; }
        public byte WorkSet_Type { get; set; }
        public string WorkSet_Grid { get; set; }
        public Control WorkSet_Control { get; set; }
        public string WorkSet_Table { get; set; }
        public string WorkSet_Pagination { get; set; }
        public int WorkSet_ReadSort { get; set; }
        public int WorkSet_SaveSort { get; set; }
        public string WorkSet_Trigger { get; set; }
        public string WorkSet_Select { get; set; }
        public string WorkSet_Update { get; set; }
        public string WorkSet_Insert { get; set; }
        public string WorkSet_Delete { get; set; }
        public string WorkSet_Connection { get; set; }
        public string WorkSet_SqlType { get; set; }
        public bool IsDelete { get; set; }
        public string Remark { get; set; }
        public string Create_User { get; set; }
        public System.DateTime Create_Time { get; set; }
        public string Modify_User { get; set; }
        public System.DateTime Modify_Time { get; set; }
        public string Delete_User { get; set; }
        public System.DateTime Delete_Time { get; set; }
    }
}