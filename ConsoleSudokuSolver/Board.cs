using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleSudokuSolver
{
    internal class Board
    {
        public int RowLength { get; set; }
        public int ColLength { get; set; }
        public List<Cell> Cells { get; set; } = new List<Cell>();
        public List<Cell> EmptyCells { get; set; } = new List<Cell>();
        

        public Board(int rowLength, int colLength)
        {
            RowLength = rowLength;
            ColLength = colLength;
        }

        /// <summary>
        /// Adds all the cells on the board. Default value is 0
        /// </summary>
        public void Initialize()
        {
            // (For each column)
            for (var c = 0; c < ColLength; c++)
            {
                // For each row)
                for (var r = 0; r < RowLength; r++)
                {
                    var cell = new Cell(r, c); // Initialize a new cell
                    Cells.Add(cell); // Add it to the Cells list
                }
            }
        }

        /// <summary>
        /// Prints the board to the screen
        /// </summary>
        public void PrintBoard()
        {
            var cellPosition = 0;

            Console.Clear(); // Clean up console

            // (For each column)
            for (var c = 0; c < ColLength; c++)
            {
                // When it has reached the third column, add a spacer
                if (c % 3 == 0 && c != 0)
                    Console.Write("-----------\n");

                // (For each row)
                for (var r = 0; r < RowLength; r++)
                {
                    // When it has reached the third row, add a spacer
                    if (r % 3 == 0 && r != 0)
                        Console.Write("|");

                    // Print the cell
                    if (Cells[cellPosition].Value == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write(Cells[cellPosition].Value);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(Cells[cellPosition].Value);
                    }

                    // Add a line break when it has reached the end of the row
                    if (r == 8)
                        Console.WriteLine();

                    cellPosition++;
                }
            }
        }

        /// <summary>
        /// Adds values to specific cells to create a working board
        ///
        /// TODO: Refactor and allow for multiple boards
        /// </summary>
        public void AddValues()
        {
            #region BoardLayout1

            /*Cells[4].Value = 2;
            Cells[6].Value = 4;
            Cells[8].Value = 8;

            Cells[9].Value = 9;
            Cells[10].Value = 8;
            Cells[11].Value = 6;
            Cells[12].Value = 1;
            Cells[17].Value = 3;

            Cells[18].Value = 2;
            Cells[19].Value = 3;
            Cells[20].Value = 4;
            Cells[23].Value = 9;
            Cells[25].Value = 6;
            Cells[26].Value = 5;

            Cells[31].Value = 9;
            Cells[32].Value = 1;
            Cells[34].Value = 8;

            Cells[38].Value = 2;
            Cells[40].Value = 5;
            Cells[41].Value = 7;

            Cells[45].Value = 5;
            Cells[46].Value = 4;
            Cells[47].Value = 1;
            Cells[48].Value = 3;
            Cells[50].Value = 6;
            Cells[51].Value = 2;

            Cells[56].Value = 8;
            Cells[57].Value = 7;
            Cells[58].Value = 6;

            Cells[65].Value = 3;
            Cells[66].Value = 9;
            Cells[67].Value = 1;
            Cells[69].Value = 8;

            Cells[72].Value = 1;
            Cells[74].Value = 9;
            Cells[80].Value = 2;*/

            #endregion

            #region BoardLayout2

            /*Cells[2].Value = 8;
            Cells[3].Value = 2;
            Cells[6].Value = 9;
            Cells[8].Value = 3;

            Cells[9].Value = 3;
            Cells[10].Value = 4;
            Cells[11].Value = 2;
            Cells[13].Value = 9;
            Cells[14].Value = 5;
            Cells[17].Value = 7;

            Cells[18].Value = 1;
            Cells[19].Value = 9;
            Cells[20].Value = 7;
            Cells[26].Value = 4;

            Cells[29].Value = 5;
            Cells[30].Value = 3;
            Cells[31].Value = 1;
            Cells[32].Value = 2;
            Cells[33].Value = 4;
            Cells[34].Value = 7;
            Cells[35].Value = 9;

            Cells[45].Value = 2;
            Cells[49].Value = 7;
            Cells[50].Value = 4;
            Cells[51].Value = 5;

            Cells[55].Value = 2;
            Cells[59].Value = 1;
            Cells[62].Value = 5;

            Cells[64].Value = 7;
            Cells[68].Value = 6;
            Cells[69].Value = 8;
            Cells[70].Value = 9;
            Cells[71].Value = 1;

            Cells[72].Value = 8;
            Cells[75].Value = 4;
            Cells[76].Value = 3;
            Cells[78].Value = 7;
            Cells[80].Value = 6;*/

            #endregion

            #region BoardLayout3

            Cells[3].Value = 6;
            Cells[5].Value = 9;
            Cells[7].Value = 8;

            Cells[13].Value = 3;
            Cells[15].Value = 7;

            Cells[19].Value = 1;
            Cells[24].Value = 4;

            Cells[29].Value = 8;
            Cells[31].Value = 6;
            Cells[35].Value = 5;

            Cells[36].Value = 4;
            Cells[37].Value = 2;
            Cells[39].Value = 1;

            Cells[51].Value = 2;

            Cells[58].Value = 9;
            Cells[60].Value = 5;
            Cells[62].Value = 7;

            Cells[63].Value = 7;
            Cells[69].Value = 8;
            Cells[71].Value = 6;

            Cells[72].Value = 1;
            Cells[77].Value = 3;

            #endregion
        }

        /// <summary>
        /// Get all cells that have an empty value (0) and add it to a list
        /// </summary>
        public void StoreEmptyCells()
        {
            foreach (var cell in Cells.Where(cell => cell.Value == 0))
                EmptyCells.Add(cell);
        }
    }
}