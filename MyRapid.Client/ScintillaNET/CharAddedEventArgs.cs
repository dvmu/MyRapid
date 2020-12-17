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
    /// Provides data for the <see cref="Scintilla.CharAdded" /> event.
    /// </summary>
    public class CharAddedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the text character added to a <see cref="Scintilla" /> control.
        /// </summary>
        /// <returns>The character added.</returns>
        public int Char { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CharAddedEventArgs" /> class.
        /// </summary>
        /// <param name="ch">The character added.</param>
        public CharAddedEventArgs(int ch)
        {
            Char = ch;
        }
    }
}