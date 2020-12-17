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
    /// Specifies the display mode of whitespace characters.
    /// </summary>
    public enum WhitespaceMode
    {
        /// <summary>
        /// The normal display mode with whitespace displayed as an empty background color.
        /// </summary>
        Invisible = NativeMethods.SCWS_INVISIBLE,

        /// <summary>
        /// Whitespace characters are drawn as dots and arrows.
        /// </summary>
        VisibleAlways = NativeMethods.SCWS_VISIBLEALWAYS,

        /// <summary>
        /// Whitespace used for indentation is displayed normally but after the first visible character,
        /// it is shown as dots and arrows.
        /// </summary>
        VisibleAfterIndent = NativeMethods.SCWS_VISIBLEAFTERINDENT,

        /// <summary>
        /// Whitespace used for indentation is displayed as dots and arrows.
        /// </summary>
        VisibleOnlyIndent = NativeMethods.SCWS_VISIBLEONLYININDENT
    }
}