using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.PlayerObjects;


namespace LOZ.Tools.ItemObjects
{
    public interface IItem
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(GameTime gametime);
        Vector2 GetPosition();
        void SetPlacement(int x, int y);

        //PlayerConstants.Pickupable_Items GetType();

    }
}
