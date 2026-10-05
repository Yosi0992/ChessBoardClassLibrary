
namespace ChessBoardGUIApp
{
    partial class FrmChessBoard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            cmbChessPieces = new ComboBox();
            pnlChessBoard = new Panel();
            cmbThemes = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 70);
            label1.Name = "label1";
            label1.Size = new Size(809, 32);
            label1.TabIndex = 0;
            label1.Text = "Select a chess piece and its location on the board and see the legal moves";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(866, 58);
            label2.Name = "label2";
            label2.Size = new Size(80, 32);
            label2.TabIndex = 1;
            label2.Text = "Pieces";
            // 
            // cmbChessPieces
            // 
            cmbChessPieces.FormattingEnabled = true;
            cmbChessPieces.Items.AddRange(new object[] { "King", "Queen", "Bishop", "Knight", "Rook" });
            cmbChessPieces.Location = new Point(965, 50);
            cmbChessPieces.Name = "cmbChessPieces";
            cmbChessPieces.Size = new Size(242, 40);
            cmbChessPieces.TabIndex = 2;
            // 
            // pnlChessBoard
            // 
            pnlChessBoard.Location = new Point(35, 116);
            pnlChessBoard.Name = "pnlChessBoard";
            pnlChessBoard.Size = new Size(640, 648);
            pnlChessBoard.TabIndex = 3;
            // 
            // cmbThemes
            // 
            cmbThemes.FormattingEnabled = true;
            cmbThemes.Items.AddRange(new object[] { "Default", "Cool", "Warm" });
            cmbThemes.Location = new Point(965, 182);
            cmbThemes.Name = "cmbThemes";
            cmbThemes.Size = new Size(242, 40);
            cmbThemes.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(794, 190);
            label3.Name = "label3";
            label3.Size = new Size(152, 32);
            label3.TabIndex = 5;
            label3.Text = "Color Theme";
            // 
            // FrmChessBoard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1230, 838);
            Controls.Add(label3);
            Controls.Add(cmbThemes);
            Controls.Add(pnlChessBoard);
            Controls.Add(cmbChessPieces);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmChessBoard";
            Text = "Chess Board";
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Label label1;
        private Label label2;
        private ComboBox cmbChessPieces;
        private Panel pnlChessBoard;
        private ComboBox cmbThemes;
        private Label label3;
    }
}
