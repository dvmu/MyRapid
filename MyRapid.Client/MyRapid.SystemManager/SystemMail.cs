/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using MyRapid.Base;
using MyRapid.Code;
using MyRapid.SysEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace MyRapid.SystemManager
{
    public partial class SystemMail : ChildPage
    {
        public SystemMail()
        {
            InitializeComponent();
        }
        public void Start()
        {
            timer1.Enabled = true;
            Sys_Button sys_Button = ButtonList.Find(b => b.Button_Sub == "Start");
            if (sys_Button == null) return;
            sys_Button.Button_Enabled = false;
            RefreshTool(sys_Button);
            sys_Button = ButtonList.Find(b => b.Button_Sub == "Stop");
            if (sys_Button == null) return;
            sys_Button.Button_Enabled = true;
            RefreshTool(sys_Button);
        }
        public void Stop()
        {
            timer1.Enabled = false;
            Sys_Button sys_Button = ButtonList.Find(b => b.Button_Sub == "Stop");
            if (sys_Button == null) return;
            sys_Button.Button_Enabled = false;
            RefreshTool(sys_Button);
            sys_Button = ButtonList.Find(b => b.Button_Sub == "Start");
            if (sys_Button == null) return;
            sys_Button.Button_Enabled = true;
            RefreshTool(sys_Button);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)gd.DataSource;
            if (dt == null) return;
            List<Sys_Mail> sys_Mails = EntityHelper.GetEntities<Sys_Mail>(dt);
            Sys_Mail sys_Mail = sys_Mails.Find(m => m.Mail_Done == false);
            if (sys_Mail == null) return;
            try
            {
                WebHelper.SendeMail(sys_Mail.Mail_From, sys_Mail.Mail_Password, sys_Mail.Mail_Smtp, sys_Mail.Mail_Send, sys_Mail.Mail_Carbon, sys_Mail.Mail_Subject, sys_Mail.Mail_Body + "\r\n" + sys_Mail.Mail_Signature);
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    if (gridView1.GetRowCellValue(i, "Mail_Id").ToStringEx() == sys_Mail.Mail_Id)
                    {
                        gridView1.SetRowCellValue(i, "Mail_Done", true);
                        Save();
                    }
                }
            }
            catch (Exception ex)
            {
                SharedFunc.RaiseError(ex);
                timer1.Enabled = false;
            }
        }
    }
}