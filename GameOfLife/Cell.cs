using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace manas.git.gol
{
    public class Cell
    {
        public int cellId { get; set; }
        public IEnumerable<Cell> Neighbours { get; set; }
        public CellState State { get; set; }
        public CellState NextGenerationState { get; set; }
    }
}
