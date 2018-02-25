﻿using System;
using System.Diagnostics;
using System.Text;

namespace NDbfReader
{
    /// <summary>
    /// Represents a <see cref="bool"/> column.
    /// </summary>
    [DebuggerDisplay("Boolean {Name}")]
    public class BooleanColumn : Column<bool?>
    {
        /// <summary>
        /// Initializes a new instance with the specified name and offset.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <param name="offset">The column offset in a row.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is <c>null</c> or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/> is &lt; 0.</exception>
        public BooleanColumn(string name, int offset)
            : base(name, offset, size: 1)
        {
        }

        /// <summary>
        /// Loads a value from the specified buffer.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="offset">The offset in <paramref name="buffer"/> at which to begin loading the value.</param>
        /// <param name="encoding">The encoding to use to parse the value.</param>
        /// <returns>A column value.</returns>
        protected override bool? DoLoad(byte[] buffer, int offset, Encoding encoding)
        {
            char charValue = char.ToUpper((char)buffer[offset]);
            switch (charValue)
            {
                case 'T':
                case 'Y':
                    return true;

                case 'F':
                case 'N':
                    return false;

                default:
                    return null;
            }
        }
    }
}