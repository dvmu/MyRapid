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
    /// Additional location options for line wrapping visual indicators.
    /// </summary>
    public enum WrapVisualFlagLocation
    {
        /// <summary>
        /// Wrap indicators are drawn near the border. This is the default.
        /// </summary>
        Default = NativeMethods.SC_WRAPVISUALFLAGLOC_DEFAULT,

        /// <summary>
        /// Wrap indicators are drawn at the end of sublines near the text.
        /// </summary>
        EndByText = NativeMethods.SC_WRAPVISUALFLAGLOC_END_BY_TEXT,

        /// <summary>
        /// Wrap indicators are drawn at the beginning of sublines near the text.
        /// </summary>
        StartByText = NativeMethods.SC_WRAPVISUALFLAGLOC_START_BY_TEXT
    }
}