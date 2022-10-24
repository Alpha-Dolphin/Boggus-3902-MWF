using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.PlayerObjects
{
    internal class Weapon : ICollidable
    {
        Rectangle r;
        public Rectangle GetHurtbox()
        {
            return r;
        }

        public void SetHurtbox(Rectangle rect)
        {
            r = rect;
        }
    }
}
