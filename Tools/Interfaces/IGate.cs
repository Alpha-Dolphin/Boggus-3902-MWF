using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LOZ.Tools.Interfaces
{
    public interface IGate : ICollidable
    {
        void Open();
        void Close();
        Direction GetDirection();
        bool IsGateOpen();
        void Draw(SpriteBatch spriteBatch);
    }
}
