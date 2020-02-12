using System;
using System.Linq;

namespace ConsoleSudokuSolver
{
    internal abstract class Solve
    {
        private static bool _isColValid;
        private static bool _isRowValid;
        private static bool _isQuadrantValid;

        /// <summary>
        /// Finds and fills all the cells that have missing values on the board
        /// </summary>
        /// <param name="board"></param>
        public static void FindMissingValues(Board board)
        {
            // Iterates through each empty cell from the EmptyCells list
            for (var i = 0; i < board.EmptyCells.Count; i++)
            {
                FillCells(board, i);

                // If the FillCells function cannot find a valid value, backtrack to a previous cell and try again WITHOUT the same values as before
                // Keeps looping until it can backtrack to a possible cell
                while (!_isColValid || !_isRowValid || !_isQuadrantValid)
                {
                    board.EmptyCells[i].Value = 0; // Sets the value of the cell to 0 when it cannot be solved
                    board.EmptyCells[i].InvalidValues.Clear(); // Resets the invalid values
                    i -= 1; // Previous empty cell
                    FillCells(board, i); // Try the function again with new values
                }
            }
        }

        /// <summary>
        /// Tries to fill the cells with valid values
        /// </summary>
        /// <param name="board"></param>
        /// <param name="i"></param>
        private static void FillCells(Board board, int i)
        {
            // Iterates through values from 1 to 9
            for (var cellValue = 1; cellValue < 10; cellValue++)
            {
                // Validate the rows, columns and quadrants
                _isColValid = ValidateColumn(board, board.EmptyCells[i], cellValue);
                _isRowValid = ValidateRow(board, board.EmptyCells[i], cellValue);
                _isQuadrantValid = ValidateQuadrant(board, board.EmptyCells[i], cellValue);

                // If the current cellValue is not valid, add it to the InvalidValues and continue
                if (!_isRowValid || !_isColValid || !_isQuadrantValid || board.EmptyCells[i].InvalidValues.Contains(cellValue))
                {
                    board.EmptyCells[i].InvalidValues.Add(cellValue);
                    continue;
                }

                // If the current cellValue is valid, change the cell value to that value and break
                board.EmptyCells[i].Value = cellValue;
                break;
            }
        }

        /// <summary>
        /// Loops through each element in the same column and checks if there are any matching values
        /// </summary>
        /// <param name="board"></param>
        /// <param name="cell"></param>
        /// <param name="cellValue"></param>
        /// <returns></returns>
        private static bool ValidateColumn(Board board, Cell cell, int cellValue)
        {
            var isColValid = true;

            // Iterates through each cell in the column and checks if there are any equal values
            foreach (var cellInCol in board.Cells.Where(cellInCol => cellInCol.RowPosition == cell.RowPosition))
            {
                if (cellInCol.Value != cellValue) continue;
                isColValid = false;
                break;
            }

            return isColValid;
        }

        /// <summary>
        /// Loops through each element in the same row and checks if there are any matching values
        /// </summary>
        /// <param name="board"></param>
        /// <param name="cell"></param>
        /// <param name="cellValue"></param>
        /// <returns></returns>
        private static bool ValidateRow(Board board, Cell cell, int cellValue)
        {
            var isRowValid = true;

            // Iterates through each cell in the row and checks if there are any equal values
            foreach (var cellInRow in board.Cells.Where(cellInRow => cellInRow.ColPosition == cell.ColPosition))
            {
                if (cellInRow.Value != cellValue) continue;
                isRowValid = false;
                break;
            }

            return isRowValid;
        }

        /// <summary>
        /// Loops through each element in the same quadrant and checks if there are any matching values
        /// </summary>
        /// <param name="board"></param>
        /// <param name="cell"></param>
        /// <param name="cellValue"></param>
        /// <returns></returns>
        private static bool ValidateQuadrant(Board board, Cell cell, int cellValue)
        {
            var isQuadrantValid = true;
            // ReSharper disable once PossibleLossOfFraction
            var quadrantRow = Math.Floor((decimal)(cell.RowPosition / 3));
            // ReSharper disable once PossibleLossOfFraction
            var quadrantCol = Math.Floor((decimal)(cell.ColPosition / 3));

            // Iterates through each cell in quadrant and checks if there are any equal values
            foreach (var cellInQuadrant in board.Cells)
            {
                if (quadrantRow != Math.Floor((decimal) cellInQuadrant.RowPosition / 3) ||
                    quadrantCol != Math.Floor((decimal) cellInQuadrant.ColPosition / 3)) continue;

                if (cellInQuadrant.Value != cellValue) continue;
                isQuadrantValid = false;
                break;
            }

            return isQuadrantValid;
        }
    }
}
