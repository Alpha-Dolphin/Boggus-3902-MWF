using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools.GateObjects
{
    internal class EastWall : IGate
    {
        private /*static*/ int xPosition = GateConstants.EAST_INITIAL_X;
        private /*static*/ int yPosition = GateConstants.EAST_INITIAL_Y;
        private Direction direction = Direction.East;
        private bool doorOpen = false;
        private Sprite closedSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, GateConstants.EAST_INITIAL_X, GateConstants.EAST_INITIAL_Y, new List<Rectangle>() { new Rectangle(815, 77, 32, 32) });
        private Sprite openSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, GateConstants.EAST_INITIAL_X, GateConstants.EAST_INITIAL_Y, new List<Rectangle>() { new Rectangle(815, 77, 32, 32) });
        public void Open()
        {

        }
        public void Close()
        {

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
