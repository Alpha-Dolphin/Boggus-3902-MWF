using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace LOZ.Tools.Sprites
{
    internal interface ISprite
    {
        void Draw(SpriteBatch _spriteBatch);
        void Update(GameTime gameTime);
    }
}
