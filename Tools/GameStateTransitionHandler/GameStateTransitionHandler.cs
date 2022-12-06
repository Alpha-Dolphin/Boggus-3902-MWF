using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.LevelManager;
using LOZ.Tools.PlayerObjects;
using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LOZ.Tools.GameStateTransitionHandler
{
	internal class GameStateTransitionHandler
	{
        GameOverScreen GameOverScreenState = new GameOverScreen();
        PauseScreen PauseScreenState = new PauseScreen();
        WinScreen WinScreenState = new WinScreen();
        RoomTransitionScreen RoomTransitionScreenState = new RoomTransitionScreen();

        public void HandleTransition(int state, Texture2D FontSpriteSheet, SpriteBatch spriteBatch, GameTime gameTime)
        {
            switch (state)
            {
                case 0:
                    GameOverScreenState.Draw(FontSpriteSheet, spriteBatch, gameTime);
                    break;
                case 1:
                    PauseScreenState.Draw(FontSpriteSheet, spriteBatch, gameTime);
                    break;
                case 2:
                    WinScreenState.Draw(FontSpriteSheet, spriteBatch);
                    break;
                case 3:
                    if (RoomTransitionScreenState.Draw(FontSpriteSheet, spriteBatch, gameTime) == 1)
                    {
                        Game1.gameState = 4;
                    }
                    break;
                case 4:
                    break;
            }
            
        }

    }
}
