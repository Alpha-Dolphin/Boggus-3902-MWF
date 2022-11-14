using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.LevelManager;
using LOZ.Tools.PlayerObjects;

namespace LOZ.Tools.RoomTransitionHandler
{
    internal class RoomTransitionHandler
    {
        public void HandleTransition(Room room, IGate gate, Link link)
        {

            switch (gate.GetDirection())
            {
                case Direction.East:
                    LOZ.Game1.currentRoom = room.eastNeighbor;
                    link.Teleport(32, 76);
                    break;
                case Direction.North:
                    LOZ.Game1.currentRoom = room.northNeighbor;
                    link.Teleport(116, 128);
                    break;
                case Direction.West:
                    LOZ.Game1.currentRoom = room.westNeighbor;
                    link.Teleport(207, 76);
                    break;
                case Direction.South:
                    LOZ.Game1.currentRoom = room.southNeighbor;
                    link.Teleport(116, 32);
                    break;

            }
                
        }
        public void HandleTransitionAbs(int roomNumber, IPlayer link, int X, int Y)
        {
            LOZ.Game1.currentRoom = roomNumber;
            link.Teleport(X, Y);
        }
    }
}
