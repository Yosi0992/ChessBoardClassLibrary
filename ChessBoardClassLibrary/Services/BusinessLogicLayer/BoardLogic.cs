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


    }
}
