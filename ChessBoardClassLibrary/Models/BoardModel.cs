/*
 * Amanuel Haile
 * CST-250
 * 1/30/2026
 * Chess Board Project
 * Activity 2
 * In class activity
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardClassLibrary.Models
{
    public class BoardModel
    {
        public int Size { get; private set; }
        public CellModel[,] Grid { get; private set; }

        /// <summary>
        /// Parametized constructor
        /// </summary>
        /// <param name="size"></param>
        public BoardModel(int size)
        {
            Size = size;
            Grid = new CellModel[Size, Size];

            InitializeBoard();
        }
        /// <summary>
        /// Set up a new board
        /// </summary>
        public void InitializeBoard()
        {
            for (int row = 0; row < Size; row++)
            {
                // iterate all over the coulmns
                for (int col = 0; col < Size; col++)
                {
                    Grid[row, col] = new CellModel(row, col);
                }

            }
        }
    }
}
