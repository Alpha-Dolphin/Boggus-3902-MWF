using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.EnvironmentObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LOZ.Tools.GameStateTransitionHandler
{

    internal class GameOverScreen
    {
        Rectangle sourceRectangle;
        Rectangle destinationRectangle;
        public void Draw(Texture2D FontSpriteSheet, SpriteBatch spriteBatch)
        {
            Texture2D blackRectangle = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            blackRectangle.SetData(new[] { Color.Black });
            spriteBatch.Draw(blackRectangle, new Rectangle(0, 0, 100, 100), Color.Black);
            sourceRectangle = new Rectangle(336, 40, 7, 7);
            destinationRectangle = new Rectangle(100,300,21,21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(496, 24, 7, 7);
            destinationRectangle = new Rectangle(121, 300, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(432, 40, 7, 7);
            destinationRectangle = new Rectangle(142, 300, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(560, 24, 7, 7);
            destinationRectangle = new Rectangle(163, 300, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(464, 40, 7, 7);
            destinationRectangle = new Rectangle(210, 300, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(576, 40, 7, 7);
            destinationRectangle = new Rectangle(231, 300, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(560, 24, 7, 7);
            destinationRectangle = new Rectangle(252, 300, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
            sourceRectangle = new Rectangle(512, 40, 7, 7);
            destinationRectangle = new Rectangle(273, 300, 21, 21);
            spriteBatch.Draw(FontSpriteSheet, destinationRectangle, sourceRectangle, Color.White);
        }

    }
}
