using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.EnvironmentObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LOZ.Tools.GameStateTransitionHandler
{
    internal class PauseScreen
    {
        Rectangle sourceRectangle;
        Rectangle destinationRectangle;
        int mAlphaValue = 1;
        int mFadeIncrement = 3;
        double mFadeDelay = .035;
        
        public void Draw(Texture2D FontSpriteSheet, SpriteBatch spriteBatch, GameTime gameTime)
        {
            Texture2D blackRectangle = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            blackRectangle.SetData(new[] { Color.Black });
            spriteBatch.Draw(blackRectangle, new Rectangle(0, 0, EnvironmentConstants.SCREEN_WIDTH, EnvironmentConstants.SCREEN_HEIGHT), Color.Black);
            sourceRectangle = new Rectangle(168, 296, 7, 7);
            destinationRectangle = new Rectangle(EnvironmentConstants.SCREEN_WIDTH / 2 - 88, EnvironmentConstants.SCREEN_HEIGHT / 2, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(184, 280, 7, 7);
            destinationRectangle = new Rectangle(EnvironmentConstants.SCREEN_WIDTH / 2 - 67, EnvironmentConstants.SCREEN_HEIGHT / 2, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(248, 296, 7, 7);
            destinationRectangle = new Rectangle(EnvironmentConstants.SCREEN_WIDTH / 2 - 46, EnvironmentConstants.SCREEN_HEIGHT / 2, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(216, 296, 7, 7);
            destinationRectangle = new Rectangle(EnvironmentConstants.SCREEN_WIDTH / 2 - 25, EnvironmentConstants.SCREEN_HEIGHT / 2, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(248, 280, 7, 7);
            destinationRectangle = new Rectangle(EnvironmentConstants.SCREEN_WIDTH / 2 - 14, EnvironmentConstants.SCREEN_HEIGHT / 2, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);

            

        }

    }
}

