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
    /// Specifies the clipboard formats to copy.
    /// </summary>
    [Flags]
    public enum CopyFormat
    {
        /// <summary>
        /// Copies text to the clipboard in Unicode format.
        /// </summary>
        Text = 1 << 0,

        /// <summary>
        /// Copies text to the clipboard in Rich Text Format (RTF).
        /// </summary>
        Rtf = 1 << 1,

        /// <summary>
        /// Copies text to the clipboard in HyperText Markup Language (HTML) format.
        /// </summary>
        Html = 1 << 2
    }
}