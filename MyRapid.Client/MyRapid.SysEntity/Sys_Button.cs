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
    ///表Sys_Button的实体类
    ///</summary>
    public class Sys_Button
    {
        ///<summary> 
        ///自增编号
        ///</summary>
        public string Button_Id { get; set; }
        ///<summary> 
        ///所在窗体
        ///</summary>
        public string Button_Page { get; set; }
        ///<summary> 
        ///按钮名称
        ///</summary>
        public string Button_Name { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Button_Nick { get; set; }
        public object Button_BarItem { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Button_Hint { get; set; }
        ///<summary> 
        ///过程函数
        ///</summary>
        public string Button_Sub { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Button_Parameter { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public string Button_Parent { get; set; }
        ///<summary> 
        ///<summary> 
        ///图标名称
        ///</summary>
        public string Button_Icon { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Button_Confirm { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Button_Open { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Button_Validation { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Button_BeginGroup { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Button_IsLarge { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public byte Button_Alignment { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public byte Button_CaptionAlignment { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public byte Button_Assign { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public int Button_Sort { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public int Button_Key { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public int Button_SecondKey { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Button_Visible { get; set; }
        ///<summary> 
        ///
        ///</summary>
        public bool Button_Enabled { get; set; }
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