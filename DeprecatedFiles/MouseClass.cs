using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
namespace LOZ.DeprecatedFiles
{
    internal class MouseClass : IController
    {
        public ISprite MouseInput(DoomGame doomGame)
        {
            var mstate = Mouse.GetState();
            if (mstate.RightButton == ButtonState.Pressed)
            {
                doomGame.Exit();
            }
            if (mstate.LeftButton == ButtonState.Pressed)
            {
                if (mstate.X <= doomGame._graphics.PreferredBackBufferWidth / 2 && mstate.Y <= doomGame._graphics.PreferredBackBufferHeight / 2)
                {
                    return new DoomGuyStaticLookStaticMotion(doomGame._graphics.PreferredBackBufferWidth, doomGame._graphics.PreferredBackBufferHeight);
                }
                else if (mstate.X > doomGame._graphics.PreferredBackBufferWidth / 2 && mstate.Y <= doomGame._graphics.PreferredBackBufferHeight / 2)
                {
                    return new DoomGuyAnimatedLookStaticMotion(doomGame._graphics.PreferredBackBufferWidth, doomGame._graphics.PreferredBackBufferHeight);
                }
                else if (mstate.X <= doomGame._graphics.PreferredBackBufferWidth / 2 && mstate.Y > doomGame._graphics.PreferredBackBufferHeight / 2)
                {
                    return new DoomGuyStaticLookAnimatedMotion(doomGame._graphics.PreferredBackBufferWidth, doomGame._graphics.PreferredBackBufferHeight);
                }
                else if (mstate.X > doomGame._graphics.PreferredBackBufferWidth / 2 && mstate.Y > doomGame._graphics.PreferredBackBufferHeight / 2)
                {
                    return new DoomGuyAnimatedLookAnimatedMotion(doomGame._graphics.PreferredBackBufferWidth, doomGame._graphics.PreferredBackBufferHeight);
                }
            }
            return null;
        }
        public ISprite KeyboardInput(DoomGame doomGame)
        {
            return null;
        }
    }
}
*/