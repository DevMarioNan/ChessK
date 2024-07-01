using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessK.Util
{
    internal class Piece
    {
        private string color;
        private string icon;
        public enum ChessPieceType
        {
            King,
            Queen,
            Rook,
            Bishop,
            Knight,
            Pawn
        }

        public ChessPieceType type;

        public Piece(string color)
        {
            this.color = color;

        }

        public String getColor()
        {
            return color;
        }

        public virtual bool isValidMove(Board board, int startRow, int startColumn, int endRow, int endColumn)
        {
            return false;
        }
    }
}
