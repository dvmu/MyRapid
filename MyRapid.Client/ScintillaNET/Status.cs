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
    /// Possible status codes returned by the <see cref="Scintilla.Status" /> property.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// No failures.
        /// </summary>
        Ok = NativeMethods.SC_STATUS_OK,

        /// <summary>
        /// Generic failure.
        /// </summary>
        Failure = NativeMethods.SC_STATUS_FAILURE,

        /// <summary>
        /// Memory is exhausted.
        /// </summary>
        BadAlloc = NativeMethods.SC_STATUS_BADALLOC,

        /// <summary>
        /// Regular expression is invalid.
        /// </summary>
        WarnRegex = NativeMethods.SC_STATUS_WARN_REGEX
    }
}