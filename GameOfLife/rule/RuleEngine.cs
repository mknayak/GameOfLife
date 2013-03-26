using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace manas.git.gol.rule
{
    public static class RuleEngine
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
            if (currentCell.State.Equals(CellState.None))
            {
                return;
            }
            int aliveNeighbours = currentCell.Neighbours.Where(c => c.State.Equals(CellState.Alive)).Count();
            CellState nextGenState=CellState.Dead;
            if (currentCell.State.Equals(CellState.Alive))
            {
                if (aliveNeighbours == 2 || aliveNeighbours == 3)
                {
                    nextGenState = CellState.Alive;
                }
            }
            else if (currentCell.State.Equals(CellState.Dead))
            {
                if (aliveNeighbours == 3)
                {
                    nextGenState = CellState.Alive;
                }
            }

            currentCell.NextGenerationState = nextGenState;
        }
    }
}
