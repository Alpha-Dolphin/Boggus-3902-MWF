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
    internal class WinScreen
    {
        Rectangle sourceRectangle;
        Rectangle destinationRectangle;

        
        public void Draw(Texture2D FontSpriteSheet, SpriteBatch spriteBatch)
        {
            Texture2D blackRectangle = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            blackRectangle.SetData(new[] { Color.Black });
            spriteBatch.Draw(blackRectangle, new Rectangle(0, 0, EnvironmentConstants.SCREEN_WIDTH, EnvironmentConstants.SCREEN_HEIGHT), Color.Black);
            sourceRectangle = new Rectangle(56, 312, 8, 8);
            destinationRectangle = new Rectangle(EnvironmentConstants.SCREEN_WIDTH / 2 - 80, EnvironmentConstants.SCREEN_HEIGHT / 2, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(152, 296, 8, 8);
            destinationRectangle = new Rectangle(EnvironmentConstants.SCREEN_WIDTH / 2 - 56, EnvironmentConstants.SCREEN_HEIGHT / 2, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(248, 296, 8, 8);
            destinationRectangle = new Rectangle(EnvironmentConstants.SCREEN_WIDTH / 2 - 32, EnvironmentConstants.SCREEN_HEIGHT / 2, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(24, 312, 8, 8);
            destinationRectangle = new Rectangle(EnvironmentConstants.SCREEN_WIDTH / 2 - 80, EnvironmentConstants.SCREEN_HEIGHT / 2+55, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(56, 296, 8, 8);
            destinationRectangle = new Rectangle(EnvironmentConstants.SCREEN_WIDTH / 2 - 56, EnvironmentConstants.SCREEN_HEIGHT / 2+55, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(136, 296, 8, 8);
            destinationRectangle = new Rectangle(EnvironmentConstants.SCREEN_WIDTH / 2 - 32, EnvironmentConstants.SCREEN_HEIGHT / 2 + 55, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

    }
}

