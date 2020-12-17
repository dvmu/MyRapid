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
    /// The caret visual style.
    /// </summary>
    public enum CaretStyle
    {
        /// <summary>
        /// The caret is not displayed.
        /// </summary>
        Invisible = NativeMethods.CARETSTYLE_INVISIBLE,

        /// <summary>
        /// The caret is drawn as a vertical line.
        /// </summary>
        Line = NativeMethods.CARETSTYLE_LINE,

        /// <summary>
        /// The caret is drawn as a block.
        /// </summary>
        Block = NativeMethods.CARETSTYLE_BLOCK
    }
}