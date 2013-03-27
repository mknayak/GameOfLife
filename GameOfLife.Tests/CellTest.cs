using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace manas.git.gol.tests
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void SimpleClassTest()
        {
            Cell cell = new Cell
            {
                State = CellState.Alive,
                position = new Position(2, 2),
                NextGenerationState = CellState.Dead,
                Neighbours = Enumerable.Empty<Cell>()
            };

            Assert.AreEqual(cell.State, CellState.Alive);
            Assert.AreEqual(cell.NextGenerationState, CellState.Dead);
            Assert.AreEqual(cell.Neighbours.Count(), 0);
            Assert.AreEqual(cell.position.column, 2);
            Assert.AreEqual(cell.position.row, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SimpleClassTest_null_neighbour_throws_exeption()
        {
            Cell cell = new Cell
            {
                State = CellState.Alive,
                position = new Position(2, 2),
                NextGenerationState = CellState.Dead,
                Neighbours = null
            };

            cell.FindNextGenerationState();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void SimpleClassTest_Call_MoveToNextGeneration_Before_FindingNextGenerationState_throws_exeption()
        {
            Cell cell = new Cell
            {
                State = CellState.Alive,
                position = new Position(2, 2),
                NextGenerationState = CellState.None,
                Neighbours = Enumerable.Empty<Cell>()
            };

            cell.MoveToNextGeneration();
        }

        [TestMethod]
        public void Live_Cell_with_3_alive_neighbour_continues_to_live_in_next_generation()
        {
            Cell cell = CellHelpersTest.GetCellWithNeighbours(CellState.Alive, 3);
            cell.FindNextGenerationState();
            cell.MoveToNextGeneration();

            Assert.AreEqual(cell.State, CellState.Alive);
            Assert.AreEqual(cell.NextGenerationState, CellState.None);
        }

        [TestMethod]
        public void Dead_Cell_with_3_alive_neighbour_become_alive_in_next_generation()
        {
            Cell cell = CellHelpersTest.GetCellWithNeighbours(CellState.Dead, 3);
            cell.FindNextGenerationState();
            cell.MoveToNextGeneration();

            Assert.AreEqual(cell.State, CellState.Alive);
            Assert.AreEqual(cell.NextGenerationState, CellState.None);
        }

        [TestMethod]
        public void Alive_Cell_with_4_alive_neighbour_dies_in_next_generation()
        {
            Cell cell = CellHelpersTest.GetCellWithNeighbours(CellState.Alive, 4);
            cell.FindNextGenerationState();
            cell.MoveToNextGeneration();

            Assert.AreEqual(cell.State, CellState.Dead);
            Assert.AreEqual(cell.NextGenerationState, CellState.None);
        }

        [TestMethod]
        public void Alive_Cell_with_1_alive_neighbour_dies_in_next_generation()
        {
            Cell cell = CellHelpersTest.GetCellWithNeighbours(CellState.Alive, 3);
            cell.FindNextGenerationState();
            cell.MoveToNextGeneration();

            Assert.AreEqual(cell.State, CellState.Alive);
            Assert.AreEqual(cell.NextGenerationState, CellState.None);
        }
    }
}
