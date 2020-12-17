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
    /// Options for displaying indentation guides in a <see cref="Scintilla" /> control.
    /// </summary>
    /// <remarks>Indentation guides can be styled using the <see cref="Style.IndentGuide" /> style.</remarks>
    public enum IndentView
    {
        /// <summary>
        /// No indentation guides are shown. This is the default.
        /// </summary>
        None = NativeMethods.SC_IV_NONE,

        /// <summary>
        /// Indentation guides are shown inside real indentation whitespace.
        /// </summary>
        Real = NativeMethods.SC_IV_REAL,

        /// <summary>
        /// Indentation guides are shown beyond the actual indentation up to the level of the next non-empty line.
        /// If the previous non-empty line was a fold header then indentation guides are shown for one more level of indent than that line.
        /// This setting is good for Python.
        /// </summary>
        LookForward = NativeMethods.SC_IV_LOOKFORWARD,

        /// <summary>
        /// Indentation guides are shown beyond the actual indentation up to the level of the next non-empty line or previous non-empty line whichever is the greater.
        /// This setting is good for most languages.
        /// </summary>
        LookBoth = NativeMethods.SC_IV_LOOKBOTH
    }
}