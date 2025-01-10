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
        Texture2D walltexture;
        Rectangle pigLocation;
        Rectangle wallrect;
        Rectangle samLocation;

       
        Vector2 pigSpeed;
        Vector2 samSpeed;
        Vector2 wallSpeed;
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
            pigLocation = new Rectangle(300, 300, 50, 50);
            samLocation = new Rectangle(25, 25, 40, 40);
            groundRect = new Rectangle(0, 825, 1250, 75);
            window = new Rectangle(0, 0, 1250, 900);
            wallrect = new Rectangle(0, 0, 30, 100);
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
            walltexture = Content.Load<Texture2D>("wall");

            pigTexture = pigRightTexture;

            samUpTexture = Content.Load<Texture2D>("sam up");
            samDowntexture = Content.Load<Texture2D>("sam down");
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
                samSpeed.Y += 6;
                samTexture = samDowntexture;
            }
            if (keyboardState.IsKeyDown(Keys.A)) 
            { 
                samSpeed.X -= 6; 
                samTexture = samLeftTexture;
            }
            if (keyboardState.IsKeyDown(Keys.D)) 
            { 
                samSpeed.X += 6; 
                samTexture = samRightTexture;
            }
            samLocation.Offset(samSpeed);

            if (pigLocation.Intersects(groundRect))
            {
                pigLocation.Offset(-pigSpeed);
            }
            if (samLocation.Intersects(groundRect))
            {

                samLocation.Offset(-samSpeed);
            }
            if (pigLocation.Intersects(wallrect))
            {
                pigLocation.Offset(-pigSpeed);
            }
            if (samLocation.Intersects(wallrect))
            {

                samLocation.Offset(-samSpeed);
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
            _spriteBatch.Draw(samTexture, samLocation, Color.White);
            _spriteBatch.Draw(groundTexture, groundRect, Color.White);
            _spriteBatch.Draw(walltexture,  wallrect, Color.White); 
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
