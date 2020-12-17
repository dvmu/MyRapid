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
namespace MyRapid.GlobalLocalizer
{
    public enum MyCommonStringId
    {
        //主窗体文本
        MainUI_Text = 1010,
        //显示隐藏菜单
        MenuCmd_ShowHideMenu = 1111,
        //显示隐藏菜单提示
        MenuCmd_ShowHideMenuHint = 1112,
        //用户信息
        MenuCmd_UserInfo = 1113,
        //用户信息提示
        MenuCmd_UserInfoHint = 1114,
        //系统设置
        MenuCmd_Config = 1115,
        //系统设置提示
        MenuCmd_ConfigHint = 1116,
        //帮助
        MenuCmd_Help = 1117,
        //提示
        MenuCmd_HelpHint = 1118,
        //当前用户
        MenuCmd_UserNickHint = 1119,
        //当前页面
        MenuCmd_PageNameHint = 1120,
        //当前页面作者
        MenuCmd_AuthorHint = 1121,
        //当前页面版本
        MenuCmd_VersionHint = 1122,
        MenuCmd_UserSkin = 1123,
        MenuCmd_UserSkinHint = 1124,
        //加载多国语言
        Initialize_GlobalLocalizer = 1210,
        //加载主界面
        Initialize_Component = 1211,
        //加载系统菜单 
        Initialize_Menu = 1212,
        //启动中
        Initialize_Finish = 1213,
        //自定义语言
        Initialize_CommonLocalizer = 1214,
        //加载图标
        Initialize_Image = 1215,
        Initialize_AutoUpdate = 1216,
        Initialize_Configuration = 1217,
        //登录失败
        Login_Error = 1310,
        //登录失败
        Login_Error_Detail = 1311,
        //帐号
        Login_UserName = 1312,
        //密码
        Login_Password = 1313,
        //登录窗体
        Login_Text = 1314,
        //记住账号
        Login_Check_UserName = 1315,
        //记住密码
        Login_Check_Password = 1316,
        //登录按钮
        Login_Button_Login = 1317,
        //取消按钮
        Login_Button_Cancel = 1318,
        //登陆成功
        Login_Succeed = 1319,
        //User登陆成功
        Login_SucceedDetail = 1320,
        //退出确认
        MainUI_Exit = 1410,
        //退出确认说明 
        MainUI_ExitDetail = 1411,
        //退出成功
        MainUI_Exit_Succeed = 1412,
        //User退出成功
        MainUI_Exit_SucceedDetail = 1413,
        MainUI_Error = 1414,
        ChildMenu_Error = 1415,
        ChildPage_ConfirmCaption = 1416,
        ChildPage_ConfirmText = 1417,
        GridColumnMenuCheckAll = 3901,
        GridColumnMenuUnCheckAll = 3902,
        GridColumnMenuAutoNumber = 3903,
        GridColumnMenuAutoFill = 3904,
        GridColumnMenuExpression = 3905,
        GridColumnMenuFieldEdit = 3906,
        GridColumnMenuFieldClear = 3907,
        CloseMenu_This = 1501,
        CloseMenu_Other = 1502,
        CloseMenu_Left = 1503,
        CloseMenu_Right = 1504,
        CloseMenu_All = 1505
    }
}