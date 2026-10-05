/*
 * Yosilas Feyisa
 * 
 */
using ChessBoardClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardClassLibrary.Services.BusinessLogicLayer
{
    public class BoardLogic
    {
        /// <summary>
        /// Reset the board by setting the cell properies back to default
        /// Encapsulate this method so it can only be called only from this class
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private BoardModel ResetBoard(BoardModel board)
        {
            foreach(CellModel cell in board.Grid)
            {
                cell.IsLegalNextMove = false;
                cell.PieceOccupyingCell = "";
            }
            return board; 
        }
        /// <summary>
        /// Check if a row/col location is on the board
        /// Encapsulate this method
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsOnBoard(BoardModel board, int row, int col)
        {
            // declare an initialize
            int size = 0;
            bool isRowSafe = false, isColSafe = false;

            size = board.Size;

            // Check if the row is on the board
            isRowSafe = row >= 0 && row < size;
            isColSafe = col >= 0 && col < size;

            // return if both row and column are safe

            return isRowSafe && isColSafe;
        }
        /// <summary>
        /// Mark the legal moves for a given chess piece
        /// </summary>
        /// <param name="board"></param>
        /// <param name="currentCell"></param>
        /// <param name="chessPiece"></param>
        /// <returns></returns>
        public BoardModel MarkLegalMoves(BoardModel board, CellModel currentCell, string chessPiece)
        {
            board = ResetBoard(board);
            chessPiece = chessPiece.ToLower();
            switch (chessPiece)
            {
                // Amanuel Haile
                case "knight":
                    // Set the occupying property of cell model for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "N";
                    board = MarkValidKnightMoves(board, currentCell);
                    break;
                case "rook":
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "R";
                    board = MarkValidRookMoves(board, currentCell);
                    break;
                case "bishop":
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "B";
                    board = MarkValidBishopMoves(board, currentCell);
                    break;
                case "queen":
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "Q";
                    board = MarkValidQueenMoves(board, currentCell);
                    break;
                case "king":
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "K";
                    board = MarkValidKingMoves(board, currentCell);
                    break;
                default:
                    return board;
                    break;
            }
            return board;
        } // end of mark legal moves method

        private BoardModel MarkValidKnightMoves(BoardModel board, CellModel currentCell)
        {
            // possible moves for knight row
            int[] knightRowMoves = { 2, 1, -1, -2, -2, -1, 1, 2 };
            // possible moves for knight column
            int[] knightColMoves = { 1, 2, 2, 1, -1, -2, -2, -1 };
            for (int i = 0; i < knightRowMoves.Length; i++)
            {
                // check if each move is on the board
                if (IsOnBoard(board, currentCell.Row + knightRowMoves[i], currentCell.Column + knightColMoves[i]))
                {
                    // If the cell is on the board we are gonna label it as a possible move for the knight
                    board.Grid[currentCell.Row + knightRowMoves[i], currentCell.Column + knightColMoves[i]].IsLegalNextMove = true;
                }
            }
            return board;
        }
        private BoardModel MarkValidRookMoves(BoardModel board, CellModel currentCell) 
        {
            int[] rookRowMoves = { -1, 1, 0, 0 };  
            int[] rookColMoves = { 0, 0, -1, 1 };
            for (int i = 0; i < rookRowMoves.Length; i++)
            {
                int row = currentCell.Row + rookRowMoves[i];
                int col = currentCell.Column + rookColMoves[i];

                while (IsOnBoard(board, row, col))
                {
                    board.Grid[row, col].IsLegalNextMove = true;

                    row += rookRowMoves[i];
                    col += rookColMoves[i];
                }
            }
            return board;
        }
        private BoardModel MarkValidBishopMoves(BoardModel board, CellModel currentCell)
        {
            int[] bishopRowMoves = { -1, -1, 1, 1 };
            int[] bishopColMoves = { -1, 1, -1, 1 };

            for (int i = 0; i < bishopRowMoves.Length; i++)
            {
                int row = currentCell.Row + bishopRowMoves[i];
                int col = currentCell.Column + bishopColMoves[i];

                while (IsOnBoard(board, row, col))
                {
                    board.Grid[row, col].IsLegalNextMove = true;

                    row += bishopRowMoves[i];
                    col += bishopColMoves[i];
                }
            }
            return board;
        }
        private BoardModel MarkValidQueenMoves(BoardModel board, CellModel currentCell)
        {
            int[] queenRowMoves = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] queenColMoves = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < queenRowMoves.Length; i++)
            {
                int row = currentCell.Row + queenRowMoves[i];
                int col = currentCell.Column + queenColMoves[i];

                while (IsOnBoard(board, row, col))
                {
                    board.Grid[row, col].IsLegalNextMove = true;

                    row += queenRowMoves[i];
                    col += queenColMoves[i];
                }
            }
            return board;
        }
        private BoardModel MarkValidKingMoves(BoardModel board, CellModel currentCell)
        {
            int[] kingRowMoves = { -1, -1, -1, 0, 0, 1, 1, 1 };
            int[] kingColMoves = { -1, 0, 1, -1, 1, -1, 0, 1 };

            for (int i = 0; i < kingRowMoves.Length; i++)
            {
                int row = currentCell.Row + kingRowMoves[i];
                int col = currentCell.Column + kingColMoves[i];

                if (IsOnBoard(board, row, col))
                {
                    board.Grid[row, col].IsLegalNextMove = true;
                }
            }
            return board;
        }




    }
}
