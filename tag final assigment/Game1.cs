using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tag_final_assigment
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        KeyboardState keyboardState;
        Texture2D redsquareTexture;
        Texture2D bluesquareTexture;
        Rectangle redsquareLocation;
        Vector2 redsquareSpeed;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
           
        }

        protected override void Initialize()
        {
            redsquareLocation = new Rectangle(10, 10, 75, 75);
            // TODO: Add your initialization logic here



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            redsquareTexture = Content.Load<Texture2D>("redsquare");
            bluesquareTexture = Content.Load<Texture2D>("bluesquare");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            redsquareSpeed = new Vector2();
            keyboardState = Keyboard.GetState();
            redsquareSpeed = Vector2.Zero; if (keyboardState.IsKeyDown(Keys.Up)) { redsquareSpeed.Y -= 4; }
            if (keyboardState.IsKeyDown(Keys.Down)) { redsquareSpeed.Y += 4; }
            if (keyboardState.IsKeyDown(Keys.Left)) { redsquareSpeed.X -= 4; }
            if (keyboardState.IsKeyDown(Keys.Right)) { redsquareSpeed.X += 4; }
            redsquareLocation.Offset(redsquareSpeed);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(redsquareTexture, redsquareLocation, Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
