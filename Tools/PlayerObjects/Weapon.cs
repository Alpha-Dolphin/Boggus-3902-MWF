using Microsoft.Xna.Framework;
using LOZ.Tools.Interfaces;

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
