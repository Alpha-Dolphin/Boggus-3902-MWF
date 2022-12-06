using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.EnvironmentObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LOZ.Tools.LevelManager;
using LOZ.Tools.PlayerObjects;
using LOZ.Tools.Sprites;

namespace LOZ.Tools.GameStateTransitionHandler
{

    internal class RoomTransitionScreen
    {
        Rectangle sourceRectangle;
        Rectangle destinationRectangle;
        int Alpha = 255;
        int FadeIncrement = 5;
        double FadeDelay = 0.1;

        public int Draw(Texture2D FontSpriteSheet, SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            Texture2D blackRectangle = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            blackRectangle.SetData(new[] { Color.Black });
            FadeDelay -= gameTime.ElapsedGameTime.TotalSeconds;
            if (FadeDelay <= 0.1)
            {
                //Reset the Fade delay
                FadeDelay = 0.1;

                //Decrement the fade value for the image
                Alpha -= FadeIncrement;
            }
            if(Alpha <= 0)
            {
                Alpha = 255;
                return 1;
            }
            else
            {
                spriteBatch.Draw(blackRectangle, new Rectangle(0, 0, EnvironmentConstants.SCREEN_WIDTH, EnvironmentConstants.SCREEN_HEIGHT), new Color(255, 255, 255, MathHelper.Clamp(Alpha, 0, 255)));
                return 0;
            }
            
        }

    }
}