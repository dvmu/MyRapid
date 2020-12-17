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
    ///表Sys_Connection的实体类
    ///</summary>
    public class Sys_Connection
    {
        ///<summary> 
        ///主键
        ///</summary>
        public string Connection_Id { get; set; }
        ///<summary> 
        ///名称
        ///</summary>
        public string Connection_Name { get; set; }
        ///<summary> 
        ///昵称
        ///</summary>
        public string Connection_Nick { get; set; }
        ///<summary> 
        ///类型
        ///</summary>
        public string Connection_Type { get; set; }
        ///<summary> 
        ///服务器
        ///</summary>
        public string Connection_Server { get; set; }
        ///<summary> 
        ///端口
        ///</summary>
        public int Connection_Port { get; set; }
        ///<summary> 
        ///数据库
        ///</summary>
        public string Connection_DataBase { get; set; }
        ///<summary> 
        ///帐号
        ///</summary>
        public string Connection_UserName { get; set; }
        ///<summary> 
        ///密码
        ///</summary>
        public string Connection_Password { get; set; }
        ///<summary> 
        ///连接字符串
        ///</summary>
        public string Connection_Connection { get; set; }
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
        public string Row_Version { get; set; }
    }
}