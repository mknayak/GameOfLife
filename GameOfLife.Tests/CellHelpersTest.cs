using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using manas.git.gol;
using manas.git.gol.helpers;
using System.Collections.Generic;

namespace manas.git.gol.tests
{
    [TestClass]
    public class CellHelpersTest
    {
        [TestMethod]
        public void A_live_Cell_With_Less_Than_Two_Live_Cell_Dies_In_Next_Generation()
        {
            Cell currentCell = GetCellWithNeighbours(CellState.Alive, 1);

            currentCell.EvaluateNextGenerationState();

            Assert.AreEqual(currentCell.NextGenerationState, CellState.Dead);

            currentCell = GetCellWithNeighbours(CellState.Alive, 0);

            currentCell.EvaluateNextGenerationState();

            Assert.AreEqual(currentCell.NextGenerationState, CellState.Dead);
        }

        [TestMethod]
        public void A_live_Cell_With_More_Than_Three_Live_Cell_Dies_In_Next_Generation()
        {
            Cell currentCell = GetCellWithNeighbours(CellState.Alive, 4);

            currentCell.EvaluateNextGenerationState();

            Assert.AreEqual(currentCell.NextGenerationState, CellState.Dead);

            currentCell = GetCellWithNeighbours(CellState.Alive, 3);

            currentCell.EvaluateNextGenerationState();

            Assert.AreEqual(currentCell.NextGenerationState, CellState.Alive);
        }

        [TestMethod]
        public void A_live_Cell_With_Two_Or_Three_Live_Cell_Continue_Alive_In_Next_Generation()
        {
            Cell currentCell = GetCellWithNeighbours(CellState.Alive, 2);

            currentCell.EvaluateNextGenerationState();

            Assert.AreEqual(currentCell.NextGenerationState, CellState.Alive);

            currentCell = GetCellWithNeighbours(CellState.Alive, 3);

            currentCell.EvaluateNextGenerationState();

            Assert.AreEqual(currentCell.NextGenerationState, CellState.Alive);
        }

        [TestMethod]
        public void A_Dead_Cell_With_Exact_Three_Live_Cell_Become_Alive_In_Next_Generation()
        {
            Cell currentCell = GetCellWithNeighbours(CellState.Dead, 3);

            currentCell.EvaluateNextGenerationState();

            Assert.AreEqual(currentCell.NextGenerationState, CellState.Alive);
        }

        /// <summary>
        /// Gets the cell with neighbours.
        /// </summary>
        /// <param name="currentCellState">State of the current cell.</param>
        /// <param name="liveNeighbourCount">The live neighbour count.</param>
        /// <returns></returns>
        public static Cell GetCellWithNeighbours(CellState currentCellState, int liveNeighbourCount)
        {
            Cell nwCell = new Cell { State = currentCellState };
            List<Cell> neighbours = new List<Cell>();
            for (int i = 0; i < liveNeighbourCount; i++)
            {
                neighbours.Add(new Cell { State = CellState.Alive });
            }
            nwCell.Neighbours = neighbours;
            return nwCell;
        }
    }
}
