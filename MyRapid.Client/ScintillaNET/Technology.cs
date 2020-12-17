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
    /// The rendering technology used in a <see cref="Scintilla" /> control.
    /// </summary>
    public enum Technology
    {
        /// <summary>
        /// Renders text using GDI. This is the default.
        /// </summary>
        Default = NativeMethods.SC_TECHNOLOGY_DEFAULT,

        /// <summary>
        /// Renders text using Direct2D/DirectWrite. Since Direct2D buffers drawing,
        /// Scintilla's buffering can be turned off with <see cref="Scintilla.BufferedDraw" />.
        /// </summary>
        DirectWrite = NativeMethods.SC_TECHNOLOGY_DIRECTWRITE
    }
}