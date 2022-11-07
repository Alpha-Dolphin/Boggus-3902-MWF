using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools.PlayerObjects
{
    internal interface IPlayer : ICollidable, ICharacter
    {
        void Move(PlayerConstants.Direction direction);

        void Attack();

        void Damage();

        void UseItem(int input);

        void Draw(SpriteBatch spriteBatch);

        List<ICollidable> GetHitboxes();
    }
}