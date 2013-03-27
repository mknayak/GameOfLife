using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace manas.git.gol.tests
{
    [TestClass]
    public class EcoSystemTest
    {
        [TestMethod]
        public void EcoSystem_Constructor_Test()
        {
            int row = 3;
            int col = 5;
            EcoSystem eco = new EcoSystem(GetCellGrid(row, col));

            Assert.AreEqual(eco.cells.GetLength(1), col);
            Assert.AreEqual(eco.cells.GetLength(0), row);
            Assert.IsNotNull(eco.cells[2, 1].Neighbours);
            Assert.IsNotNull(eco.cells[2, 4].Neighbours);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EcoSystem_Constructor_Null_CellGrid_throws_Exception_Test()
        {
            EcoSystem eco = new EcoSystem(null);
        }

        [TestMethod]
        public void EcoSystem_Move_To_Next_Generation_Test()
        {
            int row = 3;
            int col = 5;
            EcoSystem eco = new EcoSystem(GetCellGrid(row, col));
            /*
             * SEED
             _ o _ o _
             _ _ o _ _
             o _ o _ o
             * GEN1
             _ _ _ _ _
             _ _ o _ _
             _ o _ _ _
             * 
             */
            eco.cells[0, 1].State = CellState.Alive;
            eco.cells[0, 3].State = CellState.Alive;
            eco.cells[1, 2].State = CellState.Alive;
            eco.cells[2, 0].State = CellState.Alive;
            eco.cells[2, 2].State = CellState.Alive;
            eco.cells[2, 4].State = CellState.Alive;

            eco.MoveToNextGeneration();

            Assert.AreEqual(eco.cells[1, 2].State, CellState.Alive);
            Assert.AreEqual(eco.cells[2, 1].State, CellState.Alive);
        }

        public static Cell[,] GetCellGrid(int row, int col)
        {
            Cell[,] cells = new Cell[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    cells[i, j] = new Cell { position = new Position(i, j), State = CellState.Dead };
                }
            }

            return cells;
        }
    }
}
