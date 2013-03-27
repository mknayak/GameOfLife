using manas.git.gol.helpers;
using System;
using System.Collections.Generic;
namespace manas.git.gol
{
    /// <summary>
    /// Cell - Class represents a single cell in grid
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Position position { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public CellState State { get; set; }

        /// <summary>
        /// Gets or sets the neighbours.
        /// </summary>
        /// <value>
        /// The neighbours.
        /// </value>
        public IEnumerable<Cell> Neighbours { get; set; }

        /// <summary>
        /// Gets or sets the state of the next generation.
        /// </summary>
        /// <value>
        /// The state of the next generation.
        /// </value>
        public CellState NextGenerationState { get; set; }

        /// <summary>
        /// Moves to next generation.
        /// </summary>
        public void MoveToNextGeneration()
        {
            if (this.NextGenerationState.Equals(CellState.None))
                throw new Exception("Please call FindNextGenerationState, before moving to next generation");

            this.State = this.NextGenerationState;
            this.NextGenerationState = CellState.None;
        }

        /// <summary>
        /// Finds the state of the next generation.
        /// </summary>
        public void FindNextGenerationState()
        {
            if (this.Neighbours == null)
                throw new Exception("Cell must have neighbours. Please Set neighbour before moving to next generation");
            this.EvaluateNextGenerationState();
        }
    }
}
