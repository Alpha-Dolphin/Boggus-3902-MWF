using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools.GateObjects
{
    internal class WestKeyholeDoor : IGate
    {
        private int xPosition = GateConstants.WEST_INITIAL_X;
        private int yPosition = GateConstants.WEST_INITIAL_Y;
        private Direction direction = Direction.West;
        private bool doorOpen = false;
        private Sprite closedSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, GateConstants.WEST_INITIAL_X, GateConstants.WEST_INITIAL_Y, new List<Rectangle>() { new Rectangle(881, 44, 32, 32) });
        private Sprite openSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, GateConstants.WEST_INITIAL_X, GateConstants.WEST_INITIAL_Y, new List<Rectangle>() { new Rectangle(848, 44, 32, 32) });
        public void Open()
        {
            doorOpen = true;
        }
        public void Close()
        {
            doorOpen = false;
        }

        public void Draw(SpriteBatch spriteBatch)
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
            return new Rectangle(xPosition, yPosition, closedSprite.width, closedSprite.height);
        }

        public void SetHurtbox(Rectangle rect)
        {
            xPosition = rect.X;
            yPosition = rect.Y;
            closedSprite.Update(rect.X, rect.Y);
            openSprite.Update(rect.X, rect.Y);
        }
        public Direction GetDirection()
        {
            return direction;
        }
        public bool IsGateOpen()
        {
            return doorOpen;
        }
    }
}
