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
    /// <summary>
    /// The sorting order for autocompletion lists.
    /// </summary>
    public enum Order
    {
        /// <summary>
        /// Requires that an autocompletion lists be sorted in alphabetical order. This is the default.
        /// </summary>
        Presorted = NativeMethods.SC_ORDER_PRESORTED,

        /// <summary>
        /// Instructs a <see cref="Scintilla" /> control to perform an alphabetical sort of autocompletion lists.
        /// </summary>
        PerformSort = NativeMethods.SC_ORDER_PERFORMSORT,

        /// <summary>
        /// User-defined order.
        /// </summary>
        Custom = NativeMethods.SC_ORDER_CUSTOM
    }
}