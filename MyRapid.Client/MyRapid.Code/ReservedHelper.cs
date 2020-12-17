/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyRapid.Code
{
    public static class ReservedHelper
    {
        public static string[] GridField = new string[] { "IsEditable", "IsEnabled", "IsDelete", "Remark", "Create_User", "Create_Time", "Modify_User", "Modify_Time", "Delete_User", "Delete_Time" };
        //public static string[] GridPageField = new string[] { "IsEnabled", "IsDelete", "Remark", "Create_User", "Create_Time", "Modify_User", "Modify_Time", "Delete_User", "Delete_Time", "Row_Version", "Record_Id", "PageCount" };
        public static string[] GridAutoField = new string[] { "IsEditable", "IsEnabled", "IsDelete", "Remark", "Create_User", "Create_Time", "Modify_User", "Modify_Time", "Delete_User", "Delete_Time", "Row_Version", "Record_Id", "PageCount" };
        public static string[] GridDateField = new string[] { "Create_Time", "Modify_Time", "Delete_Time" };
        public static string[] GridUserField = new string[] { "Create_User", "Modify_User", "Delete_User" };
        public static string[] GridInsertField = new string[] { "Create_User", "Create_Time" };
        public static string[] GridUpdateField = new string[] { "Modify_User", "Modify_Time" };
        public static string[] GridDeleteField = new string[] { "Delete_User", "Delete_Time" };
        public static string[] ConvertTrueString = new string[] { "true", "1", "真", "checked", "yes", "real", "correct", "right", "positive" };
        public static string[] ConvertFalseString = new string[] { "false", "0", "假", "unchecked", "no", "empty", "incorrect", "wrong", "negative" };
        //public static string[] ButtonSub = new string[] { "Open", "Save", "Edit", "Add", "Remove", "Insert", "Copy", "Paste", "Clear", "Import", "Export", "Design" };
        //public static string[] ButtonName = new string[] { "查询", "保存", "编辑", "添加", "删除", "插入", "复制", "粘贴", "清空", "导入", "导出", "设计" };
        //public static string[] ButtonNick = new string[] { "查询", "保存", "编辑", "添加", "删除", "插入", "复制", "粘贴", "清空", "导入", "导出", "设计" };
        //public static string[] ButtonKey = new string[] { "Q", "S", "E", "N", "Delete", "I", "C", "P", "K", "M", "X", "D" };
        //public static int[] ButtonKeyInt = new int[] { 81, 83, 69, 78, 46, 73, 67, 80, 75, 77, 88, 68 };
        //public static string[] ButtonSort = new string[] { "1010", "1020", "1030", "1040", "1050", "1060", "1070", "1080", "1090", "1100", "1110", "1120" };
    }
}