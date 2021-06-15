using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game4
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont fontInGame;
        int _total_frames = 0;
        float _elapsed_time = 0.0f;
        int _fps = 0;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fontInGame = Content.Load<SpriteFont>("fontInGame");
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
          
            _elapsed_time += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (_elapsed_time > 1000.0f) // в орининале запись такая, но не компилится:  if (_elapsed_time &gt;= 1000.0f)

            {
                _fps = _total_frames;
                _total_frames = 0;
                _elapsed_time = 0;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _total_frames++;
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.DrawString(fontInGame, string.Format($"FPS={0}", _fps),
               new Vector2(0, 0), Color.White);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
