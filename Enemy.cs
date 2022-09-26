using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace
{
    internal interface Enemy
    {
        void Attack(GameTime gameTime);
        void Die(GameTime gameTime);
        void Move(GameTime gameTime);
        void Draw(SpriteBatch _spriteBatch);
        void Update(GameTime gameTime);
    }
}
