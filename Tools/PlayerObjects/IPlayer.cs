using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools.PlayerObjects
{
    internal interface IPlayer : ICollidable
    {
        void Move(PlayerConstants.Direction direction);

        void Attack();

        void Damage();

        void UseItem(int input);
        void Teleport(int xPos, int yPos);

        void Draw(SpriteBatch spriteBatch);

        List<ICollidable> GetHitboxes();
    }
}