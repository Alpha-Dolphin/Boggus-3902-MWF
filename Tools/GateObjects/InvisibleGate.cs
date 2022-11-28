using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using LOZ.Tools.Interfaces;

namespace LOZ.Tools.GateObjects
{
    internal class InvisibleGate : IGate
    {
        private int xPosition = GateConstants.ITEM_ROOM_GATE_X;
        private int yPosition = GateConstants.ITEM_ROOM_GATE_Y;
        private Direction direction = Direction.Up;
        private bool doorOpen = true;
        private Sprite closedSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, GateConstants.ITEM_ROOM_GATE_X, GateConstants.ITEM_ROOM_GATE_Y, new List<Rectangle>() { new Rectangle(1035, 28, 16, 1) });
        private Sprite openSprite = new Sprite(Game1.ENVIRONMENT_SPRITESHEET, GateConstants.ITEM_ROOM_GATE_X, GateConstants.ITEM_ROOM_GATE_Y, new List<Rectangle>() { new Rectangle(1035, 28, 16, 1) });
        public void Open()
        {

        }
        public void Close()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

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