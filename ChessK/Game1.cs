using System.Diagnostics;
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
            square = Content.Load<Texture2D>("Square");
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
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
            _spriteBatch.Begin();
            foreach (Square square in board.getBoard())
            {
                square.texture = this.square;
                

                if(square.getColor() == "white") _spriteBatch.Draw(square.texture, new Rectangle(square.getRow() * offset + horizontalOffset, square.getColumn() * offset, offset, offset), Color.White);
                else _spriteBatch.Draw(square.texture, new Rectangle(square.getRow() * offset + horizontalOffset, square.getColumn() * offset, offset, offset), Color.Black);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
