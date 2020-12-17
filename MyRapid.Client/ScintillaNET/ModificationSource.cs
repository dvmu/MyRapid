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
    /// The source of a modification
    /// </summary>
    public enum ModificationSource
    {
        /// <summary>
        /// Modification is the result of a user operation.
        /// </summary>
        User = NativeMethods.SC_PERFORMED_USER,

        /// <summary>
        /// Modification is the result of an undo operation.
        /// </summary>
        Undo = NativeMethods.SC_PERFORMED_UNDO,

        /// <summary>
        /// Modification is the result of a redo operation.
        /// </summary>
        Redo = NativeMethods.SC_PERFORMED_REDO
    }
}