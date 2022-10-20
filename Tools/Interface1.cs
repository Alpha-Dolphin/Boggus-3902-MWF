using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools
{
    internal interface ICollision
    {
        bool Intersects(Rectangle a, Rectangle b);

        void Collide(Object a, Object b);
    }
}
