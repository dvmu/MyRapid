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
    /// Additional display options for folds.
    /// </summary>
    [Flags]
    public enum FoldFlags
    {
        /// <summary>
        /// A line is drawn above if expanded.
        /// </summary>
        LineBeforeExpanded = NativeMethods.SC_FOLDFLAG_LINEBEFORE_EXPANDED,

        /// <summary>
        /// A line is drawn above if not expanded.
        /// </summary>
        LineBeforeContracted = NativeMethods.SC_FOLDFLAG_LINEBEFORE_CONTRACTED,

        /// <summary>
        /// A line is drawn below if expanded.
        /// </summary>
        LineAfterExpanded = NativeMethods.SC_FOLDFLAG_LINEAFTER_EXPANDED,

        /// <summary>
        /// A line is drawn below if not expanded.
        /// </summary>
        LineAfterContracted = NativeMethods.SC_FOLDFLAG_LINEAFTER_CONTRACTED,

        /// <summary>
        /// Displays the hexadecimal fold levels in the margin to aid with debugging.
        /// This feature may change in the future.
        /// </summary>
        LevelNumbers = NativeMethods.SC_FOLDFLAG_LEVELNUMBERS,

        /// <summary>
        /// Displays the hexadecimal line state in the margin to aid with debugging. This flag
        /// cannot be used at the same time as the <see cref="LevelNumbers" /> flag.
        /// </summary>
        LineState = NativeMethods.SC_FOLDFLAG_LINESTATE
    }
}