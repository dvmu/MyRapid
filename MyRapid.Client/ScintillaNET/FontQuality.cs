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
    /// The font quality (antialiasing method) used to render text.
    /// </summary>
    public enum FontQuality
    {
        /// <summary>
        /// Specifies that the character quality of the font does not matter; so the lowest quality can be used.
        /// This is the default.
        /// </summary>
        Default = NativeMethods.SC_EFF_QUALITY_DEFAULT,

        /// <summary>
        /// Specifies that anti-aliasing should not be used when rendering text.
        /// </summary>
        NonAntiAliased = NativeMethods.SC_EFF_QUALITY_NON_ANTIALIASED,

        /// <summary>
        /// Specifies that anti-aliasing should be used when rendering text, if the font supports it.
        /// </summary>
        AntiAliased = NativeMethods.SC_EFF_QUALITY_ANTIALIASED,

        /// <summary>
        /// Specifies that ClearType anti-aliasing should be used when rendering text, if the font supports it.
        /// </summary>
        LcdOptimized = NativeMethods.SC_EFF_QUALITY_LCD_OPTIMIZED
    }
}