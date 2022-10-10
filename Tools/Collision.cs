using LOZ.Tools.Interfaces;
using LOZ.Tools.PlayerObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools
{
    internal class Collision
    {
        bool CollisionChecker(Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }

        void CollisionDirective(Object a, Object b)
        {
            if (a is IEnvironment)
            {
/*                if (b is Enemy b1) collide(a rect, b1 rect);*/
            }
            if (b is IEnvironment)
            {
/*                if (a is Enemy a1) collide(b rect, a1 rect);
                else if (a is Link a2) collide(b rect, a2 rect);*/
            }
            else if (a is Link linka && b is Enemy) linka.Damage();
        }

        void Collide(Rectangle unchanged, Rectangle changed)
        {

        }
    }
}
