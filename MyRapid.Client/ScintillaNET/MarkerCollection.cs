/*******************************************************************************
 * Copyright © 2010-2020  陈恩点版权所有
 * 初版作者: 陈恩点
 * 创建时间: 2012/8/21 11:49:53
 * 联系方式: 18115503914
 * 简单描述: MyRapid快速开发框架
*********************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScintillaNET
{
    /// <summary>
    /// An immutable collection of markers in a <see cref="Scintilla" /> control.
    /// </summary>
    public class MarkerCollection : IEnumerable<Marker>
    {
        private readonly Scintilla scintilla;

        /// <summary>
        /// Provides an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An object for enumerating all <see cref="Marker" /> objects within the <see cref="MarkerCollection" />.</returns>
        public IEnumerator<Marker> GetEnumerator()
        {
            int count = Count;
            for (int i = 0; i < count; i++)
                yield return this[i];

            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Gets the number of markers in the <see cref="MarkerCollection" />.
        /// </summary>
        /// <returns>This property always returns 32.</returns>
        public int Count
        {
            get
            {
                return (NativeMethods.MARKER_MAX + 1);
            }
        }

        /// <summary>
        /// Gets a <see cref="Marker" /> object at the specified index.
        /// </summary>
        /// <param name="index">The marker index.</param>
        /// <returns>An object representing the marker at the specified <paramref name="index" />.</returns>
        /// <remarks>Markers 25 through 31 are used by Scintilla for folding.</remarks>
        public Marker this[int index]
        {
            get
            {
                index = Helpers.Clamp(index, 0, Count - 1);
                return new Marker(scintilla, index);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MarkerCollection" /> class.
        /// </summary>
        /// <param name="scintilla">The <see cref="Scintilla" /> control that created this collection.</param>
        public MarkerCollection(Scintilla scintilla)
        {
            this.scintilla = scintilla;
        }
    }
}