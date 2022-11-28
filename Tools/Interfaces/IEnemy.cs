using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LOZ.Tools.Interfaces
{
    public interface IEnemy : ICollidable
    {
        void Attack(GameTime gameTime);
        void Damage();
        void Move(GameTime gameTime);
        void Draw(SpriteBatch _spriteBatch);
        void Update(GameTime gameTime);

        static Rectangle Appear(double time)
        {
            Rectangle[] cloudFrames = new[] { new Rectangle(138, 185, 16, 16), new Rectangle(155, 185, 16, 16), new Rectangle(172, 185, 16, 16) };
            return cloudFrames[(int)((time) / (Constants.enemyEntryExitTime / 3)) % 3];
        }

        static Rectangle Disappear(double time)
        {
            Rectangle[] explostionFrames = new[] { new Rectangle(0, 0, 16, 16), new Rectangle(0, 16, 16, 16), new Rectangle(35, 3, 9, 10), new Rectangle(51, 3, 9, 10) };
            return explostionFrames[(int)(time / (Constants.enemyEntryExitTime / 4)) % 4];
        }
    }
}
