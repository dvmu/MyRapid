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
    /// Visibility and location of annotations in a <see cref="Scintilla" /> control
    /// </summary>
    public enum Annotation
    {
        /// <summary>
        /// Annotations are not displayed. This is the default.
        /// </summary>
        Hidden = NativeMethods.ANNOTATION_HIDDEN,

        /// <summary>
        /// Annotations are drawn left justified with no adornment.
        /// </summary>
        Standard = NativeMethods.ANNOTATION_STANDARD,

        /// <summary>
        /// Annotations are indented to match the text and are surrounded by a box.
        /// </summary>
        Boxed = NativeMethods.ANNOTATION_BOXED,

        /// <summary>
        /// Annotations are indented to match the text.
        /// </summary>
        Indented = NativeMethods.ANNOTATION_INDENTED
    }
}