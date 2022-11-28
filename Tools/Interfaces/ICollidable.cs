using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools.Interfaces
{
    public interface ICollidable
    {
        Rectangle GetHurtbox();
        void SetHurtbox(Rectangle rect);
    }
}
