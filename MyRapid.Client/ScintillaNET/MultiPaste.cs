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
    /// Specifies the behavior of pasting into multiple selections.
    /// </summary>
    public enum MultiPaste
    {
        /// <summary>
        /// Pasting into multiple selections only pastes to the main selection. This is the default.
        /// </summary>
        Once = NativeMethods.SC_MULTIPASTE_ONCE,

        /// <summary>
        /// Pasting into multiple selections pastes into each selection.
        /// </summary>
        Each = NativeMethods.SC_MULTIPASTE_EACH
    }
}