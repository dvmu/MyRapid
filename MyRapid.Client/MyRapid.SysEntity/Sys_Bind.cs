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
    ///表Sys_Bind的实体类
    ///</summary>
    public class Sys_Bind
    {
        ///<summary>  
        ///自增编号
        ///</summary>
        public string Bind_Id { get; set; }
        ///<summary> 
        ///WorkSet
        ///</summary>
        public string Bind_WorkSet { get; set; }
        ///<summary> 
        ///名称
        ///</summary>
        public string Bind_Name { get; set; }
        ///<summary> 
        ///昵称
        ///</summary>
        public string Bind_Nick { get; set; }
        ///<summary> 
        ///提示
        ///</summary>
        public string Bind_ToolTip { get; set; }
        ///<summary> 
        ///字段
        ///</summary>
        public string Bind_Field { get; set; }
        /// <summary>
        /// 控件
        /// </summary>
        public object Bind_Control { get; set; }
        ///<summary> 
        ///可见顺序
        ///</summary>
        public int Bind_Sort { get; set; }
        ///<summary> 
        ///可见
        ///</summary>
        public bool Bind_Visible { get; set; }
        ///<summary> 
        ///汇总
        ///</summary>
        public int Bind_Summary { get; set; }
        ///<summary> 
        ///锁定
        ///</summary>
        public byte Bind_Fix { get; set; }
        ///<summary> 
        ///只读
        ///</summary>
        public bool Bind_ReadOnly { get; set; }
        ///<summary> 
        ///多表头(弃用)
        ///</summary>
        public string Bind_Band { get; set; }
        ///<summary> 
        ///绑定字段
        ///</summary>
        public string Bind_Popup { get; set; }
        ///<summary> 
        ///推送控件
        ///</summary>
        public string Bind_Push { get; set; }
        ///<summary> 
        ///编辑控件
        ///</summary>
        public string Bind_Property { get; set; }
        ///<summary> 
        ///宽度
        ///</summary>
        public int Bind_Width { get; set; }
        ///<summary> 
        ///编辑控件
        ///</summary>
        public int Bind_FormSort { get; set; }
        ///<summary> 
        ///宽度
        ///</summary>
        public int Bind_FormWidth { get; set; }
        ///<summary> 
        ///标题对齐
        ///</summary>
        public byte Bind_TitleAlignment { get; set; }
        ///<summary> 
        ///文本对齐
        ///</summary>
        public byte Bind_TextAlignment { get; set; }
        ///<summary> 
        ///默认值
        ///</summary>
        public string Bind_Default { get; set; }
        ///<summary> 
        ///格式
        ///</summary>
        public string Bind_Format { get; set; }
        ///<summary> 
        ///限制
        ///</summary>
        public string Bind_Restrict { get; set; }
        ///<summary> 
        ///公式
        ///</summary>
        public string Bind_Formula { get; set; }
        ///<summary> 
        ///分组
        ///</summary>
        public int Bind_Group { get; set; }
        ///<summary> 
        ///数据类型
        ///</summary>
        public byte Bind_SqlDbType { get; set; }
        ///<summary> 
        ///控件类型
        ///</summary>
        public byte Bind_Type { get; set; }
        ///<summary> 
        ///合并
        ///</summary>
        public bool Bind_Merge { get; set; }
        ///<summary> 
        ///背景色
        ///</summary>
        public int Bind_BackColor { get; set; }
        ///<summary> 
        ///前景色
        ///</summary>
        public int Bind_ForeColor { get; set; }
        ///<summary> 
        ///边框色
        ///</summary>
        public int Bind_BorderColor { get; set; }
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