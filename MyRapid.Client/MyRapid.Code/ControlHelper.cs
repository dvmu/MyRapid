/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyRapid.Code
{
    public static class ControlHelper
    {
        /// <summary>
        /// 为控件添加移动功能
        /// </summary>
        /// <param name="ctrl">鼠标按下的控件</param>
        /// <param name="who">移动的控件(若不存在则为控件自己) 
        /// 1:控件所在窗体; 
        /// 2:控件的父级; 
        /// 3:控件自己. </param>
        public static void MoveHandle(Control ctrl, int who = 1)
        {
            try
            {
                Control mCtrl;//= ctrl.FindForm();
                switch (who)
                {
                    case 1:
                        mCtrl = ctrl.FindForm();
                        break;
                    case 2:
                        mCtrl = ctrl.Parent;
                        break;
                    case 3:
                        mCtrl = ctrl;
                        break;
                    default:
                        mCtrl = ctrl.FindForm();
                        break;
                }
                if (mCtrl == null)
                {
                    mCtrl = ctrl;
                }

                Point sourcePoint = new Point(0, 0);
                bool isMove = false;
                ctrl.MouseDown += delegate (object sender, MouseEventArgs e)
                {
                    sourcePoint = e.Location;
                    isMove = true;
                };
                ctrl.MouseMove += delegate (object sender, MouseEventArgs e)
                {
                    if (isMove)
                        mCtrl.Location = new Point(mCtrl.Location.X + e.X - sourcePoint.X, mCtrl.Location.Y + e.Y - sourcePoint.Y);
                };
                ctrl.MouseUp += delegate (object sender, MouseEventArgs e)
                {
                    isMove = false;
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}