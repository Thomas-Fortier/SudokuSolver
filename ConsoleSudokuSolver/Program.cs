/*
 * Console Sudoku Solver
 * Created by Thomas Fortier
 * on 2020-02-11
 *  
 * The program will solve a Sudoku board with initial values
 */

using System;

namespace ConsoleSudokuSolver
{
    internal class Program
    {
        private static void Main()
        {
            var board = new Board(9, 9);
            board.Initialize();
            board.AddValues();
            board.StoreEmptyCells();

            PrintTitleScreen();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress any key to start...");
            Console.ReadKey();
            Console.ResetColor();

            board.PrintBoard();

            Console.WriteLine("\nThis is the unsolved board. All cells that have the value of 0 are empty.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress any key to solve the puzzle...");
            Console.ResetColor();
            Console.ReadKey();

            Solve.FindMissingValues(board); // Starts the solving process

            board.PrintBoard();

            Console.WriteLine("\nHere is the solved board! Feel free to play around with the board values.\n" +
                              "Just make sure the solution is valid...");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress any key to quit...");
            Console.ResetColor();
            Console.ReadKey();
        }

        /// <summary>
        /// Prints the title and description to the console
        /// </summary>
        private static void PrintTitleScreen()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("------------------------------\n");
            Console.WriteLine("Welcome to Sudoku Solver!");
            Console.WriteLine("Created by Thomas Fortier");
            Console.WriteLine("Created on 2020-02-11");
            Console.WriteLine("\n------------------------------");
            Console.ResetColor();

            Console.WriteLine("\nThis was an experimental project to create an algorithm that\n" +
                              "can solve a Sudoku board. The type of algorithm.");
            Console.WriteLine("\nThe backtracking algorithm does exactly what it sounds like.\n" +
                              "In the case of Sudoku, if at a given point it cannot fill in a cell\n" +
                              "it will backtrack to a previous cell and change its value until it\n" +
                              "finds a valid solution.");
            Console.WriteLine("\nCurrently, you have to hard code the initial values of the board.\n" +
                              "I plan on potentially changing this. If you want to add your own board,\n" +
                              "you can change the values in Board.cs.");
            Console.WriteLine("\nThere is a graphical version in progress. It will be released ASAP.");
        }
    }
}
