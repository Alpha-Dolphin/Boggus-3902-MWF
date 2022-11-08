using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.EnemyObjects
{
    using LOZ.Tools;
    using LOZ;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    namespace LOZ.Tools
    {
        internal class WallMasterSprite : ISpriteEnemy
        {
            Rectangle anim;

            public void Draw(SpriteBatch _spriteBatch, Vector2 enemyPosition)
            {
                _spriteBatch.Draw(
                    Game1.REGULAR_ENEMIES_SPRITESHEET,
                    enemyPosition,
                    anim,
                    Color.White,
                    0f,
                    new Vector2(anim.Width / 2, anim.Height / 2),
                    2,
                    SpriteEffects.None,
                    0f
                );
            }
            public void Update(GameTime gameTime)
            {
                //Nothing
            }

            public void Update(bool grabbed)
            {
                Rectangle[] wallMasterFrames = new[] { new Rectangle(1, 11, 8, 16)};
                anim = grabbed ? wallMasterFrames[1] : wallMasterFrames[0];
            }

            public Vector2 GetWidthHeight()
            {
                return new Vector2(anim.Width, anim.Height);
            }
        }
    }

}
