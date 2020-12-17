/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;

namespace ScintillaNET
{
    /// <summary>
    /// Specifies the change that triggered a <see cref="Scintilla.UpdateUI" /> event.
    /// </summary>
    /// <remarks>This enumeration has a FlagsAttribute attribute that allows a bitwise combination of its member values.</remarks>
    [Flags]
    public enum UpdateChange
    {
        /// <summary>
        /// Contents, styling or markers have been changed.
        /// </summary>
        Content = NativeMethods.SC_UPDATE_CONTENT,

        /// <summary>
        /// Selection has been changed.
        /// </summary>
        Selection = NativeMethods.SC_UPDATE_SELECTION,

        /// <summary>
        /// Scrolled vertically.
        /// </summary>
        VScroll = NativeMethods.SC_UPDATE_V_SCROLL,

        /// <summary>
        /// Scrolled horizontally.
        /// </summary>
        HScroll = NativeMethods.SC_UPDATE_H_SCROLL
    }
}