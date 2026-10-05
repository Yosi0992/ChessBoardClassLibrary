/*
 *Yosilas Feyisa
 * CST-250
 * 
 * Chess Board GUI
 * 
 */
using ChessBoardClassLibrary.Models;
using ChessBoardClassLibrary.Services.BusinessLogicLayer;

namespace ChessBoardGUIApp
{
    public partial class FrmChessBoard : Form
    {
        BoardModel board = new BoardModel(8);
        BoardLogic boardLogic = new BoardLogic();
        // 8 by 8 2D array of buttons named "buttons"
        // we will use the buttons array to set up the chess board
        Button[,] buttons = new Button[8, 8];
        public FrmChessBoard()
        {
            InitializeComponent();
            // set up the panel with buttons
            SetUpButtons();

            cmbThemes.SelectedIndex = 1; // selects "Default"
            ApplyTheme();
        }
        /// <summary>
        /// Populate the panel control with butttons
        /// </summary>
        private void SetUpButtons()
        {
            int buttonSize = -1;

            buttonSize = pnlChessBoard.Width / board.Size;

            // Set the panel to be square
            pnlChessBoard.Height = pnlChessBoard.Width;

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    buttons[row, col] = new Button();
                    buttons[row,col].Width = buttonSize;
                    buttons[row,col].Height = buttonSize;

                    // set the location of the button
                    // using the .left and .top sides
                    buttons[row, col].Left = col * buttonSize;
                    buttons[row, col].Top = row * buttonSize;

                    // Attach a click event handler to the button
                    buttons[row, col].Click += BtnSquareClickEH;

                    // Store the location of the button on the tag property that is used as a point object

                    buttons[row, col].Tag = new Point(row, col);

                    // set the text for each button
                    buttons[row, col].Text = $"{row}, {col}";

                    // add the button to the panels controls
                    
                    pnlChessBoard.Controls.Add(buttons[row,col]);
                }
            }
        } // end of SetUpButtons method

        /// <summary>
        /// Button click event handler
        /// For the chess board buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void BtnSquareClickEH(object sender, EventArgs e)
        {
            // Cast the sender object to a button itself since we knw its a button

            Button button = (Button)sender;

            // retrieve the tag property of the button
            // which stores the position of the point object

            Point point = (Point)button.Tag;
            //Extract the row and column values from the Point object

            int row = point.X;
            int col = point.Y;

            string piece = cmbChessPieces.Text;
            if (string.IsNullOrEmpty(piece))
            {
                MessageBox.Show("Please slect a chess Piece");
                return;
            }

            MessageBox.Show($"You clicked on row {row} and column {col}");
            // Send the board, current cell and piece to the business logic layer
            board = boardLogic.MarkLegalMoves(board, board.Grid[row, col], piece);

            // update the buttons 
            UpdateButtons();
        }
        /// <summary>
        /// Update the text of each button based on the board
        /// </summary>
        private void UpdateButtons()
        {
            string piece = "";


            // set up a dictionary to get the name of the chess pieces
            // dictionary data structores stores key-value pairs
            Dictionary<string, string> pieceMap = new Dictionary<String, String>
            {
                {"N", "Knight" },
                {"R", "Rook" },
                {"B", "Bishop" },
                {"Q", "Queen" },
                {"K", "King" }
            };
            // loop through each cell in the grid to update the corresponding buttons
            for (int row = 0; row < board.Size; row++)
            {
                for(int col =  0; col < board.Size; col++)
                {
                    if (board.Grid[row, col].IsLegalNextMove)
                    {
                        buttons[row, col].Text = "Legal Move";
                    }else if (board.Grid[row,col].PieceOccupyingCell != "")
                    {
                        // use the data dictionary to get the name of the chess piece
                        piece = pieceMap[board.Grid[row, col].PieceOccupyingCell];
                        // update the text for the button
                        buttons[row,col].Text = piece;
                    }
                    else
                    {
                        // clear the text for any other button
                        buttons[row, col].Text = "";

                    }

                }
            }
        } // end of updatebuttons method
        /// <summary>
        /// Print the board in colors
        /// </summary>
        private void ApplyTheme()
        {
            Color light, dark;

            switch (cmbThemes.Text)
            {
                case "Cool":
                    light = Color.LightBlue;
                    dark = Color.SteelBlue;
                    break;

                case "Warm":
                    light = Color.Moccasin;
                    dark = Color.SandyBrown;
                    break;

                default: // "Default"
                    light = Color.White;
                    dark = Color.Gray;
                    break;
            }

            for (int row = 0; row < board.Size; row++)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    bool isLight = (row + col) % 2 == 0;
                    buttons[row, col].BackColor = isLight ? light : dark;
                }
            }
        }

        private void cmbThemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyTheme();
        }
    }
}
