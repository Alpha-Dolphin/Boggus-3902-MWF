using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace LOZ.DeprecatedFiles
{
    internal class KeyboardClass : IController
    {
        public ISprite KeyboardInput(DoomGame doomGame)
        {
            var kstate = Keyboard.GetState();
            if (kstate.IsKeyDown(Keys.D0) || kstate.IsKeyDown(Keys.NumPad0))
            {
                doomGame.Exit();
            }
            else if (kstate.IsKeyDown(Keys.D1) || kstate.IsKeyDown(Keys.NumPad1))
            {
                return new DoomGuyStaticLookStaticMotion(doomGame._graphics.PreferredBackBufferWidth, doomGame._graphics.PreferredBackBufferHeight);
            }
            else if (kstate.IsKeyDown(Keys.D2) || kstate.IsKeyDown(Keys.NumPad2))
            {
                return new DoomGuyAnimatedLookStaticMotion(doomGame._graphics.PreferredBackBufferWidth, doomGame._graphics.PreferredBackBufferHeight);
            }
            else if (kstate.IsKeyDown(Keys.D3) || kstate.IsKeyDown(Keys.NumPad3))
            {
                return new DoomGuyStaticLookAnimatedMotion(doomGame._graphics.PreferredBackBufferWidth, doomGame._graphics.PreferredBackBufferHeight);
            }
            else if (kstate.IsKeyDown(Keys.D4) || kstate.IsKeyDown(Keys.NumPad4))
            {
                return new DoomGuyAnimatedLookAnimatedMotion(doomGame._graphics.PreferredBackBufferWidth, doomGame._graphics.PreferredBackBufferHeight);
            }
            return null;
        }
        public ISprite MouseInput(DoomGame doomGame)
        {
            return null;
        }
    }
}
*/