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
    /// The behavior and appearance of a margin.
    /// </summary>
    public enum MarginType
    {
        /// <summary>
        /// Margin can display symbols.
        /// </summary>
        Symbol = NativeMethods.SC_MARGIN_SYMBOL,

        /// <summary>
        /// Margin displays line numbers.
        /// </summary>
        Number = NativeMethods.SC_MARGIN_NUMBER,

        /// <summary>
        /// Margin can display symbols and has a background color equivalent to <see cref="Style.Default" /> background color.
        /// </summary>
        BackColor = NativeMethods.SC_MARGIN_BACK,

        /// <summary>
        /// Margin can display symbols and has a background color equivalent to <see cref="Style.Default"/> foreground color.
        /// </summary>
        ForeColor = NativeMethods.SC_MARGIN_FORE,

        /// <summary>
        /// Margin can display application defined text.
        /// </summary>
        Text = NativeMethods.SC_MARGIN_TEXT,

        /// <summary>
        /// Margin can display application defined text right-justified.
        /// </summary>
        RightText = NativeMethods.SC_MARGIN_RTEXT,

        /// <summary>
        /// Margin can display symbols and has a background color specified using the <see cref="Margin.BackColor" /> property.
        /// </summary>
        Color = NativeMethods.SC_MARGIN_COLOUR
    }
}