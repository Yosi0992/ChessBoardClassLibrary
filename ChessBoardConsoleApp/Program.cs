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
Tuple<int, int> result;
BoardModel board = new BoardModel(8);
BoardLogic logic = new BoardLogic();

Utility.PrintBoard(board);

Console.Write("Enter the type of piece you want to place: ");
piece = Console.ReadLine();
result = Utility.GetRowAndCol();

board = logic.MarkLegalMoves(board, board.Grid[result.Item1, result.Item2], piece);

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
                else if (!string.IsNullOrEmpty(cell.PieceOccupyingCell))
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
    /// <summary>
    /// get the row and column of the piece
    /// </summary>
    /// <param name="board"></param>
    /// <returns></returns>
    internal static Tuple<int, int> GetRowAndCol()
    {
        int row = -1, col = -1;
        Console.Write("Enter the row number of the piece: ");
        row = int.Parse(Console.ReadLine());

        Console.Write("Enter the column number of the piece: ");
        col = int.Parse(Console.ReadLine());


        return Tuple.Create(row, col);
    }


}