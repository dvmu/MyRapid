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
    /// Configuration options for automatic code folding.
    /// </summary>
    /// <remarks>This enumeration has a FlagsAttribute attribute that allows a bitwise combination of its member values.</remarks>
    [Flags]
    public enum AutomaticFold
    {
        /// <summary>
        /// Automatic folding is disabled. This is the default.
        /// </summary>
        None = 0,

        /// <summary>
        /// Automatically show lines as needed. The <see cref="Scintilla.NeedShown" /> event is not raised when this value is used.
        /// </summary>
        Show = NativeMethods.SC_AUTOMATICFOLD_SHOW,

        /// <summary>
        /// Handle clicks in fold margin automatically. The <see cref="Scintilla.MarginClick" /> event is not raised for folding margins when this value is used.
        /// </summary>
        Click = NativeMethods.SC_AUTOMATICFOLD_CLICK,

        /// <summary>
        /// Show lines as needed when the fold structure is changed.
        /// </summary>
        Change = NativeMethods.SC_AUTOMATICFOLD_CHANGE
    }
}