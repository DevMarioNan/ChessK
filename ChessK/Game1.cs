using System.Diagnostics;
using ChessK.ChessPieces;
using ChessK.Util;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ChessK
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Board board;
        private Texture2D square;
        private Texture2D pieces;

        private int offset = 90;
        private int horizontalOffset;

        private MouseState _currentMouseState;
        private MouseState _previousMouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;

            horizontalOffset = (_graphics.PreferredBackBufferWidth - 750) /2;

            board = new Board();
        }

        protected override void Initialize()
        {
            
            // TODO: Add your initialization logic here
            
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            square = Content.Load<Texture2D>("Square");
            pieces = Content.Load<Texture2D>("Pieces");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _currentMouseState = Mouse.GetState();
            if(_currentMouseState.LeftButton == ButtonState.Pressed && _previousMouseState.LeftButton == ButtonState.Released)
            {
                
                int column = (_currentMouseState.X - horizontalOffset) / offset;
                int row = _currentMouseState.Y / offset;

                // Check if the click is within the chessboard bounds
                if (_currentMouseState.X >= horizontalOffset && _currentMouseState.X < horizontalOffset + 8 * offset &&
                    _currentMouseState.Y >= 0 && _currentMouseState.Y < 8 * offset)
                {
                    if (row >= 0 && row < 8 && column >= 0 && column < 8)
                    {
                        Square square = board.getSquare(row, column);
                        Debug.WriteLine(square.getPos());
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DimGray);

            // TODO: Add your drawing code here
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            foreach (Square square in board.getBoard())
            {
                square.texture = this.square;

                if(square.getColor() == "white") _spriteBatch.Draw(square.texture, new Rectangle(square.getRow() * offset + horizontalOffset, square.getColumn() * offset, offset, offset), Color.White);
                else _spriteBatch.Draw(square.texture, new Rectangle(square.getRow() * offset + horizontalOffset, square.getColumn() * offset, offset, offset), Color.Black);
                
                Piece piece = square.getPiece();
                if(piece == null) continue;
                
                Rectangle sourceRectangle;
                Rectangle destinationRectangle = new Rectangle(square.getRow() * offset + horizontalOffset + 7, square.getColumn() * offset, 80, 80); 
                switch (piece.type)
                {
                    case Piece.ChessPieceType.Rook:

                        if (piece.getColor() == "white")
                        {
                            sourceRectangle = new Rectangle(0, 0, 16, 16); 
                        }
                        else
                        {
                            sourceRectangle = new Rectangle(0, 16, 16, 16); 
                        }
                        _spriteBatch.Draw(pieces, destinationRectangle, sourceRectangle, Color.White);
                        break;

                    case Piece.ChessPieceType.Knight:
                        if (piece.getColor() == "white")
                        {
                            sourceRectangle = new Rectangle(16, 0, 16, 16);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle(16, 16, 16, 16);
                        }
                        _spriteBatch.Draw(pieces, destinationRectangle, sourceRectangle, Color.White);
                        break;

                    case Piece.ChessPieceType.Bishop:
                        if (piece.getColor() == "white")
                        {
                            sourceRectangle = new Rectangle(32, 0, 16, 16);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle(32, 16, 16, 16);
                        }
                        _spriteBatch.Draw(pieces, destinationRectangle, sourceRectangle, Color.White);
                        break;
                    case Piece.ChessPieceType.Queen:
                        if (piece.getColor() == "white")
                        {
                            sourceRectangle = new Rectangle(48, 0, 16, 16);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle(48, 16, 16, 16);
                        }
                        _spriteBatch.Draw(pieces, destinationRectangle, sourceRectangle, Color.White);
                        break;
                    case Piece.ChessPieceType.King:
                        if (piece.getColor() == "white")
                        {
                            sourceRectangle = new Rectangle(64, 0, 16, 16);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle(64, 16, 16, 16);
                        }
                        _spriteBatch.Draw(pieces, destinationRectangle, sourceRectangle, Color.White);
                        break;
                    case Piece.ChessPieceType.Pawn:
                        if (piece.getColor() == "white")
                        {
                            sourceRectangle = new Rectangle(80, 0, 16, 16);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle(80, 16, 16, 16);
                        }
                        _spriteBatch.Draw(pieces, destinationRectangle, sourceRectangle, Color.White);
                        break;

                }



            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
