/*
 * Amanuel Haile
 * CST-250
 * 1/30/2026
 * Chess Board Project
 * Activity 2 - BL
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
                case "knight":
                    // Set the occupying property of cell model for the current cell
                    board.Grid[currentCell.Row, currentCell.Column].PieceOccupyingCell = "N";
                    board = MarkValidKnightMoves(board, currentCell);
                    break;
                case "rook":

                    break;
                case "bishop":
                    break;
                case "queen":
                    break;
                case "king":
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


    }
}
