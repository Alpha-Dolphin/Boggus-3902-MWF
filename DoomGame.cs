using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace Pong
{
    public class DoomGame : Game
    {
        ISprite animSet;
        IController keyboard;
        IController mouse;

        public static Texture2D DoomGuyMasterLook;
        public static Vector2 DoomGuyPosition;
        private SpriteFont credits;

        //Public to test out different implimentations
        public GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public DoomGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            DoomGuyPosition = new Vector2(_graphics.PreferredBackBufferWidth,
            _graphics.PreferredBackBufferHeight);
            //ISprite and IController have different args because I wanted to try two different implimentations to see which one I liked better
            animSet = new DoomGuyStaticLookStaticMotion(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            keyboard = new KeyboardClass();
            mouse = new MouseClass();
            credits = Content.Load<SpriteFont>("Credits");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            DoomGuyMasterLook = Content.Load<Texture2D>("DoomGuyMaster");
        }

        protected override void Update(GameTime gameTime)
        {
            ISprite copy = animSet;
            animSet = keyboard.KeyboardInput(this);
            if (animSet == null) animSet = copy;
            else copy = animSet;
            animSet = mouse.MouseInput(this);
            if (animSet == null) animSet = copy;
            //Precaution
            else copy = animSet;
            animSet.Update(gameTime);
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkRed);

            animSet.Draw(_spriteBatch);
            _spriteBatch.Begin();

            _spriteBatch.DrawString(credits, "Credits:", new Vector2(_graphics.PreferredBackBufferWidth / 2 - 33, _graphics.PreferredBackBufferHeight * 3 / 4), Color.Black);
            _spriteBatch.DrawString(credits, "Program made by: Ben Elleman", new Vector2(_graphics.PreferredBackBufferWidth / 4, _graphics.PreferredBackBufferHeight * 3 / 4 + 25), Color.Black);
            _spriteBatch.DrawString(credits, "Sprites from: https://www.deviantart.com/supernaturalboden/art/Classic-Doomguy-HUD-Faces-Transparent-Background-909775694", new Vector2(0, _graphics.PreferredBackBufferHeight * 3 / 4 + 50), Color.Black);
            _spriteBatch.DrawString(credits, "HUD-Faces-Transparent-Background-909775694", new Vector2(125, _graphics.PreferredBackBufferHeight * 3 / 4 + 75), Color.Black);

            _spriteBatch.End();
            base.Update(gameTime);
        }
    }
}