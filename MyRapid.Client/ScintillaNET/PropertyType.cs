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
    /// Lexer property types.
    /// </summary>
    public enum PropertyType
    {
        /// <summary>
        /// A Boolean property. This is the default.
        /// </summary>
        Boolean = NativeMethods.SC_TYPE_BOOLEAN,

        /// <summary>
        /// An integer property.
        /// </summary>
        Integer = NativeMethods.SC_TYPE_INTEGER,

        /// <summary>
        /// A string property.
        /// </summary>
        String = NativeMethods.SC_TYPE_STRING
    }
}