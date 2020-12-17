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
    /// The long line edge display mode.
    /// </summary>
    public enum EdgeMode
    {
        /// <summary>
        /// Long lines are not indicated. This is the default.
        /// </summary>
        None = NativeMethods.EDGE_NONE,

        /// <summary>
        /// Long lines are indicated with a vertical line.
        /// </summary>
        Line = NativeMethods.EDGE_LINE,

        /// <summary>
        /// Long lines are indicated with a background color.
        /// </summary>
        Background = NativeMethods.EDGE_BACKGROUND,

        /// <summary>
        /// Similar to <see cref="Line" /> except allows for multiple vertical lines to be visible using the <see cref="Scintilla.MultiEdgeAddLine" /> method.
        /// </summary>
        /// <remarks><see cref="Line" /> and <see cref="Scintilla.EdgeColumn" /> are completely independant of this mode.</remarks>
        MultiLine = NativeMethods.EDGE_MULTILINE
    }
}