/*
 *
 */
using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;
using System.Collections.Concurrent;
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

piece = Utility.GetChessPiece();
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
        int size = board.Size;

        // Column headers
        Console.Write("   ");
        for (int col = 0; col < size; col++)
        {
            Console.Write($" {col}  ");
        }
        Console.WriteLine();

        // Top border
        PrintBorder(size);

        for (int row = 0; row < size; row++)
        {
            // Row header
            Console.Write($"{row}  ");

            for (int col = 0; col < size; col++)
            {
                CellModel cell = board.Grid[row, col];

                // Left wall of the cell
                Console.Write("|");

                // --- Your exact content rules ---
                if (cell.IsLegalNextMove)
                {
                    Console.Write(" + ");
                }
                else if (cell.PieceOccupyingCell != "")
                {
                    Console.Write($" {cell.PieceOccupyingCell} ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }

            // Right wall end + newline
            Console.WriteLine("|");

            // Border after each row
            PrintBorder(size);
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


        while(row < 0 || row > 7)
        {
            Console.Write("Enter the row of the piece: ");

            if (int.TryParse(Console.ReadLine(), out row) && row >= 0 && row <= 7)
                break;
            
            else
            {
                Console.WriteLine("Out of bounds try again");
            }

        }
        while (col < 0 || col > 7)
        {
            Console.Write("Enter the column of the piece: ");

            if (int.TryParse(Console.ReadLine(), out col) && col >= 0 && col <= 7)
                break;
            else
            {
                Console.WriteLine("Out of bounds try again");
            }

        }
        return Tuple.Create(row, col);
    }
    /// <summary>
    /// Gets the chess piece and handles invalid input
    /// </summary>
    /// <returns></returns>
    internal static string GetChessPiece()
    {
        string piece = "";

        while (true)
        {

            Console.Write("Enter the type of piece you want to place: ");
            piece = Console.ReadLine().ToLower().Trim();
            if(piece == "knight" || piece == "rook" || piece == "bishop" || piece == "king" || piece == "queen")
            {
                break;
            }
            Console.WriteLine("Invalid piece. Please enter either a Knight, Rook, Bishop, King or Queen");
        }
        return piece;

    }
    /// <summary>
    /// Border Printer 
    /// </summary>
    /// <param name="size"></param>
    private static void PrintBorder(int size)
    {
        Console.Write("   ");
        for (int col = 0; col < size; col++)
        {
            Console.Write("+---");
        }
        Console.WriteLine("+");
    }



}