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
            if (rows <= 0)
                throw new ArgumentException("rows should be more than zero");
            if (columns <= 0)
                throw new ArgumentException("columns should be more than zero");

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
            aliveList.Add(rnd.Next(minBoundary,maxBoundary));
            aliveList.Add(rnd.Next(minBoundary, maxBoundary));
            aliveList.Add(rnd.Next(minBoundary, maxBoundary));
            aliveList.Add(rnd.Next(minBoundary, maxBoundary));
            aliveList.Add(rnd.Next(minBoundary, maxBoundary));
            aliveList.Add(rnd.Next(minBoundary, maxBoundary));
            aliveList.Add(rnd.Next(minBoundary, maxBoundary));
            aliveList.Add(rnd.Next(minBoundary, maxBoundary));
            aliveList.Add(rnd.Next(minBoundary, maxBoundary));
            aliveList.Add(rnd.Next(minBoundary, maxBoundary));
            StartGameWithSeed(aliveList);
        }

        /// <summary>
        /// Starts the game with seed.
        /// </summary>
        /// <param name="aliveCellIndexes">The alive cells.</param>
        public void StartGameWithSeed(IEnumerable<int> aliveCellIndexes)
        {
            if (aliveCellIndexes.Any(c => c > this.maxBoundary || c < minBoundary))
                throw new ArgumentException(string.Format("Seed values must be between {0} and {1}", this.minBoundary, this.maxBoundary));
            
            foreach (var cellIndex in aliveCellIndexes)
            {
                int x = cellIndex / this.System.cells.GetLength(1);
                int y = cellIndex % this.System.cells.GetLength(1);
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
