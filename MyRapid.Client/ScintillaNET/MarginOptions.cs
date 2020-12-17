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
    /// Flags used to define margin options.
    /// </summary>
    /// <remarks>This enumeration has a FlagsAttribute attribute that allows a bitwise combination of its member values.</remarks>
    [Flags]
    public enum MarginOptions
    {
        /// <summary>
        /// No options. This is the default.
        /// </summary>
        None = NativeMethods.SC_MARGINOPTION_NONE,

        /// <summary>
        /// Lines selected by clicking on the margin will select only the subline of wrapped text.
        /// </summary>
        SublineSelect = NativeMethods.SC_MARGINOPTION_SUBLINESELECT
    }
}