﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace tag_final_assigment
{
    public class Game1 : Game
    {
       
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        enum Screen
        {
            start,
            Game,
            Exit
        }
        KeyboardState keyboardState, previosKeyboradstate;
        
        MouseState mouseState;
        Texture2D pigTexture, pigLeftTexture, pigRightTexture, pigUpTexture, pigDownTexture;
        Texture2D samTexture, samLeftTexture, samRightTexture, samUpTexture, samDowntexture;
        Texture2D walltexture;
        SoundEffect music;
        bool sound;
        string whosit;
        float seconds;
        float gametimer;

        Texture2D portaltexture;
        Texture2D bushtexture;
        Texture2D backgroundtexture;
        Texture2D triangletexture;
        Texture2D textboxtexture;
        Texture2D startscreentexture;
        Texture2D exitscreentexture;
        Rectangle pigLocation;
        Rectangle textboxrect;
        Rectangle startscreenrect;
        Rectangle exitscreenrect;
        Rectangle backgroundrect;
        Rectangle bushrect;
        Rectangle wall1rect, wall2rect, wall3rect, wall4rect;
        Rectangle samLocation;
        Rectangle trianglelocation;
        Rectangle portal1rect, portal2rect;
        List<Rectangle> wall;
        SpriteFont text;

        Screen screen;

        Vector2 pigSpeed;
        Vector2 trianglespeed;
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
            screen = Screen.start;
           
            backgroundrect = new Rectangle(0, 0, 1250, 900);
            trianglelocation = new Rectangle(1000, 35, 50, 50);
            pigLocation = new Rectangle(1100, 40, 50, 50);
            bushrect = new Rectangle(450, 170, 300, 300);
            portal1rect = new Rectangle(-15, 740, 100, 100);
            portal2rect = new Rectangle(1165, 740, 100, 100);
            samLocation = new Rectangle(110, 25, 40, 40);
            groundRect = new Rectangle(0, 825, 1250, 75);
            seconds = 0;
            gametimer = 5;
            window = new Rectangle(0, 0, 1250, 900);
            wall1rect = new Rectangle(0, 0, -0, 1250);
            wall2rect = new Rectangle(5, -0, 1250, 10);
            wall3rect = new Rectangle(1250, 20, 10, 900);
            wall4rect = new Rectangle(60, 100, 200, 10);
            wall = new List<Rectangle>();
            wall.Add(new Rectangle(985, 105, 200, 10));
            wall.Add(new Rectangle(260, 250, 300, 10));
            wall.Add(new Rectangle(670, 250, 260, 10));
            wall.Add(new Rectangle(0, 250, 150, 10));
            wall.Add(new Rectangle(1030, 250, 300, 10));
            wall.Add(new Rectangle(60, 400, 150, 10));
            wall.Add(new Rectangle(300, 400, 650, 10));
            wall.Add(new Rectangle(1050, 400, 120, 10));
            wall.Add(new Rectangle(60, 400, 10, 427));
            wall.Add(new Rectangle(1170, 400, 10, 427));
            whosit = "pig";


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
            portaltexture = Content.Load<Texture2D>("portal");
            bushtexture = Content.Load<Texture2D>("bush");
            triangletexture = Content.Load<Texture2D>("triangle");
            backgroundtexture = Content.Load<Texture2D>("background");
            text = Content.Load<SpriteFont>("Text");
            startscreentexture = Content.Load<Texture2D>("start screen");
            music = Content.Load<SoundEffect>("music");
            exitscreentexture = Content.Load<Texture2D>("exit screen");
            

            // backgroundtexture = Content

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
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();


            if (screen == Screen.start)
            {
                if (keyboardState.IsKeyDown(Keys.Enter))

                    screen = Screen.Game;
            }
            else if (screen == Screen.Game)
            {

                this.Window.Title = $"x = {mouseState.X}, y = {mouseState.Y}";
                seconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
                gametimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                pigSpeed = new Vector2();
                samSpeed = new Vector2();
                pigSpeed = Vector2.Zero;
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    pigSpeed.Y -= 7
                        ;
                    pigTexture = pigUpTexture;
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    pigSpeed.Y += 7;
                    pigTexture = pigDownTexture;
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    pigSpeed.X -= 7;
                    pigTexture = pigLeftTexture;
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    pigSpeed.X += 7;
                    pigTexture = pigRightTexture;
                }
                pigLocation.Offset(pigSpeed);

                if (portal1rect.Contains(pigLocation))
                {
                    pigLocation.X = 540;
                    pigLocation.Y = 350;

                }
                if (portal2rect.Contains(samLocation))
                {
                    samLocation.X = 540;
                    samLocation.Y = 350;

                }

                if (portal2rect.Contains(pigLocation))
                {
                    pigLocation.X = 540;
                    pigLocation.Y = 350;

                }
                if (portal1rect.Contains(samLocation))
                {
                    samLocation.X = 540;
                    samLocation.Y = 350;

                }



                samSpeed = Vector2.Zero;
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    samSpeed.Y -= 7;
                    samTexture = samUpTexture;
                }
                if (keyboardState.IsKeyDown(Keys.S))
                {
                    samSpeed.Y += 7;
                    samTexture = samDowntexture;
                }
                if (keyboardState.IsKeyDown(Keys.A))
                {
                    samSpeed.X -= 7;
                    samTexture = samLeftTexture;
                }
                if (keyboardState.IsKeyDown(Keys.D))
                {
                    samSpeed.X += 7;
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
                if (pigLocation.Intersects(wall1rect))
                {
                    pigLocation.Offset(-pigSpeed);
                }
                if (samLocation.Intersects(wall1rect))
                {

                    samLocation.Offset(-samSpeed);
                }




                if (pigLocation.Intersects(wall2rect))
                {
                    pigLocation.Offset(-pigSpeed);
                }
                if (samLocation.Intersects(wall2rect))
                {

                    samLocation.Offset(-samSpeed);
                }

                if (pigLocation.Intersects(wall3rect))
                {
                    pigLocation.Offset(-pigSpeed);
                }
                if (samLocation.Intersects(wall3rect))
                {

                    samLocation.Offset(-samSpeed);
                }
                if (pigLocation.Intersects(wall4rect))
                {
                    pigLocation.Offset(-pigSpeed);
                }
                if (samLocation.Intersects(wall4rect))
                {

                    samLocation.Offset(-samSpeed);
                }
                for (int i = 0; i < wall.Count; i++)
                {
                    if (pigLocation.Intersects(wall[i]))
                    {
                        pigLocation.Offset(-pigSpeed);
                    }

                }
                for (int i = 0; i < wall.Count; i++)
                {
                    if (samLocation.Intersects(wall[i]))
                    {
                        samLocation.Offset(-samSpeed);
                    }

                }

                if (pigLocation.Intersects(samLocation) && seconds >= 2)
                {
                    seconds = 0;
                    if (whosit == "pig")
                        whosit = "sam";
                    else
                        whosit = "pig";




                }
                //if (pigLocation.Intersects(samLocation))
                //{
                //    pigLocation.Offset(-pigSpeed); 
                //    samLocation.Offset(-samSpeed);
                //}





                if (whosit == "pig")
                {
                    trianglelocation.X = pigLocation.X + 0;
                    trianglelocation.Y = pigLocation.Y + -30;
                }
                else if (whosit == "sam")
                {
                    trianglelocation.X = samLocation.X + 0;
                    trianglelocation.Y = samLocation.Y + -30;

                }
                if (gametimer <= 0)
                {
                    screen = Screen.Exit;
                }





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
            if (screen == Screen.start)
            {
                

                
                if(sound == false)
                {
                    music.Play();
                    sound = true;
                }
                _spriteBatch.Draw(startscreentexture, window, Color.White);

            }
            else if (screen == Screen.Game)
            {



                _spriteBatch.Draw(backgroundtexture, backgroundrect, Color.White);
                _spriteBatch.Draw(pigTexture, pigLocation, Color.White);
                _spriteBatch.Draw(samTexture, samLocation, Color.White);
                _spriteBatch.Draw(groundTexture, groundRect, Color.White);
                _spriteBatch.Draw(walltexture, wall1rect, Color.White);
                _spriteBatch.Draw(walltexture, wall2rect, Color.White);
                _spriteBatch.Draw(walltexture, wall3rect, Color.White);
                _spriteBatch.Draw(walltexture, wall4rect, Color.Red);
                _spriteBatch.Draw(portaltexture, portal1rect, Color.White);
                _spriteBatch.Draw(portaltexture, portal2rect, Color.White);
                _spriteBatch.Draw(triangletexture, trianglelocation, Color.White);
                _spriteBatch.Draw(bushtexture, bushrect, Color.White);

                _spriteBatch.DrawString(text, gametimer.ToString("0"), new Vector2(575, 20), Color.Black);

                foreach (Rectangle barrier in wall)
                    _spriteBatch.Draw(walltexture, barrier, Color.Red);

                

            }
            else if (screen == Screen.Exit)
            {
                _spriteBatch.Draw(exitscreentexture,window , Color.White);
            }

            _spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}