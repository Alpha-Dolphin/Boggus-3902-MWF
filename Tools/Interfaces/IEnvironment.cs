
using Microsoft.Xna.Framework.Graphics;


namespace LOZ.Tools.Interfaces
{
    public interface IEnvironment : ICollidable
    {
        void SetPlacement(int x, int y);
        void Draw(SpriteBatch spriteBatch);
    }
}
