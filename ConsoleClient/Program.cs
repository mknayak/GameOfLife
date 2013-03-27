using manas.git.gol;
using System;

namespace ConsoleClient
{
    class Program
    {
        /// <summary>
        /// Entry point for ConsoleClient.
        /// </summary>
        /// <param name="args">The args.</param>
        static void Main(string[] args)
        {
            var game = GameOfLife.Initialize(6, 9);
            game.StartGame();
            Console.WriteLine("SEED");
            DrawGOL(game.System.cells);
            for (int i = 0; i < 20; i++)
            {
                var cells = game.MoveToNextGeneration();
                Console.WriteLine("Generation {0}", i+1);
                DrawGOL(cells);
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Draws the Game Of Life.
        /// </summary>
        /// <param name="cells">The cells.</param>
        private static void DrawGOL(Cell[,] cells)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    PrintCell(cells[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints the cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        static void PrintCell(Cell cell)
        {
            if (cell.State.Equals(CellState.Alive))
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.Write("{0} ", "O");

            Console.ResetColor();
        }
    }
}
