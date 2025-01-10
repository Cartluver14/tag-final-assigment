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
        Texture2D pigTexture, pigLeftTexture, pigRightTexture, pigUpTexture, pigDownTexture;
        Texture2D samTexture, samLeftTexture, samRightTexture, samUpTexture, samDowntexture;
        Rectangle pigLocation;
        Rectangle samLocation;
        Vector2 pigSpeed;
        Vector2 samSpeed;
        Texture2D groundTexture;
        Rectangle groundRect;
        Rectangle window;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
           
        }

        protected override void Initialize()
        {
            pigLocation = new Rectangle(300, 300, 80, 80);
            samLocation = new Rectangle(25, 25, 50, 50);
            groundRect = new Rectangle(0, 825, 1250, 75);
            window = new Rectangle(0, 0, 1250, 900);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here



            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            pigUpTexture = Content.Load<Texture2D>("pig up");
            pigDownTexture = Content.Load<Texture2D>("pig down");
            pigLeftTexture = Content.Load<Texture2D>("pig left");
            pigRightTexture = Content.Load<Texture2D>("pig right");

            pigTexture = pigRightTexture;

            samUpTexture = Content.Load<Texture2D>("sam up");
            samDownTexture = Content.Load<Texture2D>("sam down");
            samLeftTexture = Content.Load<Texture2D>("sam left");
            samRightTexture = Content.Load<Texture2D>("sam right");

            samTexture = samRightTexture;





            groundTexture = Content.Load<Texture2D>("ground");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            pigSpeed = new Vector2();
            samSpeed = new Vector2();
            keyboardState = Keyboard.GetState();
            pigSpeed = Vector2.Zero; 
            if (keyboardState.IsKeyDown(Keys.Up)) 
            { 
                pigSpeed.Y -= 6;
                pigTexture = pigUpTexture;
            }
            if (keyboardState.IsKeyDown(Keys.Down)) 
            { 
                pigSpeed.Y += 6; 
                pigTexture = pigDownTexture;
            }
            if (keyboardState.IsKeyDown(Keys.Left)) 
            { 
                pigSpeed.X -= 6; 
                pigTexture = pigLeftTexture;
            }
            if (keyboardState.IsKeyDown(Keys.Right)) 
            { 
                pigSpeed.X += 6; 
                pigTexture = pigRightTexture;
            }
            pigLocation.Offset(pigSpeed);

            samSpeed = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.W))
            {
                samSpeed.Y -= 6;
                samTexture = samUpTexture;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            { 
                bluesquareSpeed.Y += 6; 
            }
            if (keyboardState.IsKeyDown(Keys.A)) 
            { 
                bluesquareSpeed.X -= 6; 
            }
            if (keyboardState.IsKeyDown(Keys.D)) 
            { 
                bluesquareSpeed.X += 6; 
            }
            bluesquareLocation.Offset(bluesquareSpeed);

            if (pigLocation.Intersects(groundRect))
            {
                pigLocation.Offset(-pigSpeed);
            }
            if (bluesquareLocation.Intersects(groundRect))
            {

                bluesquareLocation.Offset(-bluesquareSpeed);
            }


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
            _spriteBatch.Draw(pigTexture, pigLocation, Color.White);
            _spriteBatch.Draw(bluesquareTexture, bluesquareLocation, Color.White);
            _spriteBatch.Draw(groundTexture, groundRect, Color.White);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
