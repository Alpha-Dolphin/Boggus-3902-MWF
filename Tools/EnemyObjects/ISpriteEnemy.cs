using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LOZ.Tools
{
    internal interface ISpriteEnemy
    {
        void Draw(SpriteBatch _spriteBatch, Vector2 enemyPosition);
        void Update(GameTime gameTime);
    }
}