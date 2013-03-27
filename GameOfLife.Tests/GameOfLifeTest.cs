using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace manas.git.gol.tests
{
    [TestClass]
    public class GameOfLifeTest
    {
        [TestMethod]
        public void Initialize_Game_Test()
        {
            GameOfLife gom = GameOfLife.Initialize(3, 4);
           
            Assert.IsNotNull(gom);
            Assert.IsNotNull(gom.System);
            Assert.IsNotNull(gom.System.cells);
            Assert.AreEqual(gom.System.cells.GetLength(0), 3);
            Assert.AreEqual(gom.System.cells.GetLength(1), 4);
        }

        [TestMethod]
        public void Start_Game_Test()
        {
           GameOfLife gom = GameOfLife.Initialize(3, 4);
           gom.StartGame();
           int aliveCellCount = 0;
           foreach (var cell in gom.System.cells)
           {
               if (cell.State.Equals(CellState.Alive))
                   aliveCellCount++;
           }

            Assert.IsNotNull(gom);
            Assert.IsNotNull(gom.System);
            Assert.IsNotNull(gom.System.cells);
            Assert.AreEqual(gom.System.cells.GetLength(0), 3);
            Assert.AreEqual(gom.System.cells.GetLength(1), 4);
            Assert.IsTrue(aliveCellCount>0);
        }
        
        [TestMethod]
        public void Start_Game_With_Seed_Test()
        {
            GameOfLife gom = GameOfLife.Initialize(3, 4);
            gom.StartGameWithSeed(new List<int> { 0,3,10});
            
            Assert.IsNotNull(gom);
            Assert.IsNotNull(gom.System);
            Assert.IsNotNull(gom.System.cells);
            Assert.AreEqual(gom.System.cells.GetLength(0), 3);
            Assert.AreEqual(gom.System.cells.GetLength(1), 4);
            Assert.AreEqual(gom.System.cells[0, 0].State, CellState.Alive);
            Assert.AreEqual(gom.System.cells[0, 3].State, CellState.Alive);
            Assert.AreEqual(gom.System.cells[2, 2].State, CellState.Alive);
        }

        [TestMethod]
        public void Move_To_Next_Generation_Start_Game_With_Seed_Test()
        {
            GameOfLife gom = GameOfLife.Initialize(3, 4);
            gom.StartGameWithSeed(new List<int> { 0, 1, 2, 4 });
           /*
            o o o _ 
            o _ _ _
            _ _ _ _
            
            */

            Assert.IsNotNull(gom);
            Assert.IsNotNull(gom.System);
            Assert.IsNotNull(gom.System.cells);
            Assert.AreEqual(gom.System.cells.GetLength(0), 3);
            Assert.AreEqual(gom.System.cells.GetLength(1), 4);
            Assert.AreEqual(gom.System.cells[0, 0].State, CellState.Alive);
            Assert.AreEqual(gom.System.cells[0, 1].State, CellState.Alive);
            Assert.AreEqual(gom.System.cells[0, 2].State, CellState.Alive);
            Assert.AreEqual(gom.System.cells[1, 0].State, CellState.Alive);

            gom.MoveToNextGeneration();
            /*
            o o _ _ 
            o _ _ _
            _ _ _ _
            
            */
            Assert.AreEqual(gom.System.cells[0, 0].State, CellState.Alive);
            Assert.AreEqual(gom.System.cells[0, 1].State, CellState.Alive);
            Assert.AreEqual(gom.System.cells[0, 2].State, CellState.Dead);
            Assert.AreEqual(gom.System.cells[1, 0].State, CellState.Alive);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_With_Zero_Rows_Throw_Exception_Test()
        {
            GameOfLife gom = GameOfLife.Initialize(0, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Game_With_Zero_Columns_Throw_Exception_Test()
        {
            GameOfLife gom = GameOfLife.Initialize(3, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Start_Game_With_Seed_OutOfRange_Negative_Seed_Exception_Test()
        {
            GameOfLife gom = GameOfLife.Initialize(3, 4);
            gom.StartGameWithSeed(new List<int> { -2, 3, 10 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Start_Game_With_Seed_OutOfRange_Positive_Seed_Exception_Test()
        {
            GameOfLife gom = GameOfLife.Initialize(3, 4);
            gom.StartGameWithSeed(new List<int> { 42, 3, 10 });
        }
    }
}
