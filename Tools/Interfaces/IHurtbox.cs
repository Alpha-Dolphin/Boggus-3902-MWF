using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LOZ.Tools.Interfaces
{
    public interface IHurtbox
    {
        List<Rectangle> GetHitboxes();
    }
}
