/*
 * Amanuel Haile
 * CST-250
 * 2/4/2025
 * Chess Game Console App
 * In class activity
 */
using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;
using System.Transactions;
//-------------------------------------------------------------------------------
// Start of the main method
//-------------------------------------------------------------------------------
Console.WriteLine("Hello Chess Players!");
string piece = "";
int row = 0;
int col = 0;
BoardModel board = new BoardModel(8);
BoardLogic logic = new BoardLogic();

Utility.PrintBoard(board);

Console.Write("Enter the type of piece you want to place: ");
piece = Console.ReadLine();
Console.Write("Enter the row: ");
row = int.Parse(Console.ReadLine());
Console.Write("Enter the column: ");
col = int.Parse(Console.ReadLine());

CellModel cell = new CellModel(row, col);
logic.MarkLegalMoves(board, cell, piece);

Utility.PrintBoard(board);



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
                else if (cell.PieceOccupyingCell == null)
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