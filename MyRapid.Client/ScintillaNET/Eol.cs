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
    /// End-of-line format.
    /// </summary>
    public enum Eol
    {
        /// <summary>
        /// Carriage Return, Line Feed pair "\r\n" (0x0D0A).
        /// </summary>
        CrLf = NativeMethods.SC_EOL_CRLF,

        /// <summary>
        /// Carriage Return '\r' (0x0D).
        /// </summary>
        Cr = NativeMethods.SC_EOL_CR,

        /// <summary>
        /// Line Feed '\n' (0x0A).
        /// </summary>
        Lf = NativeMethods.SC_EOL_LF
    }
}