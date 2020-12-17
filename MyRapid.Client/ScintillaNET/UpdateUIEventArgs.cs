/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;

namespace ScintillaNET
{
    /// <summary>
    /// Provides data for the <see cref="Scintilla.UpdateUI" /> event.
    /// </summary>
    public class UpdateUIEventArgs : EventArgs
    {
        #region Properties

        /// <summary>
        /// The UI update that occurred.
        /// </summary>
        /// <returns>A bitwise combination of <see cref="UpdateChange" /> values specifying the UI update that occurred.</returns>
        public UpdateChange Change { get; private set; }

        #endregion Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUIEventArgs" /> class.
        /// </summary>
        /// <param name="change">A bitwise combination of <see cref="UpdateChange" /> values specifying the reason to update the UI.</param>
        public UpdateUIEventArgs(UpdateChange change)
        {
            Change = change;
        }

        #endregion Constructors
    }
}