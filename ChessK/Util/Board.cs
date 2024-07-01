using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessK.ChessPieces;
using Microsoft.Xna.Framework.Graphics;

namespace ChessK.Util
{
    internal class Board
    {
        private Square[,] board;

        private String startFEN = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";
        private String[] FENParts;
        private String[] FENPieces;
        


        public Board()
        {
            FENParts = startFEN.Split(" ");
            FENPieces = FENParts[0].Split("/");
            FENPieces = ConvertFenNumbersToZeros(FENPieces).Split(" ");


            board = new Square[8, 8];
            for (int i = 0; i < 8; i++)
            {
                
                for (int j = 0; j < 8; j++)
                {
                    Piece piece = MakePiece(FENPieces[i][j]);
                    

                    if ((i + j) % 2 == 0)
                    {

                        board[i, j] = new Square(j, i, piece, "white");
                    }
                    else
                    {
                        board[i, j] = new Square(j, i, piece, "black");
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

        private Piece MakePiece(char x)
        {
            switch (x){
                case 'p':
                    return new Pawn("black");
                case 'r':
                    return new Rook("black");
                case 'n':
                    return new Knight("black");
                case 'b':
                    return new Bishop("black");
                case 'q':
                    return new Queen("black");
                case 'k':
                    return new King("black");
                case 'P':
                    return new Pawn("white");
                case 'R':
                    return new Rook("white");
                case 'N':
                    return new Knight("white");
                case 'B':
                    return new Bishop("white");
                case 'Q':
                    return new Queen("white");
                case 'K':
                    return new King("white");
                default:
                    return null;
            }
        }


        public string ConvertFenNumbersToZeros(string[] fen)
        {
            StringBuilder sb = new StringBuilder();
            
            

            foreach (string row in fen)
            {
                bool isFirst = true;

                foreach (char c in row)
                {
                    if (char.IsDigit(c))
                    {
                        int count = (int)char.GetNumericValue(c);
                        sb.Append('0', count);
                    }
                    else
                    {
                        if (!isFirst && Char.IsDigit(c))
                        {
                            sb.Append('/');
                        }

                        sb.Append(c);
                        isFirst = false;
                    }
                }
                    sb.Append(' ');

            }

            

            return sb.ToString().Trim();
        }
    }
}

