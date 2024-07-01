using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessK.Util
{
    internal class Board
    {
        private Square[,] board;

        public Board()
        {
            board = new Square[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                    {
                        board[i, j] = new Square(i, j, null, "white");
                    }
                    else
                    {
                        board[i, j] = new Square(i, j, null, "black");
                    }
                }
            }
        }

        public Square getSquare(int Column, int row)
        {
            return board[Column, row];
        }

        public Square[,] getBoard()
        {
            return board;
        }
    }
}
