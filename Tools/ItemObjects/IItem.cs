using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Tools.Interfaces;


namespace LOZ.Tools.ItemObjects
{
    public interface IItem : ICollidable
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gametime);
        Vector2 GetPosition();
        void SetPlacement(int x, int y);

        //PlayerConstants.Pickupable_Items GetType();

    }
}
