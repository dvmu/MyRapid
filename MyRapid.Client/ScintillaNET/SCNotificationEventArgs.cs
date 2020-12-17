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

namespace ScintillaNET
{
    // For internal use only
    internal sealed class SCNotificationEventArgs : EventArgs
    {
        public NativeMethods.SCNotification SCNotification { get; private set; }

        public SCNotificationEventArgs(NativeMethods.SCNotification scn)
        {
            this.SCNotification = scn;
        }
    }
}