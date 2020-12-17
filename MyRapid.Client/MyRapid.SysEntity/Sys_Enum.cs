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
namespace MyRapid.SysEntity
{
    public class Sys_Enum
    {

        public enum Sys_WorkSet_Editor
        {
            ButtonEdit = 1,
            CalcEdit = 2,
            CheckedComboBoxEdit = 3,
            CheckEdit = 4,
            CheckedLookUpEdit = 5,
            ColorEdit = 6,
            ComboBoxEdit = 7,
            DateEdit = 8,
            DateTimeEdit = 9,
            DiagramDesigner = 26,
            FileInput = 10,
            FolderPicker = 23,
            GridSelect = 11,
            ImageEdit = 12,
            ImagePicker = 13,
            LookUpEdit = 14,
            PopupPage = 15,
            ProgressBar = 16,
            //ReportDesigner = 25,
            SkinPicker = 17,
            SpinEdit = 18,
            TextEdit = 19,
            TimeEdit = 20,
            TreeListLookUpEdit = 21,
            TreeSelect = 22,
            PasswordEdit = 24,
            ReportEdit = 25,
            SnapEdit = 26,
            RichEdit = 27,
            DiagramEdit = 28,
            ChartEdit = 29,
            ScriptEdit = 30,
            MemoEdit = 31,
            ExpressionEditor = 32,
            GridPopup = 33,
            YearEdit = 34,
            MonthEdit = 35,
            PhrasePage = 36
        }
        public enum Sys_WorkSet_Type
        {
            Grid = 1,
            Sql = 2,
            Code = 3,
            Chart = 4,
            Save = 5,
            Report = 6,
            Submit = 7,
            Tree = 9,
        }
        public enum Sys_Menu_Show
        {
            MdiChild = 0,
            Dialog = 1,
            NewForm = 2
        }
        public enum Sys_FileInput_Type
        {
            Chart = 0,
            Diagram = 1,
            Report = 2,
            Rtf = 3,
            Excel = 4,
            Other = 5,
            Library = 6,
            Execute = 7
        }
        public enum Sys_FileInput_SaveType
        {
            Content = 0,
            Byte = 1,
            LocalFile = 2,
            ServerFile = 3,
            Xml = 4,
            Other = 5
        }
        public enum Sys_Log_Type
        {
            Exception = 0, //异常
            Information = 1, //信息
            Fatal = 2, //致命错误
            FaultException = 3, //服务端错误
            Operation = 4 //用户操作
        }
    }
}