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

        public Piece(string color, string icon)
        {
            this.color = color;
            this.icon = icon;
        }

        public virtual bool isValidMove(Board board, int startRow, int startColumn, int endRow, int endColumn)
        {
            return false;
        }
    }
}
