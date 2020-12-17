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
    /// Enables virtual space for rectangular selections or in other circumstances or in both.
    /// </summary>
    /// <remarks>This enumeration has a FlagsAttribute attribute that allows a bitwise combination of its member values.</remarks>
    [Flags]
    public enum VirtualSpace
    {
        /// <summary>
        /// Virtual space is not enabled. This is the default.
        /// </summary>
        None = NativeMethods.SCVS_NONE,

        /// <summary>
        /// Virtual space is enabled for rectangular selections.
        /// </summary>
        RectangularSelection = NativeMethods.SCVS_RECTANGULARSELECTION,

        /// <summary>
        /// Virtual space is user accessible.
        /// </summary>
        UserAccessible = NativeMethods.SCVS_USERACCESSIBLE,

        /// <summary>
        /// Prevents left arrow movement and selection from wrapping to the previous line.
        /// </summary>
        NoWrapLineStart = NativeMethods.SCVS_NOWRAPLINESTART
    }
}