using System;
using System.Collections.Generic;
using System.Linq;

namespace manas.git.gol
{
    /// <summary>
    /// GameOfLife - class represents the Game
    /// </summary>
    public class GameOfLife
    {
        int minBoundary;
        int maxBoundary;
        /// <summary>
        /// Gets or sets the system.
        /// </summary>
        /// <value>
        /// The system.
        /// </value>
        public EcoSystem System { get; private set; }

        /// <summary>
        /// Initializes the game with specified row.
        /// </summary>
        /// <param name="rows">The rows.</param>
        /// <param name="columns">The columns.</param>
        /// <returns></returns>
        public static GameOfLife Initialize(int rows, int columns)
        {
            Cell[,] cells = new Cell[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    cells[i, j] = new Cell
                      {
                          position = new Position(i, j),
                          State = CellState.Dead
                      };
                }
            }

            GameOfLife gol = new GameOfLife();
            gol.minBoundary = 0;
            gol.maxBoundary = rows * columns - 1;
            gol.System = new EcoSystem(cells);

            return gol;
        }

        /// <summary>
        /// Starts the game.
        /// </summary>
        public void StartGame()
        {
            Random rnd = new Random();
            List<int> aliveList = new List<int>();
            aliveList.Add(0);
            aliveList.Add(8);
            // aliveList.Add(15);
            aliveList.Add(21);
            aliveList.Add(9);
            aliveList.Add(16);
            aliveList.Add(11);
            aliveList.Add(18);
            aliveList.Add(6);
            //   aliveList.Add(12); 
            aliveList.Add(19);
            aliveList.Add(27);
            StartGameWithSeed(aliveList);
        }

        /// <summary>
        /// Starts the game with seed.
        /// </summary>
        /// <param name="aliveCells">The alive cells.</param>
        public void StartGameWithSeed(IEnumerable<int> aliveCells)
        {
            if (aliveCells.Any(c => c > this.maxBoundary || c < minBoundary))
                throw new Exception(string.Format("Seed values must be between {0} and {1}", this.minBoundary, this.maxBoundary));
            
            foreach (var cellPosition in aliveCells)
            {
                int x = cellPosition / this.System.cells.GetLength(1);
                int y = cellPosition % this.System.cells.GetLength(1);
                var selectedCell = this.System.cells[x, y];
                selectedCell.State = CellState.Alive;
            }
        }

        /// <summary>
        /// Moves to next generation.
        /// </summary>
        /// <returns></returns>
        public Cell[,] MoveToNextGeneration()
        {
            this.System.MoveToNextGeneration();
            return this.System.cells;
        }
    }
}
