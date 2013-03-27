using manas.git.gol.helpers;
using System;
namespace manas.git.gol
{
    /// <summary>
    /// EcoSystem - class represents the Grid Ecosystem
    /// </summary>
    public class EcoSystem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EcoSystem"/> class.
        /// </summary>
        /// <param name="cellGrid">The cell grid.</param>
        public EcoSystem(Cell[,] cellGrid)
        {
            if (cellGrid == null)
                throw new ArgumentNullException("cellGrid");
            this.cells = cellGrid;
            this.Rows = cellGrid.GetLength(0);
            this.Columns = cellGrid.GetLength(1);
            SetNeighbours();
        }

        /// <summary>
        /// Sets the neighbours.
        /// </summary>
        private void SetNeighbours()
        {
            foreach (var cell in cells)
            {
                cell.SetNeighbours(this);
            }
        }

        /// <summary>
        /// Gets the cells.
        /// </summary>
        /// <value>
        /// The cells.
        /// </value>
        public Cell[,] cells { get; private set; }

        /// <summary>
        /// Gets the rows.
        /// </summary>
        /// <value>
        /// The rows.
        /// </value>
        internal int Rows { get; private set; }

        /// <summary>
        /// Gets the columns.
        /// </summary>
        /// <value>
        /// The columns.
        /// </value>
        internal int Columns { get; private set; }

        /// <summary>
        /// Finds the state of the next generation.
        /// </summary>
        void FindNextGenerationState()
        {
            foreach (var cell in cells)
            {
                cell.FindNextGenerationState();
            }
        }

        /// <summary>
        /// Moves to next generation.
        /// </summary>
        public void MoveToNextGeneration()
        {
            FindNextGenerationState();
            foreach (var cell in cells)
            {
                cell.MoveToNextGeneration();
            }
        }
    }
}
