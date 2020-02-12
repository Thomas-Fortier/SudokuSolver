using System.Collections.Generic;

namespace ConsoleSudokuSolver
{
    internal class Cell
    {
        // TODO Add constraints to what positions and values can be set
        public int RowPosition { get; set; }
        public int ColPosition { get; set; }
        public int Value { get; set; }
        public List<int> InvalidValues { get; set; } = new List<int>();

        public Cell(int rowPosition, int colPosition, int value = 0)
        {
            RowPosition = rowPosition;
            ColPosition = colPosition;
            Value = value;
        }
    }
}