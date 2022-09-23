/*Deprecated file but useful code may be in here*/

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata;


namespace LOZ.DeprecatedFiles
{
    internal class DoomGuyAnimatedLookAnimatedMotion : ISprite
    {
        int frameCounter;
        Rectangle index;
        bool LR = false;
        int width;
        int height;

        public DoomGuyAnimatedLookAnimatedMotion(int width, int height)
        {
            this.width = width;
            this.height = height;
            DoomGame.DoomGuyPosition.X = width / 2;
            DoomGame.DoomGuyPosition.Y = height / 2;
        }

        public void Update(GameTime gameTime)
        {
            Rectangle DoomGuyRightLook = new Rectangle(443, 1, 140, 170);
            Rectangle DoomGuyCenterLook = new Rectangle(589, 1, 140, 170);
            Rectangle DoomGuyLeftLook = new Rectangle(734, 1, 140, 170);

            if (frameCounter >= 100 && index == DoomGuyCenterLook)
            {
                index = LR ? DoomGuyRightLook : DoomGuyLeftLook;
                LR = !LR;
                frameCounter = 0;
            }
            else if (frameCounter >= 20 && index != DoomGuyCenterLook)
            {
                index = DoomGuyCenterLook;
                frameCounter = 0;
            }
            frameCounter++;

            DoomGame.DoomGuyPosition.X -= 5;
            if (DoomGame.DoomGuyPosition.X < 0 - index.Width / 2) DoomGame.DoomGuyPosition.X = width + index.Width / 2;
        }
        public void Draw(SpriteBatch _spriteBatch)
        {

            _spriteBatch.Begin();

            _spriteBatch.Draw(
                DoomGame.DoomGuyMasterLook,
                DoomGame.DoomGuyPosition,
                index,
                Color.White,
                0f,
                new Vector2(index.Width / 2, index.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f
            );

            _spriteBatch.End();
        }
    }
}
