using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LOZ.Tools.NPCObjects
{
    public interface INPC
    {
        void Draw(SpriteBatch spriteBatch);

        void Update(GameTime gametime);

        void SetPlacement(int x, int y);
    }
}
