using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    internal interface IProjectile
    {
        public void SetVelocity(Vector2 velocity);
        public Vector2 Update();
        public void Draw(SpriteBatch spriteBatch);
        public void Destroy();
        public bool stillExists();
    }
}