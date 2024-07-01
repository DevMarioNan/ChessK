using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace ChessK.Util
{
    internal class Square
    {
        private int row;
        private int column;
        private Piece piece;
        private String color;

        public Texture2D texture { get; set; }

        public Square(int row, int column, Piece piece,String color)
        {
            this.row = row;
            this.column = column;
            this.piece = piece;
            this.color = color;
        }

        public int getRow()
        {
            return row;
        }

        public int getColumn() {
            return column;
        }

        public Piece getPiece()
        {
            return piece;
        }

        public void setPiece(Piece piece) {
            this.piece = piece;
        }

        public bool isEmpty()
        {
            return piece == null;
        }

        public String getColor()
        {
            return color;
        }

        public String getPos()
        {
            char c = (char)('a' + column);
            return c + "" + (8 - row);
        }

    }
}
