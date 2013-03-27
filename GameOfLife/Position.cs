using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace manas.git.gol
{
    /// <summary>
    /// Position - class represents the position of cell
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <param name="column">The column.</param>
        public Position(int row,int column)
        {
            if (row < 0)
                throw new ArgumentOutOfRangeException("row", "row can not be less than 0");
            if (column < 0)
                throw new ArgumentOutOfRangeException("column", "column can not be less than 0");

            this.row = row;
            this.column = column;
        }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        /// <value>
        /// The row.
        /// </value>
        public int row { get; private set; }
        /// <summary>
        /// Gets or sets the column.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        public int column { get; private set; }
    }
}
