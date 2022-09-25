using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LOZ.Tools.PlayerObjects
{
    internal interface IPlayer
    {
        void Move(Link_Constants.Direction direction);

        void Attack();

        void Damage();

        void ChangeItem(int input);

        void Draw(SpriteBatch spriteBatch);
    }
}