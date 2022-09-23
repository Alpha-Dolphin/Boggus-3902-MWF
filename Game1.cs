﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace LOZ
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        private string creditsString = "Credits\nProgram Made By: Team BoggusMWF\nSprites from: https://www.spriters-resource.com/nes/legendofzelda/";

        /*Declaration of controllers*/
        
        /*Container for sprites to draw in order*/
        private HashSet<ISprite> spritesToDraw = new HashSet<ISprite>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
        }

        protected override void Update(GameTime gameTime)
        {
            
            /*
             * Update logic here, the objects here will 
             * also need to add the sprites to draw to 
             * the sprites to draw list
             * or will need to draw them themselves, IN ORDER AS APPROPRIATE
             */

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

           
            /*Sprites to draw need to be in order in spritesToDrawList by here*/
            foreach (var item in spritesToDraw)
            {
                item.draw(spriteBatch);
            }

            spritesToDraw.Clear();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}