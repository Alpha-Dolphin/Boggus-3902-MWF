using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LOZ.Tools.Interfaces
{
    public interface ISprite
    {
        void Update(int x, int y);
        //void initialize();
        bool Finished();
        void Draw(SpriteBatch spriteBatch);
    }
}

