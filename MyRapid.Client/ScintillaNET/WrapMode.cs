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
    /// The line wrapping strategy.
    /// </summary>
    public enum WrapMode
    {
        /// <summary>
        /// Line wrapping is disabled. This is the default.
        /// </summary>
        None = NativeMethods.SC_WRAP_NONE,

        /// <summary>
        /// Lines are wrapped on word or style boundaries.
        /// </summary>
        Word = NativeMethods.SC_WRAP_WORD,

        /// <summary>
        /// Lines are wrapped between any character.
        /// </summary>
        Char = NativeMethods.SC_WRAP_CHAR,

        /// <summary>
        /// Lines are wrapped on whitespace.
        /// </summary>
        Whitespace = NativeMethods.SC_WRAP_WHITESPACE
    }
}