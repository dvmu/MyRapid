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
    /// Indicates how an autocompletion occurred.
    /// </summary>
    public enum ListCompletionMethod
    {
        /// <summary>
        /// A fillup character (see <see cref="Scintilla.AutoCSetFillUps" />) triggered the completion.
        /// The character used is indicated by the <see cref="AutoCSelectionEventArgs.Char" /> property.
        /// </summary>
        FillUp = NativeMethods.SC_AC_FILLUP,

        /// <summary>
        /// A double-click triggered the completion.
        /// </summary>
        DoubleClick = NativeMethods.SC_AC_DOUBLECLICK,

        /// <summary>
        /// A tab key or the <see cref="ScintillaNET.Command.Tab" /> command triggered the completion.
        /// </summary>
        Tab = NativeMethods.SC_AC_TAB,

        /// <summary>
        /// A new line or <see cref="ScintillaNET.Command.NewLine" /> command triggered the completion.
        /// </summary>
        NewLine = NativeMethods.SC_AC_NEWLINE,

        /// <summary>
        /// The <see cref="Scintilla.AutoCSelect" /> method triggered the completion.
        /// </summary>
        Command = NativeMethods.SC_AC_COMMAND
    }
}