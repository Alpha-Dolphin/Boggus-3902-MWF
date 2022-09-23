﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong
{
    internal interface ISprite
    {
        // Push test...
        void Draw(SpriteBatch _spriteBatch);
        void Update(GameTime gameTime);
    }
}
