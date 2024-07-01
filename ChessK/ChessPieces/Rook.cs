using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessK.Util;

namespace ChessK.ChessPieces
{
    internal class Rook : Piece
    {
        public Rook(string color) : base(color)
        {
            type = ChessPieceType.Rook;

        }
    }
}
