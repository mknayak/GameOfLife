using manas.git.gol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = GameOfLife.Initialize(4, 7);
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
