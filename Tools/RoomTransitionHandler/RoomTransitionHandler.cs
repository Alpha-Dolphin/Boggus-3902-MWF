using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.HUDObjects;
using LOZ.Tools.LevelManager;
using LOZ.Tools.PlayerObjects;
using LOZ.Tools.Sprites;

namespace LOZ.Tools.RoomTransitionHandler
{
    internal class RoomTransitionHandler
    {
        public void handleTransition(Room room, IGate gate, IPlayer link)
        {

            switch (gate.GetDirection())
            {
                case Direction.East:
                    LOZ.Game1.currentRoom = room.eastNeighbor;
                    link.Teleport(32, 76 + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale);
                    break;
                case Direction.North:
                    LOZ.Game1.currentRoom = room.northNeighbor;
                    link.Teleport(116, 128 + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale);
                    break;
                case Direction.West:
                    LOZ.Game1.currentRoom = room.westNeighbor;
                    link.Teleport(207, 76 + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale);
                    break;
                case Direction.South:
                    LOZ.Game1.currentRoom = room.southNeighbor;
                    link.Teleport(116, 32 + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale);
                    break;

            }
                
        }
    }
}
