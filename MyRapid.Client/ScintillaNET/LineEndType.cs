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
    /// Line endings types supported by lexers and allowed by a <see cref="Scintilla" /> control.
    /// </summary>
    /// <seealso cref="Scintilla.LineEndTypesSupported" />
    /// <seealso cref="Scintilla.LineEndTypesAllowed" />
    /// <seealso cref="Scintilla.LineEndTypesActive" />
    [Flags]
    public enum LineEndType
    {
        /// <summary>
        /// ASCII line endings. Carriage Return, Line Feed pair "\r\n" (0x0D0A); Carriage Return '\r' (0x0D); Line Feed '\n' (0x0A).
        /// </summary>
        Default = NativeMethods.SC_LINE_END_TYPE_DEFAULT,

        /// <summary>
        /// Unicode line endings. Next Line (0x0085); Line Separator (0x2028); Paragraph Separator (0x2029).
        /// </summary>
        Unicode = NativeMethods.SC_LINE_END_TYPE_UNICODE
    }
}