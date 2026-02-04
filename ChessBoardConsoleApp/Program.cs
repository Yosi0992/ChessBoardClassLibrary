/*
 * Amanuel Haile
 * CST-250
 * 2/4/2025
 * Chess Game Console App
 * In class activity
 */

//-------------------------------------------------------------------------------
// Start of the main method
//-------------------------------------------------------------------------------
using ChessBoardClassLibrary.Models;

Console.WriteLine("Hello Chess Players!");







// -------------------------------------------------------------------------------
// End of the main method
// -------------------------------------------------------------------------------


// -------------------------------------------------------------------------------
// Define a utility class
// -------------------------------------------------------------------------------

public static class Utility
{
    /// <summary>
    /// Print the given board of the console
    /// </summary>
    /// <param name="board"></param>
    internal static void PrintBoard(BoardModel board)
    {
        for (int row = 0; row < board.Size; row++)
        {
            for (int col = 0; col < board.Size; col++)
            {
                CellModel cell = board.Grid[row, col];
                // check if the current cell is a legal move
                if (cell.IsLegalNextMove)
                {
                    Console.Write(" + ");
                }
                else if (cell.PieceOccupyingCell != null)
                {
                    // Print the pieces letter
                    Console.Write($" {cell.PieceOccupyingCell} ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine();
        }
    } // end of print board method


}