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
    /// The display of a cursor when over a margin.
    /// </summary>
    public enum MarginCursor
    {
        /// <summary>
        /// A normal arrow.
        /// </summary>
        Arrow = NativeMethods.SC_CURSORARROW,

        /// <summary>
        /// A reversed arrow.
        /// </summary>
        ReverseArrow = NativeMethods.SC_CURSORREVERSEARROW
    }
}