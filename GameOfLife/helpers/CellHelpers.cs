using System.Collections.Generic;
using System.Linq;

namespace manas.git.gol.helpers
{
    /// <summary>
    /// CellHelpers - class contains cell extensions
    /// </summary>
    public static class CellHelpers
    {
        /// <summary>
        /// Evaluates the state of the next generation.
        /// </summary>
        /// <param name="currentCell">The current cell.</param>
        public static void EvaluateNextGenerationState(this Cell currentCell)
        {
            //Any live cell with fewer than two live neighbours dies, as if caused by under-population.
            //Any live cell with two or three live neighbours lives on to the next generation.
            //Any live cell with more than three live neighbours dies, as if by overcrowding.
            //Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

            int aliveNeighbours = currentCell.Neighbours.Count(c => c.State.Equals(CellState.Alive));
            CellState nextGenState = CellState.Dead;
            if (currentCell.State.Equals(CellState.Alive) &&
                (aliveNeighbours == 2 || aliveNeighbours == 3))
            {
                nextGenState = CellState.Alive;
            }
            else if (currentCell.State.Equals(CellState.Dead) 
                && aliveNeighbours == 3)
            {
                nextGenState = CellState.Alive;
            }

            currentCell.NextGenerationState = nextGenState;
        }

        /// <summary>
        /// Sets the neighbours.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="system">The system.</param>
        public static void SetNeighbours(this Cell cell, EcoSystem system)
        {
            List<Cell> neighbours = new List<Cell>();
            AddTopCell(cell, system, neighbours);
            AddBottomCell(cell, system, neighbours);
            AddRightCell(cell, system, neighbours);
            AddLeftCell(cell, system, neighbours);
            AddTopRightCell(cell, system, neighbours);
            AddTopLeftCell(cell, system, neighbours);
            AddBottomRightCell(cell, system, neighbours);
            AddBottomLeftCell(cell, system, neighbours);
            cell.Neighbours = neighbours;
        }

        #region Private methods
        /// <summary>
        /// Adds the top cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="system">The system.</param>
        /// <param name="neighbours">The neighbours.</param>
        private static void AddTopCell(Cell cell, EcoSystem system, List<Cell> neighbours)
        {
            if (cell.position.row.Equals(0)) return;

            Cell neighbour = system.cells[cell.position.row - 1, cell.position.column];
            if (neighbour != null) neighbours.Add(neighbour);
        }

        /// <summary>
        /// Adds the bottom cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="system">The system.</param>
        /// <param name="neighbours">The neighbours.</param>
        private static void AddBottomCell(Cell cell, EcoSystem system, List<Cell> neighbours)
        {
            if (cell.position.row + 1 >= system.Rows) return;

            Cell neighbour = system.cells[cell.position.row + 1, cell.position.column];
            if (neighbour != null) neighbours.Add(neighbour);
        }

        /// <summary>
        /// Adds the right cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="system">The system.</param>
        /// <param name="neighbours">The neighbours.</param>
        private static void AddRightCell(Cell cell, EcoSystem system, List<Cell> neighbours)
        {
            if (cell.position.column + 1 >= system.Columns) return;

            Cell neighbour = system.cells[cell.position.row, cell.position.column + 1];
            if (neighbour != null) neighbours.Add(neighbour);
        }

        /// <summary>
        /// Adds the left cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="system">The system.</param>
        /// <param name="neighbours">The neighbours.</param>
        private static void AddLeftCell(Cell cell, EcoSystem system, List<Cell> neighbours)
        {
            if (cell.position.column.Equals(0)) return;

            Cell neighbour = system.cells[cell.position.row, cell.position.column - 1];
            if (neighbour != null) neighbours.Add(neighbour);
        }

        /// <summary>
        /// Adds the top right cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="system">The system.</param>
        /// <param name="neighbours">The neighbours.</param>
        private static void AddTopRightCell(Cell cell, EcoSystem system, List<Cell> neighbours)
        {
            if (cell.position.row.Equals(0) ||
                cell.position.column + 1 >= system.Columns) return;

            Cell neighbour = system.cells[cell.position.row - 1, cell.position.column + 1];
            if (neighbour != null) neighbours.Add(neighbour);
        }

        /// <summary>
        /// Adds the top left cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="system">The system.</param>
        /// <param name="neighbours">The neighbours.</param>
        private static void AddTopLeftCell(Cell cell, EcoSystem system, List<Cell> neighbours)
        {
            if (cell.position.row.Equals(0) ||
                cell.position.column.Equals(0)) return;

            Cell neighbour = system.cells[cell.position.row - 1, cell.position.column - 1];
            if (neighbour != null) neighbours.Add(neighbour);
        }

        /// <summary>
        /// Adds the bottom right cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="system">The system.</param>
        /// <param name="neighbours">The neighbours.</param>
        private static void AddBottomRightCell(Cell cell, EcoSystem system, List<Cell> neighbours)
        {
            if (cell.position.row + 1 >= system.Rows ||
                cell.position.column + 1 >= system.Columns) return;

            Cell neighbour = system.cells[cell.position.row + 1, cell.position.column + 1];
            if (neighbour != null) neighbours.Add(neighbour);
        }

        /// <summary>
        /// Adds the bottom left cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <param name="system">The system.</param>
        /// <param name="neighbours">The neighbours.</param>
        private static void AddBottomLeftCell(Cell cell, EcoSystem system, List<Cell> neighbours)
        {
            if (cell.position.row + 1 >= system.Rows ||
                cell.position.column.Equals(0)) return;

            Cell neighbour = system.cells[cell.position.row + 1, cell.position.column - 1];
            if (neighbour != null) neighbours.Add(neighbour);
        }
        #endregion
    }
}
