/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace MyRapid.Code
{
    public static class ThreadHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="easySub"></param>
        public static void Start(Action easySub)
        {
            Task task = new Task(easySub);
            task.Start();
        }
        public static void Start(Action<object> easySub, object state)
        {
            Task task = new Task(easySub, state);
            task.Start();
        }
        public static long UsedMemory()
        {
            Process process = Process.GetCurrentProcess();
            long usedMemory = process.WorkingSet64;
            usedMemory = usedMemory / 1024 / 1024;
            return usedMemory;
        }

        private static List<System.Windows.Forms.Timer> Tup = new List<System.Windows.Forms.Timer>();
        public static void DelayRun(Action easySub, string keyName)
        {
            System.Windows.Forms.Timer lastTimer = Tup.Find(t => t.Tag.ToStringEx() == keyName);
            if (lastTimer != null)
            {
                lastTimer.Enabled = false;
                lastTimer.Enabled = true;
            }

            if (lastTimer == null)
            {
                System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
                t.Interval = 501;
                t.Enabled = true;
                t.Tag = keyName;
                Tup.Add(t);
                t.Tick += delegate (object sender, EventArgs e)
                {
                    ((System.Windows.Forms.Timer)sender).Enabled = false;
                    string name = keyName;
                    easySub();

                };
            }
        }
    }
}