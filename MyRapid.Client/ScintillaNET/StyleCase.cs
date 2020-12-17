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
    /// The possible casing styles of a style.
    /// </summary>
    public enum StyleCase
    {
        /// <summary>
        /// Display the text normally.
        /// </summary>
        Mixed = NativeMethods.SC_CASE_MIXED,

        /// <summary>
        /// Display the text in upper case.
        /// </summary>
        Upper = NativeMethods.SC_CASE_UPPER,

        /// <summary>
        /// Display the text in lower case.
        /// </summary>
        Lower = NativeMethods.SC_CASE_LOWER,

        /// <summary>
        /// Display the text in camel case.
        /// </summary>
        Camel = NativeMethods.SC_CASE_CAMEL
    }
}