using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOZ.Tools.GateObjects
{
    internal class WestKeyholeDoor : IGate
    {
        private static int xPosition = 0;
        private static int yPosition = 72;
        private Direction direction = Direction.West;
        private bool doorOpen = false;
        private Sprite closedSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, xPosition, yPosition, new List<Rectangle>() { new Rectangle(881, 44, 32, 32) });
        private Sprite openSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, xPosition, yPosition, new List<Rectangle>() { new Rectangle(848, 44, 32, 32) });
        public void open()
        {
            doorOpen = true;
        }
        public void close()
        {
            doorOpen = false;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            if (doorOpen)
            {
                openSprite.Draw(spriteBatch);
            }
            else
            {
                closedSprite.Draw(spriteBatch);
            }

        }

        public Rectangle GetHurtbox()
        {
            return new Rectangle(xPosition, yPosition, 32, 32);
        }

        public void SetHurtbox(Rectangle rect)
        {

        }
        public Direction GetDirection()
        {
            return direction;
        }
        public bool isGateOpen()
        {
            return doorOpen;
        }
    }
}
