using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessK.Util;

namespace ChessK.ChessPieces
{
    internal class Knight : Piece
    {
        public Knight(string color) : base(color)
        {
            type = ChessPieceType.Knight;

        }
    }
}
