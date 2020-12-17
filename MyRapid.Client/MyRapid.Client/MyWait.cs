/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraSplashScreen;
namespace MyRapid.Client
{
    public partial class MyWait : SplashScreen
    {
        public MyWait()
        {
            InitializeComponent();
        }
        #region Overrides
        int EndValue = 0;
        public override void ProcessCommand(Enum cmd, object arg)
        {
            base.ProcessCommand(cmd, arg);
            if(((SplashScreenCommand)cmd).Equals(SplashScreenCommand.Setinfo))
            {
                MyWaitInfo pos  = (MyWaitInfo)arg;
                progressBarControl1.EditValue = EndValue;
                EndValue = pos.ProgressInt;
                labelControl1.Text = pos.ProgressText;
            }
        }
        #endregion
        public enum SplashScreenCommand
        {
            Setinfo
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBarControl1.Position < EndValue)
            {
                progressBarControl1.Position += (EndValue - progressBarControl1.Position) / 10;
            }
        }
        private void MyWait_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void labelControl2_Click(object sender, EventArgs e)
        {

        }
    }
    public class MyWaitInfo
    {
        public int ProgressInt
        {
            get; set;
        }
        public string ProgressText
        {
            get; set;
        }
    }
}