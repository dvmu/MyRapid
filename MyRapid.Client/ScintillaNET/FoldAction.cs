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
    /// Fold actions.
    /// </summary>
    public enum FoldAction
    {
        /// <summary>
        /// Contract the fold.
        /// </summary>
        Contract = NativeMethods.SC_FOLDACTION_CONTRACT,

        /// <summary>
        /// Expand the fold.
        /// </summary>
        Expand = NativeMethods.SC_FOLDACTION_EXPAND,

        /// <summary>
        /// Toggle between contracted and expanded.
        /// </summary>
        Toggle = NativeMethods.SC_FOLDACTION_TOGGLE
    }
}