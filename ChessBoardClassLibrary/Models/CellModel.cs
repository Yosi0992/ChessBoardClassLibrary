/*
 * Amanuel Haile
 * CST-250
 * 1/30/2026
 * Chess Board Project
 * Activity 2
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardClassLibrary.Models
{
    public class CellModel
    {
        // This is an exmaple of encapsulation
        public int Row { get; private set; }

        public int Column { get; private set; }

        public string PieceOccupyingCell { get; private set; }

        public bool IsLegalNextMove { get; private set; }
        /// <summary>
        /// Parametized constructor
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public CellModel(int row, int column)
        {
            Row = row;
            Column = column;

            IsLegalNextMove = false;
            PieceOccupyingCell = "";
        }
    }
}
