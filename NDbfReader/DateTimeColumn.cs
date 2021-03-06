﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace NDbfReader
{
    /// <summary>
    /// Represents a date column.
    /// </summary>
    [DebuggerDisplay("Date {Name}")]
    public class DateTimeColumn : Column<DateTime?>
    {
        private const int SIZE = 8;

        /// <summary>
        /// Initializes a new instance with the specified name and offset.
        /// </summary>
        /// <param name="name">The column name.</param>
        /// <param name="offset">The column offset in a row.</param>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is <c>null</c> or empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="offset"/> is &lt; 0.</exception>
        public DateTimeColumn(string name, int offset)
            : base(name, offset, SIZE)
        {
        }

        /// <summary>
        /// Loads a value from the specified buffer.
        /// </summary>
        /// <param name="buffer">The source buffer.</param>
        /// <param name="offset">The offset in <paramref name="buffer"/> at which to begin loading the value.</param>
        /// <param name="encoding">The encoding to use to parse the value.</param>
        /// <returns>A column value.</returns>
        protected override DateTime? DoLoad(byte[] buffer, int offset, Encoding encoding)
        {
            string stringValue = encoding.GetString(buffer, offset, SIZE);
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                return null;
            }
            return DateTime.ParseExact(stringValue, "yyyyMMdd", null, DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowTrailingWhite);
        }
    }
}