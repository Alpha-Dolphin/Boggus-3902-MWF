using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LOZ.Tools.GateObjects;
using LOZ.Tools.HUDObjects;
using LOZ.Tools.LevelManager;
using LOZ.Tools.PlayerObjects;
using LOZ.Tools.Sprites;
using Microsoft.Xna.Framework;

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
                case Direction.Down:
                    LOZ.Game1.currentRoom = room.downNeighbor;
                    link.Teleport(48, 1 + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale);
                    break;
                case Direction.Up:
                    LOZ.Game1.currentRoom = room.upNeighbor;
                    link.Teleport(112, 80 + HUDConstants.TOP_HEIGHT / AnimatedMovingSprite.yScale);
                    break;

            }
                
        }
        public void unlockDoor(IGate gate,List<Room> rooms,int currentRoomNum)
        {
            if(
            gate.GetType().Equals(typeof(WestKeyholeDoor))
            || gate.GetType().Equals(typeof(EastKeyholeDoor))
            || gate.GetType().Equals(typeof(NorthKeyholeDoor))
            || gate.GetType().Equals(typeof(SouthKeyholeDoor)))
            {
                int neighborNum;
                gate.Open();

                switch (gate.GetDirection())
                {
                    case Direction.East:
                        neighborNum = rooms[currentRoomNum].eastNeighbor;
                        foreach (IGate neighborGate in rooms[neighborNum].gateList)
                        {
                            if (neighborGate.GetDirection() == Direction.West)
                            {
                                neighborGate.Open();
                            }
                        }
                        break;
                    case Direction.North:
                        neighborNum = rooms[currentRoomNum].northNeighbor;
                        foreach (IGate neighborGate in rooms[neighborNum].gateList)
                        {
                            if (neighborGate.GetDirection() == Direction.South)
                            {
                                neighborGate.Open();
                            }
                        }
                        break;
                    case Direction.West:
                        neighborNum = rooms[currentRoomNum].westNeighbor;
                        foreach (IGate neighborGate in rooms[neighborNum].gateList)
                        {
                            if (neighborGate.GetDirection() == Direction.East)
                            {
                                neighborGate.Open();
                            }
                        }
                        break;
                    case Direction.South:
                        neighborNum = rooms[currentRoomNum].southNeighbor;
                        foreach (IGate neighborGate in rooms[neighborNum].gateList)
                        {
                            if (neighborGate.GetDirection() == Direction.North)
                            {
                                neighborGate.Open();
                            }
                        }
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
