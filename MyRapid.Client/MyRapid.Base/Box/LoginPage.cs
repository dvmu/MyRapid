/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using MyRapid.Code;
using MyRapid.GlobalLocalizer;
using MyRapid.Proxy;
using MyRapid.Proxy.MainService;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static MyRapid.SysEntity.Sys_Enum;
using System.Diagnostics;
namespace MyRapid.Base
{
    public partial class LoginPage : XtraForm
    {
        private string PassMask = "@@@@@@";
        private List<Sys_Login> LoginInfos = new List<Sys_Login>();
        private MyCommonLocalizer myCommonLocalizer = new MyCommonLocalizer();
        public LoginPage()
        {

            InitializeComponent();
            ContextMenu emptyMenu = new ContextMenu();
            txtUsername.Properties.ContextMenu = emptyMenu;
            txtPassword.Properties.ContextMenu = emptyMenu;
            pictureEdit1.Properties.ContextMenu = emptyMenu;
            layoutControl1.ContextMenu = emptyMenu;
            txtUsername.Properties.Items.Clear();
            LoginInfos = CacheHelper.Get<List<Sys_Login>>("SysLogin");
            if (LoginInfos != null)
                LoginInfos = LoginInfos.Distinct().ToList();
            if (LoginInfos == null) LoginInfos = new List<Sys_Login>();
            foreach (Sys_Login config in LoginInfos.OrderByDescending(l => l.LastLogin))
            {
                txtUsername.Properties.Items.Add(config.UserName);
            }
            txtUsername.SelectedIndex = 0;
            string mainText = myCommonLocalizer.GetLocalizedString(MyCommonStringId.Login_Text);
            if (!string.IsNullOrEmpty(mainText)) this.Text = mainText;
            string btnLoginText = myCommonLocalizer.GetLocalizedString(MyCommonStringId.Login_Button_Login);
            if (!string.IsNullOrEmpty(btnLoginText)) btnLogin.Text = btnLoginText;
            string btnCancelText = myCommonLocalizer.GetLocalizedString(MyCommonStringId.Login_Button_Cancel);
            if (!string.IsNullOrEmpty(btnCancelText)) btnCancel.Text = btnCancelText;
            string lytUsernameText = myCommonLocalizer.GetLocalizedString(MyCommonStringId.Login_UserName);
            if (!string.IsNullOrEmpty(lytUsernameText)) lytUsername.Text = lytUsernameText;
            string lytPasswordText = myCommonLocalizer.GetLocalizedString(MyCommonStringId.Login_Password);
            if (!string.IsNullOrEmpty(lytPasswordText)) lytPassword.Text = lytPasswordText;
            string chkUserNameText = myCommonLocalizer.GetLocalizedString(MyCommonStringId.Login_Check_UserName);
            if (!string.IsNullOrEmpty(chkUserNameText)) chkUserName.Text = chkUserNameText;
            string chkPasswordText = myCommonLocalizer.GetLocalizedString(MyCommonStringId.Login_Check_Password);
            if (!string.IsNullOrEmpty(chkPasswordText)) chkPassword.Text = chkPasswordText;
        }
        private string EncryptPassword;
        private void txtUsername_SelectedIndexChanged(object sender, EventArgs e)
        {

            Sys_Login loginInfo = LoginInfos.Find(l => l.UserName == txtUsername.Text);
            if (loginInfo != null)
            {
                chkUserName.Checked = loginInfo.RemUserName;
                chkPassword.Checked = loginInfo.RemPassword;
                if (loginInfo.RemPassword)
                {
                    EncryptPassword = loginInfo.Password;
                    txtPassword.Text = PassMask;
                    chkUserName.Checked = true;
                }
                UserLookAndFeel.Default.SetSkinStyle(loginInfo.SkinName);
                DevExpress.Utils.AppearanceObject.DefaultFont = new System.Drawing.Font("微软雅黑", 9);
                DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new System.Drawing.Font("微软雅黑", 9);
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                string json = BaseService.Login(txtUsername.Text, EncryptPassword);
                Sys_User sys_User = json.ToObject<Sys_User>();
                if (sys_User == null || sys_User.User_Password == null)
                {
                    string err = myCommonLocalizer.GetLocalizedString(MyCommonStringId.Login_Error);
                    string errDetail = myCommonLocalizer.GetLocalizedString(MyCommonStringId.Login_Error_Detail);
                    //BaseService.SaveLog(err, errDetail, (byte)Sys_Log_Type.Information, string.Empty, this.Name + ":" + txtUsername.Text);
                    XtraMessageBox.Show(errDetail, err);
                    return;
                }
                Provider.SysUser = sys_User;
                Sys_Login loginInfo = LoginInfos.Find(l => l.UserName == txtUsername.Text);
                if (loginInfo == null)
                {
                    loginInfo = new Sys_Login();
                    LoginInfos.Add(loginInfo);
                }
                loginInfo.UserName = txtUsername.Text;
                loginInfo.RemUserName = chkUserName.Checked;
                loginInfo.RemPassword = chkPassword.Checked;
                loginInfo.Password = string.Empty;
                loginInfo.LastLogin = DateTime.Now;
                loginInfo.SkinName = UserLookAndFeel.Default.ActiveSkinName;
                if (loginInfo.RemPassword)
                {
                    loginInfo.Password = EncryptPassword;
                }
                CacheHelper.SetAsync(LoginInfos, "SysLogin");
                this.Close();
            }
            catch (Exception ex)
            {
                //BaseService.SaveLog(ex.Message, ex.ToJson(), (byte)Sys_Log_Type.Exception, string.Empty, this.Name + ":" + txtUsername.Text);
                XtraMessageBox.Show(ex.TargetSite.ToStringEx(), ex.Message);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Equals(PassMask)) return;
            EncryptPassword = EncryptHelper.DESEncrypt(EncryptHelper.DESEncrypt(txtPassword.Text, txtPassword.Text), "NBest_desencrypt_2016");
        }
        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {

            txtPassword.Text = string.Empty;
        }
    }
}