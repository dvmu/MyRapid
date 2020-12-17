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
    /// Flags associated with a <see cref="Indicator" />.
    /// </summary>
    /// <remarks>This enumeration has a FlagsAttribute attribute that allows a bitwise combination of its member values.</remarks>
    [Flags]
    public enum IndicatorFlags
    {
        /// <summary>
        /// No flags. This is the default.
        /// </summary>
        None = 0,

        /// <summary>
        /// When set, will treat an indicator value as a RGB color that has been OR'd with <see cref="Indicator.ValueBit" />
        /// and will use that instead of the value specified in the <see cref="Indicator.ForeColor" /> property. This allows
        /// an indicator to display more than one color.
        /// </summary>
        ValueFore = NativeMethods.SC_INDICFLAG_VALUEFORE
    }
}