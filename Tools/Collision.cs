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
        bool Intersects(Rectangle a, Rectangle b)
        {
            return a.Intersects(b);
        }
        void CollisionChecker(Object a, Object b)
        {
            //This code could be simplified if it can be guranteed Link will always be the 1st (or last) object in the array of collidable objects
            if (a is IEnvironment)
            {
/*                if (b is Enemy b1) collide(b1 rect);
                else if (b is Link b2) collide(b2 rect);*/
            }
            if (b is IEnvironment)
            {
/*                if (a is Enemy a1) collide(a1 rect);
                else if (a is Link a2) collide(a2 rect);*/
            }
            else if (a is Link linka && b is Enemy) linka.Damage();
            else if (a is Enemy && b is Link linkb) linkb.Damage();
        }
    }
}
