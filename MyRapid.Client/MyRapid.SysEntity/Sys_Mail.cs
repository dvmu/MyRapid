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
    ///表Sys_Mail的实体类
    ///</summary>
    public class Sys_Mail
    {
        ///<summary> 
        ///主键
        ///</summary>
        public string Mail_Id { get; set; }
        ///<summary> 
        ///名称
        ///</summary>
        public string Mail_Name { get; set; }
        ///<summary> 
        ///昵称
        ///</summary>
        public string Mail_Nick { get; set; }
        ///<summary> 
        ///收信人
        ///</summary>
        public string Mail_Send { get; set; }
        ///<summary> 
        ///抄送人
        ///</summary>
        public string Mail_Carbon { get; set; }
        ///<summary> 
        ///发件人
        ///</summary>
        public string Mail_From { get; set; }
        ///<summary> 
        ///密码
        ///</summary>
        public string Mail_Password { get; set; }
        ///<summary> 
        ///Smtp
        ///</summary>
        public string Mail_Smtp { get; set; }
        ///<summary> 
        ///标题
        ///</summary>
        public string Mail_Subject { get; set; }
        ///<summary> 
        ///内容
        ///</summary>
        public string Mail_Body { get; set; }
        ///<summary> 
        ///签名
        ///</summary>
        public string Mail_Signature { get; set; }
        ///<summary> 
        ///已发送
        ///</summary>
        public bool Mail_Done { get; set; }
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