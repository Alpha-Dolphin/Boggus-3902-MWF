using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong
{
    internal interface IController
    {
        ISprite KeyboardInput(DoomGame doomGame);
        ISprite MouseInput(DoomGame doomGame);
    }
}
