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
		public void HandleTransition(int state,Texture2D FontSpriteSheet, SpriteBatch spriteBatch)
		{
			switch (state)
			{
				case 0:
					GameOverScreenState.Draw(FontSpriteSheet,spriteBatch);
					break;
			}

		}
					
	}
}
